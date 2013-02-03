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
#endif
	#endregion COM_INTEROP

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