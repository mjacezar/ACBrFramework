using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("3B3DFD10-A3F8-4C2D-B848-EAFDC73F7362")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class OnErrorEventArgs : EventArgs
	{
		public bool Tratado { get; set; }
	}
}