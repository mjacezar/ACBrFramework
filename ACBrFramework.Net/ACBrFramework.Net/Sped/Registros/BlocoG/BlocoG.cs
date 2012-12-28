using System;

namespace ACBrFramework.Sped
{
	public class BlocoG
	{
		#region Constructor

		public BlocoG()
		{
			RegistroG001 = new RegistroG001();
			RegistroG990 = new RegistroG990();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public RegistroG001 RegistroG001 { get; set; }

		public RegistroG990 RegistroG990 { get; set; }

		#endregion Properties
	}
}