using System;

namespace ACBrFramework.ECF
{
	public class CancelaItemArgs : EventArgs
	{
		internal CancelaItemArgs(int NumItem)
		{
			this.NumItem = NumItem;
		}

		public int NumItem { get; private set; }
	}
}
