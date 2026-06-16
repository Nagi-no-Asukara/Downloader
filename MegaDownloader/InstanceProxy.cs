using System;
using System.Security.Permissions;

namespace MegaDownloader;

[Serializable]
[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
public class InstanceProxy : MarshalByRefObject
{
	private static bool m_IsFirstInstance;

	private static string[] m_CommandLineArgs;

	public static bool IsFirstInstance
	{
		get
		{
			return m_IsFirstInstance;
		}
		set
		{
			m_IsFirstInstance = value;
		}
	}

	public static string[] CommandLineArgs
	{
		get
		{
			return m_CommandLineArgs;
		}
		set
		{
			m_CommandLineArgs = value;
		}
	}

	public void SetCommandLineArgs(bool isFirstInstance__1, string[] commandLineArgs__2)
	{
		IsFirstInstance = isFirstInstance__1;
		CommandLineArgs = commandLineArgs__2;
	}
}
