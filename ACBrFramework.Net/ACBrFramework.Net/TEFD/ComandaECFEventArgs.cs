using System;

namespace ACBrFramework.TEFD
{
	public class ComandaECFEventArgs : EventArgs
	{
		#region Constructor

		internal ComandaECFEventArgs(ACBrTEFDOperacaoECF operacao, Object resp)
		{
			this.Operacao = operacao;
			this.Resp = resp;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDOperacaoECF Operacao { get; private set; }

		public Object Resp { get; private set; }

		public RetornoECF RetornoECF { get; set; }

		#endregion Properties
	}
}