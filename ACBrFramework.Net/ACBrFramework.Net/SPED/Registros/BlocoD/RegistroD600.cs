namespace ACBrFramework.Sped
{
	public class RegistroD600
	{
		#region Constructor

		public RegistroD600()
		{
			RegistroD610 = new RegistroList<RegistroD610>();
			RegistroD690 = new RegistroList<RegistroD690>();
		}

		#endregion Constructor

		#region Properties

		public RegistroList<RegistroD610> RegistroD610 { get; private set; }

		public RegistroList<RegistroD690> RegistroD690 { get; private set; }

		#endregion Properties
	}
}