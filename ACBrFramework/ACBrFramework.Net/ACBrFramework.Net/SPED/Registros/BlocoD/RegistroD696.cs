namespace ACBrFramework.Sped
{
	public class RegistroD696
	{
		#region Constructor

		public RegistroD696()
		{
			RegistroD697 = new RegistroList<RegistroD697>();
		}

		#endregion Constructor

		#region Properties

		public string CST_ICMS { get; set; }

		public string CFOP { get; set; }

		public decimal ALIQ_ICMS { get; set; }

		public decimal VL_OPR { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_BC_ICMS_UF { get; set; }

		public decimal VL_ICMS_UF { get; set; }

		public decimal VL_RED_BC { get; set; }

		public string COD_OBS { get; set; }

		public RegistroList<RegistroD697> RegistroD697 { get; private set; }

		#endregion Properties
	}
}