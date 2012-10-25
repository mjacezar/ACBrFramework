﻿using System;
using System.Drawing;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrLCB), @"ACBrLCB.ico.bmp")]
	public sealed class ACBrLCB : ACBrComponent, IDisposable
	{
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

		#region Override Methods

		protected internal override void OnInitializeComponent()
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