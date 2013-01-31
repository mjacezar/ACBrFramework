using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("CCFF892B-8451-48E0-AD09-33D45A7E5408")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class PAFCalcEADEventArgs : EventArgs
	{
		public PAFCalcEADEventArgs() { }

		internal PAFCalcEADEventArgs(string arquivo)
		{
			this.Arquivo = arquivo;
		}

		public string Arquivo { get; private set; }
	}
}