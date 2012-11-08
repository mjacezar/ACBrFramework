using System;
using System.Windows.Forms;

using ACBrFramework.TEFD;
using System.Threading;

namespace ACBrFramework.TEFDTeste
{
	public partial class MainForm : Form
	{
		#region Fields

		private ACBrTEFD tef;
		private RetornoECF retECF;

		#endregion Fields

		#region Constructor

		static MainForm()
		{
			#region Comments

			//Necessário no DEMO permitir que outra thread possa manipular os componentes da UI
			//Em produção deve-se usar Invokers para manipular os componentes na mesma thread da UI.

			#endregion Comments

			Form.CheckForIllegalCrossThreadCalls = false;
		}

		public MainForm()
		{
			InitializeComponent();

			tef = new ACBrTEFD();
			tef.OnAguardaResp += new EventHandler<AguardaRespEventArgs>(tef_OnAguardaResp);
			tef.OnAntesCancelarTransacao += new EventHandler<AntesCancelarTransacaoEventArgs>(tef_OnAntesCancelarTransacao);
			tef.OnAntesFinalizarRequisicao += new EventHandler<AntesFinalizarRequisicaoEventArgs>(tef_OnAntesFinalizarRequisicao);
			tef.OnBloqueiaMouseTeclado += new EventHandler<BloqueiaMouseTecladoEventArgs>(tef_OnBloqueiaMouseTeclado);
			tef.OnComandaECF += new EventHandler<ComandaECFEventArgs>(tef_OnComandaECF);
			tef.OnComandaECFAbreVinculado += new EventHandler<ComandaECFAbreVinculadoEventArgs>(tef_OnComandaECFAbreVinculado);
			tef.OnComandaECFImprimeVia += new EventHandler<ComandaECFImprimeViaEventArgs>(tef_OnComandaECFImprimeVia);
			tef.OnComandaECFPagamento += new EventHandler<ComandaECFPagamentoEventArgs>(tef_OnComandaECFPagamento);
			tef.OnComandaECFSubtotaliza += new EventHandler<ComandaECFSubtotalizaEventArgs>(tef_OnComandaECFSubtotaliza);
			tef.OnDepoisCancelarTransacoes += new EventHandler<DepoisCancelarTransacoesEventArgs>(tef_OnDepoisCancelarTransacoes);
			tef.OnDepoisConfirmarTransacoes += new EventHandler<DepoisConfirmarTransacoesEventArgs>(tef_OnDepoisConfirmarTransacoes);
			tef.OnExibeMensagem += new EventHandler<ExibeMensagemEventArgs>(tef_OnExibeMensagem);
			tef.OnInfoECF += new EventHandler<InfoECFEventArgs>(tef_OnInfoECF);
			tef.OnLimpaTeclado += new EventHandler<ExecutaAcaoEventArgs>(tef_OnLimpaTeclado);
			tef.OnMudaEstadoReq += new EventHandler<MudaEstadoReqEventArgs>(tef_OnMudaEstadoReq);
			tef.OnMudaEstadoResp += new EventHandler<MudaEstadoRespEventArgs>(tef_OnMudaEstadoResp);
			tef.OnRestauraFocoAplicacao += new EventHandler<ExecutaAcaoEventArgs>(tef_OnRestauraFocoAplicacao);

			tef.TEFCliSiTef.OnExibeMenu += new EventHandler<TEFCliSiTefExibeMenuEventArgs>(TEFCliSiTef_OnExibeMenu);
			tef.TEFCliSiTef.OnObtemCampo += new EventHandler<TEFCliSiTefObtemCampoEventArgs>(TEFCliSiTef_OnObtemCampo);
		}

		void TEFCliSiTef_OnObtemCampo(object sender, TEFCliSiTefObtemCampoEventArgs e)
		{
			using (InputForm form = new InputForm())
			{
				form.Initialize(e);
				DialogResult ret = form.ShowDialog(this);

				if (ret == DialogResult.OK)
				{
					e.Resposta = form.InputText;
					e.Digitado = true;
				}
				else
				{
					e.VoltarMenu = true;
				}

			}

		}

		void TEFCliSiTef_OnExibeMenu(object sender, TEFCliSiTefExibeMenuEventArgs e)
		{
			using (MenuForm form = new MenuForm())
			{
				form.Initialize(e);
				DialogResult ret = form.ShowDialog(this);

				if (ret == DialogResult.OK)
				{
					e.ItemSelecionado = form.SelectedItem;
				}
				else
				{
					e.VoltarMenu = true;
				}

			}
		}

		#endregion Constructor

		#region Methods

		#region EventHandlers

		private void okButton_Click(object sender, EventArgs e)
		{
			retECF = RetornoECF.PagamentoOuSubTotal;

			//tef.TEFCliSiTef.EnderecoIP = "127.0.0.1";
			//tef.TEFCliSiTef.CodigoLoja = "00000000";
			//tef.TEFCliSiTef.NumeroTerminal = "SE000001";
			//tef.TEFCliSiTef.Operador = "operador";
			tef.Initializar(ACBrTEFDTipo.TefDial);

			ThreadPool.QueueUserWorkItem(new WaitCallback(Process));
		}

