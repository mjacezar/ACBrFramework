namespace ACBrFramework.TEFD
{
	public class ACBrTEFDCrediShop : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrTEFDCrediShop(ACBrTEFD parent) : base(parent) { }

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFCrediShop_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFCrediShop_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCrediShop_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCrediShop_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFCrediShop_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFCrediShop_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCrediShop_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCrediShop_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCrediShop_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCrediShop_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCrediShop_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCrediShop_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCrediShop_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCrediShop_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFCrediShop_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFCrediShop_SetGPExeName, value);
			}
		}

		#endregion Properties
	}
}