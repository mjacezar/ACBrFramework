#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.DIS
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
#endif

	#endregion COM_INTEROP

	public enum Alinhamento : int
	{
		Esquerda = 0,
		Direita = 1,
		Centro = 2,
		Justificado = 3
	}
}