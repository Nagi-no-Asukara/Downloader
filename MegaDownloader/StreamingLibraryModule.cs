using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using HttpServer;
using HttpServer.HttpModules;
using HttpServer.Sessions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class StreamingLibraryModule : HttpModule
{
	public Main Downloader;

	public Configuracion Config;

	public const string PaginaMain = "/library";

	public const string PaginaManagement = "/manage";

	public const string PaginaAjax = "/ajax";

	public const string PaginaLogin = "/login";

	public string TemplateManagerData;

	public string TemplateData;

	public string TemplateLogin;

	private string _RespuestaAjax;

	private int _TimeoutSesion;

	private string _Error;

	public StreamingLibraryModule(ref Main Downloader, ref Configuracion Config)
	{
		_RespuestaAjax = "";
		string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
		foreach (string text in manifestResourceNames)
		{
			if (text.EndsWith("StreamingLibraryManagerTemplateData.htm"))
			{
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text);
				StreamReader streamReader = new StreamReader(manifestResourceStream);
				TemplateManagerData = streamReader.ReadToEnd();
			}
			else if (text.EndsWith("StreamingLibraryTemplateData.htm"))
			{
				Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(text);
				StreamReader streamReader2 = new StreamReader(manifestResourceStream2);
				TemplateData = streamReader2.ReadToEnd();
			}
			else if (text.EndsWith("StreamingLibraryTemplateLogin.htm"))
			{
				Stream manifestResourceStream3 = Assembly.GetExecutingAssembly().GetManifestResourceStream(text);
				StreamReader streamReader3 = new StreamReader(manifestResourceStream3);
				TemplateLogin = streamReader3.ReadToEnd();
			}
		}
		_TimeoutSesion = 604800;
		this.Downloader = Downloader;
		this.Config = Config;
	}

	public override bool Process(IHttpRequest request, IHttpResponse response, IHttpSession session)
	{
		SetHeaders(ref response);
		ResetRequestVar(ref request);
		if (!ComprobarAcceso(ref request, ref response, ref session))
		{
			return false;
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

	private bool ComprobarAcceso(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		if (!string.IsNullOrEmpty(Config.ServidorStreamingPassword) & !UsuarioLogueado(ref session) & (Operators.CompareString(request.Uri.LocalPath, "/login", TextCompare: false) != 0))
		{
			response.Redirect("/login");
			return false;
		}
		switch (request.Uri.LocalPath)
		{
		case "/library":
		case "/manage":
		case "/ajax":
		case "/login":
			return true;
		default:
			response.Redirect("/library");
			return false;
		}
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

	private bool ProcesarPagina(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		string localPath = request.Uri.LocalPath;
		if (Operators.CompareString(localPath, "/login", TextCompare: false) != 0)
		{
			if (Operators.CompareString(localPath, "/ajax", TextCompare: false) == 0)
			{
				return ProcesoAjax(ref request, ref response, ref session);
			}
			return true;
		}
		return ProcesoLogin(ref request, ref response, ref session);
	}

	private void PintarPagina(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		StringBuilder stringBuilder = new StringBuilder();
		switch (request.Uri.LocalPath)
		{
		case "/manage":
			stringBuilder.Append(TemplateManagerData);
			break;
		case "/library":
			stringBuilder.Append(TemplateData);
			break;
		case "/ajax":
			stringBuilder.Append(CargarAjax());
			break;
		case "/login":
			stringBuilder.Append(TemplateLogin.Replace("%ERROR%", _Error));
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

	private string CargarAjax()
	{
		return _RespuestaAjax;
	}

	private bool ProcesoLogin(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		if (request.Param != null && ((request.Param["Password"] != null) & IsPostBack(ref request)))
		{
			if (Operators.CompareString(request.Param["Password"].Value, Config.ServidorStreamingPassword, TextCompare: false) == 0)
			{
				session["Logueado"] = "1";
				session["LoginDate"] = DateAndTime.Now;
				response.Redirect("/library");
				return false;
			}
			SetError(Language.GetText("Invalid password"));
		}
		return true;
	}

	private void SetError(string msj)
	{
		_Error = "<br/><div class='error'>" + msj + "</div><br/>";
	}

	private bool ProcesoAjax(ref IHttpRequest request, ref IHttpResponse response, ref IHttpSession session)
	{
		string authority = request.Uri.Authority;
		if (request.Param != null)
		{
			if (request.Param["Action"] == null || string.IsNullOrEmpty(request.Param["Action"].Value))
			{
				PrepareAjaxResponse("Action not specified");
				return true;
			}
			switch (request.Param["Action"].Value)
			{
			case "Load":
			{
				if (request.Param["Element"] == null || string.IsNullOrEmpty(request.Param["Element"].Value))
				{
					PrepareAjaxResponse("Element not specified");
					return true;
				}
				LibraryElement elementByID = StreamingLibraryManager.GetElementByID(request.Param["Element"].Value);
				if (elementByID == null)
				{
					PrepareAjaxResponse("Element not found");
					return true;
				}
				PrepareAjaxResponse(authority, elementByID);
				break;
			}
			case "Delete":
				if (request.Param["ID"] == null || !Versioned.IsNumeric(request.Param["ID"].Value))
				{
					PrepareAjaxResponse("ID not specified");
				}
				StreamingLibraryManager.RemoveElement(request.Param["ID"].Value);
				PrepareAjaxResponse("");
				break;
			case "Save":
			{
				if (request.Param["ID"] == null)
				{
					PrepareAjaxResponse("ID not specified");
					return true;
				}
				if (request.Param["IMDB"] == null)
				{
					PrepareAjaxResponse("IMDB not specified");
					return true;
				}
				if (request.Param["Allocine"] == null)
				{
					PrepareAjaxResponse("Allocine not specified");
					return true;
				}
				if (request.Param["Filmaffinity"] == null)
				{
					PrepareAjaxResponse("Filmaffinity not specified");
					return true;
				}
				if (request.Param["Name"] == null)
				{
					PrepareAjaxResponse("Name not specified");
					return true;
				}
				if (request.Param["Desc"] == null)
				{
					PrepareAjaxResponse("Desc not specified");
					return true;
				}
				if (request.Param["Poster"] == null)
				{
					PrepareAjaxResponse("Poster not specified");
					return true;
				}
				if (request.Param["Comments"] == null)
				{
					PrepareAjaxResponse("Comments not specified");
					return true;
				}
				if (request.Param["Link"] == null || string.IsNullOrEmpty(request.Param["Link"].Value))
				{
					PrepareAjaxResponse("Link not specified");
					return true;
				}
				if (Operators.CompareString(request.Param["Link"].Value, "** LINK NOT VISIBLE **", TextCompare: false) != 0 && string.IsNullOrEmpty(Fichero.ExtraerFileID(request.Param["Link"].Value)))
				{
					PrepareAjaxResponse("Invalid link");
					return true;
				}
				bool linkVisible = true;
				string value2 = request.Param["ID"].Value;
				string Name = request.Param["Name"].Value;
				string Desc = request.Param["Desc"].Value;
				string value3 = request.Param["Comments"].Value;
				string Poster = request.Param["Poster"].Value;
				string IMDB = request.Param["IMDB"].Value;
				string FilmAffinityID = request.Param["Filmaffinity"].Value;
				string AllocineID = request.Param["Allocine"].Value;
				string value4 = request.Param["Link"].Value;
				MegaDownloader.IMDB.FillMissingFields(ref IMDB, ref Name, ref Poster, ref Desc);
				Allocine.FillMissingFields(ref AllocineID, ref Name, ref Poster, ref Desc);
				Filmaffinity.FillMissingFields(ref FilmAffinityID, ref Name, ref Poster, ref Desc);
				if (Versioned.IsNumeric(value2))
				{
					LibraryElement libraryElement = StreamingLibraryManager.ModifyElement(value2, Name, Desc, value3, Poster, value4, linkVisible, IMDB, AllocineID, FilmAffinityID);
					if (libraryElement == null)
					{
						PrepareAjaxResponse("Element not found");
						return true;
					}
					PrepareAjaxResponse(authority, libraryElement);
				}
				else
				{
					LibraryElement libraryElement2 = StreamingLibraryManager.AddElement(Name, Desc, value3, Poster, value4, linkVisible, IMDB, AllocineID, FilmAffinityID);
					if (libraryElement2 == null)
					{
						PrepareAjaxResponse("Element not created");
						return true;
					}
					PrepareAjaxResponse(authority, libraryElement2);
				}
				break;
			}
			case "LoadAll":
				PrepareAjaxResponse(authority, StreamingLibraryManager.GetElements());
				break;
			case "OpenVLC":
				if (request.Param["URL"] == null || string.IsNullOrEmpty(request.Param["URL"].Value))
				{
					PrepareAjaxResponse("URL not specified");
					return true;
				}
				if (!StreamingHelper.WatchOnline(Config.VLCPath, request.Param["URL"].Value))
				{
					PrepareAjaxResponse("VLC could not be loaded");
				}
				return true;
			case "ImportLinks":
			{
				if (request.Param["Links"] == null)
				{
					PrepareAjaxResponse("Links not specified");
					return true;
				}
				string value = request.Param["Links"].Value;
				if (StreamingLibraryManager.IsImportedLibrary(value))
				{
					PrepareAjaxResponseImport(-1, StreamingLibraryManager.ImportLibrary(value));
					return true;
				}
				List<string> list = URLExtractor.ExtraerURLs(Uri.UnescapeDataString(value));
				PrepareAjaxResponseImport(list.Count, StreamingLibraryManager.ImportLinks(ref Config, list));
				return true;
			}
			case "ExportLinks":
			{
				if (request.Param["IDs"] == null)
				{
					PrepareAjaxResponse("IDs not specified");
					return true;
				}
				bool result = false;
				bool result2 = false;
				if (request.Param["HideLinks"] != null)
				{
					bool.TryParse(request.Param["HideLinks"].Value, out result);
				}
				if (request.Param["PlainText"] != null)
				{
					bool.TryParse(request.Param["PlainText"].Value, out result2);
				}
				PrepareAjaxResponseExport(StreamingLibraryManager.ExportElements(request.Param["IDs"].Value.Split(';').ToList(), result, result2));
				return true;
			}
			default:
				PrepareAjaxResponse("Action " + request.Param["Action"].Value + " not recognized");
				break;
			}
		}
		return true;
	}

	private void PrepareAjaxResponseExport(string code)
	{
		_RespuestaAjax = "{\"error\": \"\", \"code\": \"" + code + "\"}";
	}

	private void PrepareAjaxResponseImport(int numReceived, int numImported)
	{
		_RespuestaAjax = "{\"error\": \"\", \"numR\": \"" + numReceived + "\", \"numI\": \"" + numImported + "\"}";
	}

	private void PrepareAjaxResponse(string CurrentURL, LibraryElement ele)
	{
		_RespuestaAjax = "{\"error\": \"\", \"Data\": [" + ele.ToJSON(CurrentURL, ref Config) + "]}";
	}

	private void PrepareAjaxResponse(string CurrentURL, IEnumerable<LibraryElement> ele)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{\"error\": \"\", \"Data\": [");
		bool flag = true;
		foreach (LibraryElement item in ele)
		{
			if (!flag)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append(item.ToJSON(CurrentURL, ref Config));
			flag = false;
		}
		stringBuilder.Append("]}");
		_RespuestaAjax = stringBuilder.ToString();
	}

	private void PrepareAjaxResponse(string ErrorMessage)
	{
		_RespuestaAjax = "{\"error\": \"" + JSONEscape(ErrorMessage) + "\"}";
	}

	private string JSONEscape(string str)
	{
		return (str ?? "").Replace("\"", "\\\"");
	}
}
