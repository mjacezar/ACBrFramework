using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("9E47AAFE-7BEA-4FC1-AE28-A00302C239AD")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class ChequeEstadoEventArgs : EventArgs
	{
		internal ChequeEstadoEventArgs(CHQEstado EstadoAtual)
		{
			this.EstadoAtual = EstadoAtual;
		}

		public CHQEstado EstadoAtual { get; private set; }

		public bool Continuar { get; set; }
	}
}