namespace ACBrFramework.Sped
{
	public class RegistroC170
	{
		#region Constructor

		public RegistroC170()
		{
			RegistroC171 = new RegistroList<RegistroC171>();
			RegistroC172 = new RegistroList<RegistroC172>();
			RegistroC173 = new RegistroList<RegistroC173>();
			RegistroC174 = new RegistroList<RegistroC174>();
			RegistroC175 = new RegistroList<RegistroC175>();
			RegistroC176 = new RegistroList<RegistroC176>();
			RegistroC177 = new RegistroList<RegistroC177>();
			RegistroC178 = new RegistroList<RegistroC178>();
			RegistroC179 = new RegistroList<RegistroC179>();
		}

		#endregion Constructor

		#region Properties

		public string NUM_ITEM { get; set; }

		public string COD_ITEM { get; set; }

		public string DESCR_COMPL { get; set; }

		public decimal QTD { get; set; }

		public string UNID { get; set; }

		public decimal VL_ITEM { get; set; }

		public decimal VL_DESC { get; set; }

		public MovimentacaoFisica IND_MOV { get; set; }

		public string CST_ICMS { get; set; }

		public string CFOP { get; set; }

		public string COD_NAT { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal ALIQ_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_BC_ICMS_ST { get; set; }

		public decimal ALIQ_ST { get; set; }

		public decimal VL_ICMS_ST { get; set; }

		public ApuracaoIPI IND_APUR { get; set; }

		public string CST_IPI { get; set; }

		public string COD_ENQ { get; set; }

		public decimal VL_BC_IPI { get; set; }

		public decimal ALIQ_IPI { get; set; }

		public decimal VL_IPI { get; set; }

		public string CST_PIS { get; set; }

		public decimal VL_BC_PIS { get; set; }

		public decimal ALIQ_PIS_PERC { get; set; }

		public decimal QUANT_BC_PIS { get; set; }

		public decimal ALIQ_PIS_R { get; set; }

		public decimal VL_PIS { get; set; }

		public string CST_COFINS { get; set; }

		public decimal VL_BC_COFINS { get; set; }

		public decimal ALIQ_COFINS_PERC { get; set; }

		public decimal QUANT_BC_COFINS { get; set; }

		public decimal ALIQ_COFINS_R { get; set; }

		public decimal VL_COFINS { get; set; }

		public string COD_CTA { get; set; }

		public RegistroList<RegistroC171> RegistroC171 { get; private set; }

		public RegistroList<RegistroC172> RegistroC172 { get; private set; }

		public RegistroList<RegistroC173> RegistroC173 { get; private set; }

		public RegistroList<RegistroC174> RegistroC174 { get; private set; }

		public RegistroList<RegistroC175> RegistroC175 { get; private set; }

		public RegistroList<RegistroC176> RegistroC176 { get; private set; }

		public RegistroList<RegistroC177> RegistroC177 { get; private set; }

		public RegistroList<RegistroC178> RegistroC178 { get; private set; }

		public RegistroList<RegistroC179> RegistroC179 { get; private set; }

		#endregion Properties
	}
}