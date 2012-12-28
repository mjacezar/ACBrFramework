using System;

namespace ACBrFramework.TEFD
{
	public class MudaEstadoRespEventArgs : EventArgs
	{
		#region Constructor

		internal MudaEstadoRespEventArgs(RespEstado estadoResp)
		{
			this.EstadoResp = estadoResp;
		}

		#endregion Constructor

		#region Properties

		public RespEstado EstadoResp { get; private set; }

		#endregion Properties
	}
}