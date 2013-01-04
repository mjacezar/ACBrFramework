using System;

namespace ACBrFramework.ECF
{
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