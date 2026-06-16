using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class ELCForm : Form
{
	public delegate void ActualizarDatosCallback();

	private IContainer components;

	private Label label3;

	private Label lblExplanation2;

	[CompilerGenerated]
	[AccessedThroughProperty("btnSaveFile")]
	private Button _btnSaveFile;

	private TextBox txtExaminar;

	private Label lblSaveAsELC;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExaminar")]
	private Button _btnExaminar;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCerrar")]
	private Button _btnCerrar;

	private ComboBox comboELCAccounts;

	[CompilerGenerated]
	[AccessedThroughProperty("btnCrearELC")]
	private Button _btnCrearELC;

	[CompilerGenerated]
	[AccessedThroughProperty("txtELCUrl")]
	private TextBox _txtELCUrl;

	private GroupBox gbELCLink;

	private Label lblExplanation;

	[CompilerGenerated]
	[AccessedThroughProperty("txtMegaURLs")]
	private TextBox _txtMegaURLs;

	private GroupBox gbMEGAUrl;

	private bool ClosingForm;

	public Main MainForm;

	[CompilerGenerated]
	[AccessedThroughProperty("bckELCGenerator")]
	private BackgroundWorker _bckELCGenerator;

	private bool BackgroundWorkerBusy;

	private string Action;

	private List<ServerEncoderLinkHelper.MegaLink> MegaLinkList;

	private string TextTemplateToPrint;

	private string ELC_URL;

	private string ELCResult;

	private Exception ErrorGeneratingELC;

	private string ELCFilePath;

	private Button btnSaveFile
	{
		[CompilerGenerated]
		get
		{
			return _btnSaveFile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnSaveFile_Click;
			Button button = _btnSaveFile;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnSaveFile = value;
			button = _btnSaveFile;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	private Button btnExaminar
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

	private Button btnCerrar
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

	private Button btnCrearELC
	{
		[CompilerGenerated]
		get
		{
			return _btnCrearELC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnCrearELC_Click;
			Button button = _btnCrearELC;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnCrearELC = value;
			button = _btnCrearELC;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	private TextBox txtELCUrl
	{
		[CompilerGenerated]
		get
		{
			return _txtELCUrl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = txtELCUrl_KeyDown;
			TextBox textBox = _txtELCUrl;
			if (textBox != null)
			{
				textBox.KeyDown -= value2;
			}
			_txtELCUrl = value;
			textBox = _txtELCUrl;
			if (textBox != null)
			{
				textBox.KeyDown += value2;
			}
		}
	}

	private TextBox txtMegaURLs
	{
		[CompilerGenerated]
		get
		{
			return _txtMegaURLs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = txtMegaURLs_KeyDown;
			TextBox textBox = _txtMegaURLs;
			if (textBox != null)
			{
				textBox.KeyDown -= value2;
			}
			_txtMegaURLs = value;
			textBox = _txtMegaURLs;
			if (textBox != null)
			{
				textBox.KeyDown += value2;
			}
		}
	}

	[field: AccessedThroughProperty("chkMultipleELCs")]
	internal virtual CheckBox chkMultipleELCs
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public string MegaURLs
	{
		set
		{
			txtMegaURLs.Text = value;
		}
	}

	private BackgroundWorker bckELCGenerator
	{
		[CompilerGenerated]
		get
		{
			return _bckELCGenerator;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bckELCGenerator_DoWork;
			BackgroundWorker backgroundWorker = _bckELCGenerator;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
			}
			_bckELCGenerator = value;
			backgroundWorker = _bckELCGenerator;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.gbMEGAUrl = new System.Windows.Forms.GroupBox();
		this.chkMultipleELCs = new System.Windows.Forms.CheckBox();
		this.label3 = new System.Windows.Forms.Label();
		this.btnCrearELC = new System.Windows.Forms.Button();
		this.comboELCAccounts = new System.Windows.Forms.ComboBox();
		this.txtMegaURLs = new System.Windows.Forms.TextBox();
		this.lblExplanation = new System.Windows.Forms.Label();
		this.gbELCLink = new System.Windows.Forms.GroupBox();
		this.lblExplanation2 = new System.Windows.Forms.Label();
		this.btnSaveFile = new System.Windows.Forms.Button();
		this.btnExaminar = new System.Windows.Forms.Button();
		this.lblSaveAsELC = new System.Windows.Forms.Label();
		this.txtExaminar = new System.Windows.Forms.TextBox();
		this.txtELCUrl = new System.Windows.Forms.TextBox();
		this.btnCerrar = new System.Windows.Forms.Button();
		this.gbMEGAUrl.SuspendLayout();
		this.gbELCLink.SuspendLayout();
		base.SuspendLayout();
		this.gbMEGAUrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gbMEGAUrl.Controls.Add(this.chkMultipleELCs);
		this.gbMEGAUrl.Controls.Add(this.label3);
		this.gbMEGAUrl.Controls.Add(this.btnCrearELC);
		this.gbMEGAUrl.Controls.Add(this.comboELCAccounts);
		this.gbMEGAUrl.Controls.Add(this.txtMegaURLs);
		this.gbMEGAUrl.Controls.Add(this.lblExplanation);
		this.gbMEGAUrl.Location = new System.Drawing.Point(12, 12);
		this.gbMEGAUrl.Name = "gbMEGAUrl";
		this.gbMEGAUrl.Size = new System.Drawing.Size(658, 181);
		this.gbMEGAUrl.TabIndex = 0;
		this.gbMEGAUrl.TabStop = false;
		this.gbMEGAUrl.Text = "groupBox1";
		this.chkMultipleELCs.AutoSize = true;
		this.chkMultipleELCs.Location = new System.Drawing.Point(322, 152);
		this.chkMultipleELCs.Name = "chkMultipleELCs";
		this.chkMultipleELCs.Size = new System.Drawing.Size(85, 17);
		this.chkMultipleELCs.TabIndex = 5;
		this.chkMultipleELCs.Text = "Multiple ELC";
		this.chkMultipleELCs.UseVisualStyleBackColor = true;
		this.label3.Location = new System.Drawing.Point(6, 146);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(100, 23);
		this.label3.TabIndex = 4;
		this.label3.Text = "Cuenta ELC:";
		this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.btnCrearELC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnCrearELC.Location = new System.Drawing.Point(499, 148);
		this.btnCrearELC.Name = "btnCrearELC";
		this.btnCrearELC.Size = new System.Drawing.Size(144, 23);
		this.btnCrearELC.TabIndex = 3;
		this.btnCrearELC.Text = "Generar ELC";
		this.btnCrearELC.UseVisualStyleBackColor = true;
		this.comboELCAccounts.FormattingEnabled = true;
		this.comboELCAccounts.Location = new System.Drawing.Point(112, 148);
		this.comboELCAccounts.Name = "comboELCAccounts";
		this.comboELCAccounts.Size = new System.Drawing.Size(195, 21);
		this.comboELCAccounts.TabIndex = 2;
		this.txtMegaURLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtMegaURLs.Location = new System.Drawing.Point(14, 42);
		this.txtMegaURLs.Multiline = true;
		this.txtMegaURLs.Name = "txtMegaURLs";
		this.txtMegaURLs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtMegaURLs.Size = new System.Drawing.Size(629, 100);
		this.txtMegaURLs.TabIndex = 1;
		this.lblExplanation.Location = new System.Drawing.Point(6, 16);
		this.lblExplanation.Name = "lblExplanation";
		this.lblExplanation.Size = new System.Drawing.Size(495, 23);
		this.lblExplanation.TabIndex = 0;
		this.lblExplanation.Text = "label1";
		this.lblExplanation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.gbELCLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gbELCLink.Controls.Add(this.lblExplanation2);
		this.gbELCLink.Controls.Add(this.btnSaveFile);
		this.gbELCLink.Controls.Add(this.btnExaminar);
		this.gbELCLink.Controls.Add(this.lblSaveAsELC);
		this.gbELCLink.Controls.Add(this.txtExaminar);
		this.gbELCLink.Controls.Add(this.txtELCUrl);
		this.gbELCLink.Location = new System.Drawing.Point(12, 198);
		this.gbELCLink.Name = "gbELCLink";
		this.gbELCLink.Size = new System.Drawing.Size(658, 180);
		this.gbELCLink.TabIndex = 1;
		this.gbELCLink.TabStop = false;
		this.gbELCLink.Text = "groupBox2";
		this.lblExplanation2.Location = new System.Drawing.Point(6, 16);
		this.lblExplanation2.Name = "lblExplanation2";
		this.lblExplanation2.Size = new System.Drawing.Size(495, 23);
		this.lblExplanation2.TabIndex = 4;
		this.lblExplanation2.Text = "label2";
		this.lblExplanation2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSaveFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnSaveFile.Location = new System.Drawing.Point(499, 147);
		this.btnSaveFile.Name = "btnSaveFile";
		this.btnSaveFile.Size = new System.Drawing.Size(144, 23);
		this.btnSaveFile.TabIndex = 4;
		this.btnSaveFile.Text = "Guardar fichero";
		this.btnSaveFile.UseVisualStyleBackColor = true;
		this.btnExaminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnExaminar.Location = new System.Drawing.Point(372, 147);
		this.btnExaminar.Name = "btnExaminar";
		this.btnExaminar.Size = new System.Drawing.Size(75, 23);
		this.btnExaminar.TabIndex = 3;
		this.btnExaminar.Text = "Examinar";
		this.btnExaminar.UseVisualStyleBackColor = true;
		this.lblSaveAsELC.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblSaveAsELC.Location = new System.Drawing.Point(6, 147);
		this.lblSaveAsELC.Name = "lblSaveAsELC";
		this.lblSaveAsELC.Size = new System.Drawing.Size(100, 23);
		this.lblSaveAsELC.TabIndex = 4;
		this.lblSaveAsELC.Text = "Guardar ELC:";
		this.lblSaveAsELC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.txtExaminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtExaminar.Location = new System.Drawing.Point(112, 149);
		this.txtExaminar.Name = "txtExaminar";
		this.txtExaminar.Size = new System.Drawing.Size(254, 20);
		this.txtExaminar.TabIndex = 3;
		this.txtELCUrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtELCUrl.Location = new System.Drawing.Point(14, 42);
		this.txtELCUrl.Multiline = true;
		this.txtELCUrl.Name = "txtELCUrl";
		this.txtELCUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtELCUrl.Size = new System.Drawing.Size(629, 99);
		this.txtELCUrl.TabIndex = 2;
		this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCerrar.Location = new System.Drawing.Point(595, 386);
		this.btnCerrar.Name = "btnCerrar";
		this.btnCerrar.Size = new System.Drawing.Size(75, 23);
		this.btnCerrar.TabIndex = 2;
		this.btnCerrar.Text = "Cerrar";
		this.btnCerrar.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(682, 421);
		base.Controls.Add(this.btnCerrar);
		base.Controls.Add(this.gbELCLink);
		base.Controls.Add(this.gbMEGAUrl);
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		this.MinimumSize = new System.Drawing.Size(500, 400);
		base.Name = "ELCForm";
		this.Text = "ELCForm";
		this.gbMEGAUrl.ResumeLayout(false);
		this.gbMEGAUrl.PerformLayout();
		this.gbELCLink.ResumeLayout(false);
		this.gbELCLink.PerformLayout();
		base.ResumeLayout(false);
	}

	public ELCForm()
	{
		base.Load += ELCForm_Load;
		base.FormClosed += [SpecialName] (object a0, FormClosedEventArgs a1) =>
		{
			Cerrando();
		};
		base.Shown += PantallaMsg_Shown;
		ClosingForm = false;
		BackgroundWorkerBusy = false;
		Action = null;
		MegaLinkList = null;
		ELC_URL = null;
		ELCResult = null;
		ErrorGeneratingELC = null;
		InitializeComponent();
	}

	private void ELCForm_Load(object sender, EventArgs e)
	{
		if (MainForm != null)
		{
			Translate();
			btnSaveFile.Enabled = false;
			btnExaminar.Enabled = false;
			ELCAccountHelper eLCAccountHelper = new ELCAccountHelper(ref MainForm.Config);
			comboELCAccounts.DataSource = (from c in eLCAccountHelper.GetAccounts()
				orderby c.Alias
				select new { Url = c.URL, AccountName = c.Alias }).ToList();
			comboELCAccounts.DisplayMember = "AccountName";
			comboELCAccounts.ValueMember = "Url";
			ELCAccountHelper.Account defaultAccount = eLCAccountHelper.GetDefaultAccount();
			if (defaultAccount != null)
			{
				comboELCAccounts.SelectedValue = defaultAccount.URL;
			}
			eLCAccountHelper.Dispose();
			if (comboELCAccounts.Items.Count == 0)
			{
				MessageBox.Show(Language.GetText("No ELC accounts configured. Go to Configuration in order to add an ELC account"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			bckELCGenerator = new BackgroundWorker();
			bckELCGenerator.WorkerSupportsCancellation = true;
			bckELCGenerator.RunWorkerAsync();
			Screen screen = Screen.FromPoint(base.Location);
			base.Location = checked(new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0)));
		}
	}

	private void Cerrando()
	{
		ClosingForm = true;
		bckELCGenerator.CancelAsync();
	}

	private void PantallaMsg_Shown(object sender, EventArgs e)
	{
		PonerFoco();
	}

	public void PonerFoco()
	{
		base.TopMost = true;
		base.TopMost = false;
		base.TopMost = true;
		Activate();
	}

	private void Translate()
	{
		Text = Language.GetText("ELC generator");
		btnCerrar.Text = Language.GetText("Close");
		gbMEGAUrl.Text = Language.GetText("MEGA Url");
		btnExaminar.Text = Language.GetText("Browse");
		gbELCLink.Text = Language.GetText("ELC");
		lblExplanation.Text = Language.GetText("Paste your MEGA Url(s), select your ELC account, and click on Generate ELC");
		lblExplanation2.Text = Language.GetText("This is your ELC link. You can also create an ELC file clicking on Save file");
		btnCrearELC.Text = Language.GetText("Generate ELC");
		btnSaveFile.Text = Language.GetText("Save file");
		chkMultipleELCs.Text = Language.GetText("Multiple ELC");
	}

	private void btnCerrar_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnCrearELC_Click(object sender, EventArgs e)
	{
		try
		{
			if (comboELCAccounts.SelectedValue == null || string.IsNullOrEmpty(Conversions.ToString(comboELCAccounts.SelectedValue)))
			{
				MessageBox.Show(Language.GetText("Please select a valid ELC account"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (BackgroundWorkerBusy)
			{
				MessageBox.Show(Language.GetText("There is an ELC being processed, please wait"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (chkMultipleELCs.Checked)
			{
				List<ServerEncoderLinkHelper.MegaLink> list = new List<ServerEncoderLinkHelper.MegaLink>();
				int num = 0;
				string obj = txtMegaURLs.Text;
				StringBuilder stringBuilder = new StringBuilder();
				string[] array = obj.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
				foreach (string text in array)
				{
					List<string> list2 = URLExtractor.ExtraerURLs(text);
					if (list2.Count > 0)
					{
						foreach (string item in list2)
						{
							ServerEncoderLinkHelper.MegaLink megaLink = new ServerEncoderLinkHelper.MegaLink();
							megaLink.FileID = URLExtractor.ExtraerFileID(item);
							megaLink.FileKey = URLExtractor.ExtraerFileKey(item);
							megaLink.MegaFolder = URLExtractor.IsMegaFolder(item);
							list.Add(megaLink);
							stringBuilder.AppendLine("{" + Conversions.ToString(num) + "}");
							num = checked(num + 1);
						}
					}
					else
					{
						stringBuilder.AppendLine(text);
					}
				}
				txtELCUrl.Text = "";
				BackgroundWorkerBusy = true;
				btnCrearELC.Text = Language.GetText("Loading...");
				btnCrearELC.Enabled = false;
				ELC_URL = Conversions.ToString(comboELCAccounts.SelectedValue);
				MegaLinkList = list;
				TextTemplateToPrint = stringBuilder.ToString();
				Action = "GenerateELC_Multiple";
				return;
			}
			List<string> list3 = URLExtractor.ExtraerURLs(txtMegaURLs.Text);
			if (list3.Count == 0)
			{
				MessageBox.Show(Language.GetText("Links not valid"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			txtELCUrl.Text = "";
			BackgroundWorkerBusy = true;
			btnCrearELC.Text = Language.GetText("Loading...");
			btnCrearELC.Enabled = false;
			ELC_URL = Conversions.ToString(comboELCAccounts.SelectedValue);
			List<ServerEncoderLinkHelper.MegaLink> list4 = new List<ServerEncoderLinkHelper.MegaLink>();
			foreach (string item2 in list3)
			{
				ServerEncoderLinkHelper.MegaLink megaLink2 = new ServerEncoderLinkHelper.MegaLink();
				megaLink2.FileID = URLExtractor.ExtraerFileID(item2);
				megaLink2.FileKey = URLExtractor.ExtraerFileKey(item2);
				megaLink2.MegaFolder = URLExtractor.IsMegaFolder(item2);
				list4.Add(megaLink2);
			}
			MegaLinkList = list4;
			TextTemplateToPrint = string.Empty;
			Action = "GenerateELC";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error generating ELC: " + ex2.ToString());
			MessageBox.Show(ex2.Message, Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void btnSaveFile_Click(object sender, EventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(ELCResult))
			{
				MessageBox.Show(Language.GetText("Links not valid"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (string.IsNullOrEmpty(txtExaminar.Text))
			{
				MessageBox.Show(Language.GetText("The ELC path is not valid"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (BackgroundWorkerBusy)
			{
				MessageBox.Show(Language.GetText("There is an ELC being processed, please wait"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			ELCFilePath = txtExaminar.Text;
			BackgroundWorkerBusy = true;
			Action = "SaveELC";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteError("Error generating ELC: " + ex2.ToString());
			MessageBox.Show(ex2.Message, Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void btnExaminar_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.CheckFileExists = false;
		saveFileDialog.DefaultExt = "elc";
		saveFileDialog.Filter = Language.GetText("ELC file") + " (*.elc)|*.elc";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			txtExaminar.Text = saveFileDialog.FileName;
		}
		saveFileDialog.Dispose();
	}

	public void bckELCGenerator_DoWork(object sender, DoWorkEventArgs e)
	{
		BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
		while (!backgroundWorker.CancellationPending)
		{
			Thread.Sleep(300);
			if (backgroundWorker.CancellationPending)
			{
				break;
			}
			GenerateELC();
		}
		bckELCGenerator = null;
	}

	private void GenerateELC()
	{
		switch (Action)
		{
		case "GenerateELC_Multiple":
			try
			{
				if ((string.IsNullOrEmpty(ELC_URL) | (MegaLinkList == null)) || MegaLinkList.Count == 0)
				{
					throw new ApplicationException("Invalid input data");
				}
				string text = TextTemplateToPrint;
				int num = 0;
				foreach (ServerEncoderLinkHelper.MegaLink megaLink in MegaLinkList)
				{
					List<ServerEncoderLinkHelper.MegaLink> list = new List<ServerEncoderLinkHelper.MegaLink>();
					list.Add(megaLink);
					text = text.Replace("{" + Conversions.ToString(num) + "}", "mega://elc?" + ServerEncoderLinkHelper.ServerEncode(ELC_URL, list, ref MainForm.Config));
					num = checked(num + 1);
				}
				ELCResult = text;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception errorGeneratingELC2 = ex2;
				ErrorGeneratingELC = errorGeneratingELC2;
				ELCResult = string.Empty;
				ProjectData.ClearProjectError();
			}
			finally
			{
				BackgroundWorkerBusy = false;
			}
			ActualizarDatos();
			break;
		case "GenerateELC":
			try
			{
				if ((string.IsNullOrEmpty(ELC_URL) | (MegaLinkList == null)) || MegaLinkList.Count == 0)
				{
					throw new ApplicationException("Invalid input data");
				}
				ELCResult = "mega://elc?" + ServerEncoderLinkHelper.ServerEncode(ELC_URL, MegaLinkList, ref MainForm.Config);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception errorGeneratingELC3 = ex3;
				ErrorGeneratingELC = errorGeneratingELC3;
				ELCResult = string.Empty;
				ProjectData.ClearProjectError();
			}
			finally
			{
				BackgroundWorkerBusy = false;
			}
			ActualizarDatos();
			break;
		case "SaveELC":
			try
			{
				if (string.IsNullOrEmpty(ELCFilePath) | string.IsNullOrEmpty(ELCResult))
				{
					throw new ApplicationException("Invalid input data");
				}
				using StreamWriter streamWriter = new StreamWriter(ELCFilePath, append: false);
				streamWriter.Write(ELCResult);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception errorGeneratingELC = ex;
				ErrorGeneratingELC = errorGeneratingELC;
				ELCResult = string.Empty;
				ProjectData.ClearProjectError();
			}
			finally
			{
				BackgroundWorkerBusy = false;
			}
			ActualizarDatos();
			break;
		}
	}

	private void ActualizarDatos()
	{
		if (ClosingForm)
		{
			return;
		}
		if (txtMegaURLs.InvokeRequired)
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
		switch (Action)
		{
		case "GenerateELC":
		case "GenerateELC_Multiple":
			Action = string.Empty;
			btnCrearELC.Text = Language.GetText("Generate ELC");
			btnCrearELC.Enabled = true;
			if (ErrorGeneratingELC != null)
			{
				MessageBox.Show(Language.GetText("Error generating ELC") + ": " + ErrorGeneratingELC.Message, Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ErrorGeneratingELC = null;
			}
			else
			{
				txtELCUrl.Text = ELCResult;
				btnExaminar.Enabled = true;
				btnSaveFile.Enabled = true;
			}
			break;
		case "SaveELC":
			Action = string.Empty;
			if (ErrorGeneratingELC != null)
			{
				MessageBox.Show(Language.GetText("Error generating ELC") + ": " + ErrorGeneratingELC.Message, Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				MessageBox.Show(Language.GetText("ELC created successfully"), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			break;
		}
	}

	private void txtELCUrl_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && ((e.KeyCode == Keys.A) | (e.KeyCode == Keys.E)))
		{
			if (sender != null)
			{
				((TextBox)sender).SelectAll();
			}
			e.Handled = true;
		}
	}

	private void txtMegaURLs_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Control && ((e.KeyCode == Keys.A) | (e.KeyCode == Keys.E)))
		{
			if (sender != null)
			{
				((TextBox)sender).SelectAll();
			}
			e.Handled = true;
		}
	}
}
