using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class StreamingLibraryManager
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__12_002D0
	{
		public LibraryElement _0024VB_0024Local_ele;

		public _Closure_0024__12_002D0(_Closure_0024__12_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ele = arg0._0024VB_0024Local_ele;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(LibraryElement e)
		{
			return Operators.CompareString(Criptografia.ToInsecureString(e.Link).ToUpper().Trim(), Criptografia.ToInsecureString(_0024VB_0024Local_ele.Link).ToUpper().Trim(), TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D0
	{
		public string _0024VB_0024Local_URL2;

		public _Closure_0024__13_002D0(_Closure_0024__13_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_URL2 = arg0._0024VB_0024Local_URL2;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(LibraryElement e)
		{
			return Operators.CompareString(Criptografia.ToInsecureString(e.Link).ToUpper().Trim(), _0024VB_0024Local_URL2.ToUpper().Trim(), TextCompare: false) == 0;
		}
	}

	private static StreamingLibrary _StreamingLibrary;

	public static StreamingLibrary StreamingLibrary()
	{
		if (_StreamingLibrary == null)
		{
			_StreamingLibrary = new StreamingLibrary();
			_StreamingLibrary.LoadXML();
		}
		return _StreamingLibrary;
	}

	public static void SaveLibrary()
	{
		if (_StreamingLibrary != null)
		{
			_StreamingLibrary.SaveXML();
		}
	}

	public static LibraryElement ProcessByNameAndAddElement(string Name, string Description, string Comments, string Poster, string Link, bool LinkVisible, string IMDB, string Allocine, string Filmaffinity)
	{
		string[] array = new string[3] { "\\[film(?<FILMAFFINITY>[\\d]*)\\]", "\\[tt(?<IMDB>[\\d]*)\\]", "\\[allocine(?<ALLOCINE>[\\d]*)\\]" };
		if (!string.IsNullOrEmpty(Name))
		{
			string[] array2 = array;
			foreach (string pattern in array2)
			{
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(Name))
				{
					Match match = regex.Match(Name);
					if (!string.IsNullOrEmpty(match.Groups["FILMAFFINITY"].Value))
					{
						Filmaffinity = match.Groups["FILMAFFINITY"].Value;
					}
					else if (!string.IsNullOrEmpty(match.Groups["IMDB"].Value))
					{
						IMDB = match.Groups["IMDB"].Value;
					}
					else if (!string.IsNullOrEmpty(match.Groups["ALLOCINE"].Value))
					{
						Allocine = match.Groups["ALLOCINE"].Value;
					}
				}
			}
		}
		MegaDownloader.IMDB.FillMissingFields(ref IMDB, ref Name, ref Poster, ref Description);
		MegaDownloader.Allocine.FillMissingFields(ref Allocine, ref Name, ref Poster, ref Description);
		MegaDownloader.Filmaffinity.FillMissingFields(ref Filmaffinity, ref Name, ref Poster, ref Description);
		return AddElement(Name, Description, Comments, Poster, Link, LinkVisible, IMDB, Allocine, Filmaffinity);
	}

	public static LibraryElement AddElement(string Name, string Description, string Comments, string Poster, string Link, bool LinkVisible, string IMDB, string Allocine, string Filmaffinity)
	{
		LibraryElement libraryElement = new LibraryElement();
		libraryElement.Name = Name;
		libraryElement.Description = Description;
		libraryElement.Comments = Comments;
		libraryElement.IMDB = IMDB;
		libraryElement.Allocine = Allocine;
		libraryElement.Filmaffinity = Filmaffinity;
		libraryElement.Poster = Poster;
		libraryElement.LastModification = DateAndTime.Now;
		libraryElement.LinkVisible = LinkVisible;
		if (Operators.CompareString(Link, "** LINK NOT VISIBLE **", TextCompare: false) != 0)
		{
			libraryElement.Link = Criptografia.ToSecureString(Link);
		}
		else
		{
			libraryElement.Link = new SecureString();
		}
		libraryElement.ID = StreamingLibrary().GetIDandIncrement().ToString();
		StreamingLibrary().Elements().Add(libraryElement);
		StreamingLibrary().SaveXML();
		return libraryElement;
	}

	public static LibraryElement ModifyElement(string ID, string Name, string Description, string Comments, string Poster, string Link, bool LinkVisible, string IMDB, string Allocine, string Filmaffinity)
	{
		IEnumerable<LibraryElement> source = from e in StreamingLibrary().Elements()
			where Operators.CompareString(e.ID, ID, TextCompare: false) == 0
			select e;
		if (source.Count() > 0)
		{
			LibraryElement libraryElement = source.ToArray()[0];
			libraryElement.Name = Name;
			libraryElement.Description = Description;
			libraryElement.Comments = Comments;
			libraryElement.IMDB = IMDB;
			libraryElement.Allocine = Allocine;
			libraryElement.Filmaffinity = Filmaffinity;
			libraryElement.Poster = Poster;
			libraryElement.LastModification = DateAndTime.Now;
			if (Operators.CompareString(Link, "** LINK NOT VISIBLE **", TextCompare: false) != 0)
			{
				libraryElement.Link = Criptografia.ToSecureString(Link);
				libraryElement.LinkVisible = LinkVisible;
			}
			StreamingLibrary().SaveXML();
			return libraryElement;
		}
		return null;
	}

	public static void RemoveElement(string ID)
	{
		IEnumerable<LibraryElement> source = from e in StreamingLibrary().Elements()
			where Operators.CompareString(e.ID, ID, TextCompare: false) == 0
			select e;
		if (source.Count() > 0)
		{
			StreamingLibrary().Elements().Remove(source.ToArray()[0]);
			StreamingLibrary().SaveXML();
		}
	}

	public static LibraryElement GetElementByID(string ID)
	{
		IEnumerable<LibraryElement> source = from e in StreamingLibrary().Elements()
			where Operators.CompareString(e.ID, ID, TextCompare: false) == 0
			select e;
		if (source.Count() > 0)
		{
			return source.ToArray()[0];
		}
		return null;
	}

	public static List<LibraryElement> GetElements()
	{
		return (from e in StreamingLibrary().Elements()
			orderby e.Name
			select e).ToList();
	}

	public static bool IsImportedLibrary(string data)
	{
		return GetImportedLibrary(data).Count > 0;
	}

	public static List<string> GetImportedLibrary(string data)
	{
		List<string> list = new List<string>();
		MatchCollection matchCollection = new Regex("<(?<Tag>ExportedXML)>(?<Content>.*?)</\\1>", RegexOptions.IgnoreCase).Matches(data);
		foreach (Match item2 in matchCollection)
		{
			string item = "<ExportedXML>" + item2.Groups["Content"].Value + "</ExportedXML>";
			list.Add(item);
		}
		matchCollection = new Regex("[<|{](?<Tag>MEGALIBRARY)[>|}](?<Content>.*?)[<|{][/|:]\\1[>|}]", RegexOptions.IgnoreCase).Matches(data);
		foreach (Match item3 in matchCollection)
		{
			string text = item3.Groups["Content"].Value;
			try
			{
				text = UnCompressString(Criptografia.base64urldecodeBytes(text));
				list.Add(text);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error trying to import library [GetImportedLibrary] - error " + ex2.ToString() + " - Data: " + text);
				ProjectData.ClearProjectError();
			}
		}
		return list;
	}

	public static int ImportLibrary(string Data)
	{
		int num = 0;
		_Closure_0024__12_002D0 closure_0024__12_002D = default(_Closure_0024__12_002D0);
		foreach (string item in GetImportedLibrary(Data))
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(item);
				foreach (XmlNode item2 in xmlDocument.DocumentElement.SelectNodes("Elements/Element"))
				{
					closure_0024__12_002D = new _Closure_0024__12_002D0(closure_0024__12_002D);
					closure_0024__12_002D._0024VB_0024Local_ele = new LibraryElement();
					closure_0024__12_002D._0024VB_0024Local_ele.LoadXML(item2, Import: true);
					if (StreamingLibrary().Elements().Where(closure_0024__12_002D._Lambda_0024__0).Count() <= 0)
					{
						closure_0024__12_002D._0024VB_0024Local_ele.ID = StreamingLibrary().GetIDandIncrement().ToString();
						closure_0024__12_002D._0024VB_0024Local_ele.LastModification = DateAndTime.Now;
						StreamingLibrary().Elements().Add(closure_0024__12_002D._0024VB_0024Local_ele);
						num = checked(num + 1);
					}
				}
				StreamingLibrary().SaveXML();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error trying to import library [ImportLibrary] - error " + ex2.ToString() + " - Data: " + item);
				ProjectData.ClearProjectError();
			}
		}
		return num;
	}

	public static int ImportLinks(ref Configuracion Config, List<string> URLs)
	{
		List<string> list = new List<string>();
		foreach (string URL in URLs)
		{
			if (URLExtractor.IsMegaFolder(URL))
			{
				string folderID = URLExtractor.ExtraerFileID(URL);
				string folderKey = URLExtractor.ExtraerFileKey(URL);
				foreach (URLProcessor.FileURL item in MegaFolderHelper.RetrieveLinksFromFolder(folderID, folderKey))
				{
					list.Add(item.URL);
				}
			}
			else if (URLExtractor.IsELC(URL))
			{
				Exception Exc = null;
				foreach (string item2 in ServerEncoderLinkHelper.ServerDecode(URL, ref Config, ref Exc))
				{
					if (URLExtractor.IsMegaFolder(item2))
					{
						string folderID2 = URLExtractor.ExtraerFileID(item2);
						string folderKey2 = URLExtractor.ExtraerFileKey(item2);
						foreach (URLProcessor.FileURL item3 in MegaFolderHelper.RetrieveLinksFromFolder(folderID2, folderKey2))
						{
							list.Add("{HIDDEN}" + item3.URL);
						}
					}
					else
					{
						list.Add("{HIDDEN}" + item2);
					}
				}
			}
			else
			{
				list.Add(URL);
			}
		}
		URLs = list;
		int num = 0;
		_Closure_0024__13_002D0 closure_0024__13_002D = default(_Closure_0024__13_002D0);
		foreach (string URL2 in URLs)
		{
			closure_0024__13_002D = new _Closure_0024__13_002D0(closure_0024__13_002D);
			string text = URL2;
			bool linkVisible = true;
			if (!string.IsNullOrEmpty(URL2) && URL2.Contains("{HIDDEN}"))
			{
				linkVisible = false;
				text = text.Replace("{HIDDEN}", "");
			}
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(Fichero.ExtraerFileID(text)))
			{
				continue;
			}
			closure_0024__13_002D._0024VB_0024Local_URL2 = text;
			if (StreamingLibrary().Elements().Where(closure_0024__13_002D._Lambda_0024__0).Count() <= 0)
			{
				string fileID = Fichero.ExtraerFileID(text);
				string fileKey = Fichero.ExtraerFileKey(text);
				Conexion.InformacionFichero informacionFichero = Conexion.ObtenerInformacionFichero(Config, fileID, fileKey, ComprobacionAntesDescarga: false);
				if (informacionFichero.Err == Conexion.TipoError.SinErrores)
				{
					ProcessByNameAndAddElement(informacionFichero.Nombre, "", "", "", text, linkVisible, "", "", "");
				}
				else
				{
					AddElement("Imported element #" + Conversions.ToString(num), "", "", "", text, linkVisible, "", "", "");
				}
				num = checked(num + 1);
			}
		}
		return num;
	}

	public static string ExportElements(List<string> IDs, bool HideLinks, bool PlainText)
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode XML = xmlDocument.AppendChild(xmlDocument.CreateElement("ExportedXML")).AppendChild(xmlDocument.CreateElement("Elements"));
		foreach (LibraryElement item in StreamingLibrary().Elements())
		{
			if (IDs.Contains(item.ID))
			{
				bool linkVisible = item.LinkVisible;
				if (HideLinks)
				{
					item.LinkVisible = false;
				}
				item.SaveXML(ref XML, Export: true);
				item.LinkVisible = linkVisible;
			}
		}
		string outerXml = xmlDocument.DocumentElement.OuterXml;
		if (PlainText)
		{
			return outerXml;
		}
		return "{MEGALIBRARY}" + Criptografia.base64urlencode(CompressString(outerXml)) + "{:MEGALIBRARY}";
	}

	private static byte[] CompressString(string str)
	{
		MemoryStream memoryStream = new MemoryStream();
		GZipStream stream = new GZipStream(memoryStream, CompressionMode.Compress);
		StreamWriter streamWriter = new StreamWriter(stream);
		streamWriter.Write(str);
		streamWriter.Close();
		return memoryStream.ToArray();
	}

	private static string UnCompressString(byte[] bytes)
	{
		MemoryStream stream = new MemoryStream(bytes.ToArray());
		GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
		StreamReader streamReader = new StreamReader(stream2);
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		return result;
	}
}
