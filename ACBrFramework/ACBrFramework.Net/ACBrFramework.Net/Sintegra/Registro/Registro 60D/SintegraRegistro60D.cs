using System;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistro60D
	{
		public string NumSerie { get; set; }

		public string StAliquota { get; set; }

		public DateTime Emissao { get; set; }

		public decimal Valor { get; set; }

		public string Codigo { get; set; }

		public decimal ValorIcms { get; set; }

		public decimal Quantidade { get; set; }

		public decimal BaseDeCalculo { get; set; }
	}
}