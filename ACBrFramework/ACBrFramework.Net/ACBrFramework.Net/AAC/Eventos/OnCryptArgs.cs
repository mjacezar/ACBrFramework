using System;

namespace ACBrFramework.AAC
{
	public class OnCryptArgs : EventArgs
	{
		internal OnCryptArgs(string OnCrypt)
		{
			ConteudoArquivo = OnCrypt;
		}

		public string ConteudoArquivo { get; private set; }
		public string Resposta { get; set; }
	}
}