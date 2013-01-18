using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("D19E40F6-531D-43AF-B00A-5E58923A1CB4")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	public class AbreCupomArgs : EventArgs
	{
		internal AbreCupomArgs(string CPF_CNPJ, string Nome, string Endereco)
		{
			this.CPF_CNPJ = CPF_CNPJ;
			this.Nome = Nome;
			this.Endereco = Endereco;
		}

		public string CPF_CNPJ { get; private set; }

		public string Nome { get; private set; }

		public string Endereco { get; private set; }
	}
}