using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("14529A93-F63A-4298-B7C0-59A263DB5610")]
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