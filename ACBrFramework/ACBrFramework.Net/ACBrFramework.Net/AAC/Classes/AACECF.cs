using System;

#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("00950BA4-3763-4F86-80D9-DCF0F801E88D")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class AACECF
	{
		#region Properties

		public decimal ValorGT
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

		public string NumeroSerie { get; set; }

		public int CRO { get; set; }

		public int CNI { get; set; }

		public DateTime DtHrAtualizado { get; internal set; }

		#endregion Properties
	}
}