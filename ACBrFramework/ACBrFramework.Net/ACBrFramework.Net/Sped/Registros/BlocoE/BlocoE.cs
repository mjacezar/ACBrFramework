using System;

namespace ACBrFramework.Sped
{
	public class BlocoE
	{
		#region Constructor

		public BlocoE()
		{
			RegistroE001 = new RegistroE001();
			RegistroE990 = new RegistroE990();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public RegistroE001 RegistroE001 { get; set; }

		public RegistroE990 RegistroE990 { get; set; }

		#endregion Properties
	}
}