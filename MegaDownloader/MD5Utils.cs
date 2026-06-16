using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MegaDownloader;

public class MD5Utils
{
	public static string MD5CalcFile(string filepath)
	{
		using BufferedStream inputStream = new BufferedStream(File.OpenRead(filepath), 1200000);
		using MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		return ByteArrayToString(mD5CryptoServiceProvider.ComputeHash(inputStream));
	}

	public static string MD5CalcString(string str)
	{
		str = str ?? "";
		byte[] array = MD5.Create().ComputeHash(Encoding.Default.GetBytes(str));
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}

	private static string ByteArrayToString(byte[] arrInput)
	{
		checked
		{
			StringBuilder stringBuilder = new StringBuilder(arrInput.Length * 2);
			int num = arrInput.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				stringBuilder.Append(arrInput[i].ToString("X2"));
			}
			return stringBuilder.ToString().ToLower();
		}
	}
}
