namespace ACBrFramework.Sped
{
	public class Registro1350
	{
		public string SERIE { get; set; }

		public string FABRICANTE { get; set; }

		public string MODELO { get; set; }

		public Medicao TIPO_MEDICAO { get; set; }

		public RegistroList<Registro1360> Registro1360 { get; private set; }

		public RegistroList<Registro1370> Registro1370 { get; private set; }
	}
}