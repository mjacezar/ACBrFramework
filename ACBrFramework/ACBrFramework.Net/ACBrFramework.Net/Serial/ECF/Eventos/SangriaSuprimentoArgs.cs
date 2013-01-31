using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("689671A7-4559-4C13-A783-7A7CE989BDAC")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class SangriaSuprimentoEventArgs : EventArgs
	{
		internal SangriaSuprimentoEventArgs(decimal Valor, string Obs, string DescricaoCNF, string DescricaoFPG)
		{
			this.Valor = Valor;
			this.Obs = Obs;
			this.DescricaoCNF = DescricaoCNF;
			this.DescricaoFPG = DescricaoFPG;
		}

		public decimal Valor
		{
#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)] 
#endif
			get;
			private set; 
		}


		public string Obs { get; private set; }

		public string DescricaoCNF { get; private set; }

		public string DescricaoFPG { get; private set; }
	}
}