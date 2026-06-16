using System.Collections.Generic;

namespace MegaDownloader;

public class LinkProtectors
{
	public static List<string> ExtraerURLs(string LixInURI)
	{
		if (!IsLinkProtector(LixInURI))
		{
			return new List<string>();
		}
		return Linkdecrypter.ExtraerURLs(LixInURI);
	}

	internal static bool IsLinkProtector(string URI)
	{
		if (!IsLixIn(URI))
		{
			return IsAdfly(URI);
		}
		return true;
	}

	private static bool IsLixIn(string URI)
	{
		if (string.IsNullOrEmpty(URI))
		{
			return false;
		}
		return URI.ToLower().Contains("lix.in/");
	}

	private static bool IsAdfly(string URI)
	{
		if (string.IsNullOrEmpty(URI))
		{
			return false;
		}
		return URI.ToLower().Contains("j.gs/") | URI.ToLower().Contains("q.gs/") | URI.ToLower().Contains("adf.ly/");
	}
}
