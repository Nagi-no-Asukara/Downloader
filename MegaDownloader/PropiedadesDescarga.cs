using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

[DesignerGenerated]
public class PropiedadesDescarga : Form
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("chkUnZip")]
	private CheckBox _chkUnZip;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExaminar")]
	private Button _btnExaminar;

	[CompilerGenerated]
	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[CompilerGenerated]
	[AccessedThroughProperty("btnGuardar")]
	private Button _btnGuardar;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCancelar")]
	private Button _btnCancelar;

	[CompilerGenerated]
	[AccessedThroughProperty("chkLimitarVelocidad")]
	private CheckBox _chkLimitarVelocidad;

	[CompilerGenerated]
	[AccessedThroughProperty("LinkLabel2")]
	private LinkLabel _LinkLabel2;

	private IDescarga _Descarga;

	private ToolTip t;

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

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
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

	[field: AccessedThroughProperty("txtMD5")]
	internal virtual TextBox txtMD5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtTamano")]
	internal virtual TextBox txtTamano
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

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
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

	internal virtual Button btnCancelar
	{
		[CompilerGenerated]
		get
		{
			return _btnCancelar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnCancelar_Click;
			Button button = _btnCancelar;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnCancelar = value;
			button = _btnCancelar;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("txtUrl")]
	internal virtual TextBox txtUrl
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

	[field: AccessedThroughProperty("txtLimiteVelocidad")]
	internal virtual TextBox txtLimiteVelocidad
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

	[field: AccessedThroughProperty("Label15")]
	internal virtual Label Label15
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

	public IDescarga Descarga
	{
		set
		{
			_Descarga = value;
		}
	}

	public PropiedadesDescarga()
	{
		base.Load += PropiedadesDescarga_Load;
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
		this.chkUnZip = new System.Windows.Forms.CheckBox();
		this.btnExaminar = new System.Windows.Forms.Button();
		this.txtRuta = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.txtUrl = new System.Windows.Forms.TextBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.txtMD5 = new System.Windows.Forms.TextBox();
		this.txtTamano = new System.Windows.Forms.TextBox();
		this.txtNombre = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
		this.lblPassword = new System.Windows.Forms.Label();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.Label15 = new System.Windows.Forms.Label();
		this.txtLimiteVelocidad = new System.Windows.Forms.TextBox();
		this.chkLimitarVelocidad = new System.Windows.Forms.CheckBox();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.btnGuardar = new System.Windows.Forms.Button();
		this.btnCancelar = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		base.SuspendLayout();
		this.chkUnZip.AutoSize = true;
		this.chkUnZip.Location = new System.Drawing.Point(13, 91);
		this.chkUnZip.Name = "chkUnZip";
		this.chkUnZip.Size = new System.Drawing.Size(131, 17);
		this.chkUnZip.TabIndex = 5;
		this.chkUnZip.Text = "Extracción automática";
		this.chkUnZip.UseVisualStyleBackColor = true;
		this.btnExaminar.Location = new System.Drawing.Point(335, 19);
		this.btnExaminar.Name = "btnExaminar";
		this.btnExaminar.Size = new System.Drawing.Size(84, 23);
		this.btnExaminar.TabIndex = 1;
		this.btnExaminar.Text = "Examinar";
		this.btnExaminar.UseVisualStyleBackColor = true;
		this.txtRuta.Location = new System.Drawing.Point(49, 22);
		this.txtRuta.Name = "txtRuta";
		this.txtRuta.Size = new System.Drawing.Size(280, 20);
		this.txtRuta.TabIndex = 0;
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(10, 25);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(33, 13);
		this.Label1.TabIndex = 7;
		this.Label1.Text = "Ruta:";
		this.GroupBox1.Controls.Add(this.txtUrl);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.txtMD5);
		this.GroupBox1.Controls.Add(this.txtTamano);
		this.GroupBox1.Controls.Add(this.txtNombre);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Location = new System.Drawing.Point(12, 11);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(425, 138);
		this.GroupBox1.TabIndex = 11;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Datos de la descarga";
		this.txtUrl.Location = new System.Drawing.Point(59, 50);
		this.txtUrl.Name = "txtUrl";
		this.txtUrl.ReadOnly = true;
		this.txtUrl.Size = new System.Drawing.Size(351, 20);
		this.txtUrl.TabIndex = 15;
		this.Label5.AutoSize = true;
		this.Label5.Location = new System.Drawing.Point(20, 53);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(32, 13);
		this.Label5.TabIndex = 14;
		this.Label5.Text = "URL:";
		this.txtMD5.Location = new System.Drawing.Point(59, 74);
		this.txtMD5.Name = "txtMD5";
		this.txtMD5.ReadOnly = true;
		this.txtMD5.Size = new System.Drawing.Size(351, 20);
		this.txtMD5.TabIndex = 13;
		this.txtTamano.Location = new System.Drawing.Point(59, 102);
		this.txtTamano.Name = "txtTamano";
		this.txtTamano.ReadOnly = true;
		this.txtTamano.Size = new System.Drawing.Size(351, 20);
		this.txtTamano.TabIndex = 12;
		this.txtNombre.Location = new System.Drawing.Point(59, 24);
		this.txtNombre.Name = "txtNombre";
		this.txtNombre.ReadOnly = true;
		this.txtNombre.Size = new System.Drawing.Size(351, 20);
		this.txtNombre.TabIndex = 11;
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(20, 77);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(33, 13);
		this.Label4.TabIndex = 2;
		this.Label4.Text = "MD5:";
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(4, 105);
		this.Label3.MinimumSize = new System.Drawing.Size(49, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(49, 13);
		this.Label3.TabIndex = 1;
		this.Label3.Text = "Tamaño:";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(6, 27);
		this.Label2.MinimumSize = new System.Drawing.Size(49, 0);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(49, 13);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Nombre:";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.GroupBox2.Controls.Add(this.LinkLabel2);
		this.GroupBox2.Controls.Add(this.lblPassword);
		this.GroupBox2.Controls.Add(this.txtPassword);
		this.GroupBox2.Controls.Add(this.Label15);
		this.GroupBox2.Controls.Add(this.txtLimiteVelocidad);
		this.GroupBox2.Controls.Add(this.chkLimitarVelocidad);
		this.GroupBox2.Controls.Add(this.LinkLabel1);
		this.GroupBox2.Controls.Add(this.txtRuta);
		this.GroupBox2.Controls.Add(this.Label1);
		this.GroupBox2.Controls.Add(this.chkUnZip);
		this.GroupBox2.Controls.Add(this.btnExaminar);
		this.GroupBox2.Location = new System.Drawing.Point(12, 155);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(425, 114);
		this.GroupBox2.TabIndex = 12;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Opciones";
		this.LinkLabel2.AutoSize = true;
		this.LinkLabel2.Location = new System.Drawing.Point(245, 92);
		this.LinkLabel2.MinimumSize = new System.Drawing.Size(20, 0);
		this.LinkLabel2.Name = "LinkLabel2";
		this.LinkLabel2.Size = new System.Drawing.Size(20, 13);
		this.LinkLabel2.TabIndex = 29;
		this.LinkLabel2.TabStop = true;
		this.LinkLabel2.Text = "[?]";
		this.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.lblPassword.AutoSize = true;
		this.lblPassword.Location = new System.Drawing.Point(173, 92);
		this.lblPassword.MinimumSize = new System.Drawing.Size(75, 0);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new System.Drawing.Size(75, 13);
		this.lblPassword.TabIndex = 28;
		this.lblPassword.Text = "Password";
		this.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtPassword.Location = new System.Drawing.Point(266, 88);
		this.txtPassword.MaxLength = 6;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size(153, 20);
		this.txtPassword.TabIndex = 27;
		this.txtPassword.UseSystemPasswordChar = true;
		this.Label15.AutoSize = true;
		this.Label15.Location = new System.Drawing.Point(205, 62);
		this.Label15.Name = "Label15";
		this.Label15.Size = new System.Drawing.Size(31, 13);
		this.Label15.TabIndex = 26;
		this.Label15.Text = "KB/s";
		this.txtLimiteVelocidad.Location = new System.Drawing.Point(144, 58);
		this.txtLimiteVelocidad.MaxLength = 6;
		this.txtLimiteVelocidad.Name = "txtLimiteVelocidad";
		this.txtLimiteVelocidad.Size = new System.Drawing.Size(55, 20);
		this.txtLimiteVelocidad.TabIndex = 3;
		this.chkLimitarVelocidad.AutoSize = true;
		this.chkLimitarVelocidad.Location = new System.Drawing.Point(13, 61);
		this.chkLimitarVelocidad.MinimumSize = new System.Drawing.Size(120, 0);
		this.chkLimitarVelocidad.Name = "chkLimitarVelocidad";
		this.chkLimitarVelocidad.Size = new System.Drawing.Size(125, 17);
		this.chkLimitarVelocidad.TabIndex = 2;
		this.chkLimitarVelocidad.Text = "Limitar la velocidad a";
		this.chkLimitarVelocidad.UseVisualStyleBackColor = true;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Location = new System.Drawing.Point(289, 62);
		this.LinkLabel1.MinimumSize = new System.Drawing.Size(120, 0);
		this.LinkLabel1.Name = "LinkLabel1";
		this.LinkLabel1.Size = new System.Drawing.Size(121, 13);
		this.LinkLabel1.TabIndex = 4;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Nota sobre las opciones";
		this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.btnGuardar.Location = new System.Drawing.Point(12, 275);
		this.btnGuardar.Name = "btnGuardar";
		this.btnGuardar.Size = new System.Drawing.Size(75, 23);
		this.btnGuardar.TabIndex = 0;
		this.btnGuardar.Text = "Guardar";
		this.btnGuardar.UseVisualStyleBackColor = true;
		this.btnCancelar.Location = new System.Drawing.Point(362, 275);
		this.btnCancelar.Name = "btnCancelar";
		this.btnCancelar.Size = new System.Drawing.Size(75, 23);
		this.btnCancelar.TabIndex = 1;
		this.btnCancelar.Text = "Cancelar";
		this.btnCancelar.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(446, 310);
		base.Controls.Add(this.btnCancelar);
		base.Controls.Add(this.btnGuardar);
		base.Controls.Add(this.GroupBox2);
		base.Controls.Add(this.GroupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.Name = "PropiedadesDescarga";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Propiedades";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		base.ResumeLayout(false);
	}

	private void PropiedadesDescarga_Load(object sender, EventArgs e)
	{
		Translate();
		txtNombre.Text = _Descarga.DescargaNombre();
		if (_Descarga is Fichero)
		{
			GroupBox1.Text = Language.GetText("File properties");
			Fichero fichero = (Fichero)_Descarga;
			txtMD5.Text = fichero.MD5;
			txtRuta.Text = fichero.RutaLocal;
			txtUrl.Text = (fichero.LinkVisible ? fichero.URL : "** LINK NOT VISIBLE **");
			if (string.IsNullOrEmpty(txtMD5.Text))
			{
				txtMD5.Text = Language.GetText("Not available");
			}
			if (fichero.DescargaComenzada)
			{
				txtRuta.Enabled = false;
				btnExaminar.Enabled = false;
			}
			chkLimitarVelocidad.Checked = fichero.LimiteVelocidad > 0;
			txtLimiteVelocidad.Enabled = chkLimitarVelocidad.Checked;
			if (chkLimitarVelocidad.Checked)
			{
				txtLimiteVelocidad.Text = ((double)fichero.LimiteVelocidad / 1024.0).ToString();
			}
		}
		else
		{
			GroupBox1.Text = Language.GetText("Package properties");
			Paquete paquete = (Paquete)_Descarga;
			txtRuta.Text = paquete.RutaLocal;
			txtMD5.Text = Language.GetText("Not applied");
			txtUrl.Text = Language.GetText("Not applied");
			txtLimiteVelocidad.Enabled = false;
		}
		txtTamano.Text = Language.GetText("Downloaded") + ": " + PintarTamano(decimal.Divide(decimal.Multiply(_Descarga.DescargaPorcentaje(), new decimal(_Descarga.DescargaTamanoBytes())), 100m)) + " - " + Language.GetText("Total") + ": " + PintarTamano(new decimal(_Descarga.DescargaTamanoBytes()));
		chkUnZip.Checked = _Descarga.DescargaExtraccionAutomatica();
		txtPassword.Text = _Descarga.DescargaExtraccionPassword();
		chkUnZip_CheckedChanged(null, null);
	}

	private void Translate()
	{
		chkUnZip.Text = Language.GetText("Automatic extraction");
		btnExaminar.Text = Language.GetText("Browse");
		Label1.Text = Language.GetText("Path") + ":";
		GroupBox1.Text = Language.GetText("Download properties");
		Label5.Text = Language.GetText("URL") + ":";
		Label4.Text = Language.GetText("MD5") + ":";
		Label3.Text = Language.GetText("Size") + ":";
		Label2.Text = Language.GetText("Name") + ":";
		GroupBox2.Text = Language.GetText("Options");
		chkLimitarVelocidad.Text = Language.GetText("Limit speed to");
		LinkLabel1.Text = Language.GetText("Note about the options");
		btnGuardar.Text = Language.GetText("Save");
		btnCancelar.Text = Language.GetText("Cancel");
		Text = Language.GetText("Properties");
		lblPassword.Text = Language.GetText("Password") + ":";
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

	private string MsgRutaFic()
	{
		return Language.GetText("Can change file path if not downloaded");
	}

	private string MsgRutaPaq()
	{
		return Language.GetText("Message change package path");
	}

	private string MsgPasswordZip()
	{
		return Language.GetText("MsgPasswordZip");
	}

	private void LinkLabel1_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(LinkLabel1, (_Descarga is Fichero) ? MsgRutaFic() : MsgRutaPaq());
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
		MessageBox.Show((_Descarga is Fichero) ? MsgRutaFic() : MsgRutaPaq(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

	private void btnCancelar_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnGuardar_Click(object sender, EventArgs e)
	{
		int result = 0;
		int.TryParse(txtLimiteVelocidad.Text, out result);
		if (!chkLimitarVelocidad.Checked)
		{
			result = 0;
		}
		else if ((result <= 0) | string.IsNullOrEmpty(txtLimiteVelocidad.Text))
		{
			MessageBox.Show(Language.GetText("Invalid speed limit"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		result = checked(result * 1024);
		if (_Descarga is Fichero)
		{
			Fichero fichero = (Fichero)_Descarga;
			if ((Operators.CompareString(txtRuta.Text, fichero.RutaLocal, TextCompare: false) != 0) & !fichero.DescargaComenzada)
			{
				fichero.RutaLocal = txtRuta.Text;
			}
			fichero.SetDescargaExtraccionAutomatica(txtPassword.Text, chkUnZip.Checked);
			fichero.LimiteVelocidad = result;
			ThrottledStreamController.GetController().SetMaxSpeed(fichero.FileID, result);
		}
		else
		{
			Paquete paquete = (Paquete)_Descarga;
			foreach (Fichero listaFichero in paquete.ListaFicheros)
			{
				if ((Operators.CompareString(txtRuta.Text, listaFichero.RutaLocal, TextCompare: false) != 0) & !listaFichero.DescargaComenzada)
				{
					listaFichero.RutaLocal = txtRuta.Text;
				}
				if (paquete.DescargaExtraccionAutomatica() != chkUnZip.Checked)
				{
					listaFichero.SetDescargaExtraccionAutomatica(txtPassword.Text, chkUnZip.Checked);
				}
				listaFichero.LimiteVelocidad = result;
				ThrottledStreamController.GetController().SetMaxSpeed(listaFichero.FileID, result);
			}
			if (Operators.CompareString(txtRuta.Text, paquete.RutaLocal, TextCompare: false) != 0)
			{
				paquete.RutaLocal = txtRuta.Text;
			}
			if ((paquete.DescargaExtraccionAutomatica() != chkUnZip.Checked) | (Operators.CompareString(paquete.DescargaExtraccionPassword(), txtPassword.Text, TextCompare: false) != 0))
			{
				paquete.SetDescargaExtraccionAutomatica(txtPassword.Text, chkUnZip.Checked);
			}
		}
		Close();
	}

	private void chkLimitarVelocidad_CheckedChanged(object sender, EventArgs e)
	{
		txtLimiteVelocidad.Enabled = chkLimitarVelocidad.Checked;
	}

	private void chkUnZip_CheckedChanged(object sender, EventArgs e)
	{
		txtPassword.Enabled = chkUnZip.Checked;
		lblPassword.Enabled = chkUnZip.Checked;
	}
}
