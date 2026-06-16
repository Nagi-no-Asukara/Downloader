using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using MegaDownloader.My;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

[DesignerGenerated]
public class StreamingForm : Form
{
	public delegate void ActualizarDatosCallback();

	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCerrar")]
	private Button _btnCerrar;

	[CompilerGenerated]
	[AccessedThroughProperty("btnLanzarVLC")]
	private Button _btnLanzarVLC;

	public Configuracion Config;

	public Main MainForm;

	[CompilerGenerated]
	[AccessedThroughProperty("bckActualizador")]
	private BackgroundWorker _bckActualizador;

	private string PreviousURLMega;

	private bool ValidURLMega;

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

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtUrlMEGA")]
	internal virtual TextBox txtUrlMEGA
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnCerrar
	{
		[CompilerGenerated]
		get
		{
			return _btnCerrar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnCerrar_Click;
			Button button = _btnCerrar;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnCerrar = value;
			button = _btnCerrar;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnLanzarVLC
	{
		[CompilerGenerated]
		get
		{
			return _btnLanzarVLC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnLanzarVLC_Click;
			Button button = _btnLanzarVLC;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnLanzarVLC = value;
			button = _btnLanzarVLC;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtUrlStreaming")]
	internal virtual TextBox txtUrlStreaming
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual GroupBox GroupBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblInfo")]
	internal virtual Label lblInfo
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

	public StreamingForm()
	{
		base.Load += StreamingForm_Load;
		base.FormClosed += [SpecialName] (object a0, FormClosedEventArgs a1) =>
		{
			Cerrando();
		};
		base.HelpButtonClicked += [SpecialName] (object a0, CancelEventArgs a1) =>
		{
			HelpButtonPressed();
		};
		PreviousURLMega = string.Empty;
		ValidURLMega = false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MegaDownloader.StreamingForm));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtUrlMEGA = new System.Windows.Forms.TextBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtUrlStreaming = new System.Windows.Forms.TextBox();
		this.btnCerrar = new System.Windows.Forms.Button();
		this.btnLanzarVLC = new System.Windows.Forms.Button();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.lblInfo = new System.Windows.Forms.Label();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		base.SuspendLayout();
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.txtUrlMEGA);
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(609, 53);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "MEGA";
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(6, 22);
		this.Label1.MinimumSize = new System.Drawing.Size(120, 0);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(120, 13);
		this.Label1.TabIndex = 1;
		this.Label1.Text = "URL de MEGA:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtUrlMEGA.Location = new System.Drawing.Point(127, 19);
		this.txtUrlMEGA.Name = "txtUrlMEGA";
		this.txtUrlMEGA.Size = new System.Drawing.Size(469, 20);
		this.txtUrlMEGA.TabIndex = 0;
		this.GroupBox2.Controls.Add(this.Label2);
		this.GroupBox2.Controls.Add(this.txtUrlStreaming);
		this.GroupBox2.Location = new System.Drawing.Point(13, 71);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(608, 80);
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Streaming";
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(5, 22);
		this.Label2.MinimumSize = new System.Drawing.Size(120, 0);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(120, 13);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "URL streaming:";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtUrlStreaming.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtUrlStreaming.Location = new System.Drawing.Point(126, 19);
		this.txtUrlStreaming.Multiline = true;
		this.txtUrlStreaming.Name = "txtUrlStreaming";
		this.txtUrlStreaming.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtUrlStreaming.Size = new System.Drawing.Size(467, 55);
		this.txtUrlStreaming.TabIndex = 1;
		this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCerrar.Location = new System.Drawing.Point(546, 314);
		this.btnCerrar.Name = "btnCerrar";
		this.btnCerrar.Size = new System.Drawing.Size(75, 23);
		this.btnCerrar.TabIndex = 4;
		this.btnCerrar.Text = "Cerrar";
		this.btnCerrar.UseVisualStyleBackColor = true;
		this.btnLanzarVLC.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnLanzarVLC.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnLanzarVLC.Location = new System.Drawing.Point(12, 314);
		this.btnLanzarVLC.Name = "btnLanzarVLC";
		this.btnLanzarVLC.Size = new System.Drawing.Size(101, 23);
		this.btnLanzarVLC.TabIndex = 5;
		this.btnLanzarVLC.Text = "Lanzar VLC";
		this.btnLanzarVLC.UseVisualStyleBackColor = true;
		this.GroupBox3.Controls.Add(this.lblInfo);
		this.GroupBox3.Location = new System.Drawing.Point(13, 156);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(608, 152);
		this.GroupBox3.TabIndex = 6;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Información";
		this.lblInfo.AutoSize = true;
		this.lblInfo.Location = new System.Drawing.Point(6, 16);
		this.lblInfo.MaximumSize = new System.Drawing.Size(585, 0);
		this.lblInfo.MinimumSize = new System.Drawing.Size(585, 0);
		this.lblInfo.Name = "lblInfo";
		this.lblInfo.Size = new System.Drawing.Size(585, 117);
		this.lblInfo.TabIndex = 0;
		this.lblInfo.Text = resources.GetString("lblInfo.Text");
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btnCerrar;
		base.ClientSize = new System.Drawing.Size(629, 349);
		base.Controls.Add(this.GroupBox3);
		base.Controls.Add(this.btnLanzarVLC);
		base.Controls.Add(this.btnCerrar);
		base.Controls.Add(this.GroupBox2);
		base.Controls.Add(this.GroupBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.HelpButton = true;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "StreamingForm";
		this.Text = "StreamingForm";
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		base.ResumeLayout(false);
	}

	private void StreamingForm_Load(object sender, EventArgs e)
	{
		Translate();
		if (!Config.ServidorStreamingActivo)
		{
			txtUrlMEGA.Enabled = false;
			txtUrlStreaming.Enabled = false;
			lblInfo.Text = Language.GetText("Streaming server not activated");
			lblInfo.ForeColor = Color.Red;
		}
		bckActualizador = new BackgroundWorker();
		bckActualizador.WorkerSupportsCancellation = true;
		bckActualizador.RunWorkerAsync();
		Screen screen = Screen.FromPoint(base.Location);
		base.Location = checked(new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0)));
	}

	private void Translate()
	{
		Label1.Text = Language.GetText("MEGA Url") + ":";
		Label2.Text = Language.GetText("Streaming Url") + ":";
		GroupBox2.Text = Language.GetText("Streaming");
		GroupBox3.Text = Language.GetText("Information");
		lblInfo.Text = Language.GetText("Streaming Info");
		btnCerrar.Text = Language.GetText("Close");
		btnLanzarVLC.Text = Language.GetText("Start VLC");
		Text = Language.GetText("Streaming");
	}

	public void bckActualizador_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
		while (!backgroundWorker.CancellationPending)
		{
			Thread.Sleep(150);
			if (backgroundWorker.CancellationPending)
			{
				break;
			}
			ActualizarDatos();
		}
		bckActualizador = null;
	}

	private void Cerrando()
	{
		bckActualizador.CancelAsync();
	}

	private void ActualizarDatos()
	{
		if (txtUrlMEGA.InvokeRequired)
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
		if (!Config.ServidorStreamingActivo)
		{
			ValidURLMega = false;
			return;
		}
		string text = txtUrlMEGA.Text;
		if (Operators.CompareString(text, PreviousURLMega, TextCompare: false) != 0)
		{
			PreviousURLMega = text;
			ValidURLMega = false;
			string value = StreamingHelper.CreateStreamingLink(text, Config.ServidorStreamingPuerto, ref Config);
			if (!string.IsNullOrEmpty(value))
			{
				txtUrlStreaming.Text = value;
				ValidURLMega = true;
			}
		}
	}

	private void btnLanzarVLC_Click(object sender, EventArgs e)
	{
		if (ValidURLMega)
		{
			StreamingHelper.WatchOnline(Config.VLCPath, txtUrlStreaming.Text);
		}
	}

	private void btnCerrar_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void HelpButtonPressed()
	{
		MyProject.Forms.Main.FAQ_Click(null, null);
	}
}
