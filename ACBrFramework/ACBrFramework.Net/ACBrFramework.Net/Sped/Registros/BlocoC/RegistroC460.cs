using System;

namespace ACBrFramework.Sped
{
	public class RegistroC460
	{
		#region Constructor

		public RegistroC460()
		{
			RegistroC470 = new RegistroList<RegistroC470>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public SituacaoDocto COD_SIT { get; set; }

		public string NUM_DOC { get; set; }

		public DateTime DT_DOC { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public string CPF_CNPJ { get; set; }

		public string NOM_ADQ { get; set; }

		public RegistroList<RegistroC470> RegistroC470 { get; private set; }

		#endregion Properties
	}
}