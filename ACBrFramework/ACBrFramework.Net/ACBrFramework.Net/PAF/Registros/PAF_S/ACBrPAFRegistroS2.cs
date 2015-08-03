using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("86213E6D-FCB5-4DD7-B13A-C3ABFD30A096")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ACBrPAFRegistroS2
	{
		#region Constructor

		public ACBrPAFRegistroS2()
		{
			this.RegistroS3 = new List<ACBrPAFRegistroS3>();
		}

		#endregion Constructor

		#region Properties

		public string CNPJ { get; set; }

		public DateTime DT_ABER { get; set; }

		public string NUM_MESA { get; set; }
		
		public string SITU { get; set; }
		
		public decimal VL_TOT
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
		public string COO_CM { get; set; }

		public string NUM_FAB_CM { get; set; }

		public string COO { get; set; }

		public string NUM_FAB { get; set; }

		public bool RegistroValido { get; set; }

		public List<ACBrPAFRegistroS3> RegistroS3 { get; private set; }

		#endregion Properties
	}
}