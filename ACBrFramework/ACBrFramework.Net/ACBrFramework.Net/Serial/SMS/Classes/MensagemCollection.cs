using System.Collections.Generic;

namespace ACBrFramework.SMS
{
	public class MensagemCollection : ACBrListInterop<Mensagem>
	{
		#region Constructor

		public MensagemCollection()
			: base(ACBrSMSInterop.SMS_MSGC_Add, ACBrSMSInterop.SMS_MSGC_Remove, ACBrSMSInterop.SMS_MSGC_Clear)
		{			
		}

		#endregion Constructor

		#region Methods		

		public void LoadFromFrile(string arquivo)
		{
			int ret = ACBrSMSInterop.SMS_MSGC_LoadFromFrile(this.Handle, arquivo);
			CheckResult(ret);

			for (int i = 0; i < ret; i++)
			{
				Mensagem Item = new Mensagem();
				int resp = ACBrSMSInterop.SMS_MSGC_GetMSG(this.Handle, Item.Handle, i);
				CheckResult(resp);

				Add(Item);
			}
		}

		#region Internal

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:
					const int BUFFER_LEN = 1024;
					string error = GetString(ACBrSMSInterop.SMS_MSGC_GetUltimoErro, BUFFER_LEN);
					throw new ACBrException(error);

				case -2:
					throw new ACBrException("ACBrSMS: Menssagens não inicializado.");
			}
		}

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrSMSInterop.SMS_MSGC_Create);
		}

		protected override void OnDisposing()
		{
			CallDestroy(ACBrSMSInterop.SMS_MSGC_Destroy);
		}

		#endregion Internal

		#endregion Methods
	}
}