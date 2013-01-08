using System;

namespace ACBrFramework.AAC
{
	public class VerificarRecomporNumSerieArgs : EventArgs
	{
		internal VerificarRecomporNumSerieArgs(string numserie, double gt)
		{
			NumSerie = numserie;
			ValorGT = gt;
		}

		public string NumSerie { get; private set; }
		public Double ValorGT { get; private set; }
		public int CRO { get; set; }
		public int CNI { get; set; }
	}
}