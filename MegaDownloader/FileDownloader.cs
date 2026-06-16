using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class FileDownloader : IDisposable
{
	public class DataPart
	{
		public class Chunk
		{
			public long StartIndex;

			public long Size;

			public long Index;

			public bool Available;

			public Chunk()
			{
				StartIndex = 0L;
				Size = 0L;
				Index = 0L;
				Available = true;
			}
		}

		public List<Chunk> ChunkList;

		public bool AllFinished;

		private System.Threading.Mutex _Mutex;

		public int? NextAvailablePartIndex
		{
			get
			{
				_Mutex.WaitOne();
				int? result = null;
				int num = 0;
				foreach (Chunk chunk in ChunkList)
				{
					if (chunk.Available)
					{
						result = num;
						chunk.Available = false;
						break;
					}
					num = checked(num + 1);
				}
				_Mutex.ReleaseMutex();
				return result;
			}
		}

		public DataPart()
		{
			_Mutex = new System.Threading.Mutex();
			AllFinished = false;
			ChunkList = new List<Chunk>();
		}

		public DataPart(long size, int numParts)
			: this()
		{
			long num = checked((long)Math.Ceiling((double)size / (double)numParts));
			long num2 = 16384L;
			if (size < num2 || numParts < 2 || num < num2)
			{
				Chunk chunk = new Chunk
				{
					StartIndex = 0L,
					Index = 0L,
					Size = size,
					Available = true
				};
				ChunkList.Add(chunk);
				Log.WriteDebug($"Setting chunk {1}: From: {chunk.StartIndex} - Size: {chunk.Size}");
				return;
			}
			checked
			{
				num = (long)Math.Round(Math.Ceiling((double)num / (double)num2) * (double)num2);
				long num3 = size - num * (numParts - 1);
				if (num3 < 0)
				{
					Chunk chunk2 = new Chunk
					{
						StartIndex = 0L,
						Index = 0L,
						Size = size,
						Available = true
					};
					ChunkList.Add(chunk2);
					Log.WriteDebug($"Setting chunk {1}: From: {chunk2.StartIndex} - Size: {chunk2.Size}");
					return;
				}
				for (int i = 1; i <= numParts; i++)
				{
					Chunk chunk3 = new Chunk
					{
						StartIndex = (i - 1) * num,
						Index = 0L,
						Available = true
					};
					if (i == numParts)
					{
						chunk3.Size = num3;
					}
					else
					{
						chunk3.Size = num;
					}
					ChunkList.Add(chunk3);
					Log.WriteDebug($"Setting chunk {i}: From: {chunk3.StartIndex} - Size: {chunk3.Size}");
				}
			}
		}

		public void ResetAvailableParts()
		{
			_Mutex.WaitOne();
			foreach (Chunk chunk in ChunkList)
			{
				if (chunk.Index != chunk.Size)
				{
					chunk.Available = true;
				}
			}
			_Mutex.ReleaseMutex();
		}

		public void SetProgress(int chunkIndex, long index)
		{
			_Mutex.WaitOne();
			Chunk chunk = ChunkList[chunkIndex];
			chunk.Index = index;
			if (chunk.Index == chunk.Size)
			{
				bool flag = false;
				foreach (Chunk chunk2 in ChunkList)
				{
					if (chunk2.Index != chunk2.Size)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					AllFinished = true;
				}
			}
			_Mutex.ReleaseMutex();
		}
	}

	public class FileInfo
	{
		public string Path;

		public string FileID;

		public string FileKey;

		public int NumParts;

		private long _Size;

		private DataPart _dataPart;

		private System.Threading.Mutex _Mutex;

		private string _Name;

		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value ?? "";
				char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
				foreach (char oldChar in invalidFileNameChars)
				{
					_Name = Name.Replace(oldChar, ' ');
				}
			}
		}

		public bool DataPartInitialized => _dataPart != null;

		public DataPart GetDataPart
		{
			get
			{
				if (Size == 0L)
				{
					throw new InvalidOperationException("Must specify size");
				}
				_Mutex.WaitOne();
				if (_dataPart == null)
				{
					_dataPart = new DataPart(Size, NumParts);
				}
				_Mutex.ReleaseMutex();
				return _dataPart;
			}
		}

		public long Size
		{
			get
			{
				return _Size;
			}
			set
			{
				_Size = value;
				if (!DataPartInitialized)
				{
					return;
				}
				_Mutex.WaitOne();
				long num = 0L;
				checked
				{
					foreach (DataPart.Chunk chunk in _dataPart.ChunkList)
					{
						if (chunk.StartIndex + chunk.Size > num)
						{
							num = chunk.StartIndex + chunk.Size;
						}
					}
					_Mutex.ReleaseMutex();
					if (value != num)
					{
						throw new InvalidOperationException("File size does not match [" + Conversions.ToString(value) + " - " + Conversions.ToString(num) + "]");
					}
				}
			}
		}

		public FileInfo(string path)
		{
			_Mutex = new System.Threading.Mutex();
			Path = path;
			Name = Path.Split('/')[checked(Path.Split('/').Length - 1)];
			NumParts = 1;
			Size = 0L;
			_dataPart = null;
		}

		public void SetDataPart(DataPart d)
		{
			if (d != null)
			{
				_dataPart = d;
				_dataPart.ResetAvailableParts();
			}
		}
	}

	private enum Event
	{
		CalculationFileSizesStarted,
		FileSizesCalculationComplete,
		CreatingFilesLocal,
		FilesLocalCreated,
		DeletingFilesAfterCancel,
		FileDownloadAttempting,
		FileDownloadStarted,
		FileDownloadStopped,
		FileDownloadSucceeded,
		ProgressChanged
	}

	private enum InvokeType
	{
		EventRaiser,
		FileDownloadFailedRaiser,
		ChunkDownloadFailedRaiser,
		CalculatingFileNrRaiser,
		StartDownloaderRaiser
	}

	private class DownloaderWorker : BackgroundWorker
	{
		private int _ChunkIndex;

		private FileInfo _file;

		private bool _ChunkDownloadFailed;

		public bool ChunkDownloadFailed
		{
			get
			{
				return _ChunkDownloadFailed;
			}
			set
			{
				_ChunkDownloadFailed = value;
			}
		}

		public FileInfo File => _file;

		public int ChunkIndex => _ChunkIndex;

		public DownloaderWorker(int ChunkIndex, FileInfo file)
		{
			_ChunkIndex = ChunkIndex;
			_file = file;
			_ChunkDownloadFailed = false;
		}
	}

	public delegate void FileDownloadFailedEventHandler(object sender, Exception e);

	public delegate void ChunkDownloadFailedEventHandler(object sender, Exception e);

	public delegate void FileSizeCalculationEventHandler(object sender);

	[CompilerGenerated]
	[AccessedThroughProperty("bgwDownloader")]
	private BackgroundWorker _bgwDownloader;

	private System.Threading.Mutex Mutex;

	private System.Threading.Mutex MutexFile;

	private ManualResetEvent trigger;

	private int m_num_connections;

	private int m_parts_per_file;

	private bool m_supportsProgress;

	private bool m_deleteFiles;

	private bool m_deleteCompletedFiles;

	private int m_packageSize;

	private int m_bufferSize;

	private int m_stopWatchCycles;

	private bool m_disposed;

	private bool m_busy;

	private bool m_paused;

	private bool m_canceled;

	private long m_currentFileProgress;

	private long m_totalProgress;

	private long m_currentFileSize;

	private Dictionary<string, long> m_currentSpeed;

	private string m_localDirectory;

	private FileInfo m_file;

	private long m_totalSize;

	private BackgroundWorker bgwDownloader
	{
		[CompilerGenerated]
		get
		{
			return _bgwDownloader;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgwDownloader_DoWork;
			ProgressChangedEventHandler value3 = bwgDownloader_ProgressChanged;
			RunWorkerCompletedEventHandler value4 = bgwDownloader_RunWorkerCompleted;
			BackgroundWorker backgroundWorker = _bgwDownloader;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.ProgressChanged -= value3;
				backgroundWorker.RunWorkerCompleted -= value4;
			}
			_bgwDownloader = value;
			backgroundWorker = _bgwDownloader;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.ProgressChanged += value3;
				backgroundWorker.RunWorkerCompleted += value4;
			}
		}
	}

	[field: AccessedThroughProperty("listDownloaders")]
	private List<DownloaderWorker> listDownloaders
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FileInfo File
	{
		get
		{
			return m_file;
		}
		set
		{
			if (IsBusy)
			{
				throw new InvalidOperationException("You can not change the file during the download");
			}
			if (m_file != value)
			{
				m_file = value;
			}
		}
	}

	public string LocalDirectory
	{
		get
		{
			return m_localDirectory;
		}
		set
		{
			string text = value;
			char[] invalidPathChars = Path.GetInvalidPathChars();
			foreach (char oldChar in invalidPathChars)
			{
				text = text.Replace(oldChar, ' ');
			}
			if (Operators.CompareString(text, LocalDirectory, TextCompare: false) != 0)
			{
				m_localDirectory = text;
			}
		}
	}

	public bool SupportsProgress
	{
		get
		{
			return m_supportsProgress;
		}
		set
		{
			if (IsBusy)
			{
				throw new InvalidOperationException("You can not change the SupportsProgress property during the download");
			}
			m_supportsProgress = value;
		}
	}

	public bool DeleteCompletedFilesAfterCancel
	{
		get
		{
			return m_deleteCompletedFiles;
		}
		set
		{
			m_deleteCompletedFiles = value;
		}
	}

	public bool DeleteFilesAfterCancel
	{
		get
		{
			return m_deleteFiles;
		}
		set
		{
			m_deleteFiles = value;
		}
	}

	public int OpenConnections
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return listDownloaders.Count;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public int NumConnections
	{
		get
		{
			return m_num_connections;
		}
		set
		{
			if (value > 0)
			{
				m_num_connections = value;
				return;
			}
			throw new InvalidOperationException("The NumConnections needs to be greater than 0");
		}
	}

	public int PartsPerFile
	{
		get
		{
			return m_parts_per_file;
		}
		set
		{
			if (value > 0)
			{
				m_parts_per_file = value;
				return;
			}
			throw new InvalidOperationException("The PartsPerFile needs to be greater than 0");
		}
	}

	public int BufferSize
	{
		get
		{
			return m_bufferSize;
		}
		set
		{
			if (value < PackageSize)
			{
				throw new InvalidOperationException("The BufferSize needs to be greater than the PackageSize");
			}
			if (value > 0)
			{
				m_bufferSize = value;
				return;
			}
			throw new InvalidOperationException("The BufferSize needs to be greater than 0");
		}
	}

	public int PackageSize
	{
		get
		{
			return m_packageSize;
		}
		set
		{
			if (value > BufferSize)
			{
				throw new InvalidOperationException("The BufferSize needs to be greater than the PackageSize");
			}
			if (value > 0)
			{
				m_packageSize = value;
				return;
			}
			throw new InvalidOperationException("The PackageSize needs to be greater than 0");
		}
	}

	public int StopWatchCyclesAmount
	{
		get
		{
			return m_stopWatchCycles;
		}
		set
		{
			if (value > 0)
			{
				m_stopWatchCycles = value;
				return;
			}
			throw new InvalidOperationException("The StopWatchCyclesAmount needs to be greather then 0");
		}
	}

	public bool IsBusy
	{
		get
		{
			return m_busy;
		}
		set
		{
			if (IsBusy == value)
			{
				return;
			}
			m_busy = value;
			m_canceled = !value;
			if (IsBusy)
			{
				m_totalProgress = 0L;
				bgwDownloader.RunWorkerAsync();
				Started?.Invoke(this, new EventArgs());
				IsBusyChanged?.Invoke(this, new EventArgs());
				StateChanged?.Invoke(this, new EventArgs());
				return;
			}
			bgwDownloader.CancelAsync();
			if (IsPaused)
			{
				trigger.Set();
			}
			m_paused = false;
			CancelRequested?.Invoke(this, new EventArgs());
			StateChanged?.Invoke(this, new EventArgs());
		}
	}

	public bool IsPaused
	{
		get
		{
			return m_paused;
		}
		set
		{
			if (IsBusy && value != IsPaused)
			{
				m_paused = value;
				if (IsPaused)
				{
					trigger.Reset();
					Paused?.Invoke(this, new EventArgs());
				}
				else
				{
					trigger.Set();
					Resumed?.Invoke(this, new EventArgs());
				}
				IsPausedChanged?.Invoke(this, new EventArgs());
				StateChanged?.Invoke(this, new EventArgs());
			}
		}
	}

	public bool CanStart => !IsBusy;

	public bool CanPause => IsBusy & !IsPaused & !bgwDownloader.CancellationPending;

	public bool CanResume => IsBusy & IsPaused & !bgwDownloader.CancellationPending;

	public bool CanStop => IsBusy & !bgwDownloader.CancellationPending;

	public long TotalSize
	{
		get
		{
			if (SupportsProgress)
			{
				return m_totalSize;
			}
			throw new InvalidOperationException("This FileDownloader that it doesn't support progress. Modify SupportsProgress to state that it does support progress to get the total size.");
		}
	}

	public long TotalProgress => m_totalProgress;

	public long CurrentFileProgress => m_currentFileProgress;

	public double TotalPercentage
	{
		get
		{
			if (SupportsProgress)
			{
				double num = (double)TotalProgress / (double)TotalSize * 100.0;
				if (num > 100.0)
				{
					num = 100.0;
				}
				return Math.Round(num, 2);
			}
			throw new InvalidOperationException("This FileDownloader that it doesn't support progress. Modify SupportsProgress to state that it does support progress.");
		}
	}

	public double CurrentFilePercentage => Math.Round((double)CurrentFileProgress / (double)CurrentFileSize * 100.0, 2);

	public int DownloadSpeed
	{
		get
		{
			Mutex.WaitOne();
			checked
			{
				try
				{
					int num = 0;
					foreach (long value in m_currentSpeed.Values)
					{
						int num2 = (int)value;
						num += num2;
					}
					return num;
				}
				finally
				{
					Mutex.ReleaseMutex();
				}
			}
		}
	}

	public long CurrentFileSize => m_currentFileSize;

	private bool HasBeenCanceled => m_canceled;

	public event EventHandler Started;

	public event EventHandler Paused;

	public event EventHandler Resumed;

	public event EventHandler CancelRequested;

	public event EventHandler DeletingFilesAfterCancel;

	public event EventHandler Canceled;

	public event EventHandler Completed;

	public event EventHandler Stopped;

	public event EventHandler IsBusyChanged;

	public event EventHandler IsPausedChanged;

	public event EventHandler StateChanged;

	public event EventHandler CalculationFileSizesStarted;

	public event FileSizeCalculationEventHandler CalculatingFileSize;

	public event EventHandler FileSizesCalculationComplete;

	public event EventHandler FileDownloadAttempting;

	public event EventHandler FileDownloadStarted;

	public event EventHandler FileDownloadStopped;

	public event EventHandler FileDownloadSucceeded;

	public event FileDownloadFailedEventHandler FileDownloadFailed;

	public event ChunkDownloadFailedEventHandler ChunkDownloadFailed;

	public event EventHandler ProgressChanged;

	public event EventHandler FileLocalCreated;

	public FileDownloader(bool supportsProgress = false)
	{
		bgwDownloader = new BackgroundWorker();
		listDownloaders = new List<DownloaderWorker>();
		Mutex = new System.Threading.Mutex();
		MutexFile = new System.Threading.Mutex();
		trigger = new ManualResetEvent(initialState: true);
		m_disposed = false;
		bgwDownloader.WorkerReportsProgress = true;
		bgwDownloader.WorkerSupportsCancellation = true;
		SupportsProgress = supportsProgress;
		BufferSize = 512000;
		PackageSize = 51200;
		StopWatchCyclesAmount = 30;
		PartsPerFile = 1;
		NumConnections = 1;
		DeleteCompletedFilesAfterCancel = false;
		DeleteFilesAfterCancel = true;
		m_currentSpeed = new Dictionary<string, long>();
	}

	public void AddFileInfo(string FileID, string FileKey, string path, string name, DataPart part)
	{
		FileInfo fileInfo = new FileInfo(path);
		fileInfo.Name = name;
		fileInfo.NumParts = PartsPerFile;
		fileInfo.SetDataPart(part);
		fileInfo.FileID = FileID;
		fileInfo.FileKey = FileKey;
		File = fileInfo;
	}

	public void Start()
	{
		IsBusy = true;
	}

	public void Pause()
	{
		IsPaused = true;
	}

	public void Resume()
	{
		IsPaused = false;
	}

	public void Stop()
	{
		IsBusy = false;
	}

	public void Stop(bool deleteCompletedFiles)
	{
		DeleteCompletedFilesAfterCancel = deleteCompletedFiles;
		Stop();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	public static string FormatSizeBinary(long size, int decimals = 2)
	{
		string[] array = new string[9] { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB", "ZiB", "YiB" };
		double num = size;
		int i;
		for (i = 0; (num >= 1024.0) & (i < array.Length); i = checked(i + 1))
		{
			num /= 1024.0;
		}
		return Math.Round(num, decimals) + array[i];
	}

	public static string FormatSizeDecimal(long size, int decimals = 2)
	{
		string[] array = new string[9] { "B", "kB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
		double num = size;
		int i;
		for (i = 0; (num >= 1000.0) & (i < array.Length); i = checked(i + 1))
		{
			num /= 1000.0;
		}
		return Math.Round(num, decimals) + array[i];
	}

	private void bgwDownloader_DoWork(object ender, DoWorkEventArgs e)
	{
		try
		{
			try
			{
				if (SupportsProgress)
				{
					calculateFilesSize();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error in bgwDownloader.DoWork/calculateFilesSize: " + ex2.ToString());
				bgwDownloader.ReportProgress(1, ex2);
				ProjectData.ClearProjectError();
			}
			if (!Directory.Exists(LocalDirectory))
			{
				Directory.CreateDirectory(LocalDirectory);
			}
			if (bgwDownloader.CancellationPending)
			{
				return;
			}
			downloadFile();
			if (bgwDownloader.CancellationPending)
			{
				if (DeleteFilesAfterCancel)
				{
					fireEventFromBgw(Event.DeletingFilesAfterCancel);
					cleanUpFile();
				}
				e.Cancel = true;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteError("Error in bgwDownloader.DoWork: " + ex4.ToString());
			MessageBox.Show("Error: " + ex4.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void downloadFile()
	{
		FileInfo file = m_file;
		Log.WriteWarning("Starting file download " + file.Name);
		string text = Path.Combine(LocalDirectory, file.Name + ".part");
		string text2 = Path.Combine(LocalDirectory, file.Name);
		Exception ex = null;
		checked
		{
			try
			{
				if (file.Size == 0L)
				{
					try
					{
						HttpWebRequest httpWebRequest = Conexion.CreateHttpWebRequest(File.Path);
						httpWebRequest.Method = "HEAD";
						HttpWebResponse obj = (HttpWebResponse)httpWebRequest.GetResponse();
						long contentLength = obj.ContentLength;
						obj.Close();
						file.Size = contentLength;
						m_currentFileSize = contentLength;
						Log.WriteInfo("File size " + file.Name + ": " + Conversions.ToString(contentLength));
					}
					catch (WebException ex2)
					{
						ProjectData.SetProjectError(ex2);
						WebException ex3 = ex2;
						ex = ex3;
						ProjectData.ClearProjectError();
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception ex5 = ex4;
						ex = ex5;
						ProjectData.ClearProjectError();
					}
				}
				if (ex != null)
				{
					Log.WriteError("Error downloading file " + file.Name + " - " + ex.ToString());
					bgwDownloader.ReportProgress(1, ex);
					ex = null;
				}
				else
				{
					if (!System.IO.File.Exists(text))
					{
						fireEventFromBgw(Event.CreatingFilesLocal);
						MutexFile.WaitOne();
						try
						{
							using FileStream fileStream = System.IO.File.Create(text, 65536, FileOptions.RandomAccess);
							fileStream.SetLength(file.Size);
							fileStream.Flush();
						}
						catch (Exception ex6)
						{
							ProjectData.SetProjectError(ex6);
							Exception ex7 = ex6;
							ex = ex7;
							ProjectData.ClearProjectError();
						}
						finally
						{
							MutexFile.ReleaseMutex();
						}
					}
					else
					{
						MutexFile.WaitOne();
						try
						{
							System.IO.FileInfo fileInfo = new System.IO.FileInfo(text);
							if (fileInfo.Length != file.Size)
							{
								ex = new ApplicationException("The file exists and does not have the expected size [" + Conversions.ToString(fileInfo.Length) + " - " + Conversions.ToString(file.Size) + "]");
							}
						}
						finally
						{
							MutexFile.ReleaseMutex();
						}
					}
					if (ex != null)
					{
						Log.WriteError("Error creating file on disk " + file.Name + " - " + ex.ToString());
						bgwDownloader.ReportProgress(1, ex);
						ex = null;
					}
					else
					{
						foreach (DataPart.Chunk chunk in file.GetDataPart.ChunkList)
						{
							m_currentFileProgress += chunk.Index;
							m_totalProgress += chunk.Index;
						}
						fireEventFromBgw(Event.FilesLocalCreated);
						if (bgwDownloader.CancellationPending)
						{
							Log.WriteWarning("File download stopped - " + file.Name);
							return;
						}
						int numConnections = NumConnections;
						for (int i = 1; i <= numConnections; i++)
						{
							Log.WriteDebug("Event raised for starting a new connection");
							bgwDownloader.ReportProgress(4, null);
						}
						do
						{
							Thread.Sleep(100);
							trigger.WaitOne();
							if (!bgwDownloader.CancellationPending)
							{
								continue;
							}
							Log.WriteDebug("Aborting connection - stop requested");
							Mutex.WaitOne();
							try
							{
								foreach (DownloaderWorker listDownloader in listDownloaders)
								{
									if (listDownloader.IsBusy)
									{
										listDownloader.CancelAsync();
									}
								}
							}
							finally
							{
								Mutex.ReleaseMutex();
							}
							Log.WriteWarning("File download stopped - " + file.Name);
							break;
						}
						while (!file.GetDataPart.AllFinished);
					}
				}
			}
			catch (Exception ex8)
			{
				ProjectData.SetProjectError(ex8);
				Exception ex9 = ex8;
				ex = ex9;
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (ex != null)
				{
					Log.WriteError("Error trying to download file " + file.Name + " - " + ex.ToString());
					bgwDownloader.ReportProgress(1, ex);
				}
			}
			try
			{
				if (!file.GetDataPart.AllFinished)
				{
					return;
				}
				MutexFile.WaitOne();
				try
				{
					if (System.IO.File.Exists(text))
					{
						if (!System.IO.File.Exists(text2))
						{
							Log.WriteInfo("Rename from " + text + " to " + text2);
							FileSystem.Rename(text, text2);
						}
						else
						{
							string text3 = ((text2.LastIndexOf('.') > 0) ? text2.Substring(text2.LastIndexOf('.') + 1) : "");
							string text4 = ((text2.LastIndexOf('.') > 0) ? text2.Substring(0, text2.LastIndexOf('.')) : "");
							int num = 1;
							do
							{
								num++;
								string text5 = text4 + " (" + Conversions.ToString(num) + ")" + (string.IsNullOrEmpty(text3) ? "" : ("." + text3));
								if (!System.IO.File.Exists(text5))
								{
									Log.WriteInfo("Rename from " + text + " to " + text5);
									FileSystem.Rename(text, text5);
									break;
								}
							}
							while (num <= 9999);
						}
					}
				}
				finally
				{
					MutexFile.ReleaseMutex();
				}
				Log.WriteWarning("File downloaded successfully");
				fireEventFromBgw(Event.FileDownloadSucceeded);
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10);
				Exception ex11 = ex10;
				Log.WriteError("Error checking if the download has stopped " + file.Name + " - " + ex.ToString());
				bgwDownloader.ReportProgress(1, ex);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void bwgDownloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		switch ((InvokeType)e.ProgressPercentage)
		{
		case InvokeType.EventRaiser:
			switch ((Event)Conversions.ToInteger(e.UserState))
			{
			case Event.CalculationFileSizesStarted:
				CalculationFileSizesStarted?.Invoke(this, new EventArgs());
				break;
			case Event.FileSizesCalculationComplete:
				FileSizesCalculationComplete?.Invoke(this, new EventArgs());
				break;
			case Event.FilesLocalCreated:
				FileLocalCreated?.Invoke(this, new EventArgs());
				break;
			case Event.DeletingFilesAfterCancel:
				DeletingFilesAfterCancel?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadAttempting:
				FileDownloadAttempting?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadStarted:
				FileDownloadStarted?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadStopped:
				FileDownloadStopped?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadSucceeded:
				FileDownloadSucceeded?.Invoke(this, new EventArgs());
				break;
			case Event.ProgressChanged:
				ProgressChanged?.Invoke(this, new EventArgs());
				break;
			case Event.CreatingFilesLocal:
				break;
			}
			break;
		case InvokeType.FileDownloadFailedRaiser:
			FileDownloadFailed?.Invoke(this, (Exception)e.UserState);
			break;
		case InvokeType.CalculatingFileNrRaiser:
			CalculatingFileSize?.Invoke(this);
			break;
		case InvokeType.StartDownloaderRaiser:
			NewDownloaderWorker();
			break;
		case InvokeType.ChunkDownloadFailedRaiser:
			break;
		}
	}

	private void bgwDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		IsPaused = false;
		m_busy = false;
		if (HasBeenCanceled)
		{
			Canceled?.Invoke(this, new EventArgs());
		}
		else
		{
			Completed?.Invoke(this, new EventArgs());
		}
		Stopped?.Invoke(this, new EventArgs());
		IsBusyChanged?.Invoke(this, new EventArgs());
		StateChanged?.Invoke(this, new EventArgs());
	}

	private void ChunkDownloader_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		switch ((InvokeType)e.ProgressPercentage)
		{
		case InvokeType.EventRaiser:
			switch ((Event)Conversions.ToInteger(e.UserState))
			{
			case Event.CalculationFileSizesStarted:
				CalculationFileSizesStarted?.Invoke(this, new EventArgs());
				break;
			case Event.FileSizesCalculationComplete:
				FileSizesCalculationComplete?.Invoke(this, new EventArgs());
				break;
			case Event.DeletingFilesAfterCancel:
				DeletingFilesAfterCancel?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadAttempting:
				FileDownloadAttempting?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadStarted:
				FileDownloadStarted?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadStopped:
				FileDownloadStopped?.Invoke(this, new EventArgs());
				break;
			case Event.FileDownloadSucceeded:
				FileDownloadSucceeded?.Invoke(this, new EventArgs());
				break;
			case Event.ProgressChanged:
				ProgressChanged?.Invoke(this, new EventArgs());
				break;
			case Event.CreatingFilesLocal:
			case Event.FilesLocalCreated:
				break;
			}
			break;
		case InvokeType.ChunkDownloadFailedRaiser:
			ChunkDownloadFailed?.Invoke(this, (Exception)e.UserState);
			break;
		case InvokeType.CalculatingFileNrRaiser:
			CalculatingFileSize?.Invoke(this);
			break;
		case InvokeType.FileDownloadFailedRaiser:
			break;
		}
	}

	private void ChunkDownloader_DoWork(object sender, DoWorkEventArgs e)
	{
		checked
		{
			try
			{
				DownloaderWorker downloaderWorker = (DownloaderWorker)sender;
				FileInfo file = File;
				string text = LocalDirectory + "\\" + file.Name + ".part";
				string fileKey = file.FileKey;
				HttpWebRequest httpWebRequest = null;
				HttpWebResponse httpWebResponse = null;
				DataPart.Chunk Chunk = file.GetDataPart.ChunkList[downloaderWorker.ChunkIndex];
				Log.WriteDebug("Starting chunk " + text + " position " + Conversions.ToString(Chunk.StartIndex + Chunk.Index));
				Exception ex = null;
				long num = 0L;
				int CurrentBufferSize = 0;
				int num2 = -1;
				byte[] array = new byte[PackageSize - 1 + 1];
				byte[] BufferDisk = new byte[BufferSize - 1 + 1];
				int num3 = 0;
				Stopwatch stopwatch = new Stopwatch();
				KeyValuePair<double, double>[] array2 = new KeyValuePair<double, double>[m_stopWatchCycles - 1 + 1];
				DateTime dateTime = DateTime.MinValue;
				long num4 = Chunk.StartIndex + Chunk.Index;
				long num5 = Chunk.StartIndex + Chunk.Size - 1;
				try
				{
					if (num4 >= num5 + 1)
					{
						file.GetDataPart.SetProgress(downloaderWorker.ChunkIndex, Chunk.Size);
					}
					else if (string.IsNullOrEmpty(fileKey))
					{
						ex = new ApplicationException("FileKey not defined");
						downloaderWorker.ChunkDownloadFailed = true;
						Log.WriteError("Error: FileKey not defined");
						downloaderWorker.ReportProgress(2, ex);
					}
					else
					{
						try
						{
							httpWebRequest = Conexion.CreateHttpWebRequest(file.Path);
							Log.WriteInfo("Starting connection - " + file.Name + " from byte " + Conversions.ToString(num4) + " to " + Conversions.ToString(num5));
							string text2 = "Range";
							string text3 = $"bytes={num4}-{num5}";
							typeof(WebHeaderCollection).GetMethod("AddWithoutValidate", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(httpWebRequest.Headers, new object[2] { text2, text3 });
							httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
							string text4 = httpWebResponse.Headers["Content-Range"];
							if (!string.IsNullOrEmpty(text4) && text4.StartsWith("bytes ") && text4.Contains("-"))
							{
								string text5 = text4.Substring(6).Split('-')[0];
								if (Versioned.IsNumeric(text5))
								{
									long num6 = Conversions.ToLong(text5);
									if (num4 != num6)
									{
										if (num6 < Chunk.StartIndex)
										{
											Chunk.Size += Chunk.StartIndex - num6;
											Chunk.StartIndex = num6;
											Chunk.Index = 0L;
											num4 = Chunk.StartIndex + Chunk.Index;
											num5 = Chunk.StartIndex + Chunk.Size - 1;
										}
										else if (num6 < Chunk.StartIndex + Chunk.Index)
										{
											Chunk.Index -= Chunk.StartIndex + Chunk.Index - num6;
											num4 = Chunk.StartIndex + Chunk.Index;
											num5 = Chunk.StartIndex + Chunk.Size - 1;
										}
										else
										{
											ex = new ApplicationException($"Error when downloading chunk {num4}-{num5}: received {num6}");
										}
									}
								}
							}
						}
						catch (WebException ex2)
						{
							ProjectData.SetProjectError(ex2);
							WebException ex3 = ex2;
							ex = ex3;
							ProjectData.ClearProjectError();
						}
						catch (Exception ex4)
						{
							ProjectData.SetProjectError(ex4);
							Exception ex5 = ex4;
							ex = ex5;
							ProjectData.ClearProjectError();
						}
						if (ex != null)
						{
							downloaderWorker.ChunkDownloadFailed = true;
							Log.WriteError("Connection error when downloading file " + file.Name + " - " + ex.ToString());
							downloaderWorker.ReportProgress(2, ex);
						}
						else
						{
							string text6 = fileKey;
							if (text6.Contains("=###n="))
							{
								text6 = text6.Substring(0, fileKey.IndexOf("=###n="));
							}
							Log.WriteDebug("Starting SicBlockCipher seek position " + Conversions.ToString(num4));
							DateTime now = DateAndTime.Now;
							Criptografia.SicSeekableBlockCipher instaceCipher = Criptografia.GetInstaceCipher(text6);
							instaceCipher.IncrementCounter((int)Math.Ceiling((double)num4 / (double)instaceCipher.GetBlockSize()));
							Log.WriteDebug("Finishing SicBlockCipher seek [" + Conversions.ToString(DateAndTime.Now.Subtract(now).TotalMilliseconds) + "ms]");
							if (m_currentFileProgress > 0)
							{
								fireEventFromDownloader(downloaderWorker, Event.ProgressChanged);
							}
							Stream responseStream = httpWebResponse.GetResponseStream();
							ThrottledStream Stream = new ThrottledStream(responseStream);
							ThrottledStreamController.GetController().AddStream(ref Stream, file.FileID);
							stopwatch.Start();
							try
							{
								while (unchecked(Chunk.Index < Chunk.Size || CurrentBufferSize > 0))
								{
									if (downloaderWorker.CancellationPending)
									{
										stopwatch.Stop();
										return;
									}
									if (((CurrentBufferSize > 0) & ((Chunk.Index + CurrentBufferSize >= Chunk.Size) | !trigger.WaitOne(0) | downloaderWorker.CancellationPending | (CurrentBufferSize + PackageSize > BufferSize))) && !FlushToDisk(downloaderWorker, text, ref BufferDisk, ref CurrentBufferSize, ref Chunk))
									{
										break;
									}
									trigger.WaitOne();
									if (downloaderWorker.CancellationPending)
									{
										Log.WriteDebug("Download stopped - " + file.Name);
										stopwatch.Stop();
										return;
									}
									try
									{
										num2 = 0;
										while (num2 < PackageSize)
										{
											int num7 = Stream.Read(array, num2, PackageSize - num2);
											num2 += num7;
											if ((num7 == 0) | (Chunk.Index + CurrentBufferSize + num2 >= Chunk.Size))
											{
												break;
											}
										}
										int num8 = num2 - 1;
										int blockSize = instaceCipher.GetBlockSize();
										for (int i = 0; ((blockSize >> 31) ^ i) <= ((blockSize >> 31) ^ num8); i += blockSize)
										{
											instaceCipher.ProcessBlock(array, i, BufferDisk, CurrentBufferSize + i);
										}
									}
									catch (WebException ex6)
									{
										ProjectData.SetProjectError(ex6);
										WebException ex7 = ex6;
										ex = ex7;
										ProjectData.ClearProjectError();
									}
									catch (Exception ex8)
									{
										ProjectData.SetProjectError(ex8);
										Exception ex9 = ex8;
										ex = ex9;
										ProjectData.ClearProjectError();
									}
									if (ex != null)
									{
										downloaderWorker.ChunkDownloadFailed = true;
										downloaderWorker.ReportProgress(2, ex);
										stopwatch.Stop();
										return;
									}
									Mutex.WaitOne();
									m_currentFileProgress += num2;
									m_totalProgress += num2;
									Mutex.ReleaseMutex();
									num3 += num2;
									fireEventFromDownloader(downloaderWorker, Event.ProgressChanged);
									CurrentBufferSize += num2;
									if (DateTime.Compare(dateTime.AddMilliseconds(175.0), DateAndTime.Now) < 0)
									{
										dateTime = DateAndTime.Now;
										num++;
										stopwatch.Stop();
										long num9 = stopwatch.ElapsedTicks;
										if (num9 == 0L)
										{
											num9 = 1L;
										}
										double value = (double)num9 / (double)Stopwatch.Frequency;
										stopwatch.Reset();
										stopwatch.Start();
										int num10 = (int)unchecked(num % StopWatchCyclesAmount);
										array2[num10] = new KeyValuePair<double, double>(num3, value);
										num3 = 0;
										string key = downloaderWorker.ChunkIndex.ToString();
										int num11 = CalculateAvgSpeed(num, StopWatchCyclesAmount, array2);
										Mutex.WaitOne();
										try
										{
											m_currentSpeed[key] = num11;
										}
										finally
										{
											Mutex.ReleaseMutex();
										}
									}
								}
							}
							finally
							{
								stopwatch.Stop();
								ThrottledStreamController.GetController().RemoveStream(ref Stream);
								responseStream.Close();
							}
							Log.WriteInfo("Finishing connection - " + file.Name + " - chunk downloaded");
						}
					}
				}
				finally
				{
					httpWebResponse?.Close();
				}
				fireEventFromDownloader(downloaderWorker, Event.FileDownloadStopped);
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10);
				Exception ex11 = ex10;
				Log.WriteError("Error in Downloader.DoWork: " + ex11.ToString());
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool FlushToDisk(object worker, string filePath, ref byte[] BufferDisk, ref int CurrentBufferSize, ref DataPart.Chunk Chunk)
	{
		FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite, CurrentBufferSize, FileOptions.RandomAccess);
		checked
		{
			fileStream.Position = Chunk.StartIndex + Chunk.Index;
			fileStream.Write(BufferDisk, 0, CurrentBufferSize);
			fileStream.Close();
			long num = Chunk.Index + CurrentBufferSize;
			if (num >= Chunk.Size)
			{
				num = Chunk.Size;
			}
			DownloaderWorker downloaderWorker = (DownloaderWorker)worker;
			File.GetDataPart.SetProgress(downloaderWorker.ChunkIndex, num);
			Chunk = File.GetDataPart.ChunkList[downloaderWorker.ChunkIndex];
			CurrentBufferSize = 0;
			return Chunk.Index < Chunk.Size;
		}
	}

	private void ChunkDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		DownloaderWorker downloaderWorker = (DownloaderWorker)sender;
		Mutex.WaitOne();
		try
		{
			_ = downloaderWorker.ChunkDownloadFailed;
			DataPart.Chunk chunk = downloaderWorker.File.GetDataPart.ChunkList[downloaderWorker.ChunkIndex];
			if (chunk.Size > chunk.Index)
			{
				chunk.Available = true;
			}
			string key = downloaderWorker.ChunkIndex.ToString();
			if (m_currentSpeed.ContainsKey(key))
			{
				m_currentSpeed.Remove(key);
			}
			downloaderWorker.DoWork -= ChunkDownloader_DoWork;
			downloaderWorker.ProgressChanged -= ChunkDownloader_ProgressChanged;
			downloaderWorker.RunWorkerCompleted -= ChunkDownloader_RunWorkerCompleted;
			listDownloaders.Remove(downloaderWorker);
			downloaderWorker.Dispose();
		}
		finally
		{
			Mutex.ReleaseMutex();
		}
		if (HasBeenCanceled)
		{
			return;
		}
		if (downloaderWorker.ChunkDownloadFailed)
		{
			double value = checked(1000 + DateAndTime.Now.Millisecond * 4);
			DateTime t = DateAndTime.Now.AddMilliseconds(value);
			while (DateTime.Compare(DateAndTime.Now, t) < 0)
			{
				Thread.Sleep(50);
				if (HasBeenCanceled)
				{
					return;
				}
			}
		}
		NewDownloaderWorker();
	}

	private void fireEventFromBgw(Event eventName)
	{
		bgwDownloader.ReportProgress(0, eventName);
	}

	private void fireEventFromDownloader(DownloaderWorker d, Event eventName)
	{
		d.ReportProgress(0, eventName);
	}

	private static int CalculateAvgSpeed(long readings, int StopWatchCyclesAmount, KeyValuePair<double, double>[] arraySpeed)
	{
		double num = 0.0;
		double num2 = 0.0;
		checked
		{
			int num3 = StopWatchCyclesAmount - 1;
			if (unchecked(readings < 5 && StopWatchCyclesAmount > 5))
			{
				num3 = -1;
			}
			else if (readings < StopWatchCyclesAmount)
			{
				num3 = (int)readings;
			}
			int num4 = num3;
			for (int i = 0; i <= num4; i++)
			{
				KeyValuePair<double, double> keyValuePair = arraySpeed[i];
				num += keyValuePair.Key;
				num2 += keyValuePair.Value;
			}
			if (num2 == 0.0)
			{
				num2 = 1.0;
			}
			return (int)Math.Round(num / num2);
		}
	}

	private void NewDownloaderWorker()
	{
		Mutex.WaitOne();
		try
		{
			int? nextAvailablePartIndex = File.GetDataPart.NextAvailablePartIndex;
			if (nextAvailablePartIndex.HasValue)
			{
				DownloaderWorker downloaderWorker = new DownloaderWorker(nextAvailablePartIndex.Value, File);
				downloaderWorker.WorkerSupportsCancellation = true;
				downloaderWorker.WorkerReportsProgress = true;
				downloaderWorker.DoWork += ChunkDownloader_DoWork;
				downloaderWorker.ProgressChanged += ChunkDownloader_ProgressChanged;
				downloaderWorker.RunWorkerCompleted += ChunkDownloader_RunWorkerCompleted;
				listDownloaders.Add(downloaderWorker);
				downloaderWorker.RunWorkerAsync();
			}
		}
		finally
		{
			Mutex.ReleaseMutex();
		}
	}

	private void cleanUpFile()
	{
		if (File != null)
		{
			string path = Path.Combine(LocalDirectory, File.Name);
			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
			}
		}
	}

	private void calculateFilesSize()
	{
		fireEventFromBgw(Event.CalculationFileSizesStarted);
		bgwDownloader.ReportProgress(3, null);
		try
		{
			HttpWebRequest httpWebRequest = Conexion.CreateHttpWebRequest(File.Path);
			httpWebRequest.Method = "HEAD";
			httpWebRequest.Timeout = 15000;
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			m_totalSize = httpWebResponse.ContentLength;
			httpWebResponse.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new ApplicationException("Connection error: " + ex2.Message);
		}
		fireEventFromBgw(Event.FileSizesCalculationComplete);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!m_disposed)
		{
			if (disposing)
			{
				bgwDownloader.Dispose();
			}
			File = null;
		}
		m_disposed = true;
	}

	public void setBufferAndPackageSize(int bufferSize, int packageSize)
	{
		if (bufferSize <= 0)
		{
			bufferSize = 768000;
			Log.WriteWarning("Warning: BufferSize is 0 or less, setting default value 750KB");
		}
		if (packageSize <= 0)
		{
			packageSize = 51200;
			Log.WriteWarning("Warning: PackageSize is 0 or less, setting default value 750KB");
		}
		if (bufferSize < packageSize)
		{
			Log.WriteWarning("Warning: BufferSize needs to be greater than PackageSize, setting 5x");
			bufferSize = checked(5 * packageSize);
		}
		m_packageSize = packageSize;
		m_bufferSize = bufferSize;
	}
}
