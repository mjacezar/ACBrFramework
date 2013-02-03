using System;

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
	[Guid("C3CBF1A0-BF4B-4DC2-99EE-D0956DA3A5CE")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class EfetuaPagamentoEventArgs : EventArgs
	{
		#region Constructor

		internal EfetuaPagamentoEventArgs(string CodFormaPagto, decimal Valor, string Observacao, bool ImprimeVinculado)
		{
			this.CodFormaPagto = CodFormaPagto;
			this.Valor = Valor;
			this.Observacao = Observacao;
			this.ImprimeVinculado = ImprimeVinculado;
		}

		#endregion Constructor

		#region Properties

		public string CodFormaPagto { get; private set; }

		public decimal Valor
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			private set;
		}

		public string Observacao { get; private set; }

		public bool ImprimeVinculado { get; private set; }

		#endregion Properties
	}
}