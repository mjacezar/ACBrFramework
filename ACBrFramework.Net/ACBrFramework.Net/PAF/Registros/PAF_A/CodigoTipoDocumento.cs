#region COM_INTEROP
#if COM_INTEROP

using System.Runtime.InteropServices;

#endif
#endregion COM_INTEROP

using System.ComponentModel;
namespace ACBrFramework.PAF
{
    #region COM_INTEROP
#if COM_INTEROP
	[ComVisible(true)]
#endif
    #endregion COM_INTEROP

    public enum CodigoTipoDocumento
    {
        /// <summary>
        /// Cupom Fiscal
        /// </summary>
        [Description("Cupom Fiscal")]
        CupomFiscal = 1,

        /// <summary>
        /// Comprovante Não Fiscal
        /// </summary>
        [Description("Comprovante Não Fiscal")]
        ComprovanteNaoFiscal = 2,

        /// <summary>
        /// Nota Fiscal
        /// </summary>
        [Description("Nota Fiscal")]
        NotaFiscal = 3
    }
}