using System;

namespace ACBrFramework
{
	public abstract class ACBrClassInterop : ACBrInteropBase
	{
		#region Inner Types

		protected delegate int CreateEntryPointDelegate(ref IntPtr handle);

		protected delegate int DestroyEntryPointDelegate(ref IntPtr handle);

		#endregion Inner Types

		#region Fields

		private IntPtr handle;
		private bool list;

		#endregion Fields

		#region Properties

		public override IntPtr Handle
		{
			get
			{
				return handle;
			}
		}

		public override bool IsListed
		{
			get
			{
				return list;
			}
		}

		#endregion Properties

		#region Constructor

		static ACBrClassInterop()
		{

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
			//Isso é resolvido abrindo as propriedades do projeto EXECUTÁVEL,
			//na aba "Debug" e marcando a opção "Enable unmanaged code debugging"
			//-----------------------------------------------------------------
			//
			//Como a maioria dos usuários não adota esse procedimento,
			//a exception é coletada no Try/Catch e não é disparada
			//caso o ambiente seja DEBUG
			//
			//Note que o erro ocorre apenas quando roda dentro do VS por causa do Debugger com código nativo
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

		#region Dispose Methods

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				GC.SuppressFinalize(this);
			}

			OnDisposing();

			if (Disposed != null) Disposed(this, EventArgs.Empty);
		}

		public void Dispose()
		{
			this.Dispose(true);
		}

		#endregion Dispose Methods
	}
}
