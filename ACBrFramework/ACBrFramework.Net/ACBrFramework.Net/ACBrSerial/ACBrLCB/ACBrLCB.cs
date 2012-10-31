﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrLCB), @"ACBrSerial.ACBrLCB.ico.bmp")]
	public sealed class ACBrLCB : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler OnLeCodigo
		{
			add
			{
				bool isAssigned = onLeCodigoHandler != null;
				onLeCodigoHandler = (EventHandler)Delegate.Combine(onLeCodigoHandler, value);

				if (!isAssigned)
				{
					onLeCodigoCallback = new ProcedurePtrDelegate(lcb_OnLeCodigo);
					int ret = ACBrLCBInterop.LCB_SetOnLeCodigo(this.Handle, onLeCodigoCallback);
					CheckResult(ret);
				}
			}
			remove
			{
				onLeCodigoHandler = (EventHandler)Delegate.Remove(onLeCodigoHandler, value);

				if (onLeCodigoHandler == null)
				{
					int ret = ACBrLCBInterop.LCB_SetOnLeCodigo(this.Handle, null);
					CheckResult(ret);

					onLeCodigoCallback = null;
				}
			}
		}

		#endregion Events

		#region Fields

		private ProcedurePtrDelegate onLeCodigoCallback;
		private EventHandler onLeCodigoHandler;

		#endregion Fields

		#region Constructor

		public ACBrLCB()
		{
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

		#region EventHandlers

		[AllowReversePInvokeCalls]
		private void lcb_OnLeCodigo()
		{
			if (onLeCodigoHandler != null)
			{
				onLeCodigoHandler(this, EventArgs.Empty);
			}
		}

		#endregion EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrLCBInterop.LCB_Create);
			Device = new ACBrDevice(this);

			InitializeEvents();
		}

		private void InitializeEvents()
		{
			onLeCodigoCallback = new ProcedurePtrDelegate(lcb_OnLeCodigo);
			int ret = ACBrLCBInterop.LCB_SetOnLeCodigo(this.Handle, onLeCodigoCallback);
			CheckResult(ret);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					const int BUFFER_LEN = 1024;
					string error = GetString(ACBrLCBInterop.LCB_GetUltimoErro, BUFFER_LEN);
					throw new ACBrECFException(error);

				case -2:

					throw new ACBrECFException("ACBr LCB não inicializado.");
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