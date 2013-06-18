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
    [Guid("65E9AB1B-B18C-4637-AE90-5B8CD449D35B")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistroB2
    {
        #region Properties

        public string BOMBA { get; set; }

        public string BICO { get; set; }

        public DateTime DATA { get; set; }

        public DateTime HORA { get; set; }

        public string MOTIVO { get; set; }

        public string CNPJ_EMPRESA { get; set; }

        public string CPF_TECNICO { get; set; }

        public string NRO_LACRE_ANTES { get; set; }

        public string NRO_LACRE_APOS { get; set; }

        public decimal ENCERRANTE_ANTES
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

        public decimal ENCERRANTE_APOS
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

        public bool RegistroValido { get; set; }

        #endregion Properties
    }
}