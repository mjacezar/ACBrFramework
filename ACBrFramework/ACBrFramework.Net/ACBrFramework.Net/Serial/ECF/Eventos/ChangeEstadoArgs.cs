using System;

namespace ACBrFramework.ECF
{
	public class ChangeEstadoArgs : EventArgs
	{
		internal ChangeEstadoArgs(EstadoECF EstadoAnterior, EstadoECF EstadoAtual)
		{
			this.EstadoAnterior = EstadoAnterior;
			this.EstadoAtual = EstadoAtual;
		}

		public EstadoECF EstadoAnterior { get; private set; }
		public EstadoECF EstadoAtual { get; private set; }
	}
}