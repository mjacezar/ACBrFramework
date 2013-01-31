#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP
	[ComVisible(true)]
#endif
	public enum FinalizaArqMFD
	{
		MF,
		MFD,
		TDM,
		RZ,
		RFD,
		NFP,
		NFPTDM,
		Sintegra,
		SPED
	}
}