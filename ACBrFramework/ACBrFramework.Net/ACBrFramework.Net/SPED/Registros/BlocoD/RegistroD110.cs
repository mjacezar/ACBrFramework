namespace ACBrFramework.Sped
{
	public class RegistroD110
	{
		#region Constructor

		public RegistroD110()
		{
			RegistroD120 = new RegistroList<RegistroD120>();
		}

		#endregion Constructor

		#region Properties

		public int NUN_ITEM { get; set; }

		public string COD_ITEM { get; set; }

		public decimal VL_SERV { get; set; }

		public decimal VL_OUT { get; set; }

		public RegistroList<RegistroD120> RegistroD120 { get; private set; }

		#endregion Properties
	}
}