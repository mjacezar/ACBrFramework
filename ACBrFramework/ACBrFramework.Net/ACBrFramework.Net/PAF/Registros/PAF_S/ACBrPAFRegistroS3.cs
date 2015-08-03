using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistroS3
	{
		#region Properties

		public string COD_ITEM { get; set; }

		public string DESC_ITEM { get; set; }

		public decimal QTDE_ITEM
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

		public string UNI_ITEM { get; set; }

		public decimal VL_UNIT
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
