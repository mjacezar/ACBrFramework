using System;

namespace ACBrFramework.TEFD
{
	public class AntesCancelarTransacaoEventArgs : EventArgs
	{
		#region Constructor

		internal AntesCancelarTransacaoEventArgs(Resp respostaPendente)
		{
			this.RespostaPendente = respostaPendente;
		}

		#endregion Constructor

		#region Properties

		public Resp RespostaPendente { get; private set; }

		#endregion Properties
	}
}