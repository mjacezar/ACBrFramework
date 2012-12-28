namespace ACBrFramework.Sped
{
	public class RegistroD160
	{
		#region Constructor

		public RegistroD160()
		{
			RegistroD161 = new RegistroList<RegistroD161>();
			RegistroD162 = new RegistroList<RegistroD162>();
		}

		#endregion Constructor

		#region Properties

		public string DESPACHO { get; set; }

		public string CNPJ_CPF_REM { get; set; }

		public string IE_REM { get; set; }

		public string COD_MUN_ORI { get; set; }

		public string CNPJ_CPF_DEST { get; set; }

		public string IE_DEST { get; set; }

		public string COD_MUN_DEST { get; set; }

		public RegistroList<RegistroD161> RegistroD161 { get; private set; }

		public RegistroList<RegistroD162> RegistroD162 { get; private set; }

		#endregion Properties
	}
}