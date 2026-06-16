using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

[DesignerGenerated]
public class AddLinks : Form
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExaminar")]
	private Button _btnExaminar;

	[CompilerGenerated]
	[AccessedThroughProperty("btnAgregar")]
	private Button _btnAgregar;

	[CompilerGenerated]
	[AccessedThroughProperty("chkUnZip")]
	private CheckBox _chkUnZip;

	[CompilerGenerated]
	[AccessedThroughProperty("btnWatchOnline")]
	private Button _btnWatchOnline;

	[CompilerGenerated]
	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[CompilerGenerated]
	[AccessedThroughProperty("LinkLabel2")]
	private LinkLabel _LinkLabel2;

	[CompilerGenerated]
	[AccessedThroughProperty("linkStegano")]
	private LinkLabel _linkStegano;

	public Main Main;

	public Configuracion Config;

	public string HiddenLinks;

	private ToolTip t;

	public bool OpenSteganoLoadOnExit;

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OpcionesPaquete")]
	internal virtual GroupBox OpcionesPaquete
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

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtNombre")]
	internal virtual TextBox txtNombre
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtRuta")]
	internal virtual TextBox txtRuta
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("chkCrearDirectorio")]
	internal virtual CheckBox chkCrearDirectorio
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

	internal virtual Button btnAgregar
	{
		[CompilerGenerated]
		get
		{
			return _btnAgregar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnAgregar_Click;
			Button button = _btnAgregar;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnAgregar = value;
			button = _btnAgregar;
			if (button != null)
			{
				button.Click += value2;
			}
		}
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

	internal virtual Button btnWatchOnline
	{
		[CompilerGenerated]
		get
		{
			return _btnWatchOnline;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnWatchOnline_Click;
			Button button = _btnWatchOnline;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnWatchOnline = value;
			button = _btnWatchOnline;
			if (button != null)
			{
				button.Click += value2;
			}
		}
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

	[field: AccessedThroughProperty("chkStartDownload")]
	internal virtual CheckBox chkStartDownload
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel LinkLabel2
	{
		[CompilerGenerated]
		get
		{
			return _LinkLabel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LinkLabel2_MouseHover;
			EventHandler value3 = LinkLabel2_MouseLeave;
			EventHandler value4 = LinkLabel2_Click;
			LinkLabel linkLabel = _LinkLabel2;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_LinkLabel2 = value;
			linkLabel = _LinkLabel2;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	[field: AccessedThroughProperty("lblPassword")]
	internal virtual Label lblPassword
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

	[field: AccessedThroughProperty("txtLinks")]
	internal virtual RichTextBox txtLinks
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel linkStegano
	{
		[CompilerGenerated]
		get
		{
			return _linkStegano;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = linkStegano_LinkClicked;
			LinkLabel linkLabel = _linkStegano;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_linkStegano = value;
			linkLabel = _linkStegano;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	public AddLinks()
	{
		base.Load += AddLinks_Load;
		base.Shown += AddLinks_Shown;
		HiddenLinks = string.Empty;
		OpenSteganoLoadOnExit = false;
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
		this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
		this.OpcionesPaquete = new System.Windows.Forms.GroupBox();
		this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
		this.chkStartDownload = new System.Windows.Forms.CheckBox();
		this.lblPassword = new System.Windows.Forms.Label();
		this.chkUnZip = new System.Windows.Forms.CheckBox();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.chkCrearDirectorio = new System.Windows.Forms.CheckBox();
		this.btnExaminar = new System.Windows.Forms.Button();
		this.txtRuta = new System.Windows.Forms.TextBox();
		this.txtNombre = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.btnAgregar = new System.Windows.Forms.Button();
		this.btnWatchOnline = new System.Windows.Forms.Button();
		this.txtLinks = new System.Windows.Forms.RichTextBox();
		this.linkStegano = new System.Windows.Forms.LinkLabel();
		this.OpcionesPaquete.SuspendLayout();
		base.SuspendLayout();
		this.FlowLayoutPanel1.AutoSize = true;
		this.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
		this.FlowLayoutPanel1.Location = new System.Drawing.Point(12, 186);
		this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		this.FlowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
		this.FlowLayoutPanel1.TabIndex = 1;
		this.OpcionesPaquete.Controls.Add(this.LinkLabel2);
		this.OpcionesPaquete.Controls.Add(this.chkStartDownload);
		this.OpcionesPaquete.Controls.Add(this.lblPassword);
		this.OpcionesPaquete.Controls.Add(this.chkUnZip);
		this.OpcionesPaquete.Controls.Add(this.txtPassword);
		this.OpcionesPaquete.Controls.Add(this.chkCrearDirectorio);
		this.OpcionesPaquete.Controls.Add(this.btnExaminar);
		this.OpcionesPaquete.Controls.Add(this.txtRuta);
		this.OpcionesPaquete.Controls.Add(this.txtNombre);
		this.OpcionesPaquete.Controls.Add(this.Label2);
		this.OpcionesPaquete.Controls.Add(this.Label1);
		this.OpcionesPaquete.Location = new System.Drawing.Point(12, 215);
		this.OpcionesPaquete.Name = "OpcionesPaquete";
		this.OpcionesPaquete.Size = new System.Drawing.Size(649, 111);
		this.OpcionesPaquete.TabIndex = 4;
		this.OpcionesPaquete.TabStop = false;
		this.OpcionesPaquete.Text = "Opciones";
		this.LinkLabel2.AutoSize = true;
		this.LinkLabel2.Location = new System.Drawing.Point(506, 86);
		this.LinkLabel2.MinimumSize = new System.Drawing.Size(20, 0);
		this.LinkLabel2.Name = "LinkLabel2";
		this.LinkLabel2.Size = new System.Drawing.Size(20, 13);
		this.LinkLabel2.TabIndex = 32;
		this.LinkLabel2.TabStop = true;
		this.LinkLabel2.Text = "[?]";
		this.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkStartDownload.AutoSize = true;
		this.chkStartDownload.Location = new System.Drawing.Point(59, 85);
		this.chkStartDownload.MinimumSize = new System.Drawing.Size(97, 0);
		this.chkStartDownload.Name = "chkStartDownload";
		this.chkStartDownload.Size = new System.Drawing.Size(101, 17);
		this.chkStartDownload.TabIndex = 7;
		this.chkStartDownload.Text = "Iniciar descarga";
		this.chkStartDownload.UseVisualStyleBackColor = true;
		this.lblPassword.AutoSize = true;
		this.lblPassword.Location = new System.Drawing.Point(435, 86);
		this.lblPassword.MinimumSize = new System.Drawing.Size(75, 0);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new System.Drawing.Size(75, 13);
		this.lblPassword.TabIndex = 31;
		this.lblPassword.Text = "Password";
		this.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkUnZip.AutoSize = true;
		this.chkUnZip.Location = new System.Drawing.Point(304, 85);
		this.chkUnZip.Name = "chkUnZip";
		this.chkUnZip.Size = new System.Drawing.Size(131, 17);
		this.chkUnZip.TabIndex = 2;
		this.chkUnZip.Text = "Extracción automática";
		this.chkUnZip.UseVisualStyleBackColor = true;
		this.txtPassword.Location = new System.Drawing.Point(532, 83);
		this.txtPassword.MaxLength = 6;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size(102, 20);
		this.txtPassword.TabIndex = 30;
		this.txtPassword.UseSystemPasswordChar = true;
		this.chkCrearDirectorio.AutoSize = true;
		this.chkCrearDirectorio.Location = new System.Drawing.Point(178, 85);
		this.chkCrearDirectorio.MinimumSize = new System.Drawing.Size(97, 0);
		this.chkCrearDirectorio.Name = "chkCrearDirectorio";
		this.chkCrearDirectorio.Size = new System.Drawing.Size(97, 17);
		this.chkCrearDirectorio.TabIndex = 3;
		this.chkCrearDirectorio.Text = "Crear directorio";
		this.chkCrearDirectorio.UseVisualStyleBackColor = true;
		this.btnExaminar.Location = new System.Drawing.Point(559, 51);
		this.btnExaminar.Name = "btnExaminar";
		this.btnExaminar.Size = new System.Drawing.Size(75, 23);
		this.btnExaminar.TabIndex = 6;
		this.btnExaminar.Text = "Examinar";
		this.btnExaminar.UseVisualStyleBackColor = true;
		this.txtRuta.Location = new System.Drawing.Point(59, 53);
		this.txtRuta.Name = "txtRuta";
		this.txtRuta.Size = new System.Drawing.Size(494, 20);
		this.txtRuta.TabIndex = 5;
		this.txtNombre.Location = new System.Drawing.Point(59, 24);
		this.txtNombre.Name = "txtNombre";
		this.txtNombre.Size = new System.Drawing.Size(575, 20);
		this.txtNombre.TabIndex = 1;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(6, 27);
		this.Label2.MinimumSize = new System.Drawing.Size(47, 0);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(47, 13);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Nombre:";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(6, 56);
		this.Label1.MinimumSize = new System.Drawing.Size(47, 0);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(47, 13);
		this.Label1.TabIndex = 4;
		this.Label1.Text = "Ruta:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Location = new System.Drawing.Point(310, 191);
		this.LinkLabel1.Name = "LinkLabel1";
		this.LinkLabel1.Size = new System.Drawing.Size(19, 13);
		this.LinkLabel1.TabIndex = 11;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "[?]";
		this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btnAgregar.Location = new System.Drawing.Point(12, 186);
		this.btnAgregar.Name = "btnAgregar";
		this.btnAgregar.Size = new System.Drawing.Size(133, 23);
		this.btnAgregar.TabIndex = 1;
		this.btnAgregar.Text = "Agregar links";
		this.btnAgregar.UseVisualStyleBackColor = true;
		this.btnWatchOnline.Location = new System.Drawing.Point(171, 186);
		this.btnWatchOnline.Name = "btnWatchOnline";
		this.btnWatchOnline.Size = new System.Drawing.Size(133, 23);
		this.btnWatchOnline.TabIndex = 5;
		this.btnWatchOnline.Text = "Ver Online";
		this.btnWatchOnline.UseVisualStyleBackColor = true;
		this.txtLinks.Location = new System.Drawing.Point(12, 12);
		this.txtLinks.Name = "txtLinks";
		this.txtLinks.Size = new System.Drawing.Size(649, 168);
		this.txtLinks.TabIndex = 12;
		this.txtLinks.Text = "";
		this.linkStegano.AutoSize = true;
		this.linkStegano.Location = new System.Drawing.Point(411, 191);
		this.linkStegano.MinimumSize = new System.Drawing.Size(250, 0);
		this.linkStegano.Name = "linkStegano";
		this.linkStegano.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.linkStegano.Size = new System.Drawing.Size(250, 13);
		this.linkStegano.TabIndex = 13;
		this.linkStegano.TabStop = true;
		this.linkStegano.Text = "Recuperar enlaces de una imagen";
		this.linkStegano.TextAlign = System.Drawing.ContentAlignment.TopRight;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(675, 338);
		base.Controls.Add(this.linkStegano);
		base.Controls.Add(this.txtLinks);
		base.Controls.Add(this.LinkLabel1);
		base.Controls.Add(this.btnWatchOnline);
		base.Controls.Add(this.btnAgregar);
		base.Controls.Add(this.OpcionesPaquete);
		base.Controls.Add(this.FlowLayoutPanel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		this.MaximumSize = new System.Drawing.Size(1500, 1500);
		base.MinimizeBox = false;
		base.Name = "AddLinks";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "AddLinks";
		this.OpcionesPaquete.ResumeLayout(false);
		this.OpcionesPaquete.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void AddLinks_Load(object sender, EventArgs e)
	{
		Translate();
		txtRuta.Text = Config.RutaDefecto;
		chkCrearDirectorio.Checked = Config.CrearDirectorioPaquete;
		chkUnZip.Checked = Config.ExtraerAutomaticamente;
		chkStartDownload.Checked = true;
		OpcionesPaquete.Visible = true;
		if (Config.MantenerUltimaConfiguracion & UltimaConfiguracionUsada.ExisteUltimaConfiguracion)
		{
			chkCrearDirectorio.Checked = UltimaConfiguracionUsada.CrearDirectorioPaquete;
			chkUnZip.Checked = UltimaConfiguracionUsada.ExtraerAutomaticamente;
			txtRuta.Text = UltimaConfiguracionUsada.RutaDescarga;
			chkStartDownload.Checked = UltimaConfiguracionUsada.IniciarDescarga;
		}
		chkUnZip_CheckedChanged(null, null);
		Screen screen = Screen.FromPoint(base.Location);
		base.Location = checked(new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0)));
	}

	public bool AgregarEnlaces(string texto, bool limpiarContenidoAnterior, bool ExtraerURLs, bool EsconderLinks)
	{
		if (!limpiarContenidoAnterior)
		{
			texto = txtLinks.Text + "\r\n" + texto;
		}
		List<string> list = URLExtractor.ExtraerURLs(texto);
		if (list != null && list.Count > 0)
		{
			if (ExtraerURLs)
			{
				string text = "";
				foreach (string item in list)
				{
					if (text.Length > 0)
					{
						text += "\r\n";
					}
					text += item;
				}
				texto = text;
			}
			if (EsconderLinks)
			{
				List<ServerEncoderLinkHelper.MegaLink> list2 = new List<ServerEncoderLinkHelper.MegaLink>();
				list = URLExtractor.ExtraerURLs(texto);
				if (list != null && list.Count > 0)
				{
					foreach (string item2 in list)
					{
						texto = texto.Replace(item2, "** LINK NOT VISIBLE **");
						ServerEncoderLinkHelper.MegaLink megaLink = new ServerEncoderLinkHelper.MegaLink();
						megaLink.FileID = URLExtractor.ExtraerFileID(item2);
						megaLink.FileKey = URLExtractor.ExtraerFileKey(item2);
						megaLink.MegaFolder = URLExtractor.IsMegaFolder(item2);
						list2.Add(megaLink);
					}
				}
				ref string hiddenLinks = ref HiddenLinks;
				hiddenLinks = hiddenLinks + "mega://elc?" + ServerEncoderLinkHelper.ServerEncode("HIDDEN", list2, ref Config);
			}
			txtLinks.Text = texto;
			return true;
		}
		return false;
	}

	private void Translate()
	{
		Text = Language.GetText("Add links");
		OpcionesPaquete.Text = Language.GetText("Options");
		chkUnZip.Text = Language.GetText("Automatic extraction");
		chkCrearDirectorio.Text = Language.GetText("Create directory");
		btnExaminar.Text = Language.GetText("Browse");
		Label2.Text = Language.GetText("Name") + ":";
		Label1.Text = Language.GetText("Path") + ":";
		btnAgregar.Text = Language.GetText("Add links");
		btnWatchOnline.Text = Language.GetText("Watch Online");
		chkStartDownload.Text = Language.GetText("Start download");
		lblPassword.Text = Language.GetText("Password") + ":";
		linkStegano.Text = Language.GetText("Retrieve links from an image");
	}

	private void AddLinks_Shown(object sender, EventArgs e)
	{
		PonerFoco();
		if (!string.IsNullOrEmpty(txtLinks.Text))
		{
			btnAgregar.Focus();
		}
		else
		{
			txtLinks.Focus();
		}
	}

	public void PonerFoco()
	{
		base.TopMost = true;
		base.TopMost = false;
		base.TopMost = true;
		Activate();
	}

	private void ToggleOpciones_Click(object sender, EventArgs e)
	{
		OpcionesPaquete.Visible = !OpcionesPaquete.Visible;
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

	private List<string> ExtraerURLs()
	{
		return URLExtractor.ExtraerURLs(txtLinks.Text + "\r\n" + HiddenLinks);
	}

	private void btnAgregar_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list = ExtraerURLs();
			if (list.Count == 0)
			{
				throw new ApplicationException(Language.GetText("Links not valid"));
			}
			if (!Directory.Exists(txtRuta.Text))
			{
				try
				{
					Directory.CreateDirectory(txtRuta.Text);
					if (!Directory.Exists(txtRuta.Text))
					{
						throw new ApplicationException("Invalid dir");
					}
					return;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					throw new ApplicationException(Language.GetText("Invalid directory"));
				}
			}
			btnAgregar.Text = Language.GetText("Loading...");
			btnAgregar.Enabled = false;
			UltimaConfiguracionUsada.ExisteUltimaConfiguracion = true;
			UltimaConfiguracionUsada.CrearDirectorioPaquete = chkCrearDirectorio.Checked;
			UltimaConfiguracionUsada.ExtraerAutomaticamente = chkUnZip.Checked;
			UltimaConfiguracionUsada.RutaDescarga = txtRuta.Text;
			UltimaConfiguracionUsada.IniciarDescarga = chkStartDownload.Checked;
			List<URLProcessor.FileURL> list2 = URLProcessor.ProcessURLs(list, ref Config);
			if (list2.Count == 0)
			{
				throw new ApplicationException(Language.GetText("Links not valid"));
			}
			Paquete paquete = new Paquete();
			Paquete paquete2 = paquete;
			paquete2.Nombre = txtNombre.Text;
			paquete2.RutaLocal = txtRuta.Text;
			paquete2.CrearSubdirectorio = chkCrearDirectorio.Checked;
			paquete2.PendienteNombrePaquete = string.IsNullOrEmpty(txtNombre.Text);
			if (paquete2.CrearSubdirectorio & !string.IsNullOrEmpty(txtNombre.Text))
			{
				paquete2.RutaLocal = Path.Combine(paquete2.RutaLocal, txtNombre.Text);
				Directory.CreateDirectory(paquete2.RutaLocal);
			}
			Log.WriteWarning("Adding package in " + paquete2.RutaLocal);
			paquete2.SetDescargaExtraccionAutomatica(txtPassword.Text, chkUnZip.Checked);
			foreach (URLProcessor.FileURL item in list2)
			{
				string text = Path.Combine(paquete.RutaLocal, item.Path);
				Directory.CreateDirectory(text);
				string text2 = item.URL;
				bool flag = true;
				if (!string.IsNullOrEmpty(text2) && text2.Contains("{HIDDEN}"))
				{
					flag = false;
					text2 = text2.Replace("{HIDDEN}", "");
				}
				Fichero fichero = new Fichero(text2);
				Fichero fichero2 = fichero;
				fichero2.LinkVisible = flag;
				fichero2.RutaLocal = text;
				fichero2.RutaRelativa = item.Path;
				fichero2.NombreFichero = (flag ? text2 : "** LINK NOT VISIBLE **");
				fichero2.FileID = Fichero.ExtraerFileID(text2);
				fichero2.FileKey = Fichero.ExtraerFileKey(text2);
				fichero2.SetDescargaExtraccionAutomatica(txtPassword.Text, chkUnZip.Checked);
				Log.WriteWarning("Adding file to the new package: " + fichero2.FileID);
				fichero2 = null;
				paquete2.AgregarFichero(fichero);
			}
			paquete2 = null;
			Main.AgregarPaquete(paquete, AgregadoDesdeServidorWeb: false);
			if (chkStartDownload.Checked)
			{
				Main.StartDownload();
			}
			Close();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteError("Error while adding the link: " + ex4.ToString());
			MessageBox.Show(ex4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			btnAgregar.Enabled = true;
			btnAgregar.Text = Language.GetText("Add links");
			ProjectData.ClearProjectError();
		}
	}

	private void btnWatchOnline_Click(object sender, EventArgs e)
	{
		if (!Config.ServidorStreamingActivo)
		{
			MessageBox.Show(Language.GetText("Streaming server not activated"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		if (string.IsNullOrEmpty(Config.VLCPath))
		{
			MessageBox.Show(Language.GetText("Missing VLC Path"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		List<string> list = ExtraerURLs();
		if (list.Count == 0)
		{
			MessageBox.Show(Language.GetText("Links not valid"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		List<URLProcessor.FileURL> list2 = URLProcessor.ProcessURLs(list, ref Config);
		if (list2.Count == 0)
		{
			MessageBox.Show(Language.GetText("Links not valid"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		string text = StreamingHelper.CreateStreamingLink(list2[0].URL, Config.ServidorStreamingPuerto, ref Config);
		if (string.IsNullOrEmpty(text))
		{
			MessageBox.Show(Language.GetText("Links not valid"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		StreamingHelper.WatchOnline(Config.VLCPath, text);
		Close();
	}

	private string MsgVerOnline()
	{
		return Language.GetText("Watch Online Note");
	}

	private string MsgPasswordZip()
	{
		return Language.GetText("MsgPasswordZip");
	}

	private void LinkLabel1_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(LinkLabel1, MsgVerOnline());
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
		MessageBox.Show(MsgVerOnline(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void chkUnZip_CheckedChanged(object sender, EventArgs e)
	{
		txtPassword.Enabled = chkUnZip.Checked;
		lblPassword.Enabled = chkUnZip.Checked;
	}

	private void LinkLabel2_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(LinkLabel2, MsgPasswordZip());
	}

	private void LinkLabel2_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(LinkLabel2);
		}
	}

	private void LinkLabel2_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgPasswordZip(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void linkStegano_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		OpenSteganoLoadOnExit = true;
		Close();
	}
}
