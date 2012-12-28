namespace ACBrFramework.Sped
{
	public class RegistroC195
	{
		#region Constructor

		public RegistroC195()
		{
			RegistroC197 = new RegistroList<RegistroC197>();
		}

		#endregion Constructor

		#region Properties

		public string COD_OBS { get; set; }

		public string TXT_COMPL { get; set; }

		public RegistroList<RegistroC197> RegistroC197 { get; private set; }

		#endregion Properties
	}
}