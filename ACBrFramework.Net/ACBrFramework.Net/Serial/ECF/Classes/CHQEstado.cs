#if COM_INTEROP
using System.Runtime.InteropServices;
#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP
	[ComVisible(true)]
#endif
	public enum CHQEstado : int
	{
		Idle,
		Posicione,
		Imprimindo,
		FimImpressao,
		Retire,
		Autenticacao
	}
}
