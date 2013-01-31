#if COM_INTEROP
using System.Runtime.InteropServices;
#endif
namespace ACBrFramework
{
#if COM_INTEROP
	[ComVisible(true)]
#endif
	public enum SerialStopBits
	{
		One,
		OneAndHalf,
		Two
	}
}