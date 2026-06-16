using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using HttpServer;
using HttpServer.HttpModules;
using HttpServer.Sessions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class StreamingModule : HttpModule
{
	private Configuracion _Config;

	public const string PaginaStreaming = "/streaming";

	private static Dictionary<string, KeyValuePair<DateTime, Conexion.InformacionFichero>> Urls = new Dictionary<string, KeyValuePair<DateTime, Conexion.InformacionFichero>>();

	public StreamingModule(ref Configuracion Config)
	{
		_Config = Config;
	}

	public override bool Process(IHttpRequest request, IHttpResponse response, IHttpSession session)
	{
		checked
		{
			try
			{
				if (!IsStreaming(ref request))
				{
					return false;
				}
				if (!string.IsNullOrEmpty(_Config.ServidorStreamingPassword) && (request.Param["p"] == null || Operators.CompareString(request.Param["p"].Value, _Config.ServidorStreamingPassword, TextCompare: false) != 0))
				{
					string ResponseBody = "Error: Access denied";
					ComprimirRespuesta(ref request, ref response, ref ResponseBody);
					return true;
				}
				string FileKey = string.Empty;
				string FileID = string.Empty;
				if (request.Param["mega"] != null && !string.IsNullOrEmpty(request.Param["mega"].Value))
				{
					FileKey = ExtraerStreamingFileKey(request.Uri.PathAndQuery);
					FileID = ExtraerStreamingFileID(request.Uri.PathAndQuery);
				}
				else if (request.Param["id"] != null && !string.IsNullOrEmpty(request.Param["id"].Value))
				{
					LibraryElement elementByID = StreamingLibraryManager.GetElementByID(request.Param["id"].Value);
					if (elementByID == null)
					{
						string ResponseBody = "Invalid ID";
						ComprimirRespuesta(ref request, ref response, ref ResponseBody);
						return true;
					}
					string uRL = Criptografia.ToInsecureString(elementByID.Link);
					FileKey = Fichero.ExtraerFileKey(uRL);
					FileID = Fichero.ExtraerFileID(uRL);
				}
				else if (request.Param["t"] != null && !string.IsNullOrEmpty(request.Param["t"].Value) && !StreamingHelper.GetFileDataFromTempID(request.Param["t"].Value, ref FileID, ref FileKey))
				{
					string ResponseBody = "Invalid ID";
					ComprimirRespuesta(ref request, ref response, ref ResponseBody);
					return true;
				}
				if (string.IsNullOrEmpty(FileID))
				{
					string ResponseBody = "Missing FileID and/or FileKey";
					ComprimirRespuesta(ref request, ref response, ref ResponseBody);
					return true;
				}
				string pathAndQuery = request.Uri.PathAndQuery;
				Conexion.InformacionFichero informacionFichero;
				if (!Urls.ContainsKey(pathAndQuery) || DateTime.Compare(Urls[pathAndQuery].Key, DateAndTime.Now) < 0)
				{
					informacionFichero = Conexion.ObtenerInformacionFichero(_Config, FileID, FileKey, ComprobacionAntesDescarga: true);
					if (informacionFichero.Err != Conexion.TipoError.SinErrores)
					{
						string ResponseBody = "Error: " + informacionFichero.Errtxt;
						ComprimirRespuesta(ref request, ref response, ref ResponseBody);
						return true;
					}
					FileKey = informacionFichero.FileKey;
					FileID = informacionFichero.FileID;
					Urls[pathAndQuery] = new KeyValuePair<DateTime, Conexion.InformacionFichero>(DateAndTime.Now.AddMinutes(3.0), informacionFichero);
				}
				else
				{
					informacionFichero = Urls[pathAndQuery].Value;
					FileKey = informacionFichero.FileKey;
					FileID = informacionFichero.FileID;
				}
				if (FileKey.Contains("=###n="))
				{
					FileKey = FileKey.Substring(0, FileKey.IndexOf("=###n="));
				}
				HttpWebRequest httpWebRequest = null;
				HttpWebResponse httpWebResponse = null;
				Criptografia.SicSeekableBlockCipher instaceCipher = Criptografia.GetInstaceCipher(FileKey);
				try
				{
					long rangeStart = 0L;
					long rangeEnd = 0L;
					long requestRangeStart = 0L;
					long requestRangeEnd = 0L;
					long content = 0L;
					RangeAdjust(ref rangeStart, ref rangeEnd, ref requestRangeStart, ref requestRangeEnd, ref content, request, response, informacionFichero.Tamano);
					ContentDisposition contentDisposition = new ContentDisposition();
					contentDisposition.FileName = Utils.RemoveDiacritics(informacionFichero.Nombre);
					response.AddHeader("Content-Disposition", contentDisposition.ToString());
					response.AddHeader("Cache-Control", "private");
					response.ContentLength = content;
					response.ContentType = "application/octet-stream";
					response.Status = HttpStatusCode.PartialContent;
					response.Connection = (ConnectionType)0;
					httpWebRequest = Conexion.CreateHttpWebRequest(informacionFichero.URL);
					string text = "Range";
					string text2 = $"bytes={rangeStart}-{rangeEnd}";
					typeof(WebHeaderCollection).GetMethod("AddWithoutValidate", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(httpWebRequest.Headers, new object[2] { text, text2 });
					httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					instaceCipher.IncrementCounter((int)Math.Ceiling((double)rangeStart / (double)instaceCipher.GetBlockSize()));
					int num = 16384;
					long num2 = 0L;
					int num3 = 0;
					byte[] array = new byte[num - 1 + 1];
					Stream responseStream = httpWebResponse.GetResponseStream();
					try
					{
						response.SendHeaders();
						for (; (num2 < content) & ClientConnected(response); num2 += num3)
						{
							num3 = responseStream.Read(array, 0, num);
							int num4 = instaceCipher.GetBlockSize() - unchecked(num3 % instaceCipher.GetBlockSize());
							if (num4 != instaceCipher.GetBlockSize())
							{
								num3 = ((num2 + num3 >= content) ? (num3 + num4) : (num3 + responseStream.Read(array, num3, num4)));
							}
							byte[] array2 = new byte[num3 - 1 + 1];
							int num5 = num3 - 1;
							int blockSize = instaceCipher.GetBlockSize();
							for (int i = 0; ((blockSize >> 31) ^ i) <= ((blockSize >> 31) ^ num5); i += blockSize)
							{
								instaceCipher.ProcessBlock(array, i, array2, i);
							}
							if (num2 == 0L)
							{
								array2 = array2.ToList().GetRange((int)(requestRangeStart - rangeStart), array2.Length - (int)(requestRangeStart - rangeStart)).ToArray();
							}
							response.SendBody(array2);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2.ToString();
						throw;
					}
					finally
					{
						responseStream.Close();
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4.ToString();
					throw;
				}
				finally
				{
					httpWebResponse?.Close();
				}
				return true;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				Log.WriteError("Error in StreamingModule: " + ex6.ToString());
				throw;
			}
		}
	}

	private void RangeAdjust(ref long rangeStart, ref long rangeEnd, ref long requestRangeStart, ref long requestRangeEnd, ref long content, IHttpRequest request, IHttpResponse response, long FileSize)
	{
		rangeStart = 0L;
		rangeEnd = 0L;
		if (!string.IsNullOrEmpty(request.Headers["Range"]))
		{
			Match match = Regex.Match(request.Headers["Range"], "bytes=(\\d*)-(\\d*)");
			if (match.Success)
			{
				if (!string.IsNullOrEmpty(match.Groups[1].Value))
				{
					long.TryParse(match.Groups[1].Value, out rangeStart);
				}
				if (!string.IsNullOrEmpty(match.Groups[2].Value))
				{
					long.TryParse(match.Groups[2].Value, out rangeEnd);
				}
			}
		}
		requestRangeStart = rangeStart;
		requestRangeEnd = rangeEnd;
		checked
		{
			if (unchecked(rangeStart % 16) != 0L)
			{
				rangeStart -= unchecked(rangeStart % 16);
			}
			if (unchecked(rangeEnd % 16) != 0L)
			{
				rangeEnd = rangeEnd - unchecked(rangeEnd % 16) + 16;
			}
			if (rangeStart == rangeEnd && rangeStart != 0L)
			{
				rangeEnd += 16L;
			}
			rangeEnd = ((rangeEnd == 0L) ? (FileSize - 1) : rangeEnd);
			requestRangeEnd = ((requestRangeEnd > 0) ? requestRangeEnd : (FileSize - 1));
			content = requestRangeEnd - requestRangeStart + 1;
			response.AddHeader("Content-Length", content.ToString());
			response.ContentType = "application/octet-stream";
			if (!string.IsNullOrEmpty(request.Headers["Range"]))
			{
				response.AddHeader("Accept-Ranges", "bytes");
				response.AddHeader("Content-Range", "bytes " + Conversions.ToString(requestRangeStart) + "-" + requestRangeEnd + "/" + FileSize);
			}
		}
	}

	private bool ClientConnected(IHttpResponse response)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(((object)response).GetType().GetField("_context", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(response));
		Stream stream = (Stream)objectValue.GetType().GetProperty("Stream", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(RuntimeHelpers.GetObjectValue(objectValue), null);
		return Conversions.ToBoolean(stream.GetType().GetProperty("Connected", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stream, null));
	}

	private void ComprimirRespuesta(ref IHttpRequest request, ref IHttpResponse response, ref string ResponseBody)
	{
		string text = request.Headers["Accept-Encoding"];
		if (!string.IsNullOrEmpty(text) && text.ToLower().Contains("gzip"))
		{
			response.AddHeader("Content-Encoding", "gzip");
			byte[] bytes = Encoding.UTF8.GetBytes(ResponseBody);
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				gZipStream.Write(bytes, 0, bytes.Length);
				gZipStream.Flush();
			}
			bytes = memoryStream.ToArray();
			response.Body.Write(bytes, 0, bytes.Length);
			return;
		}
		StreamWriter streamWriter = new StreamWriter(response.Body);
		streamWriter.Write(ResponseBody);
		streamWriter.Flush();
	}

	private bool IsStreaming(ref IHttpRequest request)
	{
		return Operators.CompareString(request.Uri.LocalPath, "/streaming", TextCompare: false) == 0;
	}

	public static string ExtraerStreamingFileKey(string URL)
	{
		if (string.IsNullOrEmpty(URL))
		{
			return "";
		}
		if (!URL.ToLower().Contains("?mega="))
		{
			return "";
		}
		URL = URL.Substring(checked(URL.IndexOf("?") + 6));
		if (URL.Split('!').Length != 3 && !string.IsNullOrEmpty(URL.Split('!')[0]))
		{
			return "";
		}
		return URL.Split('!')[2];
	}

	public static string ExtraerStreamingFileID(string URL)
	{
		if (string.IsNullOrEmpty(URL))
		{
			return "";
		}
		if (!URL.ToLower().Contains("?mega="))
		{
			return "";
		}
		URL = URL.Substring(checked(URL.IndexOf("?") + 6));
		if (URL.Split('!').Length != 3 && !string.IsNullOrEmpty(URL.Split('!')[0]))
		{
			return "";
		}
		return URL.Split('!')[1];
	}
}
