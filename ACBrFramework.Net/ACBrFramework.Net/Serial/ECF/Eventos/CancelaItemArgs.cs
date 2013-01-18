using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("C9B8B0EA-A264-49ED-94DC-0BB157B027C3")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class CancelaItemArgs : EventArgs
	{
		internal CancelaItemArgs(int NumItem)
		{
			this.NumItem = NumItem;
		}

		public int NumItem { get; private set; }
	}
}