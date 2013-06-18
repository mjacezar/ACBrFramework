using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.Sintegra
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("57691D26-9315-49F8-A60B-7B2F328D969D")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class SintegraRegistro53
	{
		public string CPFCNPJ { get; set; }

		public string Inscricao { get; set; }

		public string Estado { get; set; }

		public string Serie { get; set; }

		public DateTime DataDocumento { get; set; }

		public string Cfop { get; set; }

		public string Numero { get; set; }

		public string Situacao { get; set; }

		public string CodigoAntecipacao { get; set; }

		public decimal BaseST { get; set; }

		public string Modelo { get; set; }

		public string Emitente { get; set; }

		public decimal Despesas { get; set; }

		public decimal IcmsRetido { get; set; }
	}
}