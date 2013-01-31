#if COM_INTEROP
using System.Runtime.InteropServices;
#endif
namespace ACBrFramework.ECF
{
#if COM_INTEROP
	[ComVisible(true)]
#endif

	public enum TipoContador
	{
		COO,
		CRZ
	}
}