using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using SharpCompress.Archive;
using SharpCompress.Archive.Rar;
using SharpCompress.Archive.Zip;
using SharpCompress.Common;
using SharpCompress.Reader;
using SharpCompress.Reader.Rar;

namespace MegaDownloader;

public class DescompresorController
{
	public class QueueItem
	{
		public string Path;

		public string Password;

		public bool CreateDirectory;
	}

	public delegate void DescompresionFinalizadaEventHandler(string Code);

	private class Descompressor
	{
		public string Password;

		private string PathFichero;

		private string PathExtraccion;

		public Exception Exception;

		public Descompressor(string _Fichero, string _PathExtraccion, string _Password)
		{
			PathFichero = _Fichero;
			PathExtraccion = _PathExtraccion;
			Password = _Password;
			if (string.IsNullOrEmpty(Password))
			{
				Password = null;
			}
		}

		private static IArchive getIArchive(string PathFichero, string Password)
		{
			if (PathFichero.ToUpper().EndsWith(".RAR"))
			{
				return (IArchive)(object)RarArchive.Open(PathFichero, (Options)0, Password);
			}
			if (PathFichero.ToUpper().EndsWith(".ZIP"))
			{
				return (IArchive)(object)ZipArchive.Open(PathFichero, Password);
			}
			return ArchiveFactory.Open(PathFichero);
		}

