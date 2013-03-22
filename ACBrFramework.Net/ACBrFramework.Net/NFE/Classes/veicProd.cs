using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class veicProd : ACBrComposedComponent
	{
		#region Constructor

		internal veicProd(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{

		}

		#endregion Constructor

		#region Propriedades

		public TipoOperacao TpOP
		{
			get
			{
				return (TipoOperacao)GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetTpOP);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetTpOP, (int)value);
			}
		}

		public string Chassi
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetChassi);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetChassi, value);
			}
		}

		public string CCor
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetCCor);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetCCor, value);
			}
		}

		public string XCor
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetXCor);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetXCor, value);
			}
		}

		public string Pot
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetPot);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetPot, value);
			}
		}

		public string Cilin
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetCilin);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetCilin, value);
			}
		}

		public string PesoL
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetPesoL);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetPesoL, value);
			}
		}

		public string PesoB
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetPesoB);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetPesoB, value);
			}
		}

		public string NSerie
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetNSerie);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetNSerie, value);
			}
		}

		public string TpComb
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetTpComb);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetTpComb, value);
			}
		}

		public string CombDescricao
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetCombDescricao);
			}
		}

		public string NMotor
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetNMotor);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetNMotor, value);
			}
		}

		public string CMT
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetCMT);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetCMT, value);
			}
		}

		public string Dist
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetDist);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetDist, value);
			}
		}

		public int AnoMod
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetAnoMod);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetAnoMod, value);
			}
		}

		public int AnoFab
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetAnoFab);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetAnoFab, value);
			}
		}

		public string TpPint
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetTpPint);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetTpPint, value);
			}
		}

		public int TpVeic
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetTpVeic);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetTpVeic, value);
			}
		}

		public int EspVeic
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetEspVeic);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetEspVeic, value);
			}
		}

		public string VIN
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetVIN);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetVIN, value);
			}
		}

		public CondicaoVeiculo CondVeic
		{
			get
			{
				return (CondicaoVeiculo)GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetCondVeic);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetCondVeic, (int)value);
			}
		}

		public string CMod
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetCMod);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetCMod, value);
			}
		}

		public string CCorDENATRAN
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetCCorDENATRAN);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetCCorDENATRAN, value);
			}
		}

		public int Lota
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetLota);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetLota, value);
			}
		}

		public int TpRest
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_GetTpRest);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Prod_veicProd_SetTpRest, value);
			}
		}

		#endregion Propriedades
	}
}
