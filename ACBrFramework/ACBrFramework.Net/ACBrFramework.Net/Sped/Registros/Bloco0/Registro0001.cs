namespace ACBrFramework.Sped
{
	public class Registro0001
	{
		#region Constructor

		public Registro0001()
		{
			Registro0005 = new Registro0005();
			Registro0015 = new RegistroList<Registro0015>();
			Registro0100 = new Registro0100();
			Registro0150 = new RegistroList<Registro0150>();
			Registro0190 = new RegistroList<Registro0190>();
			Registro0200 = new RegistroList<Registro0200>();
			Registro0300 = new RegistroList<Registro0300>();
			Registro0400 = new RegistroList<Registro0400>();
			Registro0450 = new RegistroList<Registro0450>();
			Registro0460 = new RegistroList<Registro0460>();
			Registro0500 = new RegistroList<Registro0500>();
			Registro0600 = new RegistroList<Registro0600>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public Registro0005 Registro0005 { get; set; }

		public RegistroList<Registro0015> Registro0015 { get; private set; }

		public Registro0100 Registro0100 { get; set; }

		public RegistroList<Registro0150> Registro0150 { get; private set; }

		public RegistroList<Registro0190> Registro0190 { get; private set; }

		public RegistroList<Registro0200> Registro0200 { get; private set; }

		public RegistroList<Registro0300> Registro0300 { get; private set; }

		public RegistroList<Registro0400> Registro0400 { get; private set; }

		public RegistroList<Registro0450> Registro0450 { get; private set; }

		public RegistroList<Registro0460> Registro0460 { get; private set; }

		public RegistroList<Registro0500> Registro0500 { get; private set; }

		public RegistroList<Registro0600> Registro0600 { get; private set; }

		#endregion Properties
	}
}