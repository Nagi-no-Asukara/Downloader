using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace MegaDownloader;

public class MegaFolderHelper
{
	public class FileListResponse
	{
		public string e;

		public object ok;

		public object u;

		public string sn;

		public List<FileNode> f;
	}

	public class FileNode
	{
		public string h;

		public string p;

		public string u;

		public int t;

		public string a;

		public string k;

		public long s;

		public long ts;
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__4_002D0
	{
		public Dictionary<string, KeyValuePair<string, string>> _0024VB_0024Local_unprocessed;

		public string _0024VB_0024Local_id;

		public Func<string, bool> _0024I0;

		public _Closure_0024__4_002D0(_Closure_0024__4_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_unprocessed = arg0._0024VB_0024Local_unprocessed;
				_0024VB_0024Local_id = arg0._0024VB_0024Local_id;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(string n)
		{
			return Operators.CompareString(_0024VB_0024Local_unprocessed[n].Value, _0024VB_0024Local_id, TextCompare: false) == 0;
		}
	}

	public static List<URLProcessor.FileURL> RetrieveLinksFromFolder(string FolderID, string FolderKey)
	{
		bool flag = FolderID.StartsWith("fenc?") | FolderID.StartsWith("fenc2?");
		URLExtractor.CheckFileIDAndFileKey(ref FolderID, ref FolderKey);
		string jSON = "[{\"a\":\"f\",\"c\":1,\"r\":1}]";
		Conexion.Respuesta respuesta = Conexion.SendJSON(Conexion.Get_MEGA_API_Url("") + "&n=" + FolderID, jSON);
		if (respuesta.Excepcion != null)
		{
			throw new ApplicationException("Error getting file list from shared folder - " + respuesta.Excepcion.ToString());
		}
		if (Versioned.IsNumeric(respuesta.Mensaje))
		{
			throw MEGA_ErrorHandler.GetErrorFromMegaResponse(respuesta.Mensaje, "getting file list from shared folder");
		}
		FileListResponse fileListResponse = (FileListResponse)JsonConvert.DeserializeObject(respuesta.Mensaje.Trim('[', ']'), typeof(FileListResponse));
		fileListResponse = fileListResponse;
		List<URLProcessor.FileURL> list = new List<URLProcessor.FileURL>();
		Dictionary<string, KeyValuePair<string, string>> dictionary = new Dictionary<string, KeyValuePair<string, string>>();
		string id = "";
		checked
		{
			foreach (FileNode item in fileListResponse.f)
			{
				if (item.t != 1)
				{
					continue;
				}
				string h = item.h;
				string pData = item.k.Substring(item.k.IndexOf(':') + 1);
				pData = Criptografia.a32_to_base64(Criptografia.decrypt_key(Criptografia.base64_to_a32(pData), Criptografia.base64_to_a32(FolderKey)));
				string text = PreSharedKeyManager.DecryptFileInfo(item.a, pData);
				Regex regex = new Regex("MEGA.*?\"n\"\\s*:\\s*\"(?<FileName>.*?)\"");
				if (!string.IsNullOrEmpty(text) && regex.IsMatch(text))
				{
					text = regex.Match(text).Groups["FileName"].Value;
					dictionary.Add(h, new KeyValuePair<string, string>(text, (Operators.CompareString(h, item.k.Substring(0, item.k.IndexOf(':')), TextCompare: false) == 0) ? "" : item.p));
					if (Operators.CompareString(h, item.k.Substring(0, item.k.IndexOf(':')), TextCompare: false) == 0)
					{
						id = h;
					}
				}
			}
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			FillFolderStructure(id, dictionary2, dictionary);
			foreach (FileNode item2 in fileListResponse.f)
			{
				if (item2.t != 0)
				{
					continue;
				}
				string pData2 = item2.k.Substring(item2.k.IndexOf(':') + 1);
				string pPath = string.Empty;
				if (dictionary2.ContainsKey(item2.p))
				{
					pPath = dictionary2[item2.p];
				}
				pData2 = Criptografia.a32_to_base64(Criptografia.decrypt_key(Criptografia.base64_to_a32(pData2), Criptografia.base64_to_a32(FolderKey)));
				string text2 = PreSharedKeyManager.DecryptFileInfo(item2.a, pData2);
				try
				{
					Regex regex2 = new Regex("MEGA.*?\"n\"\\s*:\\s*\"(?<FileName>.*?)\"");
					if (!string.IsNullOrEmpty(text2) && regex2.IsMatch(text2))
					{
						text2 = regex2.Match(text2).Groups["FileName"].Value;
						if (flag)
						{
							string pURL = URLExtractor.GenerateEncodedURILink("N?" + item2.h, pData2 + "=###n=" + FolderID, MegaFolder: false, Compatibility: false);
							list.Add(new URLProcessor.FileURL(pURL, pPath));
						}
						else
						{
							string pURL2 = $"http://mega.co.nz/#N!{item2.h}!{pData2}=###n={FolderID}";
							list.Add(new URLProcessor.FileURL(pURL2, pPath));
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					throw;
				}
			}
			return list;
		}
	}

	private static void FillFolderStructure(string id, Dictionary<string, string> final, Dictionary<string, KeyValuePair<string, string>> unprocessed)
	{
		_Closure_0024__4_002D0 arg = default(_Closure_0024__4_002D0);
		_Closure_0024__4_002D0 CS_0024_003C_003E8__locals14 = new _Closure_0024__4_002D0(arg);
		CS_0024_003C_003E8__locals14._0024VB_0024Local_id = id;
		CS_0024_003C_003E8__locals14._0024VB_0024Local_unprocessed = unprocessed;
		if (!CS_0024_003C_003E8__locals14._0024VB_0024Local_unprocessed.ContainsKey(CS_0024_003C_003E8__locals14._0024VB_0024Local_id))
		{
			return;
		}
		string value = CS_0024_003C_003E8__locals14._0024VB_0024Local_unprocessed[CS_0024_003C_003E8__locals14._0024VB_0024Local_id].Value;
		if (!string.IsNullOrEmpty(value))
		{
			string path = final[value];
			final.Add(CS_0024_003C_003E8__locals14._0024VB_0024Local_id, Path.Combine(path, CS_0024_003C_003E8__locals14._0024VB_0024Local_unprocessed[CS_0024_003C_003E8__locals14._0024VB_0024Local_id].Key));
		}
		else
		{
			final.Add(CS_0024_003C_003E8__locals14._0024VB_0024Local_id, "");
		}
		foreach (string item in CS_0024_003C_003E8__locals14._0024VB_0024Local_unprocessed.Keys.Where([SpecialName] (string n) => Operators.CompareString(CS_0024_003C_003E8__locals14._0024VB_0024Local_unprocessed[n].Value, CS_0024_003C_003E8__locals14._0024VB_0024Local_id, TextCompare: false) == 0))
		{
			FillFolderStructure(item, final, CS_0024_003C_003E8__locals14._0024VB_0024Local_unprocessed);
		}
	}
}
