using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("DC37AF30-10E8-4E57-BBB8-2AC28B8B7246")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public sealed class FormaPagamento
	{
		public string Indice { get; set; }

		public string Descricao { get; set; }

		public bool PermiteVinculado { get; set; }

		public decimal Total
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get;
			set;
		}

		public DateTime Data { get; set; }

		public string TipoDoc { get; set; }
	}
}