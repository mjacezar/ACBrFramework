namespace ACBrFramework.Sped
{
	public class RegistroC420
	{
		#region Constructor

		public RegistroC420()
		{
			RegistroC425 = new RegistroList<RegistroC425>();
		}

		#endregion Constructor

		#region Properties

		public string COD_TOT_PAR { get; set; }

		public decimal VLR_ACUM_TOT { get; set; }

		public int NR_TOT { get; set; }

		public string DESCR_NR_TOT { get; set; }

		public RegistroList<RegistroC425> RegistroC425 { get; private set; }

		#endregion Properties
	}
}