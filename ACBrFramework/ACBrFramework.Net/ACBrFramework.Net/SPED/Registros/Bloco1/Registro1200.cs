namespace ACBrFramework.Sped
{
	public class Registro1200
	{
		#region Constructor

		public Registro1200()
		{
			Registro1210 = new RegistroList<Registro1210>();
		}

		#endregion Constructor

		#region Properties

		public string COD_AJ_APUR { get; set; }

		public decimal SLD_CRED { get; set; }

		public decimal CRED_APR { get; set; }

		public decimal CRED_RECEB { get; set; }

		public decimal CRED_UTIL { get; set; }

		public decimal SLD_CRED_FIM { get; set; }

		public RegistroList<Registro1210> Registro1210 { get; private set; }

		#endregion Properties
	}
}