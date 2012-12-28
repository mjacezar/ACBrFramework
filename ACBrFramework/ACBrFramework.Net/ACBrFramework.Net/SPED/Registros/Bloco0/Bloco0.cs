using System;

namespace ACBrFramework.Sped
{
	public class Bloco0
	{
		#region Constructor

		public Bloco0()
		{
			Registro0000 = new Registro0000();
			Registro0001 = new Registro0001();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public Registro0000 Registro0000 { get; private set; }

		public Registro0001 Registro0001 { get; private set; }

		public Registro0990 Registro0990 { get; private set; }

		#endregion Properties
	}
}