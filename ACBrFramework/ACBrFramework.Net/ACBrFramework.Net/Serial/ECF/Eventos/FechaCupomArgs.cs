using System;

namespace ACBrFramework.ECF
{
	public class FechaCupomArgs : EventArgs
	{
		internal FechaCupomArgs(string observacao, int bitmap)
		{
			this.Observacao = observacao;
			this.IndiceBMP = bitmap;
		}

		public string Observacao { get; private set; }
		public int IndiceBMP { get; private set; }
	}
}
