using System;
using System.Security;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class LibraryElement
{
	public const string HIDDEN_LINK = "{HIDDEN}";

	public const string HIDDEN_LINK_DESC = "** LINK NOT VISIBLE **";

	public string ID;

	public string Name;

	public string Description;

	public string Comments;

	public string Poster;

	public DateTime LastModification;

	public SecureString Link;

	public bool LinkVisible;

	public string IMDB;

	public string Allocine;

	public string Filmaffinity;

	private const string ExportPassword = "ae7}Kazdje/twiev";

	public LibraryElement()
	{
		LastModification = DateAndTime.Now;
	}

	public string ToJSON(string CurrentURL, ref Configuracion Config)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{");
		stringBuilder.Append("\"ID\":");
		stringBuilder.Append("\"" + (ID ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"Name\":");
		stringBuilder.Append("\"" + (Name ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"Desc\":");
		stringBuilder.Append("\"" + (Description ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"Com\":");
		stringBuilder.Append("\"" + (Comments ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"Poster\":");
		stringBuilder.Append("\"" + (Poster ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"IMDB\":");
		stringBuilder.Append("\"" + (IMDB ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"Filmaffinity\":");
		stringBuilder.Append("\"" + (Filmaffinity ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"Allocine\":");
		stringBuilder.Append("\"" + (Allocine ?? "").Replace("\"", "\\\"") + "\",");
		stringBuilder.Append("\"Date\":");
		stringBuilder.Append("\"" + LastModification.ToString("yyyy-MM-dd HH:mm") + "\",");
		stringBuilder.Append("\"Link\":");
		string text = "** LINK NOT VISIBLE **";
		if (LinkVisible)
		{
			text = Criptografia.ToInsecureString(Link);
		}
		stringBuilder.Append("\"" + text + "\",");
		stringBuilder.Append("\"VlcLink\":");
		stringBuilder.Append("\"" + StreamingHelper.CreateStreamingLinkFromLibrary(ID, CurrentURL, ref Config).Replace("\"", "\\\"") + "\"");
		stringBuilder.Append("}");
		return stringBuilder.ToString();
	}

	public void LoadXML(XmlNode XML, bool Import)
	{
		string Path = "ID";
		ID = LeerNodo(ref XML, ref Path, "");
		Path = "Name";
		Name = LeerNodo(ref XML, ref Path, "");
		Path = "Desc";
		Description = LeerNodo(ref XML, ref Path, "");
		Path = "Com";
		Comments = LeerNodo(ref XML, ref Path, "");
		Path = "Post";
		Poster = LeerNodo(ref XML, ref Path, "");
		Path = "IMDB";
		IMDB = LeerNodo(ref XML, ref Path, "");
		Path = "Filmaffinity";
		Filmaffinity = LeerNodo(ref XML, ref Path, "");
		Path = "Allocine";
		Allocine = LeerNodo(ref XML, ref Path, "");
		Path = "Link";
		string text = LeerNodo(ref XML, ref Path, "");
		if (!string.IsNullOrEmpty(text))
		{
			if (Import)
			{
				text = Criptografia.AES_DecryptString(text, "ae7}Kazdje/twiev");
			}
			else
			{
				Link = Criptografia.DecryptString_DPAPI(text);
				text = Criptografia.ToInsecureString(Link);
			}
			LinkVisible = !text.StartsWith("{HIDDEN}");
			text = text.Replace("{HIDDEN}", "");
			Link = Criptografia.ToSecureString(text);
		}
		else
		{
			Link = new SecureString();
		}
		LastModification = DateTime.MinValue;
		Path = "Date";
		text = LeerNodo(ref XML, ref Path, "");
		if (Information.IsDate(text))
		{
			LastModification = Conversions.ToDate(text);
		}
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

	public void SaveXML(ref XmlNode XML, bool Export)
	{
		XmlNode xmlNode = XML.AppendChild(XML.OwnerDocument.CreateElement("Element"));
		if (!Export)
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("ID")).InnerText = ID;
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Date")).InnerText = LastModification.ToString("s");
		}
		if (!string.IsNullOrEmpty(Name))
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Name")).InnerText = Name;
		}
		if (!string.IsNullOrEmpty(Description))
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Desc")).InnerText = Description;
		}
		if (!string.IsNullOrEmpty(Comments))
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Com")).InnerText = Comments;
		}
		if (!string.IsNullOrEmpty(Poster))
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Post")).InnerText = Poster;
		}
		if (!string.IsNullOrEmpty(IMDB))
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("IMDB")).InnerText = IMDB;
		}
		if (!string.IsNullOrEmpty(Filmaffinity))
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Filmaffinity")).InnerText = Filmaffinity;
		}
		if (!string.IsNullOrEmpty(Allocine))
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Allocine")).InnerText = Allocine;
		}
		string text = (LinkVisible ? "" : "{HIDDEN}") + Criptografia.ToInsecureString(Link);
		if (Export)
		{
			xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Link")).InnerText = Criptografia.AES_EncryptString(text, "ae7}Kazdje/twiev");
			return;
		}
		SecureString input = Criptografia.ToSecureString(text);
		xmlNode.AppendChild(XML.OwnerDocument.CreateElement("Link")).InnerText = Criptografia.EncryptString_DPAPI(input);
	}
}
