using System;

namespace ACBrFramework.TEFD
{
	public class InfoECFEventArgs : EventArgs
	{
		#region Constructor

		internal InfoECFEventArgs(ACBrTEFDInfoECF operacao)
		{
			this.Operacao = operacao;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDInfoECF Operacao { get; private set; }

		public RetornoECF? RetornoECF { get; set; }

		public decimal? Value { get; set; }

		#endregion Properties
	}
}