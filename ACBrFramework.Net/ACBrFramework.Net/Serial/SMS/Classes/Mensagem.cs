using System;

namespace ACBrFramework.SMS
{
	public sealed class Mensagem : ACBrClassInterop
	{
		#region Constructor

		#endregion Constructor

		#region Propriedades

		public string Telefone 
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_MSG_GetTelefone);
			}
			set
			{
				SetString(ACBrSMSInterop.SMS_MSG_SetTelefone, value);
			}
		}

		public string MensagemTexto
		{
			get
			{
				return GetString(ACBrSMSInterop.SMS_MSG_GetMensagem);
			}
			set
			{
				SetString(ACBrSMSInterop.SMS_MSG_SetMensagem, value);
			}
		}

		#endregion Propriedades

		#region Methods

		#region Override Methods

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrSMSInterop.SMS_MSG_Create);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					const int BUFFER_LEN = 1024;
					string error = GetString(ACBrSMSInterop.SMS_MSG_GetUltimoErro, BUFFER_LEN);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBrSMS: Menssagem não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrSMSInterop.SMS_MSG_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}