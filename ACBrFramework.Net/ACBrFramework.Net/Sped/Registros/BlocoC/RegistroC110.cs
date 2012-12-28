namespace ACBrFramework.Sped
{
	public class RegistroC110
	{
		#region Constructor

		public RegistroC110()
		{
			RegistroC111 = new RegistroList<RegistroC111>();
			RegistroC112 = new RegistroList<RegistroC112>();
			RegistroC113 = new RegistroList<RegistroC113>();
			RegistroC114 = new RegistroList<RegistroC114>();
			RegistroC115 = new RegistroList<RegistroC115>();
			RegistroC116 = new RegistroList<RegistroC116>();
		}

		#endregion Constructor

		#region Properties

		public string COD_INF { get; set; }

		public string TXT_COMPL { get; set; }

		public RegistroList<RegistroC111> RegistroC111 { get; private set; }

		public RegistroList<RegistroC112> RegistroC112 { get; private set; }

		public RegistroList<RegistroC113> RegistroC113 { get; private set; }

		public RegistroList<RegistroC114> RegistroC114 { get; private set; }

		public RegistroList<RegistroC115> RegistroC115 { get; private set; }

		public RegistroList<RegistroC116> RegistroC116 { get; private set; }

		#endregion Properties
	}
}