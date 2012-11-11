using System;
using System.Windows.Forms;
using ACBrFramework.ECF;
using ACBrFramework.TEFD;

namespace ACBrFramework.TEFDTeste
{
	public partial class MainForm : Form
	{
		#region Fields

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
			inicializarECFTEF();
		}		

		#endregion Constructor

		#region Methods

		private void inicializarECFTEF()
		{
			cmbModelo.Items.Add("AUTO");
			foreach (var modelo in Enum.GetValues(typeof(ModeloECF))) cmbModelo.Items.Add(modelo);
			cmbModelo.SelectedIndex = 0;

			foreach (var gp in Enum.GetValues(typeof(ACBrTEFDTipo))) cmbGP.Items.Add(gp);
			cmbGP.SelectedIndex = 0;

			cmbPorta.Items.Clear();
			cmbPorta.Items.Add("AUTO");
			cmbPorta.Items.Add("COM1");
			cmbPorta.Items.Add("COM2");
			cmbPorta.Items.Add("COM3");
			cmbPorta.Items.Add("COM4");
			cmbPorta.Items.Add("COM5");
			cmbPorta.Items.Add("COM6");
			cmbPorta.Items.Add("LPT1");
			cmbPorta.Items.Add("LPT2");
			cmbPorta.Items.Add("LPT3");
			cmbPorta.Items.Add("ecf.txt");
			cmbPorta.SelectedIndex = 0;
		}

		private void ativarECF()
		{
			try
			{
				if (!acBrECF1.Ativo)
				{
					if (cmbModelo.SelectedIndex == 0 && cmbPorta.SelectedIndex == 0)
					{
						if (acBrECF1.AcharECF())
						{
							MessageBox.Show("Não foi possivel localizar a ECF");
							return;
						}

						cmbModelo.SelectedItem = acBrECF1.Modelo;
						cmbPorta.SelectedItem = acBrECF1.Device.Porta;
					}
					else if (cmbModelo.SelectedIndex == 0 && cmbPorta.SelectedIndex != 0)
					{
						acBrECF1.Porta = (string)cmbPorta.SelectedItem;
						if (acBrECF1.AcharECF(true, false))
						{
							MessageBox.Show("Não foi possivel localizar a ECF");
							return;
						}
						
						cmbModelo.SelectedItem = acBrECF1.Modelo;
					}
					else if (cmbModelo.SelectedIndex != 0 && cmbPorta.SelectedIndex == 0)
					{
						acBrECF1.Modelo = (ModeloECF)cmbModelo.SelectedItem;
						if (acBrECF1.AcharPorta())
						{
							MessageBox.Show("Não foi possivel localizar a porta");
							return;
						}
						
						cmbPorta.SelectedItem = acBrECF1.Device.Porta;
					}
					else
					{
						acBrECF1.Modelo = (ModeloECF)cmbModelo.SelectedItem;
						acBrECF1.Porta = (string)cmbPorta.SelectedItem;
					}

					acBrECF1.Ativar();
					btnAtivar.Text = "Desativar";
					lblModelo.Text = acBrECF1.ModeloStr;
					pctModelo.Image = Properties.Resources._092;
					pctModelo.Refresh();
					WriteResp("ECF Ativada");
				}
				else
				{
					acBrECF1.Desativar();
					btnAtivar.Text = "Ativar";
					lblModelo.Text = "ECF Desativada";
					pctModelo.Image = Properties.Resources._093;
					pctModelo.Refresh();
					WriteResp("ECF Desativada");
				}				
					
			}
			catch(Exception ex)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = ex.Message;
			}
		}

		private void mostrarFPG()
		{
			try
			{
				acBrECF1.CarregaFormasPagamento();
				foreach (ACBrECFFormaPagamento forma in acBrECF1.FormasPagamento)
				{
					WriteResp(string.Format("Forma: {0} - {1}", forma.Indice, forma.Descricao));
				}
			}
			catch (Exception ex)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = ex.Message;
			}
		}

		private void WriteResp(string resp)
		{
			if (string.IsNullOrEmpty(resp)) return;

			foreach (string line in resp.Split('\n'))
			{
				respListBox.Items.Add(line);
			}
			respListBox.SelectedIndex = respListBox.Items.Count - 1;
		}

        #endregion Methods

        #region EventHandlers

		private void btnSerial_Click(object sender, EventArgs e)
		{
			using (SerialCFGForm serial = new SerialCFGForm())
			{
				serial.Device = acBrECF1.Device;
				serial.ShowDialog();
				cmbPorta.SelectedItem = acBrECF1.Device.Porta;
			}
		}

		private void btnAtivar_Click(object sender, EventArgs e)
		{
			ativarECF();
		}

		private void btnFPG_Click(object sender, EventArgs e)
		{
			mostrarFPG();
		}

		#region Eventos TEF

		private void tef_OnRestauraFocoAplicacao(object sender, ExecutaAcaoEventArgs e)
		{
			this.Focus();
			e.Tratado = true;
		}

		private void tef_OnMudaEstadoResp(object sender, MudaEstadoRespEventArgs e)
		{
			
		}

		private void tef_OnMudaEstadoReq(object sender, MudaEstadoReqEventArgs e)
		{
			
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

		#endregion Eventos TEF

		#endregion EventHandlers
	}
}