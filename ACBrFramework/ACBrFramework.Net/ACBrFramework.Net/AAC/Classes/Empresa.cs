﻿#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("17376497-6E66-4E59-BBB8-680EC6A19697")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Empresa : ACBrComposedComponent
	{
		#region Constructor

		internal Empresa(IdenticacaoPaf identPaf)
			: base(identPaf.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public string CNPJ
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetCNPJ);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetCNPJ, value);
			}
		}

		public string RazaoSocial
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetRazaoSocial);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetRazaoSocial, value);
			}
		}

		public string Endereco
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetEndereco);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetEndereco, value);
			}
		}

		public string Cep
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetCep);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetCep, value);
			}
		}

		public string Cidade
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetCidade);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetCidade, value);
			}
		}

		public string Uf
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetUf);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetUf, value);
			}
		}

		public string Telefone
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetTelefone);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetTelefone, value);
			}
		}

		public string Contato
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetContato);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetContato, value);
			}
		}

		public string Email
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetEmail);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetEmail, value);
			}
		}

		public string IE
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetIE);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetIE, value);
			}
		}

		public string IM
		{
			get
			{
				return GetString(ACBrAACInterop.AAC_IdentPaf_Empresa_GetIM);
			}
			set
			{
				SetString(ACBrAACInterop.AAC_IdentPaf_Empresa_SetIM, value);
			}
		}

		#endregion Properties
	}
}