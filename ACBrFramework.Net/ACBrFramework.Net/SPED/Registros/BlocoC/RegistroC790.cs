namespace ACBrFramework.Sped
{
	public class RegistroC790
	{
		#region Constructor

		public RegistroC790()
		{
			RegistroC791 = new RegistroList<RegistroC791>();
		}

		#endregion Constructor

		#region Properties

		public string CST_ICMS { get; set; }

		public string CFOP { get; set; }

		public decimal ALIQ_ICMS { get; set; }

		public decimal VL_OPR { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_BC_ICMS_ST { get; set; }

		public decimal VL_ICMS_ST { get; set; }

		public decimal VL_RED_BC { get; set; }

		public string COD_OBS { get; set; }

		public RegistroList<RegistroC791> RegistroC791 { get; private set; }

		#endregion Properties
	}
}