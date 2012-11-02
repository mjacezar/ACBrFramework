using System;

namespace ACBrFramework.ACBrTEFD
{
	public class AntesFinalizarRequisicaoEventArgs : EventArgs
	{
		#region Constructor

		internal AntesFinalizarRequisicaoEventArgs(object req)
		{
			this.Req = req;
		}

		#endregion Constructor

		#region Properties

		public object Req { get; private set; }

		#endregion Properties
	}
}