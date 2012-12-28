namespace ACBrFramework.Sped
{
	public class RegistroH010
	{
		#region Constructor

		public RegistroH010()
		{
			RegistroH020 = new RegistroList<RegistroH020>();
		}

		#endregion Constructor

		#region Properties

		public string COD_ITEM { get; set; }

		public string UNID { get; set; }

		public decimal QTD { get; set; }

		public decimal VL_UNIT { get; set; }

		public decimal VL_ITEM { get; set; }

		public PosseItem IND_PROP { get; set; }

		public string COD_PART { get; set; }

		public string TXT_COMPL { get; set; }

		public string COD_CTA { get; set; }

		public RegistroList<RegistroH020> RegistroH020 { get; private set; }

		#endregion Properties
	}
}