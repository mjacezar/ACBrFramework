namespace ACBrFramework.TEFD
{
	public class TefGood : ACBrComposedComponent
	{
		#region Constructor

		internal TefGood(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFGood_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFGood_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFGood_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFGood_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFGood_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFGood_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGood_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGood_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGood_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGood_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGood_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGood_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGood_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGood_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGood_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGood_SetGPExeName, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGood_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGood_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFGood_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFGood_SetHabilitado, value);
			}
		}

		#endregion Properties
	}
}