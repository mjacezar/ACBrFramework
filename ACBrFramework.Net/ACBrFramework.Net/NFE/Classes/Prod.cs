using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class Prod : ACBrComposedComponent
	{
		#region Constructor

		internal Prod(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			this.VeicProd = new veicProd(parent, composedHandle);
            this.Med = new MedCollection(parent, composedHandle);
            this.Arma = new ArmaCollection(parent, composedHandle);
		}

		#endregion Constructor

		#region Propriedades

		public string CProd
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetCProd);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetCProd, value);
			}
		}

		public int NItem
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetNItem);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetNItem, value);
			}
		}

		public string XProd
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetXProd);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetXProd, value);
			}
		}

		public string CEAN
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetCEAN);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetCEAN, value);
			}
		}

		public string NCM
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetNCM);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetNCM, value);
			}
		}

		public string EXTIPI
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetEXTIPI);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetEXTIPI, value);
			}
		}

		public string CFOP
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetCFOP);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetCFOP, value);
			}
		}

		public string UCom
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetUCom);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetUCom, value);
			}
		}

		public decimal QCom
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetQCom);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetQCom, value);
			}
		}

		public decimal VUnCom
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetVUnCom);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetVUnCom, value);
			}
		}

		public decimal VProd
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetVProd);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetVProd, value);
			}
		}

		public string CEANTrib
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetCEANTrib);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetCEANTrib, value);
			}
		}

		public string UTrib
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetUTrib);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetUTrib, value);
			}
		}

		public decimal VUnTrib
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetVUnTrib);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetVUnTrib, value);
			}
		}

		public decimal QTrib
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetQTrib);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetQTrib, value);
			}
		}

		public decimal VFrete
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetVFrete);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetVFrete, value);
			}
		}

		public decimal VSeg
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetVSeg);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetVSeg, value);
			}
		}

		public decimal VDesc
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetVDesc);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetVDesc, value);
			}
		}

		public decimal VOutro
		{
			get
			{
				return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetVOutro);
			}
			set
			{
				SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetVOutro, value);
			}
		}

		public IndicadorTotal IndTot
		{
			get
			{
				return (IndicadorTotal)GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetIndTot);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetIndTot, (int)value);
			}
		}

		public string XPed
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetXPed);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetXPed, value);
			}
		}

		public int NItemPed
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_GetNItemPed);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_SetNItemPed, value);
			}
		}

        public MedCollection Med { get; private set; }

        public ArmaCollection Arma { get; private set; }

		public veicProd VeicProd { get; private set; }

		#endregion Propriedades
	}
}