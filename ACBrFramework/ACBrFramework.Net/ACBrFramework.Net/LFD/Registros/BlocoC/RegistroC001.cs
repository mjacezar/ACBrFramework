namespace ACBrFramework.LFD
{
	public class RegistroC001
	{
		#region Constructor

		public RegistroC001()
		{
			RegistroC020 = new RegistroList<RegistroC020>();
			RegistroC550 = new RegistroList<RegistroC550>();
			RegistroC600 = new RegistroList<RegistroC600>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public int COD_MUN { get; set; }

		public RegistroList<RegistroC020> RegistroC020 { get; private set; }

		public RegistroList<RegistroC550> RegistroC550 { get; private set; }

		public RegistroList<RegistroC600> RegistroC600 { get; private set; }

		#endregion Properties
	}
}