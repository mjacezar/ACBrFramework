using System;
namespace ACBrFramework.LFD
{
	public class Registro0210
	{
		#region Properties

		public string UNID_ITEM { get; set; }
		
		public string COD_ITEM_COMP { get; set; }
		
		public decimal QTD_COMP { get; set; }
		
		public string UNID_COMP { get; set; }
		
		public decimal PERDA_COMP { get; set; }
		
		public DateTime DT_INI_COMP { get; set; }
		
		public DateTime DT_FIN_COMP { get; set; }
		
		public IndAlteracao IND_ALT { get; set; }

		#endregion Properties
	}
}