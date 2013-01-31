using System;
#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBrFramework
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("074D4D85-E77C-4F97-9A90-83032541707E")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class ChaveEventArgs : EventArgs
	{
		public string Chave { get; set; }
	}
}