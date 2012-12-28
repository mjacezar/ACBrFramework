using System;

namespace ACBrFramework.Sped
{
	public class BlocoC
	{
		#region Constructor

		public BlocoC()
		{
			RegistroC001 = new RegistroC001();
			RegistroC990 = new RegistroC990();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public bool Gravado { get; set; }

		public RegistroC001 RegistroC001 { get; set; }

		public RegistroC990 RegistroC990 { get; set; }

		#endregion Properties
	}
}