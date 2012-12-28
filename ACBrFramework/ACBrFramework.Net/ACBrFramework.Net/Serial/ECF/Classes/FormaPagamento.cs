using System;

namespace ACBrFramework.ECF
{
	public sealed class FormaPagamento
	{
		public string Indice { get; set; }

		public string Descricao { get; set; }

		public bool PermiteVinculado { get; set; }

		public decimal Total { get; set; }

		public DateTime Data { get; set; }

		public string TipoDoc { get; set; }
	}
}