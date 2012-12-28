namespace ACBrFramework.Sped
{
	public class RegistroC400
	{
		#region Constructor

		public RegistroC400()
		{
			RegistroC405 = new RegistroList<RegistroC405>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string ECF_MOD { get; set; }

		public string ECF_FAB { get; set; }

		public string ECF_CX { get; set; }

		public RegistroList<RegistroC405> RegistroC405 { get; private set; }

		#endregion Properties
	}
}