using System;

namespace MegaDownloader;

public class InstanceCallbackEventArgs : EventArgs
{
	private bool m_IsFirstInstance;

	private string[] m_CommandLineArgs;

	public bool IsFirstInstance
	{
		get
		{
			return m_IsFirstInstance;
		}
		private set
		{
			m_IsFirstInstance = value;
		}
	}

	public string[] CommandLineArgs
	{
		get
		{
			return m_CommandLineArgs;
		}
		private set
		{
			m_CommandLineArgs = value;
		}
	}

	public InstanceCallbackEventArgs(bool isFirstInstance__1, string[] commandLineArgs__2)
	{
		IsFirstInstance = isFirstInstance__1;
		CommandLineArgs = commandLineArgs__2;
	}
}
