using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;

using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class ELCAccountHelper : IDisposable
{
	public class Account
	{
		public SecureString User;

		public SecureString Key;

		public string Alias;

		public string URL;

		public bool DefaultAccount;
	}

	private List<Account> _AccountList;

	private bool disposedValue;

	public ELCAccountHelper(ref Configuracion Config)
	{
		_AccountList = new List<Account>();
		foreach (Account eLCAccount in Config.ELCAccounts)
		{
			Account item = new Account
			{
				User = eLCAccount.User.Copy(),
				Key = eLCAccount.Key.Copy(),
				Alias = eLCAccount.Alias,
				URL = eLCAccount.URL,
				DefaultAccount = eLCAccount.DefaultAccount
			};
			_AccountList.Add(item);
		}
	}

	public List<Account> GetAccounts()
	{
		return _AccountList;
	}

	public Account GetDefaultAccount()
	{
		return GetAccounts().FirstOrDefault([SpecialName] (Account c) => c.DefaultAccount);
	}

	public Account GetAccountDetailsByURL(string URL)
	{
		return GetAccounts().FirstOrDefault([SpecialName] (Account c) => Operators.CompareString(c.URL.ToLower().Trim(), URL.ToLower().Trim(), TextCompare: false) == 0);
	}

	public Account GetAccountDetailsByAlias(string Alias)
	{
		return GetAccounts().FirstOrDefault([SpecialName] (Account c) => Operators.CompareString(c.Alias.ToLower().Trim(), Alias.ToLower().Trim(), TextCompare: false) == 0);
	}

	public bool ModifyAccountDetails(string URLPreviousAccount, Account NewAccount)
	{
		Account c = GetAccountDetailsByURL(URLPreviousAccount);
		if (c == null)
		{
			return false;
		}
		Account accountDetailsByURL = GetAccountDetailsByURL(NewAccount.URL);
		if (accountDetailsByURL != null && !accountDetailsByURL.Equals(c))
		{
			return false;
		}
		accountDetailsByURL = GetAccountDetailsByAlias(NewAccount.Alias);
		if (accountDetailsByURL != null && !accountDetailsByURL.Equals(c))
		{
			return false;
		}
		c.User.Dispose();
		c.Key.Dispose();
		c.URL = NewAccount.URL;
		c.Alias = NewAccount.Alias;
		c.User = NewAccount.User;
		c.Key = NewAccount.Key;
		c.DefaultAccount = NewAccount.DefaultAccount;
		ReAssignDefault(ref c);
		return true;
	}

	public bool AddNewAccount(Account NewAccount)
	{
		if (GetAccountDetailsByAlias(NewAccount.Alias) != null)
		{
			return false;
		}
		if (GetAccountDetailsByURL(NewAccount.URL) != null)
		{
			return false;
		}
		_AccountList.Add(NewAccount);
		ReAssignDefault(ref NewAccount);
		return true;
	}

	public bool DeleteAccount(string URL)
	{
		Account accountDetailsByURL = GetAccountDetailsByURL(URL);
		bool result;
		if (accountDetailsByURL == null)
		{
			result = false;
		}
		else
		{
			result = _AccountList.Remove(accountDetailsByURL);
			accountDetailsByURL.User.Dispose();
			accountDetailsByURL.Key.Dispose();
			Account c = null;
			ReAssignDefault(ref c);
		}
		return result;
	}

	private void ReAssignDefault(ref Account c)
	{
		if (c != null && c.DefaultAccount)
		{
			foreach (Account account in _AccountList)
			{
				if (!c.Equals(account))
				{
					account.DefaultAccount = false;
				}
			}
			return;
		}
		bool flag = false;
		foreach (Account account2 in _AccountList)
		{
			if (account2.DefaultAccount)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			IOrderedEnumerable<Account> source = _AccountList.OrderBy([SpecialName] (Account a) => a.Alias);
			if (source.Count() > 0)
			{
				source.ElementAtOrDefault(0).DefaultAccount = true;
			}
		}
	}

	public void SaveToConfig(ref Configuracion Config)
	{
		foreach (Account eLCAccount in Config.ELCAccounts)
		{
			eLCAccount.User.Dispose();
			eLCAccount.Key.Dispose();
		}
		Config.ELCAccounts.Clear();
		foreach (Account account2 in _AccountList)
		{
			Account account = new Account();
			account.User = account2.User.Copy();
			account.Key = account2.Key.Copy();
			account.DefaultAccount = account2.DefaultAccount;
			account.URL = account2.URL;
			account.Alias = account2.Alias;
			Config.ELCAccounts.Add(account);
		}
	}

	public bool ImportConfig(List<string> ConfigList, ref Main MainForm)
	{
		if (ConfigList == null || ConfigList.Count == 0)
		{
			return false;
		}
		List<Account> list = new List<Account>();
		string text = "";
		checked
		{
			foreach (string Config in ConfigList)
			{
				string text2 = Config.Replace("\\:", "{TEMP_PUNTOS}");
				if (!((text2.Split(':').Length == 3) | (text2.Split(':').Length == 4)))
				{
					continue;
				}
				int num = 0;
				string text3 = "";
				string input = "";
				string input2 = "";
				string alias = "";
				string[] array = text2.Split(':');
				for (int i = 0; i < array.Length; i++)
				{
					string text4 = Uri.UnescapeDataString(array[i].Replace("{TEMP_PUNTOS}", ":"));
					switch (num)
					{
					case 0:
						text3 = text4;
						break;
					case 1:
						input = text4;
						break;
					case 2:
						input2 = text4;
						break;
					case 3:
						alias = text4;
						break;
					}
					num++;
				}
				Account account = new Account();
				account.URL = text3;
				account.User = Criptografia.ToSecureString(input);
				account.Key = Criptografia.ToSecureString(input2);
				account.Alias = alias;
				if (string.IsNullOrEmpty(account.Alias))
				{
					account.Alias = text3;
				}
				list.Add(account);
				if (text.Length > 0)
				{
					text += ", ";
				}
				text += text3;
			}
			if (list.Count == 0)
			{
				return false;
			}
			MainForm.Activate();
			if (MessageBox.Show(Language.GetText("Do you want to import the configuration for the following ELC accounts?") + "\r\n\r\n" + text, Language.GetText("Confirmation"), MessageBoxButtons.YesNo) == DialogResult.No)
			{
				return false;
			}
			foreach (Account item in list)
			{
				if (!ModifyAccountDetails(item.URL, item))
				{
					AddNewAccount(item);
				}
			}
			MessageBox.Show(Language.GetText("Data saved successfully"), Language.GetText("Save"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return true;
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			foreach (Account account in _AccountList)
			{
				account.User.Dispose();
				account.Key.Dispose();
			}
			_AccountList.Clear();
		}
		disposedValue = true;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
