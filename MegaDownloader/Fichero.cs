using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class Fichero : IDescarga, IDisposable
{
	private class Cache
	{
		public string FileKey;

		public string FileID;

		public string URLFichero;

		public string URL;

		public string OptionalPassword;
	}

	private class DownloadWorker : BackgroundWorker
	{
		public Configuracion Config;

		public int NumConexionesDisponibles;

		public DownloadWorker(ref Configuracion Configuration, int NumeroConexionesDisponibles)
		{
			NumConexionesDisponibles = NumeroConexionesDisponibles;
			Config = Configuration;
		}
	}

	public const string HIDDEN_LINK = "{HIDDEN}";

	public const string HIDDEN_LINK_DESC = "** LINK NOT VISIBLE **";

	public SecureString _FileID;

	public SecureString _FileKey;

	public SecureString _URL;

	public SecureString _URLFichero;

	public string NombreFichero;

	public string RutaLocal;

	public string RutaRelativa;

	public long TamanoBytes;

	public int NumeroConexionesAbiertas;

	public int NumeroChunksAsignados;

	public string MD5;

	public bool LinkVisible;

	public string DescripcionError;

	public DateTime? FechaUltimoError;

	public decimal Porcentaje;

	public bool DescargaComenzada;

	public bool DescargaProcesada;

	public bool ExtraccionFicheroAutomatica;

	public string ExtraccionFicheroPassword;

	public int Prioridad;

	public decimal VelocidadKBs;

	public long BytesDescargados;

	public Estado EstadoDescarga;

	public bool MarcadoParaBorrarFicheroLocal;

	public string TiempoEstimadoDescarga;

	public bool PausaIndividual;

	public bool DescargaIndividual;

	public FileDownloader.DataPart DatosPartes;

	private int NumErroresChunk;

	public int LimiteVelocidad;

	private Exception UltimoErrorChunk;

	private int Version;

	private const int NUM_MAX_ERRORES_CHUNK = 100;

	private const string keyUrl = "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE";

	private Cache CacheSecureData;

	private bool _Actualizando;

	[CompilerGenerated]
	[AccessedThroughProperty("bgArranque")]
	private DownloadWorker _bgArranque;

	private bool disposedValue;

	[field: AccessedThroughProperty("Downloader")]
	private FileDownloader Downloader
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public string URL
	{
		get
		{
			string text = Criptografia.ToInsecureString(_URL);
			if (string.IsNullOrEmpty(text) | (Version > 1))
			{
				return text;
			}
			return Criptografia.AES_DecryptString(text, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE");
		}
		set
		{
			if (Version > 1)
			{
				_URL = Criptografia.ToSecureString(value);
			}
			else
			{
				_URL = Criptografia.ToSecureString(Criptografia.AES_EncryptString(value, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE"));
			}
			CacheSecureData = null;
		}
	}

	public string URLFichero
	{
		get
		{
			string text = Criptografia.ToInsecureString(_URLFichero);
			if (string.IsNullOrEmpty(text) | (Version > 1))
			{
				return text;
			}
			return Criptografia.AES_DecryptString(text, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE");
		}
		set
		{
			if (Version > 1)
			{
				_URLFichero = Criptografia.ToSecureString(value);
			}
			else
			{
				_URLFichero = Criptografia.ToSecureString(Criptografia.AES_EncryptString(value, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE"));
			}
			CacheSecureData = null;
		}
	}

	public string FileID
	{
		get
		{
			string text = Criptografia.ToInsecureString(_FileID);
			if (string.IsNullOrEmpty(text) | (Version > 1))
			{
				return text;
			}
			return Criptografia.AES_DecryptString(text, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE");
		}
		set
		{
			if (Version > 1)
			{
				_FileID = Criptografia.ToSecureString(value);
			}
			else
			{
				_FileID = Criptografia.ToSecureString(Criptografia.AES_EncryptString(value, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE"));
			}
			CacheSecureData = null;
		}
	}

	public string FileKey
	{
		get
		{
			string text = Criptografia.ToInsecureString(_FileKey);
			if (string.IsNullOrEmpty(text) | (Version > 1))
			{
				return text;
			}
			return Criptografia.AES_DecryptString(text, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE");
		}
		set
		{
			if (Version > 1)
			{
				_FileKey = Criptografia.ToSecureString(value);
			}
			else
			{
				_FileKey = Criptografia.ToSecureString(Criptografia.AES_EncryptString(value, "xmpcphVkCTJ2unykcwRMBecz3jEnTX93Nv5KZGrtYK6LE3WE"));
			}
			CacheSecureData = null;
		}
	}

	public Estado SetDescargaEstado
	{
		set
		{
			EstadoDescarga = value;
		}
	}

	public int SetDescargaPrioridad
	{
		set
		{
			Prioridad = value;
		}
	}

	public void SetDescargaExtraccionAutomatica(string password, bool value)
	{
		ExtraccionFicheroAutomatica = value;
		ExtraccionFicheroPassword = password;
	}

	private DownloadWorker bgArranque
	{
		[CompilerGenerated]
		get
		{
			return _bgArranque;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgArranque_DoWork;
			RunWorkerCompletedEventHandler value3 = bgArranque_RunWorkerCompleted;
			DownloadWorker downloadWorker = _bgArranque;
			if (downloadWorker != null)
			{
				downloadWorker.DoWork -= value2;
				downloadWorker.RunWorkerCompleted -= value3;
			}
			_bgArranque = value;
			downloadWorker = _bgArranque;
			if (downloadWorker != null)
			{
				downloadWorker.DoWork += value2;
				downloadWorker.RunWorkerCompleted += value3;
			}
		}
	}

	public event EventHandler CancellationComplete;

	public Fichero()
		: this("")
	{
	}

	public Fichero(string Url)
	{
		CacheSecureData = null;
		_Actualizando = false;
		Version = 2;
		LinkVisible = true;
		URL = Url;
		URLFichero = "";
		FileID = "";
		FileKey = "";
		NombreFichero = "";
		RutaLocal = "";
		RutaRelativa = "";
		TamanoBytes = 0L;
		MD5 = "";
		Porcentaje = default(decimal);
		DescargaComenzada = false;
		DescargaProcesada = false;
		ExtraccionFicheroAutomatica = false;
		ExtraccionFicheroPassword = null;
		Prioridad = 0;
		VelocidadKBs = default(decimal);
		EstadoDescarga = Estado.EnCola;
		MarcadoParaBorrarFicheroLocal = false;
		TamanoBytes = 0L;
		BytesDescargados = 0L;
		NumErroresChunk = 0;
		PausaIndividual = false;
		DescargaIndividual = false;
	}

	private void RegenerateCacheSecureData()
	{
		Cache cache = new Cache();
		cache.FileID = Criptografia.EncryptString_DPAPI(_FileID);
		cache.FileKey = Criptografia.EncryptString_DPAPI(_FileKey);
		cache.URL = Criptografia.EncryptString_DPAPI(Criptografia.ToSecureString((LinkVisible ? "" : "{HIDDEN}") + Criptografia.ToInsecureString(_URL)));
		cache.URLFichero = Criptografia.EncryptString_DPAPI(_URLFichero);
		CacheSecureData = cache;
	}

	public string DescargaNombre()
	{
		if (string.IsNullOrEmpty(NombreFichero))
		{
			return FileID;
		}
		return NombreFichero;
	}

	string IDescarga.DescargaNombre()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaNombre
		return this.DescargaNombre();
	}

	public decimal DescargaPorcentaje()
	{
		return Porcentaje;
	}

	decimal IDescarga.DescargaPorcentaje()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaPorcentaje
		return this.DescargaPorcentaje();
	}

	public long DescargaTamanoBytes()
	{
		return TamanoBytes;
	}

	long IDescarga.DescargaTamanoBytes()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaTamanoBytes
		return this.DescargaTamanoBytes();
	}

	public decimal DescargaVelocidadKBs()
	{
		return VelocidadKBs;
	}

	decimal IDescarga.DescargaVelocidadKBs()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaVelocidadKBs
		return this.DescargaVelocidadKBs();
	}

	public Estado DescargaEstado()
	{
		return EstadoDescarga;
	}

	Estado IDescarga.DescargaEstado()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaEstado
		return this.DescargaEstado();
	}

	public int DescargaPrioridad()
	{
		return Prioridad;
	}

	int IDescarga.DescargaPrioridad()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaPrioridad
		return this.DescargaPrioridad();
	}

	public bool DescargaExtraccionAutomatica()
	{
		return ExtraccionFicheroAutomatica;
	}

	bool IDescarga.DescargaExtraccionAutomatica()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaExtraccionAutomatica
		return this.DescargaExtraccionAutomatica();
	}

	public string DescargaExtraccionPassword()
	{
		return ExtraccionFicheroPassword;
	}

	string IDescarga.DescargaExtraccionPassword()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaExtraccionPassword
		return this.DescargaExtraccionPassword();
	}

	public string DescargaTiempoEstimadoDescarga()
	{
		return TiempoEstimadoDescarga;
	}

	string IDescarga.DescargaTiempoEstimadoDescarga()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaTiempoEstimadoDescarga
		return this.DescargaTiempoEstimadoDescarga();
	}

	public void ActualizarInformacionFichero(Configuracion Config, ref Conexion.TipoError ErrorObtenido, bool ComprobacionAntesDescarga)
	{
		if (_Actualizando)
		{
			return;
		}
		_Actualizando = true;
		try
		{
			Estado setDescargaEstado = DescargaEstado();
			SetDescargaEstado = Estado.Verificando;
			Conexion.InformacionFichero informacionFichero = Conexion.ObtenerInformacionFichero(Config, FileID, FileKey, ComprobacionAntesDescarga);
			if (informacionFichero != null && informacionFichero.Err == Conexion.TipoError.SinErrores)
			{
				if (!string.IsNullOrEmpty(informacionFichero.URL))
				{
					URLFichero = informacionFichero.URL;
				}
				if (informacionFichero.Tamano > 0)
				{
					TamanoBytes = informacionFichero.Tamano;
				}
				if (!string.IsNullOrEmpty(informacionFichero.Nombre))
				{
					NombreFichero = informacionFichero.Nombre;
				}
				MD5 = informacionFichero.MD5;
				DescargaProcesada = true;
				SetDescargaEstado = setDescargaEstado;
				FileKey = informacionFichero.FileKey;
				FileID = informacionFichero.FileID;
			}
			else if (informacionFichero != null && informacionFichero.Err != Conexion.TipoError.SinErrores)
			{
				ErrorObtenido = informacionFichero.Err;
				EstablecerError("The file could not be verified.\r\n * File code: " + FileID + "\r\n * Error type: " + informacionFichero.Err.ToString() + "\r\n * Internal info: " + informacionFichero.Errtxt);
			}
		}
		finally
		{
			_Actualizando = false;
		}
	}

	public static string ExtraerFileKey(string URL)
	{
		return URLExtractor.ExtraerFileKey(URL);
	}

	public static string ExtraerFileID(string URL)
	{
		return URLExtractor.ExtraerFileID(URL);
	}

	public void BorrarFicheroLocal()
	{
		if (!MarcadoParaBorrarFicheroLocal)
		{
			return;
		}
		Mutex.DeletingFiles.WaitOne();
		string text = string.Empty;
		try
		{
			text = Path.Combine(RutaLocal, NombreFichero);
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			text = Path.Combine(RutaLocal, NombreFichero + ".part");
			if (File.Exists(text))
			{
				File.Delete(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error deleting local files - Path: " + text + " - Error: " + ex2.ToString());
			MessageBox.Show(Language.GetText("Error deleting local files - Path: %PATH% - Error: %ERROR%").Replace("%PATH%", text).Replace("%ERROR%", ex2.Message), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			Mutex.DeletingFiles.ReleaseMutex();
		}
	}

	public string ObtenerNombreSinExtension()
	{
		if (!string.IsNullOrEmpty(NombreFichero) && NombreFichero.Contains("."))
		{
			string text = NombreFichero.Substring(0, NombreFichero.LastIndexOf("."));
			if (text.LastIndexOf(".part") >= 0 && Versioned.IsNumeric(text.Substring(checked(text.LastIndexOf(".part") + 5))))
			{
				text = text.Substring(0, text.LastIndexOf(".part"));
			}
			return text;
		}
		return NombreFichero;
	}

	private void bgArranque_DoWork(object sender, DoWorkEventArgs e)
	{
		checked
		{
			try
			{
				DownloadWorker downloadWorker = (DownloadWorker)sender;
				Conexion.TipoError ErrorObtenido = Conexion.TipoError.SinErrores;
				ActualizarInformacionFichero(downloadWorker.Config, ref ErrorObtenido, ComprobacionAntesDescarga: true);
				if (ErrorObtenido == Conexion.TipoError.SinErrores)
				{
					NumErroresChunk = 0;
					Downloader = new FileDownloader(supportsProgress: true);
					Downloader.Resumed += downloader_Started;
					Downloader.Started += downloader_Started;
					Downloader.Paused += downloader_Paused;
					Downloader.CancelRequested += downloader_CancelRequested;
					Downloader.Canceled += downloader_Canceled;
					Downloader.Completed += downloader_Completed;
					Downloader.FileDownloadFailed += downloader_FileDownloadFailed;
					Downloader.ChunkDownloadFailed += downloader_ChunkDownloadFailed;
					Downloader.FileLocalCreated += downloader_FileLocalCreated;
					Downloader.setBufferAndPackageSize(downloadWorker.Config.TamanoBufferKB * 1024, downloadWorker.Config.TamanoPaqueteKB * 1024);
					Downloader.StopWatchCyclesAmount = 30;
					Downloader.LocalDirectory = RutaLocal;
					Downloader.DeleteFilesAfterCancel = false;
					Downloader.DeleteCompletedFilesAfterCancel = false;
					Downloader.PartsPerFile = downloadWorker.Config.ConexionesPorFichero;
					Downloader.NumConnections = ((downloadWorker.Config.ConexionesPorFichero < downloadWorker.NumConexionesDisponibles) ? downloadWorker.Config.ConexionesPorFichero : downloadWorker.NumConexionesDisponibles);
					Downloader.AddFileInfo(FileID, FileKey, URLFichero, DescargaNombre(), DatosPartes);
					if (Downloader.CanStart)
					{
						Downloader.Start();
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error on bgArranque_DoWork: " + ex2.ToString());
				bgArranque = null;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void bgArranque_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		bgArranque.Dispose();
		bgArranque = null;
	}

	public void Start(ref Configuracion Config, int NumConexionesDisponibles)
	{
		if (Estado.Erroneo != DescargaEstado())
		{
			if ((Downloader == null) & (bgArranque == null))
			{
				EstadoDescarga = Estado.CreandoLocal;
				DescargaComenzada = true;
				bgArranque = new DownloadWorker(ref Config, NumConexionesDisponibles);
				bgArranque.WorkerSupportsCancellation = false;
				bgArranque.WorkerReportsProgress = false;
				bgArranque.RunWorkerAsync();
			}
			else if (Downloader != null && Downloader.CanStart)
			{
				EstadoDescarga = Estado.CreandoLocal;
				DescargaComenzada = true;
				Downloader.Start();
			}
		}
	}

	public void Resume()
	{
		if (Downloader != null && Downloader.CanResume)
		{
			Downloader.Resume();
		}
	}

	public void Pause()
	{
		if (Downloader != null && Downloader.CanPause)
		{
			Downloader.Pause();
		}
	}

	public void Stop()
	{
		int num = 100;
		for (int i = 0; _Actualizando && i < num; i = checked(i + 1))
		{
			Thread.Sleep(50);
		}
		if (Downloader == null)
		{
			CancellationComplete?.Invoke(this, new EventArgs());
		}
		else if (Downloader.CanStop)
		{
			Downloader.Stop();
		}
	}

	public void DescompresionFinalizada()
	{
		if (EstadoDescarga == Estado.Descomprimiendo)
		{
			EstadoDescarga = Estado.Completado;
		}
	}

	private void downloader_Started(object sender, EventArgs e)
	{
		EstadoDescarga = Estado.Descargando;
		DescargaComenzada = true;
	}

	private void downloader_Paused(object sender, EventArgs e)
	{
		EstadoDescarga = Estado.Pausado;
	}

	private void downloader_CancelRequested(object sender, EventArgs e)
	{
		EstadoDescarga = Estado.Pausado;
	}

	private void downloader_FileLocalCreated(object sender, EventArgs e)
	{
		EstadoDescarga = Estado.Descargando;
	}

	private void downloader_FileDownloadFailed(object sender, Exception e)
	{
		EstadoDescarga = Estado.Erroneo;
		string text = "";
		try
		{
			if (e is WebException && ((WebException)e).Response != null)
			{
				using Stream stream = ((WebException)e).Response.GetResponseStream();
				using StreamReader streamReader = new StreamReader(stream);
				text = streamReader.ReadToEnd();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		EstablecerError("File download failed.\r\n * File code: " + FileID + "\r\n * Error type: An error occurred while trying to download the file.\r\n * Server response: " + text + "\r\n * Internal info: " + e.ToString());
		Log.WriteError(DescripcionError);
	}

	private void downloader_ChunkDownloadFailed(object sender, Exception e)
	{
		string text = "";
		try
		{
			if (e is WebException && ((WebException)e).Response != null)
			{
				using Stream stream = ((WebException)e).Response.GetResponseStream();
				using StreamReader streamReader = new StreamReader(stream);
				text = streamReader.ReadToEnd();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		Log.WriteError("Chunk download failed. Reconnecting. \r\n * File code: " + FileID + "\r\n * Error type: An error occurred while trying to download the file.\r\n * Server response: " + text + "\r\n * Internal info: " + e.ToString());
		UltimoErrorChunk = e;
		checked
		{
			NumErroresChunk++;
			if (NumErroresChunk > 100)
			{
				Stop();
			}
		}
	}

	private void downloader_Completed(object sender, EventArgs e)
	{
		if (EstadoDescarga != Estado.Erroneo)
		{
			Log.WriteWarning("File " + FileID + " downloaded.");
			EstadoDescarga = Estado.Completado;
			if (!string.IsNullOrEmpty(MD5))
			{
				Log.WriteInfo("Verifying MD5...");
				EstadoDescarga = Estado.ComprobandoMD5;
				string text = "";
				try
				{
					text = MD5Utils.MD5CalcFile(Path.Combine(RutaLocal, NombreFichero));
					if (Operators.CompareString(text.ToUpper(), MD5.ToUpper(), TextCompare: false) == 0)
					{
						EstadoDescarga = Estado.Completado;
						Log.WriteInfo("MD5 file " + FileID + " verified.");
					}
					else
					{
						EstablecerError("File downloaded correctly (aparently), but the MD5 verification has failed.\r\nThis mean that the file is corrupted. Try opening and if it fails, download it again. After few tries if it is still corrupted, it could mean that it is corrupted on the server.\r\n * File code: " + FileID + "\r\n * Error type: Error verifying MD5\r\n * Internal info: calculated MD5 [" + text + "]; expected MD5 [" + MD5 + "]");
						Log.WriteInfo("File " + FileID + " checked, MD5 does not match.");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteError("Error verifying MD5: " + ex2.ToString());
					EstadoDescarga = Estado.Completado;
					ProjectData.ClearProjectError();
				}
			}
		}
		if (EstadoDescarga != Estado.Erroneo && ExtraccionFicheroAutomatica && DescompresorController.GetController().AgregarElemento(FileID, Path.Combine(RutaLocal, NombreFichero), CrearDirectorio: true, DescargaExtraccionPassword()))
		{
			EstadoDescarga = Estado.Descomprimiendo;
		}
	}

	private void downloader_Canceled(object sender, EventArgs e)
	{
		EstadoDescarga = Estado.EnCola;
		Mutex.FicheroDownloader.WaitOne();
		try
		{
			if (Downloader != null)
			{
				Downloader.Resumed -= downloader_Started;
				Downloader.Started -= downloader_Started;
				Downloader.Paused -= downloader_Paused;
				Downloader.CancelRequested -= downloader_CancelRequested;
				Downloader.Canceled -= downloader_Canceled;
				Downloader.Completed -= downloader_Completed;
				Downloader.FileDownloadFailed -= downloader_FileDownloadFailed;
				Downloader.ChunkDownloadFailed -= downloader_ChunkDownloadFailed;
				Downloader.FileLocalCreated -= downloader_FileLocalCreated;
				Downloader.Dispose();
			}
			Downloader = null;
		}
		finally
		{
			Mutex.FicheroDownloader.ReleaseMutex();
		}
		if (MarcadoParaBorrarFicheroLocal)
		{
			BorrarFicheroLocal();
		}
		if (NumErroresChunk > 100)
		{
			string text = "Download stopped because there were too many connection errors (" + Conversions.ToString(NumErroresChunk) + "). \r\nLast error: \r\n * File code: " + FileID + "\r\n * Error type: Connection error.\r\n * Internal info: " + UltimoErrorChunk.ToString();
			EstablecerError(text);
			Log.WriteError(text);
		}
		CancellationComplete?.Invoke(this, new EventArgs());
	}

	public void ActualizarDatosDescarga()
	{
		Mutex.FicheroDownloader.WaitOne();
		checked
		{
			try
			{
				if (Downloader != null)
				{
					NumeroConexionesAbiertas = Downloader.OpenConnections;
					if (Downloader.File != null && Downloader.File.Size > 0)
					{
						DatosPartes = Downloader.File.GetDataPart;
					}
					VelocidadKBs = new decimal((double)Downloader.DownloadSpeed / 1024.0);
					if ((Downloader.CurrentFileSize > 0) | (TamanoBytes == 0))
					{
						TamanoBytes = Downloader.CurrentFileSize;
					}
					if ((Downloader.CurrentFileProgress > 0) | (BytesDescargados == 0))
					{
						BytesDescargados = Downloader.CurrentFileProgress;
						if (BytesDescargados > TamanoBytes)
						{
							BytesDescargados = TamanoBytes;
						}
					}
					if (TamanoBytes > 0)
					{
						Porcentaje = new decimal((double)(100 * BytesDescargados) / (double)TamanoBytes);
					}
				}
				if (EstadoDescarga == Estado.Descargando)
				{
					if (decimal.Compare(VelocidadKBs, 0m) == 0)
					{
						TiempoEstimadoDescarga = " --- ";
						return;
					}
					double num = Convert.ToDouble(decimal.Divide(decimal.Subtract(new decimal(TamanoBytes), decimal.Divide(decimal.Multiply(Porcentaje, new decimal(TamanoBytes)), 100m)), decimal.Multiply(1024m, VelocidadKBs)));
					TimeSpan timeSpan = TimeSpan.FromSeconds(num);
					if (num > 3600.0)
					{
						TiempoEstimadoDescarga = $"{timeSpan.Days * 24 + timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
					}
					else
					{
						TiempoEstimadoDescarga = $"{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
					}
				}
				else
				{
					TiempoEstimadoDescarga = "";
				}
			}
			finally
			{
				Mutex.FicheroDownloader.ReleaseMutex();
			}
		}
	}

	private void EstablecerError(string msj)
	{
		EstadoDescarga = Estado.Erroneo;
		DescripcionError = msj;
		FechaUltimoError = DateAndTime.Now;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
		}
		disposedValue = true;
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

	public void CargarXML(XmlNode XML)
	{
		if (XML.Attributes["v"] != null && Versioned.IsNumeric(XML.Attributes["v"].Value))
		{
			Version = Conversions.ToInteger(XML.Attributes["v"].Value);
		}
		else
		{
			Version = 1;
		}
		string Path = "FileID";
		_FileID = Criptografia.DecryptString_DPAPI(LeerNodo(ref XML, ref Path, ""));
		Path = "FileKey";
		_FileKey = Criptografia.DecryptString_DPAPI(LeerNodo(ref XML, ref Path, ""));
		Path = "URL";
		_URL = Criptografia.DecryptString_DPAPI(LeerNodo(ref XML, ref Path, ""));
		Path = "URLFichero";
		_URLFichero = Criptografia.DecryptString_DPAPI(LeerNodo(ref XML, ref Path, ""));
		string text = Criptografia.ToInsecureString(_URL);
		if (text.StartsWith("{HIDDEN}"))
		{
			_URL = Criptografia.ToSecureString(text.Replace("{HIDDEN}", ""));
			LinkVisible = false;
		}
		Path = "NombreFichero";
		NombreFichero = LeerNodo(ref XML, ref Path, "");
		Path = "RutaRelativa";
		RutaRelativa = LeerNodo(ref XML, ref Path, "");
		Path = "RutaLocal";
		RutaLocal = LeerNodo(ref XML, ref Path, "");
		Path = "TamanoBytes";
		long.TryParse(LeerNodo(ref XML, ref Path, "0"), out TamanoBytes);
		Path = "NumeroConexionesAbiertas";
		int.TryParse(LeerNodo(ref XML, ref Path, "0"), out NumeroConexionesAbiertas);
		Path = "NumeroChunksAsignados";
		int.TryParse(LeerNodo(ref XML, ref Path, "0"), out NumeroChunksAsignados);
		Path = "FechaUltimoError";
		string value = LeerNodo(ref XML, ref Path, "");
		if (!string.IsNullOrEmpty(value))
		{
			FechaUltimoError = Conversions.ToDate(value);
		}
		Path = "Porcentaje";
		decimal.TryParse(LeerNodo(ref XML, ref Path, "0"), out Porcentaje);
		Path = "DescargaComenzada";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out DescargaComenzada);
		Path = "DescargaProcesada";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out DescargaProcesada);
		Path = "ExtraccionFicheroAutomatica";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out ExtraccionFicheroAutomatica);
		Path = "ExtraccionFicheroPassword";
		string text2 = LeerNodo(ref XML, ref Path, "");
		if (!string.IsNullOrEmpty(text2))
		{
			ExtraccionFicheroPassword = Criptografia.AES_DecryptString(text2, "passZIP");
		}
		Path = "Prioridad";
		int.TryParse(LeerNodo(ref XML, ref Path, "0"), out Prioridad);
		Path = "VelocidadKBs";
		decimal.TryParse(LeerNodo(ref XML, ref Path, "0"), out VelocidadKBs);
		Path = "BytesDescargados";
		long.TryParse(LeerNodo(ref XML, ref Path, "0"), out BytesDescargados);
		EstadoDescarga = Estado.EnCola;
		Type typeFromHandle = typeof(Estado);
		Path = "EstadoDescarga";
		if (Enum.IsDefined(typeFromHandle, LeerNodo(ref XML, ref Path, "")))
		{
			Type typeFromHandle2 = typeof(Estado);
			Path = "EstadoDescarga";
			EstadoDescarga = (Estado)Conversions.ToInteger(Enum.Parse(typeFromHandle2, LeerNodo(ref XML, ref Path, "")));
		}
		Path = "MarcadoParaBorrarFicheroLocal";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out MarcadoParaBorrarFicheroLocal);
		Path = "DescargaIndividual";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out DescargaIndividual);
		Path = "PausaIndividual";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out PausaIndividual);
		Path = "TiempoEstimadoDescarga";
		TiempoEstimadoDescarga = LeerNodo(ref XML, ref Path, "");
		Path = "LimiteVelocidad";
		int.TryParse(LeerNodo(ref XML, ref Path, "0"), out LimiteVelocidad);
		if (XML.SelectSingleNode("DatosPartes") == null)
		{
			return;
		}
		XmlNode NodoXML = XML.SelectSingleNode("DatosPartes");
		DatosPartes = new FileDownloader.DataPart();
		Path = "AllFinished";
		bool.TryParse(LeerNodo(ref NodoXML, ref Path, "false"), out DatosPartes.AllFinished);
		if (NodoXML.SelectSingleNode("ChunkList") == null)
		{
			return;
		}
		XmlNode xmlNode = NodoXML.SelectSingleNode("ChunkList");
		DatosPartes.ChunkList = new List<FileDownloader.DataPart.Chunk>();
		foreach (XmlNode item in xmlNode.SelectNodes("Chunk"))
		{
			XmlNode NodoXML2 = item;
			FileDownloader.DataPart.Chunk chunk = new FileDownloader.DataPart.Chunk();
			Path = "Index";
			long.TryParse(LeerNodo(ref NodoXML2, ref Path, "0"), out chunk.Index);
			Path = "Size";
			long.TryParse(LeerNodo(ref NodoXML2, ref Path, "0"), out chunk.Size);
			Path = "StartIndex";
			long.TryParse(LeerNodo(ref NodoXML2, ref Path, "0"), out chunk.StartIndex);
			Path = "Available";
			bool.TryParse(LeerNodo(ref NodoXML2, ref Path, "false"), out chunk.Available);
			DatosPartes.ChunkList.Add(chunk);
		}
	}

	public XmlNode GuardarXML(XmlDocument XML, bool IncluirDatosCifrados)
	{
		XmlNode xmlNode = XML.CreateElement("Fichero");
		xmlNode.Attributes.Append(XML.CreateAttribute("v")).Value = Version.ToString();
		if (IncluirDatosCifrados)
		{
			if (CacheSecureData == null)
			{
				RegenerateCacheSecureData();
			}
			xmlNode.AppendChild(XML.CreateElement("FileID")).InnerText = CacheSecureData.FileID;
			xmlNode.AppendChild(XML.CreateElement("FileKey")).InnerText = CacheSecureData.FileKey;
			xmlNode.AppendChild(XML.CreateElement("URL")).InnerText = CacheSecureData.URL;
			xmlNode.AppendChild(XML.CreateElement("URLFichero")).InnerText = CacheSecureData.URLFichero;
			xmlNode.AppendChild(XML.CreateElement("OptionalPassword")).InnerText = CacheSecureData.OptionalPassword;
		}
		else
		{
			xmlNode.AppendChild(XML.CreateElement("FileID")).InnerText = Criptografia.ToInsecureString(_FileID);
		}
		xmlNode.AppendChild(XML.CreateElement("NombreFichero")).InnerText = NombreFichero;
		xmlNode.AppendChild(XML.CreateElement("RutaLocal")).InnerText = RutaLocal;
		xmlNode.AppendChild(XML.CreateElement("RutaRelativa")).InnerText = RutaRelativa;
		xmlNode.AppendChild(XML.CreateElement("TamanoBytes")).InnerText = TamanoBytes.ToString();
		xmlNode.AppendChild(XML.CreateElement("NumeroConexionesAbiertas")).InnerText = NumeroConexionesAbiertas.ToString();
		xmlNode.AppendChild(XML.CreateElement("NumeroChunksAsignados")).InnerText = NumeroChunksAsignados.ToString();
		if (FechaUltimoError.HasValue)
		{
			xmlNode.AppendChild(XML.CreateElement("FechaUltimoError")).InnerText = FechaUltimoError.Value.ToString("s");
		}
		xmlNode.AppendChild(XML.CreateElement("Porcentaje")).InnerText = Porcentaje.ToString();
		xmlNode.AppendChild(XML.CreateElement("DescargaComenzada")).InnerText = DescargaComenzada.ToString();
		xmlNode.AppendChild(XML.CreateElement("DescargaProcesada")).InnerText = DescargaProcesada.ToString();
		xmlNode.AppendChild(XML.CreateElement("ExtraccionFicheroAutomatica")).InnerText = ExtraccionFicheroAutomatica.ToString();
		if (!string.IsNullOrEmpty(ExtraccionFicheroPassword))
		{
			xmlNode.AppendChild(XML.CreateElement("ExtraccionFicheroPassword")).InnerText = Criptografia.AES_EncryptString(ExtraccionFicheroPassword, "passZIP");
		}
		xmlNode.AppendChild(XML.CreateElement("Prioridad")).InnerText = Prioridad.ToString();
		xmlNode.AppendChild(XML.CreateElement("VelocidadKBs")).InnerText = VelocidadKBs.ToString();
		xmlNode.AppendChild(XML.CreateElement("BytesDescargados")).InnerText = BytesDescargados.ToString();
		xmlNode.AppendChild(XML.CreateElement("EstadoDescarga")).InnerText = Enum.GetName(typeof(Estado), EstadoDescarga);
		xmlNode.AppendChild(XML.CreateElement("MarcadoParaBorrarFicheroLocal")).InnerText = MarcadoParaBorrarFicheroLocal.ToString();
		xmlNode.AppendChild(XML.CreateElement("TiempoEstimadoDescarga")).InnerText = TiempoEstimadoDescarga;
		xmlNode.AppendChild(XML.CreateElement("PausaIndividual")).InnerText = PausaIndividual.ToString();
		xmlNode.AppendChild(XML.CreateElement("DescargaIndividual")).InnerText = DescargaIndividual.ToString();
		xmlNode.AppendChild(XML.CreateElement("LimiteVelocidad")).InnerText = LimiteVelocidad.ToString();
		if (DatosPartes != null)
		{
			XmlNode xmlNode2 = xmlNode.AppendChild(XML.CreateElement("DatosPartes"));
			xmlNode2.AppendChild(XML.CreateElement("AllFinished")).InnerText = DatosPartes.AllFinished.ToString();
			if (DatosPartes.ChunkList != null)
			{
				XmlNode xmlNode3 = xmlNode2.AppendChild(XML.CreateElement("ChunkList"));
				foreach (FileDownloader.DataPart.Chunk chunk in DatosPartes.ChunkList)
				{
					XmlNode xmlNode4 = xmlNode3.AppendChild(XML.CreateElement("Chunk"));
					xmlNode4.AppendChild(XML.CreateElement("StartIndex")).InnerText = chunk.StartIndex.ToString();
					xmlNode4.AppendChild(XML.CreateElement("Size")).InnerText = chunk.Size.ToString();
					xmlNode4.AppendChild(XML.CreateElement("Index")).InnerText = chunk.Index.ToString();
					xmlNode4.AppendChild(XML.CreateElement("Available")).InnerText = chunk.Available.ToString();
				}
			}
		}
		return xmlNode;
	}

	private static string LeerNodo(ref XmlNode NodoXML, ref string Path, string ValorDefecto)
	{
		XmlNode xmlNode = NodoXML.SelectSingleNode(Path);
		if (xmlNode == null)
		{
			return ValorDefecto;
		}
		return xmlNode.InnerText;
	}
}
