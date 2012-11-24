using System;

namespace ACBrFramework.TEFD
{
	public class AntesCancelarTransacaoEventArgs : EventArgs
	{
		#region Constructor

		internal AntesCancelarTransacaoEventArgs(ACBrTEFDResp respostaPendente)
		{
			this.RespostaPendente = respostaPendente;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDResp RespostaPendente { get; private set; }

		#endregion Properties
	}
}