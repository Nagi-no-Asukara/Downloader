using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

[DesignerGenerated]
public class EncodeLinksForm : Form
{
	public delegate void ActualizarDatosCallback();

	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	private bool ClosingForm;

	[CompilerGenerated]
	[AccessedThroughProperty("bckActualizador")]
	private BackgroundWorker _bckActualizador;

	public Main MainForm;

	private int TextHash;

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

	[field: AccessedThroughProperty("txtEncodedLinks")]
	internal virtual RichTextBox txtEncodedLinks
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

	[field: AccessedThroughProperty("txtOriginalLinks")]
	internal virtual RichTextBox txtOriginalLinks
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

	[field: AccessedThroughProperty("lblExplanation")]
	internal virtual Label lblExplanation
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	private BackgroundWorker bckActualizador
	{
		[CompilerGenerated]
		get
		{
			return _bckActualizador;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bckActualizador_DoWork;
			BackgroundWorker backgroundWorker = _bckActualizador;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
			}
			_bckActualizador = value;
			backgroundWorker = _bckActualizador;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
			}
		}
	}

	public EncodeLinksForm()
	{
		base.Load += EncodeLinksForm_Load;
		base.FormClosed += [SpecialName] (object a0, FormClosedEventArgs a1) =>
		{
			Cerrando();
		};
		ClosingForm = false;
		TextHash = 0;
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
		this.txtEncodedLinks = new System.Windows.Forms.RichTextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.lblExplanation = new System.Windows.Forms.Label();
		this.txtOriginalLinks = new System.Windows.Forms.RichTextBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		base.SuspendLayout();
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.Location = new System.Drawing.Point(616, 328);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 23);
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Cerrar";
		this.Button1.UseVisualStyleBackColor = true;
		this.txtEncodedLinks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtEncodedLinks.Location = new System.Drawing.Point(6, 19);
		this.txtEncodedLinks.Name = "txtEncodedLinks";
		this.txtEncodedLinks.ReadOnly = true;
		this.txtEncodedLinks.Size = new System.Drawing.Size(667, 107);
		this.txtEncodedLinks.TabIndex = 1;
		this.txtEncodedLinks.Text = "";
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Controls.Add(this.lblExplanation);
		this.GroupBox1.Controls.Add(this.txtOriginalLinks);
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(679, 172);
		this.GroupBox1.TabIndex = 2;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "GroupBox1";
		this.lblExplanation.AutoSize = true;
		this.lblExplanation.Location = new System.Drawing.Point(6, 30);
		this.lblExplanation.MinimumSize = new System.Drawing.Size(500, 0);
		this.lblExplanation.Name = "lblExplanation";
		this.lblExplanation.Size = new System.Drawing.Size(500, 13);
		this.lblExplanation.TabIndex = 3;
		this.lblExplanation.Text = "Label1";
		this.txtOriginalLinks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOriginalLinks.Location = new System.Drawing.Point(6, 59);
		this.txtOriginalLinks.Name = "txtOriginalLinks";
		this.txtOriginalLinks.Size = new System.Drawing.Size(667, 107);
		this.txtOriginalLinks.TabIndex = 2;
		this.txtOriginalLinks.Text = "";
		this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox2.Controls.Add(this.txtEncodedLinks);
		this.GroupBox2.Location = new System.Drawing.Point(12, 190);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(679, 132);
		this.GroupBox2.TabIndex = 3;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "GroupBox2";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(703, 363);
		base.Controls.Add(this.GroupBox2);
		base.Controls.Add(this.GroupBox1);
		base.Controls.Add(this.Button1);
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		this.MinimumSize = new System.Drawing.Size(650, 340);
		base.Name = "EncodeLinksForm";
		this.Text = "Información";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void EncodeLinksForm_Load(object sender, EventArgs e)
	{
		txtEncodedLinks.Multiline = true;
		txtEncodedLinks.Text = "";
		Translate();
		bckActualizador = new BackgroundWorker();
		bckActualizador.WorkerSupportsCancellation = true;
		bckActualizador.RunWorkerAsync();
		Screen screen = Screen.FromPoint(base.Location);
		base.Location = checked(new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0)));
	}

	private void Translate()
	{
		Text = Language.GetText("Encode Url");
		Button1.Text = Language.GetText("Close");
		GroupBox1.Text = Language.GetText("MEGA Url");
		GroupBox2.Text = Language.GetText("Encoded Url");
		lblExplanation.Text = Language.GetText("Paste your MEGA Url(s) and the encoded Url(s) will appear under the Encoded Url box.");
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Cerrando()
	{
		ClosingForm = true;
		bckActualizador.CancelAsync();
	}

	public void bckActualizador_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
		while (!backgroundWorker.CancellationPending)
		{
			Thread.Sleep(300);
			if (backgroundWorker.CancellationPending)
			{
				break;
			}
			ActualizarDatos();
		}
		bckActualizador = null;
	}

	private void ActualizarDatos()
	{
		if (ClosingForm)
		{
			return;
		}
		if (txtOriginalLinks.InvokeRequired)
		{
			try
			{
				ActualizarDatosCallback method = ActualizarDatos;
				Invoke(method, new object[0]);
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
				return;
			}
		}
		if (ClosingForm)
		{
			return;
		}
		string text = txtOriginalLinks.Text;
		int hashCode = text.GetHashCode();
		if (hashCode == TextHash)
		{
			return;
		}
		TextHash = hashCode;
		List<string> list = URLExtractor.ExtraerSoloURLsOficiales(text);
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
		txtEncodedLinks.Text = text;
	}
}
