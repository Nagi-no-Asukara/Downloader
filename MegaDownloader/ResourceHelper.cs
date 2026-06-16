using System.Reflection;

namespace MegaDownloader;

public class ResourceHelper
{
	public static string GetResourceName(string EndsWith)
	{
		if (string.IsNullOrEmpty(EndsWith))
		{
			return "";
		}
		string[] manifestResourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
		foreach (string text in manifestResourceNames)
		{
			if (text.ToUpper().EndsWith(EndsWith.ToUpper()))
			{
				return text;
			}
		}
		return "";
	}
}
