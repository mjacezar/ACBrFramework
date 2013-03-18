#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.EAD
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
#endif

	#endregion COM_INTEROP

	public enum EADDigest
	{
		MD2,
		MD4,
		MD5,
		RMD160,
		SHA,
		SHA1
	}
}