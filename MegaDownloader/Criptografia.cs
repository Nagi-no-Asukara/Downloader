using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

namespace MegaDownloader;

public class Criptografia
{
	public class SicSeekableBlockCipher : IBlockCipher
	{
		private readonly IBlockCipher cipher;

		private readonly int blockSize;

		private readonly byte[] IV;

		private readonly byte[] counter;

		private readonly byte[] counterOut;

		public string AlgorithmName => cipher.AlgorithmName + "/SIC";

		public bool IsPartialBlockOkay => true;

		public SicSeekableBlockCipher(IBlockCipher cipher)
		{
			this.cipher = cipher;
			blockSize = cipher.GetBlockSize();
			checked
			{
				IV = new byte[blockSize - 1 + 1];
				counter = new byte[blockSize - 1 + 1];
				counterOut = new byte[blockSize - 1 + 1];
			}
		}

		public IBlockCipher GetUnderlyingCipher()
		{
			return cipher;
		}

		public void Init(bool forEncryption, ICipherParameters parameters)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Expected O, but got Unknown
			if (parameters is ParametersWithIV)
			{
				ParametersWithIV val = (ParametersWithIV)parameters;
				Array.Copy(val.GetIV(), 0, IV, 0, IV.Length);
				Reset();
				cipher.Init(true, val.Parameters);
				return;
			}
			throw new ArgumentException("SIC mode requires ParametersWithIV", "parameters");
		}

		public int GetBlockSize()
		{
			return cipher.GetBlockSize();
		}

