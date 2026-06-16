using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class Log
{
	public enum LevelLogType
	{
		Minimal,
		Normal,
		Info,
		Debug
	}

	private static object _syncObject = RuntimeHelpers.GetObjectValue(new object());

	private static LevelLogType _LogLevel = LevelLogType.Normal;

	private static StringBuilder _Buffer = null;

	private static DateTime _LastWrite = DateAndTime.Now;

	public static LevelLogType SetLogLevel
	{
		set
		{
			_LogLevel = value;
		}
	}

	public static void WriteError(string Text)
	{
		WriteLog(Text, LevelLogType.Minimal);
	}

	public static void WriteWarning(string Text)
	{
		WriteLog(Text, LevelLogType.Normal);
	}

	public static void WriteInfo(string Text)
	{
		WriteLog(Text, LevelLogType.Info);
	}

	public static void WriteDebug(string Text)
	{
		WriteLog(Text, LevelLogType.Debug);
	}

	public static void WriteLog(string Text, LevelLogType Level)
	{
		if (_LogLevel < Level)
		{
			return;
		}
		object syncObject = _syncObject;
		ObjectFlowControl.CheckForSyncLockOnValueType(syncObject);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(syncObject, ref lockTaken);
			if (_Buffer == null)
			{
				_Buffer = new StringBuilder();
			}
			_Buffer.Append(DateAndTime.Now.ToString("s"));
			_Buffer.Append(":");
			_Buffer.Append(DateAndTime.Now.ToString("fff"));
			_Buffer.Append(" [ID#");
			_Buffer.Append(Thread.CurrentThread.ManagedThreadId);
			_Buffer.Append("] >>> ");
			_Buffer.AppendLine(Text);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(syncObject);
			}
		}
		Flush(forceFlush: false);
	}

	public static void Flush(bool forceFlush)
	{
		object syncObject = _syncObject;
		ObjectFlowControl.CheckForSyncLockOnValueType(syncObject);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(syncObject, ref lockTaken);
			if (((DateTime.Compare(_LastWrite.AddSeconds(10.0), DateAndTime.Now) < 0 || forceFlush) & (_Buffer != null)) && _Buffer.Length > 0)
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MegaDownloader/Log");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				using (StreamWriter streamWriter = new StreamWriter(text + "\\Log_" + DateAndTime.Now.ToString("yyyyMMdd") + ".txt", append: true))
				{
					streamWriter.Write(_Buffer.ToString());
				}
				_Buffer = null;
				_LastWrite = DateAndTime.Now;
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(syncObject);
			}
		}
	}
}
