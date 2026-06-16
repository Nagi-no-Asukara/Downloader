using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MegaDownloader;

public class ThrottledStreamController
{
	private static System.Threading.Mutex Mutex = new System.Threading.Mutex();

	private static ThrottledStreamController _Controller;

	private List<ThrottledStream> _StreamList;

	private Dictionary<string, List<ThrottledStream>> _htId;

	private Dictionary<string, long> _htMaxSpeed;

	private long _globalMaxSpeed;

	public static ThrottledStreamController GetController()
	{
		Mutex.WaitOne();
		if (_Controller == null)
		{
			_Controller = new ThrottledStreamController();
		}
		Mutex.ReleaseMutex();
		return _Controller;
	}

	private ThrottledStreamController()
	{
		Mutex.WaitOne();
		_StreamList = new List<ThrottledStream>();
		_htId = new Dictionary<string, List<ThrottledStream>>();
		_htMaxSpeed = new Dictionary<string, long>();
		_globalMaxSpeed = 0L;
		Mutex.ReleaseMutex();
	}

	private void _RecalcularVelocidad()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Mutex.WaitOne();
		checked
		{
			try
			{
				if (_StreamList.Count == 0)
				{
					return;
				}
				long num = (long)Math.Round((double)_globalMaxSpeed / (double)_StreamList.Count);
				long num2 = 0L;
				List<ThrottledStream> list = new List<ThrottledStream>();
				foreach (string key in _htMaxSpeed.Keys)
				{
					long num3 = _htMaxSpeed[key];
					if (!((num3 > 0) & _htId.ContainsKey(key)))
					{
						continue;
					}
					int num4 = 0;
					foreach (ThrottledStream item in _htId[key])
					{
						if (_StreamList.Contains(item))
						{
							num4++;
						}
					}
					if (num4 == 0)
					{
						continue;
					}
					num3 = (long)Math.Round((double)num3 / (double)num4);
					if (unchecked(num3 > num && num > 0))
					{
						num3 = num;
					}
					foreach (ThrottledStream item2 in _htId[key])
					{
						if (_StreamList.Contains(item2))
						{
							list.Add(item2);
							item2.MaximumBytesPerSecond = num3;
							num2 += num3;
						}
					}
				}
				int num5 = 0;
				foreach (ThrottledStream stream in _StreamList)
				{
					if (!list.Contains(stream))
					{
						num5++;
					}
				}
				if (num5 > 0)
				{
					long num3 = (long)Math.Round((double)(_globalMaxSpeed - num2) / (double)num5);
					if (num3 < 0)
					{
						num3 = 0L;
					}
					foreach (ThrottledStream stream2 in _StreamList)
					{
						if (!list.Contains(stream2))
						{
							stream2.MaximumBytesPerSecond = num3;
						}
					}
				}
				foreach (ThrottledStream stream3 in _StreamList)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append("[").Append((int)Math.Round((double)stream3.MaximumBytesPerSecond / 1024.0)).Append("]");
				}
			}
			finally
			{
				Mutex.ReleaseMutex();
			}
			Log.WriteDebug("Speed limit recalculated: " + stringBuilder.ToString());
		}
	}

	public void AddStream(ref ThrottledStream Stream, string Id)
	{
		if (string.IsNullOrEmpty(Id) | (Stream == null))
		{
			throw new ArgumentNullException();
		}
		Mutex.WaitOne();
		if (!_StreamList.Contains(Stream))
		{
			_StreamList.Add(Stream);
			if (!_htId.ContainsKey(Id))
			{
				_htId[Id] = new List<ThrottledStream>();
			}
			if (!_htMaxSpeed.ContainsKey(Id))
			{
				_htMaxSpeed[Id] = 0L;
			}
			_htId[Id].Add(Stream);
		}
		Mutex.ReleaseMutex();
		_RecalcularVelocidad();
	}

	public void RemoveStream(ref ThrottledStream Stream)
	{
		if (Stream == null)
		{
			throw new ArgumentNullException();
		}
		Mutex.WaitOne();
		if (_StreamList.Contains(Stream))
		{
			_StreamList.Remove(Stream);
			string text = null;
			foreach (string key in _htId.Keys)
			{
				if (_htId[key].Contains(Stream))
				{
					_htId[key].Remove(Stream);
					if (_htId[key].Count == 0)
					{
						text = key;
					}
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				_htId.Remove(text);
			}
		}
		Mutex.ReleaseMutex();
		_RecalcularVelocidad();
	}

	public void SetMaxGlobalSpeed(long Bps)
	{
		Mutex.WaitOne();
		_globalMaxSpeed = Bps;
		Mutex.ReleaseMutex();
		_RecalcularVelocidad();
	}

	public void SetMaxSpeed(string Id, long Bps)
	{
		Mutex.WaitOne();
		_htMaxSpeed[Id] = Bps;
		Mutex.ReleaseMutex();
		_RecalcularVelocidad();
	}

	public void RemoveId(string Id)
	{
		if (Id == null)
		{
			throw new ArgumentNullException();
		}
		Mutex.WaitOne();
		if (_htMaxSpeed.ContainsKey(Id))
		{
			_htMaxSpeed.Remove(Id);
		}
		Mutex.ReleaseMutex();
		_RecalcularVelocidad();
	}

	public void Abortar()
	{
		Mutex.WaitOne();
		foreach (ThrottledStream stream in _StreamList)
		{
			stream.Abort();
		}
		Mutex.ReleaseMutex();
	}

	public void Abortar(string Id)
	{
		if (string.IsNullOrEmpty(Id))
		{
			throw new ArgumentNullException();
		}
		Mutex.WaitOne();
		if (_htId.ContainsKey(Id))
		{
			foreach (ThrottledStream stream in _StreamList)
			{
				if (_htId[Id].Contains(stream))
				{
					stream.Abort();
				}
			}
		}
		Mutex.ReleaseMutex();
	}

	public void Continuar()
	{
		Mutex.WaitOne();
		foreach (ThrottledStream stream in _StreamList)
		{
			stream.Continue();
		}
		Mutex.ReleaseMutex();
	}
}
