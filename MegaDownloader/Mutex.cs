using System.Threading;

namespace MegaDownloader;

public class Mutex
{
	public static System.Threading.Mutex NumeroConexionesMaxima = new System.Threading.Mutex();

	public static System.Threading.Mutex GuardarConfig = new System.Threading.Mutex();

	public static System.Threading.Mutex GuardarDownloadList = new System.Threading.Mutex();

	public static System.Threading.Mutex ListaDescargas = new System.Threading.Mutex();

	public static System.Threading.Mutex FicheroDownloader = new System.Threading.Mutex();

	public static System.Threading.Mutex DeletingFiles = new System.Threading.Mutex();

	public static System.Threading.Mutex MEGAUriParameters = new System.Threading.Mutex();
}
