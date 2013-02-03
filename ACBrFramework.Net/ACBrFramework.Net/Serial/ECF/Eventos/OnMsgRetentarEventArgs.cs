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
	[Guid("3FE53A5B-5FEE-4CD2-9F61-B0A9ED4959FF")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class MsgRetentarEventArgs : EventArgs
	{
		#region Constructor

		internal MsgRetentarEventArgs(string msg, string situacao)
		{
			this.Mensagem = msg;
			this.Situacao = situacao;
		}

		#endregion Constructor

		#region Properties

		public string Mensagem { get; private set; }

		public string Situacao { get; private set; }

		public bool Result { get; set; }

		#endregion Properties
	}
}