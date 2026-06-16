namespace MegaDownloader;

public interface IDescarga
{
	int DescargaPrioridad();

	string DescargaNombre();

	long DescargaTamanoBytes();

	decimal DescargaPorcentaje();

	decimal DescargaVelocidadKBs();

	Estado DescargaEstado();

	bool DescargaExtraccionAutomatica();

	string DescargaExtraccionPassword();

	string DescargaTiempoEstimadoDescarga();
}
