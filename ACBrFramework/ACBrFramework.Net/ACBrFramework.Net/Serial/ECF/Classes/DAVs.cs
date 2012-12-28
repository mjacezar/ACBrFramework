using System;

namespace ACBrFramework.ECF
{
	public sealed class DAVs
	{
		public string Numero { get; set; }

		public int COO_Cupom { get; set; }

		public int COO_Dav { get; set; }

		public string Titulo { get; set; }

		public decimal Valor { get; set; }

		public DateTime DtEmissao { get; set; }
	}
}