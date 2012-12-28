namespace ACBrFramework.Sped
{
	public class RegistroD140
	{
		#region Properties

		public string COD_PART_CONSG { get; set; }

		public string COD_MUN_ORIG { get; set; }

		public string COD_MUN_DEST { get; set; }

		public string IND_VEIC { get; set; }

		public TipoVeiculo VEIC_ID { get; set; }

		public TipoNavegacao IND_NAV { get; set; }

		public string VIAGEM { get; set; }

		public decimal VL_FRT_LIQ { get; set; }

		public decimal VL_DESP_PORT { get; set; }

		public decimal VL_DESP_CAR_DESC { get; set; }

		public decimal VL_OUT { get; set; }

		public decimal VL_FRT_BRT { get; set; }

		public decimal VL_FRT_MM { get; set; }

		#endregion Properties
	}
}