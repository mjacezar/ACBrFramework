#region COM_INTEROP

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

#endregion COM_INTEROP

namespace ACBrFramework.AAC
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("97C089E7-92E2-4C0E-8546-DC5B9CCFAAB8")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class Arquivo
	{
		#region Properties

		public string Nome { get; set; }

		public string MD5 { get; set; }

		#endregion Properties
	}
}