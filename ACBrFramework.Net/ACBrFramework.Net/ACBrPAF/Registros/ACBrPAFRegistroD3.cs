using System;

namespace ACBrFramework
{
	public class ACBrPAFRegistroD3
	{
		public DateTime DT_INCLUSAO { get; set; }

		public int NUM_ITEM { get; set; }

		public string COD_ITEM { get; set; }

		public string DESC_ITEM { get; set; }

		public decimal QTDE_ITEM { get; set; }

		public string UNI_ITEM { get; set; }

		public decimal VL_UNIT { get; set; }

		public decimal VL_DESCTO { get; set; }

		public decimal VL_ACRES { get; set; }

		public decimal VL_TOTAL { get; set; }

		public int DEC_VL_UNIT { get; set; }

		public int DEC_QTDE_ITEM { get; set; }

		public string SIT_TRIB { get; set; }

		public decimal ALIQ { get; set; }

		public string IND_CANC { get; set; }

		public bool RegistroValido { get; set; }
	}
}