		public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			cipher.ProcessBlock(counter, 0, counterOut, 0);
			int num = checked(counterOut.Length - 1);
			for (int i = 0; i <= num; i = checked(i + 1))
			{
				output[checked(outOff + i)] = (byte)(counterOut[i] ^ input[checked(inOff + i)]);
			}
			IncrementCounter();
			return counter.Length;
		}

		public void Reset()
		{
			Array.Copy(IV, 0, counter, 0, counter.Length);
			cipher.Reset();
		}

		public void IncrementCounter(int NumberOfIncrements = 1)
		{
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Expected O, but got Unknown
			checked
			{
				if (NumberOfIncrements < 16)
				{
					int num = NumberOfIncrements;
					for (int i = 1; i <= num; i++)
					{
						int num2 = counter.Length - 1;
						if (num2 >= 0)
						{
							counter[num2] = (byte)((counter[num2] + 1 <= 255) ? (counter[num2] + 1) : 0);
						}
						while (num2 >= 0 && counter[num2] == 0)
						{
							num2--;
							if (num2 >= 0)
							{
								counter[num2] = (byte)((counter[num2] + 1 <= 255) ? (counter[num2] + 1) : 0);
							}
						}
					}
					return;
				}
				List<byte> list = new BigInteger(counter).Add(new BigInteger(NumberOfIncrements.ToString())).ToByteArray().ToList();
				if (list.Count < 16)
				{
					for (int j = list.Count + 1; j <= 16; j++)
					{
						list.Insert(0, 0);
					}
				}
				Array.Copy(list.ToArray(), 0, counter, 0, counter.Length);
			}
		}
	}

	private static byte[] entropy = Encoding.Unicode.GetBytes("G*SNAfhHW5A¿Amck+XMLCM6M#$xEK;9q");

	public static string EncryptString_DPAPI(SecureString input)
	{
		return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(ToInsecureString(input)), entropy, DataProtectionScope.CurrentUser));
	}

	public static SecureString DecryptString_DPAPI(string encryptedData)
	{
		SecureString result;
		try
		{
			byte[] bytes = ProtectedData.Unprotect(Convert.FromBase64String(encryptedData), entropy, DataProtectionScope.CurrentUser);
			result = ToSecureString(Encoding.Unicode.GetString(bytes));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = new SecureString();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static SecureString ToSecureString(string input)
	{
		SecureString secureString = new SecureString();
		foreach (char c in input)
		{
			secureString.AppendChar(c);
		}
		secureString.MakeReadOnly();
		return secureString;
	}

	public static string ToInsecureString(SecureString input)
	{
		string empty = string.Empty;
		IntPtr intPtr = Marshal.SecureStringToBSTR(input);
		try
		{
			return Marshal.PtrToStringBSTR(intPtr);
		}
		finally
		{
			Marshal.ZeroFreeBSTR(intPtr);
		}
	}

	public static string AES_EncryptString(string vstrTextToBeEncrypted, string vstrEncryptionKey)
	{
		return AES_EncryptString(vstrTextToBeEncrypted, vstrEncryptionKey, Encoding.ASCII);
	}

	public static string AES_EncryptString(string vstrTextToBeEncrypted, string vstrEncryptionKey, Encoding Encoding)
	{
		int num = Strings.Len(vstrEncryptionKey);
		if (num >= 32)
		{
			vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32);
		}
		else
		{
			num = Strings.Len(vstrEncryptionKey);
			int number = checked(32 - num);
			vstrEncryptionKey += Strings.StrDup(number, "X");
		}
		byte[] bytes = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray());
		return AES_EncryptString(vstrTextToBeEncrypted, bytes, Encoding);
	}

	public static string AES_EncryptString(string vstrTextToBeEncrypted, byte[] bytKey, Encoding Encoding)
	{
		byte[] inArray = null;
		byte[] rgbIV = new byte[16]
		{
			121, 241, 10, 1, 132, 74, 11, 39, 255, 91,
			45, 78, 14, 211, 22, 62
		};
		MemoryStream memoryStream = new MemoryStream();
		vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted ?? "");
		byte[] bytes = Encoding.GetBytes(vstrTextToBeEncrypted.ToCharArray());
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		try
		{
			CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(bytKey, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return Convert.ToBase64String(inArray);
	}

	public static string AES_DecryptString(string vstrStringToBeDecrypted, string vstrDecryptionKey)
	{
		return AES_DecryptString(vstrStringToBeDecrypted, vstrDecryptionKey, Encoding.ASCII);
	}

	public static string AES_DecryptString(string vstrStringToBeDecrypted, string vstrDecryptionKey, Encoding Encoding)
	{
		int num = Strings.Len(vstrDecryptionKey);
		if (num >= 32)
		{
			vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32);
		}
		else
		{
			num = Strings.Len(vstrDecryptionKey);
			int number = checked(32 - num);
			vstrDecryptionKey += Strings.StrDup(number, "X");
		}
		byte[] bytes = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray());
		return AES_DecryptString(vstrStringToBeDecrypted, bytes, Encoding);
	}

	public static string AES_DecryptString(string vstrStringToBeDecrypted, byte[] bytDecryptionKey, Encoding Encoding)
	{
		byte[] rgbIV = new byte[16]
		{
			121, 241, 10, 1, 132, 74, 11, 39, 255, 91,
			45, 78, 14, 211, 22, 62
		};
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		_ = string.Empty;
		byte[] array = Convert.FromBase64String(vstrStringToBeDecrypted);
		byte[] array2 = new byte[checked(array.Length + 1)];
		MemoryStream memoryStream = new MemoryStream(array);
		try
		{
			CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(bytDecryptionKey, rgbIV), CryptoStreamMode.Read);
			cryptoStream.Read(array2, 0, array2.Length);
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
			memoryStream.Close();
			cryptoStream.Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return StripNullCharacters(Encoding.GetString(array2));
	}

	private static string StripNullCharacters(string vstrStringWithNulls)
	{
		int num = 1;
		string text = vstrStringWithNulls;
		while (num > 0)
		{
			num = Strings.InStr(num, vstrStringWithNulls, "\0");
			if (num > 0)
			{
				text = checked(Strings.Left(text, num - 1) + Strings.Right(text, Strings.Len(text) - num));
			}
			if (num > text.Length)
			{
				break;
			}
		}
		return text;
	}

	internal static string GetFileKeyFromPreSharedKey(string PreSharedKey)
	{
		byte[] bytes = GetBytes(PreSharedKey.PadRight(24, '#').Substring(0, 24));
		byte[] array = IntArrayToBytesArray(new int[6] { -1815844893, 2108737444, -776061055, 22203222, 1885434739, 2003792484 });
		if (bytes.Length == array.Length)
		{
			int num = checked(bytes.Length - 1);
			for (int i = 0; i <= num; i = checked(i + 1))
			{
				bytes[i] = (byte)(bytes[i] ^ checked((byte)i));
				bytes[i] ^= array[i];
			}
		}
		int[] array2 = ByteArrayToIntArray(bytes);
		return a32_to_base64(new int[8]
		{
			array2[0] ^ array2[4],
			array2[1] ^ array2[5],
			array2[2],
			array2[3],
			array2[4],
			array2[5],
			0,
			0
		});
	}

	private static byte[] GetBytes(string str)
	{
		List<byte> list = new List<byte>();
		foreach (char value in str)
		{
			list.Add(BitConverter.GetBytes(value)[0]);
		}
		return list.ToArray();
	}

	private static string a32_to_str(int[] a)
	{
		string text = "";
		checked
		{
			int num = a.Length * 4 - 1;
			for (int i = 0; i <= num; i++)
			{
				int i2 = a[i >> 2];
				int j = 24 - (i & 3) * 8;
				int charCode = ZFRS(i2, j) & 0xFF;
				text += Conversions.ToString(Strings.ChrW(charCode));
			}
			return text;
		}
	}

	private static int ZFRS(int i, int j)
	{
		bool num = i < 0;
		i >>= j;
		if (num)
		{
			i &= 0x7FFFFFFF;
		}
		return i;
	}

	internal static SicSeekableBlockCipher GetInstaceCipher(string pKey)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		int[] array = ByteArrayToIntArray(B64Decode(pKey));
		int[] array2 = new int[6]
		{
			array[0] ^ array[4],
			array[1] ^ array[5],
			array[2] ^ array[6],
			array[3] ^ array[7],
			array[4],
			array[5]
		};
		byte[] array3 = IntArrayToBytesArray(new int[4]
		{
			array2[0],
			array2[1],
			array2[2],
			array2[3]
		});
		byte[] array4 = IntArrayToBytesArray(new int[4]
		{
			array2[4],
			array2[5],
			0,
			0
		});
		SicSeekableBlockCipher sicSeekableBlockCipher = new SicSeekableBlockCipher((IBlockCipher)new AesEngine());
		ParametersWithIV parameters = new ParametersWithIV((ICipherParameters)new KeyParameter(array3), array4);
		sicSeekableBlockCipher.Init(forEncryption: false, (ICipherParameters)(object)parameters);
		return sicSeekableBlockCipher;
	}

	internal static string AES_MEGA_DecryptString(string pEnc, string pKey)
	{
		int[] array = ByteArrayToIntArray(B64Decode(pKey));
		byte[] pKey2 = ((array.Length != 4) ? IntArrayToBytesArray(new int[4]
		{
			array[0] ^ array[4],
			array[1] ^ array[5],
			array[2] ^ array[6],
			array[3] ^ array[7]
		}) : IntArrayToBytesArray(new int[4]
		{
			array[0],
			array[1],
			array[2],
			array[3]
		}));
		byte[] pIV = IntArrayToBytesArray(new int[4]);
		byte[] array2 = B64Decode(pEnc);
		checked
		{
			int num = 16 - ((array2.Length - 1) & 0xF) - 1;
			byte[] array3 = new byte[array2.Length + (num - 1) + 1];
			Array.Copy(array2, 0, array3, 0, array2.Length);
			return DecryptStringFromBytesAes(array3, pKey2, pIV);
		}
	}

	private static string DecryptStringFromBytesAes(byte[] pCipherText, byte[] pKey, byte[] pIV)
	{
		if (pCipherText == null || pCipherText.Length <= 0)
		{
			throw new ArgumentNullException("pCipherText");
		}
		if (pKey == null || pKey.Length <= 0)
		{
			throw new ArgumentNullException("pKey");
		}
		if (pIV == null || pIV.Length <= 0)
		{
			throw new ArgumentNullException("pIV");
		}
		string text = null;
		using Aes aes = Aes.Create();
		aes.Mode = CipherMode.CBC;
		aes.Padding = PaddingMode.None;
		aes.Key = pKey;
		aes.IV = pIV;
		ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
		using MemoryStream stream = new MemoryStream(pCipherText);
		using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
		using StreamReader streamReader = new StreamReader(stream2);
		return streamReader.ReadToEnd();
	}

	internal static int[] decrypt_key(int[] Data, int[] keyhash)
	{
		checked
		{
			using AesManaged aesManaged = new AesManaged();
			aesManaged.KeySize = 128;
			aesManaged.BlockSize = 128;
			aesManaged.Key = IntArrayToBytesArrayREVERSE(keyhash);
			aesManaged.IV = new byte[16];
			aesManaged.Mode = CipherMode.CBC;
			aesManaged.Padding = PaddingMode.Zeros;
			byte[] array = IntArrayToBytesArrayREVERSE(Data);
			byte[] array2 = new byte[array.Length - 1 + 1];
			int num = array.Length - 1;
			int inputBlockSize = aesManaged.CreateDecryptor().InputBlockSize;
			for (int i = 0; ((inputBlockSize >> 31) ^ i) <= ((inputBlockSize >> 31) ^ num); i += inputBlockSize)
			{
				ICryptoTransform cryptoTransform = aesManaged.CreateDecryptor();
				cryptoTransform.TransformBlock(array, i, cryptoTransform.InputBlockSize, array2, i);
			}
			return ByteArrayToIntArrayREVERSE(array2);
		}
	}

	internal static int[] ByteArrayToIntArrayREVERSE(byte[] pBytes)
	{
		checked
		{
			int[] array = new int[(int)Math.Ceiling((double)pBytes.Count() / 4.0) - 1 + 1];
			int num = 0;
			int num2 = (int)Math.Round((double)pBytes.Length / 4.0) - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (4 * (i + 1) <= pBytes.Length)
				{
					List<byte> list = new List<byte>();
					int num3 = i * 4 + 3;
					int num4 = i * 4;
					for (int j = num3; j >= num4; j += -1)
					{
						list.Add(pBytes[j]);
					}
					array[num] = BitConverter.ToInt32(list.ToArray(), 0);
					num++;
				}
			}
			return array;
		}
	}

	private static byte[] IntArrayToBytesArrayREVERSE(IEnumerable<int> pInts)
	{
		checked
		{
			byte[] array = new byte[pInts.Count() * 4 - 1 + 1];
			int num = 0;
			foreach (int pInt in pInts)
			{
				byte[] bytes = BitConverter.GetBytes(pInt);
				for (int i = bytes.Length - 1; i >= 0; i += -1)
				{
					array[num] = bytes[i];
					num++;
				}
			}
			return array;
		}
	}

	internal static int[] base64_to_a32(string pData)
	{
		return str_to_a32(base64urldecode(pData));
	}

	internal static string a32_to_base64(int[] a)
	{
		return EncodeTo64(a32_to_str(a)).Replace("+", "-").Replace("/", "_").Replace("=", "");
	}

	private static string EncodeTo64(string toEncode)
	{
		return Convert.ToBase64String(GetBytes(toEncode));
	}

	private static string base64urldecode(string pData)
	{
		byte[] array = base64urldecodeBytes(pData);
		string text = "";
		byte[] array2 = array;
		foreach (byte charCode in array2)
		{
			text += Conversions.ToString(Strings.ChrW(charCode));
		}
		return text;
	}

	internal static int[] str_to_a32(string b)
	{
		int[] array;
		int num;
		checked
		{
			array = new int[(b.Length + 3 >> 2) - 1 + 1];
			num = b.Length - 1;
		}
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			array[i >> 2] |= (int)((uint)Convert.ToChar(b.Substring(i, 1)) << checked(24 - (i & 3) * 8));
		}
		return array;
	}

	private static byte[] B64Decode(string pData)
	{
		pData += "==".Substring(checked(2 - pData.Length * 3) & 3);
		pData = pData.Replace("-", "+").Replace("_", "/").Replace(",", "");
		return Convert.FromBase64String(pData);
	}

	private static int[] ByteArrayToIntArray(byte[] pBytes)
	{
		List<int> list = new List<int>();
		checked
		{
			int num = (int)Math.Round((double)pBytes.Length / 4.0) - 1;
			for (int i = 0; i <= num; i++)
			{
				if (4 * (i + 1) <= pBytes.Length)
				{
					list.Add(BitConverter.ToInt32(pBytes, i * 4));
				}
			}
			return list.ToArray();
		}
	}

	private static byte[] IntArrayToBytesArray(IEnumerable<int> pInts)
	{
		List<byte> list = new List<byte>();
		foreach (int pInt in pInts)
		{
			list.AddRange(BitConverter.GetBytes(pInt));
		}
		return list.ToArray();
	}

	public static string base64urlencode(byte[] pData)
	{
		return Convert.ToBase64String(pData).Replace("+", "-").Replace("/", "_")
			.Replace("=", "");
	}

	public static byte[] base64urldecodeBytes(string pData)
	{
		pData += "==".Substring(checked(2 - pData.Length * 3) & 3);
		pData = pData.Replace("-", "+").Replace("_", "/").Replace(",", "");
		return Convert.FromBase64String(pData);
	}
}
