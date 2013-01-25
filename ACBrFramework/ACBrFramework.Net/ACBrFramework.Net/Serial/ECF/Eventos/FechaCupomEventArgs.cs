using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("B6B257C2-40B0-4155-B07F-4199E91947A7")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class FechaCupomEventArgs : EventArgs
	{
		internal FechaCupomEventArgs(string observacao, int bitmap)
		{
			this.Observacao = observacao;
			this.IndiceBMP = bitmap;
		}

		public string Observacao { get; private set; }

		public int IndiceBMP { get; private set; }
	}
}