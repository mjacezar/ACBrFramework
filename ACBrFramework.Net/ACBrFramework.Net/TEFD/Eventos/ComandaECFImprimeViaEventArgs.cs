using System;

namespace ACBrFramework.TEFD
{
	public class ComandaECFImprimeViaEventArgs : EventArgs
	{
		#region Constructor

		internal ComandaECFImprimeViaEventArgs(TipoRelatorio tipoRelatorio, int via, string[] imagemComprovante)
		{
			this.TipoRelatorio = tipoRelatorio;
			this.Via = via;
			this.ImagemComprovante = imagemComprovante;
		}

		#endregion Constructor

		#region Properties

		public TipoRelatorio TipoRelatorio { get; private set; }

		public int Via { get; private set; }

		public string[] ImagemComprovante { get; private set; }

		public bool RetornoECF { get; set; }

		#endregion Properties
	}
}