using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("69C6DE3B-E976-44EC-92CA-25C23B77344F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class OnErrorRelatorioEventArgs : EventArgs
	{
		internal OnErrorRelatorioEventArgs(int Indice)
		{
			this.Indice = Indice;
		}

		public bool Tratado { get; set; }

		public int Indice { get; private set; }
	}
}