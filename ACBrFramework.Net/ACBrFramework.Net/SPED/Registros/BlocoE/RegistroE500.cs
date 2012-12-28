using System;

namespace ACBrFramework.Sped
{
	public class RegistroE500
	{
		#region Constructor

		public RegistroE500()
		{
			RegistroE510 = new RegistroList<RegistroE510>();
			RegistroE520 = new RegistroList<RegistroE520>();
		}

		#endregion Constructor

		#region Properties

		public ApuracaoIPI IND_APUR { get; set; }

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public RegistroList<RegistroE510> RegistroE510 { get; private set; }

		public RegistroList<RegistroE520> RegistroE520 { get; private set; }

		#endregion Properties
	}
}