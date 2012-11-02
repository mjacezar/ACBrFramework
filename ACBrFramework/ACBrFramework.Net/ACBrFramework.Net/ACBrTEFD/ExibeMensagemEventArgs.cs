using System;

namespace ACBrFramework.ACBrTEFD
{
	public class ExibeMensagemEventArgs : EventArgs
	{
		#region Constructor

		internal ExibeMensagemEventArgs(ACBrTEFDOperacaoMensagem operacao, string mensagem)
		{
			this.Operacao = operacao;
			this.Mensagem = mensagem;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDOperacaoMensagem Operacao { get; private set; }

		public string Mensagem { get; private set; }

		public ModalResult ModalResult { get; set; }

		#endregion Properties
	}
}