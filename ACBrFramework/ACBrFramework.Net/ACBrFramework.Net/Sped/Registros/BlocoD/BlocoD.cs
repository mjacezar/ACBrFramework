using System;

namespace ACBrFramework.Sped
{
	public class BlocoD
	{
		#region Constructor

		public BlocoD()
		{
			RegistroD001 = new RegistroD001();
			RegistroD990 = new RegistroD990();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public RegistroD001 RegistroD001 { get; set; }

		public RegistroD990 RegistroD990 { get; set; }

		#endregion Properties
	}
}