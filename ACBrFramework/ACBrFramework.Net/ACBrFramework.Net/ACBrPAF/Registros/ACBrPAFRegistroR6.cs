using System;
using System.Collections.Generic;

namespace ACBrFramework
{
	public class ACBrPAFRegistroR6
	{
		#region Constructor

		public ACBrPAFRegistroR6()
		{
			RegistroR7 = new List<ACBrPAFRegistroR7>();
		}

		#endregion Constructor

		#region Properties

		public List<ACBrPAFRegistroR7> RegistroR7 { get; private set; }

		public int NUM_USU { get; set; }

		public int COO { get; set; }

		public int GNF { get; set; }

		public int GRG { get; set; }

		public int CDC { get; set; }

		public string DENOM { get; set; }

		public DateTime DT_FIN { get; set; }

		public DateTime HR_FIN { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}