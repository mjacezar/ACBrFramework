using System;

namespace ACBrFramework.Sped
{
	public class RegistroD410
	{
		#region Constructor

		public RegistroD410()
		{
			RegistroD411 = new RegistroList<RegistroD411>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string SER { get; set; }

		public string SUB { get; set; }

		public string NUM_DOC_INI { get; set; }

		public string NUM_DOC_FIN { get; set; }

		public DateTime DT_DOC { get; set; }

		public string CST_ICMS { get; set; }

		public string CFOP { get; set; }

		public decimal ALIQ_ICMS { get; set; }

		public decimal VL_OPR { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_SERV { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public RegistroList<RegistroD411> RegistroD411 { get; private set; }

		#endregion Properties
	}
}