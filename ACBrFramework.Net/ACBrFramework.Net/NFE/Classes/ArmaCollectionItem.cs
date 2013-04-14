using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
    public sealed class ArmaCollectionItem : ACBrComposedComponent
    {
        #region Constructor

        internal ArmaCollectionItem(ACBrNFE parent, IntPtr composedHandle)
            : base(parent, composedHandle)
        {

        }

        #endregion Constructor

        #region Propriedades

        public TipoArma TpArma
        {
            get
            {
                return (TipoArma)GetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_GetTpArma);
            }
            set
            {
                SetInt32(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_SetTpArma, (int)value);
            }
        }

        public string NSerie
        {
            get
            {
                return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_GetNSerie);
            }
            set
            {
                SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_SetNSerie, value);
            }
        }

        public string NCano
        {
            get
            {
                return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_GetNCano);
            }
            set
            {
                SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_SetNCano, value);
            }
        }

        public string Descr
        {
            get
            {
                return GetString(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_GetDescr);
            }
            set
            {
                SetString(ACBrNFEInterop.NFE_NFe_Det_Item_Arma_Item_SetDescr, value);
            }
        }

        #endregion Propriedades
    }
}
