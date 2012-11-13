﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.ComponentModel;

namespace ACBrFramework.TEFD
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.TEFD.ico.bmp")]
	[TypeConverter(typeof(ExpandableObjectConverter))] 
	public sealed class ACBrTEFD : ACBrComponent, IDisposable
	{
		#region Events

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

		public ACBrTEFDIdentificacao Identificacao { get; private set; }

		[Browsable(false)]
		public ACBrTEFDReq Req { get; private set; }

		[Browsable(false)]
		public ACBrTEFDResp Resp { get; private set; }

		[Browsable(false)]
		public ACBrTEFDRespostasPendentes RespostasPendentes { get; private set; }

		public ACBrTEFDCliSiTef TEFCliSiTef { get; private set; }

		public ACBrTEFDDial TEFDial { get; private set; }

		public ACBrTEFDDisc TEFDisc { get; private set; }

		public ACBrTEFDHiper TEFHiper { get; private set; }

		public ACBrTEFDGPU TEFGPU { get; private set; }

		public ACBrTEFDAuttar TEFAuttar { get; private set; }

		public ACBrTEFDGood TEFGood { get; private set; }

		public ACBrTEFDFoxWin TEFFoxWin { get; private set; }

		public ACBrTEFDPetrocard TEFPetrocard { get; private set; }

		public ACBrTEFDCrediShop TEFCrediShop { get; private set; }

		public ACBrTEFDTipo GPAtual
		{
			get
			{
				return (ACBrTEFDTipo)GetInt32(ACBrTEFInterop.TEF_GetGPAtual);
			}
			set
			{
				SetInt32(ACBrTEFInterop.TEF_SetGPAtual, (int)value);
			}
		}

		#endregion Properties

		#region Methods

		public void Initializar(ACBrTEFDTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_Inicializar(this.Handle, (int)gp);
			CheckResult(ret);
		}

		public void DesInicializar(ACBrTEFDTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_DesInicializar(this.Handle, (int)gp);
			CheckResult(ret);
		}

		public void AtivarGP(ACBrTEFDTipo gp)
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
			int ret = ACBrTEFInterop.TEF_CRT(this.Handle, Convert.ToDouble(valor), indiceFPG_ECF, documentoVinculado, moeda);
			CheckResult(ret);

			return ret == 1;
		}

		public void ATV()
		{
			ATV(ACBrTEFDTipo.Nenhum);
		}

		public void ATV(ACBrTEFDTipo gp)
		{
			int ret = ACBrTEFInterop.TEF_ATV(this.Handle, (int)gp);
			CheckResult(ret);
		}

		public bool ADM()
		{
			return ADM(ACBrTEFDTipo.Nenhum);
		}

		public bool ADM(ACBrTEFDTipo gp)
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

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrTEFInterop.TEF_Create);

			this.Identificacao = new ACBrTEFDIdentificacao(this);
			this.Req = new ACBrTEFDReq(this);
			this.Resp = new ACBrTEFDResp(this);
			this.RespostasPendentes = new ACBrTEFDRespostasPendentes(this);
			this.TEFCliSiTef = new ACBrTEFDCliSiTef(this);
			this.TEFDial = new ACBrTEFDDial(this);
			this.TEFDisc = new ACBrTEFDDisc(this);
			this.TEFHiper = new ACBrTEFDHiper(this);
			this.TEFGPU = new ACBrTEFDGPU(this);
			this.TEFAuttar = new ACBrTEFDAuttar(this);
			this.TEFGood = new ACBrTEFDGood(this);
			this.TEFFoxWin = new ACBrTEFDFoxWin(this);
			this.TEFPetrocard = new ACBrTEFDPetrocard(this);
			this.TEFCrediShop = new ACBrTEFDCrediShop(this);
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
		private void OnExibeMensagemCallback(ACBrTEFDOperacaoMensagem Operacao, string Mensagem, ref ModalResult AModalResult)
		{
			if (onExibeMensagem.IsAssigned)
			{
				ExibeMensagemEventArgs e = new ExibeMensagemEventArgs(Operacao, Mensagem);
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
		private void OnComandaECFCallback(ACBrTEFDOperacaoECF Operacao, IntPtr Resp, ref int RetornoECF)
		{
			if (onComandaECF.IsAssigned)
			{
				ComandaECFEventArgs e = new ComandaECFEventArgs(Operacao, Resp);
				onComandaECF.Raise(e);
				RetornoECF = Convert.ToInt32(e.RetornoECF);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFSubtotalizaCallback(double DescAcre, ref int RetornoECF)
		{
			if (onComandaECFSubtotaliza.IsAssigned)
			{
				ComandaECFSubtotalizaEventArgs e = new ComandaECFSubtotalizaEventArgs(Convert.ToDecimal(DescAcre));
				onComandaECFSubtotaliza.Raise(e);
				RetornoECF = Convert.ToInt32(e.RetornoECF);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFPagamentoCallback(string IndiceECF, double Valor, ref int RetornoECF)
		{
			if (onComandaECFPagamento.IsAssigned)
			{
				ComandaECFPagamentoEventArgs e = new ComandaECFPagamentoEventArgs(IndiceECF, Convert.ToDecimal(Valor));
				onComandaECFPagamento.Raise(e);
				RetornoECF = Convert.ToInt32(e.RetornoECF);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFAbreVinculadoCallback(string COO, string IndiceECF, double Valor, ref int RetornoECF)
		{
			if (onComandaECFAbreVinculado.IsAssigned)
			{
				ComandaECFAbreVinculadoEventArgs e = new ComandaECFAbreVinculadoEventArgs(COO, IndiceECF, Convert.ToDecimal(Valor));
				onComandaECFAbreVinculado.Raise(e);
				RetornoECF = Convert.ToInt32(e.RetornoECF);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFImprimeViaCallback(ACBrTEFDTipoRelatorio TipoRelatorio, int Via, IntPtr ImagemComprovante, int ImagemComprovanteCount, ref int RetornoECF)
		{
			if (onComandaECFImprimeVia.IsAssigned)
			{
				string[] imagemComprovante = GetStringArray(ImagemComprovante, ImagemComprovanteCount);

				ComandaECFImprimeViaEventArgs e = new ComandaECFImprimeViaEventArgs(TipoRelatorio, Via, imagemComprovante);
				onComandaECFImprimeVia.Raise(e);

				RetornoECF = Convert.ToInt32(e.RetornoECF);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnInfoECFCallback(ACBrTEFDInfoECF Operacao, StringBuilder RetornoECF, int RetornoECFLen)
		{
			if (onInfoECF.IsAssigned)
			{
				InfoECFEventArgs e = new InfoECFEventArgs(Operacao);
				onInfoECF.Raise(e);

				RetornoECF.Length = 0;
				RetornoECF.Append(e.Retorno);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesFinalizarRequisicaoCallback(IntPtr Req)
		{
			if (onAntesFinalizarRequisicao.IsAssigned)
			{
				AntesFinalizarRequisicaoEventArgs e = new AntesFinalizarRequisicaoEventArgs(this.Req);
				onAntesFinalizarRequisicao.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisConfirmarTransacoesCallback(IntPtr RespostasPendentes)
		{
			if (onDepoisConfirmarTransacoes.IsAssigned)
			{
				DepoisConfirmarTransacoesEventArgs e = new DepoisConfirmarTransacoesEventArgs(this.RespostasPendentes);
				onDepoisConfirmarTransacoes.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesCancelarTransacaoCallback(IntPtr RespostaPendente)
		{
			if (onAntesCancelarTransacao.IsAssigned)
			{
				AntesCancelarTransacaoEventArgs e = new AntesCancelarTransacaoEventArgs(RespostaPendente);
				onAntesCancelarTransacao.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisCancelarTransacoesCallback(IntPtr RespostasPendentes)
		{
			if (onDepoisCancelarTransacoes.IsAssigned)
			{
				DepoisCancelarTransacoesEventArgs e = new DepoisCancelarTransacoesEventArgs(this.RespostasPendentes);
				onDepoisCancelarTransacoes.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnMudaEstadoReqCallback(ACBrTEFDReqEstado EstadoReq)
		{
			if (onMudaEstadoReq.IsAssigned)
			{
				MudaEstadoReqEventArgs e = new MudaEstadoReqEventArgs(EstadoReq);
				onMudaEstadoReq.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnMudaEstadoRespCallback(ACBrTEFDRespEstado EstadoResp)
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