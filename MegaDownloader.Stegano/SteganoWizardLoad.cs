using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MegaDownloader.My;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader.Stegano;

[DesignerGenerated]
public class SteganoWizardLoad : Form
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("btImageInput")]
	private Button _btImageInput;

	[CompilerGenerated]
	[AccessedThroughProperty("btLoad")]
	private Button _btLoad;

	[CompilerGenerated]
	[AccessedThroughProperty("btCancel")]
	private Button _btCancel;

	public Configuracion Config;

	public Main MainForm;

	[field: AccessedThroughProperty("gbIntro")]
	internal virtual GroupBox gbIntro
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lbIntro")]
	internal virtual Label lbIntro
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("gbImage")]
	internal virtual GroupBox gbImage
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lbImage")]
	internal virtual Label lbImage
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lbImageInput")]
	internal virtual Label lbImageInput
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btImageInput
	{
		[CompilerGenerated]
		get
		{
			return _btImageInput;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btImageInput_Click;
			Button button = _btImageInput;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btImageInput = value;
			button = _btImageInput;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("txtImageInput")]
	internal virtual TextBox txtImageInput
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("gbPassword")]
	internal virtual GroupBox gbPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lbPassword")]
	internal virtual Label lbPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lbPasswordTxt")]
	internal virtual Label lbPasswordTxt
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

	internal virtual Button btLoad
	{
		[CompilerGenerated]
		get
		{
			return _btLoad;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btLoad_Click;
			Button button = _btLoad;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btLoad = value;
			button = _btLoad;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCancel
	{
		[CompilerGenerated]
		get
		{
			return _btCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btCancel_Click;
			Button button = _btCancel;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btCancel = value;
			button = _btCancel;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public SteganoWizardLoad()
	{
		base.Load += ScreenLoad;
		base.HelpButtonClicked += [SpecialName] (object a0, CancelEventArgs a1) =>
		{
			HelpButtonPressed();
		};
		base.DragDrop += SteganoWizard_DragDrop;
		base.DragEnter += SteganoWizard_DragEnter;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MegaDownloader.Stegano.SteganoWizardLoad));
		this.gbIntro = new System.Windows.Forms.GroupBox();
		this.lbIntro = new System.Windows.Forms.Label();
		this.gbImage = new System.Windows.Forms.GroupBox();
		this.lbImageInput = new System.Windows.Forms.Label();
		this.btImageInput = new System.Windows.Forms.Button();
		this.txtImageInput = new System.Windows.Forms.TextBox();
		this.lbImage = new System.Windows.Forms.Label();
		this.gbPassword = new System.Windows.Forms.GroupBox();
		this.lbPassword = new System.Windows.Forms.Label();
		this.lbPasswordTxt = new System.Windows.Forms.Label();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.btLoad = new System.Windows.Forms.Button();
		this.btCancel = new System.Windows.Forms.Button();
		this.gbIntro.SuspendLayout();
		this.gbImage.SuspendLayout();
		this.gbPassword.SuspendLayout();
		base.SuspendLayout();
		this.gbIntro.Controls.Add(this.lbIntro);
		this.gbIntro.Location = new System.Drawing.Point(12, 12);
		this.gbIntro.Name = "gbIntro";
		this.gbIntro.Size = new System.Drawing.Size(489, 199);
		this.gbIntro.TabIndex = 0;
		this.gbIntro.TabStop = false;
		this.gbIntro.Text = "Introduction";
		this.lbIntro.AutoSize = true;
		this.lbIntro.Location = new System.Drawing.Point(6, 28);
		this.lbIntro.MaximumSize = new System.Drawing.Size(480, 0);
		this.lbIntro.Name = "lbIntro";
		this.lbIntro.Size = new System.Drawing.Size(470, 143);
		this.lbIntro.TabIndex = 0;
		this.lbIntro.Text = resources.GetString("lbIntro.Text");
		this.gbImage.Controls.Add(this.lbImageInput);
		this.gbImage.Controls.Add(this.btImageInput);
		this.gbImage.Controls.Add(this.txtImageInput);
		this.gbImage.Controls.Add(this.lbImage);
		this.gbImage.Location = new System.Drawing.Point(12, 217);
		this.gbImage.Name = "gbImage";
		this.gbImage.Size = new System.Drawing.Size(489, 126);
		this.gbImage.TabIndex = 1;
		this.gbImage.TabStop = false;
		this.gbImage.Text = "Image to load";
		this.lbImageInput.AutoSize = true;
		this.lbImageInput.Location = new System.Drawing.Point(6, 64);
		this.lbImageInput.Name = "lbImageInput";
		this.lbImageInput.Size = new System.Drawing.Size(65, 13);
		this.lbImageInput.TabIndex = 4;
		this.lbImageInput.Text = "Input image:";
		this.btImageInput.Location = new System.Drawing.Point(392, 89);
		this.btImageInput.Name = "btImageInput";
		this.btImageInput.Size = new System.Drawing.Size(85, 23);
		this.btImageInput.TabIndex = 3;
		this.btImageInput.Text = "Browse";
		this.btImageInput.UseVisualStyleBackColor = true;
		this.txtImageInput.Location = new System.Drawing.Point(16, 91);
		this.txtImageInput.Name = "txtImageInput";
		this.txtImageInput.Size = new System.Drawing.Size(370, 20);
		this.txtImageInput.TabIndex = 2;
		this.lbImage.AutoSize = true;
		this.lbImage.Location = new System.Drawing.Point(6, 32);
		this.lbImage.MaximumSize = new System.Drawing.Size(480, 0);
		this.lbImage.Name = "lbImage";
		this.lbImage.Size = new System.Drawing.Size(322, 13);
		this.lbImage.TabIndex = 1;
		this.lbImage.Text = "Select an existing image as \"Input image\", or enter the image URL.";
		this.gbPassword.Controls.Add(this.lbPassword);
		this.gbPassword.Controls.Add(this.lbPasswordTxt);
		this.gbPassword.Controls.Add(this.txtPassword);
		this.gbPassword.Location = new System.Drawing.Point(12, 349);
		this.gbPassword.Name = "gbPassword";
		this.gbPassword.Size = new System.Drawing.Size(489, 104);
		this.gbPassword.TabIndex = 3;
		this.gbPassword.TabStop = false;
		this.gbPassword.Text = "Other options";
		this.lbPassword.AutoSize = true;
		this.lbPassword.Location = new System.Drawing.Point(6, 29);
		this.lbPassword.MaximumSize = new System.Drawing.Size(480, 0);
		this.lbPassword.Name = "lbPassword";
		this.lbPassword.Size = new System.Drawing.Size(300, 13);
		this.lbPassword.TabIndex = 8;
		this.lbPassword.Text = "If the image has a password, enter it. If not, just leave it empty.";
		this.lbPasswordTxt.AutoSize = true;
		this.lbPasswordTxt.Location = new System.Drawing.Point(91, 64);
		this.lbPasswordTxt.MaximumSize = new System.Drawing.Size(90, 0);
		this.lbPasswordTxt.MinimumSize = new System.Drawing.Size(90, 0);
		this.lbPasswordTxt.Name = "lbPasswordTxt";
		this.lbPasswordTxt.Size = new System.Drawing.Size(90, 13);
		this.lbPasswordTxt.TabIndex = 8;
		this.lbPasswordTxt.Text = "Password:";
		this.lbPasswordTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtPassword.Location = new System.Drawing.Point(187, 61);
		this.txtPassword.MaxLength = 256;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = '*';
		this.txtPassword.Size = new System.Drawing.Size(141, 20);
		this.txtPassword.TabIndex = 8;
		this.btLoad.Location = new System.Drawing.Point(12, 459);
		this.btLoad.Name = "btLoad";
		this.btLoad.Size = new System.Drawing.Size(85, 25);
		this.btLoad.TabIndex = 8;
		this.btLoad.Text = "Load";
		this.btLoad.UseVisualStyleBackColor = true;
		this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btCancel.Location = new System.Drawing.Point(416, 459);
		this.btCancel.Name = "btCancel";
		this.btCancel.Size = new System.Drawing.Size(85, 25);
		this.btCancel.TabIndex = 9;
		this.btCancel.Text = "Cancel";
		this.btCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.btLoad;
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btCancel;
		base.ClientSize = new System.Drawing.Size(512, 493);
		base.Controls.Add(this.btCancel);
		base.Controls.Add(this.btLoad);
		base.Controls.Add(this.gbPassword);
		base.Controls.Add(this.gbImage);
		base.Controls.Add(this.gbIntro);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.HelpButton = true;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SteganoWizardLoad";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "SteganoWizard";
		this.gbIntro.ResumeLayout(false);
		this.gbIntro.PerformLayout();
		this.gbImage.ResumeLayout(false);
		this.gbImage.PerformLayout();
		this.gbPassword.ResumeLayout(false);
		this.gbPassword.PerformLayout();
		base.ResumeLayout(false);
	}

	private void Translate()
	{
		Text = Language.GetText("Steganography Wizard");
		gbIntro.Text = Language.GetText("Introduction");
		lbIntro.Text = Language.GetText("Steganography is the art and science ... LOAD");
		lbImage.Text = Language.GetText("Select an existing image as Input image, or enter the image URL");
		lbPassword.Text = Language.GetText("If the image has a password, enter it. If not, just leave it empty");
		btCancel.Text = Language.GetText("Cancel");
		btLoad.Text = Language.GetText("Load");
		gbImage.Text = Language.GetText("Image to load");
		gbPassword.Text = Language.GetText("Other options");
		lbPasswordTxt.Text = Language.GetText("Password") + ":";
		btImageInput.Text = Language.GetText("Browse");
		lbImageInput.Text = Language.GetText("Input image") + ":";
	}

	private void ScreenLoad(object sender, EventArgs e)
	{
		Screen screen = Screen.FromPoint(base.Location);
		base.Location = checked(new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0)));
		Translate();
	}

	private void btLoad_Click(object sender, EventArgs e)
	{
		btLoad.Enabled = false;
		btCancel.Enabled = false;
		_ = DateAndTime.Now;
		try
		{
			if (string.IsNullOrEmpty(txtImageInput.Text))
			{
				throw new ApplicationException(Language.GetText("Input image not specified"));
			}
			if (!File.Exists(txtImageInput.Text) && !IsValidUri(txtImageInput.Text))
			{
				throw new ApplicationException(Language.GetText("Input image does not exist"));
			}
			string HiddenText = null;
			if (new SteganoManager().LoadImages(txtImageInput.Text, txtPassword.Text, ref HiddenText))
			{
				Hide();
				if ((HiddenText ?? "").StartsWith("{HIDDEN}"))
				{
					MyProject.Forms.Main.ComprobarYAgregarLinks(HiddenText.Substring("{HIDDEN}".Length), ExtraerURLs: false, EsconderLinks: true);
				}
				else
				{
					MyProject.Forms.Main.ComprobarYAgregarLinks(HiddenText, ExtraerURLs: false, EsconderLinks: false);
				}
				Close();
				return;
			}
			MessageBox.Show(Language.GetText("No hidden links were found. Please check the image and the password"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (ApplicationException ex)
		{
			ProjectData.SetProjectError(ex);
			ApplicationException ex2 = ex;
			MessageBox.Show(ex2.Message, Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteError("Error trying to load stegano: " + ex4.ToString());
			MessageBox.Show(ex4.Message, Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		btCancel.Enabled = true;
		btLoad.Enabled = true;
	}

	public bool IsValidUri(string url)
	{
		Uri result = null;
		return Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out result);
	}

	private void btCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btImageInput_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.CheckFileExists = true;
		openFileDialog.DefaultExt = "jpg";
		openFileDialog.Filter = Language.GetText("Images") + "|*.jpg";
		openFileDialog.Multiselect = false;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			txtImageInput.Text = openFileDialog.FileName;
		}
		openFileDialog.Dispose();
	}

	private void HelpButtonPressed()
	{
		if (Language.GetCurrentLanguageCode().ToUpperInvariant().StartsWith("ES"))
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("STEGANO_LINK_ES"));
		}
		else
		{
			Process.Start(InternalConfiguration.ObtenerValueFromInternalConfig("STEGANO_LINK_EN"));
		}
	}

	private void SteganoWizard_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Data.GetData(DataFormats.FileDrop) == null)
		{
			return;
		}
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
		bool flag = true;
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (!File.Exists(text) || !text.ToLower().EndsWith(".jpg"))
			{
				flag = false;
			}
		}
		if (!flag)
		{
			return;
		}
		string[] array3 = array;
		foreach (string text2 in array3)
		{
			if (text2.ToLower().EndsWith(".jpg"))
			{
				txtImageInput.Text = text2;
				break;
			}
		}
	}

	private void SteganoWizard_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetData(DataFormats.FileDrop) == null)
		{
			return;
		}
		string[] obj = (string[])e.Data.GetData(DataFormats.FileDrop);
		bool flag = true;
		string[] array = obj;
		foreach (string text in array)
		{
			if (!File.Exists(text) || !text.ToLower().EndsWith(".jpg"))
			{
				flag = false;
			}
		}
		if (flag)
		{
			e.Effect = DragDropEffects.Copy;
		}
	}
}
