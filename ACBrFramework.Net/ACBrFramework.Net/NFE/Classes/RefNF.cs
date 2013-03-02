using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public class RefNF : ACBrComposedComponent
	{
		#region Constructor

		public RefNF(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
		}

		#endregion Constructor

		#region Properties

		public int CUF
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_GetcUF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_SetcUF, value);
			}
		}

		public string AAMM
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_GetAAMM);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_SetAAMM, value);
			}
		}

		public string CNPJ
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_GetCNPJ);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_SetCNPJ, value);
			}
		}

		public int Modelo
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_Getmodelo);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_Setmodelo, value);
			}
		}

		public int Serie
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_Getserie);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_Setserie, value);
			}
		}

		public int NNF
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_GetnNF);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Ide_NFref_Item_RefNF_SetnNF, value);
			}
		}

		#endregion Properties
	}
}
