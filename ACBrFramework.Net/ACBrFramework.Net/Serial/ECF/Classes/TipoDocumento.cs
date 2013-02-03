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