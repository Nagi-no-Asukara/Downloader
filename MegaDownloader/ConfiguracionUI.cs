using System;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class ConfiguracionUI
{
	public int AnchoVentanaPrincipal;

	public int AltoVentanaPrincipal;

	public byte[] EstadoLista;

	public string RutaSkin;

	public void ConfiguracionDefectoVacia()
	{
		AnchoVentanaPrincipal = 0;
		AltoVentanaPrincipal = 0;
	}

	public void CargarXML(XmlDocument XML)
	{
		AnchoVentanaPrincipal = 0;
		string Path = "ConfigUI/AnchoVentanaPrincipal";
		int.TryParse(LeerNodo(ref XML, ref Path, "0"), out AnchoVentanaPrincipal);
		AltoVentanaPrincipal = 0;
		Path = "ConfigUI/AltoVentanaPrincipal";
		int.TryParse(LeerNodo(ref XML, ref Path, "0"), out AltoVentanaPrincipal);
		Path = "ConfigUI/RutaSkin";
		RutaSkin = LeerNodo(ref XML, ref Path, "");
		Path = "ConfigUI/ConfigListaDescargas";
		string s = LeerNodo(ref XML, ref Path, "");
		try
		{
			EstadoLista = Convert.FromBase64String(s);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			EstadoLista = null;
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

	public void GuardarXML(ref XmlDocument XML)
	{
		string innerText = "";
		if (EstadoLista != null)
		{
			innerText = Convert.ToBase64String(EstadoLista);
		}
		XmlNode xmlNode = XML.DocumentElement.AppendChild(XML.CreateElement("ConfigUI"));
		xmlNode.AppendChild(XML.CreateElement("AnchoVentanaPrincipal")).InnerText = AnchoVentanaPrincipal.ToString();
		xmlNode.AppendChild(XML.CreateElement("AltoVentanaPrincipal")).InnerText = AltoVentanaPrincipal.ToString();
		xmlNode.AppendChild(XML.CreateElement("ConfigListaDescargas")).InnerText = innerText;
		xmlNode.AppendChild(XML.CreateElement("RutaSkin")).InnerText = RutaSkin;
	}
}
