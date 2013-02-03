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
	[Guid("0252BC02-6678-4D6F-978E-C91C3B9DFA3B")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class SubtotalizaCupomEventArgs : EventArgs
	{
		#region Constructor

		internal SubtotalizaCupomEventArgs(decimal DescontoAcrescimo, string MensagemRodape)
		{
			this.DescontoAcrescimo = DescontoAcrescimo;
			this.MensagemRodape = MensagemRodape;
		}

		#endregion Constructor

		#region Properties

		public decimal DescontoAcrescimo
		{
			#region COM_INTEROP

#if COM_INTEROP
			[return: MarshalAs(UnmanagedType.Currency)]
#endif

			#endregion COM_INTEROP

			get;
			private set;
		}

		public string MensagemRodape { get; private set; }

		#endregion Properties
	}
}