		private void Process(object param)
		{
			tef.CRT(15.9M, "01", "", 0);
			MessageBox.Show("Finalizado");
		}

		private void tef_OnRestauraFocoAplicacao(object sender, ExecutaAcaoEventArgs e)
		{
			this.Focus();
			e.Tratado = true;
		}

		private void tef_OnMudaEstadoResp(object sender, MudaEstadoRespEventArgs e)
		{
			this.Invoke(new Action(() => statusRespLabel.Text = e.EstadoResp.ToString()));
		}

		private void tef_OnMudaEstadoReq(object sender, MudaEstadoReqEventArgs e)
		{
			this.Invoke(new Action(() => statusReqLabel.Text = e.EstadoReq.ToString()));
		}

		private void tef_OnLimpaTeclado(object sender, ExecutaAcaoEventArgs e)
		{
		}

		private void tef_OnInfoECF(object sender, InfoECFEventArgs e)
		{
			if (e.Operacao == ACBrTEFDInfoECF.EstadoECF)
			{
				e.RetornoECF = retECF;
			}
			else if (e.Operacao == ACBrTEFDInfoECF.SubTotal)
			{
				e.Value = 15.9M;
			}
			else
			{
				e.Value = 0;
			}
		}

		private void tef_OnExibeMensagem(object sender, ExibeMensagemEventArgs e)
		{
			if (e.Operacao == ACBrTEFDOperacaoMensagem.OK)
			{
				MessageBox.Show(e.Mensagem);
				e.ModalResult = ModalResult.OK;
			}
			else if (e.Operacao == ACBrTEFDOperacaoMensagem.YesNo)
			{
				var ret = MessageBox.Show(this, e.Mensagem, this.Text, MessageBoxButtons.YesNo);
				e.ModalResult = ret == DialogResult.Yes ? ModalResult.Yes : ModalResult.No;
			}
			else
			{
				this.Invoke(new Action(() => messageLabel.Text = e.Mensagem));
			}
		}

		private void tef_OnDepoisConfirmarTransacoes(object sender, DepoisConfirmarTransacoesEventArgs e)
		{
		}

		private void tef_OnDepoisCancelarTransacoes(object sender, DepoisCancelarTransacoesEventArgs e)
		{
		}

		private void tef_OnComandaECFSubtotaliza(object sender, ComandaECFSubtotalizaEventArgs e)
		{
			retECF = e.RetornoECF = RetornoECF.PagamentoOuSubTotal;
		}

		private void tef_OnComandaECFPagamento(object sender, ComandaECFPagamentoEventArgs e)
		{
			retECF = e.RetornoECF = RetornoECF.Livre;
		}

		private void tef_OnComandaECFImprimeVia(object sender, ComandaECFImprimeViaEventArgs e)
		{
			MessageBox.Show(string.Join("\n", e.ImagemComprovante));
			retECF = e.RetornoECF = RetornoECF.Livre;
		}

		private void tef_OnComandaECFAbreVinculado(object sender, ComandaECFAbreVinculadoEventArgs e)
		{
			retECF = e.RetornoECF = RetornoECF.CDC;
		}

		private void tef_OnComandaECF(object sender, ComandaECFEventArgs e)
		{
			switch (e.Operacao)
			{
				case ACBrTEFDOperacaoECF.SubTotalizaCupom:
					retECF = e.RetornoECF = RetornoECF.PagamentoOuSubTotal;
					break;

				case ACBrTEFDOperacaoECF.AbreGerencial:
				case ACBrTEFDOperacaoECF.PulaLinhas:
				case ACBrTEFDOperacaoECF.ImprimePagamentos:
					retECF = e.RetornoECF = RetornoECF.CDCouRelatorioGerencial;
					break;

				case ACBrTEFDOperacaoECF.FechaVinculado:
				case ACBrTEFDOperacaoECF.FechaGerencial:
				case ACBrTEFDOperacaoECF.CancelaCupom:
				case ACBrTEFDOperacaoECF.FechaCupom:
					retECF = e.RetornoECF = RetornoECF.Livre;
					break;
			}
		}

		private void tef_OnBloqueiaMouseTeclado(object sender, BloqueiaMouseTecladoEventArgs e)
		{
		}

		private void tef_OnAntesFinalizarRequisicao(object sender, AntesFinalizarRequisicaoEventArgs e)
		{
		}

		private void tef_OnAntesCancelarTransacao(object sender, AntesCancelarTransacaoEventArgs e)
		{
		}

		private void tef_OnAguardaResp(object sender, AguardaRespEventArgs e)
		{
		}

		#endregion EventHandlers

		#endregion Methods
	}
}