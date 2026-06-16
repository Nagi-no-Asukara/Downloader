using System;
using System.Globalization;
using System.Security;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace MegaDownloader;

public class Updater
{
	private enum Version
	{
		Binary,
		Installer,
		MSD
	}

	public static void ComprobarVersionMegadownloader(ref string UrlNuevaVersion, ref string Version)
	{
		string updateCheckURL = Conexion.GetUpdateCheckURL();
		if (string.IsNullOrEmpty(updateCheckURL))
		{
			return;
		}
		Conexion.Respuesta respuesta = Conexion.LeerURL(updateCheckURL);
		if (respuesta.Excepcion != null)
		{
			return;
		}
		XmlDocument DocumentoXML = new XmlDocument();
		try
		{
			DocumentoXML.LoadXml(respuesta.Mensaje);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error loading the version check XML: " + ex2.ToString());
			ProjectData.ClearProjectError();
			return;
		}
		double result = 0.0;
		double result2 = 0.0;
		string Path = "Version";
		if ((double.TryParse(LeerNodo(ref DocumentoXML, ref Path, ""), NumberStyles.Number, new CultureInfo("en-GB"), out result) & double.TryParse(InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_UPDATE"), NumberStyles.Number, new CultureInfo("en-GB"), out result2)) && result > result2)
		{
			string text = "Link";
			text = GetVersion() switch
			{
				Updater.Version.MSD => "LinkMSD", 
				Updater.Version.Installer => "LinkInstaller", 
				_ => "Link", 
			};
			UrlNuevaVersion = LeerNodo(ref DocumentoXML, ref text, "");
			if (string.IsNullOrEmpty(UrlNuevaVersion))
			{
				Path = "Link";
				UrlNuevaVersion = LeerNodo(ref DocumentoXML, ref Path, "");
			}
			Path = "Version";
			Version = LeerNodo(ref DocumentoXML, ref Path, "");
			Log.WriteInfo("There is a new version of MegaDownloader: " + Version + " - " + UrlNuevaVersion);
		}
	}

	private static Version GetVersion()
	{
		Version result;
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MegaDownloader", writable: false);
			result = ((registryKey != null && registryKey.GetValue("Installer") != null && Operators.CompareString(Conversions.ToString(registryKey.GetValue("Installer")), "1", TextCompare: false) == 0) ? Version.Installer : Version.Binary);
		}
		catch (SecurityException ex)
		{
			ProjectData.SetProjectError(ex);
			SecurityException ex2 = ex;
			Log.WriteError("SECURITY ERROR: Not enough privileges to access the registry. Installation check not possible, assume binaries.");
			result = Version.Binary;
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteError("Error accessing the registry for checking installation. Error: " + ex4.ToString());
			result = Version.Binary;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static string LeerNodo(ref XmlDocument DocumentoXML, ref string Path, string ValorDefecto)
	{
		XmlNode xmlNode = DocumentoXML.DocumentElement.SelectSingleNode(Path);
		if (xmlNode == null)
		{
			return ValorDefecto;
		}
		return xmlNode.InnerText;
	}
}
