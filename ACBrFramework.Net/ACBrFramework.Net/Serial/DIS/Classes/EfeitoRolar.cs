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
	public enum EfeitoRolar : int
	{
		ParaEsquerda_Inicio = 0,
		ParaEsquerda_Sempre = 1,
		ParaDireita_Inicio = 2,
		ParaDireita_Sempre = 3,
		Vai_e_Volta = 4
	}
}