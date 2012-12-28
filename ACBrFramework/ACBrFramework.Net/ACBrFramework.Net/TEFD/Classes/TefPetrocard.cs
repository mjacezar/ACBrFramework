namespace ACBrFramework.TEFD
{
	public class TefPetrocard : ACBrComposedComponent
	{
		#region Constructor

		internal TefPetrocard(ACBrTEFD parent)
			: base(parent)
		{
		}

		#endregion Constructor

		#region Properties

		public bool AutoAtivarGP
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFPetrocard_GetAutoAtivarGP);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFPetrocard_SetAutoAtivarGP, value);
			}
		}

		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFPetrocard_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFPetrocard_SetNumVias, value);
			}
		}

		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_TEFPetrocard_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_TEFPetrocard_SetEsperaSTS, value);
			}
		}

		public string ArqTemp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFPetrocard_GetArqTemp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFPetrocard_SetArqTemp, value);
			}
		}

		public string ArqReq
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFPetrocard_GetArqReq);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFPetrocard_SetArqReq, value);
			}
		}

		public string ArqSTS
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFPetrocard_GetArqSTS);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFPetrocard_SetArqSTS, value);
			}
		}

		public string ArqResp
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFPetrocard_GetArqResp);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFPetrocard_SetArqResp, value);
			}
		}

		public string GPExeName
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFPetrocard_GetGPExeName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFPetrocard_SetGPExeName, value);
			}
		}

		public string Name
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_TEFPetrocard_GetName);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_TEFPetrocard_SetName, value);
			}
		}

		public bool Habilitado
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_TEFPetrocard_GetHabilitado);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_TEFPetrocard_SetHabilitado, value);
			}
		}

		#endregion Properties
	}
}