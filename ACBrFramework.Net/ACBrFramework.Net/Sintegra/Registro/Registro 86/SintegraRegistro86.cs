using System;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistro86
	{
		public string RegistroExportacao { get; set; }

		public DateTime DataRegistro { get; set; }

		public string CPFCNPJ { get; set; }

		public string Inscricao { get; set; }

		public string UF { get; set; }

		public string NumeroNotaFiscal { get; set; }

		public DateTime DataDocumento { get; set; }

		public string Modelo { get; set; }

		public string Serie { get; set; }

		public string Codigo { get; set; }

		public decimal Quantidade { get; set; }

		public decimal ValorUnitario { get; set; }

		public decimal ValorTotalProduto { get; set; }

		public string Relacionamento { get; set; }
	}
}