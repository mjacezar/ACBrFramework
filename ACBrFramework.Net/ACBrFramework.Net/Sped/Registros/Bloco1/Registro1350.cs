namespace ACBrFramework.Sped
{
	public class Registro1350
	{
		#region Constructor

		public Registro1350()
		{
			Registro1360 = new RegistroList<Registro1360>();
			Registro1370 = new RegistroList<Registro1370>();
		}

		#endregion Constructor

		#region Properties

		public string SERIE { get; set; }

		public string FABRICANTE { get; set; }

		public string MODELO { get; set; }

		public Medicao TIPO_MEDICAO { get; set; }

		public RegistroList<Registro1360> Registro1360 { get; private set; }

		public RegistroList<Registro1370> Registro1370 { get; private set; }

		#endregion Properties
	}
}