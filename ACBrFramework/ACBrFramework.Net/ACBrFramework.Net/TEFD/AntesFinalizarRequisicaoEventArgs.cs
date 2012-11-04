using System;

namespace ACBrFramework.TEFD
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