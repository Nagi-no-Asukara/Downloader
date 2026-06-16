using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MegaDownloader.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader.Stegano;

[DesignerGenerated]
public class SteganoWizardSave : Form
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("btImageOutput")]
	private Button _btImageOutput;

	[CompilerGenerated]
	[AccessedThroughProperty("txtImageOutput")]
	private TextBox _txtImageOutput;

	[CompilerGenerated]
	[AccessedThroughProperty("btImageInput")]
	private Button _btImageInput;

	[CompilerGenerated]
	[AccessedThroughProperty("btSave")]
	private Button _btSave;

	[CompilerGenerated]
	[AccessedThroughProperty("btCancel")]
	private Button _btCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("helpVisibleLinks")]
	private LinkLabel _helpVisibleLinks;

	[CompilerGenerated]
	[AccessedThroughProperty("helpStegano")]
	private LinkLabel _helpStegano;

	public Configuracion Config;

	public Main MainForm;

	private ToolTip t;

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

	internal virtual Button btImageOutput
	{
		[CompilerGenerated]
		get
		{
			return _btImageOutput;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btImageOutput_Click;
			DragEventHandler value3 = SteganoWizard_DragDrop2;
			DragEventHandler value4 = SteganoWizard_DragEnter;
			Button button = _btImageOutput;
			if (button != null)
			{
				button.Click -= value2;
				button.DragDrop -= value3;
				button.DragEnter -= value4;
			}
			_btImageOutput = value;
			button = _btImageOutput;
			if (button != null)
			{
				button.Click += value2;
				button.DragDrop += value3;
				button.DragEnter += value4;
			}
		}
	}

	internal virtual TextBox txtImageOutput
	{
		[CompilerGenerated]
		get
		{
			return _txtImageOutput;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DragEventHandler value2 = SteganoWizard_DragDrop2;
			DragEventHandler value3 = SteganoWizard_DragEnter;
			TextBox textBox = _txtImageOutput;
			if (textBox != null)
			{
				textBox.DragDrop -= value2;
				textBox.DragEnter -= value3;
			}
			_txtImageOutput = value;
			textBox = _txtImageOutput;
			if (textBox != null)
			{
				textBox.DragDrop += value2;
				textBox.DragEnter += value3;
			}
		}
	}

	[field: AccessedThroughProperty("lbImageOutput")]
	internal virtual Label lbImageOutput
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

	[field: AccessedThroughProperty("gbLinks")]
	internal virtual GroupBox gbLinks
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lbLinks")]
	internal virtual Label lbLinks
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

	internal virtual Button btSave
	{
		[CompilerGenerated]
		get
		{
			return _btSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btSave_Click;
			Button button = _btSave;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btSave = value;
			button = _btSave;
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

	[field: AccessedThroughProperty("txtQuality")]
	internal virtual TextBox txtQuality
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lbQuality")]
	internal virtual Label lbQuality
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtLinks")]
	internal virtual RichTextBox txtLinks
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("chkVisibleLinks")]
	internal virtual CheckBox chkVisibleLinks
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel helpVisibleLinks
	{
		[CompilerGenerated]
		get
		{
			return _helpVisibleLinks;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = helpVisibleLinks_MouseHover;
			EventHandler value3 = helpVisibleLinks_MouseLeave;
			EventHandler value4 = helpVisibleLinks_Click;
			LinkLabel linkLabel = _helpVisibleLinks;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_helpVisibleLinks = value;
			linkLabel = _helpVisibleLinks;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	internal virtual LinkLabel helpStegano
	{
		[CompilerGenerated]
		get
		{
			return _helpStegano;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = helpStegano_LinkClicked;
			LinkLabel linkLabel = _helpStegano;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked -= value2;
			}
			_helpStegano = value;
			linkLabel = _helpStegano;
			if (linkLabel != null)
			{
				linkLabel.LinkClicked += value2;
			}
		}
	}

	public SteganoWizardSave()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MegaDownloader.Stegano.SteganoWizardSave));
		this.gbIntro = new System.Windows.Forms.GroupBox();
		this.helpStegano = new System.Windows.Forms.LinkLabel();
		this.lbIntro = new System.Windows.Forms.Label();
		this.gbImage = new System.Windows.Forms.GroupBox();
		this.btImageOutput = new System.Windows.Forms.Button();
		this.txtImageOutput = new System.Windows.Forms.TextBox();
		this.lbImageOutput = new System.Windows.Forms.Label();
		this.lbImageInput = new System.Windows.Forms.Label();
		this.btImageInput = new System.Windows.Forms.Button();
		this.txtImageInput = new System.Windows.Forms.TextBox();
		this.lbImage = new System.Windows.Forms.Label();
		this.gbLinks = new System.Windows.Forms.GroupBox();
		this.helpVisibleLinks = new System.Windows.Forms.LinkLabel();
		this.chkVisibleLinks = new System.Windows.Forms.CheckBox();
		this.txtLinks = new System.Windows.Forms.RichTextBox();
		this.lbLinks = new System.Windows.Forms.Label();
		this.gbPassword = new System.Windows.Forms.GroupBox();
		this.txtQuality = new System.Windows.Forms.TextBox();
		this.lbQuality = new System.Windows.Forms.Label();
		this.lbPassword = new System.Windows.Forms.Label();
		this.lbPasswordTxt = new System.Windows.Forms.Label();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.btSave = new System.Windows.Forms.Button();
		this.btCancel = new System.Windows.Forms.Button();
		this.gbIntro.SuspendLayout();
		this.gbImage.SuspendLayout();
		this.gbLinks.SuspendLayout();
		this.gbPassword.SuspendLayout();
		base.SuspendLayout();
		this.gbIntro.Controls.Add(this.helpStegano);
		this.gbIntro.Controls.Add(this.lbIntro);
		this.gbIntro.Location = new System.Drawing.Point(12, 12);
		this.gbIntro.Name = "gbIntro";
		this.gbIntro.Size = new System.Drawing.Size(489, 187);
		this.gbIntro.TabIndex = 0;
		this.gbIntro.TabStop = false;
		this.gbIntro.Text = "Introduction";
		this.helpStegano.AutoSize = true;
		this.helpStegano.Location = new System.Drawing.Point(6, 157);
		this.helpStegano.Name = "helpStegano";
		this.helpStegano.Size = new System.Drawing.Size(151, 13);
		this.helpStegano.TabIndex = 1;
		this.helpStegano.TabStop = true;
		this.helpStegano.Text = "For more information click here";
		this.lbIntro.AutoSize = true;
		this.lbIntro.Location = new System.Drawing.Point(6, 28);
		this.lbIntro.MaximumSize = new System.Drawing.Size(480, 0);
		this.lbIntro.Name = "lbIntro";
		this.lbIntro.Size = new System.Drawing.Size(470, 117);
		this.lbIntro.TabIndex = 0;
		this.lbIntro.TabStop = true;
		this.lbIntro.Text = resources.GetString("lbIntro.Text");
		this.gbImage.Controls.Add(this.btImageOutput);
		this.gbImage.Controls.Add(this.txtImageOutput);
		this.gbImage.Controls.Add(this.lbImageOutput);
		this.gbImage.Controls.Add(this.lbImageInput);
		this.gbImage.Controls.Add(this.btImageInput);
		this.gbImage.Controls.Add(this.txtImageInput);
		this.gbImage.Controls.Add(this.lbImage);
		this.gbImage.Location = new System.Drawing.Point(12, 346);
		this.gbImage.Name = "gbImage";
		this.gbImage.Size = new System.Drawing.Size(489, 218);
		this.gbImage.TabIndex = 1;
		this.gbImage.TabStop = false;
		this.gbImage.Text = "Image to hide";
		this.btImageOutput.AllowDrop = true;
		this.btImageOutput.Location = new System.Drawing.Point(391, 177);
		this.btImageOutput.Name = "btImageOutput";
		this.btImageOutput.Size = new System.Drawing.Size(85, 23);
		this.btImageOutput.TabIndex = 7;
		this.btImageOutput.Text = "Browse";
		this.btImageOutput.UseVisualStyleBackColor = true;
		this.txtImageOutput.AllowDrop = true;
		this.txtImageOutput.Location = new System.Drawing.Point(15, 179);
		this.txtImageOutput.Name = "txtImageOutput";
		this.txtImageOutput.Size = new System.Drawing.Size(370, 20);
		this.txtImageOutput.TabIndex = 6;
		this.lbImageOutput.AutoSize = true;
		this.lbImageOutput.Location = new System.Drawing.Point(5, 152);
		this.lbImageOutput.Name = "lbImageOutput";
		this.lbImageOutput.Size = new System.Drawing.Size(73, 13);
		this.lbImageOutput.TabIndex = 5;
		this.lbImageOutput.Text = "Output image:";
		this.lbImageInput.AutoSize = true;
		this.lbImageInput.Location = new System.Drawing.Point(5, 91);
		this.lbImageInput.Name = "lbImageInput";
		this.lbImageInput.Size = new System.Drawing.Size(65, 13);
		this.lbImageInput.TabIndex = 4;
		this.lbImageInput.Text = "Input image:";
		this.btImageInput.Location = new System.Drawing.Point(391, 116);
		this.btImageInput.Name = "btImageInput";
		this.btImageInput.Size = new System.Drawing.Size(85, 23);
		this.btImageInput.TabIndex = 3;
		this.btImageInput.Text = "Browse";
		this.btImageInput.UseVisualStyleBackColor = true;
		this.txtImageInput.Location = new System.Drawing.Point(15, 118);
		this.txtImageInput.Name = "txtImageInput";
		this.txtImageInput.Size = new System.Drawing.Size(370, 20);
		this.txtImageInput.TabIndex = 2;
		this.lbImage.AutoSize = true;
		this.lbImage.Location = new System.Drawing.Point(6, 32);
		this.lbImage.MaximumSize = new System.Drawing.Size(480, 0);
		this.lbImage.Name = "lbImage";
		this.lbImage.Size = new System.Drawing.Size(455, 52);
		this.lbImage.TabIndex = 1;
		this.lbImage.Text = "Select an existing image as \"Input image\", and then select or create a new JPEG image as the \"Output image\".\r\nThe input image can be an existing file or an image URL.\r\n\r\n";
		this.gbLinks.Controls.Add(this.helpVisibleLinks);
		this.gbLinks.Controls.Add(this.chkVisibleLinks);
		this.gbLinks.Controls.Add(this.txtLinks);
		this.gbLinks.Controls.Add(this.lbLinks);
		this.gbLinks.Location = new System.Drawing.Point(12, 205);
		this.gbLinks.Name = "gbLinks";
		this.gbLinks.Size = new System.Drawing.Size(489, 135);
		this.gbLinks.TabIndex = 2;
		this.gbLinks.TabStop = false;
		this.gbLinks.Text = "Links";
		this.helpVisibleLinks.AutoSize = true;
		this.helpVisibleLinks.Location = new System.Drawing.Point(457, 27);
		this.helpVisibleLinks.Name = "helpVisibleLinks";
		this.helpVisibleLinks.Size = new System.Drawing.Size(19, 13);
		this.helpVisibleLinks.TabIndex = 7;
		this.helpVisibleLinks.TabStop = true;
		this.helpVisibleLinks.Text = "[?]";
		this.chkVisibleLinks.AutoSize = true;
		this.chkVisibleLinks.Location = new System.Drawing.Point(301, 27);
		this.chkVisibleLinks.MinimumSize = new System.Drawing.Size(150, 0);
		this.chkVisibleLinks.Name = "chkVisibleLinks";
		this.chkVisibleLinks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.chkVisibleLinks.Size = new System.Drawing.Size(150, 17);
		this.chkVisibleLinks.TabIndex = 6;
		this.chkVisibleLinks.Text = "Visible links";
		this.chkVisibleLinks.UseVisualStyleBackColor = true;
		this.txtLinks.Location = new System.Drawing.Point(9, 56);
		this.txtLinks.Name = "txtLinks";
		this.txtLinks.Size = new System.Drawing.Size(467, 68);
		this.txtLinks.TabIndex = 5;
		this.txtLinks.Text = "";
		this.lbLinks.AutoSize = true;
		this.lbLinks.Location = new System.Drawing.Point(6, 27);
		this.lbLinks.Name = "lbLinks";
		this.lbLinks.Size = new System.Drawing.Size(214, 13);
		this.lbLinks.TabIndex = 4;
		this.lbLinks.Text = "Enter one or more MEGA links to be hidden.\r\n";
		this.gbPassword.Controls.Add(this.txtQuality);
		this.gbPassword.Controls.Add(this.lbQuality);
		this.gbPassword.Controls.Add(this.lbPassword);
		this.gbPassword.Controls.Add(this.lbPasswordTxt);
		this.gbPassword.Controls.Add(this.txtPassword);
		this.gbPassword.Location = new System.Drawing.Point(12, 570);
		this.gbPassword.Name = "gbPassword";
		this.gbPassword.Size = new System.Drawing.Size(489, 117);
		this.gbPassword.TabIndex = 3;
		this.gbPassword.TabStop = false;
		this.gbPassword.Text = "Other options";
		this.txtQuality.Location = new System.Drawing.Point(346, 74);
		this.txtQuality.Name = "txtQuality";
		this.txtQuality.Size = new System.Drawing.Size(25, 20);
		this.txtQuality.TabIndex = 10;
		this.txtQuality.Text = "85";
		this.lbQuality.AutoSize = true;
		this.lbQuality.Location = new System.Drawing.Point(250, 77);
		this.lbQuality.MaximumSize = new System.Drawing.Size(90, 0);
		this.lbQuality.MinimumSize = new System.Drawing.Size(90, 0);
		this.lbQuality.Name = "lbQuality";
		this.lbQuality.Size = new System.Drawing.Size(90, 13);
		this.lbQuality.TabIndex = 9;
		this.lbQuality.Text = "JPEG Quality:";
		this.lbQuality.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.lbPassword.AutoSize = true;
		this.lbPassword.Location = new System.Drawing.Point(6, 29);
		this.lbPassword.MaximumSize = new System.Drawing.Size(480, 0);
		this.lbPassword.Name = "lbPassword";
		this.lbPassword.Size = new System.Drawing.Size(415, 13);
		this.lbPassword.TabIndex = 8;
		this.lbPassword.Text = "Optionally, you can specify the JPEG quality and a password. If not, just leave it empty.";
		this.lbPasswordTxt.AutoSize = true;
		this.lbPasswordTxt.Location = new System.Drawing.Point(7, 77);
		this.lbPasswordTxt.MaximumSize = new System.Drawing.Size(90, 0);
		this.lbPasswordTxt.MinimumSize = new System.Drawing.Size(90, 0);
		this.lbPasswordTxt.Name = "lbPasswordTxt";
		this.lbPasswordTxt.Size = new System.Drawing.Size(90, 13);
		this.lbPasswordTxt.TabIndex = 8;
		this.lbPasswordTxt.Text = "Password:";
		this.lbPasswordTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtPassword.Location = new System.Drawing.Point(103, 74);
		this.txtPassword.MaxLength = 256;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = '*';
		this.txtPassword.Size = new System.Drawing.Size(141, 20);
		this.txtPassword.TabIndex = 8;
		this.btSave.Location = new System.Drawing.Point(12, 693);
		this.btSave.Name = "btSave";
		this.btSave.Size = new System.Drawing.Size(85, 23);
		this.btSave.TabIndex = 8;
		this.btSave.Text = "Save";
		this.btSave.UseVisualStyleBackColor = true;
		this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btCancel.Location = new System.Drawing.Point(416, 693);
		this.btCancel.Name = "btCancel";
		this.btCancel.Size = new System.Drawing.Size(85, 23);
		this.btCancel.TabIndex = 9;
		this.btCancel.Text = "Cancel";
		this.btCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.btSave;
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btCancel;
		base.ClientSize = new System.Drawing.Size(513, 726);
		base.Controls.Add(this.btCancel);
		base.Controls.Add(this.btSave);
		base.Controls.Add(this.gbPassword);
		base.Controls.Add(this.gbLinks);
		base.Controls.Add(this.gbImage);
		base.Controls.Add(this.gbIntro);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.HelpButton = true;
		base.Icon = MegaDownloader.My.Resources.Resources.icono;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SteganoWizardSave";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "SteganoWizard";
		this.gbIntro.ResumeLayout(false);
		this.gbIntro.PerformLayout();
		this.gbImage.ResumeLayout(false);
		this.gbImage.PerformLayout();
		this.gbLinks.ResumeLayout(false);
		this.gbLinks.PerformLayout();
		this.gbPassword.ResumeLayout(false);
		this.gbPassword.PerformLayout();
		base.ResumeLayout(false);
	}

	private void Translate()
	{
		Text = Language.GetText("Steganography Wizard");
		gbIntro.Text = Language.GetText("Introduction");
		gbImage.Text = Language.GetText("Image to load");
		gbPassword.Text = Language.GetText("Other options");
		btCancel.Text = Language.GetText("Cancel");
		btSave.Text = Language.GetText("Save");
		lbIntro.Text = Language.GetText("Steganography is the art and science ... SAVE");
		lbQuality.Text = Language.GetText("JPEG Quality") + ":";
		lbPasswordTxt.Text = Language.GetText("Password") + ":";
		btImageInput.Text = Language.GetText("Browse");
		btImageOutput.Text = Language.GetText("Browse");
		lbLinks.Text = Language.GetText("Enter one or more MEGA links to be hidden");
		lbImage.Text = Language.GetText("Select an existing image as Input image ...");
		lbImageInput.Text = Language.GetText("Input image") + ":";
		lbImageOutput.Text = Language.GetText("Output image") + ":";
		lbPassword.Text = Language.GetText("Optionally, you can specify the JPEG quality and a password. If not, just leave it empty");
		chkVisibleLinks.Text = Language.GetText("Visible links");
		helpStegano.Text = Language.GetText("For more information about stegano click here");
	}

	private void ScreenLoad(object sender, EventArgs e)
	{
		Screen screen = Screen.FromPoint(base.Location);
		base.Location = checked(new Point((int)Math.Round((double)(screen.WorkingArea.Right - base.Width) / 2.0), (int)Math.Round((double)(screen.WorkingArea.Bottom - base.Height) / 2.0)));
		Translate();
	}

	private void btSave_Click(object sender, EventArgs e)
	{
		btSave.Enabled = false;
		btCancel.Enabled = false;
		DateTime now = DateAndTime.Now;
		try
		{
			if (URLExtractor.ExtraerURLs(txtLinks.Text).Count == 0)
			{
				throw new ApplicationException(Language.GetText("Links not valid"));
			}
			if (string.IsNullOrEmpty(txtImageInput.Text))
			{
				throw new ApplicationException(Language.GetText("Input image not specified"));
			}
			if (string.IsNullOrEmpty(txtImageOutput.Text))
			{
				throw new ApplicationException(Language.GetText("Output image not specified"));
			}
			if (!File.Exists(txtImageInput.Text) && !IsValidUri(txtImageInput.Text))
			{
				throw new ApplicationException(Language.GetText("Input image does not exist"));
			}
			if (!Versioned.IsNumeric(txtQuality.Text) || Conversions.ToInteger(txtQuality.Text) < 10 || Conversions.ToInteger(txtQuality.Text) > 100)
			{
				throw new ApplicationException(Language.GetText("Invalid JPEG quality"));
			}
			new SteganoManager().CreateImage(((!chkVisibleLinks.Checked) ? "{HIDDEN}" : "") + txtLinks.Text, txtImageInput.Text, txtImageOutput.Text, Conversions.ToInteger(txtQuality.Text), txtPassword.Text);
			MessageBox.Show(string.Format(Language.GetText("The image was created successfully in {0} ms"), DateAndTime.Now.Subtract(now).TotalMilliseconds.ToString("F2")), Language.GetText("Save"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (ApplicationException ex)
		{
			ProjectData.SetProjectError(ex);
			ApplicationException ex2 = ex;
			MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteError("Error trying to generate stegano: " + ex4.ToString());
			MessageBox.Show(ex4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		btCancel.Enabled = true;
		btSave.Enabled = true;
		btSave.Text = Language.GetText("Save");
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
		openFileDialog.Filter = Language.GetText("Images") + "|*.jpg;*.png;*.bmp;*.gif";
		openFileDialog.Multiselect = false;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			txtImageInput.Text = openFileDialog.FileName;
		}
		openFileDialog.Dispose();
	}

	private void btImageOutput_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.CheckFileExists = false;
		saveFileDialog.DefaultExt = "jpg";
		saveFileDialog.Filter = Language.GetText("Images") + " (*.jpg)|*.jpg";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			txtImageOutput.Text = saveFileDialog.FileName;
		}
		saveFileDialog.Dispose();
	}

	private string MsgVisibleLinksHelp()
	{
		return Language.GetText("Visible links HELP");
	}

	private void helpVisibleLinks_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(helpVisibleLinks, MsgVisibleLinksHelp());
	}

	private void helpVisibleLinks_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(helpVisibleLinks);
		}
	}

	private void helpVisibleLinks_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgVisibleLinksHelp(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void helpStegano_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

	private void HelpButtonPressed()
	{
		helpStegano_LinkClicked(null, null);
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

	private void SteganoWizard_DragDrop2(object sender, DragEventArgs e)
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
				txtImageOutput.Text = text2;
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
