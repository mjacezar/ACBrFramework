namespace ACBrFramework.Sped
{
	public class RegistroE220
	{
		#region Constructor

		public RegistroE220()
		{
			RegistroE230 = new RegistroList<RegistroE230>();
			RegistroE240 = new RegistroList<RegistroE240>();
		}

		#endregion Constructor

		#region Properties

		public string COD_AJ_APUR { get; set; }

		public string DESCR_COMPL_AJ { get; set; }

		public decimal VL_AJ_APUR { get; set; }

		public RegistroList<RegistroE230> RegistroE230 { get; private set; }

		public RegistroList<RegistroE240> RegistroE240 { get; private set; }

		#endregion Properties
	}
}