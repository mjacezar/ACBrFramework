using System;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistro61
	{
		public DateTime Emissao { get; set; }

		public decimal Valor { get; set; }

		public decimal ValorIcms { get; set; }

		public decimal Outras { get; set; }

		public decimal BaseDeCalculo { get; set; }

		public decimal Isentas { get; set; }

		public int NumOrdemInicial { get; set; }

		public int NumOrdemFinal { get; set; }

		public string Modelo { get; set; }

		public string SubSerie { get; set; }

		public string Serie { get; set; }

		public decimal Aliquota { get; set; }
	}
}