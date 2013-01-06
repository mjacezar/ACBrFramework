namespace ACBrFramework.ECF
{
	public sealed class Consumidor : ACBrComposedComponent
	{
		#region Constructor

		internal Consumidor(ACBrECF acbrECF)
			: base(acbrECF)
		{

		}

		#endregion Constructor

		#region Properties

		public string Documento
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_Consumidor_GetDocumento);
			}
		}

		public string Nome
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_Consumidor_GetNome);
			}
		}

		public string Endereco
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_Consumidor_GetEndereco);
			}
		}

		public bool Atribuido
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_Consumidor_GetAtribuido);
			}
		}

		public bool Enviado
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_Consumidor_GetEnviado);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_Consumidor_SetEnviado, value);
			}
		}		

		#endregion Properties

		#region Methods

		public void AtribuiConsumidor(string CPF_CNPJ, string Nome, string Endereco)
		{
			int ret = ACBrECFInterop.ECF_Consumidor_AtribuiConsumidor(this.Handle, ToUTF8(CPF_CNPJ), ToUTF8(Nome), ToUTF8(Endereco));
			CheckResult(ret);
		}

		public void Zera()
		{
			int ret = ACBrECFInterop.ECF_Consumidor_Zera(this.Handle);
			CheckResult(ret);
		}

		#endregion Methods
	}
}