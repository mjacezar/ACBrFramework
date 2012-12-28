﻿namespace ACBrFramework.ECF
{
	public sealed class ComprovanteNaoFiscal
	{
		public string Indice { get; internal set; }

		public string Descricao { get; internal set; }

		public bool PermiteVinculado { get; internal set; }

		public string FormaPagamento { get; internal set; }

		public decimal Total { get; internal set; }

		public int Contador { get; internal set; }
	}
}