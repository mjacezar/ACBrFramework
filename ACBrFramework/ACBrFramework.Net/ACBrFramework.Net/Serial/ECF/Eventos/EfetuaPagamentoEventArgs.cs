using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("C3CBF1A0-BF4B-4DC2-99EE-D0956DA3A5CE")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class EfetuaPagamentoEventArgs : EventArgs
	{
		internal EfetuaPagamentoEventArgs(string CodFormaPagto, decimal Valor, string Observacao, bool ImprimeVinculado)
		{
			this.CodFormaPagto = CodFormaPagto;
			this.Valor = Valor;
			this.Observacao = Observacao;
			this.ImprimeVinculado = ImprimeVinculado;
		}

		public string CodFormaPagto { get; private set; }

		public decimal Valor
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get; 
			private set; 
		}

		public string Observacao { get; private set; }

		public bool ImprimeVinculado { get; private set; }
	}
}