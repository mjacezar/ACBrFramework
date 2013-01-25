using System;

namespace ACBrFramework.RFD
{
	public class OnCalcEADArgs : EventArgs
	{
		internal OnCalcEADArgs(string arquivo)
		{
			this.Arquivo = arquivo;
		}

		public string Arquivo { get; set; }
	}
}