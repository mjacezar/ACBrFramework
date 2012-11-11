using System;

namespace ACBrFramework.TEFD
{
	public class DepoisConfirmarTransacoesEventArgs : EventArgs
	{
		#region Constructor

		internal DepoisConfirmarTransacoesEventArgs(ACBrTEFDRespostasPendentes respostasPendentes)
		{
			this.RespostasPendentes = respostasPendentes;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDRespostasPendentes RespostasPendentes { get; private set; }

		#endregion Properties
	}
}