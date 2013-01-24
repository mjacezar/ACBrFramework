using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("0A113F75-65E1-427F-A1E6-DA9A18B51398")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class ChangeEstadoArgs : EventArgs
	{
		internal ChangeEstadoArgs(EstadoECF EstadoAnterior, EstadoECF EstadoAtual)
		{
			this.EstadoAnterior = EstadoAnterior;
			this.EstadoAtual = EstadoAtual;
		}

		public EstadoECF EstadoAnterior { get; private set; }

		public EstadoECF EstadoAtual { get; private set; }
	}
}