namespace ACBrFramework.Sped
{
	public class RegistroD365
	{
		#region Constructor

		public RegistroD365()
		{
			RegistroD370 = new RegistroList<RegistroD370>();
		}

		#endregion Constructor

		#region Properties

		public string COD_TOT_PAR { get; set; }

		public decimal VLR_ACUM_TOT { get; set; }

		public string NR_TOT { get; set; }

		public string DESCR_NR_TOT { get; set; }

		public RegistroList<RegistroD370> RegistroD370 { get; private set; }

		#endregion Properties
	}
}