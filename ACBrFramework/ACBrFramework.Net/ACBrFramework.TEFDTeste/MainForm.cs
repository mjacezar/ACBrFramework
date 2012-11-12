using System;
using System.Windows.Forms;
using System.Drawing;
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
			cmbModelo.Items.Clear();
			cmbModelo.Items.Add("AUTO");
			foreach (var modelo in Enum.GetValues(typeof(ModeloECF))) cmbModelo.Items.Add(modelo);
			cmbModelo.SelectedIndex = 0;

			cmbGP.Items.Clear();
			foreach (var gp in Enum.GetValues(typeof(ACBrTEFDTipo))) cmbGP.Items.Add(gp);
			cmbGP.SelectedIndex = 0;

            cmbGPAtual.Items.Clear();
            foreach (var gp in Enum.GetValues(typeof(ACBrTEFDTipo))) cmbGPAtual.Items.Add(gp);
            cmbGPAtual.SelectedIndex = 0;

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

            cmbTEFDirecao.Items.Clear();
            cmbTEFDirecao.Items.Add("Nenhuma Transação");
            cmbTEFDirecao.Items.Add("Cartão de Crédito");
            cmbTEFDirecao.Items.Add("Cartão de Débito");
            cmbTEFDirecao.Items.Add("Cartão Voucher");
            cmbTEFDirecao.Items.Add("Cartão Private Label");
            cmbTEFDirecao.Items.Add("Cheque");
            cmbTEFDirecao.Items.Add("Controle de Frota");
            cmbTEFDirecao.SelectedIndex = 0;
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
                            WriteResp("Não foi possivel localizar a ECF");
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
                            WriteResp("Não foi possivel localizar a ECF");
							return;
						}
						
						cmbModelo.SelectedItem = acBrECF1.Modelo;
					}
					else if (cmbModelo.SelectedIndex != 0 && cmbPorta.SelectedIndex == 0)
					{
						acBrECF1.Modelo = (ModeloECF)cmbModelo.SelectedItem;
						if (acBrECF1.AcharPorta())
						{
                            WriteResp("Não foi possivel localizar a porta");
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
					pctModelo.Image = Properties.Resources._092;
					pctModelo.Refresh();
					WriteResp("ECF Ativada");
				}
				else
				{
					acBrECF1.Desativar();
					btnAtivar.Text = "Ativar";
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

		private void iniciarGP()
		{
			try
			{			

				if (btnIniciarGP.Text.Equals("Inicializar"))
				{
					acBrTEFD1.EsperaSleep = Convert.ToInt32(txtEsperaSleep.Text);
					acBrTEFD1.Initializar((ACBrTEFDTipo)cmbGP.SelectedItem);
					btnIniciarGP.Text = "Desinicializar";					
					WriteResp(string.Format("Tef: {0} - Iniciado", cmbGP.Text));					
				}
				else
				{
					acBrTEFD1.DesInicializar((ACBrTEFDTipo)cmbGP.SelectedItem);
                    btnIniciarGP.Text = "Inicializar";	
					WriteResp(string.Format("Tef: {0} - Desinicializado", cmbGP.Text));
                }

                analisaTEF();
				
			}
			catch (Exception ex)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = ex.Message;
			}
		}

        private void analisaTEF()
        {
            Image imgRed = Properties.Resources._093;
            Image imgGreen = Properties.Resources._092;


            if (acBrTEFD1.TEFDial.Habilitado)
            {
                acBrTEFD1.TEFDial.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctDial.Image = imgGreen;
                pctDial.Refresh();
            }
            else
            {
                acBrTEFD1.TEFDial.EsperaSTS = 7;
                pctDial.Image = imgRed;
                pctDial.Refresh();
            }

            if (acBrTEFD1.TEFDisc.Habilitado)
            {
                acBrTEFD1.TEFDisc.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctDisc.Image = imgGreen;
                pctDisc.Refresh();
            }
            else
            {
                acBrTEFD1.TEFDisc.EsperaSTS = 7;
                pctDisc.Image = imgRed;
                pctDisc.Refresh();
            }

            if (acBrTEFD1.TEFHiper.Habilitado)
            {
                acBrTEFD1.TEFHiper.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctHiper.Image = imgGreen;
                pctHiper.Refresh();
            }
            else
            {
                acBrTEFD1.TEFHiper.EsperaSTS = 7;
                pctHiper.Image = imgRed;
                pctHiper.Refresh();
            }

            if (acBrTEFD1.TEFCrediShop.Habilitado)
            {
                acBrTEFD1.TEFCrediShop.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctCrediShop.Image = imgGreen;
                pctCrediShop.Refresh();
            }
            else
            {
                acBrTEFD1.TEFCrediShop.EsperaSTS = 7;
                pctCrediShop.Image = imgRed;
                pctCrediShop.Refresh();
            }

            if (acBrTEFD1.TEFAuttar.Habilitado)
            {
                acBrTEFD1.TEFAuttar.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctAuttar.Image = imgGreen;
                pctAuttar.Refresh();
            }
            else
            {
                acBrTEFD1.TEFAuttar.EsperaSTS = 7;
                pctAuttar.Image = imgRed;
                pctAuttar.Refresh();
            }

            if (acBrTEFD1.TEFAuttar.Habilitado)
            {
                acBrTEFD1.TEFAuttar.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctAuttar.Image = imgGreen;
                pctAuttar.Refresh();
            }
            else
            {
                acBrTEFD1.TEFAuttar.EsperaSTS = 7;
                pctAuttar.Image = imgRed;
                pctAuttar.Refresh();
            }

            if (acBrTEFD1.TEFGPU.Habilitado)
            {
                acBrTEFD1.TEFGPU.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctGPU.Image = imgGreen;
                pctGPU.Refresh();
            }
            else
            {
                acBrTEFD1.TEFGPU.EsperaSTS = 7;
                pctGPU.Image = imgRed;
                pctGPU.Refresh();
            }

            if (acBrTEFD1.TEFGood.Habilitado)
            {
                acBrTEFD1.TEFGood.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctGood.Image = imgGreen;
                pctGood.Refresh();
            }
            else
            {
                acBrTEFD1.TEFGood.EsperaSTS = 7;
                pctGood.Image = imgRed;
                pctGood.Refresh();
            }

            if (acBrTEFD1.TEFFoxWin.Habilitado)
            {
                acBrTEFD1.TEFFoxWin.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctFoxWin.Image = imgGreen;
                pctFoxWin.Refresh();
            }
            else
            {
                acBrTEFD1.TEFFoxWin.EsperaSTS = 7;
                pctFoxWin.Image = imgRed;
                pctFoxWin.Refresh();
            }

            if (acBrTEFD1.TEFPetrocard.Habilitado)
            {
                acBrTEFD1.TEFPetrocard.EsperaSTS = Convert.ToInt32(txtEsperaSTS.Text);
                pctPetrocard.Image = imgGreen;
                pctPetrocard.Refresh();
            }
            else
            {
                acBrTEFD1.TEFPetrocard.EsperaSTS = 7;
                pctPetrocard.Image = imgRed;
                pctPetrocard.Refresh();
            }


            cmbGPAtual.SelectedItem = acBrTEFD1.GPAtual;
            cmbGP.SelectedItem = cmbGPAtual.SelectedItem;
            
        }

		private void AtivarGP()
		{
			try
			{
				acBrTEFD1.AtivarGP((ACBrTEFDTipo)cmbGP.SelectedItem);
                WriteResp(string.Format("TEF - {0}", cmbGP.Text));
			}
			catch (Exception ex)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = ex.Message;
			}
		}

        private void CancelarTransacoesPendentes()
        {
            try
            {
                acBrTEFD1.CancelarTransacoesPendentes();
                WriteResp("TEF - Transações Pendentes Canceladas");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void ImprimirTransacoesPendentes()
        {
            try
            {
                acBrTEFD1.ImprimirTransacoesPendentes();
                WriteResp("TEF - Imprimindo Transações Pendentes");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void ConfirmarTransacoesPendentes()
        {
            try
            {
                acBrTEFD1.ConfirmarTransacoesPendentes();
                WriteResp("TEF - Confirmando Transações Pendentes");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void FinalizarCupom()
        {
            try
            {
                acBrTEFD1.FinalizarCupom();
                WriteResp("TEF - Finalizando Cupoms");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void LeituraX()
        {
            try
            {
                acBrECF1.LeituraX();
                WriteResp("ECF - Leitura X");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void ReducaoZ()
        {
            try
            {
                if (MessageBox.Show(@"A Redução Z pode Bloquear o seu ECF até a 12:00pm.\nContinuar assim mesmo ?", "TEF", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    acBrECF1.ReducaoZ();
                    WriteResp("ECF - Redução Z");
                }
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void AbrirCupom()
        {
            try
            {
                acBrECF1.AbreCupom();
                WriteResp("ECF - Cumpom Aberto");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void VendeItem()
        {
            try
            {
                decimal valor;
                if (!decimal.TryParse(txtValorECF.Text, out valor))
                    return;

                VendeItem(valor);
            }             
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void VendeItem(decimal valor)
        {
            try
            {
                acBrECF1.VendeItem("12345", "PRODUTO TESTE", "NN", 1, valor);
                WriteResp("ECF - Vende Item");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void SubTotaliza()
        {
            try
            {
                acBrECF1.SubtotalizaCupom();
                WriteResp("ECF - SubTotaliza Cupom");
                MostrarSaldoRestante();
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void Pagamento()
        {
            try
            {
                string indice = "01";
                decimal valor;

                if (!decimal.TryParse(txtValorECF.Text, out valor))
                    return;

                if (InputBox.Show(string.Format("Pagamento de {0:c} Digite o Cod.Forma Pagamento", valor), "Indice da Forma de Pagamento", ref indice).Equals(DialogResult.OK))
                {
                    acBrECF1.EfetuaPagamento(indice, valor);
                    WriteResp("Pagamento Efetuado");
                    WriteResp(string.Format("Pagamento: {0} efetuado no valor de {1:c}", indice, valor));
                    MostrarSaldoRestante();
                }
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }

        }

        private void FecharCupom()
        {
            try
            {
                acBrECF1.FechaCupom(@"Projeto ACBrFramework|http://acbrframework.sf.net");
                WriteResp("ECF - Fechar Cupom");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void CancelarCupom()
        {
            try
            {
                acBrECF1.CancelaCupom();
                WriteResp("ECF - Cancela Cupom");
                acBrTEFD1.CancelarTransacoesPendentes();
                WriteResp("TEF - Cancela Transações");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void FecharGerencialVinculado()
        {
            try
            {
                acBrECF1.FechaRelatorio();
                WriteResp("ECF - Fecha Relatorio");                
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void Estado()
        {
            try
            {
                WriteResp(string.Format("ECF - {0}", acBrECF1.Estado));
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void AdicionarPagamento()
        {
            try
            {
                string indice = "01";
                string Valor = "0,00";
                decimal valor = 0;

                if (CalculaSaldoRestante() <= 0)
                {
                    WriteResp("Total do Cupom já foi atingido");
                    return;
                }

                if (InputBox.Show("Pagamento", "Digite o indice da forma de pagamento", ref indice).Equals(DialogResult.Cancel))
                    return;

                if (InputBox.Show("Pagamento", "Digite o Valor Pago", ref Valor).Equals(DialogResult.Cancel))
                    return;

                if (!decimal.TryParse(Valor, out valor))
                {
                    WriteResp("ECF - Valor invalido");
                    return;
                }

                if (string.IsNullOrEmpty(indice) || acBrECF1.AchaFPGIndice(indice) == null)
                {
                    WriteResp("ECF - Codigo da forma de pagamento invalido");
                    return;
                }

                pgtoList.Items.Add(string.Format("{0}|{1}", indice, valor));
                WriteResp(string.Format("Pagamento: {0} no valor: {1} acumulado", indice, valor));
                MostrarSaldoRestante();
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void RemoverPagamento()
        {
            try
            {
                if (pgtoList.SelectedIndex < 0)
                    return;

                pgtoList.Items.Remove(pgtoList.SelectedItem);
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void LimparPagamentos()
        {
            try
            {
                pgtoList.Items.Clear();
                txtDescAcresc.Text = "0,00";
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void MostrarSaldoRestante()
        {
            try
            {
                WriteResp(string.Format("Saldo Restante - {0:C2}", CalculaSaldoRestante()));
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private decimal CalculaSaldoRestante()
        {
            decimal valor = 0, saldo = 0;

            decimal.TryParse(txtDescAcresc.Text, out valor);
            saldo = acBrECF1.SubTotal + valor;
            saldo = saldo - acBrECF1.TotalPago;
            saldo = saldo - CalculaTotalPago();

            return saldo;
        }

        private decimal CalculaTotalPago()
        {
            decimal TotalPago = 0, valor;

            foreach (string pagto in pgtoList.Items)
            {
                string[] pgt = pagto.Split('|');
                decimal.TryParse(pgt[1], out valor);
                TotalPago += valor;
            }

            return TotalPago;
        }

        private void VerificarECFATV()
        {
            try
            {
                if(!acBrECF1.Ativo)
                    WriteResp("ATENÇÃO !! O ECF AINDA NÃO FOI ATIVADO");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void ATV()
        {
            try
            {
                acBrTEFD1.ATV((ACBrTEFDTipo)cmbGPAtual.SelectedItem);
                WriteResp("ATV executado com sucesso");  
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void ADM()
        {
            try
            {
                VerificarECFATV();

                if(acBrTEFD1.ADM((ACBrTEFDTipo)cmbGPAtual.SelectedItem))
                    WriteResp("ADM executado com sucesso");
                else
                    WriteResp("Falha ao executar ADM");
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void CNF()
        {
            try
            {
                using (CNF_CNCForm CNF = new CNF_CNCForm())
                {
                    CNF.IsNCN = false;
                    if (CNF.ShowDialog().Equals(DialogResult.OK))
                    {
                        acBrTEFD1.CNF(CNF.Rede, CNF.NSU, CNF.Finalizacao);
                        WriteResp("CNF executado com sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void NCN()
        {
            try
            {
                using (CNF_CNCForm NCN = new CNF_CNCForm())
                {
                    NCN.IsNCN = true;
                    if (NCN.ShowDialog().Equals(DialogResult.OK))
                    {
                        acBrTEFD1.NCN(NCN.Rede, NCN.NSU, NCN.Finalizacao, NCN.Valor);
                        WriteResp("NCN executado com sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = ex.Message;
            }
        }

        private void CRT()
        {
            try
            {
                decimal valor = 0;

                if (!decimal.TryParse(txtValorTEF.Text, out valor))
                {
                    WriteResp("TEF - Valor incorreto");
                    return;
                }

                acBrTEFD1.CRT(valor, txtIndCartao.Text, acBrECF1.NumCOO);
                MostrarSaldoRestante();
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

		private void btnIniciarGP_Click(object sender, EventArgs e)
		{
			iniciarGP();
		}

		private void btnAtivarGP_Click(object sender, EventArgs e)
		{
			AtivarGP();
		}

        private void button22_Click(object sender, EventArgs e)
        {
            CancelarTransacoesPendentes();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ConfirmarTransacoesPendentes();
        }

        private void btnImprimiPendentes_Click(object sender, EventArgs e)
        {
            ImprimirTransacoesPendentes();
        }

        private void btnFinalizarCupom_Click(object sender, EventArgs e)
        {
            FinalizarCupom();
        }

        private void btnLeituraX_Click(object sender, EventArgs e)
        {
            LeituraX();
        }

        private void btnReducaoZ_Click(object sender, EventArgs e)
        {
            ReducaoZ();
        }

        private void btnAbrirECF_Click(object sender, EventArgs e)
        {
            AbrirCupom();
        }

        private void btnVendeItem_Click(object sender, EventArgs e)
        {
            VendeItem();
        }

        private void btnSubTotalizar_Click(object sender, EventArgs e)
        {
            SubTotaliza();
        }
        
        private void btnPagamento_Click(object sender, EventArgs e)
        {
            Pagamento();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FecharCupom();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarCupom();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimparPagamentos();
        }

        private void btnAbreVendeTotaliza_Click(object sender, EventArgs e)
        {
            AbrirCupom();
            VendeItem();
            SubTotaliza();
        }

        private void btnFecharGerencial_Click(object sender, EventArgs e)
        {
            FecharGerencialVinculado();
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            Estado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarPagamento();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MostrarSaldoRestante();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoverPagamento();
        }

        private void btnATV_Click(object sender, EventArgs e)
        {
            ATV();
        }

        private void btnADM_Click(object sender, EventArgs e)
        {
            ADM();
        }

        private void btnNCN_Click(object sender, EventArgs e)
        {
            NCN();
        }

        private void btnCNF_Click(object sender, EventArgs e)
        {
            CNF();
        }

        private void btnCRT_Click(object sender, EventArgs e)
        {
            CRT();
        }

		private void chkAutoAtivarGP_CheckedChanged(object sender, EventArgs e)
		{
			acBrTEFD1.AutoAtivar = chkAutoAtivarGP.Checked;
		}

		private void chkMultiplosCartoes_CheckedChanged(object sender, EventArgs e)
		{
			acBrTEFD1.MultiplosCartoes = chkMultiplosCartoes.Checked;
            chkMulti.Checked = chkMultiplosCartoes.Checked;
		}

        private void chkMulti_CheckedChanged(object sender, EventArgs e)
        {
            chkMultiplosCartoes.Checked = chkMulti.Checked;
        }

		private void chkAutoEfetuarPagamento_CheckedChanged(object sender, EventArgs e)
		{
			acBrTEFD1.AutoEfetuarPagamento = chkAutoEfetuarPagamento.Checked;
		}

		private void chkAutoFinalizarCupom_CheckedChanged(object sender, EventArgs e)
		{
			acBrTEFD1.AutoFinalizarCupom = chkAutoFinalizarCupom.Checked;
		}

		private void chkCHQGerencial_CheckedChanged(object sender, EventArgs e)
		{
			acBrTEFD1.CHQEmGerencial = chkCHQGerencial.Checked;
		}

        private void cmbGPAtual_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGPAtual.SelectedItem == null)
                return;

            acBrTEFD1.GPAtual = (ACBrTEFDTipo)cmbGPAtual.SelectedItem;
            analisaTEF();
        }

        private void cmbGP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGP.SelectedItem == null)
                return;

            acBrTEFD1.GPAtual = (ACBrTEFDTipo)cmbGP.SelectedItem;
            analisaTEF();
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
                switch (acBrECF1.Estado)
                {
                    case EstadoECF.Livre:
                        e.RetornoECF = RetornoECF.Livre;
                        break;

                    case EstadoECF.Venda:
                        e.RetornoECF = RetornoECF.VendaDeItens;
                        break;

                    case EstadoECF.Pagamento:
                        e.RetornoECF = RetornoECF.PagamentoOuSubTotal;
                        break;

                    case EstadoECF.Relatorio:
                        e.RetornoECF = RetornoECF.RelatorioGerencial;
                        break;

                    case EstadoECF.NaoFiscal:
                        e.RetornoECF = RetornoECF.RecebimentoNaoFiscal;
                        break;

                    default:
                        e.RetornoECF = RetornoECF.Outro;
                        break;
                }
			}
			else if (e.Operacao == ACBrTEFDInfoECF.SubTotal)
			{
                decimal valor = 0;
                valor += acBrECF1.SubTotal;
                valor -= acBrECF1.TotalPago + decimal.Parse(txtDescAcresc.Text);
				e.Value = valor;
			}
            else if (e.Operacao == ACBrTEFDInfoECF.TotalAPagar)
			{
                e.Value = CalculaTotalPago();
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