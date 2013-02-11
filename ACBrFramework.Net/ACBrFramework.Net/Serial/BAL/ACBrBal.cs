using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.BAL
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Serial.BAL.ico.bmp")]
	public sealed class ACBrBAL : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler<LePesoEventArgs> OnLePeso
		{
			add
			{
				onLePeso.Add(value);
			}
			remove
			{
				onLePeso.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<LePesoEventArgs, ACBrBALInterop.LePesoCallback> onLePeso;

		#endregion Fields

		#region Constructor

		public ACBrBAL()
		{
			onLePeso = new ACBrEventHandler<LePesoEventArgs, ACBrBALInterop.LePesoCallback>(this, OnLePesoCallback, ACBrBALInterop.BAL_SetOnLePeso);
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
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr BAL não inicializado.");
			}
		}

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrBALInterop.BAL_Create);
			Device = new ACBrDevice(this);
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

		[AllowReversePInvokeCalls]
		private void OnLePesoCallback(double value)
		{
			if (onLePeso.IsAssigned)
			{
				LePesoEventArgs e = new LePesoEventArgs();
				e.Peso = Convert.ToDecimal(value);
				onLePeso.Raise(e);
			}
		}

		#endregion EventHandlers

		#endregion Methods
	}
}