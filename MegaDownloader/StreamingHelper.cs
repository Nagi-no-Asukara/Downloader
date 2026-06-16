using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class StreamingHelper
{
	private static Dictionary<string, string> TempStreamingCache = new Dictionary<string, string>();

	public static bool WatchOnline(string VLCPath, string URLStreamning)
	{
		if (string.IsNullOrEmpty(VLCPath))
		{
			return false;
		}
		string path = "vlc.exe";
		if (!File.Exists(Path.Combine(VLCPath, path)))
		{
			path = "vlcportable.exe";
		}
		if (!File.Exists(Path.Combine(VLCPath, path)))
		{
			return false;
		}
		Process process = new Process();
		process.StartInfo.FileName = Path.Combine(VLCPath, path);
		process.StartInfo.Arguments = URLStreamning;
		process.Start();
		return true;
	}

	public static bool GetFileDataFromTempID(string TempID, ref string FileID, ref string FileKey)
	{
		if (!TempStreamingCache.ContainsKey(TempID))
		{
			return false;
		}
		string text = TempStreamingCache[TempID];
		if (string.IsNullOrEmpty(text) || !text.Contains("|"))
		{
			return false;
		}
		FileID = text.Split('|')[0];
		FileKey = text.Split('|')[1];
		return true;
	}

	public static string CreateStreamingLink(string URLMega, int StreamingPort, ref Configuracion Config)
	{
		List<URLProcessor.FileURL> list = URLProcessor.ProcessURLs(new List<string> { URLMega }, ref Config);
		if (list.Count > 1)
		{
			MessageBox.Show(Language.GetText("The link is a folder with %NUM files. Now only the first will be used, if you want to use all, import the link into the streaming library.").Replace("%NUM", list.Count.ToString()), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else if (list.Count == 0)
		{
			return string.Empty;
		}
		string text = Fichero.ExtraerFileID(list[0].URL);
		string text2 = Fichero.ExtraerFileKey(list[0].URL);
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		string text3 = text + "|" + text2;
		string text4 = "";
		if (TempStreamingCache.ContainsKey(text3))
		{
			text4 = TempStreamingCache[text3];
		}
		else
		{
			text4 = ((double)TempStreamingCache.Keys.Count / 2.0 + 1.0).ToString();
			TempStreamingCache[text3] = text4;
			TempStreamingCache[text4] = text3;
		}
		string text5 = "http://localhost:";
		text5 += Conversions.ToString(StreamingPort);
		text5 = text5 + "/streaming?t=" + text4;
		if (!string.IsNullOrEmpty(Config.ServidorStreamingPassword))
		{
			text5 = text5 + "&p=" + Config.ServidorStreamingPassword;
		}
		return text5;
	}

	public static string CreateStreamingLinkFromLibrary(string ID, string CurrentURL, ref Configuracion Config)
	{
		if (StreamingLibraryManager.GetElementByID(ID) == null)
		{
			return string.Empty;
		}
		string text = "http://" + CurrentURL;
		text = text + "/streaming?id=" + ID;
		if (!string.IsNullOrEmpty(Config.ServidorStreamingPassword))
		{
			text = text + "&p=" + Config.ServidorStreamingPassword;
		}
		return text;
	}

	public static string LibraryManagerURL(int StreamingPort, bool Manage)
	{
		string text = "http://localhost:";
		text += Conversions.ToString(StreamingPort);
		if (Manage)
		{
			return text + "/manage";
		}
		return text + "/library";
	}
}
