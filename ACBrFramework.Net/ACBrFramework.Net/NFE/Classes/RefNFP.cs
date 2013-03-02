using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public class RefNFP : ACBrComposedComponent
	{
		#region Constructor

		public RefNFP(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
		}

		#endregion Constructor

		#region Properties

		public int CUF
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_GetcUF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_SetcUF, value);
			}
		}

		public string AAMM
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_GetAAMM);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_SetAAMM, value);
			}
		}

		public string CNPJCPF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_GetCNPJCPF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_SetCNPJCPF, value);
			}
		}

		public string IE
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_GetIE);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_SetIE, value);
			}
		}

		public int Modelo
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_Getmodelo);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_Setmodelo, value);
			}
		}

		public int Serie
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_Getserie);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_Setserie, value);
			}
		}

		public int NNF
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_GetnNF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNFP_SetnNF, value);
			}
		}

		#endregion Properties
	}
}
