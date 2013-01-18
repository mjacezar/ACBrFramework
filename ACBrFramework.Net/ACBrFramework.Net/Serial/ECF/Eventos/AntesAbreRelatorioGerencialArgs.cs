using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]

	[Guid("55FBF954-EB34-4497-BB7D-DD8A0E8DFEF9")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class AntesAbreRelatorioGerencialArgs : EventArgs
	{
		#region Constructor

		internal AntesAbreRelatorioGerencialArgs(int Indice)
		{
			this.Indice = Indice;
		}

		#endregion Constructor

		#region Properties

		public int Indice { get; private set; }

		#endregion Properties
	}
}