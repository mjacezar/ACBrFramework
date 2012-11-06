using System;

namespace ACBrFramework.TEFD
{
	public class AntesFinalizarRequisicaoEventArgs : EventArgs
	{
		#region Constructor

		internal AntesFinalizarRequisicaoEventArgs(ACBrTEFDReq req)
		{
			this.Req = req;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDReq Req { get; private set; }

		#endregion Properties
	}
}