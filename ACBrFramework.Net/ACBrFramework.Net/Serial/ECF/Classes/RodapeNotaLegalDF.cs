namespace ACBrFramework.ECF
{
	public sealed class RodapeNotaLegalDF : ACBrComposedComponent
	{
		internal RodapeNotaLegalDF(Rodape rodape)
			: base(rodape.Parent)
		{
		}

		public bool Imprimir
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir, value);
			}
		}

		public bool ProgramaDeCredito
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito, value);
			}
		}

		public decimal ValorICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS);
			}
			set
			{
				SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS, value);
			}
		}

		public decimal ValorISS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS);
			}
			set
			{
				SetDecimal(ACBrECFInterop.ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS, value);
			}
		}
	}
}