using System;
using System.Text;

namespace MegaDownloader;

public class Filmaffinity
{
	public class MovieInfo
	{
		public bool OK;

		public Exception Err;

		public string Title;

		public string Poster;

		public string Plot;
	}

	public static void FillMissingFields(ref string FilmAffinityID, ref string Name, ref string Poster, ref string Desc)
	{
		if (string.IsNullOrEmpty(FilmAffinityID) || !(string.IsNullOrEmpty(Name) | string.IsNullOrEmpty(Poster) | string.IsNullOrEmpty(Desc)))
		{
			return;
		}
		MovieInfo movieInfo = GetMovieInfo(FilmAffinityID);
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

	public static MovieInfo GetMovieInfo(string FilmAffinityID)
	{
		MovieInfo movieInfo = new MovieInfo();
		FilmAffinityID = FilmAffinityID.ToLower().Replace("film", "");
		Conexion.Respuesta respuesta = Conexion.LeerURL("http://www.filmaffinity.com/es/film" + FilmAffinityID + ".html", Encoding.GetEncoding("UTF-8"), "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36", "http://www.filmaffinity.com");
		if (respuesta.Excepcion != null)
		{
			movieInfo.OK = false;
			movieInfo.Err = respuesta.Excepcion;
			return movieInfo;
		}
		string value = "<img alt=\"logo\" src=\"/images/logo4.png\"></a>";
		if (respuesta.Mensaje.IndexOf(value) <= 0)
		{
			movieInfo.OK = false;
			movieInfo.Err = new ApplicationException("Could not scrap website");
			return movieInfo;
		}
		checked
		{
			int num = respuesta.Mensaje.IndexOf("<title>") + 7;
			int num2 = respuesta.Mensaje.IndexOf("</title>", num);
			if (unchecked(num2 > 0 && num > 0) & (num2 - num > 0))
			{
				movieInfo.Title = respuesta.Mensaje.Substring(num, num2 - num).Replace(" - FilmAffinity", "");
			}
			num = respuesta.Mensaje.IndexOf("<dt>Sinopsis</dt>") + 1;
			if (num > 0)
			{
				num = respuesta.Mensaje.IndexOf("<dd>", num) + 4;
			}
			num2 = respuesta.Mensaje.IndexOf("</dd>", num);
			if (unchecked(num2 > 0 && num > 0) & (num2 - num > 0))
			{
				movieInfo.Plot = respuesta.Mensaje.Substring(num, num2 - num).Replace("(FILMAFFINITY)", "").Trim()
					.Replace("\r\n", " ");
			}
			num = respuesta.Mensaje.IndexOf("<a class=\"lightbox\" href=\"") + 26;
			if (num > 0)
			{
				num2 = respuesta.Mensaje.IndexOf("\" title", num);
			}
			if (unchecked(num2 > 0 && num > 0) & (num2 - num > 0))
			{
				movieInfo.Poster = respuesta.Mensaje.Substring(num, num2 - num).Trim();
			}
			movieInfo.OK = true;
			return movieInfo;
		}
	}
}
