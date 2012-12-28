namespace ACBrFramework.Sped
{
	public class RegistroE210
	{
		#region Constructor

		public RegistroE210()
		{
			RegistroE220 = new RegistroList<RegistroE220>();
			RegistroE250 = new RegistroList<RegistroE250>();
		}

		#endregion Constructor

		#region Properties

		public MovimentoST IND_MOV_ST { get; set; }

		public decimal VL_SLD_CRED_ANT_ST { get; set; }

		public decimal VL_DEVOL_ST { get; set; }

		public decimal VL_RESSARC_ST { get; set; }

		public decimal VL_OUT_CRED_ST { get; set; }

		public decimal VL_AJ_CREDITOS_ST { get; set; }

		public decimal VL_RETENCAO_ST { get; set; }

		public decimal VL_OUT_DEB_ST { get; set; }

		public decimal VL_AJ_DEBITOS_ST { get; set; }

		public decimal VL_SLD_DEV_ANT_ST { get; set; }

		public decimal VL_DEDUCOES_ST { get; set; }

		public decimal VL_ICMS_RECOL_ST { get; set; }

		public decimal VL_SLD_CRED_ST_TRANSPORTAR { get; set; }

		public decimal DEB_ESP_ST { get; set; }

		public RegistroList<RegistroE220> RegistroE220 { get; private set; }

		public RegistroList<RegistroE250> RegistroE250 { get; private set; }

		#endregion Properties
	}
}