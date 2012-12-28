using System;

namespace ACBrFramework.TEFD
{
	public class ExibeMensagemEventArgs : EventArgs
	{
		#region Constructor

		internal ExibeMensagemEventArgs(OperacaoMensagem operacao, string mensagem)
		{
			this.Operacao = operacao;
			this.Mensagem = mensagem;
		}

		#endregion Constructor

		#region Properties

		public OperacaoMensagem Operacao { get; private set; }

		public string Mensagem { get; private set; }

		public ModalResult ModalResult { get; set; }

		#endregion Properties
	}
}