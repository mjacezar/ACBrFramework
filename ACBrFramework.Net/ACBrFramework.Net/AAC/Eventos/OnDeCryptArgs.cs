using System;

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
	[Guid("9BE13B03-4506-445C-93AC-C6E3C2A246D1")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class DecryptEventArgs : EventArgs
	{
		#region Constructor

		internal DecryptEventArgs(string OnDeCrypt)
		{
			ConteudoCriptografado = OnDeCrypt;
		}

		#endregion Constructor


		#region Properties

		public string ConteudoCriptografado { get; private set; }

		public string Resposta { get; set; }

		#endregion Properties
	}
}