using System;
namespace ACBrFramework.LFD
{
	public class RegistroC600
	{
		#region Constructor

		public RegistroC600()
		{
			RegistroC605 = new RegistroList<RegistroC605>();
		}

		#endregion Constructor

		#region Properties

		public string CPF_CONS { get; set; }
		
		public string CNPJ_CONS { get; set; }
		
		public string COD_MOD { get; set; }
		
		public SituacaoDocto COD_SIT { get; set; }
		
		public int ECF_CX { get; set; }
		
		public string ECF_FAB { get; set; }
		
		public int CRO { get; set; }
		
		public int CRZ { get; set; }
		
		public int NUM_DOC { get; set; }
		
		public DateTime DT_DOC { get; set; }
		
		public string COP { get; set; }
		
		public decimal VL_DOC { get; set; }
		
		public decimal VL_CANC_ICMS { get; set; }
		
		public decimal VL_DESC_ICMS { get; set; }
		
		public decimal VL_ACMO_ICMS { get; set; }
		
		public decimal VL_CANC_ISS { get; set; }
		
		public decimal VL_DESC_ISS { get; set; }
		
		public decimal VL_ACMO_ISS { get; set; }
		
		public decimal VL_BC_ICMS { get; set; }
		
		public decimal VL_ICMS { get; set; }
		
		public decimal VL_ISN { get; set; }
		
		public decimal VL_NT { get; set; }
		
		public decimal VL_ST { get; set; }
		
		public decimal VL_ISS { get; set; }
		
		public decimal VL_ICMS_ST { get; set; }

		public RegistroList<RegistroC605> RegistroC605 { get; private set; } 

		#endregion Properties
	}
}