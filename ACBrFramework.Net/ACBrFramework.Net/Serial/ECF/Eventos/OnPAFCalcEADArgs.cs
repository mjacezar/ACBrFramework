using System;

namespace ACBrFramework.ECF
{
	public class OnPAFCalcEADArgs : EventArgs
	{
		internal OnPAFCalcEADArgs(string arquivo)
		{
			this.Arquivo = arquivo;
		}

		public string Arquivo { get; private set; }
	}
}
