#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("2183D8DA-141F-4C11-B07F-D9C48AC8B545")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public sealed class RelatorioGerencial
	{
		public string Indice { get; internal set; }

		public string Descricao { get; internal set; }

		public int Contador { get; internal set; }
	}
}