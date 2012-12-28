namespace ACBrFramework.Sped
{
	public class Registro0200
	{
		#region Constructor

		public Registro0200()
		{
			Registro0205 = new RegistroList<Registro0205>();
			Registro0206 = new RegistroList<Registro0206>();
			Registro0220 = new RegistroList<Registro0220>();
		}

		#endregion Constructor

		#region Properties

		public string COD_ITEM { get; set; }

		public string DESCR_ITEM { get; set; }

		public string COD_BARRA { get; set; }

		public string COD_ANT_ITEM { get; set; }

		public string UNID_INV { get; set; }

		public TipoItem TIPO_ITEM { get; set; }

		public string COD_NCM { get; set; }

		public string EX_IPI { get; set; }

		public string COD_GEN { get; set; }

		public string COD_LST { get; set; }

		public decimal ALIQ_ICMS { get; set; }

		public RegistroList<Registro0205> Registro0205 { get; private set; }

		public RegistroList<Registro0206> Registro0206 { get; private set; }

		public RegistroList<Registro0220> Registro0220 { get; private set; }

		#endregion Properties
	}
}