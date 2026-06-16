using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

[DesignerGenerated]
public class PantallaMsg : Form
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("lklGenerarELC")]
	private LinkLabel _lklGenerarELC;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("chkCodificarEnlaces")]
	private CheckBox _chkCodificarEnlaces;

	public string TextoError;

	public bool MostrarCodificarEnlaces;

	internal virtual LinkLabel lklGenerarELC
	{
		[CompilerGenerated]
		get
		{
			return _lklGenerarELC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lklGenerarELC_Click;
			LinkLabel linkLabel = _lklGenerarELC;
			if (linkLabel != null)
			{
				linkLabel.Click -= value2;
			}
			_lklGenerarELC = value;
			linkLabel = _lklGenerarELC;
			if (linkLabel != null)
			{
				linkLabel.Click += value2;
			}
		}
	}

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

	[field: AccessedThroughProperty("txtDatos")]
	internal virtual RichTextBox txtDatos
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkCodificarEnlaces
	{
		[CompilerGenerated]
		get
		{
			return _chkCodificarEnlaces;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkCodificarEnlaces_CheckedChanged;
			CheckBox checkBox = _chkCodificarEnlaces;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkCodificarEnlaces = value;
			checkBox = _chkCodificarEnlaces;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	public PantallaMsg()
	{
		base.Load += VerError_Load;
		MostrarCodificarEnlaces = false;
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
		this.txtDatos = new System.Windows.Forms.RichTextBox();
		this.chkCodificarEnlaces = new System.Windows.Forms.CheckBox();
		this.lklGenerarELC = new System.Windows.Forms.LinkLabel();
		base.SuspendLayout();
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.Location = new System.Drawing.Point(638, 234);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 23);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Cerrar";
		this.Button1.UseVisualStyleBackColor = true;
		this.txtDatos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtDatos.Location = new System.Drawing.Point(12, 12);
		this.txtDatos.Name = "txtDatos";
		this.txtDatos.ReadOnly = true;
		this.txtDatos.Size = new System.Drawing.Size(701, 216);
		this.txtDatos.TabIndex = 1;
		this.txtDatos.Text = "";
		this.chkCodificarEnlaces.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.chkCodificarEnlaces.AutoSize = true;
		this.chkCodificarEnlaces.Location = new System.Drawing.Point(13, 239);
		this.chkCodificarEnlaces.Name = "chkCodificarEnlaces";
		this.chkCodificarEnlaces.Size = new System.Drawing.Size(107, 17);
		this.chkCodificarEnlaces.TabIndex = 2;
		this.chkCodificarEnlaces.Text = "Codificar enlaces";
		this.chkCodificarEnlaces.UseVisualStyleBackColor = true;
		this.lklGenerarELC.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lklGenerarELC.Location = new System.Drawing.Point(143, 240);
		this.lklGenerarELC.Name = "lklGenerarELC";
		this.lklGenerarELC.Size = new System.Drawing.Size(100, 23);
		this.lklGenerarELC.TabIndex = 3;
		this.lklGenerarELC.TabStop = true;
		this.lklGenerarELC.Text = "Generar ELC";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(725, 269);
		base.Controls.Add(this.lklGenerarELC);
		base.Controls.Add(this.chkCodificarEnlaces);
		base.Controls.Add(this.txtDatos);
		base.Controls.Add(this.Button1);
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.Name = "PantallaMsg";
		this.Text = "Información";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void VerError_Load(object sender, EventArgs e)
	{
		txtDatos.Multiline = true;
		txtDatos.Text = (TextoError ?? "").Replace("\r\n", Environment.NewLine);
		chkCodificarEnlaces.Visible = MostrarCodificarEnlaces;
		lklGenerarELC.Visible = MostrarCodificarEnlaces;
		Text = Language.GetText("Information");
		Button1.Text = Language.GetText("Close");
		chkCodificarEnlaces.Text = Language.GetText("Encode Url");
		lklGenerarELC.Text = Language.GetText("Generate ELC");
		checked
		{
			lklGenerarELC.Location = new Point(chkCodificarEnlaces.Location.X + chkCodificarEnlaces.Width, lklGenerarELC.Location.Y);
			Screen screen = Screen.FromPoint(base.Location);
			base.Location = new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0));
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void lklGenerarELC_Click(object sender, EventArgs e)
	{
		ELCForm eLCForm = new ELCForm();
		eLCForm.MegaURLs = TextoError;
		eLCForm.MainForm = (Main)base.Owner;
		eLCForm.Show();
		Close();
	}

	private void chkCodificarEnlaces_CheckedChanged(object sender, EventArgs e)
	{
		if (chkCodificarEnlaces.Checked)
		{
			List<string> list = URLExtractor.ExtraerSoloURLsOficiales(TextoError);
			string text = TextoError;
			foreach (string item in list)
			{
				string text2 = URLExtractor.ExtraerFileID(item);
				string fileKey = URLExtractor.ExtraerFileKey(item);
				if (!string.IsNullOrEmpty(text2))
				{
					string newValue = URLExtractor.GenerateEncodedURILink(text2, fileKey, URLExtractor.IsMegaFolder(item), Compatibility: false);
					text = text.Replace(item, newValue);
				}
			}
			txtDatos.Text = (text ?? "").Replace("\r\n", Environment.NewLine);
		}
		else
		{
			txtDatos.Text = (TextoError ?? "").Replace("\r\n", Environment.NewLine);
		}
	}
}
