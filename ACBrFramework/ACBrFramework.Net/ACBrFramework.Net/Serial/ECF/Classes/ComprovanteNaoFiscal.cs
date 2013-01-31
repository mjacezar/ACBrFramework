#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("18BA0423-3605-4E51-92E6-192ED5B01723")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public sealed class ComprovanteNaoFiscal
	{
		public string Indice { get; internal set; }

		public string Descricao { get; internal set; }

		public bool PermiteVinculado { get; internal set; }

		public string FormaPagamento { get; internal set; }

		public decimal Total
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get;
			internal set;
		}

		public int Contador { get; internal set; }
	}
}