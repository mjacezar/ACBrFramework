using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ACBrFramework.AAC;
using ACBrFramework.ECF;
using ACBrFramework.PAF;

namespace ACBrFramework.ECFTeste
{
	public partial class MainForm : Form
	{
		#region Fields

		private StringBuilder bobina = new StringBuilder();

		#endregion Fields

		#region Constructor

		public MainForm()
		{
			InitializeComponent();

			InicializarECF();
			Popular();
			PopularAAC();
		}

		#endregion Constructor

		#region Methods

		#region ACC

		private void PopularAAC()
		{
			aacTipoDesenvolvimentoComboBox.Items.Clear();
			foreach (var desenv in Enum.GetValues(typeof(TipoDesenvolvimento))) aacTipoDesenvolvimentoComboBox.Items.Add(desenv);

			aacTipoIntegracaoComboBox.Items.Clear();
			foreach (var integ in Enum.GetValues(typeof(TipoIntegracao))) aacTipoIntegracaoComboBox.Items.Add(integ);

			aacTipoFuncionamentoComboBox.Items.Clear();
			foreach (var func in Enum.GetValues(typeof(TipoFuncionamento))) aacTipoFuncionamentoComboBox.Items.Add(func);
		}

		private void CarregarAAC()
		{
			acbrAAC.NomeArquivoAuxiliar = aacNomeArquivoTextbox.Text;

			try
			{
				acbrAAC.AbrirArquivo();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return;
			}

			//Dados da software house
			aacRazaoSocialTextBox.Text = acbrAAC.IdentPaf.Empresa.RazaoSocial;
			aacIETextBox.Text = acbrAAC.IdentPaf.Empresa.IE;
			aacIMTextBox.Text = acbrAAC.IdentPaf.Empresa.IM;
			aacCNPJTextBox.Text = acbrAAC.IdentPaf.Empresa.CNPJ;

			//Dados do aplicativo
			aacBancoDadosTextBox.Text = acbrAAC.IdentPaf.Paf.BancoDeDadosAplicativo;
			aacLinguagemTextBox.Text = acbrAAC.IdentPaf.Paf.LinguagemAplicativo;
			aacMD5TextBox.Text = acbrAAC.IdentPaf.Paf.MD5Aplicativo;
			aacNomePAFTextBox.Text = acbrAAC.IdentPaf.Paf.NomeAplicativo;
			aacPrincipalExeTextBox.Text = acbrAAC.IdentPaf.Paf.PrincipalExeAplicativo;
			aacSOTextBox.Text = acbrAAC.IdentPaf.Paf.SistemaOperacionalAplicativo;
			aacVersaoTextBox.Text = acbrAAC.IdentPaf.Paf.VersaoAplicativo;

			//Dados de funcionalidade
			aacTipoDesenvolvimentoComboBox.SelectedItem = acbrAAC.IdentPaf.Paf.TipoDesenvolvimento;
			aacTipoFuncionamentoComboBox.SelectedItem = acbrAAC.IdentPaf.Paf.TipoFuncionamento;
			aacTipoIntegracaoComboBox.SelectedItem = acbrAAC.IdentPaf.Paf.TipoIntegracao;

			//Dados de não concomitância
			aacRealizaDavAnexoIICheckBox.Checked = acbrAAC.IdentPaf.Paf.RealizaDAVConfAnexoII;
			aacRealizaDavECFCheckBox.Checked = acbrAAC.IdentPaf.Paf.RealizaDAVECF;
			aacRealizaDavNaoFiscalCheckBox.Checked = acbrAAC.IdentPaf.Paf.RealizaDAVNaoFiscal;
			aacRealizaDavOSCheckBox.Checked = acbrAAC.IdentPaf.Paf.RealizaDAVOS;
			aacRealizaLancMesaCheckBox.Checked = acbrAAC.IdentPaf.Paf.RealizaLancamentoMesa;
			aacRealizaPreVendaCheckBox.Checked = acbrAAC.IdentPaf.Paf.RealizaPreVenda;

			//Dados de aplicações especiais
			aacImpressoraNaoFiscalProdCheckBox.Checked = acbrAAC.IdentPaf.Paf.UsaImpressoraNaoFiscal;
			aacIndTecProdCheckBox.Checked = acbrAAC.IdentPaf.Paf.IndiceTecnicoProducao;
			aacBalancaCheckBox.Checked = acbrAAC.IdentPaf.Paf.BarSimiliarBalanca;
			aacBarECFComumCheckBox.Checked = acbrAAC.IdentPaf.Paf.BarSimiliarECFComum;
			aacBarECFRestauranteCheckBox.Checked = acbrAAC.IdentPaf.Paf.BarSimiliarECFRestaurante;
			aacImprimeDAVDiscFormCheckBox.Checked = acbrAAC.IdentPaf.Paf.DAVDiscrFormula;

			//Dados critério por uf

			aacTotalizaValoresListaCheckBox.Checked = acbrAAC.IdentPaf.Paf.TotalizaValoresLista;
			aacListaPreVendaCheckBox.Checked = acbrAAC.IdentPaf.Paf.TransPreVenda;
			aacListaDAVCheckBox.Checked = acbrAAC.IdentPaf.Paf.TransDAV;
			aacRecompoeGTCheckBox.Checked = acbrAAC.IdentPaf.Paf.RecompoeGT;
			aacEmissaoDocFisPED.Checked = acbrAAC.IdentPaf.Paf.EmitePED;
			aacCupomManiaCheckBox.Checked = acbrAAC.IdentPaf.Paf.CupomMania;
			aacMinasLegalCheckBox.Checked = acbrAAC.IdentPaf.Paf.MinasLegal;

			//Dados ECFs autorizadas
			int numeroEcfs = acbrAAC.IdentPaf.ECFsAutorizados.Count;

			aacECFsAutorizadaDataGridView.Rows.Clear();

			foreach (AACECF ecfAutorizado in acbrAAC.IdentPaf.ECFsAutorizados)
			{
				aacECFsAutorizadaDataGridView.Rows.Add(ecfAutorizado.NumeroSerie, ecfAutorizado.CRO, ecfAutorizado.CNI, ecfAutorizado.ValorGT);
			}
		}

