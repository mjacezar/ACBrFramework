using System;

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
	[Guid("11D39543-D08B-4D94-A80A-386A4825564D")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class AtualizaEventArgs : EventArgs
	{
		public int Linha { get; internal set; }

		public string TextoVisivel { get; internal set; }
	}
}