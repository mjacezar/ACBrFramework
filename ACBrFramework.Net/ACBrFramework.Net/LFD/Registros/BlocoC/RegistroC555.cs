using System;
namespace ACBrFramework.LFD
{
	public class RegistroC555
	{
		#region Constructor

		public RegistroC555()
		{
		}

		#endregion Constructor

		#region Properties

		public int NUM_ITEM { get; set; }

		public string COD_ITEM { get; set; }
		
		public string UNID { get; set; }
		
		public decimal VL_UNIT { get; set; }
		
		public decimal QTD { get; set; }
		
		public decimal VL_DESC_I { get; set; }
		
		public decimal VL_ACMO_I { get; set; }
		
		public decimal VL_ITEM { get; set; }
		
		public string CST { get; set; }
		
		public string CFOP { get; set; }
		
		public decimal VL_BC_ICMS_I { get; set; }
		
		public decimal ALIQ_ICMS { get; set; }
		
		public decimal VL_ICMS_I { get; set; }

		#endregion Properties
	}
}