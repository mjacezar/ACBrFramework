using System;

namespace ACBrFramework.TEFD
{
	public class MudaEstadoReqEventArgs : EventArgs
	{
		#region Constructor

		internal MudaEstadoReqEventArgs(ACBrTEFDReqEstado estadoReq)
		{
			this.EstadoReq = estadoReq;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDReqEstado EstadoReq { get; private set; }

		#endregion Properties
	}
}