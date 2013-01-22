using System;

namespace ACBrFramework.ECF
{
	public class EfetuaPagamentoArgs : EventArgs
	{
		internal EfetuaPagamentoArgs(string CodFormaPagto, double Valor, string Observacao, bool ImprimeVinculado)
		{
			this.CodFormaPagto = CodFormaPagto;
			this.Valor = Valor;
			this.Observacao = Observacao;
			this.ImprimeVinculado = ImprimeVinculado;
		}

		public string CodFormaPagto { get; private set; }
		public double Valor { get; private set; }
		public string Observacao { get; private set; }
		public bool ImprimeVinculado { get; private set; }
	}
}