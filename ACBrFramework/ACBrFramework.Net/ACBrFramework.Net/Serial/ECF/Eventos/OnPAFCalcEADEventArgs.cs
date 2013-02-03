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
	[Guid("CCFF892B-8451-48E0-AD09-33D45A7E5408")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class PAFCalcEADEventArgs : EventArgs
	{
		#region Constructor

		internal PAFCalcEADEventArgs(string arquivo)
		{
			this.Arquivo = arquivo;
		}

		#endregion Constructor

		#region Properties

		public string Arquivo { get; private set; }

		#endregion Properties
	}
}