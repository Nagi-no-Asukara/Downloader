using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;

namespace MegaDownloader;

public class Linkdecrypter
{
	public static List<string> ExtraerURLs(string URI)
	{
		List<string> list = new List<string>();
		NameValueCollection nameValueCollection = new NameValueCollection();
		nameValueCollection.Add("link_cache", "on");
		nameValueCollection.Add("modo_links", "text");
		nameValueCollection.Add("modo_recursivo", "on");
		nameValueCollection.Add("pro_links", URI);
		Conexion.Respuesta respuesta = Conexion.SendPOST("http://linkdecrypter.com", nameValueCollection, "application/x-www-form-urlencoded", SendAppId: false);
		string cookie = GetCookie(respuesta.Cookies);
		nameValueCollection = new NameValueCollection();
		nameValueCollection.Add("Cookie", cookie);
		int num = 0;
		checked
		{
			while (true)
			{
				num++;
				Thread.Sleep(300);
				respuesta = Conexion.LeerURL("http://linkdecrypter.com", null, null, null, nameValueCollection);
				if (respuesta.Mensaje.Contains("Loading CAPTCHA"))
				{
					break;
				}
				if (respuesta.Mensaje.Contains("<textarea name=\"links\""))
				{
					List<string> list2 = URLExtractor.ExtraerURLs(respuesta.Mensaje);
					foreach (string item in list2)
					{
						list.Add(item);
					}
					break;
				}
				if (num >= 5)
				{
					break;
				}
				Thread.Sleep((int)Math.Round((double)(num * 500) + new Random().NextDouble() * 500.0));
			}
			return list;
		}
	}

	private static string GetCookie(string cookies)
	{
		if (string.IsNullOrEmpty(cookies))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = cookies.Split(';');
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			string[] array2 = array[i].Trim().Split('=');
			if (array2.Length != 2)
			{
				continue;
			}
			switch (array2[0])
			{
			case "__cfduid":
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("; ");
				}
				stringBuilder.Append("__cfduid").Append("=").Append(array2[1]);
				break;
			case "HttpOnly,PHPSESSID":
			case "HttpOnly, PHPSESSID":
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("; ");
				}
				stringBuilder.Append("PHPSESSID").Append("=").Append(array2[1]);
				break;
			}
		}
		return stringBuilder.ToString();
	}
}
