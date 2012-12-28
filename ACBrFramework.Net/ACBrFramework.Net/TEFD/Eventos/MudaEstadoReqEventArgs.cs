using System;

namespace ACBrFramework.TEFD
{
	public class MudaEstadoReqEventArgs : EventArgs
	{
		#region Constructor

		internal MudaEstadoReqEventArgs(ReqEstado estadoReq)
		{
			this.EstadoReq = estadoReq;
		}

		#endregion Constructor

		#region Properties

		public ReqEstado EstadoReq { get; private set; }

		#endregion Properties
	}
}