using System;

namespace ACBrFramework.TEFD
{
	public class ComandaECFEventArgs : EventArgs
	{
		#region Constructor

		internal ComandaECFEventArgs(OperacaoECF operacao, Resp resp)
		{
			this.Operacao = operacao;
		    this.Resp = resp;
		}

		#endregion Constructor

		#region Properties

		public OperacaoECF Operacao { get; private set; }

		public Resp Resp { get; private set; }

		public bool RetornoECF { get; set; }

		#endregion Properties
	}
}