using System;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistroH2
	{
		#region Properties

		public string CNPJ_CRED_CARTAO { get; set; }

		public int COO { get; set; }

		public int CCF { get; set; }

		public decimal VLR_TROCO { get; set; }

		public DateTime DT_TROCO { get; set; }

		public string CPF { get; set; }

		public string Titulo { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}