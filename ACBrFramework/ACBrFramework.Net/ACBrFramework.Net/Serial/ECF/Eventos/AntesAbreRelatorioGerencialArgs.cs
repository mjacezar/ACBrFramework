using System;

namespace ACBrFramework.ECF
{
	public class AntesAbreRelatorioGerencialArgs : EventArgs
	{
		internal AntesAbreRelatorioGerencialArgs(int Indice)
		{
			this.Indice = Indice;
		}

		public int Indice { get; private set; }
	}
}