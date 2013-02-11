using System;
using System.ComponentModel;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("F31FB210-ECDF-4050-9FAE-352D72700FD9")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	[DesignerCategory("ACBr")]
	[DesignTimeVisible(true)]
	public abstract class ACBrClassInterop : ACBrInteropBase, IDisposable
	{
		#region Inner Types

		protected delegate int CreateEntryPointDelegate(ref IntPtr handle);

		protected delegate int DestroyEntryPointDelegate(ref IntPtr handle);

		#endregion Inner Types

		#region Events

		public event System.EventHandler Disposed
		{
#if COM_INTEROP
			[ComVisible(false)]
#endif
			add
			{
				disposed += value;
			}
#if COM_INTEROP
			[ComVisible(false)]
#endif
			remove
			{
				disposed -= value;
			}
		}

		#endregion Events

		#region Fields

		private IntPtr handle;
		private System.EventHandler disposed;

		#endregion Fields

		#region Properties

		[Browsable(false)]
		public override IntPtr Handle
		{
			get
			{
				return handle;
			}
		}

		#endregion Properties

		#region Constructor

		protected ACBrClassInterop()
		{
			OnInitialize();
		}

		~ACBrClassInterop()
		{
			this.Dispose(false);
		}

		#endregion Constructor

		#region P/Invoke Helpers

		protected void CallCreate(CreateEntryPointDelegate entryPoint)
		{
			var ret = entryPoint(ref this.handle);
			CheckResult(ret);
		}

		protected void CallDestroy(DestroyEntryPointDelegate entryPoint)
		{
			#region Comments (Exception on Disposing)

			//Rodando dentro do Visual Studio
			//o Debugger causa um AccessViolationException
			//ao inspecionar a chamada ao entryPoint do Destroy
			//
			//-----------------------------------------------------------------
			//Isso � resolvido abrindo as propriedades do projeto EXECUT�VEL,
			//na aba "Debug" e marcando a op��o "Enable unmanaged code debugging"
			//-----------------------------------------------------------------
			//
			//Como a maioria dos usu�rios n�o adota esse procedimento,
			//a exception � coletada no Try/Catch e n�o � disparada
			//caso o ambiente seja DEBUG
			//
			//Note que o erro ocorre apenas quando roda dentro do VS por causa do Debugger com c�digo nativo
			//Tanto compilando em RELASE quanto DEBUG

			#endregion Comments (Exception on Disposing)

			try
			{
				var ret = entryPoint(ref this.handle);
				CheckResult(ret);
			}
			catch (AccessViolationException)
			{
#if !DEBUG
				throw;
#endif
			}
		}

		#endregion P/Invoke Helpers

		#region Abstract Methods

		protected internal abstract void OnInitialize();

		protected abstract void OnDisposing();

		#endregion Abstract Methods

		#region Dispose Methods

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				GC.SuppressFinalize(this);
			}

			OnDisposing();

			if (disposed != null) disposed(this, EventArgs.Empty);
		}

		public void Dispose()
		{
			this.Dispose(true);
		}

		#endregion Dispose Methods
	}
}
