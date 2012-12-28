namespace ACBrFramework.Sped
{
	public class RegistroH001
	{
		#region Constructor

		public RegistroH001()
		{
			RegistroH005 = new RegistroList<RegistroH005>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public RegistroList<RegistroH005> RegistroH005 { get; private set; }

		#endregion Properties
	}
}