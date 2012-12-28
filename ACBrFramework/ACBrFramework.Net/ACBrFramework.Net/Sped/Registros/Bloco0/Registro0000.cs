using System;

namespace ACBrFramework.Sped
{
	public class Registro0000
	{
		public VersaoLeiaute OD_VER { get; set; }

		public CodFinalidade COD_FIN { get; set; }

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public string NOME { get; set; }

		public string CNPJ { get; set; }

		public string CPF { get; set; }

		public string UF { get; set; }

		public string IE { get; set; }

		public int COD_MUN { get; set; }

		public string IM { get; set; }

		public string SUFRAMA { get; set; }

		public Perfil IND_PERFIL { get; set; }

		public Atividade IND_ATIV { get; set; }
	}
}