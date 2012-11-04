using System;

namespace ACBrFramework.TEFD
{
	public class DepoisCancelarTransacoesEventArgs : EventArgs
	{
		#region Constructor

		internal DepoisCancelarTransacoesEventArgs(object respostasPendentes)
		{
			this.RespostasPendentes = respostasPendentes;
		}

		#endregion Constructor

		#region Properties

		public object RespostasPendentes { get; private set; }

		#endregion Properties
	}
}