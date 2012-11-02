using System;

namespace ACBrFramework.ACBrTEFD
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

		public int RetornoECF { get; set; }

		#endregion Properties
	}
}