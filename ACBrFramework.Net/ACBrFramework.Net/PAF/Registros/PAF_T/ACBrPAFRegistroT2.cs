using System;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistroT2
	{
		#region Properties

		public DateTime DT_MOV { get; set; }

		public string TP_DOCTO { get; set; }

		public string SERIE { get; set; }

		public int NUM_BILH_I { get; set; }

		public int NUM_BILH_F { get; set; }

		public string NUM_ECF { get; set; }

		public int CRZ { get; set; }

		public string CFOP { get; set; }

		public double VL_CONT { get; set; }

		public double VL_BASECALC { get; set; }

		public double ALIQ { get; set; }

		public double VL_IMPOSTO { get; set; }

		public double VL_ISENTAS { get; set; }

		public double VL_OUTRAS { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}