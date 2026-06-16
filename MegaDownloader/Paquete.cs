using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class Paquete : IDescarga
{
	public string Nombre;

	public string RutaLocal;

	public bool CrearSubdirectorio;

	public bool PendienteNombrePaquete;

	public List<Fichero> ListaFicheros;

	public bool ExtraccionFicheroAutomatica;

	public string ExtraccionFicheroPassword;

	public int Prioridad;

	private Estado EstadoDescarga;

	public decimal Porcentaje;

	public long TamanoBytes;

	private decimal VelocidadKBs;

	private string TiempoEstimadoDescarga;

	private static string _LastSavedXML = null;

	public int SetDescargaPrioridad
	{
		set
		{
			Prioridad = value;
		}
	}

	public void SetDescargaExtraccionAutomatica(string password, bool value)
	{
		ExtraccionFicheroAutomatica = value;
		ExtraccionFicheroPassword = password;
	}

	private bool HayFicheros()
	{
		Mutex.ListaDescargas.WaitOne();
		bool result = ListaFicheros != null && ListaFicheros.Count > 0;
		Mutex.ListaDescargas.ReleaseMutex();
		return result;
	}

	public void AgregarFichero(Fichero Fichero)
	{
		Mutex.ListaDescargas.WaitOne();
		if (ListaFicheros == null)
		{
			ListaFicheros = new List<Fichero>();
		}
		ListaFicheros.Add(Fichero);
		Mutex.ListaDescargas.ReleaseMutex();
	}

	public void ActualizarDatosDescarga()
	{
		checked
		{
			if (!HayFicheros())
			{
				EstadoDescarga = Estado.EnCola;
				Porcentaje = default(decimal);
				TamanoBytes = 0L;
				VelocidadKBs = default(decimal);
			}
			else
			{
				decimal num = default(decimal);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool flag8 = false;
				long num2 = 0L;
				long num3 = 0L;
				Mutex.ListaDescargas.WaitOne();
				foreach (Fichero listaFichero in ListaFicheros)
				{
					num2 += listaFichero.DescargaTamanoBytes();
					num3 += Convert.ToInt64(decimal.Multiply(new decimal(listaFichero.DescargaTamanoBytes()), decimal.Divide(listaFichero.DescargaPorcentaje(), 100m)));
					switch (listaFichero.DescargaEstado())
					{
					case Estado.Descargando:
						num = decimal.Add(num, listaFichero.DescargaVelocidadKBs());
						flag = true;
						break;
					case Estado.EnCola:
						flag2 = true;
						break;
					case Estado.Pausado:
						flag5 = true;
						break;
					case Estado.ComprobandoMD5:
						flag7 = true;
						break;
					case Estado.Descomprimiendo:
						flag6 = true;
						break;
					case Estado.Verificando:
						flag8 = true;
						break;
					case Estado.CreandoLocal:
						flag4 = true;
						break;
					default:
						flag3 = true;
						break;
					case Estado.Completado:
						break;
					}
				}
				Mutex.ListaDescargas.ReleaseMutex();
				if (flag)
				{
					EstadoDescarga = Estado.Descargando;
				}
				else if (flag5)
				{
					EstadoDescarga = Estado.Pausado;
				}
				else if (flag3)
				{
					EstadoDescarga = Estado.Erroneo;
				}
				else if (flag4)
				{
					EstadoDescarga = Estado.CreandoLocal;
				}
				else if (flag2)
				{
					EstadoDescarga = Estado.EnCola;
				}
				else if (flag7)
				{
					EstadoDescarga = Estado.ComprobandoMD5;
				}
				else if (flag6)
				{
					EstadoDescarga = Estado.Descomprimiendo;
				}
				else if (flag8)
				{
					EstadoDescarga = Estado.Verificando;
				}
				else
				{
					EstadoDescarga = Estado.Completado;
				}
				TamanoBytes = num2;
				VelocidadKBs = Math.Round(num, 2);
				if (TamanoBytes == 0L)
				{
					Porcentaje = default(decimal);
				}
				else
				{
					Porcentaje = new decimal((double)(100 * num3) / (double)num2);
				}
			}
			if (decimal.Compare(VelocidadKBs, 0m) == 0)
			{
				TiempoEstimadoDescarga = " --- ";
				return;
			}
			double num4 = Convert.ToDouble(decimal.Divide(new decimal(TamanoBytes - Convert.ToInt64(decimal.Divide(decimal.Multiply(Porcentaje, new decimal(TamanoBytes)), 100m))), decimal.Multiply(1024m, VelocidadKBs)));
			TimeSpan timeSpan = TimeSpan.FromSeconds(num4);
			if (num4 > 3600.0)
			{
				TiempoEstimadoDescarga = $"{timeSpan.Days * 24 + timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
			}
			else
			{
				TiempoEstimadoDescarga = $"{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
			}
		}
	}

	public int DescargaPrioridad()
	{
		return Prioridad;
	}

	int IDescarga.DescargaPrioridad()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaPrioridad
		return this.DescargaPrioridad();
	}

	public string DescargaNombre()
	{
		return Nombre;
	}

	string IDescarga.DescargaNombre()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaNombre
		return this.DescargaNombre();
	}

	public Estado DescargaEstado()
	{
		return EstadoDescarga;
	}

	Estado IDescarga.DescargaEstado()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaEstado
		return this.DescargaEstado();
	}

	public bool DescargaExtraccionAutomatica()
	{
		return ExtraccionFicheroAutomatica;
	}

	bool IDescarga.DescargaExtraccionAutomatica()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaExtraccionAutomatica
		return this.DescargaExtraccionAutomatica();
	}

	public string DescargaExtraccionPassword()
	{
		return ExtraccionFicheroPassword;
	}

	string IDescarga.DescargaExtraccionPassword()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaExtraccionPassword
		return this.DescargaExtraccionPassword();
	}

	public string DescargaTiempoEstimadoDescarga()
	{
		return TiempoEstimadoDescarga;
	}

	string IDescarga.DescargaTiempoEstimadoDescarga()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaTiempoEstimadoDescarga
		return this.DescargaTiempoEstimadoDescarga();
	}

	public decimal DescargaPorcentaje()
	{
		return Porcentaje;
	}

	decimal IDescarga.DescargaPorcentaje()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaPorcentaje
		return this.DescargaPorcentaje();
	}

	public long DescargaTamanoBytes()
	{
		return TamanoBytes;
	}

	long IDescarga.DescargaTamanoBytes()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaTamanoBytes
		return this.DescargaTamanoBytes();
	}

	public decimal DescargaVelocidadKBs()
	{
		return VelocidadKBs;
	}

	decimal IDescarga.DescargaVelocidadKBs()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DescargaVelocidadKBs
		return this.DescargaVelocidadKBs();
	}

	public static List<Paquete> CargarDesdeFichero()
	{
		string text = ObtenerRutaFicheroDescargas();
		List<Paquete> result;
		if (!File.Exists(text))
		{
			result = new List<Paquete>();
		}
		else
		{
			Log.WriteDebug("Loading download list XML");
			XmlDocument xmlDocument = new XmlDocument();
			Mutex.GuardarDownloadList.WaitOne();
			try
			{
				xmlDocument.Load(text);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error loading download list XML: " + ex2.ToString());
				if (!File.Exists(text + ".bak"))
				{
					result = new List<Paquete>();
					ProjectData.ClearProjectError();
					goto IL_0157;
				}
				Log.WriteError("Let's try to load the backup file: " + text + ".bak");
				try
				{
					xmlDocument.Load(text + ".bak");
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					Log.WriteError("Error loading download backup list XML: " + ex4.ToString());
					result = new List<Paquete>();
					ProjectData.ClearProjectError();
					goto IL_0157;
				}
				ProjectData.ClearProjectError();
			}
			finally
			{
				Mutex.GuardarDownloadList.ReleaseMutex();
			}
			List<Paquete> ListaPaquetes = new List<Paquete>();
			foreach (XmlNode item in xmlDocument.DocumentElement.SelectNodes("Paquete"))
			{
				Paquete paquete = new Paquete();
				paquete.CargarXML(item);
				ListaPaquetes.Add(paquete);
			}
			MarcarFicherosComoParados(ref ListaPaquetes);
			result = ListaPaquetes;
		}
		goto IL_0157;
		IL_0157:
		return result;
	}

	private static void MarcarFicherosComoParados(ref List<Paquete> ListaPaquetes)
	{
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete ListaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in ListaPaquete.ListaFicheros)
			{
				if ((listaFichero.DescargaEstado() == Estado.Descargando) | (listaFichero.DescargaEstado() == Estado.Pausado))
				{
					listaFichero.SetDescargaEstado = Estado.EnCola;
				}
				else if ((listaFichero.DescargaEstado() == Estado.Descomprimiendo) | (listaFichero.DescargaEstado() == Estado.Verificando))
				{
					listaFichero.SetDescargaEstado = Estado.Completado;
				}
				ThrottledStreamController.GetController().SetMaxSpeed(listaFichero.FileID, listaFichero.LimiteVelocidad);
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
	}

	public static void GuardarEnFichero(List<Paquete> ListaPaquetes)
	{
		string text = ObtenerRutaFicheroDescargas();
		XmlDocument xmlDocument = GuardarXML(ListaPaquetes, IncluirDatosCifrados: false);
		if (_LastSavedXML != null && Operators.CompareString(_LastSavedXML, xmlDocument.DocumentElement.OuterXml.GetHashCode().ToString(), TextCompare: false) == 0)
		{
			return;
		}
		_LastSavedXML = xmlDocument.DocumentElement.OuterXml.GetHashCode().ToString();
		xmlDocument = GuardarXML(ListaPaquetes, IncluirDatosCifrados: true);
		Log.WriteDebug("Saving download list");
		Mutex.GuardarDownloadList.WaitOne();
		try
		{
			if (File.Exists(text + ".bak"))
			{
				File.Delete(text + ".bak");
			}
			File.Move(text, text + ".bak");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		try
		{
			xmlDocument.Save(text);
		}
		finally
		{
			Mutex.GuardarDownloadList.ReleaseMutex();
		}
	}

	private static XmlDocument GuardarXML(List<Paquete> ListaPaquetes, bool IncluirDatosCifrados)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.AppendChild(xmlDocument.CreateElement("ListaPaquetes"));
		if (ListaPaquetes != null)
		{
			foreach (Paquete ListaPaquete in ListaPaquetes)
			{
				xmlDocument.DocumentElement.AppendChild(ListaPaquete.GuardarXML(xmlDocument, IncluirDatosCifrados));
			}
		}
		return xmlDocument;
	}

	private static string ObtenerRutaFicheroDescargas()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Config");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return Path.Combine(text, "DownloadList.xml");
	}

	public void CargarXML(XmlNode XML)
	{
		string Path = "Nombre";
		Nombre = LeerNodo(ref XML, ref Path, "");
		Path = "RutaLocal";
		RutaLocal = LeerNodo(ref XML, ref Path, "");
		Path = "CrearSubdirectorio";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out CrearSubdirectorio);
		Path = "PendienteNombrePaquete";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out PendienteNombrePaquete);
		Path = "ExtraccionFicheroAutomatica";
		bool.TryParse(LeerNodo(ref XML, ref Path, "false"), out ExtraccionFicheroAutomatica);
		Path = "ExtraccionFicheroPassword";
		string text = LeerNodo(ref XML, ref Path, "");
		if (!string.IsNullOrEmpty(text))
		{
			ExtraccionFicheroPassword = Criptografia.AES_DecryptString(text, "passZIP");
		}
		Path = "Prioridad";
		int.TryParse(LeerNodo(ref XML, ref Path, "0"), out Prioridad);
		Path = "Porcentaje";
		decimal.TryParse(LeerNodo(ref XML, ref Path, "0"), out Porcentaje);
		Path = "TamanoBytes";
		long.TryParse(LeerNodo(ref XML, ref Path, "0"), out TamanoBytes);
		ListaFicheros = new List<Fichero>();
		foreach (XmlNode item in XML.SelectNodes("ListaFicheros/Fichero"))
		{
			Fichero fichero = new Fichero();
			fichero.CargarXML(item);
			ListaFicheros.Add(fichero);
		}
	}

	public XmlNode GuardarXML(XmlDocument XML, bool IncluirDatosCifrados)
	{
		XmlNode xmlNode = XML.CreateElement("Paquete");
		xmlNode.AppendChild(XML.CreateElement("Nombre")).InnerText = Nombre;
		xmlNode.AppendChild(XML.CreateElement("RutaLocal")).InnerText = RutaLocal;
		xmlNode.AppendChild(XML.CreateElement("CrearSubdirectorio")).InnerText = CrearSubdirectorio.ToString();
		xmlNode.AppendChild(XML.CreateElement("ExtraccionFicheroAutomatica")).InnerText = ExtraccionFicheroAutomatica.ToString();
		if (!string.IsNullOrEmpty(ExtraccionFicheroPassword))
		{
			xmlNode.AppendChild(XML.CreateElement("ExtraccionFicheroPassword")).InnerText = Criptografia.AES_EncryptString(ExtraccionFicheroPassword, "passZIP");
		}
		xmlNode.AppendChild(XML.CreateElement("Prioridad")).InnerText = Prioridad.ToString();
		xmlNode.AppendChild(XML.CreateElement("Porcentaje")).InnerText = Porcentaje.ToString();
		xmlNode.AppendChild(XML.CreateElement("TamanoBytes")).InnerText = TamanoBytes.ToString();
		if (PendienteNombrePaquete)
		{
			xmlNode.AppendChild(XML.CreateElement("PendienteNombrePaquete")).InnerText = PendienteNombrePaquete.ToString();
		}
		if (ListaFicheros != null)
		{
			XmlNode xmlNode2 = xmlNode.AppendChild(XML.CreateElement("ListaFicheros"));
			foreach (Fichero listaFichero in ListaFicheros)
			{
				xmlNode2.AppendChild(listaFichero.GuardarXML(XML, IncluirDatosCifrados));
			}
		}
		return xmlNode;
	}

	private static string LeerNodo(ref XmlNode NodoXML, ref string Path, string ValorDefecto)
	{
		XmlNode xmlNode = NodoXML.SelectSingleNode(Path);
		if (xmlNode == null)
		{
			return ValorDefecto;
		}
		return xmlNode.InnerText;
	}
}
