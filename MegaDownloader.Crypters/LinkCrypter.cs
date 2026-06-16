using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace MegaDownloader.Crypters;

public class LinkCrypter
{
	public static bool IsLinkCrypter(string FileID)
	{
		if (string.IsNullOrEmpty(FileID))
		{
			return false;
		}
		return FileID.ToLower().StartsWith("linkcrypter.net".ToLower()) & (FileID.Split('$').Length == 3);
	}

	public static Conexion.InformacionFichero ObtenerInformacionFichero(Configuracion Config, string FileID, string FileKey, bool ComprobacionAntesDescarga)
	{
		if (!IsLinkCrypter(FileID))
		{
			throw new ApplicationException("Error, not LinkCrypter link");
		}
		string arg = "!" + FileID.Split('$')[1] + "!" + FileID.Split('$')[2];
		List<string> list = new List<string>();
		if (ComprobacionAntesDescarga)
		{
			if (string.IsNullOrEmpty(FileKey))
			{
				list.Add("info");
			}
			list.Add("dl");
		}
		else
		{
			list.Add("info");
		}
		Conexion.InformacionFichero informacionFichero = new Conexion.InformacionFichero();
		informacionFichero.FileID = FileID;
		informacionFichero.FileKey = FileKey;
		Conexion.InformacionFichero result;
		foreach (string item in list)
		{
			string jSON = $"{{\"link\":\"{arg}\",\"m\":\"{item}\"}}";
			Conexion.Respuesta respuesta = Conexion.SendJSON("https://linkcrypter.net/api", jSON, "", SendAppId: false);
			if (respuesta.Excepcion == null)
			{
				Dictionary<string, object> dictionary;
				try
				{
					string text = respuesta.Mensaje;
					if (text.StartsWith("["))
					{
						text = text.Substring(1);
					}
					if (text.EndsWith("]"))
					{
						text = text.Trim(']');
					}
					if (Versioned.IsNumeric(text))
					{
						throw new ApplicationException("Invalid LinkCrypter link (" + text + ")");
					}
					dictionary = (Dictionary<string, object>)JsonConvert.DeserializeObject(text, typeof(Dictionary<string, object>));
					if (dictionary.ContainsKey("error"))
					{
						throw new ApplicationException("Invalid LinkCrypter link (" + Conversions.ToString(dictionary["error"]) + ")");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteError("Error getting the info in LinkCrypter - Error: " + ex2.ToString());
					informacionFichero.Err = Conexion.TipoError.Otros;
					informacionFichero.Errtxt = "Error getting the info in LinkCrypter: " + ex2.Message;
					result = informacionFichero;
					ProjectData.ClearProjectError();
					goto IL_0359;
				}
				if (dictionary.ContainsKey("name"))
				{
					informacionFichero.Nombre = Conversions.ToString(dictionary["name"]);
				}
				if (dictionary.ContainsKey("key"))
				{
					informacionFichero.FileKey = Conversions.ToString(dictionary["key"]);
				}
				if (dictionary.ContainsKey("size"))
				{
					informacionFichero.Tamano = 0L;
					long.TryParse(Conversions.ToString(dictionary["size"]), out informacionFichero.Tamano);
				}
				if (dictionary.ContainsKey("url"))
				{
					informacionFichero.URL = Conversions.ToString(dictionary["url"]);
				}
				continue;
			}
			if (respuesta.Excepcion is WebException)
			{
				informacionFichero.Err = Conexion.TipoError.ErrorConexion;
				informacionFichero.Errtxt = "Connection error: " + respuesta.Excepcion.Message + " - Message received: " + respuesta.Mensaje;
				Log.WriteError("Error getting the info in LinkCrypter: " + respuesta.Excepcion.Message + " - Message received: " + respuesta.Mensaje);
				result = informacionFichero;
			}
			else
			{
				informacionFichero.Err = Conexion.TipoError.Otros;
				informacionFichero.Errtxt = "Description: " + respuesta.Excepcion.ToString() + " - Message received: " + respuesta.Mensaje;
				Log.WriteError("Error getting the info in LinkCrypter: " + respuesta.Excepcion.Message + " - Message received: " + respuesta.Mensaje);
				result = informacionFichero;
			}
			goto IL_0359;
		}
		result = informacionFichero;
		goto IL_0359;
		IL_0359:
		return result;
	}
}
