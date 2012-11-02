using System;

namespace ACBrFramework.ACBrTEFD
{
	public class AntesCancelarTransacaoEventArgs : EventArgs
	{
		#region Constructor

		internal AntesCancelarTransacaoEventArgs(object respostaPendente)
		{
			this.RespostaPendente = respostaPendente;
		}

		#endregion Constructor

		#region Properties

		public object RespostaPendente { get; private set; }

		#endregion Properties
	}
}