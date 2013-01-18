using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("B8A81DA0-5C11-48B0-BBE8-1705B04BD2ED")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	public class BobinaEventArgs : EventArgs
	{
		public string Linhas { get; set; }

		public string Operacao { get; set; }
	}
}