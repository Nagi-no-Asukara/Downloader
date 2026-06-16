using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace MegaDownloader;

public class ClipboardViewer : NativeWindow, IDisposable
{
	private const int WM_CHANGECBCHAIN = 781;

	private const int WM_CLIPBOARDUPDATE = 797;

	private const int WM_DESTROY = 2;

	private const int WM_DRAWCLIPBOARD = 776;

	private const string CS_CLIPBOARD_VIEWER_IGNORE = "Clipboard Viewer Ignore";

	private bool _firstUse;

	private bool _disposed;

	private IntPtr _installedHandle;

	private IntPtr _nextViewerHandle;

	public bool ClearOnReceive;

	public bool IsInstalled => !_installedHandle.Equals(IntPtr.Zero);

	public event EventHandler<HandledEventArgs> ClipboardChanged;

	[DllImport("user32")]
	private static extern IntPtr SetClipboardViewer(IntPtr hWnd);

	[DllImport("user32")]
	private static extern int ChangeClipboardChain(IntPtr hWnd, IntPtr hWndNext);

	[DllImport("user32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool AddClipboardFormatListener(IntPtr hwnd);

	[DllImport("user32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

	[DllImport("user32", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

	public ClipboardViewer()
	{
		_installedHandle = IntPtr.Zero;
		_nextViewerHandle = IntPtr.Zero;
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			Uninstall();
			_disposed = true;
		}
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	protected override void WndProc(ref Message m)
	{
		switch (m.Msg)
		{
		case 781:
			if (m.WParam == _nextViewerHandle)
			{
				_nextViewerHandle = m.LParam;
			}
			else if (!_nextViewerHandle.Equals(IntPtr.Zero))
			{
				SendMessage(_nextViewerHandle, m.Msg, m.WParam, m.LParam);
			}
			break;
		case 776:
			if (!_firstUse)
			{
				_firstUse = !_firstUse;
			}
			else if (!Clipboard.ContainsData("Clipboard Viewer Ignore"))
			{
				OnClipboardChanged();
			}
			if (!_nextViewerHandle.Equals(IntPtr.Zero))
			{
				SendMessage(_nextViewerHandle, m.Msg, m.WParam, m.LParam);
			}
			break;
		case 797:
			if (!Clipboard.ContainsData("Clipboard Viewer Ignore"))
			{
				OnClipboardChanged();
			}
			break;
		case 2:
			Uninstall();
			base.WndProc(ref m);
			return;
		default:
			base.WndProc(ref m);
			return;
		}
		m.Result = IntPtr.Zero;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
	protected override void OnHandleChange()
	{
		Uninstall();
		base.OnHandleChange();
	}

	public void Install()
	{
		Uninstall();
		if (!base.Handle.Equals(IntPtr.Zero))
		{
			if (IsVista())
			{
				AddClipboardFormatListener(base.Handle);
				return;
			}
			_nextViewerHandle = SetClipboardViewer(base.Handle);
			_installedHandle = base.Handle;
		}
	}

	public void Uninstall()
	{
		if (!_installedHandle.Equals(IntPtr.Zero))
		{
			if (IsVista())
			{
				RemoveClipboardFormatListener(_installedHandle);
				return;
			}
			ChangeClipboardChain(_installedHandle, _nextViewerHandle);
			_nextViewerHandle = IntPtr.Zero;
			_installedHandle = IntPtr.Zero;
		}
	}

	private static bool IsVista()
	{
		return (Environment.OSVersion.Platform == PlatformID.Win32NT) & (Environment.OSVersion.Version.Major >= 6);
	}

	protected virtual void OnClipboardChanged()
	{
		HandledEventArgs e = new HandledEventArgs(defaultHandledValue: false);
		ClipboardChanged?.Invoke(this, e);
		if (e.Handled && ClearOnReceive)
		{
			Clipboard.Clear();
		}
		else
		{
			if (!e.Handled)
			{
				return;
			}
			IDataObject dataObject = Clipboard.GetDataObject();
			if (dataObject != null)
			{
				DataObject dataObject2 = new DataObject("Clipboard Viewer Ignore", 0);
				string[] formats = dataObject.GetFormats(autoConvert: false);
				foreach (string format in formats)
				{
					dataObject2.SetData(format, autoConvert: true, RuntimeHelpers.GetObjectValue(dataObject.GetData(format)));
				}
				Clipboard.Clear();
				Clipboard.SetDataObject(dataObject2, copy: true);
			}
		}
	}
}
