using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using SharpCompress.PriorityExtension;

namespace MegaDownloader;

public class Configuracion
{
	public enum ErrorConfigClass
	{
		SinErrores,
		Fichero_No_Existe,
		Fichero_No_Valido,
		Usuario_Password_Incorrecto,
		Fichero_No_Creado
	}

	public ConfiguracionUI ConfigUI;

	public string Idioma;

	public bool CondicionesAceptadas;

	public string VersionConfig;

	public ErrorConfigClass ErrorConfig;

	public string RutaDefecto;

	public bool ExtraerAutomaticamente;

	public bool CrearDirectorioPaquete;

	public bool AnalizarPortapapeles;

	public int TamanoPaqueteKB;

	public int TamanoBufferKB;

	public int MaxConexionesGuardadas;

	public int ConexionesPorFichero;

	public int DescargasSimultaneas;

	public bool ResetearErrores;

	public bool UsarProxy;

	public bool ApagarPC;

	public bool CheckUpdates;

	public bool ComenzarDescargando;

	public bool MantenerUltimaConfiguracion;

	public bool HideCollaborateButton;

	public string ProxyIP;

	public string ProxyUser;

	public string ProxyPassword;

	public int ProxyPort;

	public int ResetearErroresPeriodoMinutos;

	public int LimiteVelocidadKBs;

	public bool IniciarConWindows;

	public Log.LevelLogType NivelLog;

	public Priority.PriorityType PrioridadDescompresion;

	public bool ServidorStreamingActivo;

	public int ServidorStreamingPuerto;

	private const int DEFAULT_STREAMING_PORT = 54321;

	public string ServidorStreamingPassword;

	public bool ServidorWebActivo;

	public string ServidorWebNombre;

	public string ServidorWebRutaPlantilla;

	public int ServidorWebPuerto;

	public string ServidorWebPassword;

	public int ServidorWebTimeout;

	public string VLCPath;

	public List<SecureString> ListaPreSharedKeys;

	private SecureString _Usuario;

	private SecureString _Password;

	private List<ELCAccountHelper.Account> _ELCAccountList;

	private const string KeyPassword = "A9G7dHUprtNmNEBLEDhFneBAcyRTZdd5RuAzYQKc3qJ4BaVH";

	private static string _LastSavedXML = null;

	public string Usuario
	{
		get
		{
			return Criptografia.ToInsecureString(_Usuario);
		}
		set
		{
			_Usuario = Criptografia.ToSecureString(value);
		}
	}

	public string Password
	{
		get
		{
			return Criptografia.ToInsecureString(_Password);
		}
		set
		{
			_Password = Criptografia.ToSecureString(value);
		}
	}

	public List<ELCAccountHelper.Account> ELCAccounts
	{
		get
		{
			return _ELCAccountList;
		}
		set
		{
			_ELCAccountList = value;
		}
	}

	public Configuracion()
	{
		ErrorConfig = ErrorConfigClass.SinErrores;
		ConfigUI = new ConfiguracionUI();
		CargaXML();
		Conexion.SetProxy(this);
		ThrottledStreamController.GetController().SetMaxGlobalSpeed(LimiteVelocidadKBs);
	}

