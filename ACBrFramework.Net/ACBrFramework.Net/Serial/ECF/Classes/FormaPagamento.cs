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
	[Guid("DC37AF30-10E8-4E57-BBB8-2AC28B8B7246")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class FormaPagamento
	{
		#region Properties

		public string Indice { get; set; }

		public string Descricao { get; set; }

		public bool PermiteVinculado { get; set; }

		public decimal Total
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			set;
		}

		public DateTime Data { get; set; }

		public string TipoDoc { get; set; }

		#endregion Properties
	}
}