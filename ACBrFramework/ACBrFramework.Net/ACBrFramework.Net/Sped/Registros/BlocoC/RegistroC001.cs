namespace ACBrFramework.Sped
{
	public class RegistroC001
	{
		#region Constructor

		public RegistroC001()
		{
			RegistroC100 = new RegistroList<RegistroC100>();
			RegistroC300 = new RegistroList<RegistroC300>();
			RegistroC350 = new RegistroList<RegistroC350>();
			RegistroC400 = new RegistroList<RegistroC400>();
			RegistroC495 = new RegistroList<RegistroC495>();
			RegistroC500 = new RegistroList<RegistroC500>();
			RegistroC600 = new RegistroList<RegistroC600>();
			RegistroC700 = new RegistroList<RegistroC700>();
			RegistroC800 = new RegistroList<RegistroC800>();
			RegistroC860 = new RegistroList<RegistroC860>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public RegistroList<RegistroC100> RegistroC100 { get; private set; }

		public RegistroList<RegistroC300> RegistroC300 { get; private set; }

		public RegistroList<RegistroC350> RegistroC350 { get; private set; }

		public RegistroList<RegistroC400> RegistroC400 { get; private set; }

		public RegistroList<RegistroC495> RegistroC495 { get; private set; }

		public RegistroList<RegistroC500> RegistroC500 { get; private set; }

		public RegistroList<RegistroC600> RegistroC600 { get; private set; }

		public RegistroList<RegistroC700> RegistroC700 { get; private set; }

		public RegistroList<RegistroC800> RegistroC800 { get; private set; }

		public RegistroList<RegistroC860> RegistroC860 { get; private set; }

		#endregion Properties
	}
}