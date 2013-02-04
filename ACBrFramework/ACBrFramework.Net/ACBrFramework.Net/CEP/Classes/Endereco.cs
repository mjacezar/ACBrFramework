using System;
using System.Collections.Generic;

namespace ACBrFramework.CEP
{
	public class Endereco : ACBrComposedComponent
	{
		#region Constructor

		internal Endereco(ACBrCEP parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
		}

		#endregion Constructor

		#region Properties

		public string CEP
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetCEP);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetCEP, value);
			}
		}

		public string Bairro
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetBairro);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetBairro, value);
			}
		}

		public string Complemento
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetComplemento);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetComplemento, value);
			}
		}

		public string Tipo_Logradouro
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetTipo_Logradouro);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetTipo_Logradouro, value);
			}
		}

		public string Logradouro
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetLogradouro);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetLogradouro, value);
			}
		}

		public string Municipio
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetMunicipio);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetMunicipio, value);
			}
		}

		public string UF
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetUF);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetUF, value);
			}
		}

		public string IBGE_Municipio
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetIBGE_Municipio);
			}
			set
			{
				SetString(ACBrCEPInterop.CEP_Endereco_SetIBGE_Municipio, value);
			}
		}

		public string IBGE_UF
		{
			get
			{
				return GetString(ACBrCEPInterop.CEP_Endereco_GetIBGE_UF);
			}
		}

		#endregion Properties
	}
}