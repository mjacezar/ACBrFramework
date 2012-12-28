namespace ACBrFramework.Sped
{
	public class RegistroD150
	{
		#region Properties

		public string COD_MUN_ORIG { get; set; }

		public string COD_MUN_DEST { get; set; }

		public string VEIC_ID { get; set; }

		public string VIAGEM { get; set; }

		public TipoTarifa IND_TFA { get; set; }

		public decimal VL_PESO_TX { get; set; }

		public decimal VL_TX_TERR { get; set; }

		public decimal VL_TX_RED { get; set; }

		public decimal VL_OUT { get; set; }

		public decimal VL_TX_ADV { get; set; }

		#endregion Properties
	}
}