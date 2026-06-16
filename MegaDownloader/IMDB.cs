using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace MegaDownloader;

public class IMDB
{
	public class MovieInfo
	{
		public bool OK;

		public Exception Err;

		public string Title;

		public string Poster;

		public string Plot;
	}

	public static void FillMissingFields(ref string IMDB, ref string Name, ref string Poster, ref string Desc)
	{
		if (string.IsNullOrEmpty(IMDB) || !(string.IsNullOrEmpty(Name) | string.IsNullOrEmpty(Poster) | string.IsNullOrEmpty(Desc)))
		{
			return;
		}
		MovieInfo movieInfo = GetMovieInfo(IMDB);
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

	public static MovieInfo GetMovieInfo(string IMDB)
	{
		MovieInfo movieInfo = new MovieInfo();
		IMDB = IMDB.ToLower().Replace("tt", "");
		Conexion.Respuesta respuesta = Conexion.LeerURL("http://www.omdbapi.com/?i=tt" + IMDB);
		MovieInfo result;
		if (respuesta.Excepcion != null)
		{
			movieInfo.OK = false;
			movieInfo.Err = respuesta.Excepcion;
			result = movieInfo;
		}
		else
		{
			Dictionary<string, object> dictionary;
			try
			{
				dictionary = (Dictionary<string, object>)JsonConvert.DeserializeObject(respuesta.Mensaje, typeof(Dictionary<string, object>));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				movieInfo.OK = false;
				movieInfo.Err = respuesta.Excepcion;
				result = movieInfo;
				ProjectData.ClearProjectError();
				goto IL_0191;
			}
			if (dictionary.ContainsKey("Error") && !string.IsNullOrEmpty(Conversions.ToString(dictionary["Error"])))
			{
				movieInfo.OK = false;
				movieInfo.Err = new ApplicationException(Conversions.ToString(dictionary["Error"]));
				result = movieInfo;
			}
			else
			{
				if (dictionary.ContainsKey("Title"))
				{
					movieInfo.Title = Conversions.ToString(dictionary["Title"]);
				}
				if (dictionary.ContainsKey("Year"))
				{
					ref string title = ref movieInfo.Title;
					title = title + " (" + Conversions.ToString(dictionary["Year"]) + ")";
				}
				if (dictionary.ContainsKey("Poster"))
				{
					movieInfo.Poster = Conversions.ToString(dictionary["Poster"]);
				}
				if (dictionary.ContainsKey("Plot"))
				{
					movieInfo.Plot = Conversions.ToString(dictionary["Plot"]);
				}
				movieInfo.OK = true;
				result = movieInfo;
			}
		}
		goto IL_0191;
		IL_0191:
		return result;
	}
}
