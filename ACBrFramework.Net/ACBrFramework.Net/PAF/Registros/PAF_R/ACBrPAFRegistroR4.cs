using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("3F9A5DE9-1907-4576-89AD-CD4B79109836")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroR4
	{
		#region Constructor

		public ACBrPAFRegistroR4()
		{
			RegistroR5 = new ACBrPAFRegistrosR5();
			RegistroR7 = new ACBrPAFRegistrosR7();
		}

		#endregion Constructor

		#region Properties

		public ACBrPAFRegistrosR5 RegistroR5 { get; private set; }

		public ACBrPAFRegistrosR7 RegistroR7 { get; private set; }

		public int NUM_USU { get; set; }

		public int NUM_CONT { get; set; }

		public int COO { get; set; }

		public DateTime DT_INI { get; set; }

		public decimal SUB_DOCTO {
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

		public decimal SUB_DESCTO {
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

		public string TP_DESCTO { get; set; }

		public decimal SUB_ACRES {
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

		public string TP_ACRES { get; set; }

		public decimal VL_TOT {
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

		public string CANC { get; set; }

		public decimal VL_CA {
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

		public string ORDEM_DA { get; set; }

		public string NOME_CLI { get; set; }

		public string CNPJ_CPF { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}