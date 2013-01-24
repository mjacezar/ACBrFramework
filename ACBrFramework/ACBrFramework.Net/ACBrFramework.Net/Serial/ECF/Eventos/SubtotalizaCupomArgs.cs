using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("0252BC02-6678-4D6F-978E-C91C3B9DFA3B")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class SubtotalizaCupomEventArgs : EventArgs
	{
		internal SubtotalizaCupomEventArgs(decimal DescontoAcrescimo, string MensagemRodape)
		{
			this.DescontoAcrescimo = DescontoAcrescimo;
			this.MensagemRodape = MensagemRodape;
		}

		public decimal DescontoAcrescimo { get; private set; }

		public string MensagemRodape { get; private set; }
	}
}