#region COM_INTEROP
#if COM_INTEROP

using System.Runtime.InteropServices;

#endif
#endregion COM_INTEROP

namespace ACBrFramework.ECF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("B066E951-6AC3-4991-B2DB-06073F026B7F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Aliquota
	{
		#region Properties

		public int Sequencia { get; internal set; }

		public string Indice { get; internal set; }

		public decimal ValorAliquota
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			internal set;
		}

		public string Tipo { get; internal set; }

		public decimal Total
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			internal set;
		}

		#endregion Properties
	}
}