		public void Extract()
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			checked
			{
				try
				{
					if (PathFichero.ToLower().Contains(".7z."))
					{
						throw new NotImplementedException();
					}
					IArchive iArchive = getIArchive(PathFichero, Password);
					try
					{
						if (!iArchive.IsComplete || (iArchive is RarArchive && RarArchiveExtensions.IsMultipartVolume((RarArchive)iArchive) && !RarArchiveExtensions.IsFirstVolume((RarArchive)iArchive)))
						{
							return;
						}
						if (unchecked((iArchive.IsSolid | !string.IsNullOrEmpty(Password)) && iArchive is RarArchive))
						{
							List<Stream> list = new List<Stream>();
							list.Add(File.OpenRead(PathFichero));
							try
							{
								int num = 0;
								if (PathFichero.ToLower().EndsWith("part1.rar"))
								{
									num = 1;
								}
								else if (PathFichero.ToLower().EndsWith("part01.rar"))
								{
									num = 2;
								}
								else if (PathFichero.ToLower().EndsWith("part001.rar"))
								{
									num = 3;
								}
								else if (PathFichero.ToLower().EndsWith("part0001.rar"))
								{
									num = 4;
								}
								int num2 = (int)Math.Round(Math.Pow(10.0, num));
								for (int i = 2; i <= num2; i++)
								{
									string text = PathFichero.ToLower().Replace("part" + "1".PadLeft(num, '0') + ".rar", "part" + i.ToString().PadLeft(num, '0') + ".rar");
									if (!(File.Exists(text) & (Operators.CompareString(PathFichero.ToLower(), text.ToLower(), TextCompare: false) != 0)))
									{
										break;
									}
									list.Add(File.OpenRead(text));
								}
								if ((num > 0) & !string.IsNullOrEmpty(Password))
								{
									throw new NotImplementedException();
								}
								if (list.Count == 1)
								{
									IReader val = (IReader)(object)RarReader.Open(list[0], Password, (Options)1);
									try
									{
										DescompresorController controller = GetController();
										try
										{
											Mutex.WaitOne();
											try
											{
												controller._TamanoTotal = 0L;
												controller._FicActTamanoTotal = 0L;
												controller._TamanoTotalExtraido = 0L;
												controller._FicActExtraido = 0L;
												controller._FicActNombre = "";
												foreach (IArchiveEntry entry in iArchive.Entries)
												{
													controller._TamanoTotal += ((IEntry)entry).Size;
												}
											}
											finally
											{
												Mutex.ReleaseMutex();
											}
											while (val.MoveToNextEntry())
											{
												if (!val.Entry.IsDirectory)
												{
													controller._FicActNombre = val.Entry.Key;
													controller._TamanoTotalExtraido += controller._FicActTamanoTotal;
													controller._FicActTamanoTotal = val.Entry.Size;
													controller._FicActExtraido = 0L;
													IReaderExtensions.WriteEntryToDirectory(val, PathExtraccion, (ExtractOptions)3);
												}
											}
											return;
										}
										finally
										{
											Mutex.WaitOne();
											controller._TamanoTotal = null;
											controller._FicActTamanoTotal = null;
											controller._TamanoTotalExtraido = null;
											controller._FicActExtraido = null;
											controller._FicActNombre = null;
											Mutex.ReleaseMutex();
										}
									}
									finally
									{
										((IDisposable)val)?.Dispose();
									}
								}
								IReader val2 = (IReader)(object)RarReader.Open((IEnumerable<Stream>)list, (Options)1);
								try
								{
									DescompresorController controller2 = GetController();
									try
									{
										Mutex.WaitOne();
										try
										{
											controller2._TamanoTotal = 0L;
											controller2._FicActTamanoTotal = 0L;
											controller2._TamanoTotalExtraido = 0L;
											controller2._FicActExtraido = 0L;
											controller2._FicActNombre = "";
											foreach (IArchiveEntry entry2 in iArchive.Entries)
											{
												controller2._TamanoTotal += ((IEntry)entry2).Size;
											}
										}
										finally
										{
											Mutex.ReleaseMutex();
										}
										while (val2.MoveToNextEntry())
										{
											if (!val2.Entry.IsDirectory)
											{
												controller2._FicActNombre = val2.Entry.Key;
												controller2._TamanoTotalExtraido += controller2._FicActTamanoTotal;
												controller2._FicActTamanoTotal = val2.Entry.Size;
												controller2._FicActExtraido = 0L;
												IReaderExtensions.WriteEntryToDirectory(val2, PathExtraccion, (ExtractOptions)3);
											}
										}
										return;
									}
									finally
									{
										Mutex.WaitOne();
										controller2._TamanoTotal = null;
										controller2._FicActTamanoTotal = null;
										controller2._TamanoTotalExtraido = null;
										controller2._FicActExtraido = null;
										controller2._FicActNombre = null;
										Mutex.ReleaseMutex();
									}
								}
								finally
								{
									((IDisposable)val2)?.Dispose();
								}
							}
							finally
							{
								foreach (Stream item in list)
								{
									item.Close();
									item.Dispose();
								}
							}
						}
						iArchive.CompressedBytesRead += archive_CompressedBytesRead;
						iArchive.EntryExtractionBegin += archive_EntryExtractionBegin;
						DescompresorController controller3 = GetController();
						try
						{
							Mutex.WaitOne();
							try
							{
								controller3._TamanoTotal = 0L;
								controller3._FicActTamanoTotal = 0L;
								controller3._TamanoTotalExtraido = 0L;
								controller3._FicActExtraido = 0L;
								controller3._FicActNombre = "";
								foreach (IArchiveEntry entry3 in iArchive.Entries)
								{
									controller3._TamanoTotal += ((IEntry)entry3).Size;
								}
							}
							finally
							{
								Mutex.ReleaseMutex();
							}
							foreach (IArchiveEntry entry4 in iArchive.Entries)
							{
								if (!((IEntry)entry4).IsDirectory)
								{
									controller3._FicActNombre = ((IEntry)entry4).Key;
									IArchiveEntryExtensions.WriteToDirectory(entry4, PathExtraccion, (ExtractOptions)3);
								}
							}
						}
						finally
						{
							Mutex.WaitOne();
							controller3._TamanoTotal = null;
							controller3._FicActTamanoTotal = null;
							controller3._TamanoTotalExtraido = null;
							controller3._FicActExtraido = null;
							controller3._FicActNombre = null;
							Mutex.ReleaseMutex();
							iArchive.CompressedBytesRead -= archive_CompressedBytesRead;
							iArchive.EntryExtractionBegin -= archive_EntryExtractionBegin;
						}
					}
					finally
					{
						((IDisposable)iArchive)?.Dispose();
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception = ex;
					Exception = exception;
					ProjectData.ClearProjectError();
				}
			}
		}

		private void archive_CompressedBytesRead(object sender, CompressedBytesReadEventArgs e)
		{
			DescompresorController controller = GetController();
			Mutex.WaitOne();
			controller._FicActExtraido = e.CompressedBytesRead;
			Mutex.ReleaseMutex();
		}

		private void archive_EntryExtractionBegin(object sender, ArchiveExtractionEventArgs<IArchiveEntry> e)
		{
			DescompresorController controller = GetController();
			Mutex.WaitOne();
			checked
			{
				controller._TamanoTotalExtraido += controller._FicActTamanoTotal;
				controller._FicActTamanoTotal = ((IEntry)e.Item).Size;
				controller._FicActExtraido = 0L;
				Mutex.ReleaseMutex();
			}
		}
	}

	internal static System.Threading.Mutex Mutex = new System.Threading.Mutex();

	private static DescompresorController _Controller;

	private Dictionary<string, QueueItem> _colaElementos;

	private string _codigoElementoActual;

	private string _pathElementoActual;

	private string _passwordElementoActual;

