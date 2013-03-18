#region COM_INTEROP
#if COM_INTEROP

using System.Runtime.InteropServices;

#endif
#endregion COM_INTEROP

namespace ACBrFramework.PAF
{
	#region COM_INTEROP
#if COM_INTEROP
	[ComVisible(true)]
	#endif
	#endregion COM_INTEROP

	public enum TipoIntegracao
	{
		Retaguarda = 0,
		PED = 1,
		Ambos = 2,
		NaoIntegra = 3
	}
}