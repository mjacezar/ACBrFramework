namespace ACBrFramework.LFD
{
	public class Registro0001
	{
		#region Constructor

		public Registro0001()
		{
			Registro0005 = new Registro0005();
			Registro0025 = new RegistroList<Registro0025>();

			Registro0100 = new Registro0100();
			Registro0150 = new RegistroList<Registro0150>();
			Registro0200 = new RegistroList<Registro0200>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public int COD_MUN { get; set; }

		public Registro0005 Registro0005 { get; set; }

		public RegistroList<Registro0025> Registro0025 { get; private set; }

		public Registro0100 Registro0100 { get; set; }

		public RegistroList<Registro0150> Registro0150 { get; private set; }

		public RegistroList<Registro0200> Registro0200 { get; private set; }

		#endregion Properties
	}
}