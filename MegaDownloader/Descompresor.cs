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
public class Descompresor : Form
{
	public delegate void ActualizarDatosCallback();

	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("bckActualizador")]
	private BackgroundWorker _bckActualizador;

	[field: AccessedThroughProperty("gbEstado")]
	internal virtual GroupBox gbEstado
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblTamano")]
	internal virtual Label lblTamano
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

	[field: AccessedThroughProperty("lblActual")]
	internal virtual Label lblActual
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

	[field: AccessedThroughProperty("lblFichero")]
	internal virtual Label lblFichero
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

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual GroupBox GroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtCola")]
	internal virtual TextBox txtCola
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

	public Descompresor()
	{
		base.Load += Descompresor_Load;
		base.Shown += Descompresor_Shown;
		base.FormClosed += [SpecialName] (object a0, FormClosedEventArgs a1) =>
		{
			Cerrando();
		};
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
		this.gbEstado = new System.Windows.Forms.GroupBox();
		this.lblTamano = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.lblActual = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.lblFichero = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.txtCola = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.gbEstado.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		base.SuspendLayout();
		this.gbEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gbEstado.Controls.Add(this.lblTamano);
		this.gbEstado.Controls.Add(this.Label6);
		this.gbEstado.Controls.Add(this.lblActual);
		this.gbEstado.Controls.Add(this.Label4);
		this.gbEstado.Controls.Add(this.lblFichero);
		this.gbEstado.Controls.Add(this.Label2);
		this.gbEstado.Location = new System.Drawing.Point(12, 48);
		this.gbEstado.Name = "gbEstado";
		this.gbEstado.Size = new System.Drawing.Size(504, 81);
		this.gbEstado.TabIndex = 0;
		this.gbEstado.TabStop = false;
		this.gbEstado.Text = "Estado";
		this.lblTamano.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblTamano.AutoSize = true;
		this.lblTamano.Location = new System.Drawing.Point(390, 50);
		this.lblTamano.MinimumSize = new System.Drawing.Size(100, 0);
		this.lblTamano.Name = "lblTamano";
		this.lblTamano.Size = new System.Drawing.Size(100, 13);
		this.lblTamano.TabIndex = 5;
		this.lblTamano.Text = "  -";
		this.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Label6.AutoSize = true;
		this.Label6.Location = new System.Drawing.Point(343, 50);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(49, 13);
		this.Label6.TabIndex = 4;
		this.Label6.Text = "Tamaño:";
		this.lblActual.AutoSize = true;
		this.lblActual.Location = new System.Drawing.Point(57, 50);
		this.lblActual.Name = "lblActual";
		this.lblActual.Size = new System.Drawing.Size(10, 13);
		this.lblActual.TabIndex = 3;
		this.lblActual.Text = "-";
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(6, 50);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(40, 13);
		this.Label4.TabIndex = 2;
		this.Label4.Text = "Actual:";
		this.lblFichero.AutoSize = true;
		this.lblFichero.Location = new System.Drawing.Point(57, 25);
		this.lblFichero.Name = "lblFichero";
		this.lblFichero.Size = new System.Drawing.Size(10, 13);
		this.lblFichero.TabIndex = 1;
		this.lblFichero.Text = "-";
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(6, 25);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(45, 13);
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Fichero:";
		this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox2.Controls.Add(this.txtCola);
		this.GroupBox2.Location = new System.Drawing.Point(12, 135);
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.Size = new System.Drawing.Size(504, 88);
		this.GroupBox2.TabIndex = 1;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Cola de descompresión";
		this.txtCola.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtCola.Enabled = false;
		this.txtCola.Location = new System.Drawing.Point(6, 19);
		this.txtCola.Multiline = true;
		this.txtCola.Name = "txtCola";
		this.txtCola.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtCola.Size = new System.Drawing.Size(492, 63);
		this.txtCola.TabIndex = 0;
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(12, 9);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(388, 26);
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Esta pantalla le permite ver el estado de los ficheros pendientes de descomprimir \r\n(si ha activado la opción de extraer automáticamente).";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(528, 235);
		base.Controls.Add(this.Label1);
		base.Controls.Add(this.GroupBox2);
		base.Controls.Add(this.gbEstado);
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(400, 250);
		base.Name = "Descompresor";
		this.Text = "Descompresor de ficheros";
		this.gbEstado.ResumeLayout(false);
		this.gbEstado.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Descompresor_Load(object sender, EventArgs e)
	{
		Translate();
	}

	private void Translate()
	{
		gbEstado.Text = Language.GetText("Status");
		Label6.Text = Language.GetText("Size") + ":";
		Label4.Text = Language.GetText("Current") + ":";
		Label2.Text = Language.GetText("File") + ":";
		GroupBox2.Text = Language.GetText("Extraction queue");
		Label1.Text = Language.GetText("This screen lets you see the status of the files pending of extraction") + " \r\n(" + Language.GetText("if automatic extraction option is enabled") + ").";
		Text = Language.GetText("File decompressor");
	}

	private void Descompresor_Shown(object sender, EventArgs e)
	{
		ActualizarDatos();
		bckActualizador = new BackgroundWorker();
		bckActualizador.WorkerSupportsCancellation = true;
		bckActualizador.RunWorkerAsync();
	}

	private void ActualizarDatos()
	{
		if (txtCola.InvokeRequired)
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
		DescompresorController controller = DescompresorController.GetController();
		List<string> cola = controller.GetCola();
		lblFichero.Text = controller.EleActual_Ruta;
		lblActual.Text = controller.EleActual_FicActNombre;
		lblTamano.Text = "  -";
		long? eleActual_TamanoTotal = controller.EleActual_TamanoTotal;
		long? num = controller.EleActual_FicActExtraido;
		long? num2 = controller.EleActual_TamanoTotalExtraido;
		checked
		{
			if (eleActual_TamanoTotal.HasValue)
			{
				if (!num.HasValue)
				{
					num = 0L;
				}
				if (!num2.HasValue)
				{
					num2 = 0L;
				}
				num += num2;
				lblTamano.Text = PintarTamano(new decimal(num.Value)) + " / " + PintarTamano(new decimal(eleActual_TamanoTotal.Value));
			}
			if (string.IsNullOrEmpty(lblFichero.Text))
			{
				lblFichero.Text = "-";
			}
			if (string.IsNullOrEmpty(lblActual.Text))
			{
				lblActual.Text = "-";
			}
			while ((lblFichero.Width + 65 >= gbEstado.Width) & (lblFichero.Text.Length > 10))
			{
				int length = lblFichero.Text.Length;
				int num3 = (int)Math.Round((double)length / 2.0);
				lblFichero.Text = lblFichero.Text.Substring(0, num3 - 3) + " ... " + lblFichero.Text.Substring(num3 + 3, length - (num3 + 3));
				if (lblFichero.Text.Length >= length)
				{
					break;
				}
			}
			while ((lblActual.Width + 220 >= gbEstado.Width) & (lblActual.Text.Length > 15))
			{
				int length2 = lblActual.Text.Length;
				int num4 = (int)Math.Round((double)length2 / 2.0);
				lblActual.Text = lblActual.Text.Substring(0, num4 - 4) + " ... " + lblActual.Text.Substring(num4 + 3, length2 - (num4 + 4));
				if (lblActual.Text.Length >= length2)
				{
					break;
				}
			}
			string text = "";
			foreach (string item in cola)
			{
				text = text + item + "\r\n";
			}
			if (Operators.CompareString(txtCola.Text, text, TextCompare: false) != 0)
			{
				txtCola.Text = text;
			}
		}
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
		return numBytes.ToString("F1") + " " + text;
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

	private void Cerrando()
	{
		bckActualizador.CancelAsync();
	}
}
