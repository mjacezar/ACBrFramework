using System;

namespace ACBrFramework.ACBrTEFD
{
	public class ComandaECFImprimeViaEventArgs : EventArgs
	{
		#region Constructor

		internal ComandaECFImprimeViaEventArgs(ACBrTEFDTipoRelatorio tipoRelatorio, int via, string[] imagemComprovante)
		{
			this.TipoRelatorio = tipoRelatorio;
			this.Via = via;
			this.ImagemComprovante = imagemComprovante;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDTipoRelatorio TipoRelatorio { get; private set; }

		public int Via { get; private set; }

		public string[] ImagemComprovante { get; private set; }

		public int RetornoECF { get; set; }

		#endregion Properties
	}
}