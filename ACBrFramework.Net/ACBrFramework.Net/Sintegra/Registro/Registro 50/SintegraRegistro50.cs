using System;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistro50
	{
		public string CPFCNPJ { get; set; }

		public string Inscricao { get; set; }

		public string UF { get; set; }

		public string Situacao { get; set; }

		public decimal Aliquota { get; set; }

		public decimal Isentas { get; set; }

		public decimal Icms { get; set; }

		public decimal ValorContabil { get; set; }

		public decimal BasedeCalculo { get; set; }

		public decimal Outras { get; set; }

		public string EmissorDocumento { get; set; }

		public string Cfop { get; set; }

		public string Serie { get; set; }

		public string Modelo { get; set; }

		public string Numero { get; set; }

		public DateTime DataDocumento { get; set; }
	}
}