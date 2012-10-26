﻿using System;
using System.Drawing;

namespace ACBrFramework
{
	[ToolboxBitmap(typeof(ACBrBAL), @"ACBrSerial.ACBrBAL.ico.bmp")]
	public sealed class ACBrBAL : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler<LePesoEventArgs> OnLePeso;

		#endregion Events

		#region Fields

		DoubleProcedureDelegate onLePeso;

		#endregion Fields

		#region Constructor

		public ACBrBAL()
		{
		}

		#endregion Constructor

		#region Properties

		public bool Ativo
		{
			get
			{
				return GetBool(ACBrBALInterop.BAL_GetAtivo);
			}
		}

		public ModeloBal Modelo
		{
			get
			{
				return (ModeloBal)GetInt32(ACBrBALInterop.BAL_GetModelo);
			}
			set
			{
				SetInt32(ACBrBALInterop.BAL_SetModelo, (int)value);
			}
		}

		public string ModeloStr
		{
			get
			{
				return GetString(ACBrBALInterop.BAL_GetModeloStr);
			}
		}

		public string Porta
		{
			get
			{
				return GetString(ACBrBALInterop.BAL_GetPorta);
			}
			set
			{
				SetString(ACBrBALInterop.BAL_SetPorta, value);
			}
		}

		public ACBrDevice Device { get; private set; }

		public bool MonitoraBalanca
		{
			get
			{
				return GetBool(ACBrBALInterop.BAL_GetMonitoraBalanca);
			}
			set
			{
				SetBool(ACBrBALInterop.BAL_SetMonitoraBalanca, value);
			}
		}

		public decimal UltimoPesoLido
		{
			get
			{
				return GetDecimal(ACBrBALInterop.BAL_GetUltimoPesoLido);
			}
		}

		public string UltimaResposta
		{
			get
			{
				return GetString(ACBrBALInterop.BAL_GetUltimaResposta);
			}
		}

		#endregion Properties

		#region Methods

		public void Ativar()
		{
			int ret = ACBrBALInterop.BAL_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrBALInterop.BAL_Desativar(this.Handle);
			CheckResult(ret);
		}

		public decimal LePeso()
		{
			const int DEFAULT_TIMEOUT = 3000;
			return LePeso(DEFAULT_TIMEOUT);
		}

		public decimal LePeso(int timeout)
		{
			double peso = 0;
			int ret = ACBrBALInterop.BAL_LePeso(this.Handle, timeout, ref peso);
			CheckResult(ret);

			return Convert.ToDecimal(peso);
		}

		#region Override Methods

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrBALInterop.BAL_GetUltimoErro);
					throw new ACBrECFException(error);

				case -2:

					throw new ACBrECFException("ACBr BAL não inicializado.");
			}
		}

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrBALInterop.BAL_Create);
			Device = new ACBrDevice(this);

			InitializeEvents();
		}

		private void InitializeEvents()
		{
			int ret;

			onLePeso = new DoubleProcedureDelegate(bal_OnLePeso);
			ret = ACBrBALInterop.BAL_SetOnLePeso(this.Handle, onLePeso);
			CheckResult(ret);
		}


		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrBALInterop.BAL_Destroy);
			}
		}

		#endregion Override Methods

		#region EventHandlers

		private void bal_OnLePeso(double value)
		{
			if (OnLePeso != null)
			{
				LePesoEventArgs e = new LePesoEventArgs();
				e.Peso = Convert.ToDecimal(value);
				OnLePeso(this, e);
			}
		}

		#endregion EventHandlers

		#endregion Methods
	}
}