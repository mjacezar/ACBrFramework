using System;

namespace ACBrFramework.Sped
{
	public class RegistroC800
	{
		#region Constructor

		public RegistroC800()
		{
			RegistroC850 = new RegistroList<RegistroC850>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public SituacaoDocto COD_SIT { get; set; }

		public string NUM_CFE { get; set; }

		public DateTime DT_DOC { get; set; }

		public decimal VL_CFE { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public string CNPJ_CPF { get; set; }

		public string NR_SAT { get; set; }

		public string CHV_CFE { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_MERC { get; set; }

		public decimal VL_OUT_DA { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_PIS_ST { get; set; }

		public decimal VL_COFINS_ST { get; set; }

		public RegistroList<RegistroC850> RegistroC850 { get; private set; }

		#endregion Properties
	}
}