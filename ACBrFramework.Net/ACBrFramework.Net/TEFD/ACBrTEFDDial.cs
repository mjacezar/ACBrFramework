namespace ACBrFramework.TEFD
{
	public class ACBrTEFDDial : ACBrComposedComponent
	{
		#region Constructor

		internal ACBrTEFDDial(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFDial_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFDial_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFDial_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFDial_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFDial_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFDial_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDial_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDial_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDial_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDial_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDial_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDial_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDial_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDial_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFDial_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFDial_SetGPExeName, value);
			}
		}

		#endregion Properties
	}
}