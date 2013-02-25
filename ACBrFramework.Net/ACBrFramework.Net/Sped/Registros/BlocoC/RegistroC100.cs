using System;
using System.Collections.Generic;

namespace ACBrFramework.Sped
{
	public class RegistroC100
	{
		#region Constructor

		public RegistroC100()
		{
			RegistroC105 = new RegistroList<RegistroC105>();
			RegistroC110 = new RegistroList<RegistroC110>();
			RegistroC120 = new RegistroList<RegistroC120>();
			RegistroC130 = new RegistroList<RegistroC130>();
			RegistroC140 = new RegistroList<RegistroC140>();
			RegistroC160 = new RegistroList<RegistroC160>();
			RegistroC165 = new RegistroList<RegistroC165>();
			RegistroC170 = new RegistroList<RegistroC170>();
			RegistroC190 = new RegistroList<RegistroC190>();
			RegistroC195 = new RegistroList<RegistroC195>();
		}

		#endregion Constructor

		#region Properties

		public TipoOperacao IND_OPER { get; set; }

		public Emitente IND_EMIT { get; set; }

		public string COD_PART { get; set; }

		public string COD_MOD { get; set; }

		public SituacaoDocto COD_SIT { get; set; }

		public string SER { get; set; }

		public string NUM_DOC { get; set; }

		public string CHV_NFE { get; set; }

		public DateTime DT_DOC { get; set; }

		public DateTime DT_E_S { get; set; }

		public decimal VL_DOC { get; set; }

		public TipoPagamento IND_PGTO { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_ABAT_NT { get; set; }

		public decimal VL_MERC { get; set; }

		public TipoFrete IND_FRT { get; set; }

		public decimal VL_FRT { get; set; }

		public decimal VL_SEG { get; set; }

		public decimal VL_OUT_DA { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_BC_ICMS_ST { get; set; }

		public decimal VL_ICMS_ST { get; set; }

		public decimal VL_IPI { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public decimal VL_PIS_ST { get; set; }

		public decimal VL_COFINS_ST { get; set; }

		public RegistroList<RegistroC105> RegistroC105 { get; private set; }

		public RegistroList<RegistroC110> RegistroC110 { get; private set; }

		public RegistroList<RegistroC120> RegistroC120 { get; private set; }

		public RegistroList<RegistroC130> RegistroC130 { get; private set; }

		public RegistroList<RegistroC140> RegistroC140 { get; private set; }

		public RegistroList<RegistroC160> RegistroC160 { get; private set; }

		public RegistroList<RegistroC165> RegistroC165 { get; private set; }

		public RegistroList<RegistroC170> RegistroC170 { get; private set; }

		public RegistroList<RegistroC190> RegistroC190 { get; private set; }

		public RegistroList<RegistroC195> RegistroC195 { get; private set; }

		#endregion Properties
	}
}