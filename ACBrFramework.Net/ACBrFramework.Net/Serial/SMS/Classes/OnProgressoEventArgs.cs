using System;

namespace ACBrFramework.SMS
{
	public class OnProgressoEventArgs : EventArgs
	{
		public int Atual { get; set; }

		public int Total { get; set; }
	}
}