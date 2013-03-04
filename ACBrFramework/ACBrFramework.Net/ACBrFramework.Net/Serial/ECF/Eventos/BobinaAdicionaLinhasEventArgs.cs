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
	[Guid("B8A81DA0-5C11-48B0-BBE8-1705B04BD2ED")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class BobinaAdicionaLinhasEventArgs : EventArgs
	{
		#region Constructor

		internal BobinaAdicionaLinhasEventArgs(string linhas, string operacao)
		{
			this.Linhas = linhas;
			this.Operacao = operacao;
		}

		#endregion Constructor

		#region Properties

		public string Linhas { get; private set; }

		public string Operacao { get; private set; }

		#endregion Properties
	}
}