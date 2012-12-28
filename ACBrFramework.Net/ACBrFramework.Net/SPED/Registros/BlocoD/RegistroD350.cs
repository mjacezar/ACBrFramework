namespace ACBrFramework.Sped
{
	public class RegistroD350
	{
		#region Constructor

		public RegistroD350()
		{
			RegistroD355 = new RegistroList<RegistroD355>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string ECF_MOD { get; set; }

		public string ECF_FAB { get; set; }

		public string ECF_CX { get; set; }

		public RegistroList<RegistroD355> RegistroD355 { get; private set; }

		#endregion Properties
	}
}