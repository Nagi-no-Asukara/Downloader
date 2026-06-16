using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class URLExtractor
{
	private static byte[] ENC_XOR = new byte[9] { 12, 57, 251, 120, 18, 75, 6, 250, 85 };

	public const string ENCODE_PASSWORD = "k1o6Al-1kz¿!z05y";

	public const string ENCODE_PASSWORD2 = "nYrXa@9Q¿1&hCWM\\9(731Bp?t42=!k3.";

	public const string MEGASEARCHPREFIX = "mega-search?";

	public const string ENCODEDPREFIX = "enc?";

	public const string ENCODEDPREFIX2 = "enc2?";

	public const string FOLDERENCODEDPREFIX = "fenc?";

	public const string FOLDERENCODEDPREFIX2 = "fenc2?";

	public const string SERVERENCODEDPREFIX = "elc?";

	public const string MEGACRYPTERTOKEN = "megacrypter.com";

	public const string YOUPASTETOKEN = "youpaste.co";

	public const string ENCRYPTERMEGATOKEN = "encrypterme.ga";

	public const string LINKCRYPTERTOKEN = "linkcrypter.net";

	private static readonly string[] patternHTTPURI = new string[5] { "(http://|https://|)mega.co.nz/(?<MODE2>#|#F|#N)!(?<FileID>[^\\!]+)(!(?<FileKey>[\\w-#=]+))?", "(http://|https://|)mega.nz/(?<MODE2>#|#F|#N)!(?<FileID>[^\\!]+)(!(?<FileKey>[\\w-#=]+))?", "(http://|https://|)mega.nz/(?<MODE2>file|folder)/(?<FileID>[^\\#]+)(#(?<FileKey>[\\w-#=]+))?", "(http://|https://|)megashur.se/out.php\\?m=(?<FileID>[^\\!]+)(!(?<FileKey>[\\w-#=]+))?", "chrome://mega/content/secure.html(?<MODE2>#|#F|#N)!(?<FileID>[^\\!]+)(!(?<FileKey>[\\w-#=]+))?" };

	private static readonly string[] patternMEGAURI = new string[7] { "(?<TAG>mega)(?<MODE1>://|:///|:)(?<MODE2>#|#F|F|#N|N)!(?<FileID>[^\\!]+)(!(?<FileKey>[\\w-#=]+))?", "(?<TAG>mega)(?<MODE1>://|:///|:)(?<MODE2>file|folder|#file|#folder)/(?<FileID>[^\\#]+)(#(?<FileKey>[\\w-#=]+))?", "(?<TAG>mega)(?<MODE1>://|:///|:)(?<MEGASEARCH>mega-search(\\?|/\\?))(?<MEGASEARCH_FILEID>[\\w-#=]+)", "(?<TAG>mega)(?<MODE1>://|:///|:)(?<BASIC_ENCODE>enc(\\?|/\\?))(?<ENCODED_FILEID>[\\w-#=]+)", "(?<TAG>mega)(?<MODE1>://|:///|:)(?<BASIC_ENCODE>enc2(\\?|/\\?))(?<ENCODED_FILEID>[\\w-#=]+)", "(?<TAG>mega)(?<MODE1>://|:///|:)(?<BASIC_ENCODE>fenc(\\?|/\\?))(?<ENCODED_FILEID>[\\w-#=]+)", "(?<TAG>mega)(?<MODE1>://|:///|:)(?<BASIC_ENCODE>fenc2(\\?|/\\?))(?<ENCODED_FILEID>[\\w-#=]+)" };

	private static readonly string[] patternELCUri = new string[1] { "(?<TAG>mega)(?<MODE1>://|:///|:)(?<BASIC_ENCODE>elc(\\?|/\\?))(?<ENCODED_FILEID>[\\w-]+)" };

	private static readonly string[] patternOthers = new string[8] { "(http://|https://|)megacrypter.com/!(?<MEGACRYPTER1>[^\\!]+)(!(?<MEGACRYPTER2>[\\w-]+))?", "(http://|https://|)youpaste.co/!(?<YOUPASTE1>[^\\!]+)(!(?<YOUPASTE2>[\\w-]+))?", "(http://|https://|)linkcrypter.net/!(?<CRYPTER1>[^\\!]+)(!(?<CRYPTER2>[\\w-]+))?", "(http://|https://|)encrypterme.ga/!(?<ENCRYPTERMEGA1>[^\\!]+)(!(?<ENCRYPTERMEGA2>[\\w-]+))?", "(http://|https://|)lix.in/(?<LINKPROTECTOR>[-,0-9a-zA-Z]+)", "(http://|https://|)j.gs/(?<LINKPROTECTOR>[-,0-9a-zA-Z/]+)", "(http://|https://|)q.gs/(?<LINKPROTECTOR>[-,0-9a-zA-Z/]+)", "(http://|https://|)adf.ly/(?<LINKPROTECTOR>[-,0-9a-zA-Z/]+)" };

	private static readonly string[] patternElcConfig = new string[1] { "(?<TAG>mega)(?<MODE1>://|:///|:)(?<BASIC_ENCODE>configelc(\\?|/\\?))(?<ENCODED_CONFIG>[^\\s]+)" };

	private static string[] patternGetInfoURL()
	{
		return patternHTTPURI.Concat(patternMEGAURI).Concat(patternELCUri).Concat(patternOthers)
			.ToArray();
	}

	internal static bool IsMegaFolder(string URI)
	{
		bool flag = false;
		if (string.IsNullOrEmpty(URI))
		{
			return false;
		}
		flag = URI.Contains("mega.co.nz/#F!") | URI.Contains("mega.nz/#F!") | URI.Contains("chrome://mega/content/secure.html#F!");
		if (!flag)
		{
			string[] array = patternGetInfoURL();
			foreach (string pattern in array)
			{
				Regex regex = new Regex(pattern);
				if (!regex.IsMatch(URI))
				{
					continue;
				}
				Match match = regex.Match(URI);
				if (!string.IsNullOrEmpty(match.Groups["MODE2"].Value))
				{
					switch (match.Groups["MODE2"].Value)
					{
					case "#F":
					case "F":
					case "#folder":
					case "folder":
						break;
					default:
						continue;
					}
					flag = true;
					break;
				}
				if (!string.IsNullOrEmpty(match.Groups["BASIC_ENCODE"].Value) && match.Groups["BASIC_ENCODE"].Value.StartsWith("fenc"))
				{
					flag = true;
					break;
				}
			}
		}
		return flag;
	}

	internal static bool IsELC(string URI)
	{
		string[] array = patternELCUri;
		foreach (string pattern in array)
		{
			if (new Regex(pattern).IsMatch(URI))
			{
				return true;
			}
		}
		return false;
	}

	public static List<string> ExtraerSoloURLsOficiales(string Texto)
	{
		HashSet<string> hashSet = new HashSet<string>();
		if (Texto == null)
		{
			return hashSet.ToList();
		}
		string[] array = patternHTTPURI;
		foreach (string pattern in array)
		{
			MatchCollection matchCollection = new Regex(pattern, RegexOptions.IgnoreCase).Matches(Texto);
			foreach (Match item in matchCollection)
			{
				string text = item.Value.Trim();
				if (!string.IsNullOrEmpty(ExtraerFileID(text)))
				{
					hashSet.Add(text);
				}
			}
		}
		return hashSet.ToList();
	}

	public static List<string> ExtraerConfiguracionELC(string Texto)
	{
		HashSet<string> hashSet = new HashSet<string>();
		if (string.IsNullOrEmpty(Texto))
		{
			return hashSet.ToList();
		}
		string[] array = patternElcConfig;
		foreach (string pattern in array)
		{
			MatchCollection matchCollection = new Regex(pattern, RegexOptions.IgnoreCase).Matches(Texto);
			foreach (Match item in matchCollection)
			{
				string value = item.Groups["ENCODED_CONFIG"].Value;
				if (!string.IsNullOrEmpty(value))
				{
					string text = value.Replace("\\:", "{TEMP_PUNTOS}");
					if ((text.Split(':').Length == 3) | (text.Split(':').Length == 4))
					{
						hashSet.Add(value);
					}
				}
			}
		}
		return hashSet.ToList();
	}

	public static List<string> ExtraerURLs(string Texto)
	{
		HashSet<string> hashSet = new HashSet<string>();
		if (string.IsNullOrEmpty(Texto))
		{
			return hashSet.ToList();
		}
		string[] array = patternHTTPURI;
		MatchCollection matchCollection;
		foreach (string pattern in array)
		{
			matchCollection = new Regex(pattern, RegexOptions.IgnoreCase).Matches(Texto);
			foreach (Match item in matchCollection)
			{
				string text = item.Value.Trim();
				if (!string.IsNullOrEmpty(ExtraerFileID(text)))
				{
					hashSet.Add(text);
				}
				else if (EsUrlAcortador(text))
				{
					text = Conexion.ObtenerUrlDesdeAcortador(text);
					if (!string.IsNullOrEmpty(ExtraerFileID(text)))
					{
						hashSet.Add(text);
					}
				}
			}
		}
		matchCollection = new Regex("(?<TAG>mega)(?<MODE>://|:///|:)(?<DATA>[\\w-/#!:.?]+)", RegexOptions.IgnoreCase).Matches(Texto);
		foreach (Match item2 in matchCollection)
		{
			string value = item2.Groups["DATA"].Value;
			string text2 = item2.Value.Trim();
			if (!string.IsNullOrEmpty(value) && value.Length > 5)
			{
				if (value.ToLower().StartsWith("mega-search?") | value.ToLower().StartsWith("enc?") | value.ToLower().StartsWith("fenc?") | value.ToLower().StartsWith("enc2?") | value.ToLower().StartsWith("fenc2?") | value.ToLower().StartsWith("elc?"))
				{
					hashSet.Add(text2);
				}
				else if (!string.IsNullOrEmpty(ExtraerFileID(text2)))
				{
					hashSet.Add(text2);
				}
				else if (!string.IsNullOrEmpty(ExtraerFileID(value)))
				{
					hashSet.Add(text2);
				}
			}
		}
		string[] array2 = patternOthers;
		foreach (string pattern2 in array2)
		{
			matchCollection = new Regex(pattern2, RegexOptions.IgnoreCase).Matches(Texto);
			foreach (Match item3 in matchCollection)
			{
				string text3 = item3.Value.Trim();
				if (text3.ToLower().Contains("megacrypter.com".ToLower()))
				{
					string value2 = item3.Groups["MEGACRYPTER1"].Value;
					string value3 = item3.Groups["MEGACRYPTER2"].Value;
					if (!string.IsNullOrEmpty(value2) & !string.IsNullOrEmpty(value3))
					{
						hashSet.Add(text3);
					}
				}
				if (text3.ToLower().Contains("youpaste.co".ToLower()))
				{
					string value4 = item3.Groups["YOUPASTE1"].Value;
					string value5 = item3.Groups["YOUPASTE2"].Value;
					if (!string.IsNullOrEmpty(value4) & !string.IsNullOrEmpty(value5))
					{
						hashSet.Add(text3);
					}
				}
				if (text3.ToLower().Contains("encrypterme.ga".ToLower()))
				{
					string value6 = item3.Groups["ENCRYPTERMEGA1"].Value;
					string value7 = item3.Groups["ENCRYPTERMEGA2"].Value;
					if (!string.IsNullOrEmpty(value6) & !string.IsNullOrEmpty(value7))
					{
						hashSet.Add(text3);
					}
				}
				if (text3.ToLower().Contains("linkcrypter.net".ToLower()))
				{
					string value8 = item3.Groups["CRYPTER1"].Value;
					string value9 = item3.Groups["CRYPTER2"].Value;
					if (!string.IsNullOrEmpty(value8) & !string.IsNullOrEmpty(value9))
					{
						hashSet.Add(text3);
					}
				}
				if (!string.IsNullOrEmpty(item3.Groups["LINKPROTECTOR"].Value))
				{
					hashSet.Add(text3);
				}
			}
		}
		return hashSet.ToList();
	}

	public static bool EsUrlAcortador(string URL)
	{
		if (string.IsNullOrEmpty(URL))
		{
			return false;
		}
		if (URL.ToLower().Contains("bit.ly"))
		{
			return true;
		}
		if (URL.ToLower().Contains("goo.gl"))
		{
			return true;
		}
		return false;
	}

	public static void CheckFileIDAndFileKey(ref string FileID, ref string FileKey)
	{
		if (!string.IsNullOrEmpty(FileID))
		{
			FileID = FileID.Replace("/?", "?");
		}
		checked
		{
			if ((string.IsNullOrEmpty(FileKey) & !string.IsNullOrEmpty(FileID)) && FileID.StartsWith("mega-search?"))
			{
				string uRL = Conexion.ObtenerUrlDesdeAcortador(InternalConfiguration.ObtenerValueFromInternalConfig("MEGA_SEARCH_CURL") + FileID.Substring(FileID.IndexOf("mega-search?") + "mega-search?".Length));
				string text = ExtraerFileID(uRL);
				string text2 = ExtraerFileKey(uRL);
				if (!string.IsNullOrEmpty(text))
				{
					FileID = text;
					FileKey = text2;
				}
			}
			else
			{
				if (!(string.IsNullOrEmpty(FileKey) & !string.IsNullOrEmpty(FileID)) || !(FileID.StartsWith("enc?") | FileID.StartsWith("fenc?") | FileID.StartsWith("enc2?") | FileID.StartsWith("fenc2?")))
				{
					return;
				}
				string text3 = (FileID.StartsWith("fenc2?") ? FileID.Substring(FileID.IndexOf("fenc2?") + "fenc2?".Length) : (FileID.StartsWith("fenc?") ? FileID.Substring(FileID.IndexOf("fenc?") + "fenc?".Length) : ((!FileID.StartsWith("enc2?")) ? FileID.Substring(FileID.IndexOf("enc?") + "enc?".Length) : FileID.Substring(FileID.IndexOf("enc2?") + "enc2?".Length))));
				text3 += "==".Substring((2 - text3.Length * 3) & 3);
				text3 = text3.Replace("-", "+").Replace("_", "/").Replace(",", "");
				bool flag = FileID.StartsWith("fenc?") | FileID.StartsWith("fenc2?");
				string text4 = (flag ? "F" : "") + Criptografia.AES_DecryptString(text3, "k1o6Al-1kz¿!z05y");
				if (!text4.StartsWith("mega:"))
				{
					text4 = "mega://#" + text4;
				}
				string text5 = ExtraerFileID(text4);
				string text6 = ExtraerFileKey(text4);
				if (!string.IsNullOrEmpty(text5) & !HasNonPrintableCharacters(text5))
				{
					FileID = text5;
					FileKey = text6;
					return;
				}
				text4 = (flag ? "F" : "") + Criptografia.AES_DecryptString(text3, getENC2Bytes(), Encoding.ASCII);
				if (!text4.StartsWith("mega:"))
				{
					text4 = "mega://#" + text4;
				}
				text5 = ExtraerFileID(text4);
				text6 = ExtraerFileKey(text4);
				if (!string.IsNullOrEmpty(text5))
				{
					FileID = text5;
					FileKey = text6;
				}
			}
		}
	}

	private static bool HasNonPrintableCharacters(string F)
	{
		List<char> list = Path.GetInvalidFileNameChars().ToList();
		list.Remove('?');
		foreach (char item in F)
		{
			if (list.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	private static byte[] getENC2Bytes()
	{
		string text = "nYrXa@9Q¿1&hCWM\\9(731Bp?t42=!k3.";
		int num = Strings.Len(text);
		if (num >= 32)
		{
			text = Strings.Left(text, 32);
		}
		else
		{
			num = Strings.Len(text);
			int number = checked(32 - num);
			text += Strings.StrDup(number, "X");
		}
		byte[] bytes = Encoding.ASCII.GetBytes(text.ToCharArray());
		int num2 = 0;
		do
		{
			bytes[num2 % bytes.Length] = (byte)(bytes[num2 % bytes.Length] ^ ENC_XOR[num2 % ENC_XOR.Length]);
			num2 = checked(num2 + 1);
		}
		while (num2 <= 159);
		return bytes;
	}

	public static string GenerateEncodedURILink(string FileID, string FileKey, bool MegaFolder, bool Compatibility)
	{
		string vstrTextToBeEncrypted = "!" + FileID + "!" + FileKey;
		string text = null;
		text = ((!Compatibility) ? Criptografia.AES_EncryptString(vstrTextToBeEncrypted, getENC2Bytes(), Encoding.ASCII) : Criptografia.AES_EncryptString(vstrTextToBeEncrypted, "k1o6Al-1kz¿!z05y"));
		text = text.Replace("+", "-").Replace("/", "_").Replace("=", "");
		return "mega://" + (MegaFolder ? "fenc2?" : "enc2?") + text;
	}

	public static string ExtraerFileID(string URL)
	{
		if (string.IsNullOrEmpty(URL))
		{
			return "";
		}
		URL = URL.Replace("%21", "!");
		URL = URL.Replace("%20", "");
		string[] array = patternGetInfoURL();
		foreach (string pattern in array)
		{
			Regex regex = new Regex(pattern);
			if (!regex.IsMatch(URL))
			{
				continue;
			}
			Match match = regex.Match(URL);
			if (!string.IsNullOrEmpty(match.Groups["MEGASEARCH_FILEID"].Value))
			{
				return match.Groups["MEGASEARCH"].Value + match.Groups["MEGASEARCH_FILEID"].Value.Trim('/');
			}
			if (!string.IsNullOrEmpty(match.Groups["ENCODED_FILEID"].Value))
			{
				return match.Groups["BASIC_ENCODE"].Value + match.Groups["ENCODED_FILEID"].Value.Trim('/');
			}
			if (!string.IsNullOrEmpty(match.Groups["MEGACRYPTER1"].Value) & !string.IsNullOrEmpty(match.Groups["MEGACRYPTER2"].Value))
			{
				return "megacrypter.com$" + match.Groups["MEGACRYPTER1"].Value + "$" + match.Groups["MEGACRYPTER2"].Value;
			}
			if (!string.IsNullOrEmpty(match.Groups["YOUPASTE1"].Value) & !string.IsNullOrEmpty(match.Groups["YOUPASTE2"].Value))
			{
				return "youpaste.co$" + match.Groups["YOUPASTE1"].Value + "$" + match.Groups["YOUPASTE2"].Value;
			}
			if (!string.IsNullOrEmpty(match.Groups["CRYPTER1"].Value) & !string.IsNullOrEmpty(match.Groups["CRYPTER2"].Value))
			{
				return "linkcrypter.net$" + match.Groups["CRYPTER1"].Value + "$" + match.Groups["CRYPTER2"].Value;
			}
			if (!string.IsNullOrEmpty(match.Groups["ENCRYPTERMEGA1"].Value) & !string.IsNullOrEmpty(match.Groups["ENCRYPTERMEGA2"].Value))
			{
				return "encrypterme.ga$" + match.Groups["ENCRYPTERMEGA1"].Value + "$" + match.Groups["ENCRYPTERMEGA2"].Value;
			}
			string text = match.Groups["FileID"].Value ?? "";
			if (!string.IsNullOrEmpty(match.Groups["MODE2"].Value))
			{
				string value = match.Groups["MODE2"].Value;
				if (Operators.CompareString(value, "#N", TextCompare: false) == 0 || Operators.CompareString(value, "N", TextCompare: false) == 0)
				{
					text = "N?" + text;
				}
			}
			return text;
		}
		return string.Empty;
	}

	public static string ExtraerFileKey(string URL)
	{
		if (string.IsNullOrEmpty(URL))
		{
			return "";
		}
		URL = URL.Replace("%21", "!");
		URL = URL.Replace("%20", "");
		string[] array = patternGetInfoURL();
		foreach (string pattern in array)
		{
			Regex regex = new Regex(pattern);
			if (regex.IsMatch(URL))
			{
				string text = regex.Match(URL).Groups["FileKey"].Value ?? "";
				if ((text.Length < 40) & !IsMegaFolder(URL))
				{
					return string.Empty;
				}
				if (text.Contains(" "))
				{
					text = text.Replace(" ", "");
				}
				return text;
			}
		}
		return string.Empty;
	}
}
