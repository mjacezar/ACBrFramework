using System;

namespace ACBrFramework.ACBrTEFD
{
	public class MudaEstadoRespEventArgs : EventArgs
	{
		#region Constructor

		internal MudaEstadoRespEventArgs(ACBrTEFDRespEstado estadoResp)
		{
			this.EstadoResp = estadoResp;
		}

		#endregion Constructor

		#region Properties

		public ACBrTEFDRespEstado EstadoResp { get; private set; }

		#endregion Properties
	}
}