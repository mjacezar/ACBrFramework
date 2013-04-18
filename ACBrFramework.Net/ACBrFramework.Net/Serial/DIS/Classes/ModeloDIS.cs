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

	public enum ModeloDIS : int
	{
		Nenhum = 0,
		GertecSerial = 1,
		GertecTeclado = 2,
		KeytecTeclado = 3,
		SmakTeclado = 4
	}
}