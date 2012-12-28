namespace ACBrFramework.Sped
{
	public class Registro1310
	{
		public string NUM_TANQUE { get; set; }

		public decimal ESTQ_ABERT { get; set; }

		public decimal VOL_ENTR { get; set; }

		public decimal VOL_DISP { get; set; }

		public decimal VOL_SAIDAS { get; set; }

		public decimal ESTQ_ESCR { get; set; }

		public decimal VAL_AJ_PERDA { get; set; }

		public decimal VAL_AJ_GANHO { get; set; }

		public decimal FECH_FISICO { get; set; }

		public RegistroList<Registro1320> Registro1320 { get; private set; }
	}
}