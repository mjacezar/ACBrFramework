using System;

#if COM_INTEROP

using System.Runtime.InteropServices;

#endif

namespace ACBrFramework.ECF
{
#if COM_INTEROP

	[ComVisible(true)]
	[Guid("A7735663-B7A8-436A-B428-10480363B2E9")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif
	public sealed class DadosReducaoZClass : ACBrComposedComponent
	{
		#region Fields

		private ComprovanteNaoFiscal[] comprovantesNaoFiscais;
		private Aliquota[] icms;
		private RelatorioGerencial[] relatoriosGerenciais;
		private Aliquota[] issqn;
		private FormaPagamento[] formasPagamento;

		#endregion Fields

		#region Constructor\Destructor

		public DadosReducaoZClass(ACBrECF parent)
			: base(parent)
		{
			CarregaComprovantesNaoFiscais();
			CarregaICMS();
			CarregaRelatoriosGerenciais();
			CarregaISSQN();
			CarregaMeiosDePagamento();
		}

		#endregion Constructor\Destructor

		#region Propriedades

		public int COO
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCOO);
			}
		}

		public int CFD
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCFD);
			}
		}

		public decimal CancelamentoISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetCancelamentoISSQN);
			}
		}

		public int GNFC
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetGNFC);
			}
		}

		public int CRO
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCRO);
			}
		}

		public decimal ValorVendaBruta { get; internal set; }

		public ComprovanteNaoFiscal[] TotalizadoresNaoFiscais
		{
			get
			{
				return this.comprovantesNaoFiscais;
			}
		}

		public Aliquota[] ICMS
		{
			get
			{
				return this.icms;
			}
		}

		public decimal AcrescimoICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetAcrescimoICMS);
			}
		}

		public decimal DescontoICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetDescontoICMS);
			}
		}

		public decimal NaoTributadoICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetNaoTributadoICMS);
			}
		}

		public RelatorioGerencial[] RelatorioGerencial
		{
			get
			{
				return this.relatoriosGerenciais;
			}
		}

		public int CRZ
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCRZ);
			}
		}

		public Aliquota[] ISSQN
		{
			get
			{
				return this.issqn;
			}
		}

		public int GRG
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetGRG);
			}
		}

		public decimal ValorGrandeTotal
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetValorGrandeTotal);
			}
		}

		public decimal AcrescimoISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetAcrescimoISSQN);
			}
		}

		public decimal NaoTributadoISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetNaoTributadoISSQN);
			}
		}

		public decimal IsentoICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetIsentoICMS);
			}
		}

		public decimal SubstituicaoTributariaICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetSubstituicaoTributariaICMS);
			}
		}

		public DateTime DataDaImpressora
		{
			get
			{
				return GetDateTime(ACBrECFInterop.ECF_DadosReducaoZClass_GetDataDaImpressora);
			}
		}

		public decimal TotalOperacaoNaoFiscal
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetTotalOperacaoNaoFiscal);
			}
		}

		public decimal DescontoISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetDescontoISSQN);
			}
		}

		public decimal CancelamentoOPNF
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetCancelamentoOPNF);
			}
		}

		public decimal AcrescimoOPNF
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetAcrescimoOPNF);
			}
		}

		public decimal DescontoOPNF
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetDescontoOPNF);
			}
		}

		public decimal CancelamentoICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetCancelamentoICMS);
			}
		}

		public int GNF
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetGNF);
			}
		}

		public decimal IsentoISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetIsentoISSQN);
			}
		}

		public decimal SubstituicaoTributariaISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetSubstituicaoTributariaISSQN);
			}
		}

		public decimal VendaLiquida
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetVendaLiquida);
			}
		}

		public int CFC
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCFC);
			}
		}

		public int CCF
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCCF);
			}
		}

		public decimal TotalISSQN
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetTotalISSQN);
			}
		}

		public decimal TotalICMS
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetTotalICMS);
			}
		}

		public int CDC
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCDC);
			}
		}

		public int CCDC
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetCCDC);
			}
		}

		public int NCN
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_DadosReducaoZClass_GetNCN);
			}
		}

		public DateTime DataDoMovimento
		{
			get
			{
				return GetDateTime(ACBrECFInterop.ECF_DadosReducaoZClass_GetDataDoMovimento);
			}
		}

		public FormaPagamento[] MeiosDePagamento
		{
			get
			{
				return this.formasPagamento;
			}
		}

		public string NumeroCOOInicial
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_DadosReducaoZClass_GetNumeroCOOInicial);
			}
		}

		public string NumeroDoECF
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_DadosReducaoZClass_GetNumeroDoECF);
			}
		}

		public string NumeroDeSerie
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_DadosReducaoZClass_GetNumeroDeSerie);
			}
		}

		public string NumeroDeSerieMFD
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_DadosReducaoZClass_GetNumeroDeSerieMFD);
			}
		}

		public string NumeroDaLoja
		{
			get
			{
				return GetString(ACBrECFInterop.ECF_DadosReducaoZClass_GetNumeroDaLoja);
			}
		}

		public decimal TotalTroco
		{
			get
			{
				return GetDecimal(ACBrECFInterop.ECF_DadosReducaoZClass_GetTotalTroco);
			}
		}

		#endregion Propriedades

		#region Methods

		public void CalculaValoresVirtuais()
		{
			int ret = ACBrECFInterop.ECF_DadosReducaoZClass_CalculaValoresVirtuais(this.Handle);
			CheckResult(ret);

			CarregaComprovantesNaoFiscais();
			CarregaICMS();
			CarregaRelatoriosGerenciais();
			CarregaISSQN();
			CarregaMeiosDePagamento();
		}

		public string MontaDadosReducaoZ()
		{
			const int bufferlen = 16384;
			return GetString(ACBrECFInterop.ECF_DadosReducaoZClass_MontaDadosReducaoZ, bufferlen);
		}

		private void CarregaComprovantesNaoFiscais()
		{
			int count = ACBrECFInterop.ECF_DadosReducaoZClass_GetCNFCount(this.Handle);
			CheckResult(count);

			comprovantesNaoFiscais = new ComprovanteNaoFiscal[count];
			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.ComprovanteNaoFiscalRec();
				int ret = ACBrECFInterop.ECF_DadosReducaoZClass_GetCNF(this.Handle, ref record, i);
				CheckResult(ret);

				ComprovanteNaoFiscal comprovanteNaoFiscal = new ComprovanteNaoFiscal();
				comprovanteNaoFiscal.Indice = FromUTF8(record.Indice);
				comprovanteNaoFiscal.Descricao = FromUTF8(record.Descricao);
				comprovanteNaoFiscal.PermiteVinculado = record.PermiteVinculado;
				comprovanteNaoFiscal.FormaPagamento = FromUTF8(record.FormaPagamento);
				comprovanteNaoFiscal.Total = FromUTF8(record.Total);
				comprovanteNaoFiscal.Contador = record.Contador;

				comprovantesNaoFiscais[i] = comprovanteNaoFiscal;
			}
		}

		private void CarregaICMS()
		{
			int count = ACBrECFInterop.ECF_DadosReducaoZClass_GetICMSCount(this.Handle);
			CheckResult(count);

			icms = new Aliquota[count];

			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.AliquotaRec();
				int ret = ACBrECFInterop.ECF_DadosReducaoZClass_GetICMS(this.Handle, ref record, i);
				CheckResult(ret);

				Aliquota aliquota = new Aliquota();
				aliquota.Indice = FromUTF8(record.Indice);
				aliquota.ValorAliquota = Convert.ToDecimal(record.Aliquota);
				aliquota.Sequencia = record.Sequencia;
				aliquota.Tipo = record.Tipo.ToString();
				aliquota.Total = Convert.ToDecimal(record.Total);

				icms[i] = aliquota;
			}
		}

		private void CarregaRelatoriosGerenciais()
		{
			int count = ACBrECFInterop.ECF_DadosReducaoZClass_GetRGCount(this.Handle);
			CheckResult(count);

			relatoriosGerenciais = new RelatorioGerencial[count];

			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.RelatorioGerencialRec();
				int ret = ACBrECFInterop.ECF_DadosReducaoZClass_GetRG(this.Handle, ref record, i);
				CheckResult(ret);

				RelatorioGerencial relatorio = new RelatorioGerencial()
				{
					Indice = FromUTF8(record.Indice),
					Descricao = FromUTF8(record.Descricao),
					Contador = record.Contador
				};

				relatoriosGerenciais[i] = relatorio;
			}
		}

		private void CarregaISSQN()
		{
			int count = ACBrECFInterop.ECF_DadosReducaoZClass_GetISSQNCount(this.Handle);
			CheckResult(count);

			issqn = new Aliquota[count];

			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.AliquotaRec();
				int ret = ACBrECFInterop.ECF_DadosReducaoZClass_GetISSQN(this.Handle, ref record, i);
				CheckResult(ret);

				Aliquota aliquota = new Aliquota();
				aliquota.Indice = FromUTF8(record.Indice);
				aliquota.ValorAliquota = Convert.ToDecimal(record.Aliquota);
				aliquota.Sequencia = record.Sequencia;
				aliquota.Tipo = record.Tipo.ToString();
				aliquota.Total = Convert.ToDecimal(record.Total);

				issqn[i] = aliquota;
			}
		}

		private void CarregaMeiosDePagamento()
		{
			int count = ACBrECFInterop.ECF_DadosReducaoZClass_GetFPGCount(this.Handle);
			CheckResult(count);

			formasPagamento = new FormaPagamento[count];
			for (int i = 0; i < count; i++)
			{
				var record = new ACBrECFInterop.FormaPagamentoRec();
				int ret = ACBrECFInterop.ECF_DadosReducaoZClass_GetFPG(this.Handle, ref record, i);
				CheckResult(ret);

				FormaPagamento formaPagamento = new FormaPagamento();
				formaPagamento.Indice = FromUTF8(record.Indice);
				formaPagamento.Descricao = FromUTF8(record.Descricao);
				formaPagamento.PermiteVinculado = record.PermiteVinculado;
				formaPagamento.Total = Convert.ToDecimal(record.Total);
				formaPagamento.Data = DateTime.FromOADate(record.Data);
				formaPagamento.TipoDoc = FromUTF8(record.TipoDoc);

				formasPagamento[i] = formaPagamento;
			}
		}

		#endregion Methods
	}
}