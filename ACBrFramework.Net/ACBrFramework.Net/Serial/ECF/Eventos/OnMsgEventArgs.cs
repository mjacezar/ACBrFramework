using System;

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
	[Guid("8AAE11A9-F932-490F-B042-7EF23E4C6EC7")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class MsgEventArgs : EventArgs
	{
		#region Constructor

		internal MsgEventArgs(string msg)
		{
			this.Mensagem = msg;
		}

		#endregion Constructor

		#region Properties

		public string Mensagem { get; private set; }

		#endregion Properties
	}
}