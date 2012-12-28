using System;

namespace ACBrFramework.Sped
{
	public class RegistroD300
	{
		#region Constructor

		public RegistroD300()
		{
			RegistroD301 = new RegistroList<RegistroD301>();
			RegistroD310 = new RegistroList<RegistroD310>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string SER { get; set; }

		public string SUB { get; set; }

		public string NUM_DOC_INI { get; set; }

		public string NUM_DOC_FIN { get; set; }

		public string CST_ICMS { get; set; }

		public string CFOP { get; set; }

		public decimal ALIQ_ICMS { get; set; }

		public DateTime DT_DOC { get; set; }

		public decimal VL_OPR { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_SERV { get; set; }

		public decimal VL_SEG { get; set; }

		public decimal VL_OUT_DESP { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_RED_BC { get; set; }

		public string COD_OBS { get; set; }

		public string COD_CTA { get; set; }

		public RegistroList<RegistroD301> RegistroD301 { get; private set; }

		public RegistroList<RegistroD310> RegistroD310 { get; private set; }

		#endregion Properties
	}
}