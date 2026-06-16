using System;
using System.Collections.Generic;

namespace MegaDownloader;

public class URLProcessor
{
	public class FileURL
	{
		public string URL;

		public string Path;

		public FileURL(string pURL, string pPath)
		{
			URL = pURL;
			Path = pPath;
		}
	}

	public static List<FileURL> ProcessURLs(List<string> URLs, ref Configuracion Config)
	{
		List<string> list = new List<string>();
		foreach (string URL in URLs)
		{
			if (LinkProtectors.IsLinkProtector(URL))
			{
				list.AddRange(LinkProtectors.ExtraerURLs(URL));
			}
			else
			{
				list.Add(URL);
			}
		}
		List<FileURL> list2 = new List<FileURL>();
		foreach (string item in list)
		{
			if (URLExtractor.IsMegaFolder(item))
			{
				string folderID = URLExtractor.ExtraerFileID(item);
				string folderKey = URLExtractor.ExtraerFileKey(item);
				foreach (FileURL item2 in MegaFolderHelper.RetrieveLinksFromFolder(folderID, folderKey))
				{
					list2.Add(item2);
				}
			}
			else if (URLExtractor.IsELC(item))
			{
				Exception Exc = null;
				foreach (string item3 in ServerEncoderLinkHelper.ServerDecode(item, ref Config, ref Exc))
				{
					if (URLExtractor.IsMegaFolder(item3))
					{
						string folderID2 = URLExtractor.ExtraerFileID(item3);
						string folderKey2 = URLExtractor.ExtraerFileKey(item3);
						foreach (FileURL item4 in MegaFolderHelper.RetrieveLinksFromFolder(folderID2, folderKey2))
						{
							list2.Add(new FileURL("{HIDDEN}" + item4.URL, item4.Path));
						}
					}
					else
					{
						list2.Add(new FileURL("{HIDDEN}" + item3, ""));
					}
				}
				if (Exc != null)
				{
					throw Exc;
				}
			}
			else
			{
				list2.Add(new FileURL(item, ""));
			}
		}
		return list2;
	}
}
