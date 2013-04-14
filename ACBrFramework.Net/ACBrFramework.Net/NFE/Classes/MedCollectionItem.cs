using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
    public sealed class MedCollectionItem : ACBrComposedComponent
    {
        #region Constructor

        internal MedCollectionItem(ACBrNFE parent, IntPtr composedHandle)
            : base(parent, composedHandle)
        {

        }

        #endregion Constructor

        #region Propriedades

        public string NLote
        {
            get
            {
                return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_GetNLote);
            }
            set
            {
                SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_SetNLote, value);
            }

        }

        public decimal QLote
        {
            get
            {
                return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_GetQLote);
            }
            set
            {
                SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_SetQLote, value);
            }
        }

        public decimal VPMC
        {
            get
            {
                return GetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_GetVPMC);
            }
            set
            {
                SetDecimal(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_SetVPMC, value);
            }
        }

        public DateTime DFab
        {
            get
            {
                return GetDateTime(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_GetDFab);
            }
            set
            {
                SetDateTime(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_SetDFab, value);
            }
        }

        public DateTime DVal
        {
            get
            {
                return GetDateTime(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_GetDVal);
            }
            set
            {
                SetDateTime(ACBrNFEInterop.NFE_NFe_Det_Item_Med_Item_SetDVal, value);
            }
        }

        #endregion Propriedades
    }
}