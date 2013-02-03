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
	[Guid("18BA0423-3605-4E51-92E6-192ED5B01723")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ComprovanteNaoFiscal
	{
		#region Properties

		public string Indice { get; internal set; }

		public string Descricao { get; internal set; }

		public bool PermiteVinculado { get; internal set; }

		public string FormaPagamento { get; internal set; }

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

		public int Contador { get; internal set; }
		
		#endregion Properties
	}
}