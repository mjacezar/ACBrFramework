using System;

namespace ACBrFramework.Sped
{
	public class RegistroD355
	{
		#region Constructor

		public RegistroD355()
		{
			RegistroD360 = new RegistroList<RegistroD360>();
			RegistroD365 = new RegistroList<RegistroD365>();
			RegistroD390 = new RegistroList<RegistroD390>();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_DOC { get; set; }

		public int CRO { get; set; }

		public int CRZ { get; set; }

		public int NUM_COO_FIN { get; set; }

		public decimal GT_FIN { get; set; }

		public decimal VL_BRT { get; set; }

		public RegistroList<RegistroD360> RegistroD360 { get; private set; }

		public RegistroList<RegistroD365> RegistroD365 { get; private set; }

		public RegistroList<RegistroD390> RegistroD390 { get; private set; }

		#endregion Properties
	}
}