using System;

namespace ACBrFramework.Sped
{
	public class BlocoH
	{
		#region Constructor

		public BlocoH()
		{
			RegistroH001 = new RegistroH001();
			RegistroH990 = new RegistroH990();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public RegistroH001 RegistroH001 { get; set; }

		public RegistroH990 RegistroH990 { get; set; }

		#endregion Properties
	}
}