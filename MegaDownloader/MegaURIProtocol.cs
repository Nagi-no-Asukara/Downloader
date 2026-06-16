using System;
using System.Security;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace MegaDownloader;

public class MegaURIProtocol
{
	public const string UrlProtocol = "mega";

	public static Exception RegisterUrlProtocol()
	{
		Exception result;
		try
		{
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("mega", writable: false);
			if (registryKey == null)
			{
				registryKey = Registry.ClassesRoot.CreateSubKey("mega");
				registryKey.SetValue("", "URL: mega Protocol");
				registryKey.SetValue("URL Protocol", "");
				registryKey = registryKey.CreateSubKey("shell\\open\\command");
				registryKey.SetValue("", "\"" + Application.ExecutablePath + "\" %1");
				Log.WriteError("MEGA URI protocol added to registry.");
			}
			else
			{
				registryKey = registryKey.OpenSubKey("shell\\open\\command", writable: false);
				string text = "\"" + Application.ExecutablePath + "\" %1";
				if (registryKey == null)
				{
					registryKey = Registry.ClassesRoot.CreateSubKey("mega\\shell\\open\\command");
				}
				if (registryKey == null || registryKey.GetValue("") == null || Operators.CompareString(Conversions.ToString(registryKey.GetValue("")), text, TextCompare: false) != 0)
				{
					registryKey = Registry.ClassesRoot.OpenSubKey("mega\\shell\\open\\command", writable: true);
					registryKey.SetValue("", text);
				}
			}
			registryKey?.Close();
			result = null;
		}
		catch (UnauthorizedAccessException ex)
		{
			ProjectData.SetProjectError(ex);
			UnauthorizedAccessException ex2 = ex;
			Log.WriteError("SECURITY ERROR: Not enough privileges to access the registry. MEGA URI protocol could not be entered. Execute the application with administrator privileges (at least one time) in order to access the registry. Please note that if you move the application, you will have to execute it again with administrator privileges.");
			result = ex2;
			ProjectData.ClearProjectError();
		}
		catch (SecurityException ex3)
		{
			ProjectData.SetProjectError(ex3);
			SecurityException ex4 = ex3;
			Log.WriteError("SECURITY ERROR: Not enough privileges to access the registry. MEGA URI protocol could not be entered. Execute the application with administrator privileges (at least one time) in order to access the registry. Please note that if you move the application, you will have to execute it again with administrator privileges.");
			result = ex4;
			ProjectData.ClearProjectError();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			Log.WriteError("Error accessing the registry for registering MEGA URI protocol. Error: " + ex6.ToString());
			result = ex6;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsAdmin()
	{
		WindowsIdentity current = WindowsIdentity.GetCurrent();
		return new WindowsPrincipal(current).IsInRole(WindowsBuiltInRole.Administrator);
	}
}
