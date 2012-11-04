using System;

namespace ACBrFramework.TEFD
{
	public class ComandaECFSubtotalizaEventArgs : EventArgs
	{
		#region Constructor

		internal ComandaECFSubtotalizaEventArgs(decimal descAcre)
		{
			this.DescAcre = descAcre;
		}

		#endregion Constructor

		#region Properties

		public decimal DescAcre { get; private set; }

		public RetornoECF RetornoECF { get; set; }

		#endregion Properties
	}
}