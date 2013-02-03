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
	[Guid("69C6DE3B-E976-44EC-92CA-25C23B77344F")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class ErrorRelatorioEventArgs : EventArgs
	{
		#region Constructor

		internal ErrorRelatorioEventArgs(int Indice)
		{
			this.Indice = Indice;
		}

		#endregion Constructor

		#region Properties

		public bool Tratado { get; set; }

		public int Indice { get; private set; }

		#endregion Properties
	}
}