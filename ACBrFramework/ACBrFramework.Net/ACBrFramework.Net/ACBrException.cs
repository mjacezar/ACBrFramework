using System;

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBrFramework
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("EEAC1AB6-0C7C-4756-942C-38570D663BF2")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class ACBrException : Exception
	{
		public ACBrException(string message)
			: base(message)
		{
		}
	}
}