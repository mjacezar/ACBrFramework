namespace ACBrFramework.TEFD
{
	public class TefDisc : ACBrComposedComponent
	{
		#region Constructor

		internal TefDisc(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFDisc_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFDisc_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFDisc_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFDisc_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFDisc_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFDisc_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDisc_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDisc_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDisc_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDisc_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDisc_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDisc_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDisc_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDisc_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDisc_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDisc_SetGPExeName, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDisc_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDisc_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFDisc_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFDisc_SetHabilitado, value);
			}
		}

		#endregion Properties
	}
}