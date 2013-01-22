using System;

namespace ACBrFramework.ECF
{
	public class OnMsgArgs : EventArgs
	{
		internal OnMsgArgs(string msg)
		{
			this.Mensagem = msg;
		}

		public string Mensagem { get; private set; }
	}
}
