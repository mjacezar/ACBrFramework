namespace ACBrFramework.Sped
{
	public class RegistroE520
	{
		#region Constructor

		public RegistroE520()
		{
			RegistroE530 = new RegistroList<RegistroE530>();
		}

		#endregion Constructor

		#region Properties

		public decimal VL_SD_ANT_IPI { get; set; }

		public decimal VL_DEB_IPI { get; set; }

		public decimal VL_CRED_IPI { get; set; }

		public decimal VL_OD_IPI { get; set; }

		public decimal VL_OC_IPI { get; set; }

		public decimal VL_SC_IPI { get; set; }

		public decimal VL_SD_IPI { get; set; }

		public RegistroList<RegistroE530> RegistroE530 { get; private set; }

		#endregion Properties
	}
}