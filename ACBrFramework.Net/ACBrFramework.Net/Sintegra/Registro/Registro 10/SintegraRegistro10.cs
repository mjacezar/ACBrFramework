using System;

namespace ACBrFramework.Sintegra
{
	public sealed class SintegraRegistro10
	{
		public string CNPJ { get; set; }

		public string Inscricao { get; set; }

		public string RazaoSocial { get; set; }

		public string Cidade { get; set; }

		public string Estado { get; set; }

		public string Telefone { get; set; }

		public DateTime DataInicial { get; set; }

		public DateTime DataFinal { get; set; }

		public int CodigoConvenio { get; set; }

		public int NaturezaInformacoes { get; set; }

		public int FinalidadeArquivo { get; set; }
	}
}