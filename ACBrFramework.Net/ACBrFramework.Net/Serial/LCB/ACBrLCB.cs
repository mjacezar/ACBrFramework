using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.LCB
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Serial.LCB.ico.bmp")]
	public sealed class ACBrLCB : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler OnLeCodigo
		{
			add
			{
				onLeCodigo.Add(value);
			}
			remove
			{
				onLeCodigo.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<ACBrLCBInterop.LeCodigoCallback> onLeCodigo;

		#endregion Fields

		#region Constructor

		public ACBrLCB()
		{
			onLeCodigo = new ACBrEventHandler<ACBrLCBInterop.LeCodigoCallback>(this, OnLeCodigoCallback, ACBrLCBInterop.LCB_SetOnLeCodigo);
		}

		#endregion Constructor

		#region Properties

		public bool Ativo
		{
			get
			{
				return GetBool(ACBrLCBInterop.LCB_GetAtivo);
			}
		}

		public string Porta
		{
			get
			{
				return GetString(ACBrLCBInterop.LCB_GetPorta);
			}
			set
			{
				SetString(ACBrLCBInterop.LCB_SetPorta, value);
			}
		}

		public ACBrDevice Device { get; private set; }

		public string UltimoCodigo
		{
			get
			{
				return GetString(ACBrLCBInterop.LCB_GetUltimoErro);
			}
		}

		public string UltimaLeitura
		{
			get
			{
				return GetString(ACBrLCBInterop.LCB_GetUltimaLeitura);
			}
		}

		#endregion Properties

		#region Methods

		public void Ativar()
		{
			int ret = ACBrLCBInterop.LCB_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrLCBInterop.LCB_Desativar(this.Handle);
			CheckResult(ret);
		}

		public string LerString()
		{
			return GetString(ACBrLCBInterop.LCB_LerString);
		}

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnLeCodigoCallback()
		{
			if (onLeCodigo.IsAssigned)
			{
				onLeCodigo.Raise();
			}
		}

		#endregion Callback EventHandlers

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrLCBInterop.LCB_Create);
			Device = new ACBrDevice(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					const int BUFFER_LEN = 1024;
					string error = GetString(ACBrLCBInterop.LCB_GetUltimoErro, BUFFER_LEN);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr LCB não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrLCBInterop.LCB_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}