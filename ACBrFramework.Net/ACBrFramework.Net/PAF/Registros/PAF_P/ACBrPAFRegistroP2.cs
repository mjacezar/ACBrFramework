using System.Runtime.InteropServices;
namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("F4DA34EB-EC7B-433C-B6BD-EB27D0A6CB8E")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroP2
	{
		#region Properties

		public string COD_MERC_SERV { get; set; }

		public string DESC_MERC_SERV { get; set; }

		public string UN_MED { get; set; }

		public string IAT { get; set; }

		public string IPPT { get; set; }

		public string ST { get; set; }

		public decimal ALIQ {
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

		public decimal VL_UNIT {
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