		private bool ValidarAAC()
		{
			string nomeArquivo = aacNomeArquivoTextbox.Text;
			string diretorio = Path.GetDirectoryName(nomeArquivo);
			bool validado = true;

			if (!Directory.Exists(diretorio))
			{
				validado = false;
				MessageBox.Show("Caminho especificado não é valido");
			}

			return validado;
		}

		private void RecriarAAC()
		{
			if (!ValidarAAC()) return;

			File.WriteAllText(aacNomeArquivoTextbox.Text, "");

			acbrAAC.NomeArquivoAuxiliar = aacNomeArquivoTextbox.Text;

			//Dados da software house
			acbrAAC.IdentPaf.Empresa.RazaoSocial = aacRazaoSocialTextBox.Text;
			acbrAAC.IdentPaf.Empresa.IE = aacIETextBox.Text;
			acbrAAC.IdentPaf.Empresa.IM = aacIMTextBox.Text;
			acbrAAC.IdentPaf.Empresa.CNPJ = aacCNPJTextBox.Text;

			//Dados do aplicativo
			acbrAAC.IdentPaf.Paf.BancoDeDadosAplicativo = aacBancoDadosTextBox.Text;
			acbrAAC.IdentPaf.Paf.LinguagemAplicativo = aacLinguagemTextBox.Text;
			acbrAAC.IdentPaf.Paf.MD5Aplicativo = aacMD5TextBox.Text;
			acbrAAC.IdentPaf.Paf.NomeAplicativo = aacNomePAFTextBox.Text;
			acbrAAC.IdentPaf.Paf.PrincipalExeAplicativo = aacPrincipalExeTextBox.Text;
			acbrAAC.IdentPaf.Paf.SistemaOperacionalAplicativo = aacSOTextBox.Text;
			acbrAAC.IdentPaf.Paf.VersaoAplicativo = aacVersaoTextBox.Text;

			//Dados de funcionalidade
			if (aacTipoDesenvolvimentoComboBox.SelectedItem != null)
			{
				acbrAAC.IdentPaf.Paf.TipoDesenvolvimento = (TipoDesenvolvimento)aacTipoDesenvolvimentoComboBox.SelectedItem;
			}
			if (aacTipoFuncionamentoComboBox.SelectedItem != null)
			{
				acbrAAC.IdentPaf.Paf.TipoFuncionamento = (TipoFuncionamento)aacTipoFuncionamentoComboBox.SelectedItem;
			}
			if (aacTipoIntegracaoComboBox.SelectedItem != null)
			{
				acbrAAC.IdentPaf.Paf.TipoIntegracao = (TipoIntegracao)aacTipoIntegracaoComboBox.SelectedItem;
			}

			//Dados de não concomitância
			acbrAAC.IdentPaf.Paf.RealizaDAVConfAnexoII = aacRealizaDavAnexoIICheckBox.Checked;
			acbrAAC.IdentPaf.Paf.RealizaDAVECF = aacRealizaDavECFCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.RealizaDAVNaoFiscal = aacRealizaDavNaoFiscalCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.RealizaDAVOS = aacRealizaDavOSCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.RealizaLancamentoMesa = aacRealizaLancMesaCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.RealizaPreVenda = aacRealizaPreVendaCheckBox.Checked;

			//Dados de aplicações especiais
			acbrAAC.IdentPaf.Paf.UsaImpressoraNaoFiscal = aacImpressoraNaoFiscalProdCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.IndiceTecnicoProducao = aacIndTecProdCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.BarSimiliarBalanca = aacBalancaCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.BarSimiliarECFComum = aacBarECFComumCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.BarSimiliarECFRestaurante = aacBarECFRestauranteCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.DAVDiscrFormula = aacImprimeDAVDiscFormCheckBox.Checked;

			//Dados critério por uf

			acbrAAC.IdentPaf.Paf.TotalizaValoresLista = aacTotalizaValoresListaCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.TransPreVenda = aacListaPreVendaCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.TransDAV = aacListaDAVCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.RecompoeGT = aacRecompoeGTCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.EmitePED = aacEmissaoDocFisPED.Checked;
			acbrAAC.IdentPaf.Paf.CupomMania = aacCupomManiaCheckBox.Checked;
			acbrAAC.IdentPaf.Paf.MinasLegal = aacMinasLegalCheckBox.Checked;

			//Dados parametros
            lstParam.Items.CopyTo(acbrAAC.Params, 0);

			//Dados ECFs autorizadas
			//ACBrDll.TECFAutorizado ecfAutorizado;

			acbrAAC.IdentPaf.ECFsAutorizados.Clear();

			foreach (DataGridViewRow row in aacECFsAutorizadaDataGridView.Rows)
			{
				AACECF ecfAutorizado = new AACECF();

				ecfAutorizado.ValorGT = Convert.ToDecimal(row.Cells["valorGTColumn"].Value);
				ecfAutorizado.NumeroSerie = row.Cells["numSerieColumn"].Value.ToString();
				ecfAutorizado.CRO = Convert.ToInt32(row.Cells["CROColumn"].Value);
				ecfAutorizado.CNI = Convert.ToInt32(row.Cells["CNIColumn"].Value);

				acbrAAC.IdentPaf.ECFsAutorizados.New(ecfAutorizado);
			}

			try
			{
				acbrAAC.SalvarArquivo();
				MessageBox.Show("Arquivo de configuração criado com sucesso!");
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		#endregion ACC

		#region ECF

		private void InicializarECF()
		{
			List<string> fsMemoParams = new List<string>();
			fsMemoParams.Add("[Cabecalho]");
			fsMemoParams.Add("LIN000=<center><b>ACBrFramework.Net</b></center>");
			fsMemoParams.Add("LIN001=<center>Nome da Rua , 1234  -  Bairro</center>");
			fsMemoParams.Add("LIN002=<center>Cidade  -  UF  -  99999-999</center>");
			fsMemoParams.Add("LIN003=<center>CNPJ: 01.234.567/0001-22    IE: 012.345.678.90</center>");
			fsMemoParams.Add("LIN004=<table width=100%><tr><td align=left><code>Data</code> <code>Hora</code></td><td align=right>COO: <b><code>NumCupom</code></b></td></tr></table>");
			fsMemoParams.Add("LIN005=<hr>");
			fsMemoParams.Add(" ");
			fsMemoParams.Add("[Cabecalho_Item]");
			fsMemoParams.Add("LIN000=ITEM   CODIGO      DESCRICAO");
			fsMemoParams.Add("LIN001=QTD         x UNITARIO       Aliq     VALOR (R$)");
			fsMemoParams.Add("LIN002=<hr>");
			fsMemoParams.Add("MascaraItem=III CCCCCCCCCCCCCC DDDDDDDDDDDDDDDDDDDDDDDDDDDDD QQQQQQQQ UU x VVVVVVVVVVVVV AAAAAA TTTTTTTTTTTTT");
			fsMemoParams.Add(" ");
			fsMemoParams.Add("[Rodape]");
			fsMemoParams.Add("LIN000=<hr>");
			fsMemoParams.Add("LIN001=<table width=100%><tr><td align=left><code>Data</code> <code>Hora</code></td><td align=right>Projeto ACBr: <b><code>ACBrFramework.Net</code></b></td></tr></table>");
			fsMemoParams.Add("LIN002=<center>Obrigado Volte Sempre</center>");
			fsMemoParams.Add("LIN003=<hr>");
			fsMemoParams.Add(" ");
			fsMemoParams.Add("[Formato]");
			fsMemoParams.Add("Colunas=49");
			fsMemoParams.Add("HTML=1");
			fsMemoParams.Add("HTML_Title_Size=2");
			fsMemoParams.Add("HTML_Font=<font size=\"2\" face=\"Lucida Console\">");

			acbrECF.MemoParams = fsMemoParams.ToArray();
		}

		private void Popular()
		{
			modeloComboBox.Items.Clear();
			foreach (var modelo in Enum.GetValues(typeof(ModeloECF))) modeloComboBox.Items.Add(modelo);
			modeloComboBox.SelectedIndex = 0;

			portaComboBox.Items.Clear();
			portaComboBox.Items.Add("Procurar");
			portaComboBox.Items.Add("COM1");
			portaComboBox.Items.Add("COM2");
			portaComboBox.Items.Add("COM3");
			portaComboBox.Items.Add("COM4");
			portaComboBox.Items.Add("COM5");
			portaComboBox.Items.Add("COM6");
			portaComboBox.Items.Add("LPT1");
			portaComboBox.Items.Add("LPT2");
			portaComboBox.Items.Add("LPT3");
			portaComboBox.Items.Add("ecf.txt");
			portaComboBox.SelectedIndex = 0;

			ativarCheckButton.Checked = false;
		}

		public void Ativar()
		{
			try
			{
				acbrECF.Modelo = (ModeloECF)modeloComboBox.SelectedItem;
				acbrECF.Device.Porta = (string)portaComboBox.SelectedItem;
				acbrECF.Device.TimeOut = (int)nudTimeOut.Value;

				acbrECF.GavetaSinalInvertido = gavetaCheckBox.Checked;
				acbrECF.DescricaoGrande = descricaoCheckBox.Checked;

				acbrECF.Ativar();
				ativarCheckButton.Checked = true;
				ativarCheckButton.Text = "Desativar";

				messageToolStripStatusLabel.Text = acbrECF.Estado.ToString();
				descriptionToolStripStatusLabel.Text = string.Empty;

				tabControl.SelectedTab = cmdTabPage;
				WriteResp(acbrECF.RespostaComando);
				WriteCmd(acbrECF.ComandoEnviado);
			}
			catch (Exception exception)
			{
				ativarCheckButton.Checked = false;

				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}		

		public void Desativar()
		{
			try
			{
				acbrECF.Desativar();
				ativarCheckButton.Checked = false;
				ativarCheckButton.Text = "Ativar";

				WriteResp(acbrECF.RespostaComando);
				WriteCmd(acbrECF.ComandoEnviado);
				messageToolStripStatusLabel.Text = "OK";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		public void Testar()
		{
			try
			{
				string message = string.Empty;

				message += string.Format("Impressora: {0}", acbrECF.ModeloStr);
				message += string.Format("\nVersão: {0}", acbrECF.NumVersao);
				message += string.Format("\nColunas: {0}", acbrECF.Colunas);
				message += "\n";
				message += string.Format("\nNúmero de série: {0}", acbrECF.NumSerie);
				message += string.Format("\nNum do ECF: {0}", acbrECF.NumECF);
				message += string.Format("\nData/Hora: {0:dd/MM/yyyy HH:mm:ss}", acbrECF.DataHora);

				messageToolStripStatusLabel.Text = acbrECF.Estado.ToString();
				descriptionToolStripStatusLabel.Text = string.Empty;

				MessageBox.Show(this, message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		public void Sair()
		{
			this.Close();
		}

		public void Ler_Estado()
		{
			try
			{
				WriteResp(string.Format("\nEstado: {0}", acbrECF.Estado));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		public void Ler_DataHora()
		{
			try
			{
				WriteResp(string.Format("\nDataHora: {0}", acbrECF.DataHora));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		public void Ler_NumECF()
		{
			try
			{
				WriteResp(string.Format("\nNum ECF: {0}", acbrECF.NumECF));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_NumLoja()
		{
			try
			{
				WriteResp(string.Format("Num Loja: {0}", acbrECF.NumLoja));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_NumSerie()
		{
			try
			{
				WriteResp(string.Format("Num Serie: {0}", acbrECF.NumSerie));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_NumVersao()
		{
			try
			{
				WriteResp(string.Format("Num Versao: {0}", acbrECF.NumVersao));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_CNPJ()
		{
			try
			{
				WriteResp(string.Format("CNPJ: {0}", acbrECF.CNPJ));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_IE()
		{
			try
			{
				WriteResp(string.Format("IE: {0}", acbrECF.IE));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_PAF()
		{
			try
			{
				WriteResp(string.Format("PAF: {0}", acbrECF.PAF));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_DadosReducaoZ()
		{
			try
			{
				WriteResp(string.Format("DadosReducaoZ:\n{0}", acbrECF.GetDadosReducaoZ()));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_DadosUltimaReducaoZ()
		{
			try
			{
				WriteResp(string.Format("DadosUltimaReducaoZ:\n{0}", acbrECF.GetDadosUltimaReducaoZ()));
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void Ler_TodasVariaveis()
		{
			var type = typeof(ACBrECF);
			foreach (var property in type.GetProperties())
			{
				try
				{
					object value = property.GetValue(acbrECF, null);

					if (value is System.Collections.ICollection)
					{
						var collection = (System.Collections.ICollection)value;
						lstResp.Items.Add(string.Format("{0}:", property.Name));

						foreach (var element in collection)
						{
							if (element == null) continue;

							lstResp.Items.Add("");

							Type elementType = element.GetType();

							foreach (var elementProperty in elementType.GetProperties())
							{
								object elementValue = elementProperty.GetValue(element, null);
								lstResp.Items.Add(string.Format("{0}: {1}", elementProperty.Name, elementValue));
							}
						}

						lstResp.Items.Add("");
						WriteResp(string.Format("{0} elemento(s)", collection.Count));
					}
					else
					{
						WriteResp(string.Format("{0}: {1}", property.Name, value));
					}

					descriptionToolStripStatusLabel.Text = string.Empty;
				}
				catch (NullReferenceException)
				{
					messageToolStripStatusLabel.Text = "Não inicializado.";
					descriptionToolStripStatusLabel.Text = string.Empty;
				}
				catch (Exception exception)
				{
					messageToolStripStatusLabel.Text = "Exception";
					descriptionToolStripStatusLabel.Text = exception.Message;
				}

				Application.DoEvents();
			}
		}

		private void TestaCupomFiscal()
		{
			try
			{
				if (acbrECF.Estado == EstadoECF.Livre)
				{
					lstResp.Items.Add("Abrindo cupom ...");
					bobina.Clear();
					acbrECF.AbreCupom("", "", "");
					Application.DoEvents();
				}

				if (acbrECF.Estado == EstadoECF.Venda)
				{
					for (int i = 0; i < 10; i++)
					{
						lstResp.Items.Add(String.Format("Vende Item #{0} ...", i));
						acbrECF.VendeItem(string.Format("{0:0000000000000}", i + 1), "PRODUTO àáèéìíòóùúü " + i, "I", 1, 1.99M, 0M, "UN", "%", "D");
						Application.DoEvents();
					}

					acbrECF.SubtotalizaCupom(0M, "Mensagem SubtotalizaCupom ACBr.NET");
					lstResp.Items.Add("Subtotaliza Cupom ...");
					Application.DoEvents();
				}

				if (acbrECF.Estado == EstadoECF.Pagamento)
				{
					if (acbrECF.TotalPago == 0)
					{
						var forma01 = acbrECF.FormasPagamento[0];
						acbrECF.EfetuaPagamento(forma01.Indice, 50M, "Mensagem EfetuaPagamento ACBr.NET", false);
						lstResp.Items.Add("Efetua Pagamento ...");
						Application.DoEvents();
					}

					acbrECF.FechaCupom("Mensagem àáèéìíòóùúü FechaCupom ACBr.NET");
					lstResp.Items.Add("Fecha Cupom ...");
					Application.DoEvents();

					WriteResp("Finalizado!");
				}
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
				WriteResp(exception.Message);
			}
		}

		private void TestaCupomDAV()
		{
			try
			{
				if (acbrECF.Estado == EstadoECF.Livre)
				{
					lstResp.Items.Add("Abrindo DAV ...");
					bobina.Clear();
					acbrECF.DAV_Abrir(DateTime.Now, "Pedido", "0001", "Teste", "Rafael", "Teste DAV", "99999999999", "Rafael", "Rua Teste");
					Application.DoEvents();
				}

				if (acbrECF.Estado == EstadoECF.Relatorio)
				{
					for (int i = 0; i < 10; i++)
					{
						lstResp.Items.Add(String.Format("DAV Item #{0} ...", i));
						acbrECF.DAV_RegistrarItem(string.Format("{0:0000000000000}", i + 1), "PRODUTO àáèéìíòóùúü " + i, "UN", 1, 1.99, 0, 0, false);
					}

					acbrECF.DAV_Fechar("Mensagem àáèéìíòóùúü FechaDAV ACBr.NET");
					lstResp.Items.Add("Fecha DAV ...");
					WriteResp("Finalizado!");
				}
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
				WriteResp(exception.Message);
			}
		}

		private void LeituraX()
		{
			try
			{
				bobina.Clear();
				acbrECF.LeituraX();
				WriteResp("LeituaX OK");
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		private void ReducaoZ()
		{
			try
			{
				bobina.Clear();
				acbrECF.ReducaoZ();
				WriteResp("ReducaoZ OK");
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

        private void programaFormaPagamento()
        {
            try
            {
                string descricao = "C. Debito";
                bool vinculado = false;

                if (InputBox.Show("Programaçao de Formas de Pagamento (FPG)", "Entre com a Descriçao:", ref descricao).Equals(DialogResult.Cancel))
                    return;

                if (acbrECF.Modelo != ModeloECF.NaoFiscal && acbrECF.Modelo != ModeloECF.Mecaf)
                {
                    if (MessageBox.Show("Permite Vinculado nessa Forma de Pagamento ?", "Demo ECF - ACBrFramework.NET", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                        vinculado = true;
                }

                string menssagem = string.Format("A Forma de Pagamento: {0} será programada. \nCuidado !! A programação de Formas de Pagamento é irreversivel\nConfirma a operação ?", descricao);
                if (MessageBox.Show(menssagem, "Demo ECF - ACBrFramework.NET", MessageBoxButtons.YesNo).Equals(DialogResult.No))
                    return;

                acbrECF.ProgramaFormaPagamento(descricao, vinculado);
                menssagem = string.Format("A Forma de Pagamento: {0} foi programada. Vinculado = {1}", descricao, vinculado);
                WriteResp(menssagem);
            }
            catch (Exception exception)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = exception.Message;
            }
        }

        private void ConfigurarSerial()
        {
            using (SerialCFGForm CFG = new SerialCFGForm())
            {
                CFG.Device = acbrECF.Device;
                CFG.ShowDialog();
            }
        }

		private void WriteResp(string resp)
		{
			if (string.IsNullOrEmpty(resp)) return;

			foreach (string line in resp.Split('\n'))
			{
				lstResp.Items.Add(line);
			}
			lstResp.Items.Add("+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
			lstResp.Items.Add("");
			lstResp.SelectedIndex = lstResp.Items.Count - 1;
		}

		private void WriteCmd(string resp)
		{
			if (string.IsNullOrEmpty(resp)) return;

			foreach (string line in resp.Split('\n'))
			{
				lstCMD.Items.Add(line);
			}
			lstCMD.Items.Add("+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
			lstCMD.Items.Add("");
			lstCMD.SelectedIndex = lstCMD.Items.Count - 1;
		}

		#endregion ECF

		#endregion Methods

		#region Event Handlers

        #region Eventos

        private void acbrAAC_OnGetChave(object sender, ChaveEventArgs e)
        {
            e.Chave = "-----BEGIN RSA PRIVATE KEY-----" + Environment.NewLine +
                       "MIICXwIBAAKBgQC+TZjfcw/a/SovoqQPOW5bbKn4CQw4DeZJA3Y9vJrYHKN4aCQv" + Environment.NewLine +
                       "z0i3AG9kGdsTSZdZ/clh4xv6tUwPsBdZJHrm21gH7wN/zKLTvXbs+i3x7U00ElCB" + Environment.NewLine +
                       "YyZ8BOXJWVMuye0UvSz7p4JwSopugzbjaImIGy+5LvgcjUCn3OZzWpwYWQIDAQAB" + Environment.NewLine +
                       "AoGBAKAycEtB8An37ghVkGfkf7rkmZxb+XZCdSXnjSThXTQpv46/lB7PDrZG3n5U" + Environment.NewLine +
                       "qa/t1kQCOQF3DnmZHqNiJ/V5mR7ApbciQj4WYVLkMCgltru3MmzIUQ9IiLtAgaCv" + Environment.NewLine +
                       "uHc0MAzt/OWgQ93uFnLf4ubp4+2PTHiiIChv2m78s605wX2lAkEA+3pPsPdXcaOe" + Environment.NewLine +
                       "7T7C4hn1qg93ksN96UutB1APF3YAjWVWuPwzZv4hExiMPc0uKvVK2H3tP4P5CkM5" + Environment.NewLine +
                       "YMIEGEkF2wJBAMG5qmoYksz+MFZ2cd7gt68mf3Oq9F59qkHHcoV+1ttXx5pfzwat" + Environment.NewLine +
                       "kelhKkN+LV1XsgS0bGAKu2NitOMBUAcnItsCQQCEJxqJ3PFO/rUd58VyHEJFRCuK" + Environment.NewLine +
                       "LMGWP/aFyUSlB5XyuDaCr8YzcYjgCB5qu9BvMshKTKLIpgnRotIcTtjoCjfRAkEA" + Environment.NewLine +
                       "tsqHn+Bb9A0McykDvPdwmlXLAMsYFWihk7urtYa/GOw0rNcmMvjnqrxB8rlF+MNc" + Environment.NewLine +
                       "d8/+SokV02s5ntCIQJeO7QJBAKp2BCOIck+uhMPDiw/1788yQLD6mVb/pBzClzBn" + Environment.NewLine +
                       "pTMAFPGJG2fO4YJn/pUHdtDtSenX8TibWve+gY6oFCFw/Ts=" + Environment.NewLine +
                       "-----END RSA PRIVATE KEY-----";
        }

        private void acbrECF_OnBobinaAdicionaLinhas(object sender, BobinaEventArgs e)
        {
            bobina.Append(e.Linhas);
            wbBobina.Navigate("about:blank");
            HtmlDocument doc = wbBobina.Document;
            doc.Write(string.Format("<HTML><head><meta charset=\"iso-8859-1\"></head><body>{0}</body></HTML>", bobina));
            wbBobina.Refresh();
        }

        #endregion Eventos

        #region Botões

        private void ativarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ativar();
		}

		private void desativarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Desativar();
		}               

		private void testarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Testar();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_Estado();
		}

		private void dataHoraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_DataHora();
		}

		private void numECFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_NumECF();
		}

		private void numLojaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_NumLoja();
		}

		private void numSérieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_NumSerie();
		}

		private void numVersãoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_NumVersao();
		}

		private void cNPJToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_CNPJ();
		}

		private void iEToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_IE();
		}

		private void pAFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_PAF();
		}

		private void lerTodasAsVariáveisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Ler_TodasVariaveis();
		}

		private void leituraXToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LeituraX();
		}

		private void reToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReducaoZ();
		}

		private void leituraMemóriaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (LeituraMemoriaFiscal form = new LeituraMemoriaFiscal())
			{
				var ret = form.ShowDialog();
				if (ret == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						if (form.ByPeriod)
						{
							this.acbrECF.LeituraMemoriaFiscal(form.InitialDate, form.FinalDate, form.Simple);
						}
						else
						{
							this.acbrECF.LeituraMemoriaFiscal(form.InitialCCR, form.FinalCCR, form.Simple);
						}

						WriteResp("LeituraMemoriaFiscal OK");
					}
					catch (NullReferenceException)
					{
						messageToolStripStatusLabel.Text = "Não inicializado.";
						descriptionToolStripStatusLabel.Text = string.Empty;
					}
					catch (Exception exception)
					{
						messageToolStripStatusLabel.Text = "Exception";
						descriptionToolStripStatusLabel.Text = exception.Message;
					}
				}
			}
		}

		private void leituraMemóriaFiscalSerialToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (LeituraMemoriaFiscal form = new LeituraMemoriaFiscal())
			{
				var ret = form.ShowDialog();
				if (ret == System.Windows.Forms.DialogResult.OK)
				{
					string result;

					try
					{
						if (form.ByPeriod)
						{
							result = this.acbrECF.LeituraMemoriaFiscalSerial(form.InitialDate, form.FinalDate, form.Simple);
						}
						else
						{
							result = this.acbrECF.LeituraMemoriaFiscalSerial(form.InitialCCR, form.FinalCCR, form.Simple);
						}

						WriteResp(result);
					}
					catch (NullReferenceException)
					{
						messageToolStripStatusLabel.Text = "Não inicializado.";
						descriptionToolStripStatusLabel.Text = string.Empty;
					}
					catch (Exception exception)
					{
						messageToolStripStatusLabel.Text = "Exception";
						descriptionToolStripStatusLabel.Text = exception.Message;
					}
				}
			}
		}

		private void leituraMemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (LeituraMemoriaFiscalPAF form = new LeituraMemoriaFiscalPAF())
			{
				var ret = form.ShowDialog();
				if (ret == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						if (form.ByPeriod)
						{
							if (form.Simple)
							{
								if (form.Imprimir)
									acbrECF.PafMF_LMFS_Impressao(form.InitialDate, form.FinalDate);
								else if (form.SalvarEspelho)
									acbrECF.PafMF_LMFS_Espelho(form.InitialDate, form.FinalDate, form.Caminho);
							}
							else
							{
								if (form.Imprimir)
									acbrECF.PafMF_LMFC_Impressao(form.InitialDate, form.FinalDate);
								else if (form.SalvarCotepe1704)
									acbrECF.PafMF_LMFC_Cotepe1704(form.InitialDate, form.FinalDate, form.Caminho);
								else if (form.SalvarEspelho)
									acbrECF.PafMF_LMFC_Espelho(form.InitialDate, form.FinalDate, form.Caminho);
							}
						}
						else
						{
							if (form.Simple)
							{
								if (form.Imprimir)
									acbrECF.PafMF_LMFS_Impressao(form.InitialCCR, form.FinalCCR);
								else if (form.SalvarEspelho)
									acbrECF.PafMF_LMFS_Espelho(form.InitialCCR, form.FinalCCR, form.Caminho);
							}
							else
							{
								if (form.Imprimir)
									acbrECF.PafMF_LMFC_Impressao(form.InitialCCR, form.FinalCCR);
								else if (form.SalvarCotepe1704)
									acbrECF.PafMF_LMFC_Cotepe1704(form.InitialCCR, form.FinalCCR, form.Caminho);
								else if (form.SalvarEspelho)
									acbrECF.PafMF_LMFC_Espelho(form.InitialCCR, form.FinalCCR, form.Caminho);
							}
						}

						WriteResp("LeituraMemoriaFiscal PAF OK");
					}
					catch (NullReferenceException)
					{
						messageToolStripStatusLabel.Text = "Não inicializado.";
						descriptionToolStripStatusLabel.Text = string.Empty;
					}
					catch (Exception exception)
					{
						messageToolStripStatusLabel.Text = "Exception";
						descriptionToolStripStatusLabel.Text = exception.Message;
					}
				}
			}
		}

		private void identificaPAFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (IdentificaPAF form = new IdentificaPAF())
			{
				var ret = form.ShowDialog();
				if (ret == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						acbrECF.IdentificaPAF(form.Linha1, form.Linha2);
						WriteResp("Identifica PAF: " + form.Linha1);
					}
					catch (NullReferenceException)
					{
						messageToolStripStatusLabel.Text = "Não inicializado.";
						descriptionToolStripStatusLabel.Text = string.Empty;
					}
					catch (Exception exception)
					{
						messageToolStripStatusLabel.Text = "Exception";
						descriptionToolStripStatusLabel.Text = exception.Message;
					}
				}
			}
		}

		private void aacAbrirArquivoButton_Click(object sender, EventArgs e)
		{
			CarregarAAC();
		}

		private void aacGravarArquivoButton_Click(object sender, EventArgs e)
		{
			RecriarAAC();
		}

		private void accVisualizarArquivoButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(aacNomeArquivoTextbox.Text))
			{
				System.Diagnostics.Process.Start(aacNomeArquivoTextbox.Text);
			}
		}

		private void aacRemoverECFAutorizadaButton_Click(object sender, EventArgs e)
		{
			if (aacECFsAutorizadaDataGridView.SelectedRows.Count > 0)
			{
				aacECFsAutorizadaDataGridView.Rows.Remove(aacECFsAutorizadaDataGridView.SelectedRows[0]);
			}
		}

		private void aacAdicionarECFAutorizadaButton_Click(object sender, EventArgs e)
		{
			if (aacNumSerieECFAutorizadaTextBox.Text == "" || aacCROECFAutorizadaTextBox.Text == "" || aacGrandTotalECFAutorizadaTextBox.Text == "" || aacCNIECFAutorizadaTextBox.Text == "")
			{
				MessageBox.Show("Preencha corretamente os valores do ECF a ser autorizado");
			}
			else
			{
				aacECFsAutorizadaDataGridView.Rows.Add(aacNumSerieECFAutorizadaTextBox.Text, aacCROECFAutorizadaTextBox.Text, aacCNIECFAutorizadaTextBox.Text, aacGrandTotalECFAutorizadaTextBox.Text);
				aacNumSerieECFAutorizadaTextBox.Text = "";
				aacCROECFAutorizadaTextBox.Text = "";
				aacGrandTotalECFAutorizadaTextBox.Text = "";
				aacCNIECFAutorizadaTextBox.Text = "";
			}
		}

		private void aacVerificarGTAutorizadaButton_Click(object sender, EventArgs e)
		{
			if (aacECFsAutorizadaDataGridView.SelectedRows.Count > 0)
			{
				if (aacNomeArquivoTextbox.Text != "")
				{
					acbrAAC.NomeArquivoAuxiliar = aacNomeArquivoTextbox.Text;

					string numSerie = aacECFsAutorizadaDataGridView.SelectedRows[0].Cells["numSerieColumn"].Value.ToString();
					decimal grandeTotal = Convert.ToDecimal(aacECFsAutorizadaDataGridView.SelectedRows[0].Cells["valorGTColumn"].Value);

					int retorno = acbrAAC.VerificarGTECF(numSerie, ref grandeTotal);

					if (retorno == 0)
					{
						MessageBox.Show("Os valores estão conferindo. Operação realizada com êxito");
					}
					else
					{
						MessageBox.Show("Os valores nao conferem");
					}
				}
				else
				{
					MessageBox.Show("Coloque o nome do arquivo");
				}
			}
		}

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            programaFormaPagamento();
        }

        private void btnSerial_Click(object sender, EventArgs e)
        {
            ConfigurarSerial();
        }

        #endregion Botões        

        #region Checkbox

        private void usarAACCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (usarAACCheckBox.Checked)
            {
                acbrECF.AAC = acbrAAC;
            }
            else
            {
                acbrECF.AAC = null;
            }
        }

        private void ativarCheckButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ativarCheckButton.Checked)
            {
                Ativar();
            }
            else
            {
                Desativar();
            }
        }

        #endregion Checkbox

        #region NumericUpDown

        private void nupMaxLinhasBuffer_ValueChanged(object sender, EventArgs e)
        {
            acbrECF.MaxLinhasBuffer = Convert.ToInt32(nupMaxLinhasBuffer.Value);
        }

        private void nupPaginaCodigo_ValueChanged(object sender, EventArgs e)
        {
            acbrECF.PaginaDeCodigo = Convert.ToInt32(nupPaginaCodigo.Value);
        }

        #endregion NumericUpDown      

        #endregion Event Handlers
    }
}