using System.Runtime.InteropServices;
namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("6FF8CCF9-F898-4B8F-A709-35243F873555")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroR3
	{
		#region Properties

		public string TOT_PARCIAL { get; set; }

		public decimal VL_ACUM {
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