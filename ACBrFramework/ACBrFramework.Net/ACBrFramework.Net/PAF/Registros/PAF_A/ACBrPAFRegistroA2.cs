using System;
#region COM_INTEROP
#if COM_INTEROP

using System.Runtime.InteropServices;

#endif
#endregion COM_INTEROP

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("AED5156A-2117-47B4-B666-4298BCFB79E8")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistroA2
    {
        #region Properties
        /// <summary>
        /// Se true o registro é válido
        /// </summary>
        public bool RegistroValido { get; set; }
        /// <summary>
        /// Data do movimento
        /// </summary>
        public DateTime Data { get; set; }
        /// <summary>
        /// Meio de pagamento registrado nos documentos emitidos (Dinheiro, Cheque, Cartão de Crédito, Cartão de Débito, etc.)
        /// </summary>
        public string MeioPagamento { get; set; }
        /// <summary>
        /// Código do tipo de documento a que se refere o pagamento 
        /// </summary>
        public CodigoTipoDocumento CodigoTipoDocumento { get; set; }
        /// <summary>
        /// Valor total do meio de pagamento acumulado no dia
        /// </summary>
        public decimal Valor
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            get;
            #region COM_INTEROP

#if COM_INTEROP
            [param: MarshalAs(UnmanagedType.Currency)]
#endif

            #endregion COM_INTEROP
            set;
        }
        #endregion Properties
    }
}