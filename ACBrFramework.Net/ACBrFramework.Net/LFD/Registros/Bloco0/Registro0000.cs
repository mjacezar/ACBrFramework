using System;

namespace ACBrFramework.LFD
{
	public class Registro0000
	{
		#region Properties

		public VersaoLeiaute COD_VER { get; set; }

		public CodFinalidade COD_FIN { get; set; }

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public string NOME { get; set; }

		public string CNPJ { get; set; }

		public string UF { get; set; }

		public string IE { get; set; }

		public int COD_MUN { get; set; }

		public string IM { get; set; }

		public string SUFRAMA { get; set; }

		public ConteudoArquivo COD_CONTEUDO { get; set; }

		public string FANTASIA { get; set; }

		public string NIRE { get; set; }

		#endregion Properties
	}
}