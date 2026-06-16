using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MegaDownloader.Cryptography;

public class AES
{
	private const int SALT_SIZE = 4;

	private const int SALT_ITERATIONS = 25997;

	private static byte[] SALT_BYTES = new byte[12]
	{
		236, 148, 113, 216, 75, 18, 129, 6, 250, 85,
		24, 243
	};

	public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
	{
		byte[] array = null;
		checked
		{
			using MemoryStream memoryStream = new MemoryStream();
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 256;
			rijndaelManaged.BlockSize = 128;
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, SALT_BYTES, 25997);
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
			rijndaelManaged.IV = GetRandomBytes((int)Math.Round((double)rijndaelManaged.BlockSize / 8.0));
			rijndaelManaged.Mode = CipherMode.CBC;
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
				cryptoStream.Close();
			}
			return rijndaelManaged.IV.Concat(memoryStream.ToArray()).ToArray();
		}
	}

	public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
	{
		byte[] array = null;
		checked
		{
			using MemoryStream memoryStream = new MemoryStream();
			using RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.KeySize = 256;
			rijndaelManaged.BlockSize = 128;
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, SALT_BYTES, 25997);
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
			rijndaelManaged.IV = bytesToBeDecrypted.Take((int)Math.Round((double)rijndaelManaged.BlockSize / 8.0)).ToArray();
			rijndaelManaged.Mode = CipherMode.CBC;
			byte[] array2 = bytesToBeDecrypted.Skip((int)Math.Round((double)rijndaelManaged.BlockSize / 8.0)).ToArray();
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
			{
				cryptoStream.Write(array2, 0, array2.Length);
				cryptoStream.Close();
			}
			return memoryStream.ToArray();
		}
	}

	public string Encrypt(string text, string pwd)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		byte[] bytes2 = Encoding.UTF8.GetBytes(pwd);
		bytes2 = SHA256.Create().ComputeHash(bytes2);
		byte[] bytesToBeEncrypted = GetRandomBytes(4).Concat(bytes).ToArray();
		return Convert.ToBase64String(AES_Encrypt(bytesToBeEncrypted, bytes2));
	}

	public string Decrypt(string decryptedText, string pwd)
	{
		byte[] bytesToBeDecrypted = Convert.FromBase64String(decryptedText);
		byte[] bytes = Encoding.UTF8.GetBytes(pwd);
		bytes = SHA256.Create().ComputeHash(bytes);
		byte[] source = AES_Decrypt(bytesToBeDecrypted, bytes);
		return Encoding.UTF8.GetString(source.Skip(4).ToArray());
	}

	public byte[] GetRandomBytes(int numberOfBytes)
	{
		byte[] array = new byte[checked(numberOfBytes - 1 + 1)];
		RandomNumberGenerator.Create().GetBytes(array);
		return array;
	}
}
