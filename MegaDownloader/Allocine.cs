using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MegaDownloader;

public class Allocine
{
	public class MovieInfo
	{
		public bool OK;

		public Exception Err;

		public string Title;

		public string Poster;

		public string Plot;
	}

	public static void FillMissingFields(ref string AllocineID, ref string Name, ref string Poster, ref string Desc)
	{
		if (string.IsNullOrEmpty(AllocineID) || !(string.IsNullOrEmpty(Name) | string.IsNullOrEmpty(Poster) | string.IsNullOrEmpty(Desc)))
		{
			return;
		}
		MovieInfo movieInfo = GetMovieInfo(AllocineID);
		if (movieInfo.OK)
		{
			if (string.IsNullOrEmpty(Name))
			{
				Name = movieInfo.Title;
			}
			if (string.IsNullOrEmpty(Poster))
			{
				Poster = movieInfo.Poster;
			}
			if (string.IsNullOrEmpty(Desc))
			{
				Desc = movieInfo.Plot;
			}
		}
	}

	public static MovieInfo GetMovieInfo(string AllocineID)
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		MovieInfo movieInfo = new MovieInfo();
		string text = "100043982026";
		string text2 = "29d185d98c984a359e6e6f26a0474269";
		string text3 = "partner=" + text + "&format=json&profile=small&code=" + AllocineID;
		string text4 = "&sed=" + DateAndTime.Now.ToString("yyyyMMdd");
		string text5 = "&sig=" + GetSHA1(text2 + text3 + text4);
		Conexion.Respuesta respuesta = Conexion.LeerURL("http://api.allocine.fr/rest/v3/movie?" + text3 + text4 + text5, null, "Dalvik/1.6.0 (Linux; U; Android 4.2.2; Nexus 4 Build/JDQ39E)");
		MovieInfo result;
		if (respuesta.Excepcion != null)
		{
			movieInfo.OK = false;
			movieInfo.Err = respuesta.Excepcion;
			result = movieInfo;
		}
		else
		{
			JObject val;
			try
			{
				val = (JObject)JsonConvert.DeserializeObject(respuesta.Mensaje ?? "");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				movieInfo.OK = false;
				movieInfo.Err = respuesta.Excepcion;
				result = movieInfo;
				ProjectData.ClearProjectError();
				goto IL_02bc;
			}
			if (val["error"] != null)
			{
				movieInfo.OK = false;
				if (val["error"][(object)"$"] != null)
				{
					movieInfo.Err = new ApplicationException(val["error"][(object)"$"].ToString());
				}
				else
				{
					movieInfo.Err = new ApplicationException(val["error"].ToString());
				}
				result = movieInfo;
			}
			else if (val["movie"] == null)
			{
				movieInfo.OK = false;
				movieInfo.Err = new ApplicationException("Allocine movie node not found");
				result = movieInfo;
			}
			else
			{
				if (val["movie"][(object)"title"] != null)
				{
					movieInfo.Title = val["movie"][(object)"title"].ToString();
				}
				if (val["movie"][(object)"productionYear"] != null)
				{
					ref string title = ref movieInfo.Title;
					title = title + " (" + val["movie"][(object)"productionYear"].ToString() + ")";
				}
				if (val["movie"][(object)"synopsisShort"] != null)
				{
					movieInfo.Plot = val["movie"][(object)"synopsisShort"].ToString();
				}
				if (val["movie"][(object)"poster"] != null && val["movie"][(object)"poster"][(object)"href"] != null)
				{
					movieInfo.Poster = val["movie"][(object)"poster"][(object)"href"].ToString();
				}
				movieInfo.OK = true;
				result = movieInfo;
			}
		}
		goto IL_02bc;
		IL_02bc:
		return result;
	}

	public static string GetSHA1(string str)
	{
		return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.Default.GetBytes(str)));
	}
}
