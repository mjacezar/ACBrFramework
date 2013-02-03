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
	[Guid("0A113F75-65E1-427F-A1E6-DA9A18B51398")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class ChangeEstadoEventArgs : EventArgs
	{
		#region Constructor

		internal ChangeEstadoEventArgs(EstadoECF EstadoAnterior, EstadoECF EstadoAtual)
		{
			this.EstadoAnterior = EstadoAnterior;
			this.EstadoAtual = EstadoAtual;
		}

		#endregion Constructor

		#region Properties

		public EstadoECF EstadoAnterior { get; private set; }

		public EstadoECF EstadoAtual { get; private set; }

		#endregion Properties
	}
}