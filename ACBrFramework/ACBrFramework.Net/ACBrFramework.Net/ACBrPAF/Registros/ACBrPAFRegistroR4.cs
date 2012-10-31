using System;
using System.Collections.Generic;

namespace ACBrFramework
{
	public class ACBrPAFRegistroR4
	{
		#region Constructor

		public ACBrPAFRegistroR4()
		{
			RegistroR5 = new List<ACBrPAFRegistroR5>();
			RegistroR7 = new List<ACBrPAFRegistroR7>();
		}

		#endregion Constructor

		#region Properties

		public List<ACBrPAFRegistroR5> RegistroR5 { get; private set; }

		public List<ACBrPAFRegistroR7> RegistroR7 { get; private set; }

		public int NUM_USU { get; set; }

		public int NUM_CONT { get; set; }

		public int COO { get; set; }

		public DateTime DT_INI { get; set; }

		public decimal SUB_DOCTO { get; set; }

		public decimal SUB_DESCTO { get; set; }

		public string TP_DESCTO { get; set; }

		public decimal SUB_ACRES { get; set; }

		public string TP_ACRES { get; set; }

		public decimal VL_TOT { get; set; }

		public string CANC { get; set; }

		public decimal VL_CA { get; set; }

		public string ORDEM_DA { get; set; }

		public string NOME_CLI { get; set; }

		public string CNPJ_CPF { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}