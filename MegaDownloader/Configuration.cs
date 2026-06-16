using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;
using MegaDownloader.My;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using SharpCompress.PriorityExtension;

namespace MegaDownloader;

[DesignerGenerated]
public class Configuration : Form
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExaminar")]
	private Button _btnExaminar;

	[CompilerGenerated]
	[AccessedThroughProperty("chkUnZip")]
	private CheckBox _chkUnZip;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCancel")]
	private Button _btnCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("btnGuardar")]
	private Button _btnGuardar;

	[CompilerGenerated]
	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[CompilerGenerated]
	[AccessedThroughProperty("chkReintentarError")]
	private CheckBox _chkReintentarError;

	[CompilerGenerated]
	[AccessedThroughProperty("chkShowPassword")]
	private CheckBox _chkShowPassword;

	[CompilerGenerated]
	[AccessedThroughProperty("chkProxy")]
	private CheckBox _chkProxy;

	[CompilerGenerated]
	[AccessedThroughProperty("linkApagarPC")]
	private LinkLabel _linkApagarPC;

	[CompilerGenerated]
	[AccessedThroughProperty("chkLimitarVelocidad")]
	private CheckBox _chkLimitarVelocidad;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExaminarTemplate")]
	private Button _btnExaminarTemplate;

	[CompilerGenerated]
	[AccessedThroughProperty("txtServidorWebTemplate")]
	private TextBox _txtServidorWebTemplate;

	[CompilerGenerated]
	[AccessedThroughProperty("chkServidorWeb")]
	private CheckBox _chkServidorWeb;

	[CompilerGenerated]
	[AccessedThroughProperty("linkUltConfig")]
	private LinkLabel _linkUltConfig;

	[CompilerGenerated]
	[AccessedThroughProperty("chkStreamingServer")]
	private CheckBox _chkStreamingServer;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExaminarVLCPath")]
	private Button _btnExaminarVLCPath;

	[CompilerGenerated]
	[AccessedThroughProperty("linkDownloadVLC")]
	private LinkLabel _linkDownloadVLC;

	public Configuracion Config;

	public Main MainForm;

	public bool RequiereConfiguracion;

	public const string PASSWORDDEFECTO = "*****";

	private List<string> ListaPreSharedKey;

	private ToolTip t;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnExaminar
	{
		[CompilerGenerated]
		get
		{
			return _btnExaminar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnExaminar_Click;
			Button button = _btnExaminar;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnExaminar = value;
			button = _btnExaminar;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("txtRuta")]
	internal virtual TextBox txtRuta
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("chkAnalisisPortapapeles")]
	internal virtual CheckBox chkAnalisisPortapapeles
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkUnZip
	{
		[CompilerGenerated]
		get
		{
			return _chkUnZip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkUnZip_CheckedChanged;
			CheckBox checkBox = _chkUnZip;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkUnZip = value;
			checkBox = _chkUnZip;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("chkCrearDirectorio")]
	internal virtual CheckBox chkCrearDirectorio
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtPassword")]
	internal virtual TextBox txtPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtUsuario")]
	internal virtual TextBox txtUsuario
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnCancel
	{
		[CompilerGenerated]
		get
		{
			return _btnCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnCancel_Click;
			Button button = _btnCancel;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnCancel = value;
			button = _btnCancel;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnGuardar
	{
		[CompilerGenerated]
		get
		{
			return _btnGuardar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnGuardar_Click;
			Button button = _btnGuardar;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnGuardar = value;
			button = _btnGuardar;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual GroupBox GroupBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtTamanoBuffer")]
	internal virtual TextBox txtTamanoBuffer
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label6")]
	internal virtual Label Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtTamanoPaquete")]
	internal virtual TextBox txtTamanoPaquete
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label8")]
	internal virtual Label Label8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel LinkLabel1
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LinkLabel1_MouseHover;
			EventHandler value3 = LinkLabel1_MouseLeave;
			EventHandler value4 = LinkLabel1_Click;
			LinkLabel linkLabel = _LinkLabel1;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_LinkLabel1 = value;
			linkLabel = _LinkLabel1;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	[field: AccessedThroughProperty("txtDescSimult")]
	internal virtual TextBox txtDescSimult
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label10")]
	internal virtual Label Label10
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtConFic")]
	internal virtual TextBox txtConFic
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label9")]
	internal virtual Label Label9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("comboLog")]
	internal virtual ComboBox comboLog
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label11")]
	internal virtual Label Label11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label12")]
	internal virtual Label Label12
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtPeriodoReintento")]
	internal virtual TextBox txtPeriodoReintento
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkReintentarError
	{
		[CompilerGenerated]
		get
		{
			return _chkReintentarError;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkReintentarError_CheckedChanged;
			CheckBox checkBox = _chkReintentarError;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkReintentarError = value;
			checkBox = _chkReintentarError;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox chkShowPassword
	{
		[CompilerGenerated]
		get
		{
			return _chkShowPassword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkShowPassword_CheckedChanged;
			CheckBox checkBox = _chkShowPassword;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkShowPassword = value;
			checkBox = _chkShowPassword;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("txtProxyPort")]
	internal virtual TextBox txtProxyPort
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label14")]
	internal virtual Label Label14
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtProxyIP")]
	internal virtual TextBox txtProxyIP
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label13")]
	internal virtual Label Label13
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkProxy
	{
		[CompilerGenerated]
		get
		{
			return _chkProxy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkProxy_CheckedChanged;
			CheckBox checkBox = _chkProxy;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkProxy = value;
			checkBox = _chkProxy;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("chkApagarPC")]
	internal virtual CheckBox chkApagarPC
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel linkApagarPC
	{
		[CompilerGenerated]
		get
		{
			return _linkApagarPC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = linkApagarPC_MouseHover;
			EventHandler value3 = linkApagarPC_MouseLeave;
			EventHandler value4 = linkApagarPC_Click;
			LinkLabel linkLabel = _linkApagarPC;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_linkApagarPC = value;
			linkLabel = _linkApagarPC;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	[field: AccessedThroughProperty("chkComenzarPlay")]
	internal virtual CheckBox chkComenzarPlay
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ConexionGroup")]
	internal virtual GroupBox ConexionGroup
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label15")]
	internal virtual Label Label15
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtLimiteVelocidadKBs")]
	internal virtual TextBox txtLimiteVelocidadKBs
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkLimitarVelocidad
	{
		[CompilerGenerated]
		get
		{
			return _chkLimitarVelocidad;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkLimitarVelocidad_CheckedChanged;
			CheckBox checkBox = _chkLimitarVelocidad;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkLimitarVelocidad = value;
			checkBox = _chkLimitarVelocidad;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual GroupBox GroupBox4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("chkStartWindows")]
	internal virtual CheckBox chkStartWindows
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("comboPrioridad")]
	internal virtual ComboBox comboPrioridad
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual TabControl TabControl1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual GroupBox GroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox5")]
	internal virtual GroupBox GroupBox5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnExaminarTemplate
	{
		[CompilerGenerated]
		get
		{
			return _btnExaminarTemplate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnExaminarTemplate_Click;
			Button button = _btnExaminarTemplate;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnExaminarTemplate = value;
			button = _btnExaminarTemplate;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox txtServidorWebTemplate
	{
		[CompilerGenerated]
		get
		{
			return _txtServidorWebTemplate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DragEventHandler value2 = txtServidorWebTemplate_DragDrop;
			DragEventHandler value3 = txtServidorWebTemplate_DragEnter;
			TextBox textBox = _txtServidorWebTemplate;
			if (textBox != null)
			{
				textBox.DragDrop -= value2;
				textBox.DragEnter -= value3;
			}
			_txtServidorWebTemplate = value;
			textBox = _txtServidorWebTemplate;
			if (textBox != null)
			{
				textBox.DragDrop += value2;
				textBox.DragEnter += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label21")]
	internal virtual Label Label21
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtServidorWebNombre")]
	internal virtual TextBox txtServidorWebNombre
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label20")]
	internal virtual Label Label20
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label19")]
	internal virtual Label Label19
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtServidorWebTimeout")]
	internal virtual TextBox txtServidorWebTimeout
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label18")]
	internal virtual Label Label18
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label17")]
	internal virtual Label Label17
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtServidorWebPassword")]
	internal virtual TextBox txtServidorWebPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtServidorWebPort")]
	internal virtual TextBox txtServidorWebPort
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label16")]
	internal virtual Label Label16
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkServidorWeb
	{
		[CompilerGenerated]
		get
		{
			return _chkServidorWeb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkServidorWeb_CheckedChanged;
			CheckBox checkBox = _chkServidorWeb;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkServidorWeb = value;
			checkBox = _chkServidorWeb;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual LinkLabel linkUltConfig
	{
		[CompilerGenerated]
		get
		{
			return _linkUltConfig;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = linkUltConfig_MouseHover;
			EventHandler value3 = linkUltConfig_MouseLeave;
			EventHandler value4 = linkUltConfig_Click;
			LinkLabel linkLabel = _linkUltConfig;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_linkUltConfig = value;
			linkLabel = _linkUltConfig;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	[field: AccessedThroughProperty("chkUltimaConfig")]
	internal virtual CheckBox chkUltimaConfig
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label23")]
	internal virtual Label Label23
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtProxyName")]
	internal virtual TextBox txtProxyName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtProxyPassword")]
	internal virtual TextBox txtProxyPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label22")]
	internal virtual Label Label22
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("comboIdiomas")]
	internal virtual ComboBox comboIdiomas
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label24")]
	internal virtual Label Label24
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblDesc")]
	internal virtual Label lblDesc
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox")]
	internal virtual GroupBox GroupBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtKeyList")]
	internal virtual TextBox txtKeyList
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox7")]
	internal virtual GroupBox GroupBox7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblInfoStreaming")]
	internal virtual Label lblInfoStreaming
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox6")]
	internal virtual GroupBox GroupBox6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtStreamingPort")]
	internal virtual TextBox txtStreamingPort
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblStreamingPort")]
	internal virtual Label lblStreamingPort
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkStreamingServer
	{
		[CompilerGenerated]
		get
		{
			return _chkStreamingServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkServidorStreaming_CheckedChanged;
			CheckBox checkBox = _chkStreamingServer;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkStreamingServer = value;
			checkBox = _chkStreamingServer;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox8")]
	internal virtual GroupBox GroupBox8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnExaminarVLCPath
	{
		[CompilerGenerated]
		get
		{
			return _btnExaminarVLCPath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnExaminarVLCPath_Click;
			Button button = _btnExaminarVLCPath;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnExaminarVLCPath = value;
			button = _btnExaminarVLCPath;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual LinkLabel linkDownloadVLC
	{
		[CompilerGenerated]
		get
		{
			return _linkDownloadVLC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = linkDownloadVLC_LinkClicked;
			LinkLabel linkLabel = _linkDownloadVLC;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_linkDownloadVLC = value;
			linkLabel = _linkDownloadVLC;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	[field: AccessedThroughProperty("txtVLCPath")]
	internal virtual TextBox txtVLCPath
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label26")]
	internal virtual Label Label26
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ElcAccountControl")]
	internal virtual ELCAccountControl ElcAccountControl
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtStreamingPassword")]
	internal virtual TextBox txtStreamingPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblStreamingPassword")]
	internal virtual Label lblStreamingPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("chkCheckUpdates")]
	internal virtual CheckBox chkCheckUpdates
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Configuration()
	{
		base.Load += Configuration_Load;
		base.FormClosed += Configuration_FormClosed;
		base.HelpButtonClicked += [SpecialName] (object a0, CancelEventArgs a1) =>
		{
			HelpButtonPressed();
		};
		RequiereConfiguracion = false;
		InitializeComponent();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MegaDownloader.Configuration));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.chkShowPassword = new System.Windows.Forms.CheckBox();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.txtUsuario = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.chkComenzarPlay = new System.Windows.Forms.CheckBox();
		this.linkApagarPC = new System.Windows.Forms.LinkLabel();
		this.chkApagarPC = new System.Windows.Forms.CheckBox();
		this.Label12 = new System.Windows.Forms.Label();
		this.txtPeriodoReintento = new System.Windows.Forms.TextBox();
		this.chkReintentarError = new System.Windows.Forms.CheckBox();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.txtDescSimult = new System.Windows.Forms.TextBox();
		this.Label10 = new System.Windows.Forms.Label();
		this.txtConFic = new System.Windows.Forms.TextBox();
		this.Label9 = new System.Windows.Forms.Label();
		this.chkAnalisisPortapapeles = new System.Windows.Forms.CheckBox();
		this.chkUnZip = new System.Windows.Forms.CheckBox();
		this.chkCrearDirectorio = new System.Windows.Forms.CheckBox();
		this.btnExaminar = new System.Windows.Forms.Button();
		this.txtRuta = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.btnCancel = new System.Windows.Forms.Button();
		this.btnGuardar = new System.Windows.Forms.Button();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.comboLog = new System.Windows.Forms.ComboBox();
		this.Label11 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.txtTamanoBuffer = new System.Windows.Forms.TextBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.txtTamanoPaquete = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.txtProxyPort = new System.Windows.Forms.TextBox();
		this.Label14 = new System.Windows.Forms.Label();
		this.txtProxyIP = new System.Windows.Forms.TextBox();
		this.Label13 = new System.Windows.Forms.Label();
		this.chkProxy = new System.Windows.Forms.CheckBox();
		this.ConexionGroup = new System.Windows.Forms.GroupBox();
		this.Label15 = new System.Windows.Forms.Label();
		this.txtLimiteVelocidadKBs = new System.Windows.Forms.TextBox();
		this.chkLimitarVelocidad = new System.Windows.Forms.CheckBox();
		this.GroupBox4 = new System.Windows.Forms.GroupBox();
		this.chkCheckUpdates = new System.Windows.Forms.CheckBox();
		this.comboIdiomas = new System.Windows.Forms.ComboBox();
		this.Label24 = new System.Windows.Forms.Label();
		this.linkUltConfig = new System.Windows.Forms.LinkLabel();
		this.chkUltimaConfig = new System.Windows.Forms.CheckBox();
		this.comboPrioridad = new System.Windows.Forms.ComboBox();
		this.chkStartWindows = new System.Windows.Forms.CheckBox();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.GroupBox5 = new System.Windows.Forms.GroupBox();
		this.btnExaminarTemplate = new System.Windows.Forms.Button();
		this.txtServidorWebTemplate = new System.Windows.Forms.TextBox();
		this.Label21 = new System.Windows.Forms.Label();
		this.txtServidorWebNombre = new System.Windows.Forms.TextBox();
		this.Label20 = new System.Windows.Forms.Label();
		this.Label19 = new System.Windows.Forms.Label();
		this.txtServidorWebTimeout = new System.Windows.Forms.TextBox();
		this.Label18 = new System.Windows.Forms.Label();
		this.Label17 = new System.Windows.Forms.Label();
		this.txtServidorWebPassword = new System.Windows.Forms.TextBox();
		this.txtServidorWebPort = new System.Windows.Forms.TextBox();
		this.Label16 = new System.Windows.Forms.Label();
		this.chkServidorWeb = new System.Windows.Forms.CheckBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label23 = new System.Windows.Forms.Label();
		this.txtProxyName = new System.Windows.Forms.TextBox();
		this.txtProxyPassword = new System.Windows.Forms.TextBox();
		this.Label22 = new System.Windows.Forms.Label();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.GroupBox = new System.Windows.Forms.GroupBox();
		this.txtKeyList = new System.Windows.Forms.TextBox();
		this.lblDesc = new System.Windows.Forms.Label();
		this.TabPage4 = new System.Windows.Forms.TabPage();
		this.GroupBox8 = new System.Windows.Forms.GroupBox();
		this.btnExaminarVLCPath = new System.Windows.Forms.Button();
		this.linkDownloadVLC = new System.Windows.Forms.LinkLabel();
		this.txtVLCPath = new System.Windows.Forms.TextBox();
		this.Label26 = new System.Windows.Forms.Label();
		this.GroupBox7 = new System.Windows.Forms.GroupBox();
		this.lblInfoStreaming = new System.Windows.Forms.Label();
		this.GroupBox6 = new System.Windows.Forms.GroupBox();
		this.txtStreamingPassword = new System.Windows.Forms.TextBox();
		this.lblStreamingPassword = new System.Windows.Forms.Label();
		this.txtStreamingPort = new System.Windows.Forms.TextBox();
		this.lblStreamingPort = new System.Windows.Forms.Label();
		this.chkStreamingServer = new System.Windows.Forms.CheckBox();
		this.TabPage5 = new System.Windows.Forms.TabPage();
		this.ElcAccountControl = new MegaDownloader.ELCAccountControl();
		this.GroupBox1.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.ConexionGroup.SuspendLayout();
		this.GroupBox4.SuspendLayout();
		this.TabControl1.SuspendLayout();
		this.TabPage1.SuspendLayout();
		this.TabPage2.SuspendLayout();
		this.GroupBox5.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.TabPage3.SuspendLayout();
		this.GroupBox.SuspendLayout();
		this.TabPage4.SuspendLayout();
		this.GroupBox8.SuspendLayout();
		this.GroupBox7.SuspendLayout();
		this.GroupBox6.SuspendLayout();
		this.TabPage5.SuspendLayout();
		base.SuspendLayout();
		this.GroupBox1.Controls.Add(this.chkShowPassword);
		this.GroupBox1.Controls.Add(this.txtPassword);
		this.GroupBox1.Controls.Add(this.txtUsuario);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Location = new System.Drawing.Point(6, 6);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(599, 62);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Datos de usuario (opcionales)";
		this.chkShowPassword.AutoSize = true;
		this.chkShowPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkShowPassword.Location = new System.Drawing.Point(468, 30);
		this.chkShowPassword.Name = "chkShowPassword";
		this.chkShowPassword.Size = new System.Drawing.Size(117, 17);
		this.chkShowPassword.TabIndex = 4;
		this.chkShowPassword.Text = "Mostrar contraseña";
		this.chkShowPassword.UseVisualStyleBackColor = false;
		this.txtPassword.Location = new System.Drawing.Point(302, 28);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size(156, 20);
		this.txtPassword.TabIndex = 3;
		this.txtPassword.UseSystemPasswordChar = true;
		this.txtUsuario.Location = new System.Drawing.Point(67, 28);
		this.txtUsuario.Name = "txtUsuario";
		this.txtUsuario.Size = new System.Drawing.Size(140, 20);
		this.txtUsuario.TabIndex = 1;
		this.Label3.AutoSize = true;
		this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label3.Location = new System.Drawing.Point(216, 31);
		this.Label3.MinimumSize = new System.Drawing.Size(80, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(80, 13);
		this.Label3.TabIndex = 2;
		this.Label3.Text = "Contraseña:";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.Label2.AutoSize = true;
		this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label2.Location = new System.Drawing.Point(9, 31);
		this.Label2.MinimumSize = new System.Drawing.Size(55, 0);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(55, 13);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Usuario:";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkComenzarPlay.AutoSize = true;
		this.chkComenzarPlay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkComenzarPlay.Location = new System.Drawing.Point(10, 81);
		this.chkComenzarPlay.Name = "chkComenzarPlay";
		this.chkComenzarPlay.Size = new System.Drawing.Size(282, 17);
		this.chkComenzarPlay.TabIndex = 5;
		this.chkComenzarPlay.Text = "Comenzar a descargar en cuanto se inicie el programa";
		this.chkComenzarPlay.UseVisualStyleBackColor = true;
		this.linkApagarPC.AutoSize = true;
		this.linkApagarPC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.linkApagarPC.Location = new System.Drawing.Point(563, 82);
		this.linkApagarPC.Name = "linkApagarPC";
		this.linkApagarPC.Size = new System.Drawing.Size(19, 13);
		this.linkApagarPC.TabIndex = 7;
		this.linkApagarPC.TabStop = true;
		this.linkApagarPC.Text = "[?]";
		this.chkApagarPC.AutoSize = true;
		this.chkApagarPC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkApagarPC.Location = new System.Drawing.Point(374, 81);
		this.chkApagarPC.Name = "chkApagarPC";
		this.chkApagarPC.Size = new System.Drawing.Size(178, 17);
		this.chkApagarPC.TabIndex = 6;
		this.chkApagarPC.Text = "Apagar PC al finalizar descargas";
		this.chkApagarPC.UseVisualStyleBackColor = true;
		this.Label12.AutoSize = true;
		this.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label12.Location = new System.Drawing.Point(283, 61);
		this.Label12.Name = "Label12";
		this.Label12.Size = new System.Drawing.Size(43, 13);
		this.Label12.TabIndex = 7;
		this.Label12.Text = "minutos";
		this.txtPeriodoReintento.Location = new System.Drawing.Point(247, 58);
		this.txtPeriodoReintento.MaxLength = 3;
		this.txtPeriodoReintento.Name = "txtPeriodoReintento";
		this.txtPeriodoReintento.Size = new System.Drawing.Size(30, 20);
		this.txtPeriodoReintento.TabIndex = 6;
		this.chkReintentarError.AutoSize = true;
		this.chkReintentarError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkReintentarError.Location = new System.Drawing.Point(9, 60);
		this.chkReintentarError.Name = "chkReintentarError";
		this.chkReintentarError.Size = new System.Drawing.Size(239, 17);
		this.chkReintentarError.TabIndex = 5;
		this.chkReintentarError.Text = "En caso de error, reintentar la descarga cada";
		this.chkReintentarError.UseVisualStyleBackColor = true;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.LinkLabel1.Location = new System.Drawing.Point(350, 91);
		this.LinkLabel1.MinimumSize = new System.Drawing.Size(230, 0);
		this.LinkLabel1.Name = "LinkLabel1";
		this.LinkLabel1.Size = new System.Drawing.Size(232, 13);
		this.LinkLabel1.TabIndex = 10;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Nota importante sobre el número de conexiones";
		this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.txtDescSimult.Location = new System.Drawing.Point(550, 26);
		this.txtDescSimult.MaxLength = 2;
		this.txtDescSimult.Name = "txtDescSimult";
		this.txtDescSimult.Size = new System.Drawing.Size(30, 20);
		this.txtDescSimult.TabIndex = 4;
		this.txtDescSimult.Text = "3";
		this.Label10.AutoSize = true;
		this.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label10.Location = new System.Drawing.Point(344, 29);
		this.Label10.MinimumSize = new System.Drawing.Size(200, 0);
		this.Label10.Name = "Label10";
		this.Label10.Size = new System.Drawing.Size(200, 13);
		this.Label10.TabIndex = 3;
		this.Label10.Text = "Número de descargas simultáneas:";
		this.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtConFic.Location = new System.Drawing.Point(550, 57);
		this.txtConFic.MaxLength = 2;
		this.txtConFic.Name = "txtConFic";
		this.txtConFic.Size = new System.Drawing.Size(30, 20);
		this.txtConFic.TabIndex = 9;
		this.txtConFic.Text = "2";
		this.Label9.AutoSize = true;
		this.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label9.Location = new System.Drawing.Point(344, 60);
		this.Label9.MinimumSize = new System.Drawing.Size(200, 0);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(200, 13);
		this.Label9.TabIndex = 8;
		this.Label9.Text = "Número de conexiones por fichero:";
		this.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkAnalisisPortapapeles.AutoSize = true;
		this.chkAnalisisPortapapeles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkAnalisisPortapapeles.Location = new System.Drawing.Point(10, 58);
		this.chkAnalisisPortapapeles.Name = "chkAnalisisPortapapeles";
		this.chkAnalisisPortapapeles.Size = new System.Drawing.Size(171, 17);
		this.chkAnalisisPortapapeles.TabIndex = 3;
		this.chkAnalisisPortapapeles.Text = "Capturar links del portapapeles";
		this.chkAnalisisPortapapeles.UseVisualStyleBackColor = true;
		this.chkUnZip.AutoSize = true;
		this.chkUnZip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkUnZip.Location = new System.Drawing.Point(10, 127);
		this.chkUnZip.Name = "chkUnZip";
		this.chkUnZip.Size = new System.Drawing.Size(181, 17);
		this.chkUnZip.TabIndex = 11;
		this.chkUnZip.Text = "Extracción automática. Prioridad:";
		this.chkUnZip.UseVisualStyleBackColor = true;
		this.chkCrearDirectorio.AutoSize = true;
		this.chkCrearDirectorio.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkCrearDirectorio.Location = new System.Drawing.Point(374, 58);
		this.chkCrearDirectorio.Name = "chkCrearDirectorio";
		this.chkCrearDirectorio.Size = new System.Drawing.Size(157, 17);
		this.chkCrearDirectorio.TabIndex = 4;
		this.chkCrearDirectorio.Text = "Crear directorio por paquete";
		this.chkCrearDirectorio.UseVisualStyleBackColor = true;
		this.btnExaminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnExaminar.Location = new System.Drawing.Point(507, 27);
		this.btnExaminar.Name = "btnExaminar";
		this.btnExaminar.Size = new System.Drawing.Size(75, 23);
		this.btnExaminar.TabIndex = 2;
		this.btnExaminar.Text = "Examinar";
		this.btnExaminar.UseVisualStyleBackColor = true;
		this.txtRuta.Location = new System.Drawing.Point(97, 29);
		this.txtRuta.Name = "txtRuta";
		this.txtRuta.Size = new System.Drawing.Size(404, 20);
		this.txtRuta.TabIndex = 1;
		this.Label1.AutoSize = true;
		this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label1.Location = new System.Drawing.Point(6, 32);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(85, 13);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Ruta descargas:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnCancel.Location = new System.Drawing.Point(556, 432);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(75, 23);
		this.btnCancel.TabIndex = 1;
		this.btnCancel.Text = "Cancelar";
		this.btnCancel.UseVisualStyleBackColor = true;
		this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnGuardar.Location = new System.Drawing.Point(9, 432);
		this.btnGuardar.Name = "btnGuardar";
		this.btnGuardar.Size = new System.Drawing.Size(75, 23);
		this.btnGuardar.TabIndex = 0;
		this.btnGuardar.Text = "Guardar";
		this.btnGuardar.UseVisualStyleBackColor = true;
		this.GroupBox3.Controls.Add(this.comboLog);
		this.GroupBox3.Controls.Add(this.Label11);
		this.GroupBox3.Controls.Add(this.Label8);
		this.GroupBox3.Controls.Add(this.Label7);
		this.GroupBox3.Controls.Add(this.txtTamanoBuffer);
		this.GroupBox3.Controls.Add(this.Label6);
		this.GroupBox3.Controls.Add(this.Label5);
		this.GroupBox3.Controls.Add(this.txtTamanoPaquete);
		this.GroupBox3.Controls.Add(this.Label4);
		this.GroupBox3.Location = new System.Drawing.Point(6, 6);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(599, 107);
		this.GroupBox3.TabIndex = 0;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Opciones avanzadas";
		this.comboLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboLog.FormattingEnabled = true;
		this.comboLog.Location = new System.Drawing.Point(432, 52);
		this.comboLog.Name = "comboLog";
		this.comboLog.Size = new System.Drawing.Size(153, 21);
		this.comboLog.TabIndex = 5;
		this.Label11.AutoSize = true;
		this.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label11.Location = new System.Drawing.Point(306, 55);
		this.Label11.MinimumSize = new System.Drawing.Size(120, 0);
		this.Label11.Name = "Label11";
		this.Label11.Size = new System.Drawing.Size(120, 13);
		this.Label11.TabIndex = 4;
		this.Label11.Text = "Nivel de logs:";
		this.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.Label8.AutoSize = true;
		this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic);
		this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label8.Location = new System.Drawing.Point(11, 27);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(397, 13);
		this.Label8.TabIndex = 0;
		this.Label8.Text = "Nota: Para usuarios avanzados. Si no estás seguro de que poner, no toques nada.";
		this.Label7.AutoSize = true;
		this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label7.Location = new System.Drawing.Point(205, 81);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(21, 13);
		this.Label7.TabIndex = 8;
		this.Label7.Text = "KB";
		this.txtTamanoBuffer.Location = new System.Drawing.Point(167, 78);
		this.txtTamanoBuffer.Name = "txtTamanoBuffer";
		this.txtTamanoBuffer.Size = new System.Drawing.Size(32, 20);
		this.txtTamanoBuffer.TabIndex = 7;
		this.txtTamanoBuffer.Text = "750";
		this.Label6.AutoSize = true;
		this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label6.Location = new System.Drawing.Point(12, 81);
		this.Label6.MinimumSize = new System.Drawing.Size(150, 0);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(150, 13);
		this.Label6.TabIndex = 6;
		this.Label6.Text = "Tamaño de buffer de disco:";
		this.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.Label5.AutoSize = true;
		this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label5.Location = new System.Drawing.Point(202, 55);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(21, 13);
		this.Label5.TabIndex = 3;
		this.Label5.Text = "KB";
		this.txtTamanoPaquete.Location = new System.Drawing.Point(165, 52);
		this.txtTamanoPaquete.Name = "txtTamanoPaquete";
		this.txtTamanoPaquete.Size = new System.Drawing.Size(34, 20);
		this.txtTamanoPaquete.TabIndex = 2;
		this.txtTamanoPaquete.Text = "50";
		this.Label4.AutoSize = true;
		this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label4.Location = new System.Drawing.Point(12, 55);
		this.Label4.MinimumSize = new System.Drawing.Size(150, 0);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(150, 13);
		this.Label4.TabIndex = 1;
		this.Label4.Text = "Tamaño paquete conexión:";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtProxyPort.Location = new System.Drawing.Point(537, 43);
		this.txtProxyPort.Name = "txtProxyPort";
		this.txtProxyPort.Size = new System.Drawing.Size(46, 20);
		this.txtProxyPort.TabIndex = 4;
		this.Label14.AutoSize = true;
		this.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label14.Location = new System.Drawing.Point(490, 46);
		this.Label14.MinimumSize = new System.Drawing.Size(45, 0);
		this.Label14.Name = "Label14";
		this.Label14.Size = new System.Drawing.Size(45, 13);
		this.Label14.TabIndex = 3;
		this.Label14.Text = "Puerto:";
		this.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtProxyIP.Location = new System.Drawing.Point(136, 43);
		this.txtProxyIP.Name = "txtProxyIP";
		this.txtProxyIP.Size = new System.Drawing.Size(322, 20);
		this.txtProxyIP.TabIndex = 2;
		this.Label13.AutoSize = true;
		this.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label13.Location = new System.Drawing.Point(9, 46);
		this.Label13.MinimumSize = new System.Drawing.Size(120, 0);
		this.Label13.Name = "Label13";
		this.Label13.Size = new System.Drawing.Size(121, 13);
		this.Label13.TabIndex = 1;
		this.Label13.Text = "Dirección / IP del proxy:";
		this.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkProxy.AutoSize = true;
		this.chkProxy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkProxy.Location = new System.Drawing.Point(12, 18);
		this.chkProxy.Name = "chkProxy";
		this.chkProxy.Size = new System.Drawing.Size(76, 17);
		this.chkProxy.TabIndex = 0;
		this.chkProxy.Text = "Usar proxy";
		this.chkProxy.UseVisualStyleBackColor = true;
		this.ConexionGroup.Controls.Add(this.Label15);
		this.ConexionGroup.Controls.Add(this.txtLimiteVelocidadKBs);
		this.ConexionGroup.Controls.Add(this.chkLimitarVelocidad);
		this.ConexionGroup.Controls.Add(this.Label12);
		this.ConexionGroup.Controls.Add(this.Label10);
		this.ConexionGroup.Controls.Add(this.txtPeriodoReintento);
		this.ConexionGroup.Controls.Add(this.chkReintentarError);
		this.ConexionGroup.Controls.Add(this.Label9);
		this.ConexionGroup.Controls.Add(this.txtConFic);
		this.ConexionGroup.Controls.Add(this.txtDescSimult);
		this.ConexionGroup.Controls.Add(this.LinkLabel1);
		this.ConexionGroup.Location = new System.Drawing.Point(6, 260);
		this.ConexionGroup.Name = "ConexionGroup";
		this.ConexionGroup.Size = new System.Drawing.Size(599, 116);
		this.ConexionGroup.TabIndex = 2;
		this.ConexionGroup.TabStop = false;
		this.ConexionGroup.Text = "Conexión";
		this.Label15.AutoSize = true;
		this.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label15.Location = new System.Drawing.Point(186, 30);
		this.Label15.Name = "Label15";
		this.Label15.Size = new System.Drawing.Size(31, 13);
		this.Label15.TabIndex = 2;
		this.Label15.Text = "KB/s";
		this.txtLimiteVelocidadKBs.Location = new System.Drawing.Point(132, 27);
		this.txtLimiteVelocidadKBs.MaxLength = 6;
		this.txtLimiteVelocidadKBs.Name = "txtLimiteVelocidadKBs";
		this.txtLimiteVelocidadKBs.Size = new System.Drawing.Size(48, 20);
		this.txtLimiteVelocidadKBs.TabIndex = 1;
		this.chkLimitarVelocidad.AutoSize = true;
		this.chkLimitarVelocidad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkLimitarVelocidad.Location = new System.Drawing.Point(9, 29);
		this.chkLimitarVelocidad.Name = "chkLimitarVelocidad";
		this.chkLimitarVelocidad.Size = new System.Drawing.Size(128, 17);
		this.chkLimitarVelocidad.TabIndex = 0;
		this.chkLimitarVelocidad.Text = "Limitar la velocidad a ";
		this.chkLimitarVelocidad.UseVisualStyleBackColor = true;
		this.GroupBox4.Controls.Add(this.chkCheckUpdates);
		this.GroupBox4.Controls.Add(this.comboIdiomas);
		this.GroupBox4.Controls.Add(this.Label24);
		this.GroupBox4.Controls.Add(this.linkUltConfig);
		this.GroupBox4.Controls.Add(this.chkUltimaConfig);
		this.GroupBox4.Controls.Add(this.comboPrioridad);
		this.GroupBox4.Controls.Add(this.chkStartWindows);
		this.GroupBox4.Controls.Add(this.btnExaminar);
		this.GroupBox4.Controls.Add(this.chkComenzarPlay);
		this.GroupBox4.Controls.Add(this.txtRuta);
		this.GroupBox4.Controls.Add(this.Label1);
		this.GroupBox4.Controls.Add(this.linkApagarPC);
		this.GroupBox4.Controls.Add(this.chkUnZip);
		this.GroupBox4.Controls.Add(this.chkApagarPC);
		this.GroupBox4.Controls.Add(this.chkAnalisisPortapapeles);
		this.GroupBox4.Controls.Add(this.chkCrearDirectorio);
		this.GroupBox4.Location = new System.Drawing.Point(6, 74);
		this.GroupBox4.Name = "GroupBox4";
		this.GroupBox4.Size = new System.Drawing.Size(599, 180);
		this.GroupBox4.TabIndex = 1;
		this.GroupBox4.TabStop = false;
		this.GroupBox4.Text = "Opciones generales";
		this.chkCheckUpdates.AutoSize = true;
		this.chkCheckUpdates.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkCheckUpdates.Location = new System.Drawing.Point(10, 150);
		this.chkCheckUpdates.Name = "chkCheckUpdates";
		this.chkCheckUpdates.Size = new System.Drawing.Size(153, 17);
		this.chkCheckUpdates.TabIndex = 15;
		this.chkCheckUpdates.Text = "Comprobar actualizaciones";
		this.chkCheckUpdates.UseVisualStyleBackColor = true;
		this.comboIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboIdiomas.FormattingEnabled = true;
		this.comboIdiomas.Location = new System.Drawing.Point(429, 128);
		this.comboIdiomas.Name = "comboIdiomas";
		this.comboIdiomas.Size = new System.Drawing.Size(152, 21);
		this.comboIdiomas.TabIndex = 14;
		this.Label24.AutoSize = true;
		this.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label24.Location = new System.Drawing.Point(371, 131);
		this.Label24.Name = "Label24";
		this.Label24.Size = new System.Drawing.Size(41, 13);
		this.Label24.TabIndex = 13;
		this.Label24.Text = "Idioma:";
		this.linkUltConfig.AutoSize = true;
		this.linkUltConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.linkUltConfig.Location = new System.Drawing.Point(563, 105);
		this.linkUltConfig.Name = "linkUltConfig";
		this.linkUltConfig.Size = new System.Drawing.Size(19, 13);
		this.linkUltConfig.TabIndex = 10;
		this.linkUltConfig.TabStop = true;
		this.linkUltConfig.Text = "[?]";
		this.chkUltimaConfig.AutoSize = true;
		this.chkUltimaConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkUltimaConfig.Location = new System.Drawing.Point(374, 104);
		this.chkUltimaConfig.Name = "chkUltimaConfig";
		this.chkUltimaConfig.Size = new System.Drawing.Size(193, 17);
		this.chkUltimaConfig.TabIndex = 9;
		this.chkUltimaConfig.Text = "Guardar última configuración usada";
		this.chkUltimaConfig.UseVisualStyleBackColor = true;
		this.comboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboPrioridad.FormattingEnabled = true;
		this.comboPrioridad.Location = new System.Drawing.Point(191, 125);
		this.comboPrioridad.Name = "comboPrioridad";
		this.comboPrioridad.Size = new System.Drawing.Size(67, 21);
		this.comboPrioridad.TabIndex = 12;
		this.chkStartWindows.AutoSize = true;
		this.chkStartWindows.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkStartWindows.Location = new System.Drawing.Point(10, 104);
		this.chkStartWindows.Name = "chkStartWindows";
		this.chkStartWindows.Size = new System.Drawing.Size(122, 17);
		this.chkStartWindows.TabIndex = 8;
		this.chkStartWindows.Text = "Iniciar con Windows";
		this.chkStartWindows.UseVisualStyleBackColor = true;
		this.TabControl1.Controls.Add(this.TabPage1);
		this.TabControl1.Controls.Add(this.TabPage2);
		this.TabControl1.Controls.Add(this.TabPage3);
		this.TabControl1.Controls.Add(this.TabPage4);
		this.TabControl1.Controls.Add(this.TabPage5);
		this.TabControl1.Location = new System.Drawing.Point(10, 12);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(621, 408);
		this.TabControl1.TabIndex = 0;
		this.TabPage1.Controls.Add(this.GroupBox1);
		this.TabPage1.Controls.Add(this.ConexionGroup);
		this.TabPage1.Controls.Add(this.GroupBox4);
		this.TabPage1.Location = new System.Drawing.Point(4, 22);
		this.TabPage1.Name = "TabPage1";
		this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage1.Size = new System.Drawing.Size(613, 382);
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "General";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.TabPage2.Controls.Add(this.GroupBox5);
		this.TabPage2.Controls.Add(this.GroupBox2);
		this.TabPage2.Controls.Add(this.GroupBox3);
		this.TabPage2.Location = new System.Drawing.Point(4, 22);
		this.TabPage2.Name = "TabPage2";
		this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage2.Size = new System.Drawing.Size(613, 382);
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "Avanzado";
		this.TabPage2.UseVisualStyleBackColor = true;
		this.GroupBox5.Controls.Add(this.btnExaminarTemplate);
		this.GroupBox5.Controls.Add(this.txtServidorWebTemplate);
		this.GroupBox5.Controls.Add(this.Label21);
		this.GroupBox5.Controls.Add(this.txtServidorWebNombre);
		this.GroupBox5.Controls.Add(this.Label20);
		this.GroupBox5.Controls.Add(this.Label19);
		this.GroupBox5.Controls.Add(this.txtServidorWebTimeout);
		this.GroupBox5.Controls.Add(this.Label18);
		this.GroupBox5.Controls.Add(this.Label17);
		this.GroupBox5.Controls.Add(this.txtServidorWebPassword);
		this.GroupBox5.Controls.Add(this.txtServidorWebPort);
		this.GroupBox5.Controls.Add(this.Label16);
		this.GroupBox5.Controls.Add(this.chkServidorWeb);
		this.GroupBox5.Location = new System.Drawing.Point(6, 232);
		this.GroupBox5.Name = "GroupBox5";
		this.GroupBox5.Size = new System.Drawing.Size(599, 144);
		this.GroupBox5.TabIndex = 2;
		this.GroupBox5.TabStop = false;
		this.GroupBox5.Text = "Servidor Web";
		this.btnExaminarTemplate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnExaminarTemplate.Location = new System.Drawing.Point(510, 79);
		this.btnExaminarTemplate.Name = "btnExaminarTemplate";
		this.btnExaminarTemplate.Size = new System.Drawing.Size(75, 23);
		this.btnExaminarTemplate.TabIndex = 10;
		this.btnExaminarTemplate.Text = "Examinar";
		this.btnExaminarTemplate.UseVisualStyleBackColor = true;
		this.txtServidorWebTemplate.AllowDrop = true;
		this.txtServidorWebTemplate.Location = new System.Drawing.Point(114, 81);
		this.txtServidorWebTemplate.Name = "txtServidorWebTemplate";
		this.txtServidorWebTemplate.Size = new System.Drawing.Size(388, 20);
		this.txtServidorWebTemplate.TabIndex = 9;
		this.Label21.AutoSize = true;
		this.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label21.Location = new System.Drawing.Point(12, 84);
		this.Label21.Name = "Label21";
		this.Label21.Size = new System.Drawing.Size(97, 13);
		this.Label21.TabIndex = 8;
		this.Label21.Text = "Ruta de la plantilla:";
		this.txtServidorWebNombre.Location = new System.Drawing.Point(114, 115);
		this.txtServidorWebNombre.Name = "txtServidorWebNombre";
		this.txtServidorWebNombre.Size = new System.Drawing.Size(123, 20);
		this.txtServidorWebNombre.TabIndex = 12;
		this.Label20.AutoSize = true;
		this.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label20.Location = new System.Drawing.Point(12, 118);
		this.Label20.Name = "Label20";
		this.Label20.Size = new System.Drawing.Size(96, 13);
		this.Label20.TabIndex = 11;
		this.Label20.Text = "Nombre (opcional):";
		this.Label19.AutoSize = true;
		this.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label19.Location = new System.Drawing.Point(414, 48);
		this.Label19.Name = "Label19";
		this.Label19.Size = new System.Drawing.Size(43, 13);
		this.Label19.TabIndex = 5;
		this.Label19.Text = "minutos";
		this.txtServidorWebTimeout.Location = new System.Drawing.Point(377, 45);
		this.txtServidorWebTimeout.MaxLength = 2;
		this.txtServidorWebTimeout.Name = "txtServidorWebTimeout";
		this.txtServidorWebTimeout.Size = new System.Drawing.Size(31, 20);
		this.txtServidorWebTimeout.TabIndex = 4;
		this.Label18.AutoSize = true;
		this.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label18.Location = new System.Drawing.Point(251, 48);
		this.Label18.MinimumSize = new System.Drawing.Size(120, 0);
		this.Label18.Name = "Label18";
		this.Label18.Size = new System.Drawing.Size(120, 13);
		this.Label18.TabIndex = 3;
		this.Label18.Text = "Interrumpir sesión:";
		this.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.Label17.AutoSize = true;
		this.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label17.Location = new System.Drawing.Point(12, 48);
		this.Label17.MinimumSize = new System.Drawing.Size(80, 0);
		this.Label17.Name = "Label17";
		this.Label17.Size = new System.Drawing.Size(80, 13);
		this.Label17.TabIndex = 1;
		this.Label17.Text = "Contraseña:";
		this.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtServidorWebPassword.Location = new System.Drawing.Point(93, 45);
		this.txtServidorWebPassword.Name = "txtServidorWebPassword";
		this.txtServidorWebPassword.Size = new System.Drawing.Size(144, 20);
		this.txtServidorWebPassword.TabIndex = 2;
		this.txtServidorWebPassword.UseSystemPasswordChar = true;
		this.txtServidorWebPort.Location = new System.Drawing.Point(537, 45);
		this.txtServidorWebPort.Name = "txtServidorWebPort";
		this.txtServidorWebPort.Size = new System.Drawing.Size(46, 20);
		this.txtServidorWebPort.TabIndex = 7;
		this.Label16.AutoSize = true;
		this.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label16.Location = new System.Drawing.Point(490, 48);
		this.Label16.MinimumSize = new System.Drawing.Size(41, 0);
		this.Label16.Name = "Label16";
		this.Label16.Size = new System.Drawing.Size(41, 13);
		this.Label16.TabIndex = 6;
		this.Label16.Text = "Puerto:";
		this.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkServidorWeb.AutoSize = true;
		this.chkServidorWeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkServidorWeb.Location = new System.Drawing.Point(12, 19);
		this.chkServidorWeb.Name = "chkServidorWeb";
		this.chkServidorWeb.Size = new System.Drawing.Size(111, 17);
		this.chkServidorWeb.TabIndex = 0;
		this.chkServidorWeb.Text = "Usar servidor web";
		this.chkServidorWeb.UseVisualStyleBackColor = true;
		this.GroupBox2.Controls.Add(this.Label23);
		this.GroupBox2.Controls.Add(this.txtProxyName);
		this.GroupBox2.Controls.Add(this.txtProxyPassword);
		this.GroupBox2.Controls.Add(this.Label22);
		this.GroupBox2.Controls.Add(this.txtProxyPort);
		this.GroupBox2.Controls.Add(this.txtProxyIP);
		this.GroupBox2.Controls.Add(this.Label14);
		this.GroupBox2.Controls.Add(this.chkProxy);
		this.GroupBox2.Controls.Add(this.Label13);
		this.GroupBox2.Location = new System.Drawing.Point(6, 119);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(599, 107);
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Proxy";
		this.Label23.AutoSize = true;
		this.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label23.Location = new System.Drawing.Point(10, 76);
		this.Label23.MinimumSize = new System.Drawing.Size(120, 0);
		this.Label23.Name = "Label23";
		this.Label23.Size = new System.Drawing.Size(120, 13);
		this.Label23.TabIndex = 5;
		this.Label23.Text = "Usuario (opcional):";
		this.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtProxyName.Location = new System.Drawing.Point(135, 73);
		this.txtProxyName.Name = "txtProxyName";
		this.txtProxyName.Size = new System.Drawing.Size(144, 20);
		this.txtProxyName.TabIndex = 6;
		this.txtProxyPassword.Location = new System.Drawing.Point(428, 73);
		this.txtProxyPassword.Name = "txtProxyPassword";
		this.txtProxyPassword.Size = new System.Drawing.Size(155, 20);
		this.txtProxyPassword.TabIndex = 8;
		this.txtProxyPassword.UseSystemPasswordChar = true;
		this.Label22.AutoSize = true;
		this.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label22.Location = new System.Drawing.Point(296, 76);
		this.Label22.MinimumSize = new System.Drawing.Size(130, 0);
		this.Label22.Name = "Label22";
		this.Label22.Size = new System.Drawing.Size(130, 13);
		this.Label22.TabIndex = 7;
		this.Label22.Text = "Contraseña (opcional):";
		this.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.TabPage3.Controls.Add(this.GroupBox);
		this.TabPage3.Controls.Add(this.lblDesc);
		this.TabPage3.Location = new System.Drawing.Point(4, 22);
		this.TabPage3.Name = "TabPage3";
		this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage3.Size = new System.Drawing.Size(613, 382);
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "Pre-Shared Keys";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.GroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox.Controls.Add(this.txtKeyList);
		this.GroupBox.Location = new System.Drawing.Point(9, 65);
		this.GroupBox.Name = "GroupBox";
		this.GroupBox.Size = new System.Drawing.Size(598, 311);
		this.GroupBox.TabIndex = 4;
		this.GroupBox.TabStop = false;
		this.GroupBox.Text = "Listado de claves";
		this.txtKeyList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtKeyList.Location = new System.Drawing.Point(6, 19);
		this.txtKeyList.Multiline = true;
		this.txtKeyList.Name = "txtKeyList";
		this.txtKeyList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtKeyList.Size = new System.Drawing.Size(586, 286);
		this.txtKeyList.TabIndex = 0;
		this.lblDesc.AutoSize = true;
		this.lblDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblDesc.Location = new System.Drawing.Point(12, 12);
		this.lblDesc.Name = "lblDesc";
		this.lblDesc.Size = new System.Drawing.Size(473, 39);
		this.lblDesc.TabIndex = 3;
		this.lblDesc.Text = resources.GetString("lblDesc.Text");
		this.TabPage4.Controls.Add(this.GroupBox8);
		this.TabPage4.Controls.Add(this.GroupBox7);
		this.TabPage4.Controls.Add(this.GroupBox6);
		this.TabPage4.Location = new System.Drawing.Point(4, 22);
		this.TabPage4.Name = "TabPage4";
		this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage4.Size = new System.Drawing.Size(613, 382);
		this.TabPage4.TabIndex = 3;
		this.TabPage4.Text = "Streaming";
		this.TabPage4.UseVisualStyleBackColor = true;
		this.GroupBox8.Controls.Add(this.btnExaminarVLCPath);
		this.GroupBox8.Controls.Add(this.linkDownloadVLC);
		this.GroupBox8.Controls.Add(this.txtVLCPath);
		this.GroupBox8.Controls.Add(this.Label26);
		this.GroupBox8.Location = new System.Drawing.Point(6, 73);
		this.GroupBox8.Name = "GroupBox8";
		this.GroupBox8.Size = new System.Drawing.Size(601, 60);
		this.GroupBox8.TabIndex = 2;
		this.GroupBox8.TabStop = false;
		this.GroupBox8.Text = "Configuración VLC";
		this.btnExaminarVLCPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.btnExaminarVLCPath.Location = new System.Drawing.Point(404, 22);
		this.btnExaminarVLCPath.Name = "btnExaminarVLCPath";
		this.btnExaminarVLCPath.Size = new System.Drawing.Size(75, 23);
		this.btnExaminarVLCPath.TabIndex = 11;
		this.btnExaminarVLCPath.Text = "Examinar";
		this.btnExaminarVLCPath.UseVisualStyleBackColor = true;
		this.linkDownloadVLC.AutoSize = true;
		this.linkDownloadVLC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.linkDownloadVLC.Location = new System.Drawing.Point(476, 27);
		this.linkDownloadVLC.MinimumSize = new System.Drawing.Size(100, 0);
		this.linkDownloadVLC.Name = "linkDownloadVLC";
		this.linkDownloadVLC.Size = new System.Drawing.Size(100, 13);
		this.linkDownloadVLC.TabIndex = 11;
		this.linkDownloadVLC.TabStop = true;
		this.linkDownloadVLC.Text = "Descargar VLC";
		this.linkDownloadVLC.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtVLCPath.Location = new System.Drawing.Point(87, 24);
		this.txtVLCPath.Name = "txtVLCPath";
		this.txtVLCPath.Size = new System.Drawing.Size(311, 20);
		this.txtVLCPath.TabIndex = 10;
		this.Label26.AutoSize = true;
		this.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.Label26.Location = new System.Drawing.Point(6, 27);
		this.Label26.MinimumSize = new System.Drawing.Size(75, 0);
		this.Label26.Name = "Label26";
		this.Label26.Size = new System.Drawing.Size(75, 13);
		this.Label26.TabIndex = 10;
		this.Label26.Text = "Ruta VLC:";
		this.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.GroupBox7.Controls.Add(this.lblInfoStreaming);
		this.GroupBox7.Location = new System.Drawing.Point(6, 139);
		this.GroupBox7.Name = "GroupBox7";
		this.GroupBox7.Size = new System.Drawing.Size(601, 237);
		this.GroupBox7.TabIndex = 1;
		this.GroupBox7.TabStop = false;
		this.GroupBox7.Text = "Información";
		this.lblInfoStreaming.AutoSize = true;
		this.lblInfoStreaming.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblInfoStreaming.Location = new System.Drawing.Point(6, 16);
		this.lblInfoStreaming.MaximumSize = new System.Drawing.Size(570, 0);
		this.lblInfoStreaming.MinimumSize = new System.Drawing.Size(570, 0);
		this.lblInfoStreaming.Name = "lblInfoStreaming";
		this.lblInfoStreaming.Size = new System.Drawing.Size(570, 273);
		this.lblInfoStreaming.TabIndex = 0;
		this.lblInfoStreaming.Text = resources.GetString("lblInfoStreaming.Text");
		this.GroupBox6.Controls.Add(this.txtStreamingPassword);
		this.GroupBox6.Controls.Add(this.lblStreamingPassword);
		this.GroupBox6.Controls.Add(this.txtStreamingPort);
		this.GroupBox6.Controls.Add(this.lblStreamingPort);
		this.GroupBox6.Controls.Add(this.chkStreamingServer);
		this.GroupBox6.Location = new System.Drawing.Point(6, 6);
		this.GroupBox6.Name = "GroupBox6";
		this.GroupBox6.Size = new System.Drawing.Size(601, 61);
		this.GroupBox6.TabIndex = 0;
		this.GroupBox6.TabStop = false;
		this.GroupBox6.Text = "Configuración de streaming";
		this.txtStreamingPassword.Location = new System.Drawing.Point(447, 26);
		this.txtStreamingPassword.Name = "txtStreamingPassword";
		this.txtStreamingPassword.Size = new System.Drawing.Size(129, 20);
		this.txtStreamingPassword.TabIndex = 11;
		this.txtStreamingPassword.UseSystemPasswordChar = true;
		this.lblStreamingPassword.AutoSize = true;
		this.lblStreamingPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblStreamingPassword.Location = new System.Drawing.Point(316, 29);
		this.lblStreamingPassword.MinimumSize = new System.Drawing.Size(125, 0);
		this.lblStreamingPassword.Name = "lblStreamingPassword";
		this.lblStreamingPassword.Size = new System.Drawing.Size(125, 13);
		this.lblStreamingPassword.TabIndex = 10;
		this.lblStreamingPassword.Text = "Password (opcional):";
		this.lblStreamingPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtStreamingPort.Location = new System.Drawing.Point(253, 25);
		this.txtStreamingPort.Name = "txtStreamingPort";
		this.txtStreamingPort.Size = new System.Drawing.Size(40, 20);
		this.txtStreamingPort.TabIndex = 9;
		this.lblStreamingPort.AutoSize = true;
		this.lblStreamingPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblStreamingPort.Location = new System.Drawing.Point(206, 29);
		this.lblStreamingPort.MinimumSize = new System.Drawing.Size(41, 0);
		this.lblStreamingPort.Name = "lblStreamingPort";
		this.lblStreamingPort.Size = new System.Drawing.Size(41, 13);
		this.lblStreamingPort.TabIndex = 8;
		this.lblStreamingPort.Text = "Puerto:";
		this.lblStreamingPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkStreamingServer.AutoSize = true;
		this.chkStreamingServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.chkStreamingServer.Location = new System.Drawing.Point(23, 28);
		this.chkStreamingServer.Name = "chkStreamingServer";
		this.chkStreamingServer.Size = new System.Drawing.Size(151, 17);
		this.chkStreamingServer.TabIndex = 1;
		this.chkStreamingServer.Text = "Usar servidor de streaming";
		this.chkStreamingServer.UseVisualStyleBackColor = true;
		this.TabPage5.Controls.Add(this.ElcAccountControl);
		this.TabPage5.Location = new System.Drawing.Point(4, 22);
		this.TabPage5.Name = "TabPage5";
		this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
		this.TabPage5.Size = new System.Drawing.Size(613, 382);
		this.TabPage5.TabIndex = 4;
		this.TabPage5.Text = "Cuentas ELC";
		this.TabPage5.UseVisualStyleBackColor = true;
		this.ElcAccountControl.Location = new System.Drawing.Point(-2, 0);
		this.ElcAccountControl.Name = "ElcAccountControl";
		this.ElcAccountControl.Size = new System.Drawing.Size(615, 376);
		this.ElcAccountControl.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btnCancel;
		base.ClientSize = new System.Drawing.Size(643, 467);
		base.Controls.Add(this.TabControl1);
		base.Controls.Add(this.btnGuardar);
		base.Controls.Add(this.btnCancel);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.HelpButton = true;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Configuration";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Configuration";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.ConexionGroup.ResumeLayout(false);
		this.ConexionGroup.PerformLayout();
		this.GroupBox4.ResumeLayout(false);
		this.GroupBox4.PerformLayout();
		this.TabControl1.ResumeLayout(false);
		this.TabPage1.ResumeLayout(false);
		this.TabPage2.ResumeLayout(false);
		this.GroupBox5.ResumeLayout(false);
		this.GroupBox5.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.TabPage3.ResumeLayout(false);
		this.TabPage3.PerformLayout();
		this.GroupBox.ResumeLayout(false);
		this.GroupBox.PerformLayout();
		this.TabPage4.ResumeLayout(false);
		this.GroupBox8.ResumeLayout(false);
		this.GroupBox8.PerformLayout();
		this.GroupBox7.ResumeLayout(false);
		this.GroupBox7.PerformLayout();
		this.GroupBox6.ResumeLayout(false);
		this.GroupBox6.PerformLayout();
		this.TabPage5.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void Configuration_Load(object sender, EventArgs e)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		ElcAccountControl.Config = Config;
		ElcAccountControl.CargarDatos();
		Translate();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary[Log.LevelLogType.Minimal.ToString()] = Language.GetText("Log_Minimum");
		dictionary[Log.LevelLogType.Normal.ToString()] = Language.GetText("Log_Normal");
		dictionary[Log.LevelLogType.Info.ToString()] = Language.GetText("Log_Informative");
		dictionary[Log.LevelLogType.Debug.ToString()] = Language.GetText("Log_Debug");
		comboLog.DataSource = new BindingSource(dictionary, null);
		comboLog.DisplayMember = "Value";
		comboLog.ValueMember = "Key";
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		dictionary2[((Enum)(Priority.PriorityType)0/*cast due to .constrained prefix*/).ToString()] = Language.GetText("Priority_Normal");
		dictionary2[((Enum)(Priority.PriorityType)1/*cast due to .constrained prefix*/).ToString()] = Language.GetText("Priority_Low");
		comboPrioridad.DataSource = new BindingSource(dictionary2, null);
		comboPrioridad.DisplayMember = "Value";
		comboPrioridad.ValueMember = "Key";
		Dictionary<string, string> availableLanguages = Language.GetAvailableLanguages();
		comboIdiomas.DataSource = new BindingSource(availableLanguages, null);
		comboIdiomas.DisplayMember = "Value";
		comboIdiomas.ValueMember = "Key";
		txtRuta.Text = Config.RutaDefecto;
		if (string.IsNullOrEmpty(txtRuta.Text) || !Directory.Exists(Config.RutaDefecto))
		{
			txtRuta.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		}
		txtUsuario.Text = Config.Usuario;
		txtPassword.Text = "*****";
		txtVLCPath.Text = Config.VLCPath;
		if (string.IsNullOrEmpty(Config.VLCPath))
		{
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\VideoLan\\VLC", writable: false);
				if (registryKey == null)
				{
					registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\VideoLan\\VLC", writable: false);
				}
				if (registryKey != null && registryKey.GetValue("InstallDir") != null)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(registryKey.GetValue("InstallDir"));
					txtVLCPath.Text = Conversions.ToString(objectValue);
				}
			}
			catch (SecurityException ex)
			{
				ProjectData.SetProjectError(ex);
				SecurityException ex2 = ex;
				Log.WriteError("SECURITY ERROR: Not enough privileges to access the registry. Can't read VLC path.");
				ProjectData.ClearProjectError();
			}
		}
		chkAnalisisPortapapeles.Checked = Config.AnalizarPortapapeles;
		chkCrearDirectorio.Checked = Config.CrearDirectorioPaquete;
		chkUnZip.Checked = Config.ExtraerAutomaticamente;
		chkApagarPC.Checked = Config.ApagarPC;
		chkCheckUpdates.Checked = Config.CheckUpdates;
		chkUltimaConfig.Checked = Config.MantenerUltimaConfiguracion;
		chkComenzarPlay.Checked = Config.ComenzarDescargando;
		chkStartWindows.Checked = Config.IniciarConWindows;
		comboLog.SelectedValue = Config.NivelLog.ToString();
		comboPrioridad.SelectedValue = ((Enum)System.Runtime.CompilerServices.Unsafe.As<Priority.PriorityType, Priority.PriorityType>(ref Config.PrioridadDescompresion)/*cast due to .constrained prefix*/).ToString();
		comboIdiomas.SelectedValue = Config.Idioma;
		if (string.IsNullOrEmpty(Conversions.ToString(comboIdiomas.SelectedValue)) && comboIdiomas.Items.Count > 0)
		{
			comboIdiomas.SelectedIndex = 0;
		}
		chkReintentarError.Checked = Config.ResetearErrores;
		if (Config.ResetearErrores)
		{
			txtPeriodoReintento.Text = Config.ResetearErroresPeriodoMinutos.ToString();
		}
		if (Config.TamanoPaqueteKB > 0)
		{
			txtTamanoPaquete.Text = Config.TamanoPaqueteKB.ToString();
		}
		if (Config.TamanoBufferKB > 0)
		{
			txtTamanoBuffer.Text = Config.TamanoBufferKB.ToString();
		}
		if (Config.ConexionesPorFichero > 0)
		{
			txtConFic.Text = Config.ConexionesPorFichero.ToString();
		}
		if (Config.DescargasSimultaneas > 0)
		{
			txtDescSimult.Text = Config.DescargasSimultaneas.ToString();
		}
		chkLimitarVelocidad.Checked = Config.LimiteVelocidadKBs > 0;
		txtLimiteVelocidadKBs.Enabled = chkLimitarVelocidad.Checked;
		if (Config.LimiteVelocidadKBs > 0)
		{
			txtLimiteVelocidadKBs.Text = ((double)Config.LimiteVelocidadKBs / 1024.0).ToString();
		}
		chkProxy.Checked = Config.UsarProxy;
		txtProxyIP.Text = Config.ProxyIP;
		txtProxyPort.Text = Config.ProxyPort.ToString();
		txtProxyName.Text = Config.ProxyUser;
		txtProxyPassword.Text = Config.ProxyPassword;
		if (Config.ProxyPort == 0)
		{
			txtProxyPort.Text = "";
		}
		txtStreamingPassword.Text = Config.ServidorStreamingPassword;
		chkStreamingServer.Checked = Config.ServidorStreamingActivo;
		txtStreamingPort.Text = Config.ServidorStreamingPuerto.ToString();
		if (Config.ServidorStreamingPuerto == 0)
		{
			txtStreamingPort.Text = "";
		}
		chkServidorWeb.Checked = Config.ServidorWebActivo;
		txtServidorWebNombre.Text = Config.ServidorWebNombre;
		txtServidorWebPassword.Text = Config.ServidorWebPassword;
		txtServidorWebPort.Text = Config.ServidorWebPuerto.ToString();
		txtServidorWebTemplate.Text = Config.ServidorWebRutaPlantilla;
		txtServidorWebTimeout.Text = Config.ServidorWebTimeout.ToString();
		if (Config.ServidorWebPuerto == 0)
		{
			txtServidorWebPort.Text = "";
		}
		if ((Config.ServidorWebTimeout < 0) | (Config.ServidorWebTimeout > 60))
		{
			txtServidorWebTimeout.Text = "";
		}
		comboPrioridad.Enabled = chkUnZip.Checked;
		txtKeyList.Text = "";
		if (Config.ListaPreSharedKeys != null)
		{
			foreach (SecureString listaPreSharedKey in Config.ListaPreSharedKeys)
			{
				TextBox textBox;
				(textBox = txtKeyList).Text = textBox.Text + Criptografia.ToInsecureString(listaPreSharedKey) + "\r\n";
			}
		}
		chkProxy_CheckedChanged(null, null);
		chkServidorWeb_CheckedChanged(null, null);
		chkServidorStreaming_CheckedChanged(null, null);
		chkReintentarError_CheckedChanged(null, null);
	}

	private void Configuration_FormClosed(object sender, FormClosedEventArgs e)
	{
		ElcAccountControl.Cerrar();
	}

	private void Translate()
	{
		Text = Language.GetText("Configuration");
		btnCancel.Text = Language.GetText("Cancel");
		btnGuardar.Text = Language.GetText("Save");
		GroupBox1.Text = Language.GetText("User data");
		chkShowPassword.Text = Language.GetText("Show password");
		Label3.Text = Language.GetText("Password") + ":";
		Label24.Text = Language.GetText("Language") + ":";
		Label2.Text = Language.GetText("E-mail") + ":";
		chkComenzarPlay.Text = Language.GetText("Start downloading when application starts");
		chkApagarPC.Text = Language.GetText("Turn off computer when finished");
		Label12.Text = Language.GetText("minutes");
		Label19.Text = Language.GetText("minutes");
		chkReintentarError.Text = Language.GetText("In case of error, retry the download each");
		LinkLabel1.Text = Language.GetText("Important note about connections");
		Label10.Text = Language.GetText("Number of parallel downloads") + ":";
		Label9.Text = Language.GetText("Number of connections per file") + ":";
		chkAnalisisPortapapeles.Text = Language.GetText("Capture links from clipboard");
		chkUnZip.Text = Language.GetText("Automatic extraction") + ". " + Language.GetText("Priority") + ":";
		chkCheckUpdates.Text = Language.GetText("Check for updates");
		chkCrearDirectorio.Text = Language.GetText("Create folder per package");
		btnExaminar.Text = Language.GetText("Browse");
		Label1.Text = Language.GetText("Download path") + ":";
		GroupBox3.Text = Language.GetText("Advanced options");
		Label11.Text = Language.GetText("Log level") + ":";
		Label8.Text = Language.GetText("Note: for advanced users only. Dont touch anything if you arent sure");
		Label6.Text = Language.GetText("Disk buffer size") + ":";
		Label4.Text = Language.GetText("Package size") + ":";
		Label14.Text = Language.GetText("Port") + ":";
		Label16.Text = Language.GetText("Port") + ":";
		Label13.Text = Language.GetText("Proxy address/IP") + ":";
		chkProxy.Text = Language.GetText("Use proxy");
		ConexionGroup.Text = Language.GetText("Connection");
		chkLimitarVelocidad.Text = Language.GetText("Limit speed to");
		GroupBox4.Text = Language.GetText("General options");
		chkUltimaConfig.Text = Language.GetText("Save / use last used configuration");
		chkStartWindows.Text = Language.GetText("Start with Windows");
		TabPage1.Text = Language.GetText("General");
		TabPage2.Text = Language.GetText("Advanced");
		GroupBox5.Text = Language.GetText("Web server");
		btnExaminarTemplate.Text = Language.GetText("Browse");
		Label21.Text = Language.GetText("Template path") + ":";
		Label20.Text = Language.GetText("Name (optional)") + ":";
		Label18.Text = Language.GetText("Interrupt session") + ":";
		Label17.Text = Language.GetText("Password") + ":";
		chkServidorWeb.Text = Language.GetText("Use web server");
		GroupBox2.Text = Language.GetText("Proxy");
		Label23.Text = Language.GetText("User (optional)") + ":";
		Label22.Text = Language.GetText("Password (optional)") + ":";
		TabPage3.Text = Language.GetText("Pre-Shared Keys");
		TabPage4.Text = Language.GetText("Streaming");
		TabPage5.Text = Language.GetText("ELC Accounts");
		lblDesc.Text = Language.GetText("Pre-Shared Key Manager Description");
		GroupBox.Text = Language.GetText("Pre-Shared Key list");
		GroupBox6.Text = Language.GetText("Streaming configuration");
		GroupBox7.Text = Language.GetText("Information");
		lblStreamingPort.Text = Language.GetText("Port") + ":";
		chkStreamingServer.Text = Language.GetText("Use streaming server");
		GroupBox8.Text = Language.GetText("VLC Configuration");
		Label26.Text = Language.GetText("VLC Path") + ":";
		btnExaminarVLCPath.Text = Language.GetText("Browse");
		linkDownloadVLC.Text = Language.GetText("Download VLC");
		lblInfoStreaming.Text = Language.GetText("Streaming configuration text");
		lblStreamingPassword.Text = Language.GetText("Password") + " (" + Language.GetText("optional") + "):";
	}

	private void btnExaminar_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.Description = Language.GetText("Select directory");
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			txtRuta.Text = folderBrowserDialog.SelectedPath;
		}
		folderBrowserDialog.Dispose();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		if (RequiereConfiguracion & string.IsNullOrEmpty(txtUsuario.Text) & string.IsNullOrEmpty(txtPassword.Text))
		{
			MessageBox.Show(Language.GetText("You must configure user and password"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		else
		{
			Close();
		}
	}

	private void btnGuardar_Click(object sender, EventArgs e)
	{
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(Config.Password) & (Operators.CompareString(txtPassword.Text, "*****", TextCompare: false) == 0))
		{
			txtPassword.Text = "";
		}
		if (string.IsNullOrEmpty(txtRuta.Text) && MessageBox.Show(Language.GetText("Do you want to leave the default path empty?"), Language.GetText("Save"), MessageBoxButtons.YesNo) == DialogResult.No)
		{
			return;
		}
		int result = 0;
		int result2 = 0;
		int.TryParse(txtTamanoPaquete.Text, out result);
		int.TryParse(txtTamanoBuffer.Text, out result2);
		if (result == 0 || result2 == 0)
		{
			MessageBox.Show(Language.GetText("Disk buffer or package size values are not correct"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (result >= result2)
		{
			MessageBox.Show(Language.GetText("Disk buffer size must be greater than package size"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int result3 = 0;
		int result4 = 0;
		int.TryParse(txtDescSimult.Text, out result3);
		int.TryParse(txtConFic.Text, out result4);
		if (result3 <= 0 || result4 <= 0 || checked(result3 * result4) > 100)
		{
			MessageBox.Show(Language.GetText("Connection number values are incorrect or too high"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int result5 = 0;
		int.TryParse(txtPeriodoReintento.Text, out result5);
		if (result5 < 1 || result5 > 999)
		{
			if (chkReintentarError.Checked)
			{
				MessageBox.Show(Language.GetText("Must specify the retry period, and this value must be between %A and %B").Replace("%A", "1").Replace("%B", "999"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			result5 = 15;
		}
		int result6 = 0;
		int.TryParse(txtProxyPort.Text, out result6);
		if (chkProxy.Checked & ((result6 == 0 || result6 > 65535) | string.IsNullOrEmpty(txtProxyIP.Text)))
		{
			MessageBox.Show(Language.GetText("Invalid proxy configuration"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int result7 = 0;
		int.TryParse(txtLimiteVelocidadKBs.Text, out result7);
		if (!chkLimitarVelocidad.Checked)
		{
			result7 = 0;
		}
		else if ((result7 <= 0) | string.IsNullOrEmpty(txtLimiteVelocidadKBs.Text))
		{
			MessageBox.Show(Language.GetText("Invalid speed limit"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		result7 = checked(result7 * 1024);
		int result8 = 0;
		int.TryParse(txtServidorWebPort.Text, out result8);
		int result9 = 0;
		int.TryParse(txtStreamingPort.Text, out result9);
		int result10 = 5;
		int.TryParse(txtServidorWebTimeout.Text, out result10);
		if (!chkServidorWeb.Checked)
		{
			if (result8 < 1024 || result8 > 65535)
			{
				result8 = 0;
			}
			if (result10 < 0 || result10 > 99)
			{
				result10 = 5;
			}
		}
		else
		{
			if ((result8 < 1024 || result8 > 65535) | string.IsNullOrEmpty(txtServidorWebPort.Text))
			{
				MessageBox.Show(Language.GetText("Invalid server port"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if ((result10 < 0 || result10 > 99) | string.IsNullOrEmpty(txtServidorWebTimeout.Text))
			{
				MessageBox.Show(Language.GetText("The value for interrumpting the session must be between 0 and %A. A value of 0 means that session is not interrupted").Replace("%A", "99"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (!string.IsNullOrEmpty(txtServidorWebTemplate.Text) && !File.Exists(txtServidorWebTemplate.Text))
			{
				MessageBox.Show(Language.GetText("The template path is not valid"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (string.IsNullOrEmpty(txtServidorWebPassword.Text) && txtServidorWebPassword.Text.Length < 8)
			{
				MessageBox.Show(Language.GetText("The web server password must have at least %A characters").Replace("%A", "8"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		if (!chkStreamingServer.Checked)
		{
			if (result9 < 1024 || result9 > 65535)
			{
				result9 = 0;
			}
		}
		else if ((result9 < 1024 || result9 > 65535) | string.IsNullOrEmpty(txtStreamingPort.Text))
		{
			MessageBox.Show(Language.GetText("Invalid server port"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if ((chkServidorWeb.Checked & chkStreamingServer.Checked) && result8 == result9)
		{
			MessageBox.Show(Language.GetText("Web server and streaming server ports must be different"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (Operators.CompareString(txtPassword.Text, "*****", TextCompare: false) != 0)
		{
			Config.Password = txtPassword.Text;
		}
		Config.VLCPath = txtVLCPath.Text;
		Config.Usuario = txtUsuario.Text;
		Config.RutaDefecto = txtRuta.Text;
		Config.ExtraerAutomaticamente = chkUnZip.Checked;
		Config.AnalizarPortapapeles = chkAnalisisPortapapeles.Checked;
		Config.CrearDirectorioPaquete = chkCrearDirectorio.Checked;
		Config.ComenzarDescargando = chkComenzarPlay.Checked;
		Config.TamanoBufferKB = result2;
		Config.TamanoPaqueteKB = result;
		Config.ConexionesPorFichero = result4;
		Config.DescargasSimultaneas = result3;
		Config.ResetearErrores = chkReintentarError.Checked;
		Config.ApagarPC = chkApagarPC.Checked;
		Config.CheckUpdates = chkCheckUpdates.Checked;
		Config.MantenerUltimaConfiguracion = chkUltimaConfig.Checked;
		Config.IniciarConWindows = chkStartWindows.Checked;
		Config.ResetearErroresPeriodoMinutos = result5;
		Config.UsarProxy = chkProxy.Checked;
		Config.ProxyPassword = txtProxyPassword.Text;
		Config.ProxyUser = txtProxyName.Text;
		Config.ProxyPort = result6;
		Config.ProxyIP = txtProxyIP.Text;
		Config.LimiteVelocidadKBs = result7;
		Config.ServidorStreamingActivo = chkStreamingServer.Checked;
		Config.ServidorStreamingPuerto = result9;
		Config.ServidorStreamingPassword = txtStreamingPassword.Text;
		Config.ServidorWebActivo = chkServidorWeb.Checked;
		Config.ServidorWebNombre = txtServidorWebNombre.Text;
		Config.ServidorWebPassword = txtServidorWebPassword.Text;
		Config.ServidorWebPuerto = result8;
		Config.ServidorWebRutaPlantilla = txtServidorWebTemplate.Text;
		Config.ServidorWebTimeout = result10;
		ElcAccountControl.SaveToConfig(ref Config);
		bool flag = false;
		if (Language.IsValidLanguageCode(Conversions.ToString(comboIdiomas.SelectedValue)))
		{
			flag = Operators.CompareString(Config.Idioma, Conversions.ToString(comboIdiomas.SelectedValue), TextCompare: false) != 0;
			Config.Idioma = Conversions.ToString(comboIdiomas.SelectedValue);
		}
		if (Enum.IsDefined(typeof(Log.LevelLogType), RuntimeHelpers.GetObjectValue(comboLog.SelectedValue)))
		{
			Configuracion config = Config;
			Type typeFromHandle = typeof(Log.LevelLogType);
			object selectedItem = comboLog.SelectedItem;
			config.NivelLog = (Log.LevelLogType)Conversions.ToInteger(Enum.Parse(typeFromHandle, ((selectedItem != null) ? ((KeyValuePair<string, string>)selectedItem) : default(KeyValuePair<string, string>)).Key));
			Log.SetLogLevel = Config.NivelLog;
		}
		if (Enum.IsDefined(typeof(Priority.PriorityType), RuntimeHelpers.GetObjectValue(comboPrioridad.SelectedValue)))
		{
			Configuracion config2 = Config;
			Type typeFromHandle2 = typeof(Priority.PriorityType);
			object selectedItem2 = comboPrioridad.SelectedItem;
			config2.PrioridadDescompresion = (Priority.PriorityType)Conversions.ToInteger(Enum.Parse(typeFromHandle2, ((selectedItem2 != null) ? ((KeyValuePair<string, string>)selectedItem2) : default(KeyValuePair<string, string>)).Key));
			Priority.DecompressionPriority = Config.PrioridadDescompresion;
		}
		List<SecureString> list = new List<SecureString>();
		string text = txtKeyList.Text;
		if (!string.IsNullOrEmpty(text))
		{
			string[] array = text.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
			foreach (string text2 in array)
			{
				if (!string.IsNullOrEmpty(text2))
				{
					list.Add(Criptografia.ToSecureString(text2));
				}
			}
		}
		Config.ListaPreSharedKeys = list;
		Config.GuardarXML(ForzarGuardado: true);
		Conexion.SetProxy(Config);
		Configuracion.RegisterInStartup(Config.IniciarConWindows);
		ThrottledStreamController.GetController().SetMaxGlobalSpeed(Config.LimiteVelocidadKBs);
		MyProject.Forms.Main.Config = Config;
		MyProject.Forms.Main.NecesitaCambiarUsuarioYPassword = false;
		ServidorWebController.StopWebServer();
		MyProject.MyForms forms;
		Main Downloader = (forms = MyProject.Forms).Main;
		string obj = ServidorWebController.StartWebServer(ref Downloader, Config);
		forms.Main = Downloader;
		string text3 = obj;
		if (!string.IsNullOrEmpty(text3))
		{
			MessageBox.Show(Language.GetText("Error starting web server") + ": " + text3, Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		bool flag2 = string.IsNullOrEmpty(txtUsuario.Text) & string.IsNullOrEmpty(txtPassword.Text);
		bool num = !string.IsNullOrEmpty(txtUsuario.Text) & !string.IsNullOrEmpty(txtPassword.Text);
		string text4 = "";
		if (flag)
		{
			text4 = text4 + "\r\n * " + Language.GetText("You have to restart the application for the language change to take effect");
		}
		if (num)
		{
			text4 = text4 + "\r\n * " + Language.GetText("User and password is not used yet");
		}
		if (!string.IsNullOrEmpty(text4))
		{
			text4 = "\r\n\r\n" + Language.GetText("Please take into consideration the following") + ": " + text4;
		}
		MessageBox.Show(Language.GetText("Data saved successfully") + text4, Language.GetText("Save"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Close();
	}

	private string MsgMaxConexiones()
	{
		return Language.GetText("Number of connection explanation");
	}

	private void LinkLabel1_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(LinkLabel1, MsgMaxConexiones());
	}

	private void LinkLabel1_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(LinkLabel1);
		}
	}

	private void LinkLabel1_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgMaxConexiones(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
	{
		txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
	}

	private void chkProxy_CheckedChanged(object sender, EventArgs e)
	{
		txtProxyIP.Enabled = chkProxy.Checked;
		txtProxyPort.Enabled = chkProxy.Checked;
		txtProxyName.Enabled = chkProxy.Checked;
		txtProxyPassword.Enabled = chkProxy.Checked;
	}

	private void chkServidorWeb_CheckedChanged(object sender, EventArgs e)
	{
		txtServidorWebNombre.Enabled = chkServidorWeb.Checked;
		txtServidorWebPassword.Enabled = chkServidorWeb.Checked;
		txtServidorWebPort.Enabled = chkServidorWeb.Checked;
		txtServidorWebTemplate.Enabled = chkServidorWeb.Checked;
		txtServidorWebTimeout.Enabled = chkServidorWeb.Checked;
		btnExaminarTemplate.Enabled = chkServidorWeb.Checked;
	}

	private void chkServidorStreaming_CheckedChanged(object sender, EventArgs e)
	{
		txtStreamingPort.Enabled = chkStreamingServer.Checked;
	}

	private string MsgApagarPC()
	{
		return Language.GetText("Turn off PC explanation");
	}

	private void linkApagarPC_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(linkApagarPC, MsgApagarPC());
	}

	private void linkApagarPC_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(linkApagarPC);
		}
	}

	private void linkApagarPC_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgApagarPC(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void chkLimitarVelocidad_CheckedChanged(object sender, EventArgs e)
	{
		txtLimiteVelocidadKBs.Enabled = chkLimitarVelocidad.Checked;
	}

	private void btnVerDescompresor_Click(object sender, EventArgs e)
	{
		if (Main.IsFormAlreadyOpen(typeof(Descompresor)) == null)
		{
			new Descompresor().Show();
		}
	}

	private void chkUnZip_CheckedChanged(object sender, EventArgs e)
	{
		comboPrioridad.Enabled = chkUnZip.Checked;
	}

	private string MsgUltConfig()
	{
		return Language.GetText("Save and use last conf explanation");
	}

	private void linkUltConfig_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(linkUltConfig, MsgUltConfig());
	}

	private void linkUltConfig_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(linkUltConfig);
		}
	}

	private void linkUltConfig_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgUltConfig(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void btnExaminarTemplate_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.CheckFileExists = true;
		openFileDialog.DefaultExt = "xml";
		openFileDialog.Filter = Language.GetText("Templates") + " (*.xml)|*.xml";
		openFileDialog.Multiselect = false;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			txtServidorWebTemplate.Text = openFileDialog.FileName;
		}
		openFileDialog.Dispose();
	}

	private void txtServidorWebTemplate_DragDrop(object sender, DragEventArgs e)
	{
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
		foreach (string text in array)
		{
			if (text.ToUpper().EndsWith(".XML"))
			{
				txtServidorWebTemplate.Text = text;
			}
		}
	}

	private void txtServidorWebTemplate_DragEnter(object sender, DragEventArgs e)
	{
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			return;
		}
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			if (array[i].ToUpper().EndsWith(".XML"))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
	}

	private void HelpButtonPressed()
	{
		MyProject.Forms.Main.FAQ_Click(null, null);
	}

	private void linkDownloadVLC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("http://www.videolan.org/vlc/");
	}

	private void btnExaminarVLCPath_Click(object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
		folderBrowserDialog.Description = Language.GetText("Select directory");
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			txtVLCPath.Text = folderBrowserDialog.SelectedPath;
		}
		folderBrowserDialog.Dispose();
	}

	private void chkReintentarError_CheckedChanged(object sender, EventArgs e)
	{
		txtPeriodoReintento.Enabled = chkReintentarError.Checked;
	}
}
