namespace ACBrFramework.ECF
{
	public sealed class Rodape : ACBrComposedComponent
	{
		#region Constructor

		internal Rodape(ACBrECF acbrECF)
			: base(acbrECF)
		{
			this.NotaLegalDF = new RodapeNotaLegalDF(this);
		}

		#endregion Constructor

		#region Properties

		public string Dav
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_GetDav);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_SetDav, value);
			}
		}

		public string DavOs
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_GetDavOs);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_SetDavOs, value);
			}
		}

		public string MD5
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_GetMD5);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_SetMD5, value);
			}
		}

		public string PreVenda
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_InfoRodapeCupom_GetPreVenda);
			}
			set
			{
				SetString(ACBrECFInterop.ECF_InfoRodapeCupom_SetPreVenda, value);
			}
		}

		public bool CupomMania
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_GetCupomMania);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_SetCupomMania, value);
			}
		}

		public bool MinasLegal
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_GetMinasLegal);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_SetMinasLegal, value);
			}
		}

		public bool ParaibaLegal
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_GetParaibaLegal);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_SetParaibaLegal, value);
			}
		}

		public RodapeNotaLegalDF NotaLegalDF { get; private set; }

		#endregion Properties
	}
}