namespace ACBrFramework.Sped
{
	public class RegistroE111
	{
		#region Constructor

		public RegistroE111()
		{
			RegistroE112 = new RegistroList<RegistroE112>();
			RegistroE113 = new RegistroList<RegistroE113>();
		}

		#endregion Constructor

		#region Properties

		public string COD_AJ_APUR { get; set; }

		public string DESCR_COMPL_AJ { get; set; }

		public decimal VL_AJ_APUR { get; set; }

		public RegistroList<RegistroE112> RegistroE112 { get; private set; }

		public RegistroList<RegistroE113> RegistroE113 { get; private set; }

		#endregion Properties
	}
}