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
	[Guid("3B3DFD10-A3F8-4C2D-B848-EAFDC73F7362")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class ErrorEventArgs : EventArgs
	{
		#region Properties

		public bool Tratado { get; set; }

		#endregion Properties
	}
}