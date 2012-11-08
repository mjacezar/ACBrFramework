using System;

namespace ACBrFramework.TEFD
{
	public class DepoisCancelarTransacoesEventArgs : EventArgs
	{
		#region Constructor

		internal DepoisCancelarTransacoesEventArgs(ACBrTEFDRespostasPendentes respostasPendentes)
		{
			this.RespostasPendentes = respostasPendentes;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDRespostasPendentes RespostasPendentes { get; private set; }

		#endregion Properties
	}
}