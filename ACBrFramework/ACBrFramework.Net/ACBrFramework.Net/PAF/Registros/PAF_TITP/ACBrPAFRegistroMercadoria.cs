namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistroMercadoria
	{
		#region Constructor

		public ACBrPAFRegistroMercadoria()
		{
			Insumos = new ACBrPAFRegistroInsumos();
		}

		#endregion Constructor

		#region Properties

		public string Descricao { get; set; }

		public string Codigo { get; set; }

		public decimal Aliquota { get; set; }

		public string Unidade { get; set; }

		public decimal Quantidade { get; set; }

		public string Ean { get; set; }

		public string CST { get; set; }

		public decimal VlrUnitario { get; set; }

		public ACBrPAFRegistroInsumos Insumos { get; private set; }

		#endregion Properties
	}
}