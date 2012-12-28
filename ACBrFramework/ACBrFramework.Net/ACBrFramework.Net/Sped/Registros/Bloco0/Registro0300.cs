namespace ACBrFramework.Sped
{
	public class Registro0300
	{
		#region Constructor

		public Registro0300()
		{
			Registro0305 = new RegistroList<Registro0305>();
		}

		#endregion Constructor

		#region Properties

		public string COD_IND_BEM { get; set; }

		public int IDENT_MERC { get; set; }

		public string DESCR_ITEM { get; set; }

		public string COD_PRNC { get; set; }

		public string COD_CTA { get; set; }

		public decimal NR_PARC { get; set; }

		public RegistroList<Registro0305> Registro0305 { get; private set; }

		#endregion Properties
	}
}