using System;

namespace ACBrFramework.Validador
{
	public class OnMsgErroEventArgs : EventArgs
	{
		#region Constructor

		internal OnMsgErroEventArgs(string mensagem)
		{
			this.Mensagem = mensagem;
		}

		#endregion Constructor

		#region Properties

		public string Mensagem { get; private set; }
		#endregion Properties
	}
}