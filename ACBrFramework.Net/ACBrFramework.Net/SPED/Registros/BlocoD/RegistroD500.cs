using System;

namespace ACBrFramework.Sped
{
	public class RegistroD500
	{
		#region Constructor

		public RegistroD500()
		{
			RegistroD510 = new RegistroList<RegistroD510>();
			RegistroD530 = new RegistroList<RegistroD530>();
			RegistroD590 = new RegistroList<RegistroD590>();
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

		public DateTime DT_DOC { get; set; }

		public DateTime DT_A_P { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_SERV { get; set; }

		public decimal VL_SERV_NT { get; set; }

		public decimal VL_TERC { get; set; }

		public decimal VL_DA { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public string COD_INF { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public string COD_CTA { get; set; }

		public TipoAssinante TP_ASSINANTE { get; set; }

		public RegistroList<RegistroD510> RegistroD510 { get; private set; }

		public RegistroList<RegistroD530> RegistroD530 { get; private set; }

		public RegistroList<RegistroD590> RegistroD590 { get; private set; }

		#endregion Properties
	}
}