#if COM_INTEROP
using System.Runtime.InteropServices;
#endif
namespace ACBrFramework
{
#if COM_INTEROP
	[ComVisible(true)]
#endif
	public enum SerialHandShake
	{
		None,
		XON_XOFF,
		RTS_CTS,
		DTR_DSR
	}
}