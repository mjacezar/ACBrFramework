using System.Runtime.InteropServices;
using System;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP
    [ComVisible(true)]
    [Guid("95a1cc87-c985-49ff-bf02-a9980e96883a")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP
    public sealed class ACBrPAFRegistroE3
    {
        #region Properties
        public string NumeroFabricacao { get; set; }
        public string MFAdicional { get; set; }
        public string TipoECF { get; set; }
        public string MarcaECF { get; set; }
        public string ModeloECF { get; set; }
        public DateTime DataEstoque { get; set; }
        public decimal HoraEstoque { get; set; }
        public bool RegistroValido { get; set; }
        #endregion Properties
    }
}