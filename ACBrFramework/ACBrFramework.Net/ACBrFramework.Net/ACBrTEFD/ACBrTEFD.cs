using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.ACBrTEFD
{
	[ToolboxBitmap(typeof(ACBrTEF), @"ACBrTEFD.ico.bmp")]
	public sealed class ACBrTEF : ACBrComponent, IDisposable
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

		private readonly InteropEventHandler<AguardaRespEventArgs, ACBrTEFInterop.AguardaRespCallback> onAguardaResp;
		private readonly InteropEventHandler<ExibeMensagemEventArgs, ACBrTEFInterop.ExibeMsgCallback> onExibeMensagem;
		private readonly InteropEventHandler<BloqueiaMouseTecladoEventArgs, ACBrTEFInterop.BloqueiaMouseTecladoCallback> onBloqueiaMouseTeclado;
		private readonly InteropEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback> onRestauraFocoAplicacao;
		private readonly InteropEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback> onLimpaTeclado;
		private readonly InteropEventHandler<ComandaECFEventArgs, ACBrTEFInterop.ComandaECFCallback> onComandaECF;
		private readonly InteropEventHandler<ComandaECFSubtotalizaEventArgs, ACBrTEFInterop.ComandaECFSubtotalizaCallback> onComandaECFSubtotaliza;
		private readonly InteropEventHandler<ComandaECFPagamentoEventArgs, ACBrTEFInterop.ComandaECFPagamentoCallback> onComandaECFPagamento;
		private readonly InteropEventHandler<ComandaECFAbreVinculadoEventArgs, ACBrTEFInterop.ComandaECFAbreVinculadoCallback> onComandaECFAbreVinculado;
		private readonly InteropEventHandler<ComandaECFImprimeViaEventArgs, ACBrTEFInterop.ComandaECFImprimeViaCallback> onComandaECFImprimeVia;
		private readonly InteropEventHandler<InfoECFEventArgs, ACBrTEFInterop.InfoECFCallback> onInfoECF;
		private readonly InteropEventHandler<AntesFinalizarRequisicaoEventArgs, ACBrTEFInterop.AntesFinalizarRequisicaoCallback> onAntesFinalizarRequisicao;
		private readonly InteropEventHandler<DepoisConfirmarTransacoesEventArgs, ACBrTEFInterop.DepoisConfirmarTransacoesCallback> onDepoisConfirmarTransacoes;
		private readonly InteropEventHandler<AntesCancelarTransacaoEventArgs, ACBrTEFInterop.AntesCancelarTransacaoCallback> onAntesCancelarTransacao;
		private readonly InteropEventHandler<DepoisCancelarTransacoesEventArgs, ACBrTEFInterop.DepoisCancelarTransacoesCallback> onDepoisCancelarTransacoes;
		private readonly InteropEventHandler<MudaEstadoReqEventArgs, ACBrTEFInterop.MudaEstadoReqCallback> onMudaEstadoReq;
		private readonly InteropEventHandler<MudaEstadoRespEventArgs, ACBrTEFInterop.MudaEstadoRespCallback> onMudaEstadoResp;

		#endregion Fields

		#region Constructor

		public ACBrTEF()
		{
			onAguardaResp = new InteropEventHandler<AguardaRespEventArgs, ACBrTEFInterop.AguardaRespCallback>(this, OnAguardaRespCallback, ACBrTEFInterop.TEF_SetOnAguardaResp);
			onExibeMensagem = new InteropEventHandler<ExibeMensagemEventArgs, ACBrTEFInterop.ExibeMsgCallback>(this, OnExibeMensagemCallback, ACBrTEFInterop.TEF_SetOnExibeMsg);
			onBloqueiaMouseTeclado = new InteropEventHandler<BloqueiaMouseTecladoEventArgs, ACBrTEFInterop.BloqueiaMouseTecladoCallback>(this, OnBloqueiaMouseTecladoCallback, ACBrTEFInterop.TEF_SetOnBloqueiaMouseTeclado);
			onRestauraFocoAplicacao = new InteropEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback>(this, OnRestauraFocoAplicacaoCallback, ACBrTEFInterop.TEF_SetOnRestauraFocoAplicacao);
			onLimpaTeclado = new InteropEventHandler<ExecutaAcaoEventArgs, ACBrTEFInterop.ExecutaAcaoCallback>(this, OnLimpaTecladoCallback, ACBrTEFInterop.TEF_SetOnRestauraFocoAplicacao);
			onComandaECF = new InteropEventHandler<ComandaECFEventArgs, ACBrTEFInterop.ComandaECFCallback>(this, OnComandaECFCallback, ACBrTEFInterop.TEF_SetOnComandaECF);
			onComandaECFSubtotaliza = new InteropEventHandler<ComandaECFSubtotalizaEventArgs, ACBrTEFInterop.ComandaECFSubtotalizaCallback>(this, OnComandaECFSubtotalizaCallback, ACBrTEFInterop.TEF_SetOnComandaECFSubtotaliza);
			onComandaECFPagamento = new InteropEventHandler<ComandaECFPagamentoEventArgs, ACBrTEFInterop.ComandaECFPagamentoCallback>(this, OnComandaECFPagamentoCallback, ACBrTEFInterop.TEF_SetOnComandaECFPagamento);
			onComandaECFAbreVinculado = new InteropEventHandler<ComandaECFAbreVinculadoEventArgs, ACBrTEFInterop.ComandaECFAbreVinculadoCallback>(this, OnComandaECFAbreVinculadoCallback, ACBrTEFInterop.TEF_SetOnComandaECFAbreVinculado);
			onComandaECFImprimeVia = new InteropEventHandler<ComandaECFImprimeViaEventArgs, ACBrTEFInterop.ComandaECFImprimeViaCallback>(this, OnComandaECFImprimeViaCallback, ACBrTEFInterop.TEF_SetOnComandaECFImprimeVia);
			onInfoECF = new InteropEventHandler<InfoECFEventArgs, ACBrTEFInterop.InfoECFCallback>(this, OnInfoECFCallback, ACBrTEFInterop.TEF_SetOnInfoECF);
			onAntesFinalizarRequisicao = new InteropEventHandler<AntesFinalizarRequisicaoEventArgs, ACBrTEFInterop.AntesFinalizarRequisicaoCallback>(this, OnAntesFinalizarRequisicaoCallback, ACBrTEFInterop.TEF_SetOnAntesFinalizarRequisicao);
			onDepoisConfirmarTransacoes = new InteropEventHandler<DepoisConfirmarTransacoesEventArgs, ACBrTEFInterop.DepoisConfirmarTransacoesCallback>(this, OnDepoisConfirmarTransacoesCallback, ACBrTEFInterop.TEF_SetOnDepoisConfirmarTransacoes);
			onAntesCancelarTransacao = new InteropEventHandler<AntesCancelarTransacaoEventArgs, ACBrTEFInterop.AntesCancelarTransacaoCallback>(this, OnAntesCancelarTransacaoCallback, ACBrTEFInterop.TEF_SetOnAntesCancelarTransacao);
			onDepoisCancelarTransacoes = new InteropEventHandler<DepoisCancelarTransacoesEventArgs, ACBrTEFInterop.DepoisCancelarTransacoesCallback>(this, OnDepoisCancelarTransacoesCallback, ACBrTEFInterop.TEF_SetOnDepoisCancelarTransacoes);
			onMudaEstadoReq = new InteropEventHandler<MudaEstadoReqEventArgs, ACBrTEFInterop.MudaEstadoReqCallback>(this, OnMudaEstadoReqCallback, ACBrTEFInterop.TEF_SetOnMudaEstadoReq);
			onMudaEstadoResp = new InteropEventHandler<MudaEstadoRespEventArgs, ACBrTEFInterop.MudaEstadoRespCallback>(this, OnMudaEstadoRespCallback, ACBrTEFInterop.TEF_SetOnMudaEstadoResp);
		}

		#endregion Constructor

		#region Properties

		#endregion Properties

		#region Methods

		#region Override Methods

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					string error = GetString(ACBrTEFInterop.TEF_GetUltimoErro);
					throw new ACBrECFException(error);

				case -2:

					throw new ACBrECFException("ACBr TEF não inicializado.");
			}
		}

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrTEFInterop.TEF_Create);
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
				RetornoECF = e.RetornoECF;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFSubtotalizaCallback(double DescAcre, ref int RetornoECF)
		{
			if (onComandaECFSubtotaliza.IsAssigned)
			{
				ComandaECFSubtotalizaEventArgs e = new ComandaECFSubtotalizaEventArgs(Convert.ToDecimal(DescAcre));
				onComandaECFSubtotaliza.Raise(e);
				RetornoECF = e.RetornoECF;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFPagamentoCallback(string IndiceECF, double Valor, ref int RetornoECF)
		{
			if (onComandaECFPagamento.IsAssigned)
			{
				ComandaECFPagamentoEventArgs e = new ComandaECFPagamentoEventArgs(IndiceECF, Convert.ToDecimal(Valor));
				onComandaECFPagamento.Raise(e);
				RetornoECF = e.RetornoECF;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFAbreVinculadoCallback(string COO, string IndiceECF, double Valor, ref int RetornoECF)
		{
			if (onComandaECFAbreVinculado.IsAssigned)
			{
				ComandaECFAbreVinculadoEventArgs e = new ComandaECFAbreVinculadoEventArgs(COO, IndiceECF, Convert.ToDecimal(Valor));
				onComandaECFAbreVinculado.Raise(e);
				RetornoECF = e.RetornoECF;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnComandaECFImprimeViaCallback(ACBrTEFDTipoRelatorio TipoRelatorio, int Via, IntPtr ImagemComprovante, int ImagemComprovanteCount, ref int RetornoECF)
		{
			if (onComandaECFImprimeVia.IsAssigned)
			{
				string[] imagemComprovante = new string[ImagemComprovanteCount];
				for (int i = 0; i < ImagemComprovanteCount; i++)
				{
					IntPtr ptr = new IntPtr(ImagemComprovante.ToInt32() + i);
					imagemComprovante[i] = FromUTF8(Marshal.PtrToStringAuto(ptr));
				}

				ComandaECFImprimeViaEventArgs e = new ComandaECFImprimeViaEventArgs(TipoRelatorio, Via, imagemComprovante);
				onComandaECFImprimeVia.Raise(e);

				RetornoECF = e.RetornoECF;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnInfoECFCallback(ACBrTEFDInfoECF Operacao, ref int RetornoECF)
		{
			if (onInfoECF.IsAssigned)
			{
				InfoECFEventArgs e = new InfoECFEventArgs(Operacao);
				onInfoECF.Raise(e);
				RetornoECF = e.RetornoECF;
			}
		}

		[AllowReversePInvokeCalls]
		private void OnAntesFinalizarRequisicaoCallback(IntPtr Req)
		{
			if (onAntesFinalizarRequisicao.IsAssigned)
			{
				AntesFinalizarRequisicaoEventArgs e = new AntesFinalizarRequisicaoEventArgs(Req);
				onAntesFinalizarRequisicao.Raise(e);
			}
		}

		[AllowReversePInvokeCalls]
		private void OnDepoisConfirmarTransacoesCallback(IntPtr RespostasPendentes)
		{
			if (onDepoisConfirmarTransacoes.IsAssigned)
			{
				DepoisConfirmarTransacoesEventArgs e = new DepoisConfirmarTransacoesEventArgs(RespostasPendentes);
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
				DepoisCancelarTransacoesEventArgs e = new DepoisCancelarTransacoesEventArgs(RespostasPendentes);
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

		#endregion EventHandlers

		#endregion Methods
	}
}