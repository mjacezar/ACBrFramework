using System;

namespace ACBrFramework.Sped
{
	public class RegistroC405
	{
		#region Constructor

		public RegistroC405()
		{
			RegistroC410 = new RegistroList<RegistroC410>();
			RegistroC420 = new RegistroList<RegistroC420>();
			RegistroC460 = new RegistroList<RegistroC460>();
			RegistroC490 = new RegistroList<RegistroC490>();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_DOC { get; set; }

		public int CRO { get; set; }

		public int CRZ { get; set; }

		public int NUM_COO_FIN { get; set; }

		public decimal GT_FIN { get; set; }

		public decimal VL_BRT { get; set; }

		public RegistroList<RegistroC410> RegistroC410 { get; private set; }

		public RegistroList<RegistroC420> RegistroC420 { get; private set; }

		public RegistroList<RegistroC460> RegistroC460 { get; private set; }

		public RegistroList<RegistroC490> RegistroC490 { get; private set; }

		#endregion Properties
	}
}