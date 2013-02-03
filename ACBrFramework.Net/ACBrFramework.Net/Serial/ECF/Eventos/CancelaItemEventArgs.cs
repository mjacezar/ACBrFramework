using System;

#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.ECF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("C9B8B0EA-A264-49ED-94DC-0BB157B027C3")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class CancelaItemEventArgs : EventArgs
	{
		#region Constructor

		internal CancelaItemEventArgs(int NumItem)
		{
			this.NumItem = NumItem;
		}

		#endregion Constructor

		#region Properties

		public int NumItem { get; private set; }

		#endregion Properties
	}
}