using System;

namespace ACBrFramework.TEFD
{
	public class DepoisCancelarTransacoesEventArgs : EventArgs
	{
		#region Constructor

		internal DepoisCancelarTransacoesEventArgs(RespostasPendentes respostasPendentes)
		{
			this.RespostasPendentes = respostasPendentes;
		}

		#endregion Constructor

		#region Properties

		public RespostasPendentes RespostasPendentes { get; private set; }

		#endregion Properties
	}
}