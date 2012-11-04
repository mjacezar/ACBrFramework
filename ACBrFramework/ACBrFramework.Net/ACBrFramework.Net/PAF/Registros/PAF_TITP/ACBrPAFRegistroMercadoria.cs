namespace ACBrFramework
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

		public double Aliquota { get; set; }

		public string Unidade { get; set; }

		public double Quantidade { get; set; }

		public string Ean { get; set; }

		public string CST { get; set; }

		public double VlrUnitario { get; set; }

		public ACBrPAFRegistroInsumos Insumos { get; private set; }

		#endregion Properties
	}
}