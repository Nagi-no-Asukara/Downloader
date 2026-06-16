using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace MegaDownloader;

public class ServerEncoderLinkHelper
{
	public class MegaLink
	{
		public string FileID;

		public string FileKey;

		public bool MegaFolder;
	}

	private const string ENCODE_PASSWORD = "tal.vApsg@i0smae";

	public static string ServerEncode(string URL, List<MegaLink> LinkList, ref Configuracion Config)
	{
		ELCAccountHelper eLCAccountHelper = new ELCAccountHelper(ref Config);
		checked
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (LinkList != null)
				{
					foreach (MegaLink Link in LinkList)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("|");
						}
						stringBuilder.Append("#" + (Link.MegaFolder ? "F" : "") + "!" + Link.FileID + "!" + Link.FileKey);
					}
				}
				string s = stringBuilder.ToString();
				byte[] array = new byte[24];
				RandomNumberGenerator.Create().GetBytes(array);
				string text = Convert.ToBase64String(array);
				byte[] array2 = Cipher(Decrypt: false, Encoding.UTF8.GetBytes(s), array);
				byte[] bytes = Encoding.UTF8.GetBytes(URL);
				if ((Operators.CompareString(URL, "REVERSE", TextCompare: false) == 0) | (Operators.CompareString(URL, "HIDDEN", TextCompare: false) == 0))
				{
					text = new string(text.Reverse().ToArray());
				}
				else
				{
					ELCAccountHelper.Account accountDetailsByURL = eLCAccountHelper.GetAccountDetailsByURL(URL);
					if (accountDetailsByURL == null)
					{
						Log.WriteDebug("ELC Account not found for [" + URL + "]");
						throw new ApplicationException(Language.GetText("ELC Account not found. You need a valid ELC Account configured for this ELC."));
					}
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection.Add("OPERATION_TYPE", "E");
					nameValueCollection.Add("DATA", text);
					nameValueCollection.Add("USER", Criptografia.ToInsecureString(accountDetailsByURL.User));
					nameValueCollection.Add("APIKEY", Criptografia.ToInsecureString(accountDetailsByURL.Key));
					string uRL = URL;
					if (URLExtractor.EsUrlAcortador(uRL))
					{
						uRL = Conexion.ObtenerUrlDesdeAcortador(uRL);
					}
					Conexion.Respuesta respuesta = Conexion.SendPOST(uRL, nameValueCollection);
					if (respuesta.Excepcion != null)
					{
						throw new ApplicationException("Error contacting the server to encode string [" + URL + "]", respuesta.Excepcion);
					}
					Dictionary<string, object> dictionary = (Dictionary<string, object>)JsonConvert.DeserializeObject(respuesta.Mensaje, typeof(Dictionary<string, object>));
					if (dictionary.ContainsKey("e") && dictionary["e"] != null && !string.IsNullOrEmpty(Conversions.ToString(dictionary["e"])))
					{
						throw new ApplicationException("Server returned error - " + Conversions.ToString(dictionary["e"]));
					}
					if (!dictionary.ContainsKey("d"))
					{
						return string.Empty;
					}
					text = Conversions.ToString(dictionary["d"]);
				}
				byte[] bytes2 = Encoding.UTF8.GetBytes(text);
				int value = array2.Length;
				short value2 = (short)bytes.Length;
				short value3 = (short)bytes2.Length;
				List<byte> list = new List<byte>();
				list.AddRange(BitConverter.GetBytes(value));
				list.AddRange(array2);
				list.AddRange(BitConverter.GetBytes(value2));
				list.AddRange(bytes);
				list.AddRange(BitConverter.GetBytes(value3));
				list.AddRange(bytes2);
				List<byte> list2 = CompressBytes(list.ToArray()).ToList();
				if (list2.Count < list.Count)
				{
					list = list2;
					list.Insert(0, 112);
				}
				else
				{
					list.Insert(0, 185);
				}
				return Convert.ToBase64String(list.ToArray()).Replace("+", "-").Replace("/", "_")
					.Replace("=", "");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw;
			}
			finally
			{
				eLCAccountHelper.Dispose();
			}
		}
	}

	public static List<string> ServerDecode(string link, ref Configuracion Config, ref Exception Exc)
	{
		ELCAccountHelper eLCAccountHelper = new ELCAccountHelper(ref Config);
		string text = link;
		List<string> list = new List<string>();
		checked
		{
			List<string> result;
			try
			{
				string text2;
				List<byte> range;
				if (string.IsNullOrEmpty(link))
				{
					result = list;
				}
				else
				{
					if (link.Contains("elc?"))
					{
						link = link.Substring(link.IndexOf("elc?") + "elc?".Length);
					}
					if (link.Contains("elc?".Replace("?", "/?")))
					{
						link = link.Substring(link.IndexOf("elc?".Replace("?", "/?")) + "elc?".Replace("?", "/?").Length);
					}
					link += "==".Substring((2 - link.Length * 3) & 3);
					link = link.Replace("-", "+").Replace("_", "/").Replace(",", "");
					List<byte> list2 = Convert.FromBase64String(link).ToList();
					bool flag = false;
					switch (list2[0])
					{
					case 112:
						list2 = list2.GetRange(1, list2.Count - 1);
						flag = true;
						break;
					case 185:
						list2 = list2.GetRange(1, list2.Count - 1);
						break;
					default:
						result = list;
						goto end_IL_000f;
					}
					if (flag)
					{
						list2 = UnCompressBytes(list2.ToArray()).ToList();
					}
					int num = BitConverter.ToInt32(list2.ToArray(), 0);
					range = list2.GetRange(4, num);
					short num2 = BitConverter.ToInt16(list2.ToArray(), 4 + num);
					List<byte> range2 = list2.GetRange(4 + num + 2, num2);
					short count = BitConverter.ToInt16(list2.ToArray(), 4 + num + 2 + num2);
					List<byte> range3 = list2.GetRange(4 + num + 2 + num2 + 2, count);
					text2 = Encoding.UTF8.GetString(range3.ToArray());
					string text3 = Encoding.UTF8.GetString(range2.ToArray());
					if ((Operators.CompareString(text3, "REVERSE", TextCompare: false) == 0) | (Operators.CompareString(text3, "HIDDEN", TextCompare: false) == 0))
					{
						text2 = new string(text2.Reverse().ToArray());
						goto IL_03a3;
					}
					ELCAccountHelper.Account accountDetailsByURL = eLCAccountHelper.GetAccountDetailsByURL(text3);
					if (accountDetailsByURL == null)
					{
						Log.WriteDebug("ELC Account not found for [" + text3 + "]");
						throw new ApplicationException(Language.GetText("ELC Account not found. You need a valid ELC Account configured for this ELC."));
					}
					NameValueCollection nameValueCollection = new NameValueCollection();
					nameValueCollection.Add("OPERATION_TYPE", "D");
					nameValueCollection.Add("DATA", text2);
					nameValueCollection.Add("USER", Criptografia.ToInsecureString(accountDetailsByURL.User));
					nameValueCollection.Add("APIKEY", Criptografia.ToInsecureString(accountDetailsByURL.Key));
					string uRL = text3;
					if (URLExtractor.EsUrlAcortador(uRL))
					{
						uRL = Conexion.ObtenerUrlDesdeAcortador(uRL);
					}
					Conexion.Respuesta respuesta = Conexion.SendPOST(uRL, nameValueCollection);
					if (respuesta.Excepcion != null)
					{
						throw new ApplicationException("Error contacting the server to decode string [" + text3 + "]", respuesta.Excepcion);
					}
					Dictionary<string, object> dictionary = (Dictionary<string, object>)JsonConvert.DeserializeObject(respuesta.Mensaje, typeof(Dictionary<string, object>));
					if (dictionary.ContainsKey("e") && dictionary["e"] != null && !string.IsNullOrEmpty(Conversions.ToString(dictionary["e"])))
					{
						throw new ApplicationException("Server returned error - " + Conversions.ToString(dictionary["e"]));
					}
					if (dictionary.ContainsKey("d"))
					{
						text2 = Conversions.ToString(dictionary["d"]);
						goto IL_03a3;
					}
					result = list;
				}
				goto end_IL_000f;
				IL_03a3:
				range = Trim0s(Cipher(Decrypt: true, range.ToArray(), Convert.FromBase64String(text2)).ToList());
				string[] array = Encoding.UTF8.GetString(range.ToArray()).Split('|');
				foreach (string text4 in array)
				{
					if (!string.IsNullOrEmpty(text4))
					{
						list.Add("mega://" + text4.Trim());
					}
				}
				result = list;
				end_IL_000f:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error trying to decrypt the server-encoded string " + text + " - Error: " + ex2.ToString());
				Exc = ex2;
				result = list;
				ProjectData.ClearProjectError();
			}
			finally
			{
				eLCAccountHelper.Dispose();
			}
			return result;
		}
	}

	private static List<byte> Trim0s(List<byte> BinaryList)
	{
		int num = BinaryList.FindIndex([SpecialName] (byte x) => x == 0);
		if (num > 0)
		{
			BinaryList.RemoveRange(num, checked(BinaryList.Count - num));
		}
		return BinaryList;
	}

	private static byte[] Cipher(bool Decrypt, byte[] Data, byte[] Key)
	{
		using AesManaged aesManaged = new AesManaged();
		aesManaged.KeySize = 128;
		aesManaged.BlockSize = 128;
		aesManaged.Key = Key.Take(16).ToArray();
		aesManaged.IV = new byte[16]
		{
			Key[16],
			Key[17],
			Key[18],
			Key[19],
			Key[20],
			Key[21],
			Key[22],
			Key[23],
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
		aesManaged.Mode = CipherMode.CBC;
		aesManaged.Padding = PaddingMode.Zeros;
		ICryptoTransform transform;
		if (Decrypt)
		{
			transform = aesManaged.CreateDecryptor(aesManaged.Key, aesManaged.IV);
			using MemoryStream stream = new MemoryStream(Data);
			using CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			byte[] array = new byte[checked(Data.Length - 1 + 1)];
			cryptoStream.Read(array, 0, array.Length);
			try
			{
				cryptoStream.FlushFinalBlock();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return array;
		}
		transform = aesManaged.CreateEncryptor(aesManaged.Key, aesManaged.IV);
		using MemoryStream memoryStream = new MemoryStream();
		using CryptoStream cryptoStream2 = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		cryptoStream2.Write(Data, 0, Data.Length);
		cryptoStream2.FlushFinalBlock();
		return memoryStream.ToArray();
	}

	private static byte[] CompressBytes(byte[] bytes)
	{
		using MemoryStream src = new MemoryStream(bytes);
		using MemoryStream memoryStream = new MemoryStream();
		using (GZipStream dest = new GZipStream(memoryStream, CompressionMode.Compress))
		{
			CopyTo(src, dest);
		}
		return memoryStream.ToArray();
	}

	private static byte[] UnCompressBytes(byte[] bytes)
	{
		using MemoryStream stream = new MemoryStream(bytes);
		using MemoryStream memoryStream = new MemoryStream();
		using (GZipStream src = new GZipStream(stream, CompressionMode.Decompress))
		{
			CopyTo(src, memoryStream);
		}
		return memoryStream.ToArray();
	}

	private static void CopyTo(Stream src, Stream dest)
	{
		byte[] array = new byte[1024];
		int num;
		do
		{
			num = src.Read(array, 0, array.Length);
			if (num != 0)
			{
				dest.Write(array, 0, num);
			}
		}
		while (num > 0);
	}
}
