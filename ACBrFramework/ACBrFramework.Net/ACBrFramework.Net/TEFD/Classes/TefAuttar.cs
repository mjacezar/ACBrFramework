namespace ACBrFramework.TEFD
{
	public class TefAuttar : ACBrComposedComponent
	{
		#region Constructor

		internal TefAuttar(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFAuttar_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFAuttar_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFAuttar_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFAuttar_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFAuttar_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFAuttar_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFAuttar_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFAuttar_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFAuttar_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFAuttar_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFAuttar_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFAuttar_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFAuttar_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFAuttar_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFAuttar_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFAuttar_SetGPExeName, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFAuttar_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFAuttar_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFAuttar_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFAuttar_SetHabilitado, value);
			}
		}

		#endregion Properties
	}
}