namespace ACBrFramework.TEFD
{
	public class TefFoxWin : ACBrComposedComponent
	{
		#region Constructor

		internal TefFoxWin(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFFoxWin_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFFoxWin_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFFoxWin_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFFoxWin_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFFoxWin_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFFoxWin_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFFoxWin_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFFoxWin_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFFoxWin_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFFoxWin_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFFoxWin_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFFoxWin_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFFoxWin_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFFoxWin_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFFoxWin_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFFoxWin_SetGPExeName, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFFoxWin_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFFoxWin_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFFoxWin_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFFoxWin_SetHabilitado, value);
			}
		}

		#endregion Properties
	}
}