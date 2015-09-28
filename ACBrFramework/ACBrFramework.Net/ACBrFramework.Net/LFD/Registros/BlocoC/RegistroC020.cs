using System;

namespace ACBrFramework.LFD
{
	public class RegistroC020
	{
		#region Constructor

		public RegistroC020()
		{
		}

		#endregion Constructor

		#region Properties

		public TipoOperacao IND_OPER { get; set; }
		
		public Emitente IND_EMIT { get; set; }
		
		public string COD_PART { get; set; }
		
		public string COD_MOD { get; set; }
		
		public SituacaoDocto COD_SIT { get; set; }
		
		public string SER { get; set; }
		
		public int NUM_DOC { get; set; }
		
		public string CHV_NFE { get; set; }
		
		public DateTime DT_EMIS { get; set; }
		
		public DateTime DT_DOC { get; set; }
		
		public string COD_NAT { get; set; }
		
		public TipoPagamento IND_PGTO { get; set; }
		
		public decimal VL_DOC { get; set; }
		
		public decimal VL_DESC { get; set; }
		
		public decimal VL_ACMO { get; set; }
		
		public decimal VL_MERC { get; set; }
		
		public TipoFrete IND_FRT { get; set; }
		
		public decimal VL_FRT { get; set; }
		
		public decimal VL_SEG { get; set; }
		
		public decimal VL_OUT_DA { get; set; }
		
		public decimal VL_BC_ICMS { get; set; }
		
		public decimal VL_ICMS { get; set; }
		
		public decimal VL_BC_ST { get; set; }
		
		public decimal VL_ICMS_ST { get; set; }
		
		public decimal VL_AT { get; set; }
		
		public decimal VL_IPI { get; set; }
		
		public string COD_INF_OBS { get; set; }

		#endregion Properties
	}
}