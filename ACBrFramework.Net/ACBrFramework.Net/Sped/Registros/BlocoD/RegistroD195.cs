namespace ACBrFramework.Sped
{
	public class RegistroD195
	{
		#region Constructor

		public RegistroD195()
		{
			RegistroD197 = new RegistroList<RegistroD197>();
		}

		#endregion Constructor

		#region Properties

		public string COD_OBS { get; set; }

		public string TXT_COMPL { get; set; }

		public RegistroList<RegistroD197> RegistroD197 { get; private set; }

		#endregion Properties
	}
}