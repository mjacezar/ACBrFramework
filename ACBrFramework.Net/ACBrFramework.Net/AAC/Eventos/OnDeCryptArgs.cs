using System;

namespace ACBrFramework.AAC
{
	public class OnDeCryptArgs : EventArgs
	{
		internal OnDeCryptArgs(string OnDeCrypt)
		{
			ConteudoCriptografado = OnDeCrypt;
		}

		public string ConteudoCriptografado { get; private set; }
		public string Resposta { get; set; }
	}
}