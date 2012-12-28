namespace ACBrFramework.Sped
{
	public class RegistroE001
	{
		#region Constructor

		public RegistroE001()
		{
			RegistroE100 = new RegistroList<RegistroE100>();
			RegistroE200 = new RegistroList<RegistroE200>();
			RegistroE500 = new RegistroList<RegistroE500>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public RegistroList<RegistroE100> RegistroE100 { get; private set; }

		public RegistroList<RegistroE200> RegistroE200 { get; private set; }

		public RegistroList<RegistroE500> RegistroE500 { get; private set; }

		#endregion Properties
	}
}