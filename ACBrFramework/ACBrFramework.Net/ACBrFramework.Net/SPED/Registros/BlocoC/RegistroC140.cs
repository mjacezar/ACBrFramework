namespace ACBrFramework.Sped
{
	public class RegistroC140
	{
		#region Constructor

		public RegistroC140()
		{
			RegistroC141 = new RegistroList<RegistroC141>();
		}

		#endregion Constructor

		#region Properties

		public Emitente IND_EMIT { get; set; }

		public TipoTitulo IND_TIT { get; set; }

		public string DESC_TIT { get; set; }

		public string NUM_TIT { get; set; }

		public int QTD_PARC { get; set; }

		public decimal VL_TIT { get; set; }

		public RegistroList<RegistroC141> RegistroC141 { get; private set; }

		#endregion Properties
	}
}