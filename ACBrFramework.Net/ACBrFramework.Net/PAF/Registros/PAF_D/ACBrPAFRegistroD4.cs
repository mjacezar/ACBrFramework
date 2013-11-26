using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("156fbd05-bd8e-4d0f-bcd9-bb54f63daf9f")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP
    public sealed class ACBrPAFRegistroD4
    {
        #region Properties

        public string NumeroDAV { get; set; }


        public decimal DataAlteracao
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }

        public decimal HoraAlteracao
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }
        public string CodigoProdutoServico { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }
        public string Unidade { get; set; }

        public decimal ValorUnitario
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }
        public decimal DescontoSobreItem
        {
            #region COM_INTEROP

#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP
#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }
        public decimal AcrescimoSobreItem
        {
            #region COM_INTEROP
#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP
#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }
        public decimal ValorTotalLiquido
        {
            #region COM_INTEROP
#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP
#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }
        public string SituacaoTributaria { get; set; }

        public decimal Aliquota
        {
            #region COM_INTEROP
#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            get;
            #region COM_INTEROP
#if COM_INTEROP
            [return: MarshalAs(UnmanagedType.Currency)]
#endif
            #endregion COM_INTEROP
            set;
        }
        public string IndicadorCancelamento { get; set; }
        public int CasasDecimaisQtd { get; set; }
        public int CasasDecimaisVlUn { get; set; }
        public string TipoAlteracao { get; set; }
        #endregion Properties
    }
}