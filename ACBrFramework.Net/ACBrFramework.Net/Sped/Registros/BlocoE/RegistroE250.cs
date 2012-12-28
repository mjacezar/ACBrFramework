using System;

namespace ACBrFramework.Sped
{
	public class RegistroE250
	{
		#region Properties

		public string COD_OR { get; set; }

		public decimal VL_OR { get; set; }

		public DateTime DT_VCTO { get; set; }

		public string COD_REC { get; set; }

		public string NUM_PROC { get; set; }

		public OrigemProcesso IND_PROC { get; set; }

		public string PROC { get; set; }

		public string TXT_COMPL { get; set; }

		public string MES_REF { get; set; }  // VERSÃO 103

		#endregion Properties
	}
}