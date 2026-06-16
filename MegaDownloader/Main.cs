using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using BrightIdeasSoftware;
using MegaDownloader.My;
using MegaDownloader.My.Resources;
using MegaDownloader.Stegano;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SharpCompress.PriorityExtension;

namespace MegaDownloader;

[DesignerGenerated]
public class Main : Form
{
	internal enum TipoEstadoAplicacion
	{
		Descargando,
		Pausa,
		Parado
	}

	public delegate void MsgBoxCallback(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);

	public delegate void SetStatusBarCallback(string RAM, string Proc, string Estado, string velocidad, string configuracionConexiones);

	public delegate void RefreshListaDescargasCallback(bool SetObjects);

	public delegate void TextoIconoMinimizadoCallback(string txt);

	public delegate void ActivarUpdateButtonCallback();

	public delegate void CerrarAplicacionCallback();

	public delegate void MostrarMensajeActualizacionCallback();

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static TypedAspectGetterDelegate<IDescarga> _0024I282_002D0;

		public static TypedAspectGetterDelegate<IDescarga> _0024I282_002D1;

		public static TreeListView.CanExpandGetterDelegate _0024I282_002D10;

		public static TreeListView.ChildrenGetterDelegate _0024I282_002D11;

		public static Func<string, string> _0024I388_002D0;

		public static Action<bool> _0024I403_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal object _Lambda_0024__282_002D0(IDescarga ele)
		{
			return ele.DescargaPrioridad();
		}

		[SpecialName]
		internal object _Lambda_0024__282_002D1(IDescarga ele)
		{
			if (ele is Fichero)
			{
				return Path.Combine(((Fichero)ele).RutaRelativa, ele.DescargaNombre());
			}
			return ele.DescargaNombre();
		}

		[SpecialName]
		internal bool _Lambda_0024__282_002D10(object ele)
		{
			if (ele is Paquete && ((Paquete)ele).ListaFicheros != null)
			{
				return ((Paquete)ele).ListaFicheros.Count > 0;
			}
			return false;
		}

		[SpecialName]
		internal IEnumerable _Lambda_0024__282_002D11(object ele)
		{
			if (!(ele is Paquete))
			{
				return null;
			}
			return ((Paquete)ele).ListaFicheros;
		}

		[SpecialName]
		internal string _Lambda_0024__388_002D0(string s)
		{
			return s;
		}

		[SpecialName]
		internal void _Lambda_0024__403_002D0(bool x)
		{
			MessageBox.Show(Language.GetText("The DLC could not be loaded. Reason: %REASON").Replace("%REASON", "30s timeout"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__312_002D0
	{
		public Fichero _0024VB_0024Local_sourcet;

		public Fichero _0024VB_0024Local_targett;

		public Predicate<Fichero> _0024I0;

		public Predicate<Fichero> _0024I1;

		public Predicate<Fichero> _0024I2;

		public _Closure_0024__312_002D0(_Closure_0024__312_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_sourcet = arg0._0024VB_0024Local_sourcet;
				_0024VB_0024Local_targett = arg0._0024VB_0024Local_targett;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(Fichero x)
		{
			return x.DescargaPrioridad() == _0024VB_0024Local_sourcet.DescargaPrioridad();
		}

		[SpecialName]
		internal bool _Lambda_0024__1(Fichero x)
		{
			return x.DescargaPrioridad() == _0024VB_0024Local_targett.DescargaPrioridad();
		}

		[SpecialName]
		internal bool _Lambda_0024__2(Fichero x)
		{
			return x.DescargaPrioridad() == _0024VB_0024Local_targett.DescargaPrioridad();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__312_002D1
	{
		public Paquete _0024VB_0024Local_sourcet;

		public Paquete _0024VB_0024Local_targett;

		public _Closure_0024__312_002D1(_Closure_0024__312_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_sourcet = arg0._0024VB_0024Local_sourcet;
				_0024VB_0024Local_targett = arg0._0024VB_0024Local_targett;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__3(Paquete x)
		{
			return x.DescargaPrioridad() == _0024VB_0024Local_sourcet.DescargaPrioridad();
		}

		[SpecialName]
		internal bool _Lambda_0024__4(Paquete x)
		{
			return x.DescargaPrioridad() == _0024VB_0024Local_targett.DescargaPrioridad();
		}

		[SpecialName]
		internal bool _Lambda_0024__5(Paquete x)
		{
			return x.DescargaPrioridad() == _0024VB_0024Local_targett.DescargaPrioridad();
		}
	}

	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("ListaDescargas")]
	private TreeListView _ListaDescargas;

	[CompilerGenerated]
	[AccessedThroughProperty("AbrirEnCarpetaToolStripMenuItem")]
	private ToolStripMenuItem _AbrirEnCarpetaToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("PropiedadesToolStripMenuItem")]
	private ToolStripMenuItem _PropiedadesToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("AgregarLinksToolStripMenuItem")]
	private ToolStripMenuItem _AgregarLinksToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("IconoMinimizado")]
	private NotifyIcon _IconoMinimizado;

	[CompilerGenerated]
	[AccessedThroughProperty("AbrirToolStripMenuItem1")]
	private ToolStripMenuItem _AbrirToolStripMenuItem1;

	[CompilerGenerated]
	[AccessedThroughProperty("CerrarToolStripMenuItem")]
	private ToolStripMenuItem _CerrarToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("btnConfig")]
	private Button _btnConfig;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCollaborate")]
	private Button _btnCollaborate;

	[CompilerGenerated]
	[AccessedThroughProperty("SubirPrioridadMenuItem")]
	private ToolStripMenuItem _SubirPrioridadMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("BajarPrioridadMenuItem")]
	private ToolStripMenuItem _BajarPrioridadMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("btnPlay")]
	private Button _btnPlay;

	[CompilerGenerated]
	[AccessedThroughProperty("btnPause")]
	private Button _btnPause;

	[CompilerGenerated]
	[AccessedThroughProperty("btnStop")]
	private Button _btnStop;

