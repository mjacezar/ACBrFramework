using System;

namespace ACBrFramework.Sped
{
	public class RegistroC350
	{
		#region Constructor

		public RegistroC350()
		{
			RegistroC370 = new RegistroList<RegistroC370>();
			RegistroC390 = new RegistroList<RegistroC390>();
		}

		#endregion Constructor

		#region Properties

		public string SER { get; set; }

		public string SUB_SER { get; set; }

		public string NUM_DOC { get; set; }

		public DateTime DT_DOC { get; set; }

		public string CNPJ_CPF { get; set; }

		public decimal VL_MERC { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public string COD_CTA { get; set; }

		public RegistroList<RegistroC370> RegistroC370 { get; private set; }

		public RegistroList<RegistroC390> RegistroC390 { get; private set; }

		#endregion Properties
	}
}