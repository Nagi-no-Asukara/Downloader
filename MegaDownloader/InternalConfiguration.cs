using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class InternalConfiguration
{
	private static XmlDocument XML_CONFIG;

	public static string ObtenerValueFromInternalConfig(string Key)
	{
		try
		{
			XmlDocument xmlDocument = XML_CONFIG;
			if (xmlDocument == null)
			{
				xmlDocument = (XML_CONFIG = GetXmlConfig());
			}
			XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode(Key);
			if (xmlNode == null)
			{
				return "";
			}
			return xmlNode.InnerText;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw;
		}
	}

	public static List<KeyValuePair<string, string>> ObtenerValuesFromInternalConfig(string Key)
	{
		try
		{
			XmlDocument xmlDocument = XML_CONFIG;
			if (xmlDocument == null)
			{
				xmlDocument = (XML_CONFIG = GetXmlConfig());
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			foreach (XmlNode item2 in xmlDocument.DocumentElement.SelectNodes(Key))
			{
				if (item2 != null && item2.Attributes["key"] != null)
				{
					KeyValuePair<string, string> item = new KeyValuePair<string, string>(item2.Attributes["key"].Value, item2.InnerText);
					list.Add(item);
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw;
		}
	}

	private static XmlDocument GetXmlConfig()
	{
		string resourceName = ResourceHelper.GetResourceName(".InternalConfig.xml");
		if (string.IsNullOrEmpty(resourceName))
		{
			throw new ApplicationException("InternalConfig could not be loaded");
		}
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
		string text = string.Empty;
		using (StreamReader streamReader = new StreamReader(manifestResourceStream))
		{
			text = streamReader.ReadToEnd();
		}
		if (!text.StartsWith("<"))
		{
			text = Encoding.UTF8.GetString(Convert.FromBase64String(text));
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		return xmlDocument;
	}

	public static string ObtenerNombreApp()
	{
		return ObtenerValueFromInternalConfig("TITULO_MAIN");
	}
}
