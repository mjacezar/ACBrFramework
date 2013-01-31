#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP
	[ComVisible(true)]
#endif

	public enum ModeloECF
	{
		Nenhum,
		NaoFiscal,
		Bematech,
		Sweda,
		Daruma,
		Schalter,
		Mecaf,
		Yanco,
		DataRegis,
		Urano,
		ICash,
		Quattro,
		FiscNET,
		Epson,
		NCR,
		SwedaSTX,
		EscECF
	}
}