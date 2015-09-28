namespace ACBrFramework.LFD
{
	public class Registro0200
	{
		#region Constructor

		public Registro0200()
		{
			Registro0205 = new RegistroList<Registro0205>();
			Registro0210 = new RegistroList<Registro0210>();
		}

		#endregion Constructor

		#region Properties

		public string COD_ITEM { get; set; }

		public string DESCR_ITEM { get; set; }

		public string COD_GEN { get; set; }

		public string COD_LST { get; set; }

		public RegistroList<Registro0205> Registro0205 { get; private set; }

		public RegistroList<Registro0210> Registro0210 { get; private set; }

		#endregion Properties
	}
}