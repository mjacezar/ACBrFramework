using System;

namespace ACBrFramework.Sped
{
	public class RegistroD180
	{
		#region Properties

		public string NUM_SEQ { get; set; }

		public Emitente IND_EMIT { get; set; }

		public string CNPJ_EMIT { get; set; }

		public string UF_EMIT { get; set; }

		public string IE_EMIT { get; set; }

		public string COD_MUN_ORIG { get; set; }

		public string CNPJ_CPF_TOM { get; set; }

		public string UF_TOM { get; set; }

		public string IE_TOM { get; set; }

		public string COD_MUN_DEST { get; set; }

		public string COD_MOD { get; set; }

		public string SER { get; set; }

		public string SUB { get; set; }

		public string NUM_DOC { get; set; }

		public DateTime DT_DOC { get; set; }

		public decimal VL_DOC { get; set; }

		#endregion Properties
	}
}