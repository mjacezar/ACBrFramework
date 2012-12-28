using System;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistro76
	{
		public decimal Isentas { get; set; }

		public decimal ValorTotal { get; set; }

		public decimal Icms { get; set; }

		public decimal BasedeCalculo { get; set; }

		public decimal Outras { get; set; }

		public int Modelo { get; set; }

		public int Numero { get; set; }

		public string Situacao { get; set; }

		public string Inscricao { get; set; }

		public string SubSerie { get; set; }

		public string Uf { get; set; }

		public string Serie { get; set; }

		public string Cfop { get; set; }

		public string CPFCNPJ { get; set; }

		public DateTime DataDocumento { get; set; }

		public TipoReceita TipoReceita { get; set; }

		public int Aliquota { get; set; }
	}
}