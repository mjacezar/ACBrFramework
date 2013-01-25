using System;

namespace ACBrFramework.RFD
{
	public class OnCalcHashLogArgs : EventArgs
	{
		internal OnCalcHashLogArgs(string linha)
		{
			this.Linha = linha;
		}

		public string Linha { get; set; }
		public string Hash { get; set; }
	}
}