	private bool _crearDirectorio;

	private List<string> _ExtensionesSoportadas;

	internal long? _TamanoTotal;

	internal long? _TamanoTotalExtraido;

	internal long? _FicActTamanoTotal;

	internal long? _FicActExtraido;

	internal string _FicActNombre;

	public long? EleActual_TamanoTotal
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return _TamanoTotal;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public long? EleActual_TamanoTotalExtraido
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return _TamanoTotalExtraido;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public string EleActual_Ruta
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return _pathElementoActual;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public string EleActual_Codigo
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return _codigoElementoActual;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public long? EleActual_FicActTamano
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return _FicActTamanoTotal;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public long? EleActual_FicActExtraido
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return _FicActExtraido;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public string EleActual_FicActNombre
	{
		get
		{
			Mutex.WaitOne();
			try
			{
				return _FicActNombre;
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
		}
	}

	public event DescompresionFinalizadaEventHandler DescompresionFinalizada;

	public static DescompresorController GetController()
	{
		Mutex.WaitOne();
		if (_Controller == null)
		{
			_Controller = new DescompresorController();
		}
		Mutex.ReleaseMutex();
		return _Controller;
	}

	private DescompresorController()
	{
		Mutex.WaitOne();
		_colaElementos = new Dictionary<string, QueueItem>();
		_codigoElementoActual = null;
		_pathElementoActual = null;
		_passwordElementoActual = null;
		_ExtensionesSoportadas = new List<string>();
		List<string> extensionesSoportadas = _ExtensionesSoportadas;
		extensionesSoportadas.Add("7z");
		extensionesSoportadas.Add("rar");
		extensionesSoportadas.Add("tar");
		extensionesSoportadas.Add("zip");
		object _ = null;
		Mutex.ReleaseMutex();
	}

	private bool PonerElementoAProcesar()
	{
		Mutex.WaitOne();
		try
		{
			if (!string.IsNullOrEmpty(_pathElementoActual) | (_colaElementos.Count == 0))
			{
				return false;
			}
			_codigoElementoActual = _colaElementos.Keys.ElementAtOrDefault(0);
			_crearDirectorio = _colaElementos[_codigoElementoActual].CreateDirectory;
			_pathElementoActual = _colaElementos[_codigoElementoActual].Path;
			_passwordElementoActual = _colaElementos[_codigoElementoActual].Password;
			_colaElementos.Remove(_codigoElementoActual);
			return true;
		}
		finally
		{
			Mutex.ReleaseMutex();
		}
	}

	private void ProcesarElemento(ref bool Cancel)
	{
		try
		{
			Mutex.WaitOne();
			if (string.IsNullOrEmpty(_pathElementoActual))
			{
				return;
			}
		}
		finally
		{
			Mutex.ReleaseMutex();
		}
		Log.WriteInfo("Extracting '" + _codigoElementoActual + "'");
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		string Fichero = "";
		string Directorio = "";
		string FicheroSinExtension = "";
		string pathElementoActual = _pathElementoActual;
		bool IsRARPart = false;
		int RARPartLength = 0;
		if (!ObtenerNombres(pathElementoActual, ref Directorio, ref Fichero, ref FicheroSinExtension, ref IsRARPart, ref RARPartLength))
		{
			Mutex.WaitOne();
			_pathElementoActual = null;
			_passwordElementoActual = null;
			Mutex.ReleaseMutex();
			Log.WriteWarning("Decompressor: invalid element, discarding: '" + _codigoElementoActual + "'");
			return;
		}
		string pathExtraccion = Directorio;
		if (_crearDirectorio)
		{
			pathExtraccion = Path.Combine(Directorio, FicheroSinExtension);
		}
		bool flag = false;
		Descompressor descompressor = new Descompressor(_pathElementoActual, pathExtraccion, _passwordElementoActual);
		Thread thread = new Thread(descompressor.Extract);
		thread.Priority = ThreadPriority.BelowNormal;
		thread.Start();
		while (!thread.Join(500) && !flag)
		{
			if (Cancel)
			{
				thread.Abort();
				Thread.Sleep(300);
				flag = true;
			}
		}
		if (descompressor.Exception != null)
		{
			Log.WriteError("Decompressor: Error extracting '" + _codigoElementoActual + "' (file '" + _pathElementoActual + "'): " + descompressor.Exception.ToString());
		}
		stopwatch.Stop();
		Log.WriteInfo("Element '" + _codigoElementoActual + "' extracted in " + Conversions.ToString(stopwatch.ElapsedMilliseconds) + "ms");
		DescompresionFinalizada?.Invoke(_codigoElementoActual);
		Mutex.WaitOne();
		_pathElementoActual = null;
		_passwordElementoActual = null;
		_codigoElementoActual = null;
		Mutex.ReleaseMutex();
	}

	private static bool ObtenerNombres(string Path, ref string Directorio, ref string Fichero, ref string FicheroSinExtension, ref bool IsRARPart, ref int RARPartLength)
	{
		FileInfo fileInfo = new FileInfo(Path);
		if (fileInfo.Exists)
		{
			Fichero = fileInfo.Name;
			if (Fichero.Contains("."))
			{
				FicheroSinExtension = Fichero.Substring(0, Fichero.LastIndexOf('.'));
			}
			else
			{
				FicheroSinExtension = Fichero;
			}
			Directorio = fileInfo.DirectoryName;
			if (Fichero.ToLower().EndsWith(".rar") & FicheroSinExtension.Contains("."))
			{
				string text = FicheroSinExtension.Substring(checked(FicheroSinExtension.LastIndexOf('.') + 1)) ?? "";
				if (text.Length > 4 && Operators.CompareString(text.ToLower().Substring(0, 4), "part", TextCompare: false) == 0 && Versioned.IsNumeric(text.ToLower().Substring(4)))
				{
					FicheroSinExtension = FicheroSinExtension.Substring(0, FicheroSinExtension.LastIndexOf('.'));
					RARPartLength = text.ToLower().Substring(4).Length;
					IsRARPart = true;
				}
				else
				{
					IsRARPart = false;
				}
			}
			else
			{
				IsRARPart = false;
			}
			return true;
		}
		return false;
	}

	public bool AgregarElemento(string Code, string Path, bool CrearDirectorio, string Password)
	{
		if (string.IsNullOrEmpty(Path))
		{
			return false;
		}
		if (!File.Exists(Path))
		{
			return false;
		}
		bool flag = false;
		foreach (string extensionesSoportada in _ExtensionesSoportadas)
		{
			if (Path.ToLower().EndsWith("." + extensionesSoportada))
			{
				flag = true;
			}
		}
		if (!flag)
		{
			return false;
		}
		string Fichero = "";
		string Directorio = "";
		string FicheroSinExtension = "";
		bool IsRARPart = false;
		int RARPartLength = 0;
		if (ObtenerNombres(Path, ref Directorio, ref Fichero, ref FicheroSinExtension, ref IsRARPart, ref RARPartLength))
		{
			if (IsRARPart)
			{
				string text = System.IO.Path.Combine(Directorio, FicheroSinExtension) + ".part" + "1".PadLeft(RARPartLength, '0') + ".rar";
				if (File.Exists(text))
				{
					Path = text;
				}
			}
			Mutex.WaitOne();
			try
			{
				foreach (string key in _colaElementos.Keys)
				{
					if (Operators.CompareString(_colaElementos[key].Path, Path, TextCompare: false) == 0)
					{
						Log.WriteInfo("File '" + Path + "' for element '" + Code + "' is already in queue.");
						return false;
					}
				}
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
			Log.WriteInfo("Adding to decompression queue element '" + Code + "' (file '" + Path + "')");
			Mutex.WaitOne();
			if (!_colaElementos.ContainsKey(Code))
			{
				_colaElementos.Add(Code, new QueueItem
				{
					Path = Path,
					CreateDirectory = CrearDirectorio,
					Password = Password
				});
			}
			Mutex.ReleaseMutex();
			return true;
		}
		return false;
	}

	public static void DescompresorController_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			Log.WriteWarning("Starting worker bgwDescompresor");
			BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
			while (!backgroundWorker.CancellationPending)
			{
				if (GetController().PonerElementoAProcesar())
				{
					DescompresorController controller = GetController();
					bool Cancel = backgroundWorker.CancellationPending;
					controller.ProcesarElemento(ref Cancel);
				}
				if (backgroundWorker.CancellationPending)
				{
					break;
				}
				Thread.Sleep(600);
			}
			Log.WriteWarning("Finishing worker bgwDescompresor");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error on worker bgwDescompresor: " + ex2.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public List<string> GetCola()
	{
		Mutex.WaitOne();
		try
		{
			List<string> list = new List<string>();
			foreach (string key in _colaElementos.Keys)
			{
				list.Add(_colaElementos[key].Path);
			}
			return list;
		}
		finally
		{
			Mutex.ReleaseMutex();
		}
	}

	public bool Ocupado()
	{
		Mutex.WaitOne();
		try
		{
			return !string.IsNullOrEmpty(_pathElementoActual) | (_colaElementos.Count > 0);
		}
		finally
		{
			Mutex.ReleaseMutex();
		}
	}
}
