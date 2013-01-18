namespace ACBrFramework.Sped
{
	public sealed class Registro0150
	{
		#region Constructor

		public Registro0150()
		{
			this.Registro0175 = new RegistroList<Registro0175>();
		}

		#endregion Constructor

		#region Properties

		public string COD_PART { get; set; }

		public string NOME { get; set; }

		public string COD_PAIS { get; set; }

		public string CNPJ { get; set; }

		public string CPF { get; set; }

		public string IE { get; set; }

		public int COD_MUN { get; set; }

		public string SUFRAMA { get; set; }

		public string ENDERECO { get; set; }

		public string NUM { get; set; }

		public string COMPL { get; set; }

		public string BAIRRO { get; set; }

		public RegistroList<Registro0175> Registro0175 { get; private set; }

		#endregion Properties
	}
}