using System;

namespace ACBrFramework.PAF
{
	public sealed class ACBrPAFRegistroB2
	{
		#region Properties

		public string BOMBA { get; set; }

		public string BICO { get; set; }

		public DateTime DATA { get; set; }

		public DateTime HORA { get; set; }

		public string MOTIVO { get; set; }

		public string CNPJ_EMPRESA { get; set; }

		public string CPF_TECNICO { get; set; }

		public string NRO_LACRE_ANTES { get; set; }

		public string NRO_LACRE_APOS { get; set; }

		public decimal ENCERRANTE_ANTES { get; set; }

		public decimal ENCERRANTE_APOS { get; set; }

		public bool RegistroValido { get; set; }

		#endregion Properties
	}
}