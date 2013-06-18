using System.Runtime.InteropServices;
namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("683AA78C-4CEF-4C4A-92F3-244190B2DA43")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP
	public sealed class ACBrPAFRegistroR7
	{
		#region Properties

		public int CCF { get; set; }

		public int GNF { get; set; }

		public string MP { get; set; }

		public decimal VL_PAGTO {
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

		public string IND_EST { get; set; }

		public decimal VL_EST {
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