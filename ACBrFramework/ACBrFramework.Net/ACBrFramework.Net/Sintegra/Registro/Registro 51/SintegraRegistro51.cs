using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.Sintegra
{

    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("2680ED2A-489C-429F-9DDB-77E1FA691E5C")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class SintegraRegistro51
	{
		public string CPFCNPJ { get; set; }

		public string Inscricao { get; set; }

		public string Estado { get; set; }

		public string Cfop { get; set; }

		public string Serie { get; set; }

		public string Numero { get; set; }

		public DateTime DataDocumento { get; set; }

		public decimal ValorIpi {
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

		public decimal ValorContabil {
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

		public string Situacao { get; set; }

		public decimal ValorIsentas {
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

		public decimal ValorOutras {
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
	}
}