using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace MegaDownloader.My;

[GeneratedCode("MyTemplate", "11.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Never)]
internal class MyApplication : WindowsFormsApplicationBase
{
	private static Main _mainFrm;

	internal static Main Main_Form
	{
		get
		{
			return _mainFrm;
		}
		set
		{
			_mainFrm = value;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	[STAThread]
	[DebuggerHidden]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static void Main(string[] Args)
	{
		Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
		MyProject.Application.Run(Args);
	}

	private void MyApplication_Startup(object sender, StartupEventArgs e)
	{
		if (ApplicationInstanceManager.CreateSingleInstance("MegaDownloader", SingleInstanceCallback))
		{
			MyProject.Application.MinimumSplashScreenDisplayTime = 600;
			AppDomain.CurrentDomain.AssemblyResolve += LoadDLLFromStream;
		}
	}

	private static void SingleInstanceCallback(object sender, InstanceCallbackEventArgs args)
	{
	}

	private Assembly LoadDLLFromStream(object sender, ResolveEventArgs args)
	{
		string endsWith = new AssemblyName(args.Name).Name + ".dll";
		endsWith = ResourceHelper.GetResourceName(endsWith);
		if (!string.IsNullOrEmpty(endsWith))
		{
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(endsWith))
			{
				byte[] array = new byte[checked((int)(stream.Length - 1) + 1)];
				stream.Read(array, 0, array.Length);
				return Assembly.Load(array);
			}
		}
		throw new ApplicationException("DLL could not be loaded: " + args.Name);
	}

	[DebuggerStepThrough]
	public MyApplication()
		: base(AuthenticationMode.Windows)
	{
		base.Startup += MyApplication_Startup;
		base.IsSingleInstance = false;
		base.EnableVisualStyles = true;
		base.SaveMySettingsOnExit = true;
		base.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
	}

	[DebuggerStepThrough]
	protected override void OnCreateMainForm()
	{
		base.MainForm = MyProject.Forms.Main;
	}
}
