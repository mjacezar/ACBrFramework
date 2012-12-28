using System;

namespace ACBrFramework.Sped
{
	public class RegistroC300
	{
		#region Constructor

		public RegistroC300()
		{
			RegistroC310 = new RegistroList<RegistroC310>();
			RegistroC320 = new RegistroList<RegistroC320>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string SER { get; set; }

		public string SUB { get; set; }

		public string NUM_DOC_INI { get; set; }

		public string NUM_DOC_FIN { get; set; }

		public DateTime DT_DOC { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public string COD_CTA { get; set; }

		public RegistroList<RegistroC310> RegistroC310 { get; private set; }

		public RegistroList<RegistroC320> RegistroC320 { get; private set; }

		#endregion Properties
	}
}