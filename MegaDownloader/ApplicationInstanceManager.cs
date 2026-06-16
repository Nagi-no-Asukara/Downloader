using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using MegaDownloader.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public sealed class ApplicationInstanceManager
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D0
	{
		public List<string> _0024VB_0024Local_args;

		public _Closure_0024__5_002D0(_Closure_0024__5_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_args = arg0._0024VB_0024Local_args;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(bool x)
		{
			MyApplication.Main_Form.ProcessArgs(_0024VB_0024Local_args.ToArray());
			MyApplication.Main_Form.Activate();
		}
	}

	private static DateTime _getParametersLastCheck = DateTime.MinValue;

	private ApplicationInstanceManager()
	{
	}

	public static bool CreateSingleInstance(string name, EventHandler<InstanceCallbackEventArgs> callback)
	{
		EventWaitHandle eventWaitHandle = null;
		string name2 = $"{Environment.MachineName}-{name}";
		InstanceProxy.IsFirstInstance = false;
		InstanceProxy.CommandLineArgs = Environment.GetCommandLineArgs();
		try
		{
			eventWaitHandle = EventWaitHandle.OpenExisting(name2);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			InstanceProxy.IsFirstInstance = true;
			ProjectData.ClearProjectError();
		}
		if (InstanceProxy.IsFirstInstance)
		{
			eventWaitHandle = new EventWaitHandle(initialState: false, EventResetMode.AutoReset, name2);
			ThreadPool.RegisterWaitForSingleObject(eventWaitHandle, WaitOrTimerCallback, callback, -1, executeOnlyOnce: false);
			eventWaitHandle.Close();
			RegisterRemoteType(name);
		}
		else
		{
			UpdateRemoteObject(name);
			eventWaitHandle?.Set();
			Environment.Exit(0);
		}
		return InstanceProxy.IsFirstInstance;
	}

	private static void UpdateRemoteObject(string uri)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Internal");
		Mutex.MEGAUriParameters.WaitOne();
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			text = Path.Combine(text, "Buffer.dat");
			using StreamWriter streamWriter = new StreamWriter(text, append: true);
			streamWriter.Write(string.Join("|", InstanceProxy.CommandLineArgs));
		}
		finally
		{
			Mutex.MEGAUriParameters.ReleaseMutex();
		}
	}

	internal static bool GetParameters()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Internal/Buffer.dat");
		if (File.Exists(path) && (DateTime.Compare(_getParametersLastCheck, DateTime.MinValue) == 0 || DateTime.Compare(File.GetLastWriteTimeUtc(path), _getParametersLastCheck.ToUniversalTime()) > 0))
		{
			Mutex.MEGAUriParameters.WaitOne();
			try
			{
				_Closure_0024__5_002D0 arg = default(_Closure_0024__5_002D0);
				_Closure_0024__5_002D0 CS_0024_003C_003E8__locals5 = new _Closure_0024__5_002D0(arg);
				CS_0024_003C_003E8__locals5._0024VB_0024Local_args = new List<string>();
				using (StreamReader streamReader = new StreamReader(path))
				{
					while (!streamReader.EndOfStream)
					{
						string[] array = streamReader.ReadLine().Split('|');
						if (CS_0024_003C_003E8__locals5._0024VB_0024Local_args.Count > 0)
						{
							array = array.Skip(1).ToArray();
						}
						CS_0024_003C_003E8__locals5._0024VB_0024Local_args.AddRange(array);
					}
				}
				using (StreamWriter streamWriter = new StreamWriter(path, append: false))
				{
					streamWriter.Write("");
				}
				_getParametersLastCheck = DateAndTime.Now;
				if (CS_0024_003C_003E8__locals5._0024VB_0024Local_args.Count > 0)
				{
					Action<bool> method = [SpecialName] (bool x) =>
					{
						MyApplication.Main_Form.ProcessArgs(CS_0024_003C_003E8__locals5._0024VB_0024Local_args.ToArray());
						MyApplication.Main_Form.Activate();
					};
					MyApplication.Main_Form.Invoke(method, true);
					return true;
				}
			}
			finally
			{
				Mutex.MEGAUriParameters.ReleaseMutex();
			}
		}
		return false;
	}

	private static void RegisterRemoteType(string uri)
	{
	}

	private static void WaitOrTimerCallback(object state, bool timedOut)
	{
		if (state is EventHandler<InstanceCallbackEventArgs> eventHandler)
		{
			eventHandler(RuntimeHelpers.GetObjectValue(state), new InstanceCallbackEventArgs(InstanceProxy.IsFirstInstance, InstanceProxy.CommandLineArgs));
		}
	}
}
