using System;
using System.Runtime.InteropServices;

namespace ACBrFramework.Sintegra
{

    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("4F2B01CF-FBEA-4378-928F-7803C4C0DFDA")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class SintegraRegistro10
	{
		public string CNPJ { get; set; }

		public string Inscricao { get; set; }

		public string RazaoSocial { get; set; }

		public string Cidade { get; set; }

		public string Estado { get; set; }

		public string Telefone { get; set; }

		public DateTime DataInicial { get; set; }

		public DateTime DataFinal { get; set; }

		public int CodigoConvenio { get; set; }

		public int NaturezaInformacoes { get; set; }

		public int FinalidadeArquivo { get; set; }
	}
}