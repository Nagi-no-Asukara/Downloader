using System;
using System.Collections.Generic;
using System.Security;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class PreSharedKeyManager
{
	public static List<string> GetFileKeyFromPreSharedKeys(ref Configuracion Config)
	{
		List<string> list = new List<string>();
		foreach (SecureString listaPreSharedKey in Config.ListaPreSharedKeys)
		{
			list.Add(Criptografia.GetFileKeyFromPreSharedKey(Criptografia.ToInsecureString(listaPreSharedKey)));
		}
		return list;
	}

	public static string DecryptFileInfo(string EncryptedFileInfo, string FileKey)
	{
		string text = null;
		if (FileKey.Contains("=###n="))
		{
			FileKey = FileKey.Substring(0, FileKey.IndexOf("=###n="));
		}
		string result;
		try
		{
			text = Criptografia.AES_MEGA_DecryptString(EncryptedFileInfo, FileKey) ?? "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = null;
			ProjectData.ClearProjectError();
			goto IL_005f;
		}
		result = (text.ToUpperInvariant().StartsWith("MEGA") ? text : null);
		goto IL_005f;
		IL_005f:
		return result;
	}
}
