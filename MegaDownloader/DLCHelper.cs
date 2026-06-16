using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace MegaDownloader;

public class DLCHelper
{
	public class DLCFileNotFound : ApplicationException
	{
		public DLCFileNotFound()
			: base("DLC/ELC file does not exists")
		{
		}
	}

	public class DLCFileIsEmpty : ApplicationException
	{
		public DLCFileIsEmpty()
			: base("DLC/ELC file is empty")
		{
		}
	}

	public static string ReadELC_File(string filePath)
	{
		if (!File.Exists(filePath))
		{
			throw new DLCFileNotFound();
		}
		StringBuilder stringBuilder = new StringBuilder();
		using (StreamReader streamReader = new StreamReader(filePath))
		{
			while (!streamReader.EndOfStream)
			{
				stringBuilder.Append(streamReader.ReadToEnd());
			}
		}
		if (stringBuilder.Length == 0)
		{
			throw new DLCFileIsEmpty();
		}
		return stringBuilder.ToString();
	}

	public static List<string> DecryptDLC_File(string filePath)
	{
		if (!File.Exists(filePath))
		{
			throw new DLCFileNotFound();
		}
		StringBuilder stringBuilder = new StringBuilder();
		using (StreamReader streamReader = new StreamReader(filePath))
		{
			while (!streamReader.EndOfStream)
			{
				stringBuilder.Append(streamReader.ReadToEnd());
			}
		}
		if (stringBuilder.Length == 0)
		{
			throw new DLCFileIsEmpty();
		}
		return DecryptDLC_Content(stringBuilder.ToString());
	}

	public static List<string> DecryptDLC_Content(string dlc_content)
	{
		NameValueCollection nameValueCollection = new NameValueCollection();
		nameValueCollection.Add("content", dlc_content);
		Conexion.Respuesta respuesta = Conexion.SendPOST("http://dcrypt.it/decrypt/paste", nameValueCollection, "application/x-www-form-urlencoded", SendAppId: false);
		if (respuesta.Excepcion != null)
		{
			throw respuesta.Excepcion;
		}
		if (!string.IsNullOrEmpty(respuesta.Mensaje) && respuesta.Mensaje.Contains("container is corrupted"))
		{
			throw new ApplicationException("DLC corrupted");
		}
		List<string> list = URLExtractor.ExtraerSoloURLsOficiales(respuesta.Mensaje);
		foreach (string item in list)
		{
			string text = URLExtractor.ExtraerFileID(item);
			string fileKey = URLExtractor.ExtraerFileKey(item);
			if (!string.IsNullOrEmpty(text))
			{
				string newValue = URLExtractor.GenerateEncodedURILink(text, fileKey, URLExtractor.IsMegaFolder(item), Compatibility: false);
				respuesta.Mensaje = respuesta.Mensaje.Replace(item, newValue);
			}
		}
		return URLExtractor.ExtraerURLs(respuesta.Mensaje);
	}
}
