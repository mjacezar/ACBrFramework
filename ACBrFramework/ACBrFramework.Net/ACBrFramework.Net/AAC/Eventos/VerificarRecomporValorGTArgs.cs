using System;

namespace ACBrFramework.AAC
{
	public class VerificarRecomporValorGTArgs : EventArgs
	{
		internal VerificarRecomporValorGTArgs(string numserie)
		{
			NumSerie = numserie;
		}

		public string NumSerie { get; private set; }
		public Double ValorGT { get; set; }
	}
}
