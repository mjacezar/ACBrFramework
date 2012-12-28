using System;

namespace ACBrFramework.Sped
{
	public class RegistroD100
	{
		#region Constructor

		public RegistroD100()
		{
			RegistroD110 = new RegistroList<RegistroD110>();
			RegistroD130 = new RegistroList<RegistroD130>();
			RegistroD140 = new RegistroList<RegistroD140>();
			RegistroD150 = new RegistroList<RegistroD150>();
			RegistroD160 = new RegistroList<RegistroD160>();
			RegistroD170 = new RegistroList<RegistroD170>();
			RegistroD180 = new RegistroList<RegistroD180>();
			RegistroD190 = new RegistroList<RegistroD190>();
			RegistroD195 = new RegistroList<RegistroD195>();
		}

		#endregion Constructor

		#region Properties

		public TipoOperacao IND_OPER { get; set; }

		public Emitente IND_EMIT { get; set; }

		public string COD_PART { get; set; }

		public string COD_MOD { get; set; }

		public SituacaoDocto COD_SIT { get; set; }

		public string SER { get; set; }

		public string SUB { get; set; }

		public string NUM_DOC { get; set; }

		public string CHV_CTE { get; set; }

		public DateTime DT_DOC { get; set; }

		public DateTime DT_A_P { get; set; }

		public string TP_CT_e { get; set; }

		public string CHV_CTE_REF { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_DESC { get; set; }

		public TipoFrete IND_FRT { get; set; }

		public decimal VL_SERV { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_NT { get; set; }

		public string COD_INF { get; set; }

		public string COD_CTA { get; set; }

		public RegistroList<RegistroD110> RegistroD110 { get; private set; }

		public RegistroList<RegistroD130> RegistroD130 { get; private set; }

		public RegistroList<RegistroD140> RegistroD140 { get; private set; }

		public RegistroList<RegistroD150> RegistroD150 { get; private set; }

		public RegistroList<RegistroD160> RegistroD160 { get; private set; }

		public RegistroList<RegistroD170> RegistroD170 { get; private set; }

		public RegistroList<RegistroD180> RegistroD180 { get; private set; }

		public RegistroList<RegistroD190> RegistroD190 { get; private set; }

		public RegistroList<RegistroD195> RegistroD195 { get; private set; }

		#endregion Properties
	}
}