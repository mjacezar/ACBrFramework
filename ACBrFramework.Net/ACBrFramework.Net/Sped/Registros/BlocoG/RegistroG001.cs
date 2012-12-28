namespace ACBrFramework.Sped
{
	public class RegistroG001
	{
		#region Constructor

		public RegistroG001()
		{
			RegistroG110 = new RegistroList<RegistroG110>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public RegistroList<RegistroG110> RegistroG110 { get; private set; }

		#endregion Properties
	}
}