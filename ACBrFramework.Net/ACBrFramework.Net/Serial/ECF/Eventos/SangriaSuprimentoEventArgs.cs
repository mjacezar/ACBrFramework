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
	[Guid("689671A7-4559-4C13-A783-7A7CE989BDAC")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class SangriaSuprimentoEventArgs : EventArgs
	{
		#region Constructor

		internal SangriaSuprimentoEventArgs(decimal Valor, string Obs, string DescricaoCNF, string DescricaoFPG)
		{
			this.Valor = Valor;
			this.Obs = Obs;
			this.DescricaoCNF = DescricaoCNF;
			this.DescricaoFPG = DescricaoFPG;
		}

		#endregion Constructor

		#region Properties

		public decimal Valor
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			private set;
		}

		public string Obs { get; private set; }

		public string DescricaoCNF { get; private set; }

		public string DescricaoFPG { get; private set; }

		#endregion Properties
	}
}