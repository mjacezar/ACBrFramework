using System;

namespace ACBrFramework.TEFD
{
	public class ComandaECFEventArgs : EventArgs
	{
		#region Constructor

		internal ComandaECFEventArgs(OperacaoECF operacao, Object resp)
		{
			this.Operacao = operacao;
			this.Resp = resp;
		}

		#endregion Constructor

		#region Properties

		public OperacaoECF Operacao { get; private set; }

		public Object Resp { get; private set; }

		public bool RetornoECF { get; set; }

		#endregion Properties
	}
}