namespace MegaDownloader;

public enum Estado
{
	Verificando,
	CreandoLocal,
	EnCola,
	Descargando,
	Pausado,
	Completado,
	ComprobandoMD5,
	Descomprimiendo,
	Erroneo
}
