using System;

namespace ACBrFramework.Sped
{
	public class RegistroD400
	{
		#region Constructor

		public RegistroD400()
		{
			RegistroD410 = new RegistroList<RegistroD410>();
			RegistroD420 = new RegistroList<RegistroD420>();
		}

		#endregion Constructor

		#region Properties

		public string COD_PART { get; set; }

		public string COD_MOD { get; set; }

		public SituacaoDocto COD_SIT { get; set; }

		public string SER { get; set; }

		public string SUB { get; set; }

		public string NUM_DOC { get; set; }

		public DateTime DT_DOC { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_SERV { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public string COD_CTA { get; set; }

		public RegistroList<RegistroD410> RegistroD410 { get; private set; }

		public RegistroList<RegistroD420> RegistroD420 { get; private set; }

		#endregion Properties
	}
}