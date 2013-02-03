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
	[Guid("B6B257C2-40B0-4155-B07F-4199E91947A7")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class FechaCupomEventArgs : EventArgs
	{
		#region Constructor

		internal FechaCupomEventArgs(string observacao, int bitmap)
		{
			this.Observacao = observacao;
			this.IndiceBMP = bitmap;
		}

		#endregion Constructor

		#region Properties

		public string Observacao { get; private set; }

		public int IndiceBMP { get; private set; }

		#endregion Properties
	}
}