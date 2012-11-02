using System;

namespace ACBrFramework.ACBrTEFD
{
	public class BloqueiaMouseTecladoEventArgs : EventArgs
	{
		#region Constructor

		internal BloqueiaMouseTecladoEventArgs(bool bloqueia)
		{
			this.Bloqueia = bloqueia;
		}

		#endregion Constructor

		#region Properties

		public bool Bloqueia { get; private set; }

		public bool Tratado { get; set; }

		#endregion Properties
	}
}