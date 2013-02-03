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
	[Guid("9E47AAFE-7BEA-4FC1-AE28-A00302C239AD")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class ChequeEstadoEventArgs : EventArgs
	{
		#region Constructor

		internal ChequeEstadoEventArgs(CHQEstado EstadoAtual)
		{
			this.EstadoAtual = EstadoAtual;
		}

		#endregion Constructor

		#region Properties

		public CHQEstado EstadoAtual { get; private set; }

		public bool Continuar { get; set; }

		#endregion Properties
	}
}