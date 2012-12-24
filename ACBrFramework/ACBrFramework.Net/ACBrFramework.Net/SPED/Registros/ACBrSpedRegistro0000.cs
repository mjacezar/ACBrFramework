using System;

namespace ACBrFramework.SPED
{
	public class ACBrSpedRegistro0000
	{
		public ACBrVersaoLeiaute OD_VER { get; set; }

		public ACBrCodFinalidade COD_FIN { get; set; }

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

		public ACBrPerfil IND_PERFIL { get; set; }

		public ACBrAtividade IND_ATIV { get; set; }
	}
}