using System;

namespace ACBrFramework.Sped
{
	public class RegistroC600
	{
		#region Constructor

		public RegistroC600()
		{
			RegistroC601 = new RegistroList<RegistroC601>();

			RegistroC610 = new RegistroList<RegistroC610>();

			RegistroC690 = new RegistroList<RegistroC690>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string COD_MUN { get; set; }

		public string SER { get; set; }

		public string SUB { get; set; }

		public string COD_CONS { get; set; }

		public decimal QTD_CONS { get; set; }

		public decimal QTD_CANC { get; set; }

		public DateTime DT_DOC { get; set; }

		public decimal VL_DOC { get; set; }

		public decimal VL_DESC { get; set; }

		public decimal CONS { get; set; }

		public decimal VL_FORN { get; set; }

		public decimal VL_SERV_NT { get; set; }

		public decimal VL_TERC { get; set; }

		public decimal VL_DA { get; set; }

		public decimal VL_BC_ICMS { get; set; }

		public decimal VL_ICMS { get; set; }

		public decimal VL_BC_ICMS_ST { get; set; }

		public decimal VL_ICMS_ST { get; set; }

		public decimal VL_PIS { get; set; }

		public decimal VL_COFINS { get; set; }

		public RegistroList<RegistroC601> RegistroC601 { get; private set; }

		public RegistroList<RegistroC610> RegistroC610 { get; private set; }

		public RegistroList<RegistroC690> RegistroC690 { get; private set; }

		#endregion Properties
	}
}