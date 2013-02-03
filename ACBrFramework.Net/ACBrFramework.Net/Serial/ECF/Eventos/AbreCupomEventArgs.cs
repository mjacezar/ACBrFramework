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
	[Guid("D19E40F6-531D-43AF-B00A-5E58923A1CB4")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public class AbreCupomEventArgs : EventArgs
	{
		#region Constructor

		internal AbreCupomEventArgs(string CPF_CNPJ, string Nome, string Endereco)
		{
			this.CPF_CNPJ = CPF_CNPJ;
			this.Nome = Nome;
			this.Endereco = Endereco;
		}

		#endregion Constructor

		#region Properties

		public string CPF_CNPJ { get; private set; }

		public string Nome { get; private set; }

		public string Endereco { get; private set; }

		#endregion Properties
	}
}