using System;

namespace ACBrFramework.ACBrTEFD
{
	public class AguardaRespEventArgs : EventArgs
	{
		#region Constructor

		internal AguardaRespEventArgs(string arquivo, int seguntosTimeout)
		{
			this.Arquivo = arquivo;
			this.SegundosTimeout = seguntosTimeout;
		}

		#endregion Constructor

		#region Properties

		public string Arquivo { get; private set; }

		public int SegundosTimeout { get; private set; }

		public bool Interromper { get; set; }

		#endregion Properties
	}
}