using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("264F96AE-A597-49A9-93B8-D7F987B818FF")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class OnPAFCalcEADEventArgs : EventArgs
	{
		internal OnPAFCalcEADEventArgs(string arquivo)
		{
			this.Arquivo = arquivo;
		}

		public string Arquivo { get; private set; }
	}
}