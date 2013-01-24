using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("8AAE11A9-F932-490F-B042-7EF23E4C6EC7")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class OnMsgEventArgs : EventArgs
	{
		internal OnMsgEventArgs(string msg)
		{
			this.Mensagem = msg;
		}

		public string Mensagem { get; private set; }
	}
}