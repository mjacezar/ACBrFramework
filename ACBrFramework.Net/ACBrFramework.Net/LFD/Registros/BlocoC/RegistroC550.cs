using System;
namespace ACBrFramework.LFD
{
	public class RegistroC550
	{
		#region Constructor

		public RegistroC550()
		{
			RegistroC555 = new RegistroList<RegistroC555>();
		}

		#endregion Constructor

		#region Properties

		public string CPF_CONS { get; set; }
		
		public string CNPJ_CONS { get; set; }
		
		public string COD_MOD { get; set; }
		
		public SituacaoDocto COD_SIT { get; set; }
		
		public string SER { get; set; }
		
		public string SUB { get; set; }
		
		public int NUM_DOC { get; set; }
		
		public DateTime DT_DOC { get; set; }
		
		public string COP { get; set; }
		
		public decimal VL_DOC { get; set; }
		
		public decimal VL_DESC { get; set; }
		
		public decimal VL_ACMO { get; set; }
		
		public decimal VL_MERC { get; set; }
		
		public decimal VL_BC_ICMS { get; set; }
		
		public decimal VL_ICMS { get; set; }
		
		public string COD_INF_OBS { get; set; }

		public RegistroList<RegistroC555> RegistroC555 { get; private set; }

		#endregion Properties
	}
}