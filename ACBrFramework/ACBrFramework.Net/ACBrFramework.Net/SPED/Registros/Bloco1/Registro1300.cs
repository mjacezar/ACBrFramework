using System;

namespace ACBrFramework.Sped
{
	public class Registro1300
	{
		public Registro1300()
		{
			Registro1310 = new RegistroList<Registro1310>();
		}

		#region Properties

		public string COD_ITEM { get; set; }

		public DateTime DT_FECH { get; set; }

		public decimal ESTQ_ABERT { get; set; }

		public decimal VOL_ENTR { get; set; }

		public decimal VOL_DISP { get; set; }

		public decimal VOL_SAIDAS { get; set; }

		public decimal ESTQ_ESCR { get; set; }

		public decimal VAL_AJ_PERDA { get; set; }

		public decimal VAL_AJ_GANHO { get; set; }

		public decimal FECH_FISICO { get; set; }

		public RegistroList<Registro1310> Registro1310 { get; private set; }

		#endregion Properties
	}
}