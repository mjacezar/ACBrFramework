using System;

namespace ACBrFramework.Sped
{
	public class RegistroE100
	{
		#region Constructor

		public RegistroE100()
		{
			RegistroE110 = new RegistroE110();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI { get; set; }

		public DateTime DT_FIN { get; set; }

		public RegistroE110 RegistroE110 { get; set; }

		#endregion Properties
	}
}