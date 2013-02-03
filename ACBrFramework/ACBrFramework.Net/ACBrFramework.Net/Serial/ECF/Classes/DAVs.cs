#region COM_INTEROP

using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.ECF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("C3E08AA0-2CCD-435D-B77E-CDACC2F2109C")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class DAVs
	{
		#region Properties

		public string Numero { get; set; }

		public int COO_Cupom { get; set; }

		public int COO_Dav { get; set; }

		public string Titulo { get; set; }

		public decimal Valor
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

		public DateTime DtEmissao { get; set; }

		#endregion Properties
	}
}