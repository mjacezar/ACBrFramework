using System;

namespace ACBrFramework.Sped
{
	public class Bloco9
	{
		#region Constructor

		internal Bloco9()
		{
			Registro9001 = new Registro9001();
			Registro9900 = new RegistroList<Registro9900>();
			Registro9990 = new Registro9990();
			Registro9999 = new Registro9999();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public Registro9001 Registro9001 { get; set; }

		public RegistroList<Registro9900> Registro9900 { get; private set; }

		public Registro9990 Registro9990 { get; set; }

		public Registro9999 Registro9999 { get; set; }

		#endregion Properties
	}
}