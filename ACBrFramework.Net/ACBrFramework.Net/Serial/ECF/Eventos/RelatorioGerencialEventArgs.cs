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
	[Guid("55FBF954-EB34-4497-BB7D-DD8A0E8DFEF9")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class RelatorioGerencialEventArgs : EventArgs
	{
		#region Constructor

		internal RelatorioGerencialEventArgs(int Indice)
		{
			this.Indice = Indice;
		}

		#endregion Constructor

		#region Properties

		public int Indice { get; private set; }

		#endregion Properties
	}
}