using System;

namespace ACBrFramework.Sped
{
	public class RegistroC500
	{
		#region Constructor

		public RegistroC500()
		{
			RegistroC510 = new RegistroList<RegistroC510>();

			RegistroC590 = new RegistroList<RegistroC590>();
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

		public string COD_CONS { get; set; }

		public string NUM_DOC { get; set; }

		public DateTime DT_DOC { get; set; }

		public DateTime DT_E_S { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal VL_FORN { get; set; }

		public decimal VL_SERV_NT { get; set; }

		public decimal VL_TERC { get; set; }

		public decimal VL_DA { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_BC_ICMS_ST { get; set; }

		public decimal VL_ICMS_ST { get; set; }

		public string COD_INF { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public TipoLigacao TP_LIGACAO { get; set; }

		public GrupoTensao COD_GRUPO_TENSAO { get; set; }

		public RegistroList<RegistroC510> RegistroC510 { get; private set; }

		public RegistroList<RegistroC590> RegistroC590 { get; private set; }

		#endregion Properties
	}
}