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
public sealed class Cerrando : Form
{
	private IContainer components;

	[field: AccessedThroughProperty("lblMensaje")]
	internal Label lblMensaje
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Cerrando()
	{
		base.Load += Cerrando_Load;
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
		new System.ComponentModel.ComponentResourceManager(typeof(MegaDownloader.Cerrando));
		this.lblMensaje = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblMensaje.AutoSize = true;
		this.lblMensaje.Location = new System.Drawing.Point(12, 9);
		this.lblMensaje.Name = "lblMensaje";
		this.lblMensaje.Size = new System.Drawing.Size(34, 13);
		this.lblMensaje.TabIndex = 0;
		this.lblMensaje.Text = "Texto";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(180, 35);
		base.ControlBox = false;
		base.Controls.Add(this.lblMensaje);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Cerrando";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Cerrando_Load(object sender, EventArgs e)
	{
	}
}
