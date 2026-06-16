using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MegaDownloader.Stegano;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace MegaDownloader.My;

[StandardModule]
[HideModuleName]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class MyProject
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	internal sealed class MyForms
	{
		[ThreadStatic]
		private static Hashtable m_FormBeingCreated;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddLinks m_AddLinks;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Cerrando m_Cerrando;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Configuration m_Configuration;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Credits m_Credits;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Descompresor m_Descompresor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ELCForm m_ELCForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EncodeLinksForm m_EncodeLinksForm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Main m_Main;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PantallaMsg m_PantallaMsg;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PropiedadesDescarga m_PropiedadesDescarga;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SplashScreen m_SplashScreen;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SteganoWizardLoad m_SteganoWizardLoad;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SteganoWizardSave m_SteganoWizardSave;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StreamingForm m_StreamingForm;

		public AddLinks AddLinks
		{
			get
			{
				m_AddLinks = Create__Instance__(m_AddLinks);
				return m_AddLinks;
			}
			set
			{
				if (value != m_AddLinks)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_AddLinks);
				}
			}
		}

		public Cerrando Cerrando
		{
			get
			{
				m_Cerrando = Create__Instance__(m_Cerrando);
				return m_Cerrando;
			}
			set
			{
				if (value != m_Cerrando)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Cerrando);
				}
			}
		}

		public Configuration Configuration
		{
			get
			{
				m_Configuration = Create__Instance__(m_Configuration);
				return m_Configuration;
			}
			set
			{
				if (value != m_Configuration)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Configuration);
				}
			}
		}

		public Credits Credits
		{
			get
			{
				m_Credits = Create__Instance__(m_Credits);
				return m_Credits;
			}
			set
			{
				if (value != m_Credits)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Credits);
				}
			}
		}

		public Descompresor Descompresor
		{
			get
			{
				m_Descompresor = Create__Instance__(m_Descompresor);
				return m_Descompresor;
			}
			set
			{
				if (value != m_Descompresor)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Descompresor);
				}
			}
		}

		public ELCForm ELCForm
		{
			get
			{
				m_ELCForm = Create__Instance__(m_ELCForm);
				return m_ELCForm;
			}
			set
			{
				if (value != m_ELCForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_ELCForm);
				}
			}
		}

		public EncodeLinksForm EncodeLinksForm
		{
			get
			{
				m_EncodeLinksForm = Create__Instance__(m_EncodeLinksForm);
				return m_EncodeLinksForm;
			}
			set
			{
				if (value != m_EncodeLinksForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_EncodeLinksForm);
				}
			}
		}

		public Main Main
		{
			get
			{
				m_Main = Create__Instance__(m_Main);
				return m_Main;
			}
			set
			{
				if (value != m_Main)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_Main);
				}
			}
		}

		public PantallaMsg PantallaMsg
		{
			get
			{
				m_PantallaMsg = Create__Instance__(m_PantallaMsg);
				return m_PantallaMsg;
			}
			set
			{
				if (value != m_PantallaMsg)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_PantallaMsg);
				}
			}
		}

		public PropiedadesDescarga PropiedadesDescarga
		{
			get
			{
				m_PropiedadesDescarga = Create__Instance__(m_PropiedadesDescarga);
				return m_PropiedadesDescarga;
			}
			set
			{
				if (value != m_PropiedadesDescarga)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_PropiedadesDescarga);
				}
			}
		}

		public SplashScreen SplashScreen
		{
			get
			{
				m_SplashScreen = Create__Instance__(m_SplashScreen);
				return m_SplashScreen;
			}
			set
			{
				if (value != m_SplashScreen)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_SplashScreen);
				}
			}
		}

		public SteganoWizardLoad SteganoWizardLoad
		{
			get
			{
				m_SteganoWizardLoad = Create__Instance__(m_SteganoWizardLoad);
				return m_SteganoWizardLoad;
			}
			set
			{
				if (value != m_SteganoWizardLoad)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_SteganoWizardLoad);
				}
			}
		}

		public SteganoWizardSave SteganoWizardSave
		{
			get
			{
				m_SteganoWizardSave = Create__Instance__(m_SteganoWizardSave);
				return m_SteganoWizardSave;
			}
			set
			{
				if (value != m_SteganoWizardSave)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_SteganoWizardSave);
				}
			}
		}

		public StreamingForm StreamingForm
		{
			get
			{
				m_StreamingForm = Create__Instance__(m_StreamingForm);
				return m_StreamingForm;
			}
			set
			{
				if (value != m_StreamingForm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_StreamingForm);
				}
			}
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T Instance) where T : Form, new()
		{
			if (Instance == null || Instance.IsDisposed)
			{
				if (m_FormBeingCreated != null)
				{
					if (m_FormBeingCreated.ContainsKey(typeof(T)))
					{
						throw new InvalidOperationException(Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_RecursiveFormCreate"));
					}
				}
				else
				{
					m_FormBeingCreated = new Hashtable();
				}
				m_FormBeingCreated.Add(typeof(T), null);
				try
				{
					return new T();
				}
				catch (TargetInvocationException ex) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					ProjectData.SetProjectError(ex);
					return ex.InnerException != null;
				}).Invoke())
				{
					throw new InvalidOperationException(Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_SeeInnerException", ex.InnerException.Message), ex.InnerException);
				}
				finally
				{
					m_FormBeingCreated.Remove(typeof(T));
				}
			}
			return Instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance) where T : Form
		{
			instance.Dispose();
			instance = null;
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyForms()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal new Type GetType()
		{
			return typeof(MyForms);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class MyWebServices
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		internal new Type GetType()
		{
			return typeof(MyWebServices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T instance) where T : new()
		{
			if (instance == null)
			{
				return new T();
			}
			return instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance)
		{
			instance = default(T);
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyWebServices()
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class ThreadSafeObjectProvider<T> where T : new()
	{
		[CompilerGenerated]
		[ThreadStatic]
		private static T m_ThreadStaticValue;

		internal T GetInstance
		{
			[DebuggerHidden]
			get
			{
				if (m_ThreadStaticValue == null)
				{
					m_ThreadStaticValue = new T();
				}
				return m_ThreadStaticValue;
			}
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ThreadSafeObjectProvider()
		{
		}
	}

	private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();

	private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();

	private static readonly ThreadSafeObjectProvider<User> m_UserObjectProvider = new ThreadSafeObjectProvider<User>();

	private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

	private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

	[HelpKeyword("My.Computer")]
	internal static MyComputer Computer
	{
		[DebuggerHidden]
		get
		{
			return m_ComputerObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Application")]
	internal static MyApplication Application
	{
		[DebuggerHidden]
		get
		{
			return m_AppObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.User")]
	internal static User User
	{
		[DebuggerHidden]
		get
		{
			return m_UserObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Forms")]
	internal static MyForms Forms
	{
		[DebuggerHidden]
		get
		{
			return m_MyFormsObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static MyWebServices WebServices
	{
		[DebuggerHidden]
		get
		{
			return m_MyWebServicesObjectProvider.GetInstance;
		}
	}
}
