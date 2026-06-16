using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using F5;
using F5.James;
using MegaDownloader.Cryptography;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader.Stegano;

public class SteganoManager
{
	public string CheckPassword(string Password)
	{
		if (string.IsNullOrEmpty(Password))
		{
			Password = "k1o6Al-1kz¿!z05y";
		}
		return Password;
	}

	public bool CreateImage(string Text, string Input, string Output, int Quality, string Password)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		Password = CheckPassword(Password);
		AES aES = new AES();
		byte[] array = Convert.FromBase64String(aES.Encrypt(Text, Password));
		Image image;
		if (File.Exists(Input))
		{
			image = Image.FromFile(Input);
		}
		else
		{
			using WebClient webClient = new WebClient();
			byte[] buffer = webClient.DownloadData(Input);
			using MemoryStream stream = new MemoryStream(buffer);
			image = Image.FromStream(stream);
		}
		using (image)
		{
			JpegEncoder val = new JpegEncoder(image, (Stream)File.OpenWrite(Output), (string)null, Quality);
			try
			{
				val.Compress((Stream)new MemoryStream(array), Encoding.Unicode.GetBytes(Password));
				double num = (double)val.MaxSizeToEmbed * 0.8;
				long num2 = array.Length;
				_ = val.K_Used;
				if (num < (double)num2)
				{
					throw new ApplicationException(Language.GetText("Warning: image too small, maybe the data is corrupted"));
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		using (MemoryStream memoryStream = new MemoryStream())
		{
			JpegExtract val2 = new JpegExtract((Stream)memoryStream, Encoding.Unicode.GetBytes(Password));
			try
			{
				val2.Extract((Stream)File.OpenRead(Output));
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			array = memoryStream.ToArray();
			try
			{
				if (Operators.CompareString(aES.Decrypt(Convert.ToBase64String(array), Password), Text, TextCompare: false) != 0)
				{
					throw new ApplicationException();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new ApplicationException(Language.GetText("Warning: The image output was created but the data verification failed. This may happen if the image is too small, try with a bigger image"));
			}
		}
		return true;
	}

	public bool LoadImages(string Input, string Password, ref string HiddenText)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		AES aES = new AES();
		Password = CheckPassword(Password);
		Stream stream;
		byte[] array;
		if (File.Exists(Input))
		{
			stream = File.OpenRead(Input);
		}
		else
		{
			using WebClient webClient = new WebClient();
			array = webClient.DownloadData(Input);
			stream = new MemoryStream(array);
		}
		bool result;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			try
			{
				JpegExtract val = new JpegExtract((Stream)memoryStream, Encoding.Unicode.GetBytes(Password));
				try
				{
					val.Extract(stream);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				array = memoryStream.ToArray();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_00c6;
			}
		}
		try
		{
			string text = aES.Decrypt(Convert.ToBase64String(array), Password);
			HiddenText = text;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00c6;
		}
		result = true;
		goto IL_00c6;
		IL_00c6:
		return result;
	}
}
