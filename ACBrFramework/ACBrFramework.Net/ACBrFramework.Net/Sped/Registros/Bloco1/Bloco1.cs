using System;

namespace ACBrFramework.Sped
{
	public class Bloco1
	{
		#region Constructor

		public Bloco1()
		{
			Registro1010 = new RegistroList<Registro1010>();
			Registro1100 = new RegistroList<Registro1100>();
			Registro1200 = new RegistroList<Registro1200>();
			Registro1300 = new RegistroList<Registro1300>();
			Registro1350 = new RegistroList<Registro1350>();
			Registro1390 = new RegistroList<Registro1390>();
			Registro1400 = new RegistroList<Registro1400>();
			Registro1500 = new RegistroList<Registro1500>();
			Registro1600 = new RegistroList<Registro1600>();
			Registro1700 = new RegistroList<Registro1700>();
			Registro1800 = new RegistroList<Registro1800>();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public RegistroList<Registro1010> Registro1010 { get; private set; }

		public RegistroList<Registro1100> Registro1100 { get; private set; }

		public RegistroList<Registro1200> Registro1200 { get; private set; }

		public RegistroList<Registro1300> Registro1300 { get; private set; }

		public RegistroList<Registro1350> Registro1350 { get; private set; }

		public RegistroList<Registro1390> Registro1390 { get; private set; }

		public RegistroList<Registro1400> Registro1400 { get; private set; }

		public RegistroList<Registro1500> Registro1500 { get; private set; }

		public RegistroList<Registro1600> Registro1600 { get; private set; }

		public RegistroList<Registro1700> Registro1700 { get; private set; }

		public RegistroList<Registro1800> Registro1800 { get; private set; }

		#endregion Properties
	}
}