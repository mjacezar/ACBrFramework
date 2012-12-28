namespace ACBrFramework.Sped
{
	public class RegistroC320
	{
		#region Constructor

		public RegistroC320()
		{
			RegistroC321 = new RegistroList<RegistroC321>();
		}

		#endregion Constructor

		#region Properties

		public string CST_ICMS { get; set; }

		public string CFOP { get; set; }

		public decimal ALIQ_ICMS { get; set; }

		public decimal VL_OPR { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_RED_BC { get; set; }

		public string COD_OBS { get; set; }

		public RegistroList<RegistroC321> RegistroC321 { get; private set; }

		#endregion Properties
	}
}