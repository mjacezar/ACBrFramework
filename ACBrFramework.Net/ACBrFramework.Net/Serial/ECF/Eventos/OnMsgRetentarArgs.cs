using System;

namespace ACBrFramework.ECF
{
	public class OnMsgRetentarArgs : EventArgs
	{
		internal OnMsgRetentarArgs(string msg, string situacao)
		{
			this.Mensagem = msg;
			this.Situacao = situacao;
		}

		public string Mensagem { get; private set; }
		public string Situacao { get; private set; }
		public bool Result { get; set; }
	}
}