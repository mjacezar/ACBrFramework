using System;

namespace ACBrFramework.Sped
{
	public class RegistroE200
	{
		#region Constructor

		public RegistroE200()
		{
			RegistroE210 = new RegistroList<RegistroE210>();
		}

		#endregion Constructor

		#region Properties

		public string UF { get; set; }

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public RegistroList<RegistroE210> RegistroE210 { get; set; }

		#endregion Properties
	}
}