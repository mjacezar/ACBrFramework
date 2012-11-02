using System;

namespace ACBrFramework.ACBrTEFD
{
	public class ComandaECFPagamentoEventArgs : EventArgs
	{
		#region Constructor

		internal ComandaECFPagamentoEventArgs(string indiceECF, decimal valor)
		{
			this.IndiceECF = indiceECF;
			this.Valor = valor;
		}

		#endregion Constructor

		#region Properties

		public string IndiceECF { get; private set; }

		public decimal Valor { get; private set; }

		public int RetornoECF { get; set; }

		#endregion Properties
	}
}