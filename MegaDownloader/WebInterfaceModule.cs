using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using HttpServer;
using HttpServer.HttpModules;
using HttpServer.Sessions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class WebInterfaceModule : HttpModule
{
	public Main Downloader;

	public const string PaginaLogin = "/login";

	public const string PaginaLogout = "/logout";

	public const string PaginaMain = "/main";

	public const string PaginaCSS = "/style.css";

	public const string PaginaFavIcon = "/favicon.ico";

	public const string PaginaAjaxStatus = "/ajax_status";

	public const string PaginaAjaxStop = "/ajax_stopdownload";

	public const string PaginaAjaxPlay = "/ajax_resumedownload";

	public const string PaginaAjaxAddLink = "/ajax_addlink";

	public const string CONST_CONTENT = "%CONTENT%";

	public const string CONST_HEAD = "%HEAD%";

	public const string CONST_JAVASCRIPT = "%JAVASCRIPT%";

	public const string CONST_TITLE = "%TITLE%";

	public const string CONST_ERROR = "%ERROR%";

	public XmlDocument XmlTemplateData;

	private string _RespuestaAjax;

	private string _Password;

	private string _TitlePersonalizado;

	private int _TimeoutSesion;

	private string _Language;

	private string _Error;

	public WebInterfaceModule(ref Main Downloader, string TemplatePath, string Password, string TituloVentana, int TimeOutSesion, string LanguageCode)
	{
		XmlTemplateData = null;
		_RespuestaAjax = "";
		if (string.IsNullOrEmpty(TemplatePath) || !File.Exists(TemplatePath))
		{
			string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
			foreach (string text in manifestResourceNames)
			{
				if (text.EndsWith("XmlTemplateData.xml"))
				{
					Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text);
					StreamReader streamReader = new StreamReader(manifestResourceStream);
					XmlTemplateData = new XmlDocument();
					XmlTemplateData.LoadXml(streamReader.ReadToEnd());
					break;
				}
			}
		}
		else
		{
			XmlTemplateData = new XmlDocument();
			XmlTemplateData.Load(TemplatePath);
		}
		CheckTemplate();
		if (string.IsNullOrEmpty(TituloVentana))
		{
			_TitlePersonalizado = InternalConfiguration.ObtenerNombreApp() + InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_MEGADOWNLOADER");
		}
		else
		{
			_TitlePersonalizado = TituloVentana;
		}
		this.Downloader = Downloader;
		_TimeoutSesion = TimeOutSesion;
		_Language = LanguageCode;
		_Password = MD5Utils.MD5CalcString(Password);
	}

	private void CheckTemplate()
	{
		if (XmlTemplateData == null)
		{
			throw new ApplicationException("Error template not found");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Template/HtmlTemplate") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Template/HtmlTemplate");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Template/FavIcon") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Template/FavIcon");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Template/FavIconMimeType") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Template/FavIconMimeType");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Content/HeadMain") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Content/HeadMain");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Content/BodyMain") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Content/BodyMain");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Content/BodyJavaScript") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Content/BodyJavaScript");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Content/BodyLogin") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Content/BodyLogin");
		}
		if (XmlTemplateData.DocumentElement.SelectSingleNode("Content/CSS") == null)
		{
			throw new ApplicationException("Template is not correct, missing node Content/CSS");
		}
	}

	public override bool Process(IHttpRequest request, IHttpResponse response, IHttpSession session)
	{
		SetHeaders(ref response);
		ResetRequestVar(ref request);
		if (!ComprobarAcceso(ref request, ref response, ref session))
		{
			return true;
		}
		if (!ProcesarPagina(ref request, ref response, ref session))
		{
			return true;
		}
		PintarPagina(ref request, ref response, ref session);
		return true;
	}

	private bool IsPostBack(ref IHttpRequest request)
	{
		return Operators.CompareString(request.Method, "POST", TextCompare: false) == 0;
	}

	private void ResetRequestVar(ref IHttpRequest request)
	{
		if (!IsPostBack(ref request))
		{
			_Error = "";
		}
	}

	private void SetHeaders(ref IHttpResponse response)
	{
		response.AddHeader("Server", "Internal");
	}

	private void SetCSSControlCache(ref IHttpResponse response)
	{
		response.AddHeader("Cache-Control", "public, max-age=604800");
	}

	private bool UsuarioLogueado(ref IHttpSession session)
	{
		bool flag = session["Logueado"] != null && Operators.CompareString(Conversions.ToString(session["Logueado"]), "1", TextCompare: false) == 0;
		if ((flag & (_TimeoutSesion > 0) & (session["LoginDate"] != null)) && session["LoginDate"] is DateTime)
		{
			flag = DateTime.Compare(Conversions.ToDate(session["LoginDate"]).AddSeconds(_TimeoutSesion), DateAndTime.Now) > 0;
		}
		return flag;
	}

	private bool ComprobarAcceso(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		bool flag = false;
		bool flag2 = false;
		switch (request.Uri.LocalPath)
		{
		case "/main":
			flag = true;
			break;
		case "/ajax_status":
		case "/ajax_stopdownload":
		case "/ajax_resumedownload":
		case "/ajax_addlink":
			flag = true;
			flag2 = true;
			break;
		}
		if (!UsuarioLogueado(ref session) && flag)
		{
			if (flag2)
			{
				StreamWriter streamWriter = new StreamWriter(response.Body);
				streamWriter.Write(ErrorAjax(Language.GetText("Error, session expired")));
				streamWriter.Flush();
				return false;
			}
			response.Redirect("/login");
			return false;
		}
		switch (request.Uri.LocalPath)
		{
		case "/login":
		case "/logout":
		case "/main":
		case "/style.css":
		case "/favicon.ico":
		case "/ajax_status":
		case "/ajax_resumedownload":
		case "/ajax_stopdownload":
		case "/ajax_addlink":
			return true;
		default:
			response.Redirect("/main");
			return false;
		}
	}

	private bool ProcesarPagina(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		return request.Uri.LocalPath switch
		{
			"/login" => ProcesoLogin(ref request, ref response, ref session), 
			"/logout" => ProcesoLogout(ref request, ref response, ref session), 
			"/ajax_addlink" => ProcesoAddLinks(ref request, ref response, ref session), 
			"/ajax_stopdownload" => ProcesoStop(ref request, ref response, ref session), 
			"/ajax_resumedownload" => ProcesoPlay(ref request, ref response, ref session), 
			"/ajax_status" => ProcesoStatus(ref request, ref response, ref session), 
			_ => true, 
		};
	}

	private void PintarPagina(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		string localPath = request.Uri.LocalPath;
		if (Operators.CompareString(localPath, "/favicon.ico", TextCompare: false) == 0)
		{
			response.AddHeader("Content-Type", FavIconMimeType());
			BinaryWriter binaryWriter = new BinaryWriter(response.Body);
			binaryWriter.Write(Convert.FromBase64String(FavIconBase64()));
			binaryWriter.Flush();
			SetCSSControlCache(ref response);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		switch (request.Uri.LocalPath)
		{
		case "/ajax_status":
			stringBuilder.Append(CargarAjax());
			break;
		case "/ajax_resumedownload":
			stringBuilder.Append(CargarAjax());
			break;
		case "/ajax_stopdownload":
			stringBuilder.Append(CargarAjax());
			break;
		case "/ajax_addlink":
			stringBuilder.Append(CargarAjax());
			break;
		case "/style.css":
			response.AddHeader("Content-Type", "text/css");
			stringBuilder.Append(CSS());
			SetCSSControlCache(ref response);
			break;
		case "/login":
			stringBuilder.Append(PintarPaginaLogin());
			break;
		case "/main":
			stringBuilder.Append(PintarPaginaMain());
			break;
		}
		string ResponseBody = stringBuilder.ToString();
		ComprimirRespuesta(ref request, ref response, ref ResponseBody);
	}

	private void ComprimirRespuesta(ref IHttpRequest request, ref IHttpResponse response, ref string ResponseBody)
	{
		string text = request.Headers["Accept-Encoding"];
		if (!string.IsNullOrEmpty(text) && text.ToLower().Contains("gzip"))
		{
			response.AddHeader("Content-Encoding", "gzip");
			byte[] bytes = Encoding.UTF8.GetBytes(ResponseBody);
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				gZipStream.Write(bytes, 0, bytes.Length);
				gZipStream.Flush();
			}
			bytes = memoryStream.ToArray();
			response.Body.Write(bytes, 0, bytes.Length);
			return;
		}
		StreamWriter streamWriter = new StreamWriter(response.Body);
		streamWriter.Write(ResponseBody);
		streamWriter.Flush();
	}

	private bool ProcesoStatus(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		_RespuestaAjax = "<span class='StatusMuyImportante'><strong>" + Language.GetText("Status") + "</strong>: ";
		switch (Downloader.ControlRemotoObtenerEstado())
		{
		case Main.TipoEstadoAplicacion.Descargando:
		{
			ref string respuestaAjax3 = ref _RespuestaAjax;
			respuestaAjax3 = respuestaAjax3 + "<span class='iconPlay'>" + Language.GetText("Downloading") + "</span>";
			break;
		}
		case Main.TipoEstadoAplicacion.Parado:
		{
			ref string respuestaAjax2 = ref _RespuestaAjax;
			respuestaAjax2 = respuestaAjax2 + "<span class='iconPause'>" + Language.GetText("Stopped") + "</span>";
			break;
		}
		case Main.TipoEstadoAplicacion.Pausa:
		{
			ref string respuestaAjax = ref _RespuestaAjax;
			respuestaAjax = respuestaAjax + "<span class='iconPause'>" + Language.GetText("Paused") + "</span>";
			break;
		}
		}
		_RespuestaAjax += "</span><br/>\r\n";
		ref string respuestaAjax4 = ref _RespuestaAjax;
		respuestaAjax4 = respuestaAjax4 + "<span class='StatusImportante'><strong>" + Language.GetText("Speed") + "</strong>: ";
		decimal? num = Downloader.ControlRemotoObtenerVelocidad();
		if (num.HasValue)
		{
			_RespuestaAjax += PintarVelocidadDescarga(num.Value);
		}
		else
		{
			_RespuestaAjax += "-";
		}
		_RespuestaAjax += "</span><br/>\r\n";
		ref string respuestaAjax5 = ref _RespuestaAjax;
		respuestaAjax5 = respuestaAjax5 + "<span class='StatusImportante'><strong>" + Language.GetText("Active downloads") + "</strong>: ";
		int? num2 = Downloader.ControlRemotoObtenerDescargasActivas();
		if (num2.HasValue)
		{
			_RespuestaAjax += num2.Value;
		}
		else
		{
			_RespuestaAjax += "-";
		}
		_RespuestaAjax += "</span><br/>\r\n";
		ref string respuestaAjax6 = ref _RespuestaAjax;
		respuestaAjax6 = respuestaAjax6 + "<span><strong>" + Language.GetText("Queued, error, completed") + "</strong>: <span style='white-space:nowrap;'>";
		int? num3 = Downloader.ControlRemotoObtenerDescargasEnCola();
		int? num4 = Downloader.ControlRemotoObtenerDescargasErroneas();
		int? num5 = Downloader.ControlRemotoObtenerDescargasCompletadas();
		if (num3.HasValue)
		{
			ref string respuestaAjax7 = ref _RespuestaAjax;
			respuestaAjax7 = respuestaAjax7 + num3.Value + " / ";
		}
		else
		{
			_RespuestaAjax += "- / ";
		}
		if (num4.HasValue)
		{
			ref string respuestaAjax8 = ref _RespuestaAjax;
			respuestaAjax8 = respuestaAjax8 + num4.Value + " / ";
		}
		else
		{
			_RespuestaAjax += "- / ";
		}
		if (num5.HasValue)
		{
			_RespuestaAjax += num5.Value;
		}
		else
		{
			_RespuestaAjax += "-";
		}
		_RespuestaAjax += "</span></span><br/>\r\n";
		ref string respuestaAjax9 = ref _RespuestaAjax;
		respuestaAjax9 = respuestaAjax9 + "<span><strong>" + Language.GetText("Hour") + "</strong>: ";
		_RespuestaAjax += DateAndTime.Now.ToString("HH:mm:ss");
		_RespuestaAjax += "</span>";
		return true;
	}

	private static string PintarVelocidadDescarga(decimal vel)
	{
		string text = "KB/s";
		if (decimal.Compare(vel, 1024m) > 0)
		{
			text = "MB/s";
			vel = decimal.Divide(vel, 1024m);
		}
		return vel.ToString("F2") + " " + text;
	}

	private bool ProcesoStop(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		Downloader.ControlRemotoParar();
		Thread.Sleep(400);
		_RespuestaAjax = Language.GetText("Download stopped");
		return true;
	}

	private bool ProcesoPlay(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		Downloader.ControlRemotoDescargar();
		Thread.Sleep(400);
		_RespuestaAjax = Language.GetText("Download started");
		return true;
	}

	private bool ProcesoLogin(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		if (request.Param != null && ((request.Param["Password"] != null) & IsPostBack(ref request)))
		{
			if (Operators.CompareString(MD5Utils.MD5CalcString(request.Param["Password"].Value), _Password, TextCompare: false) == 0)
			{
				session["Logueado"] = "1";
				session["LoginDate"] = DateAndTime.Now;
				response.Redirect("/main");
				return false;
			}
			SetError(Language.GetText("Invalid password"));
		}
		return true;
	}

	private bool ProcesoLogout(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		session["Logueado"] = "0";
		response.Redirect("/login");
		return false;
	}

	private bool ProcesoAddLinks(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		_RespuestaAjax = ErrorAjax(Language.GetText("Invalid links"));
		if (request.Param != null && ((request.Param["links"] != null) & (request.Param["pckname"] != null) & (request.Param["createdirpck"] != null) & IsPostBack(ref request)))
		{
			string value = request.Param["links"].Value;
			string value2 = request.Param["createdirpck"].Value;
			string value3 = request.Param["pckname"].Value;
			Thread.Sleep(400);
			if (string.IsNullOrEmpty(value))
			{
				_RespuestaAjax = ErrorAjax(Language.GetText("Invalid links"));
			}
			else if ((Operators.CompareString(value2, "true", TextCompare: false) == 0) & string.IsNullOrEmpty(value3))
			{
				_RespuestaAjax = ErrorAjax(Language.GetText("Invalid package name"));
			}
			else
			{
				string text = Downloader.ControlRemotoAgregarLinks(value, value3, Operators.CompareString(value2, "true", TextCompare: false) == 0);
				if (string.IsNullOrEmpty(text))
				{
					_RespuestaAjax = Language.GetText("Links added successfully");
				}
				else
				{
					_RespuestaAjax = ErrorAjax(text);
				}
			}
		}
		return true;
	}

	private string PintarComun(ref string str)
	{
		return str.Replace("%CONTENT%", "").Replace("%ERROR%", _Error).Replace("%HEAD%", "")
			.Replace("%JAVASCRIPT%", "")
			.Replace("%TITLE%", "");
	}

	private string PintarPaginaLogin()
	{
		string str = Template().Replace("%CONTENT%", BodyLogin()).Replace("%HEAD%", HeadMain(Logueado: false)).Replace("%TITLE%", "Login");
		return PintarComun(ref str);
	}

	private string PintarPaginaMain()
	{
		string str = Template().Replace("%CONTENT%", BodyMain()).Replace("%JAVASCRIPT%", BodyJavaScript()).Replace("%HEAD%", HeadMain(Logueado: true))
			.Replace("%TITLE%", _TitlePersonalizado);
		return PintarComun(ref str);
	}

	private string FavIconMimeType()
	{
		return XmlTemplateData.DocumentElement.SelectSingleNode("Template/FavIconMimeType").InnerText;
	}

	private string FavIconBase64()
	{
		return XmlTemplateData.DocumentElement.SelectSingleNode("Template/FavIcon").InnerText;
	}

	private string CSS()
	{
		return XmlTemplateData.DocumentElement.SelectSingleNode("Content/CSS").InnerText;
	}

	private string Template()
	{
		return XmlTemplateData.DocumentElement.SelectSingleNode("Template/HtmlTemplate").InnerText;
	}

	private string HeadMain(bool Logueado)
	{
		string text = "";
		if (Logueado)
		{
			text = text + "<link rel=\"shortcut icon\" href=\"/favicon.ico\" type=\"" + FavIconMimeType() + "\" />\r\n";
		}
		return text + XmlTemplateData.DocumentElement.SelectSingleNode("Content/HeadMain").InnerText;
	}

	private string BodyJavaScript()
	{
		return XmlTemplateData.DocumentElement.SelectSingleNode("Content/BodyJavaScript").InnerText;
	}

	private string BodyMain()
	{
		return XmlTemplateData.DocumentElement.SelectSingleNode("Content/BodyMain").InnerText;
	}

	private string BodyLogin()
	{
		return XmlTemplateData.DocumentElement.SelectSingleNode("Content/BodyLogin").InnerText;
	}

	private string CargarAjax()
	{
		return _RespuestaAjax;
	}

	private void SetError(string msj)
	{
		_Error = "<br/><div class='error'>" + msj + "</div><br/>";
	}

	private string ErrorAjax(string msj)
	{
		return "<span class='error'>" + msj + "</span>";
	}
}
