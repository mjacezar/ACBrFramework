namespace ACBrFramework.TEFD
{
	public class TefGPU : ACBrComposedComponent
	{
		#region Constructor

		internal TefGPU(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFGPU_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFGPU_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFGPU_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFGPU_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFGPU_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFGPU_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGPU_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGPU_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGPU_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGPU_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGPU_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGPU_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGPU_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGPU_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGPU_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGPU_SetGPExeName, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFGPU_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFGPU_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFGPU_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFGPU_SetHabilitado, value);
			}
		}

		#endregion Properties
	}
}