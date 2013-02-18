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
	[Guid("6FCBE4E4-57D7-4D7B-9855-D583F7EB8512")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class AntesArquivoEventArgs : EventArgs
	{
		#region Properties

		public bool Continua { get; set; }

		#endregion Properties
	}
}