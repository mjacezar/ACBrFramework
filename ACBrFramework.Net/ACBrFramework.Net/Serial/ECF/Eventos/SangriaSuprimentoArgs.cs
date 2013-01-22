using System;

namespace ACBrFramework.ECF
{
	public class SangriaSuprimentoArgs : EventArgs
	{
		internal SangriaSuprimentoArgs(decimal Valor, string Obs, string DescricaoCNF, string DescricaoFPG)
		{
			this.Valor = Valor;
			this.Obs = Obs;
			this.DescricaoCNF = DescricaoCNF;
			this.DescricaoFPG = DescricaoFPG;
		}

		public decimal Valor { get; private set; }
		public string Obs { get; private set; }
		public string DescricaoCNF { get; private set; }
		public string DescricaoFPG { get; private set; }
	}
}