using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class ELCAccountControl : UserControl
{
	private IContainer components;

	[CompilerGenerated]
	[AccessedThroughProperty("dgELCUsers")]
	private DataGridView _dgELCUsers;

	internal GroupBox GroupBox8;

	internal Label Label7;

	internal Label lblELCApiKey;

	internal TextBox txtELCAccountUser;

	internal TextBox txtELCAccountKey;

	[CompilerGenerated]
	[AccessedThroughProperty("chkELCAccountShowPassword")]
	private CheckBox _chkELCAccountShowPassword;

	[CompilerGenerated]
	[AccessedThroughProperty("lklELCShowPassword")]
	private LinkLabel _lklELCShowPassword;

	internal TextBox txtELCAccountAlias;

	internal Label Label3;

	[CompilerGenerated]
	[AccessedThroughProperty("lklELCAliasAccount")]
	private LinkLabel _lklELCAliasAccount;

	[CompilerGenerated]
	[AccessedThroughProperty("btnELCAccountDelete")]
	private Button _btnELCAccountDelete;

	[CompilerGenerated]
	[AccessedThroughProperty("btnELCAccountModify")]
	private Button _btnELCAccountModify;

	[CompilerGenerated]
	[AccessedThroughProperty("btnELCAccountAddNew")]
	private Button _btnELCAccountAddNew;

	internal CheckBox chkELCAccountMain;

	[CompilerGenerated]
	[AccessedThroughProperty("lklELCMainAccount")]
	private LinkLabel _lklELCMainAccount;

	internal Label lblELCUrl;

	internal TextBox txtELCAccountURL;

	[CompilerGenerated]
	[AccessedThroughProperty("lklELCUrl")]
	private LinkLabel _lklELCUrl;

	internal GroupBox GroupBox9;

	internal Label lblInfoELC;

	internal GroupBox GroupBox10;

	public const string PASSWORDDEFECTO = "*****";

	private const string PREFIX_MAIN_ACCOUNT = "[*] ";

	public Configuracion Config;

	private ELCAccountHelper ELCAccountH;

	private ToolTip t;

	private string ELCURLBeingEdited;

	private string ELCAliasBeingEdited;

	private string ELCAccountAction;

	internal virtual DataGridView dgELCUsers
	{
		[CompilerGenerated]
		get
		{
			return _dgELCUsers;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PaintEventHandler value2 = dgELCUsers_Paint;
			DataGridViewCellEventHandler value3 = dgSELUsers_CellClick;
			DataGridView dataGridView = _dgELCUsers;
			if (dataGridView != null)
			{
				dataGridView.Paint -= value2;
				dataGridView.CellClick -= value3;
			}
			_dgELCUsers = value;
			dataGridView = _dgELCUsers;
			if (dataGridView != null)
			{
				dataGridView.Paint += value2;
				dataGridView.CellClick += value3;
			}
		}
	}

	internal virtual CheckBox chkELCAccountShowPassword
	{
		[CompilerGenerated]
		get
		{
			return _chkELCAccountShowPassword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chkELCAccountShowPassword_CheckedChanged;
			CheckBox checkBox = _chkELCAccountShowPassword;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_chkELCAccountShowPassword = value;
			checkBox = _chkELCAccountShowPassword;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual LinkLabel lklELCShowPassword
	{
		[CompilerGenerated]
		get
		{
			return _lklELCShowPassword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lklELCShowPassword_MouseHover;
			EventHandler value3 = lklELCShowPassword_MouseLeave;
			EventHandler value4 = lklELCShowPassword_Click;
			LinkLabel linkLabel = _lklELCShowPassword;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_lklELCShowPassword = value;
			linkLabel = _lklELCShowPassword;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	internal virtual LinkLabel lklELCAliasAccount
	{
		[CompilerGenerated]
		get
		{
			return _lklELCAliasAccount;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lklELCAliasAccount_MouseHover;
			EventHandler value3 = lklELCAliasAccount_MouseLeave;
			EventHandler value4 = lklELCAliasAccount_Click;
			LinkLabel linkLabel = _lklELCAliasAccount;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_lklELCAliasAccount = value;
			linkLabel = _lklELCAliasAccount;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	internal virtual Button btnELCAccountDelete
	{
		[CompilerGenerated]
		get
		{
			return _btnELCAccountDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnELCAccountDelete_Click;
			Button button = _btnELCAccountDelete;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnELCAccountDelete = value;
			button = _btnELCAccountDelete;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnELCAccountModify
	{
		[CompilerGenerated]
		get
		{
			return _btnELCAccountModify;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnELCAccountModify_Click;
			Button button = _btnELCAccountModify;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnELCAccountModify = value;
			button = _btnELCAccountModify;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnELCAccountAddNew
	{
		[CompilerGenerated]
		get
		{
			return _btnELCAccountAddNew;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnELCAccountAddNew_Click;
			Button button = _btnELCAccountAddNew;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnELCAccountAddNew = value;
			button = _btnELCAccountAddNew;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual LinkLabel lklELCMainAccount
	{
		[CompilerGenerated]
		get
		{
			return _lklELCMainAccount;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lklELCMainAccount_MouseHover;
			EventHandler value3 = lklELCMainAccount_MouseLeave;
			EventHandler value4 = lklELCMainAccount_Click;
			LinkLabel linkLabel = _lklELCMainAccount;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_lklELCMainAccount = value;
			linkLabel = _lklELCMainAccount;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
			}
		}
	}

	internal virtual LinkLabel lklELCUrl
	{
		[CompilerGenerated]
		get
		{
			return _lklELCUrl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lklELCUrl_MouseHover;
			EventHandler value3 = lklELCUrl_MouseLeave;
			EventHandler value4 = lklELCUrl_Click;
			LinkLabel linkLabel = _lklELCUrl;
			if (linkLabel != null)
			{
				linkLabel.MouseHover -= value2;
				linkLabel.MouseLeave -= value3;
				linkLabel.Click -= value4;
			}
			_lklELCUrl = value;
			linkLabel = _lklELCUrl;
			if (linkLabel != null)
			{
				linkLabel.MouseHover += value2;
				linkLabel.MouseLeave += value3;
				linkLabel.Click += value4;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MegaDownloader.ELCAccountControl));
		this.GroupBox10 = new System.Windows.Forms.GroupBox();
		this.lblInfoELC = new System.Windows.Forms.Label();
		this.GroupBox9 = new System.Windows.Forms.GroupBox();
		this.lklELCUrl = new System.Windows.Forms.LinkLabel();
		this.txtELCAccountURL = new System.Windows.Forms.TextBox();
		this.lblELCUrl = new System.Windows.Forms.Label();
		this.lklELCMainAccount = new System.Windows.Forms.LinkLabel();
		this.chkELCAccountMain = new System.Windows.Forms.CheckBox();
		this.btnELCAccountAddNew = new System.Windows.Forms.Button();
		this.btnELCAccountModify = new System.Windows.Forms.Button();
		this.btnELCAccountDelete = new System.Windows.Forms.Button();
		this.lklELCAliasAccount = new System.Windows.Forms.LinkLabel();
		this.Label3 = new System.Windows.Forms.Label();
		this.txtELCAccountAlias = new System.Windows.Forms.TextBox();
		this.lklELCShowPassword = new System.Windows.Forms.LinkLabel();
		this.chkELCAccountShowPassword = new System.Windows.Forms.CheckBox();
		this.txtELCAccountKey = new System.Windows.Forms.TextBox();
		this.txtELCAccountUser = new System.Windows.Forms.TextBox();
		this.lblELCApiKey = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.GroupBox8 = new System.Windows.Forms.GroupBox();
		this.dgELCUsers = new System.Windows.Forms.DataGridView();
		this.GroupBox10.SuspendLayout();
		this.GroupBox9.SuspendLayout();
		this.GroupBox8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgELCUsers).BeginInit();
		base.SuspendLayout();
		this.GroupBox10.Controls.Add(this.lblInfoELC);
		this.GroupBox10.Location = new System.Drawing.Point(3, 3);
		this.GroupBox10.Name = "GroupBox10";
		this.GroupBox10.Size = new System.Drawing.Size(607, 99);
		this.GroupBox10.TabIndex = 5;
		this.GroupBox10.TabStop = false;
		this.GroupBox10.Text = "Información";
		this.lblInfoELC.AutoSize = true;
		this.lblInfoELC.Location = new System.Drawing.Point(7, 20);
		this.lblInfoELC.MaximumSize = new System.Drawing.Size(590, 0);
		this.lblInfoELC.Name = "lblInfoELC";
		this.lblInfoELC.Size = new System.Drawing.Size(573, 65);
		this.lblInfoELC.TabIndex = 0;
		this.lblInfoELC.Text = resources.GetString("lblInfoELC.Text");
		this.GroupBox9.Controls.Add(this.lklELCUrl);
		this.GroupBox9.Controls.Add(this.txtELCAccountURL);
		this.GroupBox9.Controls.Add(this.lblELCUrl);
		this.GroupBox9.Controls.Add(this.lklELCMainAccount);
		this.GroupBox9.Controls.Add(this.chkELCAccountMain);
		this.GroupBox9.Controls.Add(this.btnELCAccountAddNew);
		this.GroupBox9.Controls.Add(this.btnELCAccountModify);
		this.GroupBox9.Controls.Add(this.btnELCAccountDelete);
		this.GroupBox9.Controls.Add(this.lklELCAliasAccount);
		this.GroupBox9.Controls.Add(this.Label3);
		this.GroupBox9.Controls.Add(this.txtELCAccountAlias);
		this.GroupBox9.Controls.Add(this.lklELCShowPassword);
		this.GroupBox9.Controls.Add(this.chkELCAccountShowPassword);
		this.GroupBox9.Controls.Add(this.txtELCAccountKey);
		this.GroupBox9.Controls.Add(this.txtELCAccountUser);
		this.GroupBox9.Controls.Add(this.lblELCApiKey);
		this.GroupBox9.Controls.Add(this.Label7);
		this.GroupBox9.Location = new System.Drawing.Point(261, 108);
		this.GroupBox9.Name = "GroupBox9";
		this.GroupBox9.Size = new System.Drawing.Size(349, 264);
		this.GroupBox9.TabIndex = 4;
		this.GroupBox9.TabStop = false;
		this.GroupBox9.Text = "Datos de cuenta ELC";
		this.lklELCUrl.AutoSize = true;
		this.lklELCUrl.Location = new System.Drawing.Point(103, 48);
		this.lklELCUrl.Name = "lklELCUrl";
		this.lklELCUrl.Size = new System.Drawing.Size(19, 13);
		this.lklELCUrl.TabIndex = 27;
		this.lklELCUrl.TabStop = true;
		this.lklELCUrl.Text = "[?]";
		this.txtELCAccountURL.Location = new System.Drawing.Point(128, 45);
		this.txtELCAccountURL.Name = "txtELCAccountURL";
		this.txtELCAccountURL.Size = new System.Drawing.Size(215, 20);
		this.txtELCAccountURL.TabIndex = 26;
		this.lblELCUrl.AutoSize = true;
		this.lblELCUrl.Location = new System.Drawing.Point(39, 48);
		this.lblELCUrl.MinimumSize = new System.Drawing.Size(65, 0);
		this.lblELCUrl.Name = "lblELCUrl";
		this.lblELCUrl.Size = new System.Drawing.Size(65, 13);
		this.lblELCUrl.TabIndex = 25;
		this.lblELCUrl.Text = "URL:";
		this.lblELCUrl.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.lklELCMainAccount.AutoSize = true;
		this.lklELCMainAccount.Location = new System.Drawing.Point(148, 123);
		this.lklELCMainAccount.Name = "lklELCMainAccount";
		this.lklELCMainAccount.Size = new System.Drawing.Size(19, 13);
		this.lklELCMainAccount.TabIndex = 24;
		this.lklELCMainAccount.TabStop = true;
		this.lklELCMainAccount.Text = "[?]";
		this.chkELCAccountMain.AutoSize = true;
		this.chkELCAccountMain.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chkELCAccountMain.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chkELCAccountMain.Location = new System.Drawing.Point(22, 122);
		this.chkELCAccountMain.MinimumSize = new System.Drawing.Size(120, 0);
		this.chkELCAccountMain.Name = "chkELCAccountMain";
		this.chkELCAccountMain.Size = new System.Drawing.Size(120, 17);
		this.chkELCAccountMain.TabIndex = 23;
		this.chkELCAccountMain.Text = "Cuenta principal";
		this.chkELCAccountMain.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.chkELCAccountMain.UseVisualStyleBackColor = false;
		this.btnELCAccountAddNew.Location = new System.Drawing.Point(8, 235);
		this.btnELCAccountAddNew.Name = "btnELCAccountAddNew";
		this.btnELCAccountAddNew.Size = new System.Drawing.Size(96, 23);
		this.btnELCAccountAddNew.TabIndex = 20;
		this.btnELCAccountAddNew.Text = "Add new";
		this.btnELCAccountAddNew.UseVisualStyleBackColor = true;
		this.btnELCAccountModify.Location = new System.Drawing.Point(128, 235);
		this.btnELCAccountModify.Name = "btnELCAccountModify";
		this.btnELCAccountModify.Size = new System.Drawing.Size(96, 23);
		this.btnELCAccountModify.TabIndex = 21;
		this.btnELCAccountModify.Text = "Modify";
		this.btnELCAccountModify.UseVisualStyleBackColor = true;
		this.btnELCAccountDelete.Location = new System.Drawing.Point(247, 235);
		this.btnELCAccountDelete.Name = "btnELCAccountDelete";
		this.btnELCAccountDelete.Size = new System.Drawing.Size(96, 23);
		this.btnELCAccountDelete.TabIndex = 22;
		this.btnELCAccountDelete.Text = "Delete";
		this.btnELCAccountDelete.UseVisualStyleBackColor = true;
		this.lklELCAliasAccount.AutoSize = true;
		this.lklELCAliasAccount.Location = new System.Drawing.Point(103, 22);
		this.lklELCAliasAccount.Name = "lklELCAliasAccount";
		this.lklELCAliasAccount.Size = new System.Drawing.Size(19, 13);
		this.lklELCAliasAccount.TabIndex = 12;
		this.lklELCAliasAccount.TabStop = true;
		this.lklELCAliasAccount.Text = "[?]";
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(39, 22);
		this.Label3.MinimumSize = new System.Drawing.Size(65, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(65, 13);
		this.Label3.TabIndex = 11;
		this.Label3.Text = "Alias:";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtELCAccountAlias.Location = new System.Drawing.Point(128, 19);
		this.txtELCAccountAlias.Name = "txtELCAccountAlias";
		this.txtELCAccountAlias.Size = new System.Drawing.Size(215, 20);
		this.txtELCAccountAlias.TabIndex = 13;
		this.lklELCShowPassword.AutoSize = true;
		this.lklELCShowPassword.Location = new System.Drawing.Point(320, 123);
		this.lklELCShowPassword.Name = "lklELCShowPassword";
		this.lklELCShowPassword.Size = new System.Drawing.Size(19, 13);
		this.lklELCShowPassword.TabIndex = 19;
		this.lklELCShowPassword.TabStop = true;
		this.lklELCShowPassword.Text = "[?]";
		this.chkELCAccountShowPassword.AutoSize = true;
		this.chkELCAccountShowPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chkELCAccountShowPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chkELCAccountShowPassword.Location = new System.Drawing.Point(198, 123);
		this.chkELCAccountShowPassword.MinimumSize = new System.Drawing.Size(120, 0);
		this.chkELCAccountShowPassword.Name = "chkELCAccountShowPassword";
		this.chkELCAccountShowPassword.Size = new System.Drawing.Size(120, 17);
		this.chkELCAccountShowPassword.TabIndex = 18;
		this.chkELCAccountShowPassword.Text = "Mostrar contraseña";
		this.chkELCAccountShowPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chkELCAccountShowPassword.UseVisualStyleBackColor = false;
		this.txtELCAccountKey.Location = new System.Drawing.Point(128, 97);
		this.txtELCAccountKey.MaxLength = 128;
		this.txtELCAccountKey.Name = "txtELCAccountKey";
		this.txtELCAccountKey.Size = new System.Drawing.Size(215, 20);
		this.txtELCAccountKey.TabIndex = 17;
		this.txtELCAccountKey.UseSystemPasswordChar = true;
		this.txtELCAccountUser.Location = new System.Drawing.Point(128, 71);
		this.txtELCAccountUser.Name = "txtELCAccountUser";
		this.txtELCAccountUser.Size = new System.Drawing.Size(215, 20);
		this.txtELCAccountUser.TabIndex = 15;
		this.lblELCApiKey.AutoSize = true;
		this.lblELCApiKey.Location = new System.Drawing.Point(47, 100);
		this.lblELCApiKey.MinimumSize = new System.Drawing.Size(75, 0);
		this.lblELCApiKey.Name = "lblELCApiKey";
		this.lblELCApiKey.Size = new System.Drawing.Size(75, 13);
		this.lblELCApiKey.TabIndex = 16;
		this.lblELCApiKey.Text = "API-Key:";
		this.lblELCApiKey.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.Label7.AutoSize = true;
		this.Label7.Location = new System.Drawing.Point(57, 74);
		this.Label7.MinimumSize = new System.Drawing.Size(65, 0);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(65, 13);
		this.Label7.TabIndex = 14;
		this.Label7.Text = "Usuario:";
		this.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.GroupBox8.Controls.Add(this.dgELCUsers);
		this.GroupBox8.Location = new System.Drawing.Point(3, 108);
		this.GroupBox8.Name = "GroupBox8";
		this.GroupBox8.Size = new System.Drawing.Size(252, 264);
		this.GroupBox8.TabIndex = 3;
		this.GroupBox8.TabStop = false;
		this.GroupBox8.Text = "Cuentas ELC";
		this.dgELCUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgELCUsers.Location = new System.Drawing.Point(7, 19);
		this.dgELCUsers.Name = "dgELCUsers";
		this.dgELCUsers.Size = new System.Drawing.Size(239, 239);
		this.dgELCUsers.TabIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.GroupBox10);
		base.Controls.Add(this.GroupBox9);
		base.Controls.Add(this.GroupBox8);
		base.Name = "ELCAccountControl";
		base.Size = new System.Drawing.Size(615, 375);
		this.GroupBox10.ResumeLayout(false);
		this.GroupBox10.PerformLayout();
		this.GroupBox9.ResumeLayout(false);
		this.GroupBox9.PerformLayout();
		this.GroupBox8.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgELCUsers).EndInit();
		base.ResumeLayout(false);
	}

	public ELCAccountControl()
	{
		ELCURLBeingEdited = "";
		ELCAliasBeingEdited = "";
		ELCAccountAction = "";
		InitializeComponent();
	}

	public void Cerrar()
	{
		ELCAccountH.Dispose();
	}

	public void SaveToConfig(ref Configuracion Config)
	{
		ELCAccountH.SaveToConfig(ref Config);
	}

	public void CargarDatos()
	{
		if (Config != null)
		{
			ELCAccountH = new ELCAccountHelper(ref Config);
			dgELCUsers.BackgroundColor = Color.Azure;
			DataGridViewCellStyle columnHeadersDefaultCellStyle = dgELCUsers.ColumnHeadersDefaultCellStyle;
			columnHeadersDefaultCellStyle.BackColor = Color.Snow;
			columnHeadersDefaultCellStyle.Font = new Font(dgELCUsers.Font, FontStyle.Bold);
			object _ = null;
			dgELCUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.SeaShell;
			object _2 = null;
			FillELCAccountDataGridView();
			dgELCUsers.ClearSelection();
			txtELCAccountKey.Enabled = false;
			txtELCAccountUser.Enabled = false;
			txtELCAccountURL.Enabled = false;
			txtELCAccountAlias.Enabled = false;
			chkELCAccountShowPassword.Enabled = false;
			chkELCAccountMain.Enabled = false;
			btnELCAccountAddNew.Enabled = true;
			btnELCAccountDelete.Enabled = false;
			btnELCAccountModify.Enabled = false;
			ELCURLBeingEdited = "";
			ELCAliasBeingEdited = "";
			DataGridViewTextBoxColumn obj = (DataGridViewTextBoxColumn)dgELCUsers.Columns[0];
			obj.Name = "E-mail";
			obj.ReadOnly = true;
			obj.Resizable = DataGridViewTriState.False;
			dgELCUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgELCUsers.RowHeadersVisible = false;
			dgELCUsers.ColumnHeadersVisible = false;
			Translate();
		}
	}

	private void Translate()
	{
		chkELCAccountShowPassword.Text = Language.GetText("Show password");
		Label7.Text = Language.GetText("User") + ":";
		btnELCAccountDelete.Text = Language.GetText("Delete");
		btnELCAccountModify.Text = Language.GetText("Modify");
		chkELCAccountMain.Text = Language.GetText("Main account");
		Label3.Text = Language.GetText("Alias") + ":";
		btnELCAccountAddNew.Text = Language.GetText("Add new");
		lblELCUrl.Text = Language.GetText("URL") + ":";
		lblELCApiKey.Text = Language.GetText("Key") + ":";
		GroupBox10.Text = Language.GetText("Information");
		lblELCUrl.Text = Language.GetText("URL") + ":";
		GroupBox8.Text = Language.GetText("ELC Accounts");
		GroupBox9.Text = Language.GetText("ELC Account Info");
		lblInfoELC.Text = Language.GetText("ELC Desc Info");
		lblELCApiKey.Text = Language.GetText("API-Key");
	}

	private void chkELCAccountShowPassword_CheckedChanged(object sender, EventArgs e)
	{
		txtELCAccountKey.UseSystemPasswordChar = !chkELCAccountShowPassword.Checked;
	}

	private void FillELCAccountDataGridView()
	{
		dgELCUsers.DataSource = (from c in ELCAccountH.GetAccounts()
			orderby c.DefaultAccount ? ("A" + c.Alias) : ("Z" + c.Alias)
			select new { AccountName = (c.DefaultAccount ? "[*] " : "") + c.Alias }).ToList();
	}

	private void dgELCUsers_Paint(object sender, PaintEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		if (Config != null && dataGridView != null && dataGridView.Rows.Count == 0)
		{
			using (Graphics graphics = e.Graphics)
			{
				graphics.DrawString(Language.GetText("Account list empty"), new Font(dgELCUsers.Font.FontFamily, dgELCUsers.Font.Size, FontStyle.Italic), Brushes.Black, new PointF(55f, 10f));
			}
		}
	}

	private void dgSELUsers_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		string text = Conversions.ToString(dgELCUsers.Rows[e.RowIndex].Cells[0].Value);
		if (text.StartsWith("[*] "))
		{
			text = text.Substring("[*] ".Length);
		}
		ELCAccountHelper.Account accountDetailsByAlias = ELCAccountH.GetAccountDetailsByAlias(text);
		if (accountDetailsByAlias != null)
		{
			txtELCAccountUser.Text = Criptografia.ToInsecureString(accountDetailsByAlias.User);
			txtELCAccountAlias.Text = accountDetailsByAlias.Alias;
			txtELCAccountURL.Text = accountDetailsByAlias.URL;
			txtELCAccountKey.Text = "*****";
			ELCURLBeingEdited = txtELCAccountURL.Text;
			ELCAliasBeingEdited = txtELCAccountAlias.Text;
			chkELCAccountMain.Checked = accountDetailsByAlias.DefaultAccount;
			btnELCAccountAddNew.Enabled = true;
			btnELCAccountDelete.Enabled = true;
			btnELCAccountModify.Enabled = true;
			ELCAccountAction = "EDIT";
			btnELCAccountAddNew.Text = Language.GetText("Add new");
			txtELCAccountKey.Enabled = true;
			txtELCAccountUser.Enabled = true;
			txtELCAccountURL.Enabled = true;
			txtELCAccountAlias.Enabled = true;
			chkELCAccountShowPassword.Enabled = true;
			chkELCAccountShowPassword.Checked = false;
			chkELCAccountMain.Enabled = true;
		}
		else
		{
			MessageBox.Show(Language.GetText("Account not found"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ELCURLBeingEdited = "";
			ELCAliasBeingEdited = "";
			btnELCAccountAddNew.Enabled = true;
			btnELCAccountDelete.Enabled = false;
			btnELCAccountModify.Enabled = false;
		}
	}

	private void btnELCAccountAddNew_Click(object sender, EventArgs e)
	{
		string eLCAccountAction = ELCAccountAction;
		if (Operators.CompareString(eLCAccountAction, "NEW", TextCompare: false) == 0)
		{
			if (string.IsNullOrEmpty(txtELCAccountURL.Text))
			{
				MessageBox.Show(Language.GetText("URL is mandatory"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			ELCAccountHelper.Account account = new ELCAccountHelper.Account();
			account.DefaultAccount = chkELCAccountMain.Checked;
			account.User = Criptografia.ToSecureString(txtELCAccountUser.Text);
			account.Key = Criptografia.ToSecureString(txtELCAccountKey.Text);
			account.Alias = txtELCAccountAlias.Text;
			account.URL = txtELCAccountURL.Text;
			if (string.IsNullOrEmpty(account.Alias))
			{
				account.Alias = txtELCAccountURL.Text;
			}
			if (ELCAccountH.AddNewAccount(account))
			{
				FillELCAccountDataGridView();
				ELCAccountAction = "EDIT";
				btnELCAccountAddNew.Text = Language.GetText("Add new");
				ELCURLBeingEdited = txtELCAccountURL.Text;
				ELCAliasBeingEdited = txtELCAccountAlias.Text;
				btnELCAccountDelete.Enabled = true;
				btnELCAccountModify.Enabled = true;
				chkELCAccountShowPassword.Checked = false;
				txtELCAccountKey.Text = "*****";
				dgELCUsers.ClearSelection();
				MessageBox.Show(Language.GetText("Account created correctly"), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show(Language.GetText("Account already exists"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			ELCAccountAction = "NEW";
			btnELCAccountAddNew.Text = Language.GetText("Save");
			btnELCAccountModify.Enabled = false;
			btnELCAccountDelete.Enabled = false;
			ELCURLBeingEdited = "";
			ELCAliasBeingEdited = "";
			txtELCAccountUser.Text = "";
			txtELCAccountAlias.Text = "";
			txtELCAccountKey.Text = "";
			txtELCAccountURL.Text = "";
			txtELCAccountKey.Enabled = true;
			txtELCAccountUser.Enabled = true;
			txtELCAccountURL.Enabled = true;
			txtELCAccountAlias.Enabled = true;
			chkELCAccountShowPassword.Enabled = true;
			chkELCAccountMain.Checked = false;
			chkELCAccountMain.Enabled = true;
			dgELCUsers.ClearSelection();
		}
	}

	private void btnELCAccountModify_Click(object sender, EventArgs e)
	{
		if (!((Operators.CompareString(ELCAccountAction, "EDIT", TextCompare: false) == 0) & !string.IsNullOrEmpty(ELCURLBeingEdited) & !string.IsNullOrEmpty(ELCAliasBeingEdited)))
		{
			return;
		}
		if (string.IsNullOrEmpty(txtELCAccountURL.Text))
		{
			MessageBox.Show(Language.GetText("URL is mandatory"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		ELCAccountHelper.Account account = new ELCAccountHelper.Account();
		account.DefaultAccount = chkELCAccountMain.Checked;
		account.User = Criptografia.ToSecureString(txtELCAccountUser.Text);
		account.Alias = txtELCAccountAlias.Text;
		account.URL = txtELCAccountURL.Text;
		if (string.IsNullOrEmpty(account.Alias))
		{
			account.Alias = txtELCAccountURL.Text;
		}
		if (Operators.CompareString(txtELCAccountKey.Text, "*****", TextCompare: false) == 0)
		{
			ELCAccountHelper.Account accountDetailsByURL = ELCAccountH.GetAccountDetailsByURL(ELCURLBeingEdited);
			if (accountDetailsByURL != null)
			{
				account.Key = accountDetailsByURL.Key.Copy();
			}
		}
		else
		{
			account.Key = Criptografia.ToSecureString(txtELCAccountKey.Text);
		}
		if (ELCAccountH.ModifyAccountDetails(ELCURLBeingEdited, account))
		{
			FillELCAccountDataGridView();
			ELCAccountAction = "EDIT";
			btnELCAccountAddNew.Text = Language.GetText("Add new");
			ELCURLBeingEdited = txtELCAccountURL.Text;
			ELCAliasBeingEdited = txtELCAccountAlias.Text;
			chkELCAccountShowPassword.Checked = false;
			txtELCAccountKey.Text = "*****";
			dgELCUsers.ClearSelection();
			MessageBox.Show(Language.GetText("Account modified correctly"), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			MessageBox.Show(Language.GetText("Account already exists"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnELCAccountDelete_Click(object sender, EventArgs e)
	{
		if ((!string.IsNullOrEmpty(ELCURLBeingEdited) & !string.IsNullOrEmpty(ELCAliasBeingEdited)) && MessageBox.Show(Language.GetText("Do you want to delete this account?"), Language.GetText("Confirmation"), MessageBoxButtons.YesNo) == DialogResult.Yes)
		{
			if (ELCAccountH.DeleteAccount(ELCURLBeingEdited))
			{
				FillELCAccountDataGridView();
				dgELCUsers.ClearSelection();
				txtELCAccountKey.Text = "";
				txtELCAccountUser.Text = "";
				txtELCAccountAlias.Text = "";
				txtELCAccountURL.Text = "";
				txtELCAccountKey.Enabled = false;
				txtELCAccountURL.Enabled = false;
				txtELCAccountAlias.Enabled = false;
				txtELCAccountUser.Enabled = false;
				chkELCAccountShowPassword.Enabled = false;
				chkELCAccountMain.Enabled = false;
				btnELCAccountAddNew.Enabled = true;
				btnELCAccountDelete.Enabled = false;
				btnELCAccountModify.Enabled = false;
				ELCURLBeingEdited = "";
				dgELCUsers.ClearSelection();
				MessageBox.Show(Language.GetText("Account deleted correctly"), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show(Language.GetText("Account could not be deleted"), Language.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void lklELCUrl_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(lklELCUrl, MsgUrlELCAccount());
	}

	private void lklELCUrl_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(lklELCUrl);
		}
	}

	private void lklELCUrl_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgUrlELCAccount(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private string MsgUrlELCAccount()
	{
		return Language.GetText("URL ELC account explanation");
	}

	private void lklELCAliasAccount_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(lklELCAliasAccount, MsgAliasELCAccount());
	}

	private void lklELCAliasAccount_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(lklELCAliasAccount);
		}
	}

	private void lklELCAliasAccount_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgAliasELCAccount(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private string MsgAliasELCAccount()
	{
		return Language.GetText("Alias ELC account explanation");
	}

	private void lklELCMainAccount_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(lklELCMainAccount, MsgDefaultELCAccount());
	}

	private void lklELCMainAccount_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(lklELCMainAccount);
		}
	}

	private void lklELCMainAccount_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgDefaultELCAccount(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private string MsgDefaultELCAccount()
	{
		return Language.GetText("Default ELC account explanation");
	}

	private void lklELCShowPassword_MouseHover(object sender, EventArgs e)
	{
		t = new ToolTip();
		t.SetToolTip(lklELCShowPassword, MsgELCShowPassword());
	}

	private void lklELCShowPassword_MouseLeave(object sender, EventArgs e)
	{
		if (t != null)
		{
			t.Hide(lklELCShowPassword);
		}
	}

	private void lklELCShowPassword_Click(object sender, EventArgs e)
	{
		MessageBox.Show(MsgELCShowPassword(), Language.GetText("Note"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private string MsgELCShowPassword()
	{
		return Language.GetText("Show password explanation");
	}
}
