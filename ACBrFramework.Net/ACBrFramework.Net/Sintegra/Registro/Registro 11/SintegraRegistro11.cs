using System.Runtime.InteropServices;
namespace ACBrFramework.Sintegra
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("8CC73B44-A8B4-408E-8DA5-9D6D91B7481F")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class SintegraRegistro11
	{
		public string Responsavel { get; set; }

		public string Bairro { get; set; }

		public string Cep { get; set; }

		public string Numero { get; set; }

		public string Complemento { get; set; }

		public string Endereco { get; set; }

		public string Telefone { get; set; }
	}
}