	public void GuardarXML(bool ForzarGuardado)
	{
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		XmlDocument XML = new XmlDocument();
		XML.AppendChild(XML.CreateElement("Configuration"));
		XML.DocumentElement.AppendChild(XML.CreateElement("Language")).InnerText = Idioma;
		XML.DocumentElement.AppendChild(XML.CreateElement("RutaDefecto")).InnerText = RutaDefecto;
		XML.DocumentElement.AppendChild(XML.CreateElement("CondicionesAceptadas")).InnerText = CondicionesAceptadas.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("VersionConfig")).InnerText = VersionConfig;
		XML.DocumentElement.AppendChild(XML.CreateElement("ExtraerAutomaticamente")).InnerText = ExtraerAutomaticamente.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("CrearDirectorioPaquete")).InnerText = CrearDirectorioPaquete.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("AnalizarPortapapeles")).InnerText = AnalizarPortapapeles.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("TamanoPaqueteKB")).InnerText = TamanoPaqueteKB.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("TamanoBufferKB")).InnerText = TamanoBufferKB.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("DescargasSimultaneas")).InnerText = DescargasSimultaneas.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ConexionesPorFichero")).InnerText = ConexionesPorFichero.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ResetearErrores")).InnerText = ResetearErrores.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ComenzarDescargando")).InnerText = ComenzarDescargando.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("CheckUpdates")).InnerText = CheckUpdates.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("MantenerUltimaConfiguracion")).InnerText = MantenerUltimaConfiguracion.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("UsarProxy")).InnerText = UsarProxy.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ProxyPort")).InnerText = ProxyPort.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ProxyIP")).InnerText = ProxyIP;
		XML.DocumentElement.AppendChild(XML.CreateElement("ProxyUser")).InnerText = ProxyUser;
		XML.DocumentElement.AppendChild(XML.CreateElement("ProxyPassword")).InnerText = ProxyPassword;
		XML.DocumentElement.AppendChild(XML.CreateElement("VLCPath")).InnerText = VLCPath;
		XML.DocumentElement.AppendChild(XML.CreateElement("ResetearErroresPeriodoMinutos")).InnerText = ResetearErroresPeriodoMinutos.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("NivelLog")).InnerText = Enum.GetName(typeof(Log.LevelLogType), NivelLog);
		XML.DocumentElement.AppendChild(XML.CreateElement("PrioridadDescompresion")).InnerText = Enum.GetName(typeof(Priority.PriorityType), PrioridadDescompresion);
		XML.DocumentElement.AppendChild(XML.CreateElement("LimiteVelocidadKBs")).InnerText = LimiteVelocidadKBs.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("IniciarConWindows")).InnerText = IniciarConWindows.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorStreamingActivo")).InnerText = ServidorStreamingActivo.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorStreamingPuerto")).InnerText = ServidorStreamingPuerto.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorStreamingPassword")).InnerText = ServidorStreamingPassword;
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorWebActivo")).InnerText = ServidorWebActivo.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorWebNombre")).InnerText = ServidorWebNombre;
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorWebRutaPlantilla")).InnerText = ServidorWebRutaPlantilla;
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorWebPassword")).InnerText = Criptografia.AES_EncryptString(ServidorWebPassword, "A9G7dHUprtNmNEBLEDhFneBAcyRTZdd5RuAzYQKc3qJ4BaVH");
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorWebTimeout")).InnerText = ServidorWebTimeout.ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("ServidorWebPuerto")).InnerText = ServidorWebPuerto.ToString();
		if (HideCollaborateButton)
		{
			XML.DocumentElement.AppendChild(XML.CreateElement("HideCollaborateButton")).InnerText = HideCollaborateButton.ToString();
		}
		ConfigUI.GuardarXML(ref XML);
		string text = ObtenerRutaFicheroConfiguracion();
		if (!(_LastSavedXML == null || Operators.CompareString(_LastSavedXML, XML.DocumentElement.OuterXml.GetHashCode().ToString(), TextCompare: false) != 0 || ForzarGuardado))
		{
			return;
		}
		_LastSavedXML = XML.DocumentElement.OuterXml.GetHashCode().ToString();
		XML.DocumentElement.AppendChild(XML.CreateElement("Usuario")).InnerText = Criptografia.EncryptString_DPAPI(_Usuario);
		XML.DocumentElement.AppendChild(XML.CreateElement("Password")).InnerText = Criptografia.EncryptString_DPAPI(_Password);
		XML.DocumentElement.AppendChild(SavePreSharedKeys(ref XML));
		XmlNode xmlNode = XML.DocumentElement.AppendChild(XML.CreateElement("ELCAccounts"));
		foreach (ELCAccountHelper.Account eLCAccount in ELCAccounts)
		{
			XmlNode xmlNode2 = xmlNode.AppendChild(XML.CreateElement("Account"));
			xmlNode2.AppendChild(XML.CreateElement("Name")).InnerText = eLCAccount.Alias;
			xmlNode2.AppendChild(XML.CreateElement("URL")).InnerText = eLCAccount.URL;
			xmlNode2.AppendChild(XML.CreateElement("User")).InnerText = Criptografia.EncryptString_DPAPI(eLCAccount.User);
			xmlNode2.AppendChild(XML.CreateElement("Key")).InnerText = Criptografia.EncryptString_DPAPI(eLCAccount.Key);
			xmlNode2.AppendChild(XML.CreateElement("Default")).InnerText = (eLCAccount.DefaultAccount ? "1" : "0");
		}
		Log.WriteDebug("Saving configuration");
		Mutex.GuardarConfig.WaitOne();
		try
		{
			if (File.Exists(text + ".bak"))
			{
				File.Delete(text + ".bak");
			}
			File.Move(text, text + ".bak");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		try
		{
			XML.Save(text);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteError("Error saving configuration XML: " + ex4.ToString());
			ErrorConfig = ErrorConfigClass.Fichero_No_Creado;
			ProjectData.ClearProjectError();
		}
		finally
		{
			Mutex.GuardarConfig.ReleaseMutex();
		}
	}

	public XmlElement SavePreSharedKeys(ref XmlDocument XmlDoc)
	{
		XmlElement xmlElement = XmlDoc.CreateElement("PreSharedKeys");
		foreach (SecureString listaPreSharedKey in ListaPreSharedKeys)
		{
			xmlElement.AppendChild(XmlDoc.CreateElement("Key")).InnerText = Criptografia.EncryptString_DPAPI(listaPreSharedKey);
		}
		return xmlElement;
	}

	public void CargaXML()
	{
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		string text = ObtenerRutaFicheroConfiguracion();
		if (!File.Exists(text))
		{
			Log.WriteWarning("Configuration file does not exist");
			ErrorConfig = ErrorConfigClass.Fichero_No_Existe;
			ConfiguracionDefectoVacia();
			return;
		}
		Log.WriteDebug("Loading configuration XML");
		XmlDocument DocumentoXML = new XmlDocument();
		Mutex.GuardarConfig.WaitOne();
		try
		{
			DocumentoXML.Load(text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorConfig = ErrorConfigClass.Fichero_No_Valido;
			ConfiguracionDefectoVacia();
			Log.WriteError("Configuration file could not be loaded: " + ex2.ToString());
			ProjectData.ClearProjectError();
			return;
		}
		finally
		{
			Mutex.GuardarConfig.ReleaseMutex();
		}
		string Path = "Language";
		Idioma = LeerNodo(ref DocumentoXML, ref Path, "");
		try
		{
			Idioma = CultureInfo.GetCultureInfo(Idioma).Name;
			if (string.IsNullOrEmpty(Idioma))
			{
				throw new ApplicationException("Empty culture");
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Idioma = Thread.CurrentThread.CurrentUICulture.Name;
			ProjectData.ClearProjectError();
		}
		Path = "VersionConfig";
		VersionConfig = LeerNodo(ref DocumentoXML, ref Path, "0");
		Path = "RutaDefecto";
		RutaDefecto = LeerNodo(ref DocumentoXML, ref Path, "");
		Path = "ProxyIP";
		ProxyIP = LeerNodo(ref DocumentoXML, ref Path, "");
		Path = "ProxyUser";
		ProxyUser = LeerNodo(ref DocumentoXML, ref Path, "");
		Path = "ProxyPassword";
		ProxyPassword = LeerNodo(ref DocumentoXML, ref Path, "");
		Path = "VLCPath";
		VLCPath = LeerNodo(ref DocumentoXML, ref Path, "");
		Path = "Usuario";
		_Usuario = Criptografia.DecryptString_DPAPI(LeerNodo(ref DocumentoXML, ref Path, ""));
		Path = "Password";
		_Password = Criptografia.DecryptString_DPAPI(LeerNodo(ref DocumentoXML, ref Path, ""));
		ExtraerAutomaticamente = false;
		CrearDirectorioPaquete = false;
		AnalizarPortapapeles = false;
		ResetearErrores = false;
		UsarProxy = false;
		ApagarPC = false;
		ComenzarDescargando = true;
		IniciarConWindows = false;
		MantenerUltimaConfiguracion = true;
		HideCollaborateButton = false;
		CheckUpdates = true;
		Path = "CheckUpdates";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "true"), out CheckUpdates);
		Path = "HideCollaborateButton";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out HideCollaborateButton);
		Path = "ExtraerAutomaticamente";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out ExtraerAutomaticamente);
		Path = "CondicionesAceptadas";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out CondicionesAceptadas);
		Path = "CrearDirectorioPaquete";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out CrearDirectorioPaquete);
		Path = "AnalizarPortapapeles";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out AnalizarPortapapeles);
		Path = "ResetearErrores";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out ResetearErrores);
		Path = "UsarProxy";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out UsarProxy);
		Path = "IniciarConWindows";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out IniciarConWindows);
		Path = "MantenerUltimaConfiguracion";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "true"), out MantenerUltimaConfiguracion);
		Path = "ComenzarDescargando";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "true"), out ComenzarDescargando);
		TamanoPaqueteKB = 50;
		TamanoBufferKB = 750;
		MaxConexionesGuardadas = 100;
		ResetearErroresPeriodoMinutos = 15;
		ProxyPort = 0;
		LimiteVelocidadKBs = 0;
		Path = "TamanoPaqueteKB";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "50"), out TamanoPaqueteKB);
		Path = "TamanoBufferKB";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "750"), out TamanoBufferKB);
		Path = "ProxyPort";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "0"), out ProxyPort);
		Path = "LimiteVelocidadKBs";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "0"), out LimiteVelocidadKBs);
		Path = "ResetearErroresPeriodoMinutos";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "15"), out ResetearErroresPeriodoMinutos);
		if ((ResetearErroresPeriodoMinutos < 1) | (ResetearErroresPeriodoMinutos > 999))
		{
			ResetearErroresPeriodoMinutos = 15;
		}
		if (LimiteVelocidadKBs < 0)
		{
			LimiteVelocidadKBs = 0;
		}
		if (TamanoPaqueteKB < 1)
		{
			TamanoPaqueteKB = 50;
		}
		if (TamanoBufferKB < 1)
		{
			TamanoBufferKB = 750;
		}
		NivelLog = Log.LevelLogType.Normal;
		Type typeFromHandle = typeof(Log.LevelLogType);
		Path = "NivelLog";
		if (Enum.IsDefined(typeFromHandle, LeerNodo(ref DocumentoXML, ref Path, "")))
		{
			Type typeFromHandle2 = typeof(Log.LevelLogType);
			Path = "NivelLog";
			NivelLog = (Log.LevelLogType)Conversions.ToInteger(Enum.Parse(typeFromHandle2, LeerNodo(ref DocumentoXML, ref Path, "")));
		}
		PrioridadDescompresion = (Priority.PriorityType)0;
		Type typeFromHandle3 = typeof(Priority.PriorityType);
		Path = "PrioridadDescompresion";
		if (Enum.IsDefined(typeFromHandle3, LeerNodo(ref DocumentoXML, ref Path, "")))
		{
			Type typeFromHandle4 = typeof(Priority.PriorityType);
			Path = "PrioridadDescompresion";
			PrioridadDescompresion = (Priority.PriorityType)Conversions.ToInteger(Enum.Parse(typeFromHandle4, LeerNodo(ref DocumentoXML, ref Path, "")));
		}
		DescargasSimultaneas = 3;
		ConexionesPorFichero = 3;
		Path = "DescargasSimultaneas";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "3"), out DescargasSimultaneas);
		Path = "ConexionesPorFichero";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "3"), out ConexionesPorFichero);
		if (DescargasSimultaneas < 1)
		{
			DescargasSimultaneas = 3;
		}
		if (ConexionesPorFichero < 1)
		{
			ConexionesPorFichero = 3;
		}
		ServidorStreamingActivo = false;
		Path = "ServidorStreamingActivo";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out ServidorStreamingActivo);
		ServidorStreamingPuerto = 54321;
		Path = "ServidorStreamingPuerto";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, 54321.ToString()), out ServidorStreamingPuerto);
		Path = "ServidorStreamingPassword";
		ServidorStreamingPassword = LeerNodo(ref DocumentoXML, ref Path, "");
		ServidorWebActivo = false;
		Path = "ServidorWebActivo";
		bool.TryParse(LeerNodo(ref DocumentoXML, ref Path, "false"), out ServidorWebActivo);
		Path = "ServidorWebNombre";
		ServidorWebNombre = LeerNodo(ref DocumentoXML, ref Path, "");
		Path = "ServidorWebRutaPlantilla";
		ServidorWebRutaPlantilla = LeerNodo(ref DocumentoXML, ref Path, "");
		Path = "ServidorWebPassword";
		ServidorWebPassword = LeerNodo(ref DocumentoXML, ref Path, "");
		try
		{
			if (!string.IsNullOrEmpty(ServidorWebPassword))
			{
				ServidorWebPassword = Criptografia.AES_DecryptString(ServidorWebPassword, "A9G7dHUprtNmNEBLEDhFneBAcyRTZdd5RuAzYQKc3qJ4BaVH");
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ProjectData.ClearProjectError();
		}
		ServidorWebTimeout = 5;
		Path = "ServidorWebTimeout";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "5"), out ServidorWebTimeout);
		ServidorWebPuerto = 0;
		Path = "ServidorWebPuerto";
		int.TryParse(LeerNodo(ref DocumentoXML, ref Path, "0"), out ServidorWebPuerto);
		ListaPreSharedKeys = new List<SecureString>();
		foreach (XmlNode item in DocumentoXML.DocumentElement.SelectNodes("PreSharedKeys/Key"))
		{
			ListaPreSharedKeys.Add(Criptografia.DecryptString_DPAPI(item.InnerText));
		}
		_ = (_Usuario.Length == 0) | (_Password.Length == 0);
		if (ConexionesPorFichero == 0)
		{
			ErrorConfig = ErrorConfigClass.Fichero_No_Valido;
		}
		_ELCAccountList = new List<ELCAccountHelper.Account>();
		foreach (XmlNode item2 in DocumentoXML.DocumentElement.SelectNodes("ELCAccounts/Account"))
		{
			XmlNode NodoXML = item2;
			ELCAccountHelper.Account account = new ELCAccountHelper.Account();
			Path = "User";
			account.User = Criptografia.DecryptString_DPAPI(LeerNodo(ref NodoXML, ref Path, ""));
			Path = "Key";
			account.Key = Criptografia.DecryptString_DPAPI(LeerNodo(ref NodoXML, ref Path, ""));
			Path = "URL";
			account.URL = LeerNodo(ref NodoXML, ref Path, "");
			Path = "Name";
			account.Alias = LeerNodo(ref NodoXML, ref Path, "");
			if (string.IsNullOrEmpty(account.Alias))
			{
				account.Alias = account.URL;
			}
			Path = "Default";
			account.DefaultAccount = Operators.CompareString(LeerNodo(ref NodoXML, ref Path, ""), "1", TextCompare: false) == 0;
			_ELCAccountList.Add(account);
		}
		ConfigUI.CargarXML(DocumentoXML);
	}

	public void ConfiguracionDefectoVacia()
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		RutaDefecto = "";
		Idioma = Thread.CurrentThread.CurrentUICulture.Name;
		ExtraerAutomaticamente = false;
		CondicionesAceptadas = false;
		CrearDirectorioPaquete = true;
		AnalizarPortapapeles = true;
		HideCollaborateButton = false;
		ApagarPC = false;
		UsarProxy = false;
		ComenzarDescargando = true;
		CheckUpdates = true;
		ProxyPort = 0;
		VersionConfig = "0";
		DescargasSimultaneas = 3;
		ConexionesPorFichero = 3;
		ProxyIP = "";
		ServidorWebTimeout = 5;
		MaxConexionesGuardadas = 100;
		NivelLog = Log.LevelLogType.Normal;
		ServidorStreamingActivo = false;
		ServidorWebActivo = false;
		ServidorStreamingPuerto = 54321;
		PrioridadDescompresion = (Priority.PriorityType)0;
		_Usuario = Criptografia.ToSecureString("");
		_Password = Criptografia.ToSecureString("");
		ListaPreSharedKeys = new List<SecureString>();
		TamanoPaqueteKB = 50;
		TamanoBufferKB = 750;
		_ELCAccountList = new List<ELCAccountHelper.Account>();
		ConfigUI.ConfiguracionDefectoVacia();
	}

	public static void RegisterInStartup(bool isChecked)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
			if (registryKey == null && isChecked)
			{
				registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
			}
			if (isChecked)
			{
				registryKey.SetValue("MegaDownloader", "\"" + Application.ExecutablePath + "\" -silent");
			}
			else
			{
				registryKey.DeleteValue("MegaDownloader", throwOnMissingValue: false);
			}
		}
		catch (UnauthorizedAccessException ex)
		{
			ProjectData.SetProjectError(ex);
			UnauthorizedAccessException ex2 = ex;
			Log.WriteError("SECURITY ERROR: Not enough privileges to access the registry (CU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run). Execute the application with administrator privileges (at least one time) in order to access the registry. Please note that if you move the application, you will have to execute it again with administrator privileges.");
			ProjectData.ClearProjectError();
		}
		catch (SecurityException ex3)
		{
			ProjectData.SetProjectError(ex3);
			SecurityException ex4 = ex3;
			Log.WriteError("SECURITY ERROR: Not enough privileges to access the registry (CU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run). Execute the application with administrator privileges (at least one time) in order to access the registry. Please note that if you move the application, you will have to execute it again with administrator privileges.");
			ProjectData.ClearProjectError();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			Log.WriteError("Error accessing the registry (CU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run). Error: " + ex6.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private string LeerNodo(ref XmlDocument DocumentoXML, ref string Path, string ValorDefecto)
	{
		XmlNode xmlNode = DocumentoXML.DocumentElement.SelectSingleNode(Path);
		if (xmlNode == null)
		{
			return ValorDefecto;
		}
		return xmlNode.InnerText;
	}

	private string LeerNodo(ref XmlNode NodoXML, ref string Path, string ValorDefecto)
	{
		XmlNode xmlNode = NodoXML.SelectSingleNode(Path);
		if (xmlNode == null)
		{
			return ValorDefecto;
		}
		return xmlNode.InnerText;
	}

	private static string ObtenerRutaFicheroConfiguracion()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Config");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return Path.Combine(text, "Configuration.xml");
	}
}
