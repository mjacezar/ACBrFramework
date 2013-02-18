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
	[Guid("50EC9E50-CF07-4BB0-A627-4F10C77829B8")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class CryptEventArgs : EventArgs
	{
		#region Constructor

		internal CryptEventArgs(string OnCrypt)
		{
			ConteudoArquivo = OnCrypt;
		}

		#endregion Constructor

		#region Properties

		public string ConteudoArquivo { get; private set; }

		public string Resposta { get; set; }

		#endregion Properties
	}
}