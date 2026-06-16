using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader;

public class ThrottledStream : Stream
{
	public const long Infinite = 0L;

	private Stream _baseStream;

	private long _maximumBytesPerSecond;

	private long _byteCount;

	private Stopwatch _start;

	private bool _abort;

	public long MaximumBytesPerSecond
	{
		get
		{
			return _maximumBytesPerSecond;
		}
		set
		{
			if (_maximumBytesPerSecond != value)
			{
				_maximumBytesPerSecond = value;
				Reset();
			}
		}
	}

	public override bool CanRead => _baseStream.CanRead;

	public override bool CanSeek => _baseStream.CanSeek;

	public override bool CanWrite => _baseStream.CanWrite;

	public override long Length => _baseStream.Length;

	public override long Position
	{
		get
		{
			return _baseStream.Position;
		}
		set
		{
			_baseStream.Position = value;
		}
	}

	public ThrottledStream(Stream baseStream)
		: this(baseStream, 0L)
	{
	}

	public ThrottledStream(Stream baseStream, long maximumBytesPerSecond)
	{
		if (baseStream == null)
		{
			throw new ArgumentNullException("baseStream");
		}
		if (maximumBytesPerSecond < 0)
		{
			throw new ArgumentOutOfRangeException("maximumBytesPerSecond", maximumBytesPerSecond, "The maximum number of bytes per second can't be negative.");
		}
		_baseStream = baseStream;
		_maximumBytesPerSecond = maximumBytesPerSecond;
		_start = new Stopwatch();
		_start.Start();
		_byteCount = 0L;
		_abort = false;
	}

	public override void Flush()
	{
		_baseStream.Flush();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		int num = _baseStream.Read(buffer, offset, count);
		Throttle(num);
		return num;
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return _baseStream.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		_baseStream.SetLength(value);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		Throttle(count);
		_baseStream.Write(buffer, offset, count);
	}

	public override string ToString()
	{
		return _baseStream.ToString();
	}

	public void Abort()
	{
		_abort = true;
	}

	public void Continue()
	{
		_abort = false;
	}

	protected void Throttle(int bufferSizeInBytes)
	{
		if (_maximumBytesPerSecond <= 0 || bufferSizeInBytes <= 0)
		{
			return;
		}
		checked
		{
			_byteCount += bufferSizeInBytes;
			double num = (double)(1000 * _start.ElapsedTicks) / (double)Stopwatch.Frequency;
			if (!(num > 0.0))
			{
				return;
			}
			if ((long)Math.Round((double)(_byteCount * 1000) / num) > _maximumBytesPerSecond)
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				int num2 = (int)Math.Round((double)(long)Math.Round((double)(_byteCount * 1000) / (double)_maximumBytesPerSecond) - num);
				if (num2 > 0)
				{
					try
					{
						DateTime dateTime = DateTime.Now.ToUniversalTime().AddMilliseconds(num2);
						while (dateTime.Subtract(DateTime.Now.ToUniversalTime()).TotalMilliseconds > 150.0)
						{
							Thread.Sleep(100);
							if (_abort)
							{
								dateTime = DateTime.Now.ToUniversalTime();
							}
						}
						num2 = (int)Math.Round(dateTime.Subtract(DateTime.Now.ToUniversalTime()).TotalMilliseconds);
						if (num2 > 0)
						{
							Thread.Sleep(num2);
						}
					}
					catch (ThreadAbortException ex)
					{
						ProjectData.SetProjectError(ex);
						ThreadAbortException ex2 = ex;
						ProjectData.ClearProjectError();
					}
				}
				stopwatch.Stop();
			}
			Reset();
		}
	}

	protected void Reset()
	{
		if ((double)checked(1000 * _start.ElapsedTicks) / (double)Stopwatch.Frequency > 1000.0)
		{
			_byteCount = 0L;
			_start.Stop();
			_start.Reset();
			_start.Start();
		}
	}
}
