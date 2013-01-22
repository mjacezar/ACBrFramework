using System;

namespace ACBrFramework.ECF
{
	public class SubtotalizaCupomArgs : EventArgs
	{
		internal SubtotalizaCupomArgs(decimal DescontoAcrescimo, string MensagemRodape)
		{
			this.DescontoAcrescimo = DescontoAcrescimo;
			this.MensagemRodape = MensagemRodape;
		}

		public decimal DescontoAcrescimo { get; private set; }
		public string MensagemRodape { get; private set; }
	}
}