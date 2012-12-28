using System;

namespace ACBrFramework.Sped
{
	public class RegistroH005
	{
		#region Constructor

		public RegistroH005()
		{
			RegistroH010 = new RegistroList<RegistroH010>();
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INV { get; set; }

		public decimal VL_INV { get; set; }

		public MotivoInventario MOT_INV { get; set; }

		public RegistroList<RegistroH010> RegistroH010 { get; private set; }

		#endregion Properties
	}
}