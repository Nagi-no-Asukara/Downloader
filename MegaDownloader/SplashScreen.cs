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
public sealed class SplashScreen : Form
{
	private IContainer components;

	[field: AccessedThroughProperty("lblMsg")]
	internal Label lblMsg
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PictureBox1")]
	internal PictureBox PictureBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblThx")]
	internal Label lblThx
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public SplashScreen()
	{
		base.Load += SplashScreen1_Load;
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
		this.lblMsg = new System.Windows.Forms.Label();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.lblThx = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		base.SuspendLayout();
		this.lblMsg.AutoSize = true;
		this.lblMsg.Location = new System.Drawing.Point(42, 134);
		this.lblMsg.MinimumSize = new System.Drawing.Size(200, 0);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new System.Drawing.Size(200, 13);
		this.lblMsg.TabIndex = 0;
		this.lblMsg.Text = "Cargando, por favor espere...";
		this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.PictureBox1.Image = MegaDownloader.My.Resources.Resources.mega;
		this.PictureBox1.Location = new System.Drawing.Point(74, 12);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(126, 83);
		this.PictureBox1.TabIndex = 1;
		this.PictureBox1.TabStop = false;
		this.lblThx.AutoSize = true;
		this.lblThx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblThx.Location = new System.Drawing.Point(14, 107);
		this.lblThx.MaximumSize = new System.Drawing.Size(250, 0);
		this.lblThx.MinimumSize = new System.Drawing.Size(250, 0);
		this.lblThx.Name = "lblThx";
		this.lblThx.Size = new System.Drawing.Size(250, 13);
		this.lblThx.TabIndex = 2;
		this.lblThx.Text = "MegaDownloader VXXX";
		this.lblThx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		base.ClientSize = new System.Drawing.Size(276, 162);
		base.ControlBox = false;
		base.Controls.Add(this.lblThx);
		base.Controls.Add(this.PictureBox1);
		base.Controls.Add(this.lblMsg);
		this.DoubleBuffered = true;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SplashScreen";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void SplashScreen1_Load(object sender, EventArgs e)
	{
		lblMsg.Text = Language.GetText("Loading please wait");
		lblThx.Text = InternalConfiguration.ObtenerNombreApp() + InternalConfiguration.ObtenerValueFromInternalConfig("VERSION_MEGADOWNLOADER");
	}
}
