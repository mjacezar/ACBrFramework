#if COM_INTEROP
using System.Runtime.InteropServices;
#endif
namespace ACBrFramework.ECF
{
#if COM_INTEROP
	[ComVisible(true)]
#endif

	public enum TipoDocumento
	{
		RZ,
		LX,
		CF,
		CFBP,
		CupomAdicional,
		CFCancelamento,
		CCD,
		AdicionalCCD,
		SegViaCCD,
		ReimpressaoCCD,
		EstornoCCD,
		CNF,
		CNFCancelamento,
		Sangria,
		Suprimento,
		EstornoPagto,
		RG,
		LMF,
		Todos,
		Nenhum
	}
}