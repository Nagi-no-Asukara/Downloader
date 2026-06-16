using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class StreamingLibrary
{
	private List<LibraryElement> _LibraryElementList;

	private int _NextID;

	public StreamingLibrary()
	{
		Init();
	}

	public void Init()
	{
		_LibraryElementList = new List<LibraryElement>();
		_NextID = 1;
	}

	public List<LibraryElement> Elements()
	{
		return _LibraryElementList;
	}

	public int GetIDandIncrement()
	{
		int nextID = _NextID;
		checked
		{
			_NextID++;
			return nextID;
		}
	}

	public void LoadXML()
	{
		string text = ObtenerRutaFicheroConfiguracion();
		if (!File.Exists(text))
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		Mutex.GuardarConfig.WaitOne();
		try
		{
			xmlDocument.Load(text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error loading streaming library: " + ex2.ToString());
			ProjectData.ClearProjectError();
			return;
		}
		finally
		{
			Mutex.GuardarConfig.ReleaseMutex();
		}
		Init();
		if (xmlDocument.DocumentElement.SelectSingleNode("Elements") != null && xmlDocument.DocumentElement.SelectSingleNode("Elements").Attributes["nextID"] != null && Versioned.IsNumeric(xmlDocument.DocumentElement.SelectSingleNode("Elements").Attributes["nextID"].Value))
		{
			_NextID = Conversions.ToInteger(xmlDocument.DocumentElement.SelectSingleNode("Elements").Attributes["nextID"].Value);
		}
		foreach (XmlNode item in xmlDocument.DocumentElement.SelectNodes("Elements/Element"))
		{
			LibraryElement libraryElement = new LibraryElement();
			libraryElement.LoadXML(item, Import: false);
			_LibraryElementList.Add(libraryElement);
		}
	}

	public void SaveXML()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode XML = xmlDocument.AppendChild(xmlDocument.CreateElement("XML")).AppendChild(xmlDocument.CreateElement("Elements"));
		XML.Attributes.Append(xmlDocument.CreateAttribute("nextID")).Value = _NextID.ToString();
		foreach (LibraryElement item in Elements())
		{
			item.SaveXML(ref XML, Export: false);
		}
		string filename = ObtenerRutaFicheroConfiguracion();
		Mutex.GuardarConfig.WaitOne();
		try
		{
			xmlDocument.Save(filename);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error saving streaming library: " + ex2.ToString());
			ProjectData.ClearProjectError();
		}
		finally
		{
			Mutex.GuardarConfig.ReleaseMutex();
		}
	}

	private static string ObtenerRutaFicheroConfiguracion()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Library");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return Path.Combine(text, "StreamingLibrary.xml");
	}
}
