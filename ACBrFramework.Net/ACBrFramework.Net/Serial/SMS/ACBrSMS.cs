using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.SMS
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.Serial.SMS.ico.bmp")]
	public sealed class ACBrSMS : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler OnProgresso
		{
			add
			{
				onProgresso.Add(value);
			}
			remove
			{
				onProgresso.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<ACBrSMSInterop.OnProgressoCallback> onProgresso;

		#endregion Fields

		#region Constructor

		public ACBrSMS()
		{
			onProgresso = new ACBrEventHandler<ACBrSMSInterop.OnProgressoCallback>(this, OnProgressoCallback, ACBrSMSInterop.SMS_SetOnProgresso);
		}

		#endregion Constructor

		#region Properties

		[Category("Modem")]
		public Modelo Modelo
		{
			get
			{
				return (Modelo)GetInt32(ACBrSMSInterop.SMS_GetModelo);
			}
			set
			{
				SetInt32(ACBrSMSInterop.SMS_SetModelo, (int)value);
			}
		}

		[Category("Modem")]
		public ACBrDevice Device { get; private set; }

		[Category("Opções")]
		public bool Ativo
		{
			get
			{
				return GetBool(ACBrSMSInterop.SMS_GetAtivo);
			}
			set
			{
				SetBool(ACBrSMSInterop.SMS_SetAtivo, value);
			}
		}

		[Category("Opções")]
		public bool ATResult
		{
			get
			{
				return GetBool(ACBrSMSInterop.SMS_GetATResult);
			}
			set
			{
				SetBool(ACBrSMSInterop.SMS_SetATResult, value);
			}
		}

		[Category("Opções")]
		public bool QuebraMensagens
		{
			get
			{
				return GetBool(ACBrSMSInterop.SMS_GetQuebraMensagens);
			}
			set
			{
				SetBool(ACBrSMSInterop.SMS_SetQuebraMensagens, value);
			}
		}

		[Category("Opções")]
		public bool RecebeConfirmacao
		{
			get
			{
				return GetBool(ACBrSMSInterop.SMS_GetRecebeConfirmacao);
			}
			set
			{
				SetBool(ACBrSMSInterop.SMS_SetRecebeConfirmacao, value);
			}
		}

		[Category("Opções")]
		public int ATTimeOut
		{
			get
			{
				return GetInt32(ACBrSMSInterop.SMS_GetATTimeOut);
			}
			set
			{
				SetInt32(ACBrSMSInterop.SMS_SetATTimeOut, value);
			}
		}

		[Category("Opções")]
		public int IntervaloEntreMensagens
		{
			get
			{
				return GetInt32(ACBrSMSInterop.SMS_GetIntervaloEntreMensagens);
			}
			set
			{
				SetInt32(ACBrSMSInterop.SMS_SetIntervaloEntreMensagens, value);
			}
		}

		[Category("Opções")]
		public int BandejasSimCard
		{
			get
			{
				return GetInt32(ACBrSMSInterop.SMS_GetBandejasSimCard);
			}
		}

		[Category("Opções")]
		public SimCard SimCard
		{
			get
			{
				return (SimCard)GetInt32(ACBrSMSInterop.SMS_GetSimCard);
			}
		}

		[Category("Opções")]
		public string UltimaResposta
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetUltimaResposta);
			}
		}

		[Category("Opções")]
		public string UltimoComando
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetUltimoComando);
			}
		}

		[Browsable(false)]
		public bool EmLinha
		{
			get
			{
				return GetBool(ACBrSMSInterop.SMS_GetEmLinha);
			}
		}

		[Browsable(false)]
		public string IMEI
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetIMEI);
			}
		}

		[Browsable(false)]
		public string IMSI
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetIMSI);
			}
		}

		[Browsable(false)]
		public string Operadora
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetOperadora);
			}
		}

		[Browsable(false)]
		public string Fabricante
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetFabricante);
			}
		}

		[Browsable(false)]
		public string ModeloModem
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetModeloModem);
			}
		}

		[Browsable(false)]
		public string Firmware
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_GetFirmware);
			}
		}

		[Browsable(false)]
		public Sincronismo EstadoSincronismo
		{
			get
			{
				return (Sincronismo)GetInt32(ACBrSMSInterop.SMS_GetEstadoSincronismo);
			}
		}

		[Browsable(false)]
		public decimal NivelSinal
		{
			get
			{
				return GetDecimal(ACBrSMSInterop.SMS_GetNivelSinal);
			}
		}

		#endregion Properties

		#region Methods

		public void Ativar()
		{
			int ret = ACBrSMSInterop.SMS_Ativar(this.Handle);
			CheckResult(ret);
		}

		public void Desativar()
		{
			int ret = ACBrSMSInterop.SMS_Desativar(this.Handle);
			CheckResult(ret);
		}

		public void EnviarSMS(string telefone, string mensagem, ref string AIndice)
		{
			const int bufferLen = 512;
			StringBuilder buffer = new StringBuilder(bufferLen);
			int ret = ACBrSMSInterop.SMS_EnviarSMS(this.Handle, ToUTF8(telefone), ToUTF8(mensagem), buffer, bufferLen);
			CheckResult(ret);

			AIndice = buffer.ToString();
		}

		public void EnviarSMSLote(Mensagems menssagens, ref string AIndice)
		{
			const int bufferLen = 512;
			StringBuilder buffer = new StringBuilder(bufferLen);
			menssagens.Iniciar();
			for (int i = 0; i < menssagens.Count; i++)
			{
				int resp = ACBrSMSInterop.MSG_Add(menssagens.Handle, ToUTF8(menssagens[i].Telefone), ToUTF8(menssagens[i].MensagemTexto));
				menssagens.CheckResult(resp);
			}

			int ret = ACBrSMSInterop.SMS_EnviarSMSLote(this.Handle, menssagens.Handle, buffer, bufferLen);
			CheckResult(ret);
			menssagens.Finalizar();
			AIndice = buffer.ToString();
		}

		public void ListarMensagens(Filtro filtro, string path)
		{
			int ret = ACBrSMSInterop.SMS_ListarMensagens(this.Handle, (int)filtro, ToUTF8(path));
			CheckResult(ret);
		}

		public void TrocarBandeja(SimCard simCard)
		{
			int ret = ACBrSMSInterop.SMS_TrocarBandeja(this.Handle, (int)simCard);
			CheckResult(ret);
		}

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnProgressoCallback(int AATual, int ATotal)
		{
			if (onProgresso.IsAssigned)
			{
				OnProgressoEventArgs e = new OnProgressoEventArgs();
				e.Atual = AATual;
				e.Total = ATotal;
				onProgresso.Raise(e);
			}
		}

		#endregion Callback EventHandlers

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrSMSInterop.SMS_Create);
			Device = new ACBrDevice(this);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					const int BUFFER_LEN = 1024;
					string error = GetString(ACBrSMSInterop.SMS_GetUltimoErro, BUFFER_LEN);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr SMS não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrSMSInterop.SMS_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}