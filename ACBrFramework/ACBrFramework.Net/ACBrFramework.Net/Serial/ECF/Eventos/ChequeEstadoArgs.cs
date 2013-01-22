using System;

namespace ACBrFramework.ECF
{
	public class ChequeEstadoArgs : EventArgs
	{
		internal ChequeEstadoArgs(CHQEstado EstadoAtual)
		{
			this.EstadoAtual = EstadoAtual;
		}

		public CHQEstado EstadoAtual { get; private set; }
		public bool Continuar { get; set; }
	}
}
