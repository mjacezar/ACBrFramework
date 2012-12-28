using System;

namespace ACBrFramework.Sped
{
	public class RegistroG125
	{
		#region Constructor

		public RegistroG125()
		{
			RegistroG130 = new RegistroList<RegistroG130>();
			RegistroG126 = new RegistroList<RegistroG126>();
		}

		#endregion Constructor

		#region Properties

		public string COD_IND_BEM { get; set; }

		public DateTime DT_MOV { get; set; }

		public MovimentoBens TIPO_MOV { get; set; }

		public decimal VL_IMOB_ICMS_OP { get; set; }

		public decimal VL_IMOB_ICMS_ST { get; set; }

		public decimal VL_IMOB_ICMS_FRT { get; set; }

		public decimal VL_IMOB_ICMS_DIF { get; set; }

		public int NUM_PARC { get; set; }

		public decimal VL_PARC_PASS { get; set; }

		public decimal VL_PARC_APROP { get; set; }   /// Até versão 102

		public RegistroList<RegistroG130> RegistroG130 { get; private set; }

		public RegistroList<RegistroG126> RegistroG126 { get; private set; }

		#endregion Properties
	}
}