namespace ACBrFramework.TEFD
{
	public class Identificacao : ACBrComposedComponent
	{
		#region Constructor

		internal Identificacao(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public string NomeAplicacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Identificacao_GetNomeAplicacao);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Identificacao_SetNomeAplicacao, value);
			}
		}

		public string VersaoAplicacao
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Identificacao_GetVersaoAplicacao);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Identificacao_SetVersaoAplicacao, value);
			}
		}

		public string SoftwareHouse
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Identificacao_GetSoftwareHouse);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Identificacao_SetSoftwareHouse, value);
			}
		}

		public string RazaoSocial
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_Identificacao_GetRazaoSocial);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_Identificacao_SetRazaoSocial, value);
			}
		}

		#endregion Properties
	}
}