using System;

namespace ACBrFramework.ECF
{
	public class OnErrorRelatorioArgs : EventArgs
	{
		internal OnErrorRelatorioArgs(int Indice)
		{
			this.Indice = Indice;
		}

		public bool Tratado { get; set; }
		public int Indice { get; private set; }
	}
}
