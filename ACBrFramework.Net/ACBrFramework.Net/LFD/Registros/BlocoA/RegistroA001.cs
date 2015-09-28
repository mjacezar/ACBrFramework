namespace ACBrFramework.LFD
{
	public class RegistroA001
	{
		#region Constructor

		public RegistroA001()
		{
			RegistroA350 = new RegistroList<RegistroA350>();
		}

		#endregion Constructor

		#region Properties

		public IndicadorMovimento IND_MOV { get; set; }

		public int COD_MUN { get; set; }

		public RegistroList<RegistroA350> RegistroA350 { get; private set; }

		#endregion Properties
	}
}