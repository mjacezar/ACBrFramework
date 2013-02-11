using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.TEFD
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.TEFD.ico.bmp")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class ACBrTEFD : ACBrComponent, IDisposable
	{
		#region Events

		[Category("Geral")]
		public event EventHandler<AguardaRespEventArgs> OnAguardaResp
		{
			add
			{
				onAguardaResp.Add(value);
			}
			remove
			{
				onAguardaResp.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ExibeMensagemEventArgs> OnExibeMensagem
		{
			add
			{
				onExibeMensagem.Add(value);
			}
			remove
			{
				onExibeMensagem.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<BloqueiaMouseTecladoEventArgs> OnBloqueiaMouseTeclado
		{
			add
			{
				onBloqueiaMouseTeclado.Add(value);
			}
			remove
			{
				onBloqueiaMouseTeclado.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ExecutaAcaoEventArgs> OnRestauraFocoAplicacao
		{
			add
			{
				onRestauraFocoAplicacao.Add(value);
			}
			remove
			{
				onRestauraFocoAplicacao.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ExecutaAcaoEventArgs> OnLimpaTeclado
		{
			add
			{
				onLimpaTeclado.Add(value);
			}
			remove
			{
				onLimpaTeclado.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ComandaECFEventArgs> OnComandaECF
		{
			add
			{
				onComandaECF.Add(value);
			}
			remove
			{
				onComandaECF.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ComandaECFSubtotalizaEventArgs> OnComandaECFSubtotaliza
		{
			add
			{
				onComandaECFSubtotaliza.Add(value);
			}
			remove
			{
				onComandaECFSubtotaliza.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ComandaECFPagamentoEventArgs> OnComandaECFPagamento
		{
			add
			{
				onComandaECFPagamento.Add(value);
			}
			remove
			{
				onComandaECFPagamento.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ComandaECFAbreVinculadoEventArgs> OnComandaECFAbreVinculado
		{
			add
			{
				onComandaECFAbreVinculado.Add(value);
			}
			remove
			{
				onComandaECFAbreVinculado.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<ComandaECFImprimeViaEventArgs> OnComandaECFImprimeVia
		{
			add
			{
				onComandaECFImprimeVia.Add(value);
			}
			remove
			{
				onComandaECFImprimeVia.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<InfoECFEventArgs> OnInfoECF
		{
			add
			{
				onInfoECF.Add(value);
			}
			remove
			{
				onInfoECF.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<AntesFinalizarRequisicaoEventArgs> OnAntesFinalizarRequisicao
		{
			add
			{
				onAntesFinalizarRequisicao.Add(value);
			}
			remove
			{
				onAntesFinalizarRequisicao.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<DepoisConfirmarTransacoesEventArgs> OnDepoisConfirmarTransacoes
		{
			add
			{
				onDepoisConfirmarTransacoes.Add(value);
			}
			remove
			{
				onDepoisConfirmarTransacoes.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<AntesCancelarTransacaoEventArgs> OnAntesCancelarTransacao
		{
			add
			{
				onAntesCancelarTransacao.Add(value);
			}
			remove
			{
				onAntesCancelarTransacao.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<DepoisCancelarTransacoesEventArgs> OnDepoisCancelarTransacoes
		{
			add
			{
				onDepoisCancelarTransacoes.Add(value);
			}
			remove
			{
				onDepoisCancelarTransacoes.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<MudaEstadoReqEventArgs> OnMudaEstadoReq
		{
			add
			{
				onMudaEstadoReq.Add(value);
			}
			remove
			{
				onMudaEstadoReq.Remove(value);
			}
		}

		[Category("Geral")]
		public event EventHandler<MudaEstadoRespEventArgs> OnMudaEstadoResp
		{
			add
			{
				onMudaEstadoResp.Add(value);
			}
			remove
			{
				onMudaEstadoResp.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<AguardaRespEventArgs, ACBrTEFInterop.AguardaRespCallback> onAguardaResp;
		private readonly ACBrEventHandler<ExibeMensagemEventArgs, ACBrTEFInterop.ExibeMsgCallback> onExibeMensagem;
		private readonly ACBrEventHandler<BloqueiaMouseTecladoEventArgs, ACBrTEFInterop.BloqueiaMouseTecladoCallback> onBloqueiaMouseTeclado;
		private readonly ACBrEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback> onRestauraFocoAplicacao;
		private readonly ACBrEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback> onLimpaTeclado;
		private readonly ACBrEventHandler<ComandaECFEventArgs, ACBrTEFInterop.ComandaECFCallback> onComandaECF;
		private readonly ACBrEventHandler<ComandaECFSubtotalizaEventArgs, ACBrTEFInterop.ComandaECFSubtotalizaCallback> onComandaECFSubtotaliza;
		private readonly ACBrEventHandler<ComandaECFPagamentoEventArgs, ACBrTEFInterop.ComandaECFPagamentoCallback> onComandaECFPagamento;
		private readonly ACBrEventHandler<ComandaECFAbreVinculadoEventArgs, ACBrTEFInterop.ComandaECFAbreVinculadoCallback> onComandaECFAbreVinculado;
		private readonly ACBrEventHandler<ComandaECFImprimeViaEventArgs, ACBrTEFInterop.ComandaECFImprimeViaCallback> onComandaECFImprimeVia;
		private readonly ACBrEventHandler<InfoECFEventArgs, ACBrTEFInterop.InfoECFCallback> onInfoECF;
		private readonly ACBrEventHandler<AntesFinalizarRequisicaoEventArgs, ACBrTEFInterop.AntesFinalizarRequisicaoCallback> onAntesFinalizarRequisicao;
		private readonly ACBrEventHandler<DepoisConfirmarTransacoesEventArgs, ACBrTEFInterop.DepoisConfirmarTransacoesCallback> onDepoisConfirmarTransacoes;
		private readonly ACBrEventHandler<AntesCancelarTransacaoEventArgs, ACBrTEFInterop.AntesCancelarTransacaoCallback> onAntesCancelarTransacao;
		private readonly ACBrEventHandler<DepoisCancelarTransacoesEventArgs, ACBrTEFInterop.DepoisCancelarTransacoesCallback> onDepoisCancelarTransacoes;
		private readonly ACBrEventHandler<MudaEstadoReqEventArgs, ACBrTEFInterop.MudaEstadoReqCallback> onMudaEstadoReq;
		private readonly ACBrEventHandler<MudaEstadoRespEventArgs, ACBrTEFInterop.MudaEstadoRespCallback> onMudaEstadoResp;

		#endregion Fields

		#region Constructor

		public ACBrTEFD()
		{
			onAguardaResp = new ACBrEventHandler<AguardaRespEventArgs, ACBrTEFInterop.AguardaRespCallback>(this, OnAguardaRespCallback, ACBrTEFInterop.TEF_SetOnAguardaResp);
			onExibeMensagem = new ACBrEventHandler<ExibeMensagemEventArgs, ACBrTEFInterop.ExibeMsgCallback>(this, OnExibeMensagemCallback, ACBrTEFInterop.TEF_SetOnExibeMsg);
			onBloqueiaMouseTeclado = new ACBrEventHandler<BloqueiaMouseTecladoEventArgs, ACBrTEFInterop.BloqueiaMouseTecladoCallback>(this, OnBloqueiaMouseTecladoCallback, ACBrTEFInterop.TEF_SetOnBloqueiaMouseTeclado);
			onRestauraFocoAplicacao = new ACBrEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback>(this, OnRestauraFocoAplicacaoCallback, ACBrTEFInterop.TEF_SetOnRestauraFocoAplicacao);
			onLimpaTeclado = new ACBrEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback>(this, OnLimpaTecladoCallback, ACBrTEFInterop.TEF_SetOnRestauraFocoAplicacao);
			onComandaECF = new ACBrEventHandler<ComandaECFEventArgs, ACBrTEFInterop.ComandaECFCallback>(this, OnComandaECFCallback, ACBrTEFInterop.TEF_SetOnComandaECF);
			onComandaECFSubtotaliza = new ACBrEventHandler<ComandaECFSubtotalizaEventArgs, ACBrTEFInterop.ComandaECFSubtotalizaCallback>(this, OnComandaECFSubtotalizaCallback, ACBrTEFInterop.TEF_SetOnComandaECFSubtotaliza);
			onComandaECFPagamento = new ACBrEventHandler<ComandaECFPagamentoEventArgs, ACBrTEFInterop.ComandaECFPagamentoCallback>(this, OnComandaECFPagamentoCallback, ACBrTEFInterop.TEF_SetOnComandaECFPagamento);
			onComandaECFAbreVinculado = new ACBrEventHandler<ComandaECFAbreVinculadoEventArgs, ACBrTEFInterop.ComandaECFAbreVinculadoCallback>(this, OnComandaECFAbreVinculadoCallback, ACBrTEFInterop.TEF_SetOnComandaECFAbreVinculado);
			onComandaECFImprimeVia = new ACBrEventHandler<ComandaECFImprimeViaEventArgs, ACBrTEFInterop.ComandaECFImprimeViaCallback>(this, OnComandaECFImprimeViaCallback, ACBrTEFInterop.TEF_SetOnComandaECFImprimeVia);
			onInfoECF = new ACBrEventHandler<InfoECFEventArgs, ACBrTEFInterop.InfoECFCallback>(this, OnInfoECFCallback, ACBrTEFInterop.TEF_SetOnInfoECF);
			onAntesFinalizarRequisicao = new ACBrEventHandler<AntesFinalizarRequisicaoEventArgs, ACBrTEFInterop.AntesFinalizarRequisicaoCallback>(this, OnAntesFinalizarRequisicaoCallback, ACBrTEFInterop.TEF_SetOnAntesFinalizarRequisicao);
			onDepoisConfirmarTransacoes = new ACBrEventHandler<DepoisConfirmarTransacoesEventArgs, ACBrTEFInterop.DepoisConfirmarTransacoesCallback>(this, OnDepoisConfirmarTransacoesCallback, ACBrTEFInterop.TEF_SetOnDepoisConfirmarTransacoes);
			onAntesCancelarTransacao = new ACBrEventHandler<AntesCancelarTransacaoEventArgs, ACBrTEFInterop.AntesCancelarTransacaoCallback>(this, OnAntesCancelarTransacaoCallback, ACBrTEFInterop.TEF_SetOnAntesCancelarTransacao);
			onDepoisCancelarTransacoes = new ACBrEventHandler<DepoisCancelarTransacoesEventArgs, ACBrTEFInterop.DepoisCancelarTransacoesCallback>(this, OnDepoisCancelarTransacoesCallback, ACBrTEFInterop.TEF_SetOnDepoisCancelarTransacoes);
			onMudaEstadoReq = new ACBrEventHandler<MudaEstadoReqEventArgs, ACBrTEFInterop.MudaEstadoReqCallback>(this, OnMudaEstadoReqCallback, ACBrTEFInterop.TEF_SetOnMudaEstadoReq);
			onMudaEstadoResp = new ACBrEventHandler<MudaEstadoRespEventArgs, ACBrTEFInterop.MudaEstadoRespCallback>(this, OnMudaEstadoRespCallback, ACBrTEFInterop.TEF_SetOnMudaEstadoResp);
		}

		#endregion Constructor

		#region Properties

		[Category("Geral")]
		public string About
		{
			get
			{
				return GetAbout(ACBrTEFInterop.TEF_GetAbout);
			}
		}

		[Category("Geral")]
		public string PathBackup
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_GetPathBackup);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_SetPathBackup, value);
			}
		}

		[Category("Geral")]
		public string ArqLOG
		{
			get
			{
				return GetString(ACBrTEFInterop.TEF_GetArqLOG);
			}
			set
			{
				SetString(ACBrTEFInterop.TEF_SetArqLOG, value);
			}
		}

		[Category("Geral")]
		public bool AutoAtivar
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_GetAutoAtivar);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_SetAutoAtivar, value);
			}
		}

		[Category("Geral")]
		public bool MultiplosCartoes
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_GetMultiplosCartoes);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_SetMultiplosCartoes, value);
			}
		}

		[Category("Geral")]
		public bool AutoEfetuarPagamento
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_GetAutoEfetuarPagamento);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_SetAutoEfetuarPagamento, value);
			}
		}

		[Category("Geral")]
		public bool AutoFinalizarCupom
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_GetAutoFinalizarCupom);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_SetAutoFinalizarCupom, value);
			}
		}

		[Category("Geral")]
		public bool CHQEmGerencial
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_GetCHQEmGerencial);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_SetCHQEmGerencial, value);
			}
		}

		[Category("Geral")]
		public bool ExibirMsgAutenticacao
		{
			get
			{
				return GetBool(ACBrTEFInterop.TEF_GetExibirMsgAutenticacao);
			}
			set
			{
				SetBool(ACBrTEFInterop.TEF_SetExibirMsgAutenticacao, value);
			}
		}

		[Category("Geral")]
		public decimal TrocoMaximo
		{
			get
			{
				return GetDecimal(ACBrTEFInterop.TEF_GetTrocoMaximo);
			}
			set
			{
				SetDecimal(ACBrTEFInterop.TEF_SetTrocoMaximo, value);
			}
		}

		[Category("Geral")]
		public int EsperaSleep
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_GetEsperaSleep);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_SetEsperaSleep, value);
			}
		}

		[Category("Geral")]
		public int EsperaSTS
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_GetEsperaSTS);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_SetEsperaSTS, value);
			}
		}

		[Category("Geral")]
		public int NumVias
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_GetNumVias);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_SetNumVias, value);
			}
		}

		[Category("Geral")]
		public int NumeroMaximoCartoes
		{
			get
			{
				return GetInt32(ACBrTEFInterop.TEF_GetNumeroMaximoCartoes);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_SetNumeroMaximoCartoes, value);
			}
		}

		[Category("Identificação")]
		public Identificacao Identificacao { get; private set; }

		[Browsable(false)]
		public Req Req
		{
			get
			{
				IntPtr composedComponent;
				int ret = ACBrTEFInterop.TEF_GetReq(this.Handle, out composedComponent);
				CheckResult(ret);

				if (composedComponent == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new Req(this, composedComponent);
				}
			}
		}

		[Browsable(false)]
		public Resp Resp
		{
			get
			{
				IntPtr composedComponent;
				int ret = ACBrTEFInterop.TEF_GetResp(this.Handle, out composedComponent);
				CheckResult(ret);

				if (composedComponent == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new Resp(this, composedComponent);
				}
			}
		}

		[Browsable(false)]
		public RespostasPendentes RespostasPendentes
		{
			get
			{
				IntPtr composedComponent;
				int ret = ACBrTEFInterop.TEF_GetRespostasPendentes(this.Handle, out composedComponent);
				CheckResult(ret);

				if (composedComponent == IntPtr.Zero)
				{
					return null;
				}
				else
				{
					return new RespostasPendentes(this, composedComponent);
				}
			}
		}

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefCliSiTef TEFCliSiTef { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefDial TEFDial { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefDisc TEFDisc { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefHiper TEFHiper { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefGPU TEFGPU { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefAuttar TEFAuttar { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefGood TEFGood { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefFoxWin TEFFoxWin { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefPetrocard TEFPetrocard { get; private set; }

		[Category("GP"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TefCrediShop TEFCrediShop { get; private set; }

		[Browsable(false)]
		public TefTipo GPAtual
		{
			get
			{
				return (TefTipo)GetInt32(ACBrTEFInterop.TEF_GetGPAtual);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_SetGPAtual, (int)value);
			}
		}

		#endregion Properties

		#region Methods

		public void Initializar(TefTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_Inicializar(this.Handle, (int)gp);
			CheckResult(ret);
		}

		public void DesInicializar(TefTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_DesInicializar(this.Handle, (int)gp);
			CheckResult(ret);
		}

		public void AtivarGP(TefTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_AtivarGP(this.Handle, (int)gp);
			CheckResult(ret);
		}

		public bool CRT(decimal valor, string indiceFPG_ECF)
		{
			return CRT(valor, indiceFPG_ECF, string.Empty, 0);
		}

		public bool CRT(decimal valor, string indiceFPG_ECF, string documentoVinculado)
		{
			return CRT(valor, indiceFPG_ECF, documentoVinculado, 0);
		}

		public bool CRT(decimal valor, string indiceFPG_ECF, string documentoVinculado, int moeda)
		{
			int ret = ACBrTEFInterop.TEF_CRT(this.Handle, Convert.ToDouble(valor), ToUTF8(indiceFPG_ECF), ToUTF8(documentoVinculado), moeda);
			CheckResult(ret);

			return ret == 1;
		}

		public bool CHQ(decimal valor, string indiceFPG_ECF)
		{
			return CHQ(valor, indiceFPG_ECF, string.Empty, string.Empty, 'F', string.Empty,
				DateTime.Now, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
				string.Empty, string.Empty);
		}

		public bool CHQ(decimal valor, string indiceFPG_ECF, string documentoVinculado, string CMC7, char tipoPessoa,
			string documentoPessoa, DateTime DataCheque, string banco, string agencia,
			string agenciaDC, string conta, string contaDC, string cheque, string chequeDC, string compensacao)
		{
			int ret = ACBrTEFInterop.TEF_CHQ(this.Handle, Convert.ToDouble(valor), ToUTF8(indiceFPG_ECF), ToUTF8(documentoVinculado), ToUTF8(CMC7),
				tipoPessoa, ToUTF8(documentoPessoa), DataCheque.ToOADate(), ToUTF8(banco), ToUTF8(agencia),
				ToUTF8(agenciaDC), ToUTF8(conta), ToUTF8(contaDC), ToUTF8(cheque), ToUTF8(chequeDC), ToUTF8(compensacao));
			CheckResult(ret);

			return ret == 1;
		}

		public void ATV()
		{
			ATV(TefTipo.Nenhum);
		}

		public void ATV(TefTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_ATV(this.Handle, (int)gp);
			CheckResult(ret);
		}

		public bool ADM()
		{
			return ADM(TefTipo.Nenhum);
		}

		public bool ADM(TefTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_ADM(this.Handle, (int)gp);
			CheckResult(ret);

			return ret == 1;
		}

		public bool CNC(string rede, string nsu, DateTime dataHoraTransacao, decimal valor)
		{
			int ret = ACBrTEFInterop.TEF_CNC(this.Handle, rede, nsu, dataHoraTransacao.ToOADate(), Convert.ToDouble(valor));
			CheckResult(ret);

			return ret == 1;
		}

		public void CNF(string rede, string nsu, string finalizacao)
		{
			CNF(rede, nsu, finalizacao, string.Empty);
		}

		public void CNF(string rede, string nsu, string finalizacao, string documentoVinculado)
		{
			int ret = ACBrTEFInterop.TEF_CNF(this.Handle, rede, nsu, finalizacao, documentoVinculado);
			CheckResult(ret);
		}

		public void NCN(string rede, string nsu, string finalizacao)
		{
			NCN(rede, nsu, finalizacao, 0M, string.Empty);
		}

		public void NCN(string rede, string nsu, string finalizacao, decimal valor)
		{
			NCN(rede, nsu, finalizacao, valor, string.Empty);
		}

		public void NCN(string rede, string nsu, string finalizacao, decimal valor, string documentoVinculado)
		{
			int ret = ACBrTEFInterop.TEF_NCN(this.Handle, rede, nsu, finalizacao, Convert.ToDouble(valor), documentoVinculado);
			CheckResult(ret);
		}

		public void CancelarTransacoesPendentes()
		{
			int ret = ACBrTEFInterop.TEF_CancelarTransacoesPendentes(this.Handle);
			CheckResult(ret);
		}

		public void ConfirmarTransacoesPendentes()
		{
			int ret = ACBrTEFInterop.TEF_ConfirmarTransacoesPendentes(this.Handle);
			CheckResult(ret);
		}

		public void ImprimirTransacoesPendentes()
		{
			int ret = ACBrTEFInterop.TEF_ImprimirTransacoesPendentes(this.Handle);
			CheckResult(ret);
		}

		public void FinalizarCupom()
		{
			FinalizarCupom(true);
		}

		public void FinalizarCupom(bool bloqueia)
		{
			int ret = ACBrTEFInterop.TEF_FinalizarCupom(this.Handle, bloqueia);
			CheckResult(ret);
		}

		#region Override Methods

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrTEFInterop.TEF_GetUltimoErro);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr TEF não inicializado.");
			}
		}

		protected internal override void OnInitialize()
		{
			CallCreate(ACBrTEFInterop.TEF_Create);

			this.Identificacao = new Identificacao(this);
			this.TEFCliSiTef = new TefCliSiTef(this);
			this.TEFDial = new TefDial(this);
			this.TEFDisc = new TefDisc(this);
			this.TEFHiper = new TefHiper(this);
			this.TEFGPU = new TefGPU(this);
			this.TEFAuttar = new TefAuttar(this);
			this.TEFGood = new TefGood(this);
			this.TEFFoxWin = new TefFoxWin(this);
			this.TEFPetrocard = new TefPetrocard(this);
			this.TEFCrediShop = new TefCrediShop(this);
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrTEFInterop.TEF_Destroy);
			}
		}

		#endregion Override Methods

		#region Interop EventCallbacks

		[AllowReversePInvokeCalls]
		private void OnAguardaRespCallback(string Arquivo, int SegundosTimeOut, ref bool Interromper)
		{
			if (onAguardaResp.IsAssigned)
			{
				AguardaRespEventArgs e = new AguardaRespEventArgs(Arquivo, SegundosTimeOut);
				onAguardaResp.Raise(e);
				Interromper = e.Interromper;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnExibeMensagemCallback(OperacaoMensagem Operacao, string Mensagem, ref ModalResult AModalResult)
		{
			if (onExibeMensagem.IsAssigned)
			{
				ExibeMensagemEventArgs e = new ExibeMensagemEventArgs(Operacao, FromUTF8(Mensagem));
				onExibeMensagem.Raise(e);
				AModalResult = e.ModalResult;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnBloqueiaMouseTecladoCallback(bool Bloqueia, ref bool Tratado)
		{
			if (onBloqueiaMouseTeclado.IsAssigned)
			{
				BloqueiaMouseTecladoEventArgs e = new BloqueiaMouseTecladoEventArgs(Bloqueia);
				onBloqueiaMouseTeclado.Raise(e);
				Tratado = e.Tratado;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnRestauraFocoAplicacaoCallback(ref bool Tratado)
		{
			if (onRestauraFocoAplicacao.IsAssigned)
			{
				ExecutaAcaoEventArgs e = new ExecutaAcaoEventArgs();
				onRestauraFocoAplicacao.Raise(e);
				Tratado = e.Tratado;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnLimpaTecladoCallback(ref bool Tratado)
		{
			if (onLimpaTeclado.IsAssigned)
			{
				ExecutaAcaoEventArgs e = new ExecutaAcaoEventArgs();
				onLimpaTeclado.Raise(e);
				Tratado = e.Tratado;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFCallback(OperacaoECF Operacao, IntPtr respHandle, ref int RetornoECF)
		{
			if (onComandaECF.IsAssigned)
			{
				Resp resp;

				if (respHandle == IntPtr.Zero)
				{
					resp = null;
				}
				else
				{
					resp = new Resp(this, respHandle);
				}

				ComandaECFEventArgs e = new ComandaECFEventArgs(Operacao, resp);
				onComandaECF.Raise(e);
				RetornoECF = e.RetornoECF ? 1 : 0;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFSubtotalizaCallback(double DescAcre, ref int RetornoECF)
		{
			if (onComandaECFSubtotaliza.IsAssigned)
			{
				ComandaECFSubtotalizaEventArgs e = new ComandaECFSubtotalizaEventArgs(Convert.ToDecimal(DescAcre));
				onComandaECFSubtotaliza.Raise(e);
				RetornoECF = e.RetornoECF ? 1 : 0;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFPagamentoCallback(string IndiceECF, double Valor, ref int RetornoECF)
		{
			if (onComandaECFPagamento.IsAssigned)
			{
				ComandaECFPagamentoEventArgs e = new ComandaECFPagamentoEventArgs(IndiceECF, Convert.ToDecimal(Valor));
				onComandaECFPagamento.Raise(e);
				RetornoECF = e.RetornoECF ? 1 : 0;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFAbreVinculadoCallback(string COO, string IndiceECF, double Valor, ref int RetornoECF)
		{
			if (onComandaECFAbreVinculado.IsAssigned)
			{
				ComandaECFAbreVinculadoEventArgs e = new ComandaECFAbreVinculadoEventArgs(COO, IndiceECF, Convert.ToDecimal(Valor));
				onComandaECFAbreVinculado.Raise(e);
				RetornoECF = e.RetornoECF ? 1 : 0;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFImprimeViaCallback(TipoRelatorio TipoRelatorio, int Via, IntPtr ImagemComprovante, int ImagemComprovanteCount, ref int RetornoECF)
		{
			if (onComandaECFImprimeVia.IsAssigned)
			{
				string[] imagemComprovante = GetStringArray(ImagemComprovante, ImagemComprovanteCount);

				ComandaECFImprimeViaEventArgs e = new ComandaECFImprimeViaEventArgs(TipoRelatorio, Via, imagemComprovante);
				onComandaECFImprimeVia.Raise(e);

				RetornoECF = e.RetornoECF ? 1 : 0;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnInfoECFCallback(InfoECF Operacao, StringBuilder RetornoECF, int RetornoECFLen)
		{
			if (onInfoECF.IsAssigned)
			{
				InfoECFEventArgs e = new InfoECFEventArgs(Operacao);
				onInfoECF.Raise(e);

				PrepareOutStringBuilder(RetornoECF, RetornoECFLen);
				RetornoECF.Length = 0;
				RetornoECF.Append(e.Retorno);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesFinalizarRequisicaoCallback(IntPtr reqHandle)
		{
			if (onAntesFinalizarRequisicao.IsAssigned)
			{
				Req req;

				if (reqHandle == IntPtr.Zero)
				{
					req = null;
				}
				else
				{
					req = new Req(this, reqHandle);
				}

				AntesFinalizarRequisicaoEventArgs e = new AntesFinalizarRequisicaoEventArgs(req);
				onAntesFinalizarRequisicao.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisConfirmarTransacoesCallback(IntPtr respPendentesHandle)
		{
			if (onDepoisConfirmarTransacoes.IsAssigned)
			{
				RespostasPendentes respostasPendentes;

				if (respPendentesHandle == IntPtr.Zero)
				{
					respostasPendentes = null;
				}
				else
				{
					respostasPendentes = new RespostasPendentes(this, respPendentesHandle);
				}

				DepoisConfirmarTransacoesEventArgs e = new DepoisConfirmarTransacoesEventArgs(respostasPendentes);
				onDepoisConfirmarTransacoes.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesCancelarTransacaoCallback(IntPtr respPendenteHandle)
		{
			if (onAntesCancelarTransacao.IsAssigned)
			{
				Resp resp;
				if (respPendenteHandle == IntPtr.Zero)
				{
					resp = null;
				}
				else
				{
					resp = new Resp(this, respPendenteHandle);
				}

				AntesCancelarTransacaoEventArgs e = new AntesCancelarTransacaoEventArgs(resp);
				onAntesCancelarTransacao.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisCancelarTransacoesCallback(IntPtr respostasPendentesHandle)
		{
			if (onDepoisCancelarTransacoes.IsAssigned)
			{
				RespostasPendentes respostasPendentes;

				if (respostasPendentesHandle == IntPtr.Zero)
				{
					respostasPendentes = null;
				}
				else
				{
					respostasPendentes = new RespostasPendentes(this, respostasPendentesHandle);
				}

				DepoisCancelarTransacoesEventArgs e = new DepoisCancelarTransacoesEventArgs(respostasPendentes);
				onDepoisCancelarTransacoes.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnMudaEstadoReqCallback(ReqEstado EstadoReq)
		{
			if (onMudaEstadoReq.IsAssigned)
			{
				MudaEstadoReqEventArgs e = new MudaEstadoReqEventArgs(EstadoReq);
				onMudaEstadoReq.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnMudaEstadoRespCallback(RespEstado EstadoResp)
		{
			if (onMudaEstadoResp.IsAssigned)
			{
				MudaEstadoRespEventArgs e = new MudaEstadoRespEventArgs(EstadoResp);
				onMudaEstadoResp.Raise(e);
			}
		}

		#endregion Interop EventCallbacks

		#endregion Methods
	}
}