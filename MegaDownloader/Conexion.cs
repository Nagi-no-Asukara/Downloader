using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

using System.Xml;
using MegaDownloader.Crypters;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace MegaDownloader;

public class Conexion
{
	public enum TipoError
	{
		SinErrores,
		UsuarioInvalido,
		ErrorConexion,
		Otros
	}

	public class InformacionFichero
	{
		public string URL;

		public string FileID;

		public string FileKey;

		public string Nombre;

		public string MD5;

		public long Tamano;

		public TipoError Err;

		public string Errtxt;

		public InformacionFichero()
		{
			Err = TipoError.SinErrores;
		}
	}

	internal class Respuesta
	{
		public HttpStatusCode Status;

		public string Mensaje;

		public Exception Excepcion;

		public string Cookies;
	}

	private static bool useGlobalCDN = true;

	private static bool _UsarProxy = false;

	private static string _ProxyIP;

	private static string _ProxyUser;

	private static string _ProxyPassword;

	private static int _ProxyPort;

	private const string keyUrl = "81379874BC2815E6825E98F986F98410EFC68D6DABC6EF8B54968C75387551F2";

	internal const string patternGetFileName = "MEGA.*?\"n\"\\s*:\\s*\"(?<FileName>.*?)\"";

	[CompilerGenerated]
	[AccessedThroughProperty("bgPing")]
	private static BackgroundWorker _bgPing;

	[CompilerGenerated]
	[AccessedThroughProperty("bgPingNewVersion")]
	private static BackgroundWorker _bgPingNewVersion;

	[CompilerGenerated]
	[AccessedThroughProperty("bgPingNewUser")]
	private static BackgroundWorker _bgPingNewUser;

	private static BackgroundWorker bgPing
	{
		[CompilerGenerated]
		get
		{
			return _bgPing;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgPing_DoWork;
			BackgroundWorker backgroundWorker = _bgPing;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
			}
			_bgPing = value;
			backgroundWorker = _bgPing;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
			}
		}
	}

	private static BackgroundWorker bgPingNewVersion
	{
		[CompilerGenerated]
		get
		{
			return _bgPingNewVersion;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgPingNewVersion_DoWork;
			BackgroundWorker backgroundWorker = _bgPingNewVersion;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
			}
			_bgPingNewVersion = value;
			backgroundWorker = _bgPingNewVersion;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
			}
		}
	}

	private static BackgroundWorker bgPingNewUser
	{
		[CompilerGenerated]
		get
		{
			return _bgPingNewUser;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgPingNewUser_DoWork;
			BackgroundWorker backgroundWorker = _bgPingNewUser;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
			}
			_bgPingNewUser = value;
			backgroundWorker = _bgPingNewUser;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
			}
		}
	}

	public static void SetProxy(Configuracion Config)
	{
		_UsarProxy = Config.UsarProxy;
		_ProxyIP = Config.ProxyIP;
		_ProxyPort = Config.ProxyPort;
		_ProxyUser = _ProxyUser;
		_ProxyPassword = _ProxyPassword;
	}

	public static HttpWebRequest CreateHttpWebRequest(string Url)
	{
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		ServicePointManager.DefaultConnectionLimit = 10000;
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
		if (_UsarProxy)
		{
			WebProxy webProxy = new WebProxy(_ProxyIP, _ProxyPort);
			if (!string.IsNullOrEmpty(_ProxyUser))
			{
				webProxy.Credentials = new NetworkCredential(_ProxyUser, _ProxyPassword);
			}
			httpWebRequest.Proxy = webProxy;
		}
		ServicePointManager.ServerCertificateValidationCallback = CertificationAccept;
		return httpWebRequest;
	}

	public static bool CertificationAccept(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		if (((HttpWebRequest)sender).RequestUri.ToString().Contains("linkcrypter.net"))
		{
			return true;
		}
		return sslPolicyErrors == SslPolicyErrors.None;
	}

	public static string Get_MEGA_API_Url(string Session)
	{
		string text;
		if (string.IsNullOrEmpty(Session))
		{
			text = InternalConfiguration.ObtenerValueFromInternalConfig(useGlobalCDN ? "URL_MEGA_API_NOSESION_G" : "URL_MEGA_API_NOSESION_EU");
			if (!text.ToUpper().StartsWith("HTTP"))
			{
				text = Criptografia.AES_DecryptString(text, "81379874BC2815E6825E98F986F98410EFC68D6DABC6EF8B54968C75387551F2");
			}
		}
		else
		{
			text = InternalConfiguration.ObtenerValueFromInternalConfig(useGlobalCDN ? "URL_MEGA_API_SESION_G" : "URL_MEGA_API_SESION_EU");
			if (!text.ToUpper().StartsWith("HTTP"))
			{
				text = Criptografia.AES_DecryptString(text, "81379874BC2815E6825E98F986F98410EFC68D6DABC6EF8B54968C75387551F2");
			}
			text = text.Replace("%SESSION%", Session);
		}
		return text.Replace("%SEQ%", TimeSpan.FromMilliseconds(DateTime.Now.Millisecond).Ticks.ToString());
	}

	internal static Respuesta SendJSON(string URL, string JSON, string ContentType = "", bool SendAppId = true)
	{
		HttpWebRequest httpWebRequest = CreateHttpWebRequest(URL);
		HttpWebResponse httpWebResponse = null;
		httpWebRequest.Method = "POST";
		byte[] bytes = Encoding.UTF8.GetBytes(JSON);
		httpWebRequest.ContentLength = bytes.Length;
		if (!string.IsNullOrEmpty(ContentType))
		{
			httpWebRequest.ContentType = ContentType;
		}
		StreamReader streamReader = null;
		Respuesta respuesta = new Respuesta();
		respuesta.Status = HttpStatusCode.Unused;
		respuesta.Excepcion = null;
		respuesta.Mensaje = "";
		try
		{
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			respuesta.Mensaje = streamReader.ReadToEnd();
			respuesta.Status = httpWebResponse.StatusCode;
			respuesta.Cookies = httpWebResponse.Headers["Set-Cookie"];
		}
		catch (WebException ex)
		{
			ProjectData.SetProjectError(ex);
			WebException ex2 = ex;
			try
			{
				if (ex2.Response != null)
				{
					respuesta.Status = ((HttpWebResponse)ex2.Response).StatusCode;
					using Stream stream2 = ex2.Response.GetResponseStream();
					using StreamReader streamReader2 = new StreamReader(stream2);
					respuesta.Mensaje = streamReader2.ReadToEnd();
				}
			}
			catch (WebException ex3)
			{
				ProjectData.SetProjectError(ex3);
				WebException ex4 = ex3;
				ProjectData.ClearProjectError();
			}
			Log.WriteError("Error accessing the URL: " + ex2.ToString() + " - Message received: " + respuesta.Mensaje);
			respuesta.Excepcion = ex2;
			ProjectData.ClearProjectError();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			Log.WriteError("Error accessing the URL: " + ex6.ToString());
			respuesta.Excepcion = ex6;
			ProjectData.ClearProjectError();
		}
		finally
		{
			httpWebResponse?.Close();
			streamReader?.Close();
		}
		return respuesta;
	}

	internal static Respuesta SendPOST(string URL, NameValueCollection PostParameters, string ContentType = "application/x-www-form-urlencoded", bool SendAppId = true)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object key in PostParameters.Keys)
		{
			string text = Conversions.ToString(key);
			string str = PostParameters[text];
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append("&");
			}
			stringBuilder.Append(Uri.EscapeDataString(text));
			stringBuilder.Append("=");
			stringBuilder.Append(Uri.EscapeDataString(str));
		}
		if (stringBuilder.Length == 0)
		{
			throw new ArgumentException("No POST parameters found");
		}
		return SendJSON(URL, stringBuilder.ToString(), ContentType, SendAppId);
	}

	internal static string ObtenerUrlDesdeAcortador(string URL)
	{
		HttpWebResponse httpWebResponse = null;
		string result;
		try
		{
			httpWebResponse = (HttpWebResponse)CreateHttpWebRequest(URL).GetResponse();
			result = httpWebResponse.ResponseUri.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = string.Empty;
			ProjectData.ClearProjectError();
		}
		finally
		{
			httpWebResponse?.Close();
		}
		return result;
	}

	internal static Respuesta LeerURL(string URL, Encoding encoding = null, string userAgent = null, string referer = null, NameValueCollection Headers = null)
	{
		HttpWebRequest httpWebRequest = null;
		HttpWebResponse httpWebResponse = null;
		StreamReader streamReader = null;
		Respuesta respuesta = new Respuesta();
		respuesta.Status = HttpStatusCode.Unused;
		respuesta.Excepcion = null;
		respuesta.Mensaje = "";
		try
		{
			httpWebRequest = CreateHttpWebRequest(URL);
			if (Headers != null)
			{
				string[] allKeys = Headers.AllKeys;
				foreach (string name in allKeys)
				{
					httpWebRequest.Headers.Add(name, Headers[name]);
				}
			}
			if (!string.IsNullOrEmpty(referer))
			{
				httpWebRequest.Referer = referer;
			}
			if (!string.IsNullOrEmpty(userAgent))
			{
				httpWebRequest.UserAgent = userAgent;
			}
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Encoding encoding2 = encoding;
			if (encoding2 == null)
			{
				encoding2 = Encoding.GetEncoding("utf-8");
			}
			streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding2);
			respuesta.Mensaje = streamReader.ReadToEnd();
			respuesta.Status = httpWebResponse.StatusCode;
		}
		catch (WebException ex)
		{
			ProjectData.SetProjectError(ex);
			WebException ex2 = ex;
			try
			{
				if (ex2.Response != null)
				{
					respuesta.Status = ((HttpWebResponse)ex2.Response).StatusCode;
					using Stream stream = ex2.Response.GetResponseStream();
					Encoding encoding3 = encoding;
					if (encoding3 == null)
					{
						encoding3 = Encoding.GetEncoding("utf-8");
					}
					using StreamReader streamReader2 = new StreamReader(stream, encoding3);
					respuesta.Mensaje = streamReader2.ReadToEnd();
				}
			}
			catch (WebException ex3)
			{
				ProjectData.SetProjectError(ex3);
				WebException ex4 = ex3;
				ProjectData.ClearProjectError();
			}
			Log.WriteError("Error accessing the URL: " + ex2.ToString() + " - Message received: " + respuesta.Mensaje);
			respuesta.Excepcion = ex2;
			ProjectData.ClearProjectError();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			Log.WriteError("Error accessing the URL: " + ex6.ToString());
			respuesta.Excepcion = ex6;
			ProjectData.ClearProjectError();
		}
		finally
		{
			httpWebResponse?.Close();
			streamReader?.Close();
		}
		return respuesta;
	}

	public static string GetUpdateCheckURL()
	{
		return Criptografia.AES_DecryptString(InternalConfiguration.ObtenerValueFromInternalConfig("URL_UPDATE_CHECK"), "81379874BC2815E6825E98F986F98410EFC68D6DABC6EF8B54968C75387551F2").Replace("%D%", DateTime.UtcNow.ToString("yyyyMMddHH"));
	}

	private static string TratarUsuario(string Usuario)
	{
		return Uri.EscapeUriString(Usuario ?? "");
	}

	public static InformacionFichero ObtenerInformacionFichero(Configuracion Config, string FileID, string FileKey, bool ComprobacionAntesDescarga)
	{
		InformacionFichero result;
		checked
		{
			if (MegaCrypter.IsMegaCrypter(FileID))
			{
				result = MegaCrypter.ObtenerInformacionFichero(Config, FileID, FileKey, ComprobacionAntesDescarga);
			}
			else if (YouPaste.IsYouPaste(FileID))
			{
				result = YouPaste.ObtenerInformacionFichero(Config, FileID, FileKey, ComprobacionAntesDescarga);
			}
			else if (EncrypterMega.IsEncrypterMega(FileID))
			{
				result = EncrypterMega.ObtenerInformacionFichero(Config, FileID, FileKey, ComprobacionAntesDescarga);
			}
			else if (LinkCrypter.IsLinkCrypter(FileID))
			{
				result = LinkCrypter.ObtenerInformacionFichero(Config, FileID, FileKey, ComprobacionAntesDescarga);
			}
			else
			{
				InformacionFichero informacionFichero = new InformacionFichero();
				try
				{
					URLExtractor.CheckFileIDAndFileKey(ref FileID, ref FileKey);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					informacionFichero.Err = TipoError.Otros;
					if (ex2 is ArgumentOutOfRangeException)
					{
						informacionFichero.Errtxt = "Error getting ID and File Key: the provided link seems to be incomplete";
					}
					else
					{
						informacionFichero.Errtxt = "Error getting ID and File Key: " + ex2.Message;
					}
					Log.WriteError("Error getting ID and File Key: " + ex2.ToString());
					result = informacionFichero;
					ProjectData.ClearProjectError();
					goto IL_06b2;
				}
				informacionFichero.FileID = FileID;
				informacionFichero.FileKey = FileKey;
				string text = InternalConfiguration.ObtenerValueFromInternalConfig(useGlobalCDN ? "URL_MEGA_API_DOWN_GET_G" : "URL_MEGA_API_DOWN_GET_EU");
				if (!text.ToUpper().StartsWith("HTTP"))
				{
					text = Criptografia.AES_DecryptString(text, "81379874BC2815E6825E98F986F98410EFC68D6DABC6EF8B54968C75387551F2");
				}
				text = text.Replace("%ID%", TimeSpan.FromMilliseconds(DateTime.Now.Millisecond).Ticks.ToString());
				string arg = "0";
				string text2;
				if (FileID.StartsWith("megafolder?") && FileID.Split('?').Length == 3)
				{
					text2 = $"[{{\"a\":\"g\",\"g\":\"1\",\"ssl\":{arg},\"n\":\"{FileID.Split('?')[2]}\"}}]";
					text = text + "&n=" + FileID.Split('?')[1];
				}
				else if (FileID.StartsWith("N?") && FileID.Split('?').Length == 2)
				{
					if (informacionFichero.FileKey.Contains("=###n="))
					{
						text = text + "&n=" + informacionFichero.FileKey.Substring(informacionFichero.FileKey.IndexOf("=###n=") + 6);
					}
					text2 = $"[{{\"a\":\"g\",\"g\":\"1\",\"ssl\":{arg},\"n\":\"{FileID.Split('?')[1]}\"}}]";
				}
				else
				{
					if (informacionFichero.FileKey.Contains("=###n="))
					{
						text = text + "&n=" + informacionFichero.FileKey.Substring(informacionFichero.FileKey.IndexOf("=###n=") + 6);
					}
					text2 = $"[{{\"a\":\"g\",\"g\":\"1\",\"ssl\":{arg},\"p\":\"{FileID}\"}}]";
				}
				Encoding.UTF8.GetBytes(text2);
				Respuesta respuesta = SendJSON(text, text2);
				if (respuesta.Excepcion == null)
				{
					Dictionary<string, object> dictionary;
					try
					{
						string text3 = respuesta.Mensaje;
						if (text3.StartsWith("["))
						{
							text3 = text3.Substring(1);
						}
						if (text3.EndsWith("]"))
						{
							text3 = text3.Trim(']');
						}
						if (Versioned.IsNumeric(text3))
						{
							throw MEGA_ErrorHandler.GetErrorFromMegaResponse(text3, "when retrieving file information");
						}
						dictionary = (Dictionary<string, object>)JsonConvert.DeserializeObject(text3, typeof(Dictionary<string, object>));
						if (dictionary.ContainsKey("e") && dictionary["e"] != null)
						{
							throw MEGA_ErrorHandler.GetErrorFromMegaResponse(dictionary["e"].ToString(), "when retrieving file information");
						}
						if (!dictionary.ContainsKey("s"))
						{
							throw new Exception();
						}
						if (!dictionary.ContainsKey("at"))
						{
							throw new Exception();
						}
						if (!dictionary.ContainsKey("g"))
						{
							throw new Exception();
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						informacionFichero.Err = TipoError.Otros;
						if (ex4.Message.Contains("when retrieving file information"))
						{
							informacionFichero.Errtxt = ex4.Message;
						}
						else
						{
							informacionFichero.Errtxt = "Response not expected: " + respuesta.Mensaje;
						}
						Log.WriteError("Error getting the info for file " + FileID + ": Response not expected - Message received: " + respuesta.Mensaje + " - Error: " + ex4.ToString());
						result = informacionFichero;
						ProjectData.ClearProjectError();
						goto IL_06b2;
					}
					string encryptedFileInfo = Conversions.ToString(dictionary["at"]);
					string s = Conversions.ToString(dictionary["s"]);
					string uRL = Conversions.ToString(dictionary["g"]);
					string text4 = "";
					text4 = PreSharedKeyManager.DecryptFileInfo(encryptedFileInfo, informacionFichero.FileKey);
					if (string.IsNullOrEmpty(text4))
					{
						foreach (string fileKeyFromPreSharedKey in PreSharedKeyManager.GetFileKeyFromPreSharedKeys(ref Config))
						{
							text4 = PreSharedKeyManager.DecryptFileInfo(encryptedFileInfo, fileKeyFromPreSharedKey);
							if (!string.IsNullOrEmpty(text4))
							{
								informacionFichero.FileKey = fileKeyFromPreSharedKey;
								break;
							}
						}
					}
					if (string.IsNullOrEmpty(text4))
					{
						informacionFichero.Err = TipoError.Otros;
						informacionFichero.Errtxt = "File could not be decrypted. Check the file Key is present on the URL and it is correct; check that the link doesn't have spaces in the middle (some forums/webpages add spaces in the middle of long words). In case of using a pre-shared key, make sure you have configured it.";
						Log.WriteError("Error getting the info for file " + FileID + ": Error decrypting fileinfo - Message received: " + respuesta.Mensaje);
						result = informacionFichero;
						goto IL_06b2;
					}
					Regex regex = new Regex("MEGA.*?\"n\"\\s*:\\s*\"(?<FileName>.*?)\"");
					if (regex.IsMatch(text4))
					{
						Match match = regex.Match(text4);
						informacionFichero.Nombre = match.Groups["FileName"].Value;
						informacionFichero.URL = uRL;
						informacionFichero.Tamano = 0L;
						long.TryParse(s, out informacionFichero.Tamano);
					}
					else
					{
						informacionFichero.Err = TipoError.Otros;
						informacionFichero.Errtxt = "File name could not be retrieved";
						Log.WriteError("Error getting the info for file " + FileID + ": File name could not be retrieved - Message received: " + respuesta.Mensaje + " - Fileinfo: " + text4);
					}
				}
				else if (respuesta.Excepcion is WebException)
				{
					informacionFichero.Err = TipoError.ErrorConexion;
					informacionFichero.Errtxt = "Connection error: " + respuesta.Excepcion.Message + " - Message received: " + respuesta.Mensaje;
					Log.WriteError("Error getting the info for file " + FileID + ": " + respuesta.Excepcion.Message + " - Message received: " + respuesta.Mensaje);
				}
				else
				{
					informacionFichero.Err = TipoError.Otros;
					informacionFichero.Errtxt = "Description: " + respuesta.Excepcion.ToString() + " - Message received: " + respuesta.Mensaje;
					Log.WriteError("Error getting the info for file " + FileID + ": " + respuesta.Excepcion.Message + " - Message received: " + respuesta.Mensaje);
				}
				result = informacionFichero;
			}
			goto IL_06b2;
		}
		IL_06b2:
		return result;
	}

	private static string LeerNodo(ref XmlDocument DocumentoXML, ref string Path, string ValorDefecto)
	{
		XmlNode xmlNode = DocumentoXML.DocumentElement.SelectSingleNode(Path);
		if (xmlNode == null)
		{
			return ValorDefecto;
		}
		return xmlNode.InnerText;
	}

	public static void PingMega()
	{
		bgPing = new BackgroundWorker();
		bgPing.WorkerReportsProgress = false;
		bgPing.WorkerSupportsCancellation = false;
		bgPing.RunWorkerAsync();
	}

	public static void PingNewUser()
	{
		bgPingNewUser = new BackgroundWorker();
		bgPingNewUser.WorkerReportsProgress = false;
		bgPingNewUser.WorkerSupportsCancellation = false;
		bgPingNewUser.RunWorkerAsync();
	}

	public static void PingNewVersion()
	{
		bgPingNewVersion = new BackgroundWorker();
		bgPingNewVersion.WorkerReportsProgress = false;
		bgPingNewVersion.WorkerSupportsCancellation = false;
		bgPingNewVersion.RunWorkerAsync();
	}

	private static void bgPing_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			Log.WriteDebug("Starting ping...");
			LeerURL(Criptografia.AES_DecryptString(InternalConfiguration.ObtenerValueFromInternalConfig("URL_PING"), "81379874BC2815E6825E98F986F98410EFC68D6DABC6EF8B54968C75387551F2"));
			Log.WriteDebug("Ping finished");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private static void bgPingNewVersion_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			Log.WriteDebug("Starting ping new version...");
			LeerURL(InternalConfiguration.ObtenerValueFromInternalConfig("URL_NEW_VERSION"), null, PingUserAgent(), PingReferer());
			Log.WriteDebug("Ping finished");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private static void bgPingNewUser_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			Log.WriteDebug("Starting ping new user...");
			LeerURL(InternalConfiguration.ObtenerValueFromInternalConfig("URL_NEW_USER"), null, PingUserAgent(), PingReferer());
			Log.WriteDebug("Ping finished");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private static string PingUserAgent()
	{
		return "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
	}

	private static string PingReferer()
	{
		return "http://megadownloaderapp.blogspot.com";
	}
}
