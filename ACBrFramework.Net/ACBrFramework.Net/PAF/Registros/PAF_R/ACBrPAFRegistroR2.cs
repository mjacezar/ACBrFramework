using System;

namespace ACBrFramework
{
	public sealed class ACBrPAFRegistroR2
	{
		#region Constructor

		public ACBrPAFRegistroR2()
		{
			RegistroR3 = new ACBrPAFRegistrosR3();
		}

		#endregion Constructor

		#region Properties

		public ACBrPAFRegistrosR3 RegistroR3 { get; private set; }

		public int NUM_USU { get; set; }

		public int CRZ { get; set; }

		public int COO { get; set; }

		public int CRO { get; set; }

		public DateTime DT_MOV { get; set; }

		public DateTime DT_EMI { get; set; }

		public DateTime HR_EMI { get; set; }

		public decimal VL_VBD { get; set; }

		public string PAR_ECF { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}