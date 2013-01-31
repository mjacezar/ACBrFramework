#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("B066E951-6AC3-4991-B2DB-06073F026B7F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public sealed class Aliquota
	{
		public int Sequencia { get; internal set; }

		public string Indice { get; internal set; }

		public decimal ValorAliquota
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get;
			internal set;
		}

		public string Tipo { get; internal set; }

		public decimal Total
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get;
			internal set;
		}
	}
}