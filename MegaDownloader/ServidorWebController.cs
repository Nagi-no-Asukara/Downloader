using System;
using System.Net;
using System.Net.NetworkInformation;
using HttpServer.HttpModules;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class ServidorWebController
{
	private static global::HttpServer.HttpServer _WebServer = null;

	private static global::HttpServer.HttpServer _WebServerStreaming = null;

	public static string StartWebServer(ref Main Downloader, Configuracion Config)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		string result;
		if (Config == null)
		{
			result = "";
		}
		else
		{
			if (!Config.ServidorWebActivo)
			{
				StopWebServer_RemoteController();
			}
			if (!Config.ServidorStreamingActivo)
			{
				StopWebServer_Streaming();
			}
			if ((_WebServer == null) & Config.ServidorWebActivo)
			{
				if (IsBusy(Config.ServidorWebPuerto))
				{
					result = "Port " + Conversions.ToString(Config.ServidorWebPuerto) + " is not valid or is in use.";
					goto IL_01e6;
				}
				try
				{
					_WebServer = new global::HttpServer.HttpServer();
					_WebServer.ServerName = "Internal";
					_WebServer.SessionCookieName = "Sd_session";
					_WebServer.Add((HttpModule)(object)new WebInterfaceModule(ref Downloader, Config.ServidorWebRutaPlantilla, Config.ServidorWebPassword, Config.ServidorWebNombre, checked(Config.ServidorWebTimeout * 60), Language.GetCurrentLanguageCode()));
					_WebServer.Start(IPAddress.Any, Config.ServidorWebPuerto);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					_WebServer = null;
					Log.WriteError("Error starting web server: " + ex2.ToString());
					result = ex2.Message;
					ProjectData.ClearProjectError();
					goto IL_01e6;
				}
			}
			if ((_WebServerStreaming == null) & Config.ServidorStreamingActivo)
			{
				if (IsBusy(Config.ServidorStreamingPuerto))
				{
					result = "Port " + Conversions.ToString(Config.ServidorStreamingPuerto) + " is not valid or is in use.";
					goto IL_01e6;
				}
				try
				{
					_WebServerStreaming = new global::HttpServer.HttpServer();
					_WebServerStreaming.ServerName = "Streaming";
					_WebServerStreaming.SessionCookieName = "Sd_session";
					_WebServerStreaming.Add((HttpModule)(object)new StreamingModule(ref Config));
					_WebServerStreaming.Add((HttpModule)(object)new StreamingLibraryModule(ref Downloader, ref Config));
					_WebServerStreaming.Start(IPAddress.Any, Config.ServidorStreamingPuerto);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					_WebServerStreaming = null;
					Log.WriteError("Error starting streaming web server: " + ex4.ToString());
					result = ex4.Message;
					ProjectData.ClearProjectError();
					goto IL_01e6;
				}
			}
			result = "";
		}
		goto IL_01e6;
		IL_01e6:
		return result;
	}

	public static void StopWebServer()
	{
		StopWebServer_RemoteController();
		StopWebServer_Streaming();
	}

	public static void StopWebServer_RemoteController()
	{
		try
		{
			if (_WebServer != null)
			{
				_WebServer.Stop();
				_WebServer = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error stopping web server: " + ex2.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static void StopWebServer_Streaming()
	{
		try
		{
			if (_WebServerStreaming != null)
			{
				_WebServerStreaming.Stop();
				_WebServerStreaming = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error stopping streaming web server: " + ex2.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private static bool IsBusy(int port)
	{
		IPEndPoint[] activeTcpListeners = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners();
		if (activeTcpListeners == null || activeTcpListeners.Length == 0)
		{
			return false;
		}
		checked
		{
			int num = activeTcpListeners.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (activeTcpListeners[i].Port == port)
				{
					return true;
				}
			}
			return false;
		}
	}
}
