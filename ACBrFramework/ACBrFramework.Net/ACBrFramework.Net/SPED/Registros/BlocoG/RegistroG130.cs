using System;

namespace ACBrFramework.Sped
{
	public class RegistroG130
	{
		#region Constructor

		public RegistroG130()
		{
			RegistroG140 = new RegistroList<RegistroG140>();
		}

		#endregion Constructor

		#region Properties

		public Emitente IND_EMIT { get; set; }

		public string COD_PART { get; set; }

		public string COD_MOD { get; set; }

		public string SERIE { get; set; }

		public string NUM_DOC { get; set; }

		public string CHV_NFE_CTE { get; set; }

		public DateTime DT_DOC { get; set; }

		public RegistroList<RegistroG140> RegistroG140 { get; private set; }

		#endregion Properties
	}
}