namespace ACBrFramework.Sped
{
	public class RegistroD001
	{
		#region Constructor

		public RegistroD001()
		{
			RegistroD100 = new RegistroList<RegistroD100>();
			RegistroD300 = new RegistroList<RegistroD300>();
			RegistroD350 = new RegistroList<RegistroD350>();
			RegistroD400 = new RegistroList<RegistroD400>();
			RegistroD500 = new RegistroList<RegistroD500>();
			RegistroD600 = new RegistroList<RegistroD600>();
			RegistroD695 = new RegistroList<RegistroD695>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public RegistroList<RegistroD100> RegistroD100 { get; private set; }

		public RegistroList<RegistroD300> RegistroD300 { get; private set; }

		public RegistroList<RegistroD350> RegistroD350 { get; private set; }

		public RegistroList<RegistroD400> RegistroD400 { get; private set; }

		public RegistroList<RegistroD500> RegistroD500 { get; private set; }

		public RegistroList<RegistroD600> RegistroD600 { get; private set; }

		public RegistroList<RegistroD695> RegistroD695 { get; private set; }

		#endregion Properties
	}
}