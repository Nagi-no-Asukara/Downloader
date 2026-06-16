using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class Language
{
	private static CultureInfo culture = CultureInfo.InvariantCulture;

	private static XmlDocument LanguageFileDisk = null;

	private static XmlDocument LanguageFileInternal = null;

	public static string GetCurrentLanguageCode()
	{
		return culture.Name;
	}

	public static bool IsValidLanguageCode(string CultureCode)
	{
		bool result;
		try
		{
			result = !string.IsNullOrEmpty(CultureInfo.GetCultureInfo(CultureCode).Name);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void InitLanguage(string CultureCode)
	{
		try
		{
			culture = CultureInfo.GetCultureInfo(CultureCode);
			if (string.IsNullOrEmpty(culture.Name))
			{
				throw new ApplicationException("Empty culture");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			culture = Thread.CurrentThread.CurrentUICulture;
			ProjectData.ClearProjectError();
		}
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Language");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
		foreach (string text2 in manifestResourceNames)
		{
			if (!text2.ToUpper().EndsWith("-Language.xml".ToUpper()))
			{
				continue;
			}
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text2);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(manifestResourceStream);
			string value = xmlDocument.DocumentElement.Attributes["id"].Value;
			string text3 = Path.Combine(text, value + ".xml");
			if (!File.Exists(text3))
			{
				xmlDocument.Save(text3);
			}
			else
			{
				XmlDocument xmlDocument2 = new XmlDocument();
				xmlDocument2.Load(text3);
				if (Operators.CompareString(xmlDocument2.OuterXml, xmlDocument.OuterXml, TextCompare: false) != 0)
				{
					File.Delete(text3);
					xmlDocument.Save(text3);
				}
			}
			if (Operators.CompareString(value.ToLowerInvariant(), culture.Name.ToLowerInvariant(), TextCompare: false) == 0)
			{
				LanguageFileInternal = xmlDocument;
			}
			else if ((value.ToLowerInvariant().Contains("-") & culture.Name.ToLowerInvariant().Contains("-")) && Operators.CompareString(value.ToLowerInvariant().Split('-')[0], culture.Name.ToLowerInvariant().Split('-')[0], TextCompare: false) == 0)
			{
				LanguageFileInternal = xmlDocument;
			}
			else if ((LanguageFileInternal == null) & (Operators.CompareString(value.ToLowerInvariant(), "en-us", TextCompare: false) == 0))
			{
				LanguageFileInternal = xmlDocument;
			}
		}
		if (LanguageFileInternal == null)
		{
			Log.WriteError("Internal error: LanguageFileInternal is nothing");
			throw new ApplicationException("LanguageFileInternal could not be intialized");
		}
		Log.WriteDebug("LanguageFileInternal loaded: " + LanguageFileInternal.DocumentElement.Attributes["id"].Value);
		string text4 = Path.Combine(text, culture.Name + ".xml");
		if (File.Exists(text4))
		{
			XmlDocument xmlDocument3 = new XmlDocument();
			xmlDocument3.Load(text4);
			LanguageFileDisk = xmlDocument3;
			Log.WriteDebug("LanguageFileDisk loaded from disk: " + LanguageFileDisk.DocumentElement.Attributes["id"].Value);
		}
		else
		{
			LanguageFileDisk = LanguageFileInternal;
			Log.WriteDebug("LanguageFileDisk loaded from LanguageFileInternal: " + LanguageFileDisk.DocumentElement.Attributes["id"].Value);
		}
	}

	private static string ProcessMsg(string msg)
	{
		return msg;
	}

	public static string GetText(string key)
	{
		XmlNode xmlNode = LanguageFileDisk.DocumentElement.SelectSingleNode("Text[@key='" + key + "']");
		if (xmlNode != null)
		{
			return ProcessMsg(xmlNode.InnerText);
		}
		Log.WriteDebug("Translation not found on disk: " + key);
		xmlNode = LanguageFileInternal.DocumentElement.SelectSingleNode("Text[@key='" + key + "']");
		if (xmlNode != null)
		{
			return ProcessMsg(xmlNode.InnerText);
		}
		Log.WriteDebug("Translation not found on disk and internal lang file: " + key);
		return ProcessMsg(key);
	}

	public static Dictionary<string, string> GetAvailableLanguages()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Language");
		if (Directory.Exists(path))
		{
			string[] files = Directory.GetFiles(path);
			foreach (string text in files)
			{
				if (!text.ToLower().EndsWith(".xml"))
				{
					continue;
				}
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(text);
					string value = xmlDocument.DocumentElement.Attributes["id"].Value;
					string value2 = xmlDocument.DocumentElement.Attributes["name"].Value;
					if (IsValidLanguageCode(value) && !dictionary.ContainsKey(value))
					{
						dictionary.Add(value, value2);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
			}
		}
		return dictionary;
	}

	public static void SaveTranslationReport()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string text = "en-US";
		string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
		foreach (string text2 in manifestResourceNames)
		{
			if (!text2.ToUpper().EndsWith("-Language.xml".ToUpper()))
			{
				continue;
			}
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text2);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(manifestResourceStream);
			if (Operators.CompareString(xmlDocument.DocumentElement.Attributes["id"].Value, text, TextCompare: false) != 0)
			{
				continue;
			}
			foreach (XmlNode item in xmlDocument.DocumentElement.SelectNodes("Text"))
			{
				string value = item.Attributes["key"].Value;
				string innerText = item.InnerText;
				dictionary[value] = innerText;
			}
		}
		string[] manifestResourceNames2 = Assembly.GetExecutingAssembly().GetManifestResourceNames();
		foreach (string text3 in manifestResourceNames2)
		{
			if (!text3.ToUpper().EndsWith("-Language.xml".ToUpper()))
			{
				continue;
			}
			Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream(text3);
			StringBuilder stringBuilder2 = new StringBuilder();
			XmlDocument xmlDocument2 = new XmlDocument();
			xmlDocument2.Load(manifestResourceStream2);
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			string value2 = xmlDocument2.DocumentElement.Attributes["id"].Value;
			foreach (XmlNode item2 in xmlDocument2.DocumentElement.SelectNodes("Text"))
			{
				string value3 = item2.Attributes["key"].Value;
				string innerText2 = item2.InnerText;
				dictionary2[value3] = innerText2;
			}
			foreach (string key in dictionary.Keys)
			{
				if (!dictionary2.ContainsKey(key))
				{
					if (stringBuilder2.Length == 0)
					{
						stringBuilder2.AppendLine("\r\n");
						stringBuilder2.AppendLine("Missing text in " + value2 + " that is present in " + text + ": \r\n");
					}
					stringBuilder2.AppendLine("<Text key=\"" + key.Replace("&", "&amp;") + "\"><![CDATA[" + dictionary[key] + "]]></Text>");
				}
			}
			if (stringBuilder2.Length > 0)
			{
				stringBuilder.AppendLine(stringBuilder2.ToString());
			}
		}
		if (stringBuilder.Length > 0)
		{
			Log.WriteError("\r\nTRANSLATION REPORT\r\n" + stringBuilder.ToString());
		}
	}
}