	[CompilerGenerated]
	[AccessedThroughProperty("EliminarMenuItem")]
	private ToolStripMenuItem _EliminarMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("EliminarYBorrarMenuItem")]
	private ToolStripMenuItem _EliminarYBorrarMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ResetToolStripMenuItem")]
	private ToolStripMenuItem _ResetToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("VerErrorToolStripMenuItem")]
	private ToolStripMenuItem _VerErrorToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("VerLinksToolStripMenuItem")]
	private ToolStripMenuItem _VerLinksToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("VerLinksDescToolStripMenuItem")]
	private ToolStripMenuItem _VerLinksDescToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("OcultarEnlacesImagenMenuItem")]
	private ToolStripMenuItem _OcultarEnlacesImagenMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("LimpiarCompletadosToolStripMenuItem")]
	private ToolStripMenuItem _LimpiarCompletadosToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("LimpiarCompletados2ToolStripMenuItem")]
	private ToolStripMenuItem _LimpiarCompletados2ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("btnAddLink")]
	private Button _btnAddLink;

	[CompilerGenerated]
	[AccessedThroughProperty("PausarStripMenuItem")]
	private ToolStripMenuItem _PausarStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("btnUpdate")]
	private Button _btnUpdate;

	[CompilerGenerated]
	[AccessedThroughProperty("AgregarLinkStripMenuItem")]
	private ToolStripMenuItem _AgregarLinkStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("VerProgresoDescompresionToolStripMenuItem")]
	private ToolStripMenuItem _VerProgresoDescompresionToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ForceDownloadStripMenuItem")]
	private ToolStripMenuItem _ForceDownloadStripMenuItem;

	public Configuracion Config;

	public bool NecesitaCambiarUsuarioYPassword;

	private List<Paquete> ListaPaquetes;

	[CompilerGenerated]
	[AccessedThroughProperty("clipChange")]
	private ClipboardViewer _clipChange;

	[CompilerGenerated]
	[AccessedThroughProperty("dropSink")]
	private SimpleDropSink _dropSink;

	[CompilerGenerated]
	[AccessedThroughProperty("bgwComprobarMaxConexiones")]
	private BackgroundWorker _bgwComprobarMaxConexiones;

	[CompilerGenerated]
	[AccessedThroughProperty("bgwActualizadorListaDescargas")]
	private BackgroundWorker _bgwActualizadorListaDescargas;

	[CompilerGenerated]
	[AccessedThroughProperty("bgwActualizadorDatosDisco")]
	private BackgroundWorker _bgwActualizadorDatosDisco;

	[CompilerGenerated]
	[AccessedThroughProperty("bgwDescompresor")]
	private BackgroundWorker _bgwDescompresor;

	private bool bgwComprobarMaxConexionesCompleted;

	private bool bgwActualizadorListaDescargasCompleted;

	private bool bgwActualizadorDatosDiscoCompleted;

	private bool bgwDescompresorCompleted;

	private DateTime PeticionGuardadoConfig;

	private DateTime UltimoGuardadoConfig;

	private DateTime PeticionGuardadoFichero;

	private DateTime UltimoGuardadoFichero;

	private DateTime ProximoFlushMemoria;

	private DateTime ProximaComprobacionMaxConexiones;

	private decimal? VelocidadGlobalDescarga;

	private int? NumDescargasActivas;

	private int? NumDescargasEnCola;

	private int? NumDescargasErroneas;

	private int? NumDescargasCompletadas;

	private int NumeroConexionesMaxima;

	private string UrlNuevaVersionMegadownloader;

	private string VersionNuevaVersionMegadownloader;

	private PerformanceCounter ProcesadorCounter;

	private PerformanceCounter RAMCounter;

	private int NumCores;

	private TipoEstadoAplicacion EstadoAplicacion;

	private bool Cerrando;

	private bool _ForzarCierre;

	private System.Timers.Timer _Timer;

	private DateTime? ProximoAvisoActualizacion;

	private bool DLCProcessing;

	private string DLCPath;

	private List<string> DLCResults;

	private Exception DLCErrorProcessing;

	internal virtual TreeListView ListaDescargas
	{
		[CompilerGenerated]
		get
		{
			return _ListaDescargas;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<FormatRowEventArgs> eventHandler = ListaDescargas_FormatRow;
			DragEventHandler value2 = ListaDescargas_DragDrop;
			EventHandler<OlvDropEventArgs> eventHandler2 = ListaDescargas_CanDrop;
			EventHandler<CellRightClickEventArgs> eventHandler3 = ListaDescargas_CellRightClick;
			TreeListView val = _ListaDescargas;
			if (val != null)
			{
				((ObjectListView)val).FormatRow -= eventHandler;
				((Control)(object)val).DragDrop -= value2;
				((ObjectListView)val).CanDrop -= eventHandler2;
				((ObjectListView)val).CellRightClick -= eventHandler3;
			}
			_ListaDescargas = value;
			val = _ListaDescargas;
			if (val != null)
			{
				((ObjectListView)val).FormatRow += eventHandler;
				((Control)(object)val).DragDrop += value2;
				((ObjectListView)val).CanDrop += eventHandler2;
				((ObjectListView)val).CellRightClick += eventHandler3;
			}
		}
	}

	[field: AccessedThroughProperty("OlvColumnNombre")]
	internal virtual OLVColumn OlvColumnNombre
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OlvColumnTamano")]
	internal virtual OLVColumn OlvColumnTamano
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OlvColumnProgreso")]
	internal virtual OLVColumn OlvColumnProgreso
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OlvColumnVelocidad")]
	internal virtual OLVColumn OlvColumnVelocidad
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("MenuDescarga")]
	internal virtual ContextMenuStrip MenuDescarga
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem AbrirEnCarpetaToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AbrirEnCarpetaToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AbrirEnCarpetaToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _AbrirEnCarpetaToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_AbrirEnCarpetaToolStripMenuItem = value;
			toolStripMenuItem = _AbrirEnCarpetaToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem PropiedadesToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _PropiedadesToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PropiedadesToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _PropiedadesToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_PropiedadesToolStripMenuItem = value;
			toolStripMenuItem = _PropiedadesToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("MenuPanel")]
	internal virtual ContextMenuStrip MenuPanel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem AgregarLinksToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AgregarLinksToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AgregarLinksToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _AgregarLinksToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_AgregarLinksToolStripMenuItem = value;
			toolStripMenuItem = _AgregarLinksToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("OlvColumnEstado")]
	internal virtual OLVColumn OlvColumnEstado
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OlvColumnPrioridad")]
	internal virtual OLVColumn OlvColumnPrioridad
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual NotifyIcon IconoMinimizado
	{
		[CompilerGenerated]
		get
		{
			return _IconoMinimizado;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IconoMinimizado_DoubleClick;
			EventHandler value3 = IconoMinimizado_Click;
			NotifyIcon notifyIcon = _IconoMinimizado;
			if (notifyIcon != null)
			{
				notifyIcon.DoubleClick -= value2;
				notifyIcon.Click -= value3;
			}
			_IconoMinimizado = value;
			notifyIcon = _IconoMinimizado;
			if (notifyIcon != null)
			{
				notifyIcon.DoubleClick += value2;
				notifyIcon.Click += value3;
			}
		}
	}

	[field: AccessedThroughProperty("MenuMinimizado")]
	internal virtual ContextMenuStrip MenuMinimizado
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem AbrirToolStripMenuItem1
	{
		[CompilerGenerated]
		get
		{
			return _AbrirToolStripMenuItem1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AbrirToolStripMenuItem1_Click;
			ToolStripMenuItem toolStripMenuItem = _AbrirToolStripMenuItem1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_AbrirToolStripMenuItem1 = value;
			toolStripMenuItem = _AbrirToolStripMenuItem1;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem CerrarToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _CerrarToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CerrarToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _CerrarToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_CerrarToolStripMenuItem = value;
			toolStripMenuItem = _CerrarToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual Button btnConfig
	{
		[CompilerGenerated]
		get
		{
			return _btnConfig;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnConfig_Click;
			Button button = _btnConfig;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnConfig = value;
			button = _btnConfig;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnCollaborate
	{
		[CompilerGenerated]
		get
		{
			return _btnCollaborate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Collaborate_Click;
			Button button = _btnCollaborate;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnCollaborate = value;
			button = _btnCollaborate;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator2")]
	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem SubirPrioridadMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _SubirPrioridadMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SubirPrioridad_Click;
			ToolStripMenuItem toolStripMenuItem = _SubirPrioridadMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_SubirPrioridadMenuItem = value;
			toolStripMenuItem = _SubirPrioridadMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem BajarPrioridadMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _BajarPrioridadMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BajarPrioridadMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _BajarPrioridadMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_BajarPrioridadMenuItem = value;
			toolStripMenuItem = _BajarPrioridadMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnPlay
	{
		[CompilerGenerated]
		get
		{
			return _btnPlay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnPlay_Click;
			Button button = _btnPlay;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnPlay = value;
			button = _btnPlay;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnPause
	{
		[CompilerGenerated]
		get
		{
			return _btnPause;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnPause_Click;
			Button button = _btnPause;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnPause = value;
			button = _btnPause;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnStop
	{
		[CompilerGenerated]
		get
		{
			return _btnStop;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnStop_Click;
			Button button = _btnStop;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnStop = value;
			button = _btnStop;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator3")]
	internal virtual ToolStripSeparator ToolStripSeparator3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem EliminarMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _EliminarMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EliminarMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _EliminarMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_EliminarMenuItem = value;
			toolStripMenuItem = _EliminarMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem EliminarYBorrarMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _EliminarYBorrarMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EliminarYBorrarMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _EliminarYBorrarMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_EliminarYBorrarMenuItem = value;
			toolStripMenuItem = _EliminarYBorrarMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("StatusStrip1")]
	internal virtual StatusStrip StatusStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("RAMProcToolStripStatusLabel")]
	internal virtual ToolStripStatusLabel RAMProcToolStripStatusLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("StatusToolStripStatusLabel")]
	internal virtual ToolStripStatusLabel StatusToolStripStatusLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem ResetToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ResetToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _ResetToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ResetToolStripMenuItem = value;
			toolStripMenuItem = _ResetToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("OlvColumnEDT")]
	internal virtual OLVColumn OlvColumnEDT
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OlvColumnProgresoPorc")]
	internal virtual OLVColumn OlvColumnProgresoPorc
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OlvColumnDescargado")]
	internal virtual OLVColumn OlvColumnDescargado
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OlvColumnRestante")]
	internal virtual OLVColumn OlvColumnRestante
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem VerErrorToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _VerErrorToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerErrorToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _VerErrorToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_VerErrorToolStripMenuItem = value;
			toolStripMenuItem = _VerErrorToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem VerLinksToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _VerLinksToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerLinksToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _VerLinksToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_VerLinksToolStripMenuItem = value;
			toolStripMenuItem = _VerLinksToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem VerLinksDescToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _VerLinksDescToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerLinksDescToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _VerLinksDescToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_VerLinksDescToolStripMenuItem = value;
			toolStripMenuItem = _VerLinksDescToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem OcultarEnlacesImagenMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _OcultarEnlacesImagenMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OcultarEnlacesImagenMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _OcultarEnlacesImagenMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_OcultarEnlacesImagenMenuItem = value;
			toolStripMenuItem = _OcultarEnlacesImagenMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem LimpiarCompletadosToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _LimpiarCompletadosToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LimpiarCompletadosToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _LimpiarCompletadosToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_LimpiarCompletadosToolStripMenuItem = value;
			toolStripMenuItem = _LimpiarCompletadosToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem LimpiarCompletados2ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _LimpiarCompletados2ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LimpiarCompletados2ToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _LimpiarCompletados2ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_LimpiarCompletados2ToolStripMenuItem = value;
			toolStripMenuItem = _LimpiarCompletados2ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator4")]
	internal virtual ToolStripSeparator ToolStripSeparator4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnAddLink
	{
		[CompilerGenerated]
		get
		{
			return _btnAddLink;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnAddLink_Click;
			Button button = _btnAddLink;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnAddLink = value;
			button = _btnAddLink;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem PausarStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _PausarStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PausarStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _PausarStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_PausarStripMenuItem = value;
			toolStripMenuItem = _PausarStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolTipBotones")]
	internal virtual ToolTip ToolTipBotones
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnUpdate_Click;
			Button button = _btnUpdate;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnUpdate = value;
			button = _btnUpdate;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AgregarLinkStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AgregarLinkStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AgregarLinkStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _AgregarLinkStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_AgregarLinkStripMenuItem = value;
			toolStripMenuItem = _AgregarLinkStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("PanelButtonsRight")]
	internal virtual Panel PanelButtonsRight
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem VerProgresoDescompresionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _VerProgresoDescompresionToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerProgresoDescompresionToolStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _VerProgresoDescompresionToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_VerProgresoDescompresionToolStripMenuItem = value;
			toolStripMenuItem = _VerProgresoDescompresionToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ForceDownloadStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ForceDownloadStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForceDownloadStripMenuItem_Click;
			ToolStripMenuItem toolStripMenuItem = _ForceDownloadStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_ForceDownloadStripMenuItem = value;
			toolStripMenuItem = _ForceDownloadStripMenuItem;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	private ClipboardViewer clipChange
	{
		[CompilerGenerated]
		get
		{
			return _clipChange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<HandledEventArgs> obj = clipChange_ClipboardChanged;
			ClipboardViewer clipboardViewer = _clipChange;
			if (clipboardViewer != null)
			{
				clipboardViewer.ClipboardChanged -= obj;
			}
			_clipChange = value;
			clipboardViewer = _clipChange;
			if (clipboardViewer != null)
			{
				clipboardViewer.ClipboardChanged += obj;
			}
		}
	}

	private SimpleDropSink dropSink
	{
		[CompilerGenerated]
		get
		{
			return _dropSink;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ModelDropEventArgs> eventHandler = dropSink_ModelDropped;
			SimpleDropSink val = _dropSink;
			if (val != null)
			{
				val.ModelDropped -= eventHandler;
			}
			_dropSink = value;
			val = _dropSink;
			if (val != null)
			{
				val.ModelDropped += eventHandler;
			}
		}
	}

	private BackgroundWorker bgwComprobarMaxConexiones
	{
		[CompilerGenerated]
		get
		{
			return _bgwComprobarMaxConexiones;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgwComprobarMaxConexiones_DoWork;
			RunWorkerCompletedEventHandler value3 = bgwComprobarMaxConexiones_RunWorkerCompleted;
			BackgroundWorker backgroundWorker = _bgwComprobarMaxConexiones;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			_bgwComprobarMaxConexiones = value;
			backgroundWorker = _bgwComprobarMaxConexiones;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	private BackgroundWorker bgwActualizadorListaDescargas
	{
		[CompilerGenerated]
		get
		{
			return _bgwActualizadorListaDescargas;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgwActualizadorListaDescargas_DoWork;
			RunWorkerCompletedEventHandler value3 = bgwActualizadorListaDescargas_RunWorkerCompleted;
			BackgroundWorker backgroundWorker = _bgwActualizadorListaDescargas;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			_bgwActualizadorListaDescargas = value;
			backgroundWorker = _bgwActualizadorListaDescargas;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	private BackgroundWorker bgwActualizadorDatosDisco
	{
		[CompilerGenerated]
		get
		{
			return _bgwActualizadorDatosDisco;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgwActualizadorDatosDisco_DoWork;
			RunWorkerCompletedEventHandler value3 = bgwActualizadorDatosDisco_RunWorkerCompleted;
			BackgroundWorker backgroundWorker = _bgwActualizadorDatosDisco;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
				backgroundWorker.RunWorkerCompleted -= value3;
			}
			_bgwActualizadorDatosDisco = value;
			backgroundWorker = _bgwActualizadorDatosDisco;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
				backgroundWorker.RunWorkerCompleted += value3;
			}
		}
	}

	private BackgroundWorker bgwDescompresor
	{
		[CompilerGenerated]
		get
		{
			return _bgwDescompresor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RunWorkerCompletedEventHandler value2 = bgwDescompresor_RunWorkerCompleted;
			BackgroundWorker backgroundWorker = _bgwDescompresor;
			if (backgroundWorker != null)
			{
				backgroundWorker.RunWorkerCompleted -= value2;
			}
			_bgwDescompresor = value;
			backgroundWorker = _bgwDescompresor;
			if (backgroundWorker != null)
			{
				backgroundWorker.RunWorkerCompleted += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		this.components = new System.ComponentModel.Container();
		this.ListaDescargas = new TreeListView();
		this.OlvColumnPrioridad = new OLVColumn();
		this.OlvColumnNombre = new OLVColumn();
		this.OlvColumnDescargado = new OLVColumn();
		this.OlvColumnTamano = new OLVColumn();
		this.OlvColumnEstado = new OLVColumn();
		this.OlvColumnProgresoPorc = new OLVColumn();
		this.OlvColumnProgreso = new OLVColumn();
		this.OlvColumnVelocidad = new OLVColumn();
		this.OlvColumnEDT = new OLVColumn();
		this.OlvColumnRestante = new OLVColumn();
		this.PanelButtonsRight = new System.Windows.Forms.Panel();
		this.btnCollaborate = new System.Windows.Forms.Button();
		this.btnConfig = new System.Windows.Forms.Button();
		this.MenuDescarga = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.AbrirEnCarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.SubirPrioridadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.BajarPrioridadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.ForceDownloadStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.PausarStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.EliminarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.EliminarYBorrarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.VerErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.VerLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.VerLinksDescToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.OcultarEnlacesImagenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.VerProgresoDescompresionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.LimpiarCompletados2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.PropiedadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.MenuPanel = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.AgregarLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.LimpiarCompletadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.IconoMinimizado = new System.Windows.Forms.NotifyIcon(this.components);
		this.MenuMinimizado = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.AbrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.AgregarLinkStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.CerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.btnPlay = new System.Windows.Forms.Button();
		this.btnPause = new System.Windows.Forms.Button();
		this.btnStop = new System.Windows.Forms.Button();
		this.btnAddLink = new System.Windows.Forms.Button();
		this.btnUpdate = new System.Windows.Forms.Button();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.StatusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
		this.RAMProcToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolTipBotones = new System.Windows.Forms.ToolTip(this.components);
		((System.ComponentModel.ISupportInitialize)this.ListaDescargas).BeginInit();
		this.PanelButtonsRight.SuspendLayout();
		this.MenuDescarga.SuspendLayout();
		this.MenuPanel.SuspendLayout();
		this.MenuMinimizado.SuspendLayout();
		this.TableLayoutPanel1.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		base.SuspendLayout();
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnPrioridad);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnNombre);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnDescargado);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnTamano);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnEstado);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnProgresoPorc);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnProgreso);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnVelocidad);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnEDT);
		((ObjectListView)this.ListaDescargas).AllColumns.Add(this.OlvColumnRestante);
		((System.Windows.Forms.Control)(object)this.ListaDescargas).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		((ObjectListView)this.ListaDescargas).Columns.AddRange(new System.Windows.Forms.ColumnHeader[8]
		{
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnPrioridad,
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnNombre,
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnDescargado,
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnTamano,
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnEstado,
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnProgreso,
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnVelocidad,
			(System.Windows.Forms.ColumnHeader)(object)this.OlvColumnEDT
		});
		((System.Windows.Forms.Control)(object)this.ListaDescargas).Location = new System.Drawing.Point(12, 46);
		((System.Windows.Forms.Control)(object)this.ListaDescargas).Name = "ListaDescargas";
		((System.Windows.Forms.ListView)(object)this.ListaDescargas).OwnerDraw = true;
		((VirtualObjectListView)this.ListaDescargas).ShowGroups = false;
		((System.Windows.Forms.Control)(object)this.ListaDescargas).Size = new System.Drawing.Size(580, 311);
		((System.Windows.Forms.Control)(object)this.ListaDescargas).TabIndex = 0;
		((System.Windows.Forms.ListView)(object)this.ListaDescargas).UseCompatibleStateImageBehavior = false;
		((ObjectListView)this.ListaDescargas).View = System.Windows.Forms.View.Details;
		((System.Windows.Forms.ListView)(object)this.ListaDescargas).VirtualMode = true;
		this.OlvColumnPrioridad.Hideable = false;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnPrioridad).Text = "#";
		this.OlvColumnPrioridad.Width = 20;
		this.OlvColumnNombre.FillsFreeSpace = true;
		this.OlvColumnNombre.Hideable = false;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnNombre).Text = "Nombre";
		this.OlvColumnNombre.Width = 185;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnDescargado).Text = "Descargado";
		this.OlvColumnDescargado.Width = 70;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnTamano).Text = "Tamaño";
		this.OlvColumnTamano.Width = 70;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnEstado).Text = "Estado";
		this.OlvColumnEstado.Width = 50;
		this.OlvColumnProgresoPorc.IsVisible = false;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnProgresoPorc).Text = "Progreso %";
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnProgreso).Text = "Progreso";
		this.OlvColumnProgreso.Width = 80;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnVelocidad).Text = "Velocidad";
		this.OlvColumnVelocidad.Width = 77;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnEDT).Text = "Estimado";
		this.OlvColumnEDT.Width = 70;
		this.OlvColumnRestante.IsVisible = false;
		((System.Windows.Forms.ColumnHeader)(object)this.OlvColumnRestante).Text = "Restante";
		this.PanelButtonsRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.PanelButtonsRight.Controls.Add(this.btnCollaborate);
		this.PanelButtonsRight.Controls.Add(this.btnConfig);
		this.PanelButtonsRight.Location = new System.Drawing.Point(512, 3);
		this.PanelButtonsRight.Name = "PanelButtonsRight";
		this.PanelButtonsRight.Size = new System.Drawing.Size(80, 34);
		this.PanelButtonsRight.TabIndex = 0;
		this.btnCollaborate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnCollaborate.Location = new System.Drawing.Point(6, 0);
		this.btnCollaborate.Name = "btnCollaborate";
		this.btnCollaborate.Size = new System.Drawing.Size(35, 34);
		this.btnCollaborate.TabIndex = 6;
		this.ToolTipBotones.SetToolTip(this.btnCollaborate, "Colaborar");
		this.btnCollaborate.UseVisualStyleBackColor = true;
		this.btnConfig.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnConfig.Location = new System.Drawing.Point(46, 0);
		this.btnConfig.Name = "btnConfig";
		this.btnConfig.Size = new System.Drawing.Size(35, 34);
		this.btnConfig.TabIndex = 7;
		this.ToolTipBotones.SetToolTip(this.btnConfig, "Configuración");
		this.btnConfig.UseVisualStyleBackColor = true;
		this.MenuDescarga.Items.AddRange(new System.Windows.Forms.ToolStripItem[19]
		{
			this.AbrirEnCarpetaToolStripMenuItem, this.ToolStripSeparator2, this.SubirPrioridadMenuItem, this.BajarPrioridadMenuItem, this.ToolStripSeparator3, this.ForceDownloadStripMenuItem, this.PausarStripMenuItem, this.EliminarMenuItem, this.EliminarYBorrarMenuItem, this.ToolStripSeparator1,
			this.VerErrorToolStripMenuItem, this.VerLinksToolStripMenuItem, this.VerLinksDescToolStripMenuItem, this.OcultarEnlacesImagenMenuItem, this.ToolStripSeparator4, this.VerProgresoDescompresionToolStripMenuItem, this.ResetToolStripMenuItem, this.LimpiarCompletados2ToolStripMenuItem, this.PropiedadesToolStripMenuItem
		});
		this.MenuDescarga.Name = "MenuDescarga";
		this.MenuDescarga.Size = new System.Drawing.Size(226, 336);
		this.AbrirEnCarpetaToolStripMenuItem.Name = "AbrirEnCarpetaToolStripMenuItem";
		this.AbrirEnCarpetaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.AbrirEnCarpetaToolStripMenuItem.Text = "Abrir directorio";
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		this.ToolStripSeparator2.Size = new System.Drawing.Size(222, 6);
		this.SubirPrioridadMenuItem.Name = "SubirPrioridadMenuItem";
		this.SubirPrioridadMenuItem.Size = new System.Drawing.Size(225, 22);
		this.SubirPrioridadMenuItem.Text = "Subir prioridad";
		this.BajarPrioridadMenuItem.Name = "BajarPrioridadMenuItem";
		this.BajarPrioridadMenuItem.Size = new System.Drawing.Size(225, 22);
		this.BajarPrioridadMenuItem.Text = "Bajar prioridad";
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		this.ToolStripSeparator3.Size = new System.Drawing.Size(222, 6);
		this.ForceDownloadStripMenuItem.Name = "ForceDownloadStripMenuItem";
		this.ForceDownloadStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.ForceDownloadStripMenuItem.Text = "Forzar descarga";
		this.PausarStripMenuItem.Name = "PausarStripMenuItem";
		this.PausarStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.PausarStripMenuItem.Text = "Poner en pausa";
		this.EliminarMenuItem.Name = "EliminarMenuItem";
		this.EliminarMenuItem.Size = new System.Drawing.Size(225, 22);
		this.EliminarMenuItem.Text = "Eliminar";
		this.EliminarYBorrarMenuItem.Name = "EliminarYBorrarMenuItem";
		this.EliminarYBorrarMenuItem.Size = new System.Drawing.Size(225, 22);
		this.EliminarYBorrarMenuItem.Text = "Eliminar y borrar";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		this.ToolStripSeparator1.Size = new System.Drawing.Size(222, 6);
		this.VerErrorToolStripMenuItem.Name = "VerErrorToolStripMenuItem";
		this.VerErrorToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.VerErrorToolStripMenuItem.Text = "Ver error";
		this.VerLinksToolStripMenuItem.Name = "VerLinksToolStripMenuItem";
		this.VerLinksToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.VerLinksToolStripMenuItem.Text = "Ver links";
		this.VerLinksDescToolStripMenuItem.Name = "VerLinksDescToolStripMenuItem";
		this.VerLinksDescToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.VerLinksDescToolStripMenuItem.Text = "Ver links + desc";
		this.OcultarEnlacesImagenMenuItem.Name = "OcultarEnlacesImagenMenuItem";
		this.OcultarEnlacesImagenMenuItem.Size = new System.Drawing.Size(225, 22);
		this.OcultarEnlacesImagenMenuItem.Text = "Ocultar en imagen";
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		this.ToolStripSeparator4.Size = new System.Drawing.Size(222, 6);
		this.VerProgresoDescompresionToolStripMenuItem.Name = "VerProgresoDescompresionToolStripMenuItem";
		this.VerProgresoDescompresionToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.VerProgresoDescompresionToolStripMenuItem.Text = "Ver progreso descompresión";
		this.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem";
		this.ResetToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.ResetToolStripMenuItem.Text = "Reset";
		this.LimpiarCompletados2ToolStripMenuItem.Name = "LimpiarCompletados2ToolStripMenuItem";
		this.LimpiarCompletados2ToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.LimpiarCompletados2ToolStripMenuItem.Text = "Limpiar completados";
		this.PropiedadesToolStripMenuItem.Enabled = false;
		this.PropiedadesToolStripMenuItem.Name = "PropiedadesToolStripMenuItem";
		this.PropiedadesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
		this.PropiedadesToolStripMenuItem.Text = "Propiedades";
		this.MenuPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.AgregarLinksToolStripMenuItem, this.LimpiarCompletadosToolStripMenuItem });
		this.MenuPanel.Name = "MenuPanel";
		this.MenuPanel.Size = new System.Drawing.Size(187, 48);
		this.AgregarLinksToolStripMenuItem.Name = "AgregarLinksToolStripMenuItem";
		this.AgregarLinksToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.AgregarLinksToolStripMenuItem.Text = "Agregar links";
		this.LimpiarCompletadosToolStripMenuItem.Name = "LimpiarCompletadosToolStripMenuItem";
		this.LimpiarCompletadosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
		this.LimpiarCompletadosToolStripMenuItem.Text = "Limpiar completados";
		this.IconoMinimizado.ContextMenuStrip = this.MenuMinimizado;
		this.IconoMinimizado.Icon = MegaDownloader.My.Resources.Resources.icono;
		this.IconoMinimizado.Text = "NotifyIcon1";
		this.IconoMinimizado.Visible = true;
		this.MenuMinimizado.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.AbrirToolStripMenuItem1, this.AgregarLinkStripMenuItem, this.CerrarToolStripMenuItem });
		this.MenuMinimizado.Name = "MenuMinimizado";
		this.MenuMinimizado.Size = new System.Drawing.Size(139, 70);
		this.AbrirToolStripMenuItem1.Name = "AbrirToolStripMenuItem1";
		this.AbrirToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
		this.AbrirToolStripMenuItem1.Text = "Abrir";
		this.AgregarLinkStripMenuItem.Name = "AgregarLinkStripMenuItem";
		this.AgregarLinkStripMenuItem.Size = new System.Drawing.Size(138, 22);
		this.AgregarLinkStripMenuItem.Text = "Agregar link";
		this.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem";
		this.CerrarToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
		this.CerrarToolStripMenuItem.Text = "Cerrar";
		this.TableLayoutPanel1.ColumnCount = 6;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120f));
		this.TableLayoutPanel1.Controls.Add(this.btnPlay, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.btnPause, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.btnStop, 2, 0);
		this.TableLayoutPanel1.Controls.Add(this.btnAddLink, 3, 0);
		this.TableLayoutPanel1.Controls.Add(this.btnUpdate, 4, 0);
		this.TableLayoutPanel1.Controls.Add(this.PanelButtonsRight, 5, 0);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.Padding = new System.Windows.Forms.Padding(9, 0, 9, 0);
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.Size = new System.Drawing.Size(604, 40);
		this.TableLayoutPanel1.TabIndex = 4;
		this.btnPlay.Location = new System.Drawing.Point(12, 3);
		this.btnPlay.Name = "btnPlay";
		this.btnPlay.Size = new System.Drawing.Size(34, 34);
		this.btnPlay.TabIndex = 1;
		this.ToolTipBotones.SetToolTip(this.btnPlay, "Iniciar descargas");
		this.btnPlay.UseVisualStyleBackColor = true;
		this.btnPause.Location = new System.Drawing.Point(52, 3);
		this.btnPause.Name = "btnPause";
		this.btnPause.Size = new System.Drawing.Size(34, 34);
		this.btnPause.TabIndex = 2;
		this.ToolTipBotones.SetToolTip(this.btnPause, "Pausar descargas");
		this.btnPause.UseVisualStyleBackColor = true;
		this.btnStop.Location = new System.Drawing.Point(92, 3);
		this.btnStop.Name = "btnStop";
		this.btnStop.Size = new System.Drawing.Size(34, 34);
		this.btnStop.TabIndex = 3;
		this.ToolTipBotones.SetToolTip(this.btnStop, "Detener descargas");
		this.btnStop.UseVisualStyleBackColor = true;
		this.btnAddLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnAddLink.Location = new System.Drawing.Point(147, 3);
		this.btnAddLink.Name = "btnAddLink";
		this.btnAddLink.Size = new System.Drawing.Size(34, 34);
		this.btnAddLink.TabIndex = 4;
		this.ToolTipBotones.SetToolTip(this.btnAddLink, "Agregar links");
		this.btnAddLink.UseVisualStyleBackColor = true;
		this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnUpdate.Location = new System.Drawing.Point(187, 3);
		this.btnUpdate.Name = "btnUpdate";
		this.btnUpdate.Size = new System.Drawing.Size(34, 34);
		this.btnUpdate.TabIndex = 6;
		this.ToolTipBotones.SetToolTip(this.btnUpdate, "Existe una versión nueva de Megadownloader, haga click aquí para descargarla");
		this.btnUpdate.UseVisualStyleBackColor = true;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.StatusToolStripStatusLabel, this.RAMProcToolStripStatusLabel });
		this.StatusStrip1.Location = new System.Drawing.Point(0, 360);
		this.StatusStrip1.Name = "StatusStrip1";
		this.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.StatusStrip1.Size = new System.Drawing.Size(604, 22);
		this.StatusStrip1.TabIndex = 5;
		this.StatusStrip1.Text = "StatusStrip1";
		this.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel";
		this.StatusToolStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.StatusToolStripStatusLabel.Size = new System.Drawing.Size(499, 17);
		this.StatusToolStripStatusLabel.Spring = true;
		this.StatusToolStripStatusLabel.Text = "Estado: -";
		this.StatusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.RAMProcToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.RAMProcToolStripStatusLabel.Name = "RAMProcToolStripStatusLabel";
		this.RAMProcToolStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.RAMProcToolStripStatusLabel.Size = new System.Drawing.Size(90, 17);
		this.RAMProcToolStripStatusLabel.Text = "RAM: - / Proc: -";
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(604, 382);
		base.Controls.Add(this.StatusStrip1);
		base.Controls.Add(this.TableLayoutPanel1);
		base.Controls.Add((System.Windows.Forms.Control)(object)this.ListaDescargas);
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		this.MinimumSize = new System.Drawing.Size(410, 250);
		base.Name = "Main";
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "MegaDownloader";
		((System.ComponentModel.ISupportInitialize)this.ListaDescargas).EndInit();
		this.PanelButtonsRight.ResumeLayout(false);
		this.MenuDescarga.ResumeLayout(false);
		this.MenuPanel.ResumeLayout(false);
		this.MenuMinimizado.ResumeLayout(false);
		this.TableLayoutPanel1.ResumeLayout(false);
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	public Main()
	{
		base.Load += Main_Load;
		base.Shown += Main_Shown;
		base.FormClosed += Main_FormClosed;
		base.FormClosing += Main_FormClosing;
		base.Resize += Main_Resize;
		base.DragDrop += Main_DragDrop;
		base.DragEnter += Main_DragEnter;
		NecesitaCambiarUsuarioYPassword = false;
		bgwComprobarMaxConexiones = new BackgroundWorker();
		bgwActualizadorListaDescargas = new BackgroundWorker();
		bgwActualizadorDatosDisco = new BackgroundWorker();
		bgwDescompresor = new BackgroundWorker();
		bgwComprobarMaxConexionesCompleted = false;
		bgwActualizadorListaDescargasCompleted = false;
		bgwActualizadorDatosDiscoCompleted = false;
		bgwDescompresorCompleted = false;
		PeticionGuardadoConfig = DateTime.MinValue;
		UltimoGuardadoConfig = DateTime.MinValue;
		PeticionGuardadoFichero = DateTime.MinValue;
		UltimoGuardadoFichero = DateTime.MinValue;
		ProximoFlushMemoria = DateTime.MinValue;
		ProximaComprobacionMaxConexiones = DateAndTime.Now;
		VelocidadGlobalDescarga = null;
		NumDescargasActivas = null;
		NumDescargasEnCola = null;
		NumDescargasErroneas = null;
		NumDescargasCompletadas = null;
		EstadoAplicacion = TipoEstadoAplicacion.Parado;
		Cerrando = false;
		_ForzarCierre = false;
		ProximoAvisoActualizacion = null;
		DLCProcessing = false;
		DLCPath = string.Empty;
		DLCResults = null;
		DLCErrorProcessing = null;
		InitializeComponent();
	}

	private void Main_Load(object sender, EventArgs e)
	{
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		MyApplication.Main_Form = this;
		Log.WriteError("Starting Megadownloader");
		Log.WriteError("Version: " + InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_MEGADOWNLOADER"));
		Config = new Configuracion();
		Log.SetLogLevel = Config.NivelLog;
		Language.InitLanguage(Config.Idioma);
		bool num = IsSilent();
		SplashScreen splashScreen = null;
		if (!num)
		{
			splashScreen = new SplashScreen();
			splashScreen.Show();
		}
		base.Visible = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Translate();
		InicializarMonitores();
		clipChange = new ClipboardViewer();
		clipChange.AssignHandle(base.Handle);
		clipChange.Install();
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + ".config.png");
		btnConfig.Image = Image.FromStream(manifestResourceStream);
		manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + ".pause.png");
		btnPause.Image = Image.FromStream(manifestResourceStream);
		manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + ".play.png");
		btnPlay.Image = Image.FromStream(manifestResourceStream);
		manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + ".stop.png");
		btnStop.Image = Image.FromStream(manifestResourceStream);
		manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + ".addlink.png");
		btnAddLink.Image = Image.FromStream(manifestResourceStream);
		manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + ".download.png");
		btnUpdate.Image = Image.FromStream(manifestResourceStream);
		manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + ".collaborate.png");
		btnCollaborate.Image = Image.FromStream(manifestResourceStream);
		CrearMenus();
		btnCollaborate.Visible = false;
		btnUpdate.Visible = false;
		if (base.WindowState != FormWindowState.Minimized)
		{
			IconoMinimizado.Visible = false;
		}
		ListaPaquetes = Paquete.CargarDesdeFichero();
		DefinirColumnas();
		((ObjectListView)ListaDescargas).SetObjects((IEnumerable)ListaPaquetes);
		Priority.DecompressionPriority = Config.PrioridadDescompresion;
		Conexion.PingMega();
		NumeroConexionesMaxima = Config.MaxConexionesGuardadas;
		Log.WriteInfo("Starting workers");
		bgwComprobarMaxConexiones.WorkerReportsProgress = true;
		bgwComprobarMaxConexiones.WorkerSupportsCancellation = true;
		bgwComprobarMaxConexiones.RunWorkerAsync();
		bgwActualizadorListaDescargas.WorkerReportsProgress = true;
		bgwActualizadorListaDescargas.WorkerSupportsCancellation = true;
		bgwActualizadorListaDescargas.RunWorkerAsync();
		bgwActualizadorDatosDisco.WorkerReportsProgress = true;
		bgwActualizadorDatosDisco.WorkerSupportsCancellation = true;
		bgwActualizadorDatosDisco.RunWorkerAsync();
		bgwDescompresor.DoWork += DescompresorController.DescompresorController_DoWork;
		bgwDescompresor.WorkerReportsProgress = true;
		bgwDescompresor.WorkerSupportsCancellation = true;
		bgwDescompresor.RunWorkerAsync();
		DescompresorController.GetController().DescompresionFinalizada += DescompresionFinalizada_EventHandler;
		if (Config.IniciarConWindows)
		{
			Configuracion.RegisterInStartup(isChecked: true);
		}
		if (!num)
		{
			splashScreen.Close();
			base.Visible = true;
		}
		MegaURIProtocol.RegisterUrlProtocol();
		if (Config.ComenzarDescargando)
		{
			QuitarPausasIndividuales();
			EstadoAplicacion = TipoEstadoAplicacion.Descargando;
		}
		Log.WriteInfo("Start process finished");
	}

	private void Main_Shown(object sender, EventArgs e)
	{
		Text = InternalConfiguration.ObtenerNombreApp() + InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_MEGADOWNLOADER");
		if ((Config.ConfigUI.AltoVentanaPrincipal > 0) & (Config.ConfigUI.AnchoVentanaPrincipal > 0))
		{
			Log.WriteDebug("Window size - X: " + Conversions.ToString(Config.ConfigUI.AnchoVentanaPrincipal) + " Y:" + Conversions.ToString(Config.ConfigUI.AltoVentanaPrincipal));
			base.Size = new Size(Config.ConfigUI.AnchoVentanaPrincipal, Config.ConfigUI.AltoVentanaPrincipal);
			base.StartPosition = FormStartPosition.CenterScreen;
			Main_Resize(null, null);
		}
		Screen screen = Screen.FromPoint(base.Location);
		base.Location = checked(new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0)));
		if (Config.ConfigUI.EstadoLista != null)
		{
			Log.WriteDebug("Restoring columns");
			((ObjectListView)ListaDescargas).RestoreState(Config.ConfigUI.EstadoLista);
		}
		if (CheckMEGAConditions())
		{
			CheckVersionStatistics();
			if (Config.ErrorConfig != Configuracion.ErrorConfigClass.SinErrores)
			{
				Log.WriteWarning("Invalid configuration, opening configuration form.");
				Configuration configuration = new Configuration();
				configuration.MainForm = this;
				configuration.Config = Config;
				configuration.RequiereConfiguracion = true;
				configuration.ShowDialog();
				configuration.Dispose();
			}
			Log.WriteDebug("App render finished");
			if (IsSilent())
			{
				IconoMinimizado.Text = "MegaDownloader started";
				base.WindowState = FormWindowState.Minimized;
			}
			Main Downloader = this;
			string text = ServidorWebController.StartWebServer(ref Downloader, Config);
			if (!string.IsNullOrEmpty(text))
			{
				MessageBox.Show("Error starting web server: " + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			ProcessArgs(Environment.GetCommandLineArgs());
		}
	}

	private void Translate()
	{
		Text = "MegaDownloader";
		((ColumnHeader)(object)OlvColumnVelocidad).Text = Language.GetText("Speed");
		((ColumnHeader)(object)OlvColumnEDT).Text = Language.GetText("Estimated");
		((ColumnHeader)(object)OlvColumnProgreso).Text = Language.GetText("Progress");
		((ColumnHeader)(object)OlvColumnProgresoPorc).Text = Language.GetText("Progress %");
		((ColumnHeader)(object)OlvColumnEstado).Text = Language.GetText("Status");
		((ColumnHeader)(object)OlvColumnTamano).Text = Language.GetText("Size");
		((ColumnHeader)(object)OlvColumnDescargado).Text = Language.GetText("Downloaded");
		((ColumnHeader)(object)OlvColumnNombre).Text = Language.GetText("Name");
		((ColumnHeader)(object)OlvColumnRestante).Text = Language.GetText("Remaining");
		AbrirEnCarpetaToolStripMenuItem.Text = Language.GetText("Open directory");
		SubirPrioridadMenuItem.Text = Language.GetText("Increase priority");
		BajarPrioridadMenuItem.Text = Language.GetText("Decrease priority");
		PausarStripMenuItem.Text = Language.GetText("Pause");
		ForceDownloadStripMenuItem.Text = Language.GetText("Force download");
		EliminarMenuItem.Text = Language.GetText("Delete from list");
		EliminarYBorrarMenuItem.Text = Language.GetText("Delete from list and disk");
		VerErrorToolStripMenuItem.Text = Language.GetText("See error");
		VerLinksToolStripMenuItem.Text = Language.GetText("See links");
		VerLinksDescToolStripMenuItem.Text = Language.GetText("See links + desc");
		OcultarEnlacesImagenMenuItem.Text = Language.GetText("Hide links inside an image");
		ResetToolStripMenuItem.Text = Language.GetText("Reset");
		VerProgresoDescompresionToolStripMenuItem.Text = Language.GetText("See decompression progress");
		PropiedadesToolStripMenuItem.Text = Language.GetText("Properties");
		AgregarLinksToolStripMenuItem.Text = Language.GetText("Add links");
		LimpiarCompletados2ToolStripMenuItem.Text = Language.GetText("Clean completed");
		LimpiarCompletadosToolStripMenuItem.Text = Language.GetText("Clean completed");
		AbrirToolStripMenuItem1.Text = Language.GetText("Open");
		AgregarLinkStripMenuItem.Text = Language.GetText("Add link");
		CerrarToolStripMenuItem.Text = Language.GetText("Close");
		ToolTipBotones.SetToolTip(btnConfig, Language.GetText("Configuration"));
		ToolTipBotones.SetToolTip(btnPlay, Language.GetText("Start downloads"));
		ToolTipBotones.SetToolTip(btnCollaborate, Language.GetText("Collaborate"));
		ToolTipBotones.SetToolTip(btnPause, Language.GetText("Pause downloads"));
		ToolTipBotones.SetToolTip(btnStop, Language.GetText("Stop downloads"));
		ToolTipBotones.SetToolTip(btnAddLink, Language.GetText("Add links"));
		ToolTipBotones.SetToolTip(btnUpdate, Language.GetText("New version do you want to download it?"));
		StatusToolStripStatusLabel.Text = Language.GetText("Status: -");
		RAMProcToolStripStatusLabel.Text = Language.GetText("RAM Proc Empty");
	}

	private void CrearMenus()
	{
		base.Menu = new MainMenu();
		MenuItem menuItem = base.Menu.MenuItems.Add(Language.GetText("&File"));
		MenuItem menuItem2 = new MenuItem(Language.GetText("Open &DLC"));
		menuItem2.Click += OpenDLC_Click;
		MenuItem menuItem3 = new MenuItem(Language.GetText("E&xit"));
		menuItem3.Click += CerrarToolStripMenuItem_Click;
		menuItem.MenuItems.Add(menuItem2);
		menuItem.MenuItems.Add("-");
		menuItem.MenuItems.Add(menuItem3);
		MenuItem menuItem4 = new MenuItem(Language.GetText("See extraction &queue"));
		menuItem4.Click += VerDescompresor_Click;
		MenuItem menuItem5 = new MenuItem(Language.GetText("&Configuration"));
		menuItem5.Click += btnConfig_Click;
		MenuItem menuItem6 = new MenuItem(Language.GetText("See lo&gs"));
		menuItem6.Click += VerLogs_Click;
		MenuItem menuItem7 = new MenuItem(Language.GetText("Encode lin&ks"));
		menuItem7.Click += CodificarEnlaces_Click;
		MenuItem menuItem8 = new MenuItem(Language.GetText("Generat&e ELC"));
		menuItem8.Click += GenerateELC_Click;
		MenuItem menuItem9 = new MenuItem(Language.GetText("Steganograph&y"));
		MenuItem menuItem10 = base.Menu.MenuItems.Add(Language.GetText("&Options"));
		List<KeyValuePair<string, string>> list = InternalConfiguration.ObtenerValuesFromInternalConfig("SEARCH_LIST/ELEMENT");
		if (list.Count > 0)
		{
			MenuItem menuItem11 = menuItem10.MenuItems.Add(Language.GetText("Searc&h"));
			menuItem10.MenuItems.Add("-");
			foreach (KeyValuePair<string, string> item in list)
			{
				MenuItem menuItem12 = new MenuItem(item.Key);
				menuItem12.Click += Buscador_Click;
				menuItem11.MenuItems.Add(menuItem12);
			}
		}
		menuItem10.MenuItems.Add(menuItem7);
		menuItem10.MenuItems.Add(menuItem8);
		menuItem10.MenuItems.Add(menuItem9);
		menuItem10.MenuItems.Add("-");
		menuItem10.MenuItems.Add(menuItem4);
		menuItem10.MenuItems.Add(menuItem6);
		menuItem10.MenuItems.Add("-");
		menuItem10.MenuItems.Add(menuItem5);
		MenuItem menuItem13 = new MenuItem(Language.GetText("&Hide links inside an image"));
		menuItem13.Click += CreateStegano_Click;
		MenuItem menuItem14 = new MenuItem(Language.GetText("&Retrieve links from an image"));
		menuItem14.Click += UseStegano_Click;
		menuItem9.MenuItems.Add(menuItem13);
		menuItem9.MenuItems.Add(menuItem14);
		MenuItem menuItem15 = new MenuItem(Language.GetText("Watch &Online"));
		menuItem15.Click += VerStreaming_Click;
		MenuItem menuItem16 = new MenuItem(Language.GetText("Manage Streaming &Library"));
		menuItem16.Click += LibraryManager_Click;
		MenuItem menuItem17 = new MenuItem(Language.GetText("See Streaming &Library"));
		menuItem17.Click += SeeLibraryManager_Click;
		MenuItem menuItem18 = base.Menu.MenuItems.Add(Language.GetText("&Streaming"));
		menuItem18.MenuItems.Add(menuItem15);
		menuItem18.MenuItems.Add("-");
		menuItem18.MenuItems.Add(menuItem17);
		menuItem18.MenuItems.Add(menuItem16);
		MenuItem menuItem19 = new MenuItem(Language.GetText("FA&Q"));
		menuItem19.Click += FAQ_Click;
		MenuItem menuItem20 = new MenuItem(Language.GetText("Get MegaUploa&der"));
		menuItem20.Click += GetMegaUploader_Click;
		MenuItem menuItem21 = new MenuItem(Language.GetText("&About"));
		menuItem21.Click += About_Click;
		MenuItem menuItem22 = new MenuItem(Language.GetText("Chec&k for updates"));
		menuItem22.Click += CheckUpdates_Click;
		MenuItem menuItem23 = base.Menu.MenuItems.Add(Language.GetText("&Help"));
		menuItem23.MenuItems.Add(menuItem22);
		menuItem23.MenuItems.Add("-");
		menuItem23.MenuItems.Add(menuItem19);
		menuItem23.MenuItems.Add(menuItem20);
		menuItem23.MenuItems.Add("-");
		menuItem23.MenuItems.Add(menuItem21);
	}

	private void InicializarMonitores()
	{
		checked
		{
			try
			{
				Process currentProcess = Process.GetCurrentProcess();
				ProcesadorCounter = new PerformanceCounter("Process", "% Processor Time", currentProcess.ProcessName);
				RAMCounter = new PerformanceCounter("Process", "Working Set", currentProcess.ProcessName);
				NumCores = 0;
				foreach (ManagementBaseObject item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
				{
					NumCores += int.Parse(item["NumberOfCores"].ToString());
				}
				currentProcess.Dispose();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error in InicializarMonitores: " + ex2.ToString());
				ProjectData.ClearProjectError();
			}
		}
	}

	private bool IsSilent()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs != null)
		{
			string[] array = commandLineArgs;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				if (Operators.CompareString(array[i], "-silent", TextCompare: false) == 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void CheckVersionStatistics()
	{
		double result = 0.0;
		double.TryParse(InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_UPDATE"), NumberStyles.Number, new CultureInfo("en-GB"), out result);
		double result2 = 0.0;
		double.TryParse(Config.VersionConfig, NumberStyles.Number, new CultureInfo("en-GB"), out result2);
		if (result > result2)
		{
			Config.VersionConfig = result.ToString(new CultureInfo("en-GB"));
			Conexion.PingNewVersion();
		}
	}

	private bool CheckMEGAConditions()
	{
		if (!Config.CondicionesAceptadas)
		{
			if (MessageBox.Show(Language.GetText("Accept terms of use"), Language.GetText("Terms of use"), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3, (MessageBoxOptions)0, InternalConfiguration.ObtenerValueFromInternalConfig("MEGA_TERMS"), "") != DialogResult.Yes)
			{
				_ForzarCierre = true;
				Close();
				return false;
			}
			Conexion.PingNewUser();
		}
		Config.CondicionesAceptadas = true;
		return true;
	}

	private void Main_FormClosed(object sender, FormClosedEventArgs e)
	{
		Application.DoEvents();
		Cerrando = true;
		DateTime now = DateAndTime.Now;
		Log.WriteInfo("Closing, cancelling workers");
		bgwActualizadorListaDescargas.CancelAsync();
		bgwComprobarMaxConexiones.CancelAsync();
		bgwActualizadorDatosDisco.CancelAsync();
		bgwDescompresor.CancelAsync();
		Log.WriteInfo("Cancelling downloads");
		PararDescargaFicheros();
		EsperarParadaDescargasYWorkers();
		Log.WriteInfo("Saving download list");
		GuardarFicheroDescargas();
		if (base.WindowState != FormWindowState.Minimized)
		{
			Config.ConfigUI.AnchoVentanaPrincipal = base.Width;
			Config.ConfigUI.AltoVentanaPrincipal = base.Height;
		}
		Config.ConfigUI.EstadoLista = ((ObjectListView)ListaDescargas).SaveState();
		Config.GuardarXML(ForzarGuardado: false);
		ListaDescargas.ClearObjects();
		((Component)(object)ListaDescargas).Dispose();
		Log.WriteInfo("Stopping web server");
		ServidorWebController.StopWebServer();
		if (DateAndTime.Now.Subtract(now).TotalMilliseconds < 500.0)
		{
			Thread.Sleep(500);
		}
		Log.WriteError("Closing MegaDownloader, bye bye!\r\n");
		Log.Flush(forceFlush: true);
		IconoMinimizado.Dispose();
		clipChange.DestroyHandle();
		clipChange.Uninstall();
		Application.Exit();
	}

	private void Main_FormClosing(object sender, FormClosingEventArgs e)
	{
		string text = Language.GetText("Do you want to exit?");
		if (DescompresorController.GetController().Ocupado())
		{
			text = Language.GetText("Files extracting, corruption danger") + "\r\n" + text;
		}
		if (((e.CloseReason == CloseReason.UserClosing) & !_ForzarCierre) && MessageBox.Show(text, Language.GetText("Close"), MessageBoxButtons.YesNo) == DialogResult.No)
		{
			e.Cancel = true;
			return;
		}
		base.Visible = false;
		Cerrando cerrando = new Cerrando();
		cerrando.lblMensaje.Text = Language.GetText("Closing please wait");
		cerrando.Show();
	}

	private void CerrarToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void VerDescompresor_Click(object sender, EventArgs e)
	{
		if (IsFormAlreadyOpen(typeof(Descompresor)) == null)
		{
			new Descompresor().Show();
		}
	}

	private void OpenDLC_Click(object sender, EventArgs e)
	{
		if (DLCProcessing)
		{
			MessageBox.Show(Language.GetText("There is a DLC being processed, please wait"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.CheckFileExists = true;
		openFileDialog.Filter = Language.GetText("DLC") + " / " + Language.GetText("ELC") + " (*.dlc, *.elc)|*.dlc;*.elc";
		openFileDialog.Multiselect = false;
		string dLCFilePath = string.Empty;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			dLCFilePath = openFileDialog.FileName;
		}
		openFileDialog.Dispose();
		AddDLC(dLCFilePath);
	}

	private void Main_Resize(object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Minimized)
		{
			IconoMinimizado.Visible = true;
			base.Visible = false;
			IconoMinimizado.ShowBalloonTip(5000, Text, IconoMinimizado.Text, ToolTipIcon.None);
		}
		else
		{
			IconoMinimizado.Visible = false;
			base.Visible = true;
		}
	}

	private void RestaurarVentana()
	{
		if (base.WindowState == FormWindowState.Minimized)
		{
			base.Visible = true;
			IconoMinimizado.Visible = false;
			base.WindowState = FormWindowState.Normal;
		}
	}

	private void AbrirToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		RestaurarVentana();
	}

	private void IconoMinimizado_DoubleClick(object sender, EventArgs e)
	{
		RestaurarVentana();
	}

	private void IconoMinimizado_Click(object sender, EventArgs e)
	{
		if (e is MouseEventArgs && ((MouseEventArgs)e).Button == MouseButtons.Left)
		{
			RestaurarVentana();
		}
	}

	private void DefinirColumnas()
	{
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		int index = 0;
		int index2 = 1;
		int index3 = 2;
		int index4 = 3;
		int index5 = 4;
		int index6 = 5;
		int index7 = 6;
		int index8 = 7;
		int index9 = 8;
		int index10 = 9;
		((ObjectListView)ListaDescargas).PrimarySortColumn = ((ObjectListView)ListaDescargas).AllColumns[index];
		((ObjectListView)ListaDescargas).SortGroupItemsByPrimaryColumn = true;
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index]).AspectGetter = [SpecialName] (IDescarga ele) => ele.DescargaPrioridad();
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index2]).AspectGetter = [SpecialName] (IDescarga ele) => (ele is Fichero) ? Path.Combine(((Fichero)ele).RutaRelativa, ele.DescargaNombre()) : ele.DescargaNombre();
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index3]).AspectGetter = [SpecialName] (IDescarga ele) =>
		{
			decimal num = new decimal(ele.DescargaTamanoBytes());
			if (decimal.Compare(num, 0m) == 0)
			{
				return "-";
			}
			decimal numBytes = Math.Ceiling(decimal.Divide(decimal.Multiply(ele.DescargaPorcentaje(), num), 100m));
			return PintarTamano(numBytes);
		};
		((ObjectListView)ListaDescargas).AllColumns[index3].TextAlign = HorizontalAlignment.Right;
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index10]).AspectGetter = [SpecialName] (IDescarga ele) =>
		{
			decimal num = new decimal(ele.DescargaTamanoBytes());
			if (decimal.Compare(num, 0m) == 0)
			{
				return "-";
			}
			decimal d = Math.Ceiling(decimal.Divide(decimal.Multiply(ele.DescargaPorcentaje(), num), 100m));
			return PintarTamano(decimal.Subtract(num, d));
		};
		((ObjectListView)ListaDescargas).AllColumns[index10].TextAlign = HorizontalAlignment.Right;
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index4]).AspectGetter = [SpecialName] (IDescarga ele) =>
		{
			decimal num = new decimal(ele.DescargaTamanoBytes());
			return (decimal.Compare(num, 0m) == 0) ? "-" : PintarTamano(num);
		};
		((ObjectListView)ListaDescargas).AllColumns[index4].TextAlign = HorizontalAlignment.Right;
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index5]).AspectGetter = [SpecialName] (IDescarga ele) =>
		{
			try
			{
				return ele.DescargaEstado() switch
				{
					Estado.EnCola => Language.GetText("In queue"), 
					Estado.CreandoLocal => Language.GetText("Creating files"), 
					Estado.Verificando => Language.GetText("Verifying"), 
					Estado.Erroneo => Language.GetText("Error capital leters"), 
					Estado.Pausado => Language.GetText("Paused"), 
					Estado.Descomprimiendo => Language.GetText("Extracting"), 
					Estado.Descargando => Language.GetText("Downloading"), 
					Estado.ComprobandoMD5 => Language.GetText("Hashing MD5"), 
					Estado.Completado => Language.GetText("Completed"), 
					_ => "---", 
				};
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MsgBox("Error displaying download status: " + ex2.ToString(), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				throw;
			}
		};
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index7]).AspectGetter = [SpecialName] (IDescarga ele) =>
		{
			try
			{
				return ele.DescargaPorcentaje();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error displaying download %: " + ex2.ToString());
				MsgBox("Error displaying download %: " + ex2.ToString(), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				throw;
			}
		};
		BarRenderer val = new BarRenderer();
		val.UseStandardBar = false;
		val.BackgroundColor = Color.Azure;
		val.FillColor = Color.MediumTurquoise;
		val.GradientStartColor = Color.SpringGreen;
		val.GradientEndColor = Color.MediumTurquoise;
		val.MaximumWidth = 9999;
		((ObjectListView)ListaDescargas).AllColumns[index7].Renderer = (IRenderer)(object)val;
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index8]).AspectGetter = [SpecialName] (IDescarga ele) => PintarVelocidadDescarga(ele);
		((ObjectListView)ListaDescargas).AllColumns[index8].TextAlign = HorizontalAlignment.Right;
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index9]).AspectGetter = [SpecialName] (IDescarga ele) =>
		{
			try
			{
				return ele.DescargaTiempoEstimadoDescarga();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error displaying download time: " + ex2.ToString());
				MsgBox("Error displaying download time: " + ex2.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				throw;
			}
		};
		((ObjectListView)ListaDescargas).AllColumns[index9].TextAlign = HorizontalAlignment.Right;
		new TypedColumn<IDescarga>(((ObjectListView)ListaDescargas).AllColumns[index6]).AspectGetter = [SpecialName] (IDescarga ele) =>
		{
			try
			{
				return ele.DescargaPorcentaje().ToString("F2") + "%";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error displaying download % (text): " + ex2.ToString());
				MsgBox("Error displaying download % (text): " + ex2.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				throw;
			}
		};
		((ObjectListView)ListaDescargas).AllColumns[index6].TextAlign = HorizontalAlignment.Right;
		((ListView)(object)ListaDescargas).AllowColumnReorder = true;
		TreeListView listaDescargas = ListaDescargas;
		object canExpandGetter;
		if (_Closure_0024__._0024I282_002D10 != null)
		{
			canExpandGetter = _Closure_0024__._0024I282_002D10;
		}
		else
		{
			TreeListView.CanExpandGetterDelegate val2 = [SpecialName] (object ele) => ele is Paquete && ((Paquete)ele).ListaFicheros != null && ((Paquete)ele).ListaFicheros.Count > 0;
			_Closure_0024__._0024I282_002D10 = val2;
			canExpandGetter = (object)val2;
		}
		listaDescargas.CanExpandGetter = (TreeListView.CanExpandGetterDelegate)canExpandGetter;
		TreeListView listaDescargas2 = ListaDescargas;
		object childrenGetter;
		if (_Closure_0024__._0024I282_002D11 != null)
		{
			childrenGetter = _Closure_0024__._0024I282_002D11;
		}
		else
		{
			TreeListView.ChildrenGetterDelegate val3 = [SpecialName] (object ele) => (!(ele is Paquete)) ? null : ((Paquete)ele).ListaFicheros;
			_Closure_0024__._0024I282_002D11 = val3;
			childrenGetter = (object)val3;
		}
		listaDescargas2.ChildrenGetter = (TreeListView.ChildrenGetterDelegate)childrenGetter;
		((ObjectListView)ListaDescargas).SelectColumnsOnRightClickBehaviour = (ObjectListView.ColumnSelectBehaviour)1;
		((ListView)(object)ListaDescargas).FullRowSelect = true;
		((ObjectListView)ListaDescargas).DragSource = (IDragSource)new SimpleDragSource();
		dropSink = new SimpleDropSink();
		((ObjectListView)ListaDescargas).DropSink = (IDropSink)(object)dropSink;
		dropSink.CanDropBetween = true;
		dropSink.CanDropOnBackground = false;
		dropSink.CanDropOnItem = false;
		dropSink.CanDropOnSubItem = false;
		InitializeColumnWidths();
	}

	private void ListaDescargas_FormatRow(object sender, FormatRowEventArgs e)
	{
		if (e.DisplayIndex % 2 == 0)
		{
			((ListViewItem)(object)e.Item).BackColor = Color.White;
		}
		else
		{
			((ListViewItem)(object)e.Item).BackColor = Color.Honeydew;
		}
		IDescarga descarga = (IDescarga)e.Model;
		if (descarga.DescargaEstado() == Estado.Erroneo)
		{
			((ListViewItem)(object)e.Item).ForeColor = Color.Red;
		}
		else if (descarga.DescargaEstado() == Estado.Completado)
		{
			((ListViewItem)(object)e.Item).ForeColor = Color.Green;
		}
	}

	private string PintarVelocidadDescarga(IDescarga ele)
	{
		if (ele.DescargaEstado() == Estado.Descargando)
		{
			return PintarVelocidadDescarga(ele.DescargaVelocidadKBs());
		}
		return "";
	}

	private string PintarVelocidadDescarga(decimal vel)
	{
		string text = "KB/s";
		if (decimal.Compare(vel, 1024m) > 0)
		{
			text = "MB/s";
			vel = decimal.Divide(vel, 1024m);
		}
		return vel.ToString("F2") + " " + text;
	}

	private string PintarTamano(decimal numBytes)
	{
		string text = "B";
		if (decimal.Compare(numBytes, 1024m) > 0)
		{
			text = "KB";
			numBytes = decimal.Divide(numBytes, 1024m);
		}
		if (decimal.Compare(numBytes, 1024m) > 0)
		{
			text = "MB";
			numBytes = decimal.Divide(numBytes, 1024m);
		}
		if (decimal.Compare(numBytes, 1024m) > 0)
		{
			text = "GB";
			numBytes = decimal.Divide(numBytes, 1024m);
		}
		if (decimal.Compare(numBytes, 1024m) > 0)
		{
			text = "TB";
			numBytes = decimal.Divide(numBytes, 1024m);
		}
		return numBytes.ToString("F2") + " " + text;
	}

	protected virtual void InitializeColumnWidths()
	{
	}

	internal void AgregarPaquete(Paquete Paquete, bool AgregadoDesdeServidorWeb)
	{
		Mutex.ListaDescargas.WaitOne();
		ListaPaquetes.Add(Paquete);
		if (string.IsNullOrEmpty(Paquete.Nombre))
		{
			Paquete.Nombre = Language.GetText("Package") + " #" + ListaPaquetes.Count;
		}
		Mutex.ListaDescargas.ReleaseMutex();
		Log.WriteError("Package added: " + Paquete.Nombre);
		ReordenarPrioridadPaquetes(RefrescarFicheros: true);
		GuardarFicheroDescargas();
		if (!AgregadoDesdeServidorWeb)
		{
			RestaurarVentana();
		}
	}

	private void GuardarFicheroDescargas()
	{
		Mutex.ListaDescargas.WaitOne();
		try
		{
			Paquete.GuardarEnFichero(ListaPaquetes);
		}
		finally
		{
			Mutex.ListaDescargas.ReleaseMutex();
		}
		UltimoGuardadoFichero = DateAndTime.Now;
	}

	private void bgwComprobarMaxConexiones_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
		try
		{
			Log.WriteWarning("Starting worker bgwComprobarMaxConexiones");
			while (!backgroundWorker.CancellationPending)
			{
				if (DateTime.Compare(DateAndTime.Now, ProximaComprobacionMaxConexiones) >= 0)
				{
					int result = 3600;
					if (!int.TryParse(InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_PERIODO_REFRESCO_SEG"), out result))
					{
						result = 3600;
					}
					ProximaComprobacionMaxConexiones = DateAndTime.Now.AddSeconds(result);
					if (Config.CheckUpdates)
					{
						Mutex.NumeroConexionesMaxima.WaitOne();
						Updater.ComprobarVersionMegadownloader(ref UrlNuevaVersionMegadownloader, ref VersionNuevaVersionMegadownloader);
						Mutex.NumeroConexionesMaxima.ReleaseMutex();
						if (!string.IsNullOrEmpty(UrlNuevaVersionMegadownloader))
						{
							ActivarUpdateButton();
							ProximoAvisoActualizacion = DateAndTime.Now.AddSeconds(15.0);
						}
						Log.WriteWarning("Version checked; next check in " + Conversions.ToString(result) + " seconds");
					}
				}
				if (ProximoAvisoActualizacion.HasValue && DateTime.Compare(ProximoAvisoActualizacion.Value, DateAndTime.Now) < 0)
				{
					MostrarMensajeActualizacion();
				}
				if (DateTime.Compare(ProximoFlushMemoria, DateAndTime.Now) < 0)
				{
					int result2 = 60;
					if (!int.TryParse(InternalConfiguration.ObtenerValueFromInternalConfig("FLUSH_MEMORY_PERIODO_REFRESCO_SEG"), out result2))
					{
						result2 = 60;
					}
					ProximoFlushMemoria = DateAndTime.Now.AddSeconds(result2);
					FlushMemory();
					Log.WriteDebug("Flush memory, next flush in " + Conversions.ToString(result2) + " seconds");
				}
				Log.Flush(forceFlush: false);
				Thread.Sleep(1000);
			}
			Log.WriteWarning("Stopping worker bgwComprobarMaxConexiones");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error in worker bgwComprobarMaxConexiones: " + ex2.ToString());
			MsgBox(ex2.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			bgwComprobarMaxConexionesCompleted = true;
		}
	}

	private void bgwActualizadorDatosDisco_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
		try
		{
			Log.WriteWarning("Starting worker bgwActualizadorDatosDisco");
			while (!backgroundWorker.CancellationPending)
			{
				Fichero fichero = null;
				Paquete paquete = null;
				int millisecondsTimeout = 250;
				if (!NecesitaCambiarUsuarioYPassword)
				{
					Mutex.ListaDescargas.WaitOne();
					try
					{
						foreach (Paquete listaPaquete in ListaPaquetes)
						{
							foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
							{
								if (!listaFichero.DescargaProcesada & (listaFichero.DescargaEstado() != Estado.Erroneo))
								{
									fichero = listaFichero;
									paquete = listaPaquete;
									goto end_IL_00a2;
								}
							}
							continue;
							end_IL_00a2:
							break;
						}
					}
					finally
					{
						Mutex.ListaDescargas.ReleaseMutex();
					}
					if (fichero != null)
					{
						Log.WriteInfo("Updating file info " + fichero.FileID);
						millisecondsTimeout = 50;
						Conexion.TipoError ErrorObtenido = Conexion.TipoError.SinErrores;
						fichero.ActualizarInformacionFichero(Config, ref ErrorObtenido, ComprobacionAntesDescarga: false);
						switch (ErrorObtenido)
						{
						case Conexion.TipoError.UsuarioInvalido:
							NecesitaCambiarUsuarioYPassword = true;
							Log.WriteWarning("Error retrieving file info " + fichero.FileID + ": " + ErrorObtenido);
							break;
						case Conexion.TipoError.SinErrores:
							PeticionGuardadoFichero = DateAndTime.Now;
							if (!(fichero.DescargaProcesada & paquete.PendienteNombrePaquete))
							{
								break;
							}
							paquete.PendienteNombrePaquete = false;
							paquete.Nombre = fichero.ObtenerNombreSinExtension();
							if (!paquete.CrearSubdirectorio)
							{
								break;
							}
							try
							{
								paquete.RutaLocal = Path.Combine(paquete.RutaLocal, paquete.Nombre);
								Directory.CreateDirectory(paquete.RutaLocal);
								foreach (Fichero listaFichero2 in paquete.ListaFicheros)
								{
									if (!listaFichero2.DescargaComenzada)
									{
										listaFichero2.RutaLocal = paquete.RutaLocal;
									}
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								Log.WriteError("Error while creating directory for package " + paquete.Nombre + ": " + ex2.ToString());
								MessageBox.Show("Error creating directory: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								ProjectData.ClearProjectError();
							}
							break;
						default:
							Log.WriteWarning("Error retrieving file info " + fichero.FileID + ": " + ErrorObtenido);
							break;
						}
					}
					if ((DateTime.Compare(UltimoGuardadoFichero.AddSeconds(5.0), DateAndTime.Now) < 0) | ((DateTime.Compare(UltimoGuardadoFichero, PeticionGuardadoFichero) < 0) & (DateTime.Compare(PeticionGuardadoFichero.AddMilliseconds(400.0), DateAndTime.Now) < 0)))
					{
						GuardarFicheroDescargas();
					}
					if ((DateTime.Compare(UltimoGuardadoConfig.AddSeconds(5.0), DateAndTime.Now) < 0) | ((DateTime.Compare(UltimoGuardadoConfig, PeticionGuardadoConfig) < 0) & (DateTime.Compare(PeticionGuardadoConfig.AddMilliseconds(400.0), DateAndTime.Now) < 0)))
					{
						Config.GuardarXML(ForzarGuardado: false);
						UltimoGuardadoConfig = DateAndTime.Now;
					}
				}
				Thread.Sleep(millisecondsTimeout);
			}
			Log.WriteWarning("Stopping worker bgwActualizadorDatosDisco");
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteError("Error in worker bgwActualizadorDatosDisco: " + ex4.ToString());
			MsgBox(ex4.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			bgwActualizadorDatosDiscoCompleted = true;
		}
	}

	private void bgwActualizadorListaDescargas_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
		Stopwatch stopwatch = new Stopwatch();
		string text = "";
		checked
		{
			try
			{
				Log.WriteWarning("Starting worker bgwActualizadorListaDescargas");
				while (!backgroundWorker.CancellationPending)
				{
					stopwatch.Start();
					text = "Checking status\r\n";
					if (EstadoAplicacion == TipoEstadoAplicacion.Descargando)
					{
						PonerFicherosADescargar();
					}
					else if (EstadoAplicacion == TipoEstadoAplicacion.Pausa)
					{
						PonerFicherosEnPausa();
					}
					else if (EstadoAplicacion == TipoEstadoAplicacion.Parado)
					{
						PararDescargaFicheros();
					}
					text += "Calculating speed, state, etc\r\n";
					decimal num = default(decimal);
					if (backgroundWorker.CancellationPending)
					{
						break;
					}
					Mutex.ListaDescargas.WaitOne();
					try
					{
						NumDescargasActivas = 0;
						NumDescargasEnCola = 0;
						NumDescargasErroneas = 0;
						NumDescargasCompletadas = 0;
						foreach (Paquete listaPaquete in ListaPaquetes)
						{
							foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
							{
								listaFichero.ActualizarDatosDescarga();
								if ((listaFichero.EstadoDescarga == Estado.Descargando) | (listaFichero.EstadoDescarga == Estado.CreandoLocal) | (listaFichero.EstadoDescarga == Estado.Verificando))
								{
									NumDescargasActivas++;
								}
								else if ((listaFichero.EstadoDescarga == Estado.EnCola) | (listaFichero.EstadoDescarga == Estado.Pausado))
								{
									NumDescargasEnCola++;
								}
								else if (listaFichero.EstadoDescarga == Estado.Erroneo)
								{
									NumDescargasErroneas++;
								}
								else if ((listaFichero.EstadoDescarga == Estado.Completado) | (listaFichero.EstadoDescarga == Estado.ComprobandoMD5) | (listaFichero.EstadoDescarga == Estado.Descomprimiendo))
								{
									NumDescargasCompletadas++;
								}
							}
							listaPaquete.ActualizarDatosDescarga();
							num = decimal.Add(num, listaPaquete.DescargaVelocidadKBs());
						}
					}
					finally
					{
						Mutex.ListaDescargas.ReleaseMutex();
					}
					if (backgroundWorker.CancellationPending)
					{
						break;
					}
					text += "Updating download list\r\n";
					RefreshListaDescargas(SetObjects: false);
					VelocidadGlobalDescarga = num;
					string[] array = new string[5];
					int? numDescargasActivas;
					int? num2 = (numDescargasActivas = NumDescargasActivas);
					array[0] = (num2.HasValue ? Conversions.ToString(numDescargasActivas.GetValueOrDefault()) : null);
					array[1] = " ";
					array[2] = Language.GetText("active downloads");
					array[3] = " - ";
					array[4] = PintarVelocidadDescarga(num);
					TextoIconoMinimizado(string.Concat(array));
					if (backgroundWorker.CancellationPending)
					{
						break;
					}
					text += "Checking if we have finished and we have to turn off the PC\r\n";
					RevisarSiHayQueApagarPC();
					text += "Calculating data (speed, processor and RAM usage, etc)\r\n";
					string estado = Language.GetText("Stopped");
					string velocidad = "";
					switch (EstadoAplicacion)
					{
					case TipoEstadoAplicacion.Descargando:
						estado = Language.GetText("Downloading");
						if (VelocidadGlobalDescarga.HasValue && decimal.Compare(VelocidadGlobalDescarga.Value, 0m) > 0)
						{
							velocidad = " " + PintarVelocidadDescarga(VelocidadGlobalDescarga.Value);
						}
						break;
					case TipoEstadoAplicacion.Pausa:
						estado = Language.GetText("Paused");
						break;
					}
					string text2 = "-";
					string text3 = "-";
					if ((RAMCounter != null) & (ProcesadorCounter != null))
					{
						double num3 = RAMCounter.NextValue() / 1024f / 1024f;
						double num4 = ProcesadorCounter.NextValue() / (float)((NumCores == 0) ? 1 : NumCores);
						text2 = num3.ToString("F2");
						text3 = num4.ToString("F2");
					}
					text += "Displaying data in status bar\r\n";
					SetStatusBar(text2 + "MB", text3 + "%", estado, velocidad, Conversions.ToString(Config.ConexionesPorFichero) + "/" + Conversions.ToString(Config.DescargasSimultaneas));
					if (backgroundWorker.CancellationPending)
					{
						break;
					}
					text += "Getting mega:// parameters\r\n";
					ApplicationInstanceManager.GetParameters();
					text += "Sleeping\r\n";
					Thread.Sleep(430);
					text += "Finishing cycle\r\n";
					stopwatch.Stop();
					stopwatch.Reset();
				}
				Log.WriteWarning("Stopping worker bgwActualizadorListaDescargas");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteError("Error in worker bgwActualizadorListaDescargas: " + ex2.ToString());
				MsgBox(ex2.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (stopwatch.ElapsedMilliseconds > 5000)
				{
					Log.WriteError("bgwActualizadorListaDescargas was too slow (" + Conversions.ToString(stopwatch.ElapsedMilliseconds) + " ms): \r\n" + text);
				}
				bgwActualizadorListaDescargasCompleted = true;
			}
		}
	}

	private void bgwActualizadorListaDescargas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		bgwActualizadorListaDescargasCompleted = true;
	}

	private void bgwActualizadorDatosDisco_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		bgwActualizadorDatosDiscoCompleted = true;
	}

	private void bgwComprobarMaxConexiones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		bgwComprobarMaxConexionesCompleted = true;
	}

	private void bgwDescompresor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		bgwDescompresorCompleted = true;
	}

	private void PonerFicherosADescargar()
	{
		List<Fichero> list = new List<Fichero>();
		List<Fichero> list2 = new List<Fichero>();
		List<Fichero> list3 = new List<Fichero>();
		int num = 0;
		int num2 = 0;
		int conexionesPorFichero = Config.ConexionesPorFichero;
		bool resetearErrores = Config.ResetearErrores;
		int resetearErroresPeriodoMinutos = Config.ResetearErroresPeriodoMinutos;
		if (resetearErrores)
		{
			Mutex.ListaDescargas.WaitOne();
			foreach (Paquete listaPaquete in ListaPaquetes)
			{
				foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
				{
					if (listaFichero.DescargaEstado() == Estado.Erroneo && (!listaFichero.FechaUltimoError.HasValue || DateTime.Compare(listaFichero.FechaUltimoError.Value.AddMinutes(resetearErroresPeriodoMinutos), DateAndTime.Now) < 0))
					{
						list3.Add(listaFichero);
					}
				}
			}
			Mutex.ListaDescargas.ReleaseMutex();
			foreach (Fichero item in list3)
			{
				item.SetDescargaEstado = Estado.EnCola;
				Log.WriteInfo("Reseting file " + item.FileID + " automatically.");
			}
		}
		Mutex.ListaDescargas.WaitOne();
		checked
		{
			foreach (Paquete listaPaquete2 in ListaPaquetes)
			{
				foreach (Fichero listaFichero2 in listaPaquete2.ListaFicheros)
				{
					if ((listaFichero2.DescargaEstado() == Estado.EnCola) & listaFichero2.DescargaProcesada)
					{
						list.Add(listaFichero2);
					}
					else if ((listaFichero2.DescargaEstado() == Estado.Pausado) & !listaFichero2.PausaIndividual)
					{
						list2.Add(listaFichero2);
					}
					else if ((listaFichero2.DescargaEstado() == Estado.Descargando) | ((listaFichero2.DescargaEstado() == Estado.Pausado) & listaFichero2.PausaIndividual))
					{
						num++;
						int num3 = listaFichero2.NumeroConexionesAbiertas;
						if (num3 == 0)
						{
							num3 = conexionesPorFichero;
						}
						num2 += num3;
					}
					else if ((listaFichero2.DescargaEstado() == Estado.CreandoLocal) | (listaFichero2.DescargaEstado() == Estado.Verificando))
					{
						num++;
						num2 += conexionesPorFichero;
					}
				}
			}
			Mutex.ListaDescargas.ReleaseMutex();
			Mutex.NumeroConexionesMaxima.WaitOne();
			int num4 = NumeroConexionesMaxima - num2;
			Mutex.NumeroConexionesMaxima.ReleaseMutex();
			int num5 = Config.DescargasSimultaneas - num;
			foreach (Fichero item2 in list2)
			{
				if (unchecked(num4 > 0 && num5 > 0))
				{
					Log.WriteInfo("Continuing paused file download " + item2.NombreFichero);
					item2.Resume();
					num4 -= item2.NumeroConexionesAbiertas;
					num5--;
				}
			}
			foreach (Fichero item3 in list)
			{
				if (unchecked(num4 > 0 && num5 > 0))
				{
					int num6 = conexionesPorFichero;
					if (num4 < conexionesPorFichero)
					{
						num6 = num4;
					}
					Log.WriteInfo("Starting file download " + item3.NombreFichero);
					item3.Start(ref Config, num6);
					num4 -= num6;
					num5--;
				}
			}
		}
	}

	private void ForzarDescarga(Fichero Fichero)
	{
		Log.WriteInfo("Forcing download" + Fichero.NombreFichero);
		Mutex.ListaDescargas.WaitOne();
		try
		{
			if (Fichero.DescargaEstado() == Estado.Pausado)
			{
				Fichero.Resume();
			}
			else if ((Fichero.DescargaEstado() == Estado.EnCola) & Fichero.DescargaProcesada)
			{
				Fichero.DescargaIndividual = true;
				Fichero.Start(ref Config, Config.ConexionesPorFichero);
			}
		}
		finally
		{
			Mutex.ListaDescargas.ReleaseMutex();
		}
	}

	private void QuitarDescargasIndividuales()
	{
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				listaFichero.DescargaIndividual = false;
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
	}

	private void PonerFicherosEnPausa()
	{
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				if (((listaFichero.DescargaEstado() == Estado.Descargando) & !listaFichero.DescargaIndividual) | (listaFichero.DescargaEstado() == Estado.CreandoLocal))
				{
					Log.WriteInfo("Pausing file " + listaFichero.NombreFichero);
					listaFichero.Pause();
				}
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
	}

	private void QuitarPausasIndividuales()
	{
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				listaFichero.PausaIndividual = false;
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
	}

	private void PonerFicheroEnPausa(Fichero Fichero)
	{
		Mutex.ListaDescargas.WaitOne();
		if ((Fichero.DescargaEstado() == Estado.Descargando) | (Fichero.DescargaEstado() == Estado.CreandoLocal))
		{
			Log.WriteInfo("Pausing file " + Fichero.NombreFichero);
			Fichero.PausaIndividual = true;
			Fichero.Pause();
			ThrottledStreamController.GetController().Abortar(Fichero.FileID);
		}
		Mutex.ListaDescargas.ReleaseMutex();
	}

	private void PararDescargaFicheros()
	{
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				if (((listaFichero.DescargaEstado() == Estado.Descargando) & !listaFichero.DescargaIndividual) | (listaFichero.DescargaEstado() == Estado.Pausado) | (listaFichero.DescargaEstado() == Estado.CreandoLocal))
				{
					Log.WriteInfo("Stopping file " + listaFichero.NombreFichero);
					listaFichero.Stop();
				}
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
	}

	private void EsperarParadaDescargasYWorkers()
	{
		bool flag = false;
		int result = 15;
		int.TryParse(InternalConfiguration.ObtenerValueFromInternalConfig("TIMEOUT_CLOSE"), out result);
		DateTime now = DateAndTime.Now;
		while (!flag)
		{
			flag = true;
			Mutex.ListaDescargas.WaitOne();
			try
			{
				foreach (Paquete listaPaquete in ListaPaquetes)
				{
					foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
					{
						if ((listaFichero.DescargaEstado() == Estado.Descargando) | (listaFichero.DescargaEstado() == Estado.Pausado))
						{
							flag = false;
						}
					}
				}
			}
			finally
			{
				Mutex.ListaDescargas.ReleaseMutex();
			}
			if (!bgwActualizadorDatosDiscoCompleted)
			{
				flag = false;
			}
			if (!bgwComprobarMaxConexionesCompleted)
			{
				flag = false;
			}
			if (!bgwActualizadorListaDescargasCompleted)
			{
				flag = false;
			}
			Thread.Sleep(100);
			if (DateTime.Compare(now.AddSeconds(result), DateAndTime.Now) < 0)
			{
				flag = true;
			}
		}
		if (DateTime.Compare(now.AddSeconds(result), DateAndTime.Now) < 0)
		{
			Log.WriteInfo("We have waited " + Conversions.ToString(result) + " seconds... we can't wait more!");
		}
	}

	private void RevisarSiHayQueApagarPC()
	{
		if (!Config.ApagarPC | (_Timer != null))
		{
			return;
		}
		bool flag = true;
		bool flag2 = false;
		bool flag3 = false;
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				flag3 = true;
				if ((listaFichero.DescargaEstado() != Estado.Completado) & (listaFichero.DescargaEstado() != Estado.Erroneo))
				{
					flag = false;
				}
				if (listaFichero.DescargaEstado() == Estado.Erroneo)
				{
					flag2 = true;
				}
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
		if (!(flag3 && flag) || !(!Config.ResetearErrores || !flag2))
		{
			return;
		}
		bool flag4 = false;
		foreach (Form openForm in MyProject.Application.OpenForms)
		{
			if (openForm is Configuration)
			{
				flag4 = true;
			}
		}
		if (!flag4)
		{
			_Timer = new System.Timers.Timer();
			_Timer.Elapsed += ApagarPC_Event;
			_Timer.Interval = 500.0;
			_Timer.Enabled = true;
		}
	}

	private void ApagarPC_Event(object source, ElapsedEventArgs e)
	{
		if (_Timer != null)
		{
			_Timer.Enabled = false;
			_Timer = null;
			_ForzarCierre = true;
			Log.WriteWarning("Turning off PC automatically");
			Process.Start("shutdown", "/s /t 60 /c \"" + Language.GetText("Turning off in 60 seconds") + "\"");
			CerrarAplicacion();
		}
	}

	private void ReordenarPrioridadPaquetes(bool RefrescarFicheros)
	{
		int num = 0;
		Mutex.ListaDescargas.WaitOne();
		checked
		{
			foreach (Paquete listaPaquete in ListaPaquetes)
			{
				num = (listaPaquete.SetDescargaPrioridad = num + 1);
				if (listaPaquete.ListaFicheros == null)
				{
					continue;
				}
				foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
				{
					num = (listaFichero.SetDescargaPrioridad = num + 1);
				}
			}
			Mutex.ListaDescargas.ReleaseMutex();
			if (RefrescarFicheros)
			{
				RefreshListaDescargas(RefrescarFicheros);
			}
		}
	}

	private void ListaDescargas_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Data.GetData("BrightIdeasSoftware.OLVListItem") == null)
		{
			Main_DragDrop(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ListaDescargas_CanDrop(object sender, OlvDropEventArgs e)
	{
		e.Effect = DragDropEffects.Move;
		if (e.DragEventArgs.Data.GetData(DataFormats.FileDrop) == null)
		{
			return;
		}
		string[] obj = (string[])e.DragEventArgs.Data.GetData(DataFormats.FileDrop);
		bool flag = true;
		string[] array = obj;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			if (!File.Exists(array[i]))
			{
				flag = false;
			}
		}
		if (flag)
		{
			e.Effect = DragDropEffects.Copy;
		}
	}

	private void dropSink_ModelDropped(object sender, ModelDropEventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		foreach (IDescarga sourceModel in e.SourceModels)
		{
			RealizarMovimiento(sourceModel, RuntimeHelpers.GetObjectValue(e.TargetModel), ((OlvDropEventArgs)e).DropTargetLocation);
		}
		ReordenarPrioridadPaquetes(RefrescarFicheros: true);
	}

	private bool RealizarMovimiento(object Source, object Target, DropTargetLocation TargetLocation)
	{
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Invalid comparison between Unknown and I4
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Invalid comparison between Unknown and I4
		if (Source is Fichero && Target is Fichero)
		{
			_Closure_0024__312_002D0 arg = default(_Closure_0024__312_002D0);
			_Closure_0024__312_002D0 CS_0024_003C_003E8__locals10 = new _Closure_0024__312_002D0(arg);
			CS_0024_003C_003E8__locals10._0024VB_0024Local_sourcet = (Fichero)Source;
			CS_0024_003C_003E8__locals10._0024VB_0024Local_targett = (Fichero)Target;
			Mutex.ListaDescargas.WaitOne();
			try
			{
				foreach (Paquete listaPaquete in ListaPaquetes)
				{
					int num = listaPaquete.ListaFicheros.FindIndex([SpecialName] (Fichero x) => x.DescargaPrioridad() == CS_0024_003C_003E8__locals10._0024VB_0024Local_sourcet.DescargaPrioridad());
					int num2 = listaPaquete.ListaFicheros.FindIndex([SpecialName] (Fichero x) => x.DescargaPrioridad() == CS_0024_003C_003E8__locals10._0024VB_0024Local_targett.DescargaPrioridad());
					if (num >= 0 && num2 >= 0 && num2 != num)
					{
						listaPaquete.ListaFicheros.RemoveRange(num, 1);
						num2 = listaPaquete.ListaFicheros.FindIndex([SpecialName] (Fichero x) => x.DescargaPrioridad() == CS_0024_003C_003E8__locals10._0024VB_0024Local_targett.DescargaPrioridad());
						listaPaquete.ListaFicheros.Insert(((int)TargetLocation == 16) ? checked(num2 + 1) : num2, CS_0024_003C_003E8__locals10._0024VB_0024Local_sourcet);
						return true;
					}
				}
			}
			finally
			{
				Mutex.ListaDescargas.ReleaseMutex();
			}
		}
		else if (Source is Paquete && Target is Paquete)
		{
			_Closure_0024__312_002D1 arg2 = default(_Closure_0024__312_002D1);
			_Closure_0024__312_002D1 CS_0024_003C_003E8__locals13 = new _Closure_0024__312_002D1(arg2);
			CS_0024_003C_003E8__locals13._0024VB_0024Local_sourcet = (Paquete)Source;
			CS_0024_003C_003E8__locals13._0024VB_0024Local_targett = (Paquete)Target;
			Mutex.ListaDescargas.WaitOne();
			try
			{
				int num3 = ListaPaquetes.FindIndex([SpecialName] (Paquete x) => x.DescargaPrioridad() == CS_0024_003C_003E8__locals13._0024VB_0024Local_sourcet.DescargaPrioridad());
				int num4 = ListaPaquetes.FindIndex([SpecialName] (Paquete x) => x.DescargaPrioridad() == CS_0024_003C_003E8__locals13._0024VB_0024Local_targett.DescargaPrioridad());
				if (num3 >= 0 && num4 >= 0 && num4 != num3)
				{
					ListaPaquetes.RemoveRange(num3, 1);
					num4 = ListaPaquetes.FindIndex([SpecialName] (Paquete x) => x.DescargaPrioridad() == CS_0024_003C_003E8__locals13._0024VB_0024Local_targett.DescargaPrioridad());
					ListaPaquetes.Insert(((int)TargetLocation == 16) ? checked(num4 + 1) : num4, CS_0024_003C_003E8__locals13._0024VB_0024Local_sourcet);
					return true;
				}
			}
			finally
			{
				Mutex.ListaDescargas.ReleaseMutex();
			}
		}
		return false;
	}

	private void SubirPrioridad_Click(object sender, EventArgs e)
	{
		if (((ObjectListView)ListaDescargas).SelectedObjects == null)
		{
			return;
		}
		object obj = null;
		checked
		{
			foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
				if (objectValue is Paquete)
				{
					int num = ((Paquete)objectValue).DescargaPrioridad();
					int num2 = 0;
					bool flag = false;
					Mutex.ListaDescargas.WaitOne();
					foreach (Paquete listaPaquete in ListaPaquetes)
					{
						if (unchecked(listaPaquete.DescargaPrioridad() == num && num2 > 0))
						{
							flag = true;
							break;
						}
						num2++;
					}
					if (flag)
					{
						Paquete value = ListaPaquetes[num2 - 1];
						ListaPaquetes[num2 - 1] = (Paquete)objectValue;
						ListaPaquetes[num2] = value;
						ReordenarPrioridadPaquetes(RefrescarFicheros: true);
						obj = ListaPaquetes[num2 - 1];
					}
					Mutex.ListaDescargas.ReleaseMutex();
				}
				else
				{
					if (!(objectValue is Fichero))
					{
						continue;
					}
					int num3 = ((Fichero)objectValue).DescargaPrioridad();
					Mutex.ListaDescargas.WaitOne();
					foreach (Paquete listaPaquete2 in ListaPaquetes)
					{
						int num4 = 0;
						bool flag2 = false;
						foreach (Fichero listaFichero in listaPaquete2.ListaFicheros)
						{
							if (unchecked(listaFichero.DescargaPrioridad() == num3 && num4 > 0))
							{
								flag2 = true;
								break;
							}
							num4++;
						}
						if (flag2)
						{
							Fichero value2 = listaPaquete2.ListaFicheros[num4 - 1];
							listaPaquete2.ListaFicheros[num4 - 1] = (Fichero)objectValue;
							listaPaquete2.ListaFicheros[num4] = value2;
							ReordenarPrioridadPaquetes(RefrescarFicheros: true);
							obj = listaPaquete2.ListaFicheros[num4 - 1];
							break;
						}
					}
					Mutex.ListaDescargas.ReleaseMutex();
				}
			}
			if (obj != null)
			{
				((ObjectListView)ListaDescargas).SelectedObject = RuntimeHelpers.GetObjectValue(obj);
			}
		}
	}

	private void BajarPrioridadMenuItem_Click(object sender, EventArgs e)
	{
		if (((ObjectListView)ListaDescargas).SelectedObjects == null)
		{
			return;
		}
		checked
		{
			foreach (object selectedObject2 in ((ObjectListView)ListaDescargas).SelectedObjects)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(selectedObject2);
				if (objectValue is Paquete)
				{
					int num = ((Paquete)objectValue).DescargaPrioridad();
					Mutex.ListaDescargas.WaitOne();
					int num2 = ListaPaquetes.Count - 1;
					int num3 = 0;
					bool flag = false;
					foreach (Paquete listaPaquete in ListaPaquetes)
					{
						if (unchecked(listaPaquete.DescargaPrioridad() == num && num3 < num2))
						{
							flag = true;
							break;
						}
						num3++;
					}
					if (flag)
					{
						Paquete value = ListaPaquetes[num3 + 1];
						ListaPaquetes[num3 + 1] = (Paquete)objectValue;
						ListaPaquetes[num3] = value;
						Paquete selectedObject = ListaPaquetes[num3 + 1];
						Mutex.ListaDescargas.ReleaseMutex();
						ReordenarPrioridadPaquetes(RefrescarFicheros: true);
						((ObjectListView)ListaDescargas).SelectedObject = selectedObject;
					}
					else
					{
						Mutex.ListaDescargas.ReleaseMutex();
					}
				}
				else
				{
					if (!(objectValue is Fichero))
					{
						continue;
					}
					int num4 = ((Fichero)objectValue).DescargaPrioridad();
					Fichero fichero = null;
					Mutex.ListaDescargas.WaitOne();
					foreach (Paquete listaPaquete2 in ListaPaquetes)
					{
						int num5 = listaPaquete2.ListaFicheros.Count - 1;
						int num6 = 0;
						bool flag2 = false;
						foreach (Fichero listaFichero in listaPaquete2.ListaFicheros)
						{
							if (unchecked(listaFichero.DescargaPrioridad() == num4 && num6 < num5))
							{
								flag2 = true;
								break;
							}
							num6++;
						}
						if (flag2)
						{
							Fichero value2 = listaPaquete2.ListaFicheros[num6 + 1];
							listaPaquete2.ListaFicheros[num6 + 1] = (Fichero)objectValue;
							listaPaquete2.ListaFicheros[num6] = value2;
							fichero = listaPaquete2.ListaFicheros[num6 + 1];
							break;
						}
					}
					Mutex.ListaDescargas.ReleaseMutex();
					if (fichero != null)
					{
						ReordenarPrioridadPaquetes(RefrescarFicheros: true);
						((ObjectListView)ListaDescargas).SelectedObject = fichero;
					}
				}
			}
		}
	}

	private void EliminarMenuItem_Click(object sender, EventArgs e)
	{
		if (((ObjectListView)ListaDescargas).SelectedObjects == null || MessageBox.Show(Language.GetText("Do you want to delete the element(s)?") + "\r\n" + Language.GetText("Note: files will NOT be deleted"), Language.GetText("Confirmation"), MessageBoxButtons.YesNo) == DialogResult.No)
		{
			return;
		}
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is IDescarga)
			{
				Log.WriteError("Deleting from list " + ((IDescarga)objectValue).DescargaNombre());
				Eliminar((IDescarga)objectValue, BorrarFicheros: false, RefrescarFicheros: false);
			}
		}
		RefreshListaDescargas(SetObjects: true);
	}

	private void EliminarYBorrarMenuItem_Click(object sender, EventArgs e)
	{
		if (((ObjectListView)ListaDescargas).SelectedObjects == null || MessageBox.Show(Language.GetText("Do you want to delete the element(s)?") + "\r\n" + Language.GetText("Note: files will BE deleted"), Language.GetText("Confirmation"), MessageBoxButtons.YesNo) == DialogResult.No)
		{
			return;
		}
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is IDescarga)
			{
				Log.WriteError("Deleting from list and disk " + ((IDescarga)objectValue).DescargaNombre());
				Eliminar((IDescarga)objectValue, BorrarFicheros: true, RefrescarFicheros: false);
			}
		}
		RefreshListaDescargas(SetObjects: true);
	}

	private void Eliminar(IDescarga Objeto, bool BorrarFicheros, bool RefrescarFicheros)
	{
		Paquete paquete = null;
		Fichero fichero = null;
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			if (listaPaquete.DescargaPrioridad() == Objeto.DescargaPrioridad())
			{
				paquete = listaPaquete;
				break;
			}
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				if (Objeto.DescargaPrioridad() == listaFichero.DescargaPrioridad())
				{
					fichero = listaFichero;
					paquete = listaPaquete;
					goto end_IL_007f;
				}
			}
			continue;
			end_IL_007f:
			break;
		}
		if (fichero != null)
		{
			paquete.ListaFicheros.Remove(fichero);
			ThrottledStreamController.GetController().RemoveId(fichero.FileID);
			if (paquete.ListaFicheros.Count == 0)
			{
				ListaPaquetes.Remove(paquete);
			}
		}
		else if (paquete != null)
		{
			ListaPaquetes.Remove(paquete);
			foreach (Fichero listaFichero2 in paquete.ListaFicheros)
			{
				ThrottledStreamController.GetController().RemoveId(listaFichero2.FileID);
			}
		}
		PeticionGuardadoFichero = DateAndTime.Now;
		Mutex.ListaDescargas.ReleaseMutex();
		ReordenarPrioridadPaquetes(RefrescarFicheros);
		if (Objeto is Fichero)
		{
			Fichero fichero2 = (Fichero)Objeto;
			Estado estado = Objeto.DescargaEstado();
			if ((uint)(estado - 3) <= 1u || (uint)(estado - 6) <= 1u)
			{
				fichero2.CancellationComplete += DisposeFichero;
				fichero2.MarcadoParaBorrarFicheroLocal = BorrarFicheros;
				fichero2.Stop();
				Log.WriteDebug("File download stopped " + fichero2.NombreFichero);
			}
			else
			{
				fichero2.MarcadoParaBorrarFicheroLocal = BorrarFicheros;
				fichero2.BorrarFicheroLocal();
				fichero2.Dispose();
			}
		}
		else
		{
			if (!(Objeto is Paquete))
			{
				return;
			}
			foreach (Fichero listaFichero3 in ((Paquete)Objeto).ListaFicheros)
			{
				Estado estado2 = listaFichero3.DescargaEstado();
				if ((uint)(estado2 - 3) <= 1u || (uint)(estado2 - 6) <= 1u)
				{
					listaFichero3.CancellationComplete += DisposeFichero;
					listaFichero3.MarcadoParaBorrarFicheroLocal = BorrarFicheros;
					listaFichero3.Stop();
					Log.WriteDebug("File download stopped " + listaFichero3.NombreFichero);
				}
				else
				{
					listaFichero3.MarcadoParaBorrarFicheroLocal = BorrarFicheros;
					listaFichero3.BorrarFicheroLocal();
					listaFichero3.Dispose();
				}
			}
			((Paquete)Objeto).ListaFicheros.Clear();
		}
	}

	private void DisposeFichero(object sender, EventArgs e)
	{
		if (!(sender is Fichero))
		{
			return;
		}
		Fichero fichero = (Fichero)sender;
		if (fichero != null)
		{
			Log.WriteDebug("Download file stopped " + fichero.NombreFichero + ", pending delete");
			if (fichero.MarcadoParaBorrarFicheroLocal)
			{
				fichero.BorrarFicheroLocal();
			}
			fichero.Dispose();
		}
	}

	internal decimal? ControlRemotoObtenerVelocidad()
	{
		return VelocidadGlobalDescarga;
	}

	internal int? ControlRemotoObtenerDescargasActivas()
	{
		return NumDescargasActivas;
	}

	internal int? ControlRemotoObtenerDescargasCompletadas()
	{
		return NumDescargasCompletadas;
	}

	internal int? ControlRemotoObtenerDescargasErroneas()
	{
		return NumDescargasErroneas;
	}

	internal int? ControlRemotoObtenerDescargasEnCola()
	{
		return NumDescargasEnCola;
	}

	internal TipoEstadoAplicacion ControlRemotoObtenerEstado()
	{
		return EstadoAplicacion;
	}

	internal void ControlRemotoDescargar()
	{
		btnPlay_Click(null, null);
	}

	internal void ControlRemotoParar()
	{
		btnStop_Click(null, null);
	}

	internal string ControlRemotoAgregarLinks(string Links, string NombrePaquete, bool CrearDirectorio)
	{
		List<string> list = URLExtractor.ExtraerURLs(Links);
		if (list.Count == 0)
		{
			return Language.GetText("No valid URLs have been inserted");
		}
		if (string.IsNullOrEmpty(Config.RutaDefecto) || !Directory.Exists(Config.RutaDefecto))
		{
			return Language.GetText("Can not add remote links without a default path");
		}
		Paquete paquete = new Paquete();
		Paquete paquete2 = paquete;
		paquete2.Nombre = NombrePaquete;
		if (string.IsNullOrEmpty(paquete2.Nombre))
		{
			paquete2.Nombre = Language.GetText("New package");
		}
		paquete2.RutaLocal = Config.RutaDefecto;
		paquete2.CrearSubdirectorio = CrearDirectorio;
		if (paquete2.CrearSubdirectorio)
		{
			paquete2.RutaLocal = paquete2.RutaLocal.Trim('\\') + "\\" + paquete2.Nombre;
			Directory.CreateDirectory(paquete2.RutaLocal);
		}
		Log.WriteWarning("Adding package in " + paquete2.RutaLocal);
		paquete2.SetDescargaExtraccionAutomatica((string)null, Config.ExtraerAutomaticamente);
		foreach (string item in list)
		{
			Fichero fichero = new Fichero(item);
			Fichero fichero2 = fichero;
			fichero2.RutaLocal = paquete.RutaLocal;
			fichero2.NombreFichero = item;
			fichero2.FileID = Fichero.ExtraerFileID(item);
			fichero2.FileKey = Fichero.ExtraerFileKey(item);
			fichero2.SetDescargaExtraccionAutomatica((string)null, Config.ExtraerAutomaticamente);
			Log.WriteWarning("Adding files to package: " + fichero2.FileID);
			fichero2 = null;
			paquete2.AgregarFichero(fichero);
		}
		paquete2 = null;
		AgregarPaquete(paquete, AgregadoDesdeServidorWeb: true);
		return "";
	}

	private bool VersionMayorWindowsXP()
	{
		if (Environment.OSVersion.Platform == PlatformID.Win32NT)
		{
			return Environment.OSVersion.Version.Major > 5;
		}
		return false;
	}

	private void clipChange_ClipboardChanged(object sender, EventArgs e)
	{
		if (Config != null && Config.AnalizarPortapapeles)
		{
			string texto = Conversions.ToString(Clipboard.GetDataObject().GetData(typeof(string)));
			ComprobarYAgregarLinks(texto, ExtraerURLs: true, EsconderLinks: false);
		}
	}

	public static Form IsFormAlreadyOpen(Type FormType)
	{
		foreach (Form openForm in Application.OpenForms)
		{
			if (Operators.CompareString(openForm.GetType().FullName, FormType.FullName, TextCompare: false) == 0)
			{
				return openForm;
			}
		}
		return null;
	}

	public static void FlushMemory()
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();
		if (Environment.OSVersion.Platform == PlatformID.Win32NT)
		{
			SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
		}
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

	private void MsgBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
	{
		if (StatusStrip1.InvokeRequired)
		{
			MsgBoxCallback method = MsgBox;
			Invoke(method, text, caption, buttons, icon);
		}
		else
		{
			MessageBox.Show(text, caption, buttons, icon);
		}
	}

	private void SetStatusBar(string RAM, string Proc, string Estado, string velocidad, string configuracionConexiones)
	{
		try
		{
			if (!Cerrando)
			{
				if (StatusStrip1.InvokeRequired)
				{
					SetStatusBarCallback method = SetStatusBar;
					Invoke(method, RAM, Proc, Estado, velocidad, configuracionConexiones);
					return;
				}
				RAMProcToolStripStatusLabel.Text = Language.GetText("RAM") + ": " + RAM + " / " + Language.GetText("Proc") + ": " + Proc;
				StatusToolStripStatusLabel.Text = Language.GetText("Status") + ": " + Estado + velocidad + "    " + Language.GetText("Connection conf") + ": " + configuracionConexiones;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void RefreshListaDescargas(bool SetObjects)
	{
		if (((Control)(object)ListaDescargas).InvokeRequired)
		{
			RefreshListaDescargasCallback method = RefreshListaDescargas;
			Invoke(method, SetObjects);
			return;
		}
		Mutex.ListaDescargas.WaitOne();
		try
		{
			if (SetObjects)
			{
				((ObjectListView)ListaDescargas).SetObjects((IEnumerable)ListaPaquetes);
				((ObjectListView)ListaDescargas).BuildList();
			}
			ListaDescargas.RefreshObjects((IList)ListaDescargas.Roots);
		}
		finally
		{
			Mutex.ListaDescargas.ReleaseMutex();
		}
	}

	private void TextoIconoMinimizado(string txt)
	{
		if (btnPause.InvokeRequired)
		{
			TextoIconoMinimizadoCallback method = TextoIconoMinimizado;
			Invoke(method, txt);
		}
		else
		{
			IconoMinimizado.Text = txt;
		}
	}

	private void ActivarUpdateButton()
	{
		if (btnPause.InvokeRequired)
		{
			ActivarUpdateButtonCallback method = ActivarUpdateButton;
			Invoke(method, new object[0]);
		}
		else if (!btnUpdate.Visible)
		{
			btnUpdate.Visible = true;
		}
	}

	private void CerrarAplicacion()
	{
		if (btnPause.InvokeRequired)
		{
			CerrarAplicacionCallback method = CerrarAplicacion;
			Invoke(method, new object[0]);
		}
		else
		{
			Close();
		}
	}

	private void Main_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Data.GetData(DataFormats.FileDrop) == null)
		{
			return;
		}
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
		bool flag = true;
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i = checked(i + 1))
		{
			if (!File.Exists(array2[i]))
			{
				flag = false;
			}
		}
		if (!flag)
		{
			return;
		}
		string[] array3 = array;
		foreach (string text in array3)
		{
			if (text.ToUpper().EndsWith(".DLC") | text.ToUpper().EndsWith(".ELC"))
			{
				AddDLC(text);
				break;
			}
		}
	}

	private void Main_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetData(DataFormats.FileDrop) == null)
		{
			return;
		}
		string[] obj = (string[])e.Data.GetData(DataFormats.FileDrop);
		bool flag = true;
		string[] array = obj;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			if (!File.Exists(array[i]))
			{
				flag = false;
			}
		}
		if (flag)
		{
			e.Effect = DragDropEffects.Copy;
		}
	}

	private void MostrarMensajeActualizacion()
	{
		if (StatusStrip1.InvokeRequired)
		{
			MostrarMensajeActualizacionCallback method = MostrarMensajeActualizacion;
			Invoke(method, new object[0]);
		}
		else if (Form.ActiveForm != null && Form.ActiveForm.Equals(this))
		{
			ProximoAvisoActualizacion = DateTime.MaxValue;
			if (MessageBox.Show(Language.GetText("New version do you want to download it? Recommended!"), Language.GetText("New version available"), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				btnUpdate_Click(null, null);
			}
			else
			{
				ProximoAvisoActualizacion = DateAndTime.Now.AddHours(3.0);
			}
		}
	}

	private void DescompresionFinalizada_EventHandler(string Code)
	{
		Mutex.ListaDescargas.WaitOne();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				if (Operators.CompareString(listaFichero.FileID, Code, TextCompare: false) == 0)
				{
					listaFichero.DescompresionFinalizada();
				}
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
	}

	private void ListaDescargas_CellRightClick(object sender, CellRightClickEventArgs e)
	{
		if (((ObjectListView)ListaDescargas).SelectedObjects == null || ((ObjectListView)ListaDescargas).SelectedObjects.Count == 0)
		{
			e.MenuStrip = MenuPanel;
			return;
		}
		VerErrorToolStripMenuItem.Visible = false;
		VerProgresoDescompresionToolStripMenuItem.Visible = false;
		ResetToolStripMenuItem.Visible = false;
		PropiedadesToolStripMenuItem.Enabled = false;
		PausarStripMenuItem.Visible = false;
		ForceDownloadStripMenuItem.Visible = false;
		if (((ObjectListView)ListaDescargas).SelectedObjects.Count == 1)
		{
			PropiedadesToolStripMenuItem.Enabled = true;
		}
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is IDescarga && ((IDescarga)objectValue).DescargaEstado() == Estado.Erroneo)
			{
				VerErrorToolStripMenuItem.Visible = true;
				ResetToolStripMenuItem.Visible = true;
			}
			else if (objectValue is Fichero && ((Fichero)objectValue).DescargaEstado() == Estado.Descargando)
			{
				PausarStripMenuItem.Visible = true;
			}
			else if (objectValue is Fichero && ((Fichero)objectValue).DescargaEstado() == Estado.EnCola)
			{
				ForceDownloadStripMenuItem.Visible = true;
			}
			else if (objectValue is Fichero && ((Fichero)objectValue).DescargaEstado() == Estado.Pausado)
			{
				ForceDownloadStripMenuItem.Visible = true;
			}
			else if (objectValue is Fichero && ((Fichero)objectValue).DescargaEstado() == Estado.Descomprimiendo)
			{
				VerProgresoDescompresionToolStripMenuItem.Visible = true;
			}
		}
		e.MenuStrip = MenuDescarga;
	}

	private void AgregarLinksToolStripMenuItem_Click(object sender, EventArgs e)
	{
		AgregarLink();
	}

	private void AgregarLinkStripMenuItem_Click(object sender, EventArgs e)
	{
		AgregarLink();
	}

	private void btnAddLink_Click(object sender, EventArgs e)
	{
		AgregarLink();
	}

	private void LimpiarCompletados2ToolStripMenuItem_Click(object sender, EventArgs e)
	{
		LimpiarCompletados();
	}

	private void LimpiarCompletadosToolStripMenuItem_Click(object sender, EventArgs e)
	{
		LimpiarCompletados();
	}

	private void LimpiarCompletados()
	{
		Mutex.ListaDescargas.WaitOne();
		List<Fichero> list = new List<Fichero>();
		foreach (Paquete listaPaquete in ListaPaquetes)
		{
			foreach (Fichero listaFichero in listaPaquete.ListaFicheros)
			{
				if (listaFichero.EstadoDescarga == Estado.Completado)
				{
					list.Add(listaFichero);
				}
			}
		}
		Mutex.ListaDescargas.ReleaseMutex();
		foreach (Fichero item in list)
		{
			Log.WriteDebug("Deleting file " + item.NombreFichero);
			Eliminar(item, BorrarFicheros: false, RefrescarFicheros: false);
		}
		RefreshListaDescargas(SetObjects: true);
	}

	private void About_Click(object sender, EventArgs e)
	{
		Credits credits = new Credits();
		credits.Text = Language.GetText("About");
		credits.ShowDialog();
		credits.Dispose();
	}

	internal void FAQ_Click(object sender, EventArgs e)
	{
		string text = Language.GetCurrentLanguageCode().ToUpperInvariant();
		if (text.StartsWith("ES"))
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("FAQ_LINK_ES"));
		}
		else if (text.StartsWith("FR"))
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("FAQ_LINK_FR"));
		}
		else
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("FAQ_LINK_EN"));
		}
	}

	private void CheckUpdates_Click(object sender, EventArgs e)
	{
		if (Language.GetCurrentLanguageCode().ToUpperInvariant().StartsWith("ES"))
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("DOWNLOAD_LINK_ES"));
		}
		else
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("DOWNLOAD_LINK_EN"));
		}
	}

	private void Collaborate_Click(object sender, EventArgs e)
	{
		if (Language.GetCurrentLanguageCode().ToUpperInvariant().StartsWith("ES"))
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("COLLABORATE_LINK_ES"));
		}
		else
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("COLLABORATE_LINK_EN"));
		}
	}

	private void GetMegaUploader_Click(object sender, EventArgs e)
	{
		string text = ((!Language.GetCurrentLanguageCode().ToUpperInvariant().StartsWith("ES")) ? InternalConfiguration.ObtenerValueFromInternalConfig("MEGAUPLOADER_LINK_EN") : InternalConfiguration.ObtenerValueFromInternalConfig("MEGAUPLOADER_LINK_ES"));
		if (string.IsNullOrEmpty(Fichero.ExtraerFileKey(text)))
		{
			Process.Start(text);
		}
		else
		{
			AgregarLink(text, "MegaUploader", ExtraerURLs: true, EsconderLinks: false);
		}
	}

	private void Buscador_Click(object sender, EventArgs e)
	{
		string right = ((MenuItem)sender).Text;
		Process.Start((from n in InternalConfiguration.ObtenerValuesFromInternalConfig("SEARCH_LIST/ELEMENT")
			where Operators.CompareString(n.Key, right, TextCompare: false) == 0
			select n).FirstOrDefault().Value);
	}

	private void btnConfig_Click(object sender, EventArgs e)
	{
		Configuration configuration = new Configuration();
		configuration.MainForm = this;
		configuration.Config = Config;
		configuration.RequiereConfiguracion = false;
		configuration.ShowDialog();
		configuration.Dispose();
	}

	private void VerStreaming_Click(object sender, EventArgs e)
	{
		if (IsFormAlreadyOpen(typeof(StreamingForm)) == null)
		{
			StreamingForm streamingForm = new StreamingForm();
			streamingForm.MainForm = this;
			streamingForm.Config = Config;
			streamingForm.Show();
		}
	}

	private void CreateStegano_Click(object sender, EventArgs e)
	{
		if (IsFormAlreadyOpen(typeof(SteganoWizardSave)) == null)
		{
			SteganoWizardSave steganoWizardSave = new SteganoWizardSave();
			steganoWizardSave.MainForm = this;
			steganoWizardSave.Config = Config;
			steganoWizardSave.Show();
		}
	}

	private void UseStegano_Click(object sender, EventArgs e)
	{
		OpenSteganoWizard();
	}

	public SteganoWizardLoad OpenSteganoWizard()
	{
		SteganoWizardLoad steganoWizardLoad = (SteganoWizardLoad)IsFormAlreadyOpen(typeof(SteganoWizardLoad));
		if (steganoWizardLoad == null)
		{
			steganoWizardLoad = new SteganoWizardLoad();
			steganoWizardLoad.MainForm = this;
			steganoWizardLoad.Config = Config;
			steganoWizardLoad.Show();
		}
		return steganoWizardLoad;
	}

	private void LibraryManager_Click(object sender, EventArgs e)
	{
		if (!Config.ServidorStreamingActivo)
		{
			MessageBox.Show(Language.GetText("Streaming server not activated"), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			Process.Start(StreamingHelper.LibraryManagerURL(Config.ServidorStreamingPuerto, Manage: true));
		}
	}

	private void SeeLibraryManager_Click(object sender, EventArgs e)
	{
		if (!Config.ServidorStreamingActivo)
		{
			MessageBox.Show(Language.GetText("Streaming server not activated"), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			Process.Start(StreamingHelper.LibraryManagerURL(Config.ServidorStreamingPuerto, Manage: false));
		}
	}

	private void VerLogs_Click(object sender, EventArgs e)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		Process.Start(text);
	}

	private void CodificarEnlaces_Click(object sender, EventArgs e)
	{
		if (IsFormAlreadyOpen(typeof(EncodeLinksForm)) == null)
		{
			EncodeLinksForm encodeLinksForm = new EncodeLinksForm();
			encodeLinksForm.MainForm = this;
			encodeLinksForm.Show();
		}
	}

	private void GenerateELC_Click(object sender, EventArgs e)
	{
		if (IsFormAlreadyOpen(typeof(EncodeLinksForm)) == null)
		{
			ELCForm eLCForm = new ELCForm();
			eLCForm.MainForm = this;
			eLCForm.Show();
		}
	}

	public void StartDownload()
	{
		QuitarPausasIndividuales();
		EstadoAplicacion = TipoEstadoAplicacion.Descargando;
		ThrottledStreamController.GetController().Continuar();
	}

	public void PauseDownload()
	{
		QuitarDescargasIndividuales();
		EstadoAplicacion = TipoEstadoAplicacion.Pausa;
		ThrottledStreamController.GetController().Abortar();
	}

	public void StopDownload()
	{
		QuitarDescargasIndividuales();
		EstadoAplicacion = TipoEstadoAplicacion.Parado;
		ThrottledStreamController.GetController().Abortar();
	}

	private void btnPlay_Click(object sender, EventArgs e)
	{
		StartDownload();
	}

	private void btnPause_Click(object sender, EventArgs e)
	{
		PauseDownload();
	}

	private void btnStop_Click(object sender, EventArgs e)
	{
		StopDownload();
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(UrlNuevaVersionMegadownloader) && UrlNuevaVersionMegadownloader.StartsWith("http"))
		{
			string value = Fichero.ExtraerFileKey(UrlNuevaVersionMegadownloader);
			if (string.IsNullOrEmpty(value) && URLExtractor.EsUrlAcortador(UrlNuevaVersionMegadownloader))
			{
				Conexion.ObtenerUrlDesdeAcortador(UrlNuevaVersionMegadownloader);
				value = Fichero.ExtraerFileKey(UrlNuevaVersionMegadownloader);
			}
			if (string.IsNullOrEmpty(value))
			{
				Process.Start(UrlNuevaVersionMegadownloader);
			}
			else
			{
				AgregarLink(UrlNuevaVersionMegadownloader, "MegaDownloader v" + VersionNuevaVersionMegadownloader, ExtraerURLs: true, EsconderLinks: false);
			}
		}
	}

	private void AbrirEnCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (((ObjectListView)ListaDescargas).SelectedObjects == null)
		{
			return;
		}
		string text = "";
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is Fichero)
			{
				text = ((Fichero)objectValue).RutaLocal;
			}
			else if (objectValue is Paquete)
			{
				text = ((Paquete)objectValue).RutaLocal;
			}
		}
		if (Directory.Exists(text))
		{
			Process.Start(text);
		}
		else
		{
			MessageBox.Show(Language.GetText("Directory %D% does not exist").Replace("%D%", text), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
	{
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is Paquete)
			{
				foreach (Fichero listaFichero in ((Paquete)objectValue).ListaFicheros)
				{
					if (listaFichero.DescargaEstado() == Estado.Erroneo)
					{
						Log.WriteDebug("Reseting file " + listaFichero.NombreFichero);
						listaFichero.SetDescargaEstado = Estado.EnCola;
					}
				}
			}
			else if (objectValue is Fichero)
			{
				Fichero fichero = (Fichero)objectValue;
				if (fichero.DescargaEstado() == Estado.Erroneo)
				{
					Log.WriteDebug("Reseting file " + fichero.NombreFichero);
					fichero.SetDescargaEstado = Estado.EnCola;
				}
			}
		}
	}

	private void VerProgresoDescompresionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (IsFormAlreadyOpen(typeof(Descompresor)) == null)
		{
			new Descompresor().Show();
		}
	}

	private void VerErrorToolStripMenuItem_Click(object sender, EventArgs e)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is Paquete)
			{
				foreach (Fichero listaFichero in ((Paquete)objectValue).ListaFicheros)
				{
					if (listaFichero.DescargaEstado() == Estado.Erroneo)
					{
						hashSet.Add(listaFichero.DescripcionError);
					}
				}
			}
			else if (objectValue is Fichero)
			{
				Fichero fichero = (Fichero)objectValue;
				if (fichero.DescargaEstado() == Estado.Erroneo)
				{
					hashSet.Add(fichero.DescripcionError);
				}
			}
		}
		string text = "";
		foreach (string item in hashSet)
		{
			text = text + item + "\r\n\r\n";
		}
		text = text.Trim();
		PantallaMsg pantallaMsg = new PantallaMsg();
		pantallaMsg.Text = Language.GetText("Error information");
		pantallaMsg.TextoError = text;
		pantallaMsg.ShowDialog();
		pantallaMsg.Dispose();
	}

	private void VerLinksToolStripMenuItem_Click(object sender, EventArgs e)
	{
		VerLinks(DescripcionFichero: false, stegano: false);
	}

	private void VerLinksDescToolStripMenuItem_Click(object sender, EventArgs e)
	{
		VerLinks(DescripcionFichero: true, stegano: false);
	}

	private void OcultarEnlacesImagenMenuItem_Click(object sender, EventArgs e)
	{
		VerLinks(DescripcionFichero: true, stegano: true);
	}

	private void VerLinks(bool DescripcionFichero, bool stegano)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is Paquete)
			{
				foreach (Fichero listaFichero in ((Paquete)objectValue).ListaFicheros)
				{
					Fichero fic = listaFichero;
					if (DescripcionFichero)
					{
						hashSet.Add(GetFullFileDesc(ref fic));
					}
					else
					{
						hashSet.Add(fic.LinkVisible ? fic.URL : "** LINK NOT VISIBLE **");
					}
				}
			}
			else if (objectValue is Fichero)
			{
				Fichero fic2 = (Fichero)objectValue;
				if (DescripcionFichero)
				{
					hashSet.Add(GetFullFileDesc(ref fic2));
				}
				else
				{
					hashSet.Add(fic2.LinkVisible ? fic2.URL : "** LINK NOT VISIBLE **");
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (!DescripcionFichero)
		{
			foreach (string item in hashSet)
			{
				stringBuilder.Append(item + "\r\n" + (DescripcionFichero ? "\r\n" : string.Empty));
			}
		}
		else
		{
			foreach (string item2 in hashSet.OrderBy([SpecialName] (string s) => s))
			{
				stringBuilder.Append(item2 + "\r\n" + (DescripcionFichero ? "\r\n" : string.Empty));
			}
		}
		if (stegano)
		{
			Form form = IsFormAlreadyOpen(typeof(SteganoWizardSave));
			if (form == null)
			{
				SteganoWizardSave steganoWizardSave = new SteganoWizardSave();
				steganoWizardSave.MainForm = this;
				steganoWizardSave.Config = Config;
				steganoWizardSave.txtLinks.Text = stringBuilder.ToString().Trim();
				steganoWizardSave.Show();
			}
			else
			{
				SteganoWizardSave steganoWizardSave2 = (SteganoWizardSave)form;
				if (string.IsNullOrEmpty(steganoWizardSave2.txtLinks.Text))
				{
					steganoWizardSave2.txtLinks.Text = stringBuilder.ToString().Trim();
				}
				else
				{
					RichTextBox txtLinks;
					(txtLinks = steganoWizardSave2.txtLinks).Text = txtLinks.Text + "\r\n" + stringBuilder.ToString().Trim();
				}
				steganoWizardSave2.Focus();
			}
		}
		else
		{
			PantallaMsg pantallaMsg = new PantallaMsg();
			pantallaMsg.Text = Language.GetText("Links");
			pantallaMsg.TextoError = stringBuilder.ToString().Trim();
			pantallaMsg.MostrarCodificarEnlaces = true;
			pantallaMsg.ShowDialog(this);
			pantallaMsg.Dispose();
		}
	}

	private string GetFullFileDesc(ref Fichero fic)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(fic.DescargaNombre());
		if (fic.TamanoBytes > 0)
		{
			stringBuilder.Append(" (").Append(PintarTamano(new decimal(fic.TamanoBytes))).Append(")");
		}
		stringBuilder.Append("\r\n");
		if (fic.LinkVisible)
		{
			stringBuilder.Append(fic.URL);
		}
		else
		{
			stringBuilder.Append("** LINK NOT VISIBLE **");
		}
		return stringBuilder.ToString();
	}

	private void PropiedadesToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (((ObjectListView)ListaDescargas).SelectedObject is IDescarga)
		{
			PropiedadesDescarga propiedadesDescarga = new PropiedadesDescarga();
			propiedadesDescarga.Descarga = (IDescarga)((ObjectListView)ListaDescargas).SelectedObject;
			propiedadesDescarga.ShowDialog();
			propiedadesDescarga.Dispose();
		}
	}

	private void PausarStripMenuItem_Click(object sender, EventArgs e)
	{
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is Fichero && ((Fichero)objectValue).DescargaEstado() == Estado.Descargando)
			{
				PonerFicheroEnPausa((Fichero)objectValue);
			}
		}
	}

	private void ForceDownloadStripMenuItem_Click(object sender, EventArgs e)
	{
		foreach (object selectedObject in ((ObjectListView)ListaDescargas).SelectedObjects)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(selectedObject);
			if (objectValue is Fichero && ((((Fichero)objectValue).DescargaEstado() == Estado.Pausado) | (((Fichero)objectValue).DescargaEstado() == Estado.EnCola)))
			{
				ForzarDescarga((Fichero)objectValue);
			}
		}
	}

	public void ComprobarYAgregarLinks(string Texto, bool ExtraerURLs, bool EsconderLinks)
	{
		Form form = IsFormAlreadyOpen(typeof(AddLinks));
		if (form == null)
		{
			List<Type> list = new List<Type>();
			list.Add(typeof(PantallaMsg));
			list.Add(typeof(ELCForm));
			list.Add(typeof(EncodeLinksForm));
			foreach (Type item in list)
			{
				form = IsFormAlreadyOpen(item);
				if (form != null)
				{
					return;
				}
			}
			List<string> list2 = URLExtractor.ExtraerConfiguracionELC(Texto);
			if (list2 != null && list2.Count > 0)
			{
				ELCAccountHelper eLCAccountHelper = new ELCAccountHelper(ref Config);
				Main MainForm = this;
				if (eLCAccountHelper.ImportConfig(list2, ref MainForm))
				{
					eLCAccountHelper.SaveToConfig(ref Config);
				}
				eLCAccountHelper.Dispose();
			}
			List<string> list3 = URLExtractor.ExtraerURLs(Texto);
			if (list3 != null && list3.Count > 0)
			{
				Activate();
				AgregarLink(Texto, string.Empty, ExtraerURLs, EsconderLinks);
			}
		}
		else if (Operators.CompareString(form.GetType().FullName, typeof(AddLinks).FullName, TextCompare: false) == 0)
		{
			AddLinks addLinks = (AddLinks)form;
			if (!addLinks.ContainsFocus && addLinks.AgregarEnlaces(Texto, limpiarContenidoAnterior: false, ExtraerURLs, EsconderLinks))
			{
				addLinks.PonerFoco();
			}
		}
	}

	private void AgregarLink()
	{
		AgregarLink(string.Empty, string.Empty, ExtraerURLs: true, EsconderLinks: false);
	}

	private void AgregarLink(string Url, string NombrePaquete, bool ExtraerURLs, bool EsconderLinks)
	{
		AddLinks addLinks = new AddLinks();
		addLinks.Main = this;
		addLinks.Config = Config;
		if (!string.IsNullOrEmpty(Url))
		{
			addLinks.AgregarEnlaces(Url, limpiarContenidoAnterior: true, ExtraerURLs, EsconderLinks);
		}
		if (!string.IsNullOrEmpty(NombrePaquete))
		{
			addLinks.txtNombre.Text = NombrePaquete;
		}
		addLinks.ShowDialog(this);
		bool openSteganoLoadOnExit = addLinks.OpenSteganoLoadOnExit;
		addLinks.Dispose();
		if (openSteganoLoadOnExit)
		{
			OpenSteganoWizard();
		}
	}

	public void ProcessArgs(string[] args)
	{
		if (args == null || args.Length == 0)
		{
			return;
		}
		string name = Assembly.GetExecutingAssembly().GetName().Name;
		if (args[0].ToUpper().Contains(name.ToUpper()))
		{
			args = args.ToList().Skip(1).ToArray();
		}
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		string[] array = args;
		foreach (string text in array)
		{
			List<string> list = URLExtractor.ExtraerConfiguracionELC(text);
			if (list != null && list.Count > 0)
			{
				ELCAccountHelper eLCAccountHelper = new ELCAccountHelper(ref Config);
				Main MainForm = this;
				if (eLCAccountHelper.ImportConfig(list, ref MainForm))
				{
					eLCAccountHelper.SaveToConfig(ref Config);
				}
				eLCAccountHelper.Dispose();
			}
			foreach (string item in URLExtractor.ExtraerURLs(text))
			{
				hashSet.Add(item);
			}
			if (text.ToUpper().EndsWith(".DLC") && File.Exists(text))
			{
				hashSet2.Add(text);
			}
		}
		if (hashSet.Count > 0)
		{
			ComprobarYAgregarLinks(string.Join("\r\n", hashSet.ToArray()), ExtraerURLs: true, EsconderLinks: false);
		}
		if (hashSet2.Count > 0)
		{
			AddDLC(hashSet2.ElementAtOrDefault(0));
		}
	}

	private void AddDLC(string DLCFilePath)
	{
		if (!DLCProcessing)
		{
			DLCProcessing = true;
			Thread thread = new Thread(StartProcessDLC);
			DLCPath = DLCFilePath;
			thread.Start();
		}
	}

	private void FinishProcessing()
	{
		Exception dLCErrorProcessing = DLCErrorProcessing;
		List<string> dLCResults = DLCResults;
		DLCResults = null;
		DLCErrorProcessing = null;
		if (dLCErrorProcessing != null)
		{
			MessageBox.Show(Language.GetText("The DLC could not be loaded. Reason: %REASON").Replace("%REASON", dLCErrorProcessing.Message), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		if (dLCResults == null)
		{
			return;
		}
		string text = "";
		foreach (string item in dLCResults)
		{
			if (text.Length > 0)
			{
				text += "\r\n";
			}
			text += item;
		}
		if (!string.IsNullOrEmpty(text))
		{
			AgregarLink(text, string.Empty, ExtraerURLs: true, EsconderLinks: false);
		}
		else if (dLCErrorProcessing != null)
		{
			MessageBox.Show(Language.GetText("The DLC has no valid Mega links"), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void StartProcessDLC()
	{
		Thread thread = new Thread(ProcessDLC);
		thread.Start();
		Action<bool> method;
		if (!thread.Join(new TimeSpan(0, 0, 0, 30)))
		{
			DLCProcessing = false;
			thread.Abort();
			DLCResults = null;
			method = [SpecialName] (bool x) =>
			{
				MessageBox.Show(Language.GetText("The DLC could not be loaded. Reason: %REASON").Replace("%REASON", "30s timeout"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			};
			Invoke(method, true);
		}
		DLCPath = string.Empty;
		method = [SpecialName] (bool x) =>
		{
			FinishProcessing();
		};
		Invoke(method, true);
	}

	private void ProcessDLC()
	{
		try
		{
			string dLCPath = DLCPath;
			if (string.IsNullOrEmpty(dLCPath))
			{
				throw new ApplicationException(Language.GetText("The path is not valid"));
			}
			if (dLCPath.ToLower().EndsWith(".elc"))
			{
				string text = DLCHelper.ReadELC_File(dLCPath);
				DLCResults = new List<string>();
				DLCResults.Add("mega://elc?" + text);
			}
			else
			{
				DLCResults = DLCHelper.DecryptDLC_File(dLCPath);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error processing DLC: " + ex2.ToString());
			DLCErrorProcessing = ex2;
			ProjectData.ClearProjectError();
		}
		finally
		{
			if (DLCProcessing)
			{
				DLCProcessing = false;
			}
		}
	}
}
