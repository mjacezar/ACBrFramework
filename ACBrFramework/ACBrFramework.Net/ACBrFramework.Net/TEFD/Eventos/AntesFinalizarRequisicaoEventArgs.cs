using System;

namespace ACBrFramework.TEFD
{
	public class AntesFinalizarRequisicaoEventArgs : EventArgs
	{
		#region Constructor

		internal AntesFinalizarRequisicaoEventArgs(Req req)
		{
			this.Req = req;
		}

		#endregion Constructor

		#region Properties

		public Req Req { get; private set; }

		#endregion Properties
	}
}