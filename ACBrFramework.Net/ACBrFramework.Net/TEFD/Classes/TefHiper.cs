namespace ACBrFramework.TEFD
{
	public class TefHiper : ACBrComposedComponent
	{
		#region Constructor

		internal TefHiper(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFHiper_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFHiper_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFHiper_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFHiper_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFHiper_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFHiper_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFHiper_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFHiper_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFHiper_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFHiper_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFHiper_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFHiper_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFHiper_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFHiper_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFHiper_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFHiper_SetGPExeName, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFHiper_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFHiper_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFHiper_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFHiper_SetHabilitado, value);
			}
		}

		#endregion Properties
	}
}