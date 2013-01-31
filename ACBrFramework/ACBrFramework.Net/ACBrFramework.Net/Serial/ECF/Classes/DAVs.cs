using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("C3E08AA0-2CCD-435D-B77E-CDACC2F2109C")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public sealed class DAVs
	{
		public string Numero { get; set; }

		public int COO_Cupom { get; set; }

		public int COO_Dav { get; set; }

		public string Titulo { get; set; }

		public decimal Valor
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get;
#if COM_INTEROP
			[param: MarshalAs(UnmanagedType.Currency)]
#endif
			set;
		}

		public DateTime DtEmissao { get; set; }
	}
}