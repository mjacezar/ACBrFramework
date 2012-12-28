using System;

namespace ACBrFramework.Sped
{
	public class Registro1105
	{
		#region Constructor

		public Registro1105()
		{
			Registro1110 = new RegistroList<Registro1110>();
		}

		#endregion Constructor

		#region Properties

		public string COD_MOD { get; set; }

		public string SERIE { get; set; }

		public string NUM_DOC { get; set; }

		public string CHV_NFE { get; set; }

		public DateTime DT_DOC { get; set; }

		public string COD_ITEM { get; set; }

		public RegistroList<Registro1110> Registro1110 { get; private set; }

		#endregion Properties
	}
}