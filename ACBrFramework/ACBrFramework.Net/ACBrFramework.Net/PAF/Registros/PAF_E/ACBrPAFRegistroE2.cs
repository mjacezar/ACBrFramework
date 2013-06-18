using System.Runtime.InteropServices;
namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("B42B6519-212B-4F8A-B921-929FD475592E")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroE2
	{
		#region Properties

		public string COD_MERC { get; set; }

		public string DESC_MERC { get; set; }

		public string UN_MED { get; set; }

		public decimal QTDE_EST {
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