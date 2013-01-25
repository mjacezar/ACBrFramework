using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("3FE53A5B-5FEE-4CD2-9F61-B0A9ED4959FF")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public class OnMsgRetentarEventArgs : EventArgs
	{
		internal OnMsgRetentarEventArgs(string msg, string situacao)
		{
			this.Mensagem = msg;
			this.Situacao = situacao;
		}

		public string Mensagem { get; private set; }

		public string Situacao { get; private set; }

		public bool Result { get; set; }
	}
}