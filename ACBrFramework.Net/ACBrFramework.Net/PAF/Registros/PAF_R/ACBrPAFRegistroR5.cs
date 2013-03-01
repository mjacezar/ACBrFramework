namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistroR5
	{
		#region Properties

		public int NUM_CONT { get; set; }

		public int NUM_ITEM { get; set; }

		public string COD_ITEM { get; set; }

		public string DESC_ITEM { get; set; }

		public decimal QTDE_ITEM { get; set; }

		public string UN_MED { get; set; }

		public decimal VL_UNIT { get; set; }

		public decimal DESCTO_ITEM { get; set; }

		public decimal ACRES_ITEM { get; set; }

		public decimal VL_TOT_ITEM { get; set; }

		public string COD_TOT_PARC { get; set; }

		public string IND_CANC { get; set; }

		public decimal QTDE_CANC { get; set; }

		public decimal VL_CANC { get; set; }

		public decimal VL_CANC_ACRES { get; set; }

		public string IAT { get; set; }

		public string IPPT { get; set; }

		public int QTDE_DECIMAL { get; set; }

		public int VL_DECIMAL { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}