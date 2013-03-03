using System;

namespace ACBrFramework.NFE
{
	public sealed class Avulsa : ACBrComposedComponent
	{
		#region Constructor

		internal Avulsa(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{

		}

		#endregion Constructor

		#region Properties

		public string CNPJ
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetCNPJ);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetCNPJ, value);
			}
		}

		public string Fone
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetFone);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetFone, value);
			}
		}

		public string Matr
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetMatr);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetMatr, value);
			}
		}

		public string NDAR
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetNDAR);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetNDAR, value);
			}
		}

		public string RepEmi
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetRepEmi);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetRepEmi, value);
			}
		}

		public string UF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetUF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetUF, value);
			}
		}

		public string VDAR
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetVDAR);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetVDAR, value);
			}
		}

		public string XAgente
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetXAgente);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetXAgente, value);
			}
		}

		public string XOrgao
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Avulsa_GetXOrgao);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Avulsa_SetXOrgao, value);
			}
		}
		
		public DateTime DEmi
		{
			get
			{
				return GetDateTime(ACBrNFEInterop.NFE_NFe_Avulsa_GetDEmi);
			}
			set
			{
				SetDateTime(ACBrNFEInterop.NFE_NFe_Avulsa_SetDEmi, value);
			}
		}

		public DateTime DPag
		{
			get
			{
				return GetDateTime(ACBrNFEInterop.NFE_NFe_Avulsa_GetDPag);
			}
			set
			{
				SetDateTime(ACBrNFEInterop.NFE_NFe_Avulsa_SetDPag, value);
			}
		}
		
		#endregion Properties
	}
}
