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
public class Credits : Form
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("lblTitle")]
	private LinkLabel _lblTitle;

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button1_Click;
			Button button = _Button1;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button1 = value;
			button = _Button1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("lblAutor")]
	internal virtual Label lblAutor
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblEmail")]
	internal virtual Label lblEmail
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblGraciasA")]
	internal virtual Label lblGraciasA
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblListaColaboradores")]
	internal virtual Label lblListaColaboradores
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

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel lblTitle
	{
		[CompilerGenerated]
		get
		{
			return _lblTitle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = lblTitle_LinkClicked;
			LinkLabel linkLabel = _lblTitle;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_lblTitle = value;
			linkLabel = _lblTitle;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Credits()
	{
		base.Load += Credits_Load;
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
		this.Button1 = new System.Windows.Forms.Button();
		this.lblTitle = new System.Windows.Forms.LinkLabel();
		this.lblAutor = new System.Windows.Forms.Label();
		this.lblEmail = new System.Windows.Forms.Label();
		this.lblGraciasA = new System.Windows.Forms.Label();
		this.lblListaColaboradores = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.Label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		base.SuspendLayout();
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.Button1.Location = new System.Drawing.Point(314, 267);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 23);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Cerrar";
		this.Button1.UseVisualStyleBackColor = true;
		this.lblTitle.AutoSize = true;
		this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTitle.Location = new System.Drawing.Point(149, 25);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(190, 17);
		this.lblTitle.TabIndex = 1;
		this.lblTitle.TabStop = true;
		this.lblTitle.Text = "MegaDownloader BETA v";
		this.lblAutor.AutoSize = true;
		this.lblAutor.Location = new System.Drawing.Point(149, 74);
		this.lblAutor.Name = "lblAutor";
		this.lblAutor.Size = new System.Drawing.Size(173, 13);
		this.lblAutor.TabIndex = 2;
		this.lblAutor.Text = "Creado y diseñado por Andres_age";
		this.lblEmail.AutoSize = true;
		this.lblEmail.Location = new System.Drawing.Point(194, 96);
		this.lblEmail.Name = "lblEmail";
		this.lblEmail.Size = new System.Drawing.Size(118, 13);
		this.lblEmail.TabIndex = 3;
		this.lblEmail.Text = "andres.age@gmail.com";
		this.lblGraciasA.AutoSize = true;
		this.lblGraciasA.Location = new System.Drawing.Point(9, 197);
		this.lblGraciasA.Name = "lblGraciasA";
		this.lblGraciasA.Size = new System.Drawing.Size(55, 13);
		this.lblGraciasA.TabIndex = 4;
		this.lblGraciasA.Text = "Gracias a:";
		this.lblListaColaboradores.AutoSize = true;
		this.lblListaColaboradores.Location = new System.Drawing.Point(20, 219);
		this.lblListaColaboradores.Name = "lblListaColaboradores";
		this.lblListaColaboradores.Size = new System.Drawing.Size(62, 39);
		this.lblListaColaboradores.TabIndex = 5;
		this.lblListaColaboradores.Text = "* ------------\r\n* ----------------\r\n* ----------------\r\n";
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(12, 130);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(350, 13);
		this.Label1.TabIndex = 6;
		this.Label1.Text = "Gracias por usar esta aplicación no oficial de descarga de MEGA.CO.NZ";
		this.PictureBox1.Image = MegaDownloader.My.Resources.Resources.mega;
		this.PictureBox1.Location = new System.Drawing.Point(15, 25);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(128, 84);
		this.PictureBox1.TabIndex = 7;
		this.PictureBox1.TabStop = false;
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(12, 159);
		this.Label2.MaximumSize = new System.Drawing.Size(350, 0);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(325, 26);
		this.Label2.TabIndex = 8;
		this.Label2.Text = "MegaDownloader no está relacionado con Mega.co.nz - Todas las marcas y logos son propiedad de sus respectivos dueños.";
		base.AcceptButton = this.lblTitle;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		base.CancelButton = this.Button1;
		base.ClientSize = new System.Drawing.Size(401, 302);
		base.Controls.Add(this.Label2);
		base.Controls.Add(this.PictureBox1);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.lblListaColaboradores);
		base.Controls.Add(this.lblGraciasA);
		base.Controls.Add(this.lblEmail);
		base.Controls.Add(this.lblAutor);
		base.Controls.Add(this.lblTitle);
		base.Controls.Add(this.Button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Credits";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Información";
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Credits_Load(object sender, EventArgs e)
	{
		Translate();
	}

	private void Translate()
	{
		Text = Language.GetText("About");
		Button1.Text = Language.GetText("Close");
		lblTitle.Text = InternalConfiguration.ObtenerNombreApp() + InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_MEGADOWNLOADER");
		lblAutor.Text = Language.GetText("Created and designed by %NAME");
		if (!lblAutor.Text.Contains("%NAME"))
		{
			lblAutor.Text = "Created and designed by %NAME";
		}
		lblAutor.Text = lblAutor.Text.Replace("%NAME", "Andres Soliño [andres_age]");
		lblEmail.Text = "andres.age@gmail.com";
		lblGraciasA.Text = Language.GetText("Thanks to") + ":";
		Label label = lblListaColaboradores;
		label.Text = "";
		Label label2;
		(label2 = label).Text = label2.Text + "* " + Language.GetText("%NAME for helping with MEGA criptographic system").Replace("%NAME", "Bernardo Vadell") + "\r\n";
		(label2 = label).Text = label2.Text + "* " + Language.GetText("All users that have collaborated") + "\r\n";
		if (!string.IsNullOrEmpty(Language.GetText("Translator credits")))
		{
			(label2 = label).Text = label2.Text + "* " + Language.GetText("Translator credits");
		}
		label = null;
		Label1.Text = Language.GetText("Thanks for using this app");
		Label2.Text = Language.GetText("Legal text");
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void lblTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("CREDITS_LINK"));
	}
}
