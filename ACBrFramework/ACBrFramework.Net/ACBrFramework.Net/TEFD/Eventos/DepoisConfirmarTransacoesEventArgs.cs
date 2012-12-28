using System;

namespace ACBrFramework.TEFD
{
	public class DepoisConfirmarTransacoesEventArgs : EventArgs
	{
		#region Constructor

		internal DepoisConfirmarTransacoesEventArgs(RespostasPendentes respostasPendentes)
		{
			this.RespostasPendentes = respostasPendentes;
		}

		#endregion Constructor

		#region Properties

		public RespostasPendentes RespostasPendentes { get; private set; }

		#endregion Properties
	}
}