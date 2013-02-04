using System;

namespace ACBrFramework.CEP
{
	public class AntesAbrirHTTPEventArgs : EventArgs
	{
		#region Constructor

		internal AntesAbrirHTTPEventArgs(string url)
		{
			this.AURL = url;
		}

		#endregion Constructor

		#region Properties

		public string AURL { get; set; }

		#endregion Properties
	}
}