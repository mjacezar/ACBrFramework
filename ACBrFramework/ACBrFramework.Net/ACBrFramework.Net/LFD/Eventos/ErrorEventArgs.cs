using System;

namespace ACBrFramework.LFD
{
	public class ErrorEventArgs : EventArgs
	{
		#region Constructor

		internal ErrorEventArgs(string msgErro)
		{
			MsgErro = msgErro;
		}

		#endregion Constructor

		#region Properties

		public string MsgErro { get; set; }

		#endregion Properties
	}
}