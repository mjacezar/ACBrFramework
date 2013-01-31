#if COM_INTEROP
using System.Runtime.InteropServices;
#endif
namespace ACBrFramework
{
#if COM_INTEROP
	[ComVisible(true)]
#endif
	public enum SerialParity
	{
		None,
		Odd,
		Even,
		Mark,
		Space
	}
}