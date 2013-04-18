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
	public enum EfeitoExibir : int
	{
		Esquerda_Direita = 0,
		Direita_Esquerda = 1
	}
}