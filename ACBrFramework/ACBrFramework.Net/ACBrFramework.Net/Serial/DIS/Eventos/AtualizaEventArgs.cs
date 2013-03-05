using System;

namespace ACBrFramework.DIS
{
	public class AtualizaEventArgs : EventArgs
	{
		public int Linha { get; internal set; }

		public string TextoVisivel { get; internal set; }
	}
}