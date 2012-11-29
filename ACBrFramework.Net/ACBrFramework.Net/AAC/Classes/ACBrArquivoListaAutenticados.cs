using ACBrFramework.PAF;
using System;

namespace ACBrFramework.AAC
{
    public sealed class ACBrArquivoListaAutenticados : ACBrComposedComponent
    {
        #region Constructor

        internal ACBrArquivoListaAutenticados(ACBrECFIdenticacaoPaf identPaf)
            : base(identPaf.Parent)
        {
        }

        #endregion Constructor

       #region Properties

        public string Nome
        {
            get
            {
                return GetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_GetNome);
            }
            set
            {
                SetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_SetNome, value);
            }
        }

        public string MD5
        {
            get
            {
                return GetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_GetMD5);
            }
            set
            {
                SetString(ACBrAACInterop.AAC_IdentPaf_ArquivoListaAutenticados_SetMD5, value);
            }
        }

        #endregion Properties
    }
}
