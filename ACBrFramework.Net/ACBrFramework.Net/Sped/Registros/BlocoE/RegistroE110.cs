namespace ACBrFramework.Sped
{
	public class RegistroE110
	{
		#region Constructor

		internal RegistroE110()
		{
			RegistroE111 = new RegistroList<RegistroE111>();
			RegistroE115 = new RegistroList<RegistroE115>();
			RegistroE116 = new RegistroList<RegistroE116>();
		}

		#endregion Constructor

		#region Properties

		public decimal VL_TOT_DEBITOS { get; set; }

		public decimal VL_AJ_DEBITOS { get; set; }

		public decimal VL_TOT_AJ_DEBITOS { get; set; }

		public decimal VL_ESTORNOS_CRED { get; set; }

		public decimal VL_TOT_CREDITOS { get; set; }

		public decimal VL_AJ_CREDITOS { get; set; }

		public decimal VL_TOT_AJ_CREDITOS { get; set; }

		public decimal VL_ESTORNOS_DEB { get; set; }

		public decimal VL_SLD_CREDOR_ANT { get; set; }

		public decimal VL_SLD_APURADO { get; set; }

		public decimal VL_TOT_DED { get; set; }

		public decimal VL_ICMS_RECOLHER { get; set; }

		public decimal VL_SLD_CREDOR_TRANSPORTAR { get; set; }

		public decimal DEB_ESP { get; set; }

		public RegistroList<RegistroE111> RegistroE111 { get; private set; }

		public RegistroList<RegistroE115> RegistroE115 { get; private set; }

		public RegistroList<RegistroE116> RegistroE116 { get; private set; }

		#endregion Properties
	}
}