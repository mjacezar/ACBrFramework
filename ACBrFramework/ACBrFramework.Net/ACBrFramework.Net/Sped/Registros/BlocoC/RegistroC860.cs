using System;

namespace ACBrFramework.Sped
{
	public class RegistroC860
	{
		#region Constructor

		public RegistroC860()
		{
			RegistroC890 = new RegistroList<RegistroC890>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string NR_SAT { get; set; }

		public DateTime DT_DOC { get; set; }

		public string DOC_INI { get; set; }

		public string DOC_FIN { get; set; }

		public RegistroList<RegistroC890> RegistroC890 { get; private set; }

		#endregion Properties
	}
}