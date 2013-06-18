using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("3199D2BB-2FD2-40E9-84C4-52A2AD48DFB4")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroR2
	{
		#region Constructor

		public ACBrPAFRegistroR2()
		{
			RegistroR3 = new ACBrPAFRegistrosR3();
		}

		#endregion Constructor

		#region Properties

		public ACBrPAFRegistrosR3 RegistroR3 { get; private set; }

		public int NUM_USU { get; set; }

		public int CRZ { get; set; }

		public int COO { get; set; }

		public int CRO { get; set; }

		public DateTime DT_MOV { get; set; }

		public DateTime DT_EMI { get; set; }

		public DateTime HR_EMI { get; set; }

		public decimal VL_VBD {
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

		public string PAR_ECF { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}