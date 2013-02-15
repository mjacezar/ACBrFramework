using ACBrFramework.Sped;
using System;
using System.IO;
using System.Windows.Forms;

namespace ACBrFramework.Net.SpedFiscalTeste
{
	public partial class FrmSPEDFiscal : Form
	{
		#region Fields

		/// Código da Situação Tributária referente ao IPI.
		private const string ipiEntradaRecuperacaoCredito = "00"; // Entrada com recuperação de crédito

		private const string ipiEntradaTributradaZero = "01"; // Entrada tributada com alíquota zero
		private const string ipiEntradaIsenta = "02"; // Entrada isenta
		private const string ipiEntradaNaoTributada = "03"; // Entrada não-tributada
		private const string ipiEntradaImune = "04"; // Entrada imune
		private const string ipiEntradaComSuspensao = "05"; // Entrada com suspensão
		private const string ipiOutrasEntradas = "49"; // Outras entradas
		private const string ipiSaidaTributada = "50"; // Saída tributada
		private const string ipiSaidaTributadaZero = "51"; // Saída tributada com alíquota zero
		private const string ipiSaidaIsenta = "52"; // Saída isenta
		private const string ipiSaidaNaoTributada = "53"; // Saída não-tributada
		private const string ipiSaidaImune = "54"; // Saída imune
		private const string ipiSaidaComSuspensao = "55"; // Saída com suspensão
		private const string ipiOutrasSaidas = "99"; // Outras saídas

		/// Código da Situação Tributária referente ao PIS.
		private const string pisValorAliquotaNormal = "01"; // Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo)).

		private const string pisValorAliquotaDiferenciada = "02"; // Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada)).
		private const string pisQtdeAliquotaUnidade = "03"; // Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto).
		private const string pisMonofaticaAliquotaZero = "04"; // Operação Tributável (tributação monofásica (alíquota zero)).
		private const string pisAliquotaZero = "06"; // Operação Tributável (alíquota zero).
		private const string pisIsentaContribuicao = "07"; // Operação Isenta da Contribuição.
		private const string pisSemIncidenciaContribuicao = "08"; // Operação Sem Incidência da Contribuição.
		private const string pisSuspensaoContribuicao = "09"; // Operação com Suspensão da Contribuição.
		private const string pisOutrasOperacoes = "99"; // Outras Operações,

		/// Código da Situação Tributária referente ao COFINS.
		private const string cofinsValorAliquotaNormal = "01"; // Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo)).

		private const string cofinsValorAliquotaDiferenciada = "02"; // Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada)).
		private const string cofinsQtdeAliquotaUnidade = "03"; // Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto).
		private const string cofinsMonofaticaAliquotaZero = "04"; // Operação Tributável (tributação monofásica (alíquota zero)).
		private const string cofinsAliquotaZero = "06"; // Operação Tributável (alíquota zero).
		private const string cofinsIsentaContribuicao = "07"; // Operação Isenta da Contribuição.
		private const string cofinsSemIncidenciaContribuicao = "08"; // Operação Sem Incidência da Contribuição.
		private const string cofinsSuspensaoContribuicao = "09"; // Operação com Suspensão da Contribuição.
		private const string cofinsOutrasOperacoes = "99"; // Outras Operações,

		#endregion Fields

		#region Constructor

		public FrmSPEDFiscal()
		{
			InitializeComponent();
		}

		#endregion Constructor

		#region Methods

		#region EventHandlers

		private void btnTXT_Click(object sender, EventArgs e)
		{
			btnTXT.Enabled = false;
			ACBrSPEDFiscal1.LinhasBuffer = Convert.ToInt32(edBufLinhas.Text);
			ACBrSPEDFiscal1.DT_INI = Convert.ToDateTime("01/11/2011");
			ACBrSPEDFiscal1.DT_FIN = Convert.ToDateTime("30/11/2011");

			// Limpa a lista de erros.
			memoError.Text = null;

			// Informa o pata onde será salvo o arquivo TXT.
//			ACBrSPEDFiscal1.Path = @".\NovaPasta\";

			// Método que gera o arquivo TXT.
			ACBrSPEDFiscal1.SaveFileTXT();

			// Carrega o arquivo TXT no memo.
			LoadToMemo();

			// Habilita os botões
			btnB_0.Enabled = true;
			btnTXT.Enabled = true;
			cbConcomitante.Enabled = true;
		}

		private void btnError_Click(object sender, EventArgs e)
		{
			ACBrSPEDFiscal1.DT_INI = Convert.ToDateTime("01/07/2011");
			ACBrSPEDFiscal1.DT_FIN = Convert.ToDateTime("01/07/2011");

			// Limpa a lista de erros.
			memoError.Text = null;

			// Método que gera o arquivo TXT.
			ACBrSPEDFiscal1.SaveFileTXT();

			// Habilita os botões
			btnB_0.Enabled = true;
			btnB_1.Enabled = true;
			btnB_C.Enabled = true;
			btnB_D.Enabled = true;
			btnB_E.Enabled = true;
			btnB_H.Enabled = true;
		}

		private void btnB_Completo_Click(object sender, EventArgs e)
		{
			CriaBloco0();
			CriaBlocoC();
			CriaBlocoD();
			CriaBlocoE();
			CriaBlocoG();
			CriaBlocoH();
			CriaBloco1();
		}

		private void btnB_0_Click(object sender, EventArgs e)
		{
			CriaBloco0();
		}

		private void btnB_9_Click(object sender, EventArgs e)
		{
			CriaBloco9();
		}

		private void btnB_1_Click(object sender, EventArgs e)
		{
			CriaBloco1();
		}

		private void btnB_C_Click(object sender, EventArgs e)
		{
			CriaBlocoC();
		}

		private void btnB_D_Click(object sender, EventArgs e)
		{
			CriaBlocoD();
		}

		private void btnB_E_Click(object sender, EventArgs e)
		{
			CriaBlocoE();
		}

		private void btnB_G_Click(object sender, EventArgs e)
		{

			CriaBlocoG();
		}

		private void btnB_H_Click(object sender, EventArgs e)
		{
			CriaBlocoH();
		}

		private void edtFile_Changed(object sender, EventArgs e)
		{
			ACBrSPEDFiscal1.Arquivo = edtFile.Text;
		}

		#endregion EventHandlers

		private void cbConcomitante_Click(object sender, EventArgs e)
		{
		}

		private void ACBrSPEDFiscal1_OnError(object sender, ACBrFramework.Sped.ErrorEventArgs e)
		{
			if (!string.IsNullOrEmpty(memoError.Text))
			{
				memoError.Text += Environment.NewLine;
			}

			memoError.Text += e.MsgErro;
		}

		#endregion EventHandlers

		private void CriaBloco0()
		{
			string[] strUNID = { "PC", "UN", "LT", "PC", "MT" };
			int int0150;
			int int0175;
			int int0300;
			int int0190;
			int int0500;
			int int0600;

			// Alimenta o componente com informações para gerar todos os registros do
			// Bloco 0.
			cbConcomitante.Enabled = false;
			btnB_0.Enabled = false;
			btnB_C.Enabled = true;

			// Definindo
			ACBrSPEDFiscal1.DT_INI = Convert.ToDateTime("01/11/2011");
			ACBrSPEDFiscal1.DT_FIN = Convert.ToDateTime("30/11/2011");

			if (cbConcomitante.Checked)
			{
				ACBrSPEDFiscal1.LinhasBuffer = Convert.ToInt32(edBufLinhas.Text);

				//ACBrSPEDFiscal1.IniciaGeracao;
				LoadToMemo();
			}

			var bloco0 = ACBrSPEDFiscal1.Bloco_0;

			// Dados da Empresa
			var registro0000 = bloco0.Registro0000;
			registro0000.COD_VER = VersaoLeiaute.Versao103;
			registro0000.COD_FIN = CodFinalidade.Original;
			registro0000.NOME = "RAZÃO SOCIAL DA EMPRESA EMITENTE";
			registro0000.CNPJ = "11111111111180";
			registro0000.CPF = "";
			registro0000.UF = "RS";
			registro0000.IE = "1111111119";
			registro0000.COD_MUN = 4314902;
			registro0000.IM = "";
			registro0000.SUFRAMA = "";
			registro0000.IND_PERFIL = Perfil.PerfilA;
			registro0000.IND_ATIV = Atividade.Outros;

			var registro0001 = bloco0.Registro0001;
			registro0001.IND_MOV = IndicadorMovimento.ComDados;

			// FILHO - Dados complementares da Empresa
			var registro0005 = registro0001.Registro0005;
			registro0005.FANTASIA = "NOME FANTASSIA";
			registro0005.CEP = "29900000";
			registro0005.ENDERECO = "ENDEREÇO DA EMPRESA";
			registro0005.NUM = "S/N";
			registro0005.COMPL = "";
			registro0005.BAIRRO = "BAIRRO";
			registro0005.FONE = "";
			registro0005.FAX = "";
			registro0005.EMAIL = "171@171.COM.BR";

			//registro0001.Registro0015.Add(new Registro0015() { IE_ST = "254504230", UF_ST = "SC" });

			// FILHO - Dados do contador.
			var registro0100 = registro0001.Registro0100;
			registro0100.NOME = "SO CONFIE NO CONTADOR I";
			registro0100.CPF = "12345678909";

			// Deve ser uma informação valida
			registro0100.CRC = "65924";
			registro0100.CNPJ = "";
			registro0100.CEP = "92420020";
			registro0100.ENDERECO = "R. NOME DA RUA";
			registro0100.NUM = "450";
			registro0100.COMPL = "";
			registro0100.BAIRRO = "BAIRRO CONTADORES";
			registro0100.FONE = "";
			registro0100.FAX = "";
			registro0100.EMAIL = "NOME@NOME.COM.BR";
			registro0100.COD_MUN = 3200607;

			// Check(Reg0001.Registro0190.LocalizaRegistro(UNID), '(0-0190) UNIDADE MEDIDA: A unidade de medida "%s" foi duplicada na lista de registros 0190!', [UNID]);
			// FILHO
			for (int0150 = 1; int0150 <= 10; int0150++)
			{
				// 10 Clientes
				var registro0150 = new Registro0150();
				registro0150.COD_PART = (int0150).ToString();
				registro0150.NOME = "CLIENTE DE TESTES " + (int0150).ToString();
				registro0150.COD_PAIS = "1058";
				registro0150.CNPJ = "11111111111180";
				registro0150.CPF = "12345678909";
				registro0150.IE = "";
				registro0150.COD_MUN = 43140070 + int0150;
				registro0150.SUFRAMA = "";
				registro0150.ENDERECO = "ENDERECO CLIENTE" + (int0150).ToString();
				registro0150.NUM = "";
				registro0150.COMPL = "COMPLEMENTO" + (int0150).ToString();
				registro0150.BAIRRO = "BAIRRO CLIENTE" + (int0150).ToString();

				// FILHO - 1 Alteração para cada cliente de 2 a 3
				if ((int0150 == 2) || (int0150 == 3))
				{
					var registro0175 = new Registro0175();
					registro0175.DT_ALT = bloco0.DT_INI.AddDays(1);
					registro0175.NR_CAMPO = "1";
					registro0175.CONT_ANT = "CAMPO ANTERIOR " + '1';

					registro0150.Registro0175.Add(registro0175);
				}

				registro0001.Registro0150.Add(registro0150);
			}

			// FILHO
			// 4 Unidades de medida
			// Const strUNID, esta declarada no inicio deste evento.
			for (int0190 = strUNID.GetLowerBound(0); int0190 <= strUNID.GetUpperBound(0); int0190++)
			{
				//@ Unsupported property or method(B): 'LocalizaRegistro'
				//if(!registro0001.Registro0190.LocalizaRegistro(strUNID[int0190])
				{
					var registro0190 = new Registro0190();
					registro0190.UNID = strUNID[int0190];
					registro0190.DESCR = "Descricao " + strUNID[int0190];

					registro0001.Registro0190.Add(registro0190);
				}
			}

			var registro0200 = new Registro0200();
			registro0200.COD_ITEM = "000001";
			registro0200.DESCR_ITEM = "PRODUTO 1";
			registro0200.COD_BARRA = "";
			registro0200.UNID_INV = "UN";
			registro0200.TIPO_ITEM = TipoItem.MercadoriaRevenda;
			registro0200.COD_NCM = "30049026";
			registro0200.COD_GEN = "30";
			registro0200.ALIQ_ICMS = 17.00M;
			registro0001.Registro0200.Add(registro0200);

			// REGISTRO 0206: CÓDIGO DE PRODUTO CONFORME TABELA PUBLICADA PELA ANP (COMBUSTÍVEIS)
			// With Registro0206New do
			// begin
			// COD_COMB := '910101001';
			// end;

			// FILHO
			for (int0300 = 1; int0300 <= 10; int0300++)
			{
				// 10 Bens Imobilizados

				var registro0300 = new Registro0300();
				registro0300.COD_IND_BEM = string.Format("{0:000000}", int0300);
				registro0300.IDENT_MERC = 1;
				registro0300.DESCR_ITEM = "DESCRIÇÃO DO ITEM";
				registro0300.COD_PRNC = "";
				registro0300.COD_CTA = "";
				registro0300.NR_PARC = 10;

				// FILHO
				var registro0305 = new Registro0305();
				registro0305.COD_CCUS = "1";
				registro0305.VIDA_UTIL = 60;
				registro0300.Registro0305.Add(registro0305);

				registro0001.Registro0300.Add(registro0300);
			}

			var registro0400 = new Registro0400();
			registro0400.COD_NAT = "12020";
			registro0400.DESCR_NAT = "DESCRIÇÃO DA NATUREZA DE OPERAÇÃO 12020";
			registro0001.Registro0400.Add(registro0400);

			var registro0450 = new Registro0450();
			registro0450.COD_INF = "000001";
			registro0450.TXT = "INFORMAÇÃO COMPLEMENTAR DO DOCUMENTO FISCAL";
			registro0001.Registro0450.Add(registro0450);

			var registro0460 = new Registro0460();
			registro0460.COD_OBS = "000001";
			registro0460.TXT = "TEXTO DE OBSERVAÇÃO DO DOCUMENTO FISCAL ";
			registro0001.Registro0460.Add(registro0460);

			for (int0500 = 1; int0500 <= 10; int0500++)
			{
				var registro0500 = new Registro0500();
				registro0500.DT_ALT = Convert.ToDateTime("30/11/2011");
				registro0500.COD_NAT_CC = "01";
				registro0500.IND_CTA = "A";
				registro0500.NIVEL = "1";
				registro0500.COD_CTA = int0500.ToString();
				registro0500.NOME_CTA = string.Format("CONTA CONTÁBIL {0}", int0500);

				registro0001.Registro0500.Add(registro0500);
			}

			for (int0600 = 1; int0600 <= 10; int0600++)
			{
				var registro0600 = new Registro0600();
				registro0600.DT_ALT = Convert.ToDateTime("30/11/2011");
				registro0600.COD_CCUS = (int0600).ToString();
				registro0600.CCUS = string.Format("CENTRO DE CUSTOS {0}", int0600);

				registro0001.Registro0600.Add(registro0600);
			}

			if (cbConcomitante.Checked)
			{
				//@ Unsupported property or method(C): 'WriteBloco_0'
				//ACBrSPEDFiscal1.WriteBloco_0;
				LoadToMemo();
			}
		}

		private void CriaBloco9()
		{
			btnB_9.Enabled = false;

			//@ Unsupported property or method(C): 'WriteBloco_9'
			//ACBrSPEDFiscal1.WriteBloco_9;
			LoadToMemo();

			// Habilita os botões
			btnB_0.Enabled = true;
			btnB_1.Enabled = true;
			btnB_C.Enabled = true;
			btnB_D.Enabled = true;
			btnB_E.Enabled = true;
			btnB_G.Enabled = true;
			btnB_H.Enabled = true;
			cbConcomitante.Enabled = true;
		}

		private void CriaBloco1()
		{
			btnB_1.Enabled = false;
			btnB_9.Enabled = cbConcomitante.Checked;

			// Alimenta o componente com informações para gerar todos os registros do Bloco 1.
			var bloco1 = ACBrSPEDFiscal1.Bloco_1;

			var registro1001 = bloco1.Registro1001;
			registro1001.IND_MOV = IndicadorMovimento.SemDados;

			if (cbConcomitante.Checked)
			{
				//@ Unsupported property or method(C): 'WriteBloco_1'
				//ACBrSPEDFiscal1.WriteBloco_1;
				LoadToMemo();
			}
		}

		private void CriaBlocoC()
		{
			int INotas;
			int IItens;
			int NNotas;
			int BNotas;

			// Alimenta o componente com informações para gerar todos os registros do
			// Bloco C.
			btnB_C.Enabled = false;
			btnB_D.Enabled = true;
			NNotas = Convert.ToInt32(edNotas.Text);
			BNotas = Convert.ToInt32(edBufNotas.Text);

			ProgressBar1.Visible = cbConcomitante.Checked;
			ProgressBar1.Maximum = NNotas;
			ProgressBar1.Value = 0;

			var blocoC = ACBrSPEDFiscal1.Bloco_C;
			var registroC001 = blocoC.RegistroC001;
			registroC001.IND_MOV = IndicadorMovimento.ComDados;

			for (INotas = 1; INotas <= NNotas; INotas++)
			{
				var registroC100 = new RegistroC100();
				registroC100.IND_OPER = TipoOperacao.EntradaAquisicao;
				registroC100.IND_EMIT = Emitente.EmissaoPropria;
				registroC100.COD_PART = "001";
				registroC100.COD_MOD = "";
				registroC100.COD_SIT = SituacaoDocto.Regular;
				registroC100.SER = "";
				registroC100.NUM_DOC = string.Format("11{0:000000}", INotas);
				registroC100.CHV_NFE = "";
				registroC100.DT_DOC = blocoC.DT_INI.AddDays(INotas);
				registroC100.DT_E_S = blocoC.DT_INI.AddDays(INotas);
				registroC100.VL_DOC = 0;
				registroC100.IND_PGTO = TipoPagamento.SemPagamento;
				registroC100.VL_DESC = 0;
				registroC100.VL_ABAT_NT = 0;
				registroC100.VL_MERC = 0;
				registroC100.IND_FRT = TipoFrete.SemCobrancaFrete;
				registroC100.VL_SEG = 0;
				registroC100.VL_OUT_DA = 0;
				registroC100.VL_BC_ICMS = 0;
				registroC100.VL_ICMS = 0;
				registroC100.VL_BC_ICMS_ST = 0;
				registroC100.VL_ICMS_ST = 0;
				registroC100.VL_IPI = 0;
				registroC100.VL_PIS = 0;
				registroC100.VL_COFINS = 0;
				registroC100.VL_PIS_ST = 0;
				registroC100.VL_COFINS_ST = 0;
				registroC001.RegistroC100.Add(registroC100);

				// Gera registros específicos para notas emitidas por terceiros
				if (registroC100.IND_EMIT == Emitente.Terceiros)
				{
					var registroC110 = new RegistroC110();
					registroC110.COD_INF = "000001";
					registroC110.TXT_COMPL = "";
					registroC100.RegistroC110.Add(registroC110);
				}

				// Gera o registro de importação apenas para notas de entrada
				if (registroC100.IND_OPER == TipoOperacao.EntradaAquisicao)
				{
					var registroC120 = new RegistroC120();
					registroC120.COD_DOC_IMP = DoctoImporta.SimplificadaImport;
					registroC120.NUM_DOC__IMP = "1024879531";
					registroC120.PIS_IMP = 0.00M;
					registroC120.COFINS_IMP = 0.00M;
					registroC120.NUM_ACDRAW = "";

					registroC100.RegistroC120.Add(registroC120);
				}

				// Gera registros específicos para notas emitidas por terceiros e de prestação
				if ((registroC100.IND_EMIT == Emitente.Terceiros) && (registroC100.IND_OPER == TipoOperacao.SaidaPrestacao))
				{
					var registroC130 = new RegistroC130();
					registroC130.VL_SERV_NT = 10.12M;
					registroC130.VL_BC_ISSQN = 10.12M;
					registroC130.VL_ISSQN = 10.12M;
					registroC130.VL_BC_IRRF = 10.12M;
					registroC130.VL_IRRF = 10.12M;
					registroC130.VL_BC_PREV = 10.12M;
					registroC130.VL_PREV = 10.12M;

					registroC100.RegistroC130.Add(registroC130);
				}

				// REGISTRO C170: ITENS DO DOCUMENTO (CÓDIGO 01, 1B, 04 e 55).
				for (IItens = 1; IItens <= 10; IItens++)
				{
					var registroC170 = new RegistroC170();

					// Inicio Adicionar os Itens:
					registroC170.NUM_ITEM = string.Format("{0:000}", IItens);
					registroC170.COD_ITEM = string.Format("{0:000000}", registroC170.NUM_ITEM);
					registroC170.DESCR_COMPL = string.Format("11{0:000000} ITEM {1}", INotas, registroC170.COD_ITEM);
					registroC170.QTD = 1;
					registroC170.UNID = "UN";
					registroC170.VL_ITEM = 0;
					registroC170.VL_DESC = 0;
					registroC170.IND_MOV = MovimentacaoFisica.Nao;
					registroC170.CST_ICMS = "001";
					registroC170.CFOP = "1252";
					registroC170.COD_NAT = "64";
					registroC170.VL_BC_ICMS = 0;
					registroC170.ALIQ_ICMS = 0;
					registroC170.VL_ICMS = 0;
					registroC170.VL_BC_ICMS_ST = 0;
					registroC170.ALIQ_ST = 0;
					registroC170.VL_ICMS_ST = 0;
					registroC170.IND_APUR = ApuracaoIPI.Mensal;
					registroC170.CST_IPI = ipiEntradaIsenta;
					registroC170.COD_ENQ = "";
					registroC170.VL_BC_IPI = 0;
					registroC170.ALIQ_IPI = 0;
					registroC170.VL_IPI = 0;
					registroC170.CST_PIS = pisOutrasOperacoes;
					registroC170.VL_BC_PIS = 0;
					registroC170.ALIQ_PIS_PERC = 0;
					registroC170.QUANT_BC_PIS = 0;
					registroC170.ALIQ_PIS_R = 0;
					registroC170.VL_PIS = 0;
					registroC170.CST_COFINS = cofinsOutrasOperacoes;
					registroC170.VL_BC_COFINS = 0;
					registroC170.ALIQ_COFINS_PERC = 0;
					registroC170.QUANT_BC_COFINS = 0;
					registroC170.ALIQ_COFINS_R = 0;
					registroC170.VL_COFINS = 0;
					registroC170.COD_CTA = "000";

					registroC100.RegistroC170.Add(registroC170);
				}

				// REGISTRO C170: ITENS DO DOCUMENTO (CÓDIGO 01, 1B, 04 e 55).
				for (IItens = 1; IItens <= 10; IItens++)
				{
					var registroC190 = new RegistroC190();
					registroC190.CST_ICMS = "040";
					registroC190.CFOP = "1252";
					registroC190.ALIQ_ICMS = 0;
					registroC190.VL_OPR = 0;
					registroC190.VL_BC_ICMS = 0;
					registroC190.VL_ICMS = 0;
					registroC190.VL_BC_ICMS_ST = 0;
					registroC190.VL_ICMS_ST = 0;
					registroC190.VL_RED_BC = 0;
					registroC190.VL_IPI = 0;
					registroC190.COD_OBS = "000";

					registroC100.RegistroC190.Add(registroC190);
				}
			}

			var registroC400 = new RegistroC400();

			registroC400.COD_MOD = "2D";
			registroC400.ECF_MOD = "DARUMA FS600";
			registroC400.ECF_FAB = "21098765432123456789";
			registroC400.ECF_CX = "001";

			registroC001.RegistroC400.Add(registroC400);

			var registroC405 = new RegistroC405();

			registroC405.DT_DOC = blocoC.DT_FIN;
			registroC405.CRO = 1;
			registroC405.CRZ = 1;
			registroC405.NUM_COO_FIN = 1;
			registroC405.GT_FIN = 100.00M;
			registroC405.VL_BRT = 100.00M;
			registroC400.RegistroC405.Add(registroC405);

			var registroC410 = new RegistroC410();
			registroC410.VL_PIS = 0.00M;
			registroC410.VL_COFINS = 0.00M;
			registroC405.RegistroC410.Add(registroC410);

			var registroC420 = new RegistroC420();

			registroC420.COD_TOT_PAR = "T1700";
			registroC420.VLR_ACUM_TOT = 100.00M;
			registroC420.NR_TOT = 1;
			registroC420.DESCR_NR_TOT = "TOTALIZADOR T1700";
			registroC405.RegistroC420.Add(registroC420);

			//Gera este registro somente para empresas do pergil B de apresentação
			if (ACBrSPEDFiscal1.Bloco_0.Registro0000.IND_PERFIL == Perfil.PerfilB)
			{
				var registroC425 = new RegistroC425();
				registroC425.COD_ITEM = "000001";
				registroC425.QTD = 1;
				registroC425.UNID = "PC";
				registroC425.VL_ITEM = 100.00M;
				registroC425.VL_PIS = 0.00M;
				registroC425.VL_COFINS = 0.00M;
				registroC420.RegistroC425.Add(registroC425);
			}

			if (ACBrSPEDFiscal1.Bloco_0.Registro0000.IND_PERFIL != Perfil.PerfilB)
			{
				var registroC460 = new RegistroC460();
				registroC460.COD_MOD = "2D";
				registroC460.COD_SIT = SituacaoDocto.Regular;
				registroC460.NUM_DOC = "000001";
				registroC460.DT_DOC = Convert.ToDateTime("30/11/2011");
				registroC460.VL_DOC = 100.00M;
				registroC460.VL_PIS = 0.00M;
				registroC460.VL_COFINS = 0.00M;
				registroC460.CPF_CNPJ = "33333333333";
				registroC460.NOM_ADQ = "TESTE";
				registroC405.RegistroC460.Add(registroC460);

				var registroC470 = new RegistroC470();
				registroC470.COD_ITEM = "000001";
				registroC470.QTD = 1;
				registroC470.QTD_CANC = 0;
				registroC470.UNID = "UN";
				registroC470.VL_ITEM = 100.00m;
				registroC470.CST_ICMS = "000";
				registroC470.CFOP = "5102";
				registroC470.ALIQ_ICMS = 17.00m;
				registroC470.VL_PIS = 0.00m;
				registroC470.VL_COFINS = 0.00m;
				registroC460.RegistroC470.Add(registroC470);
			}

			var registroC490 = new RegistroC490();

			registroC490.CST_ICMS = "000";
			registroC490.CFOP = "5102";
			registroC490.ALIQ_ICMS = 17.00M;
			registroC490.VL_OPR = 100.00M;
			registroC490.VL_BC_ICMS = 100.00M;
			registroC490.VL_ICMS = 17.00M;
			registroC490.COD_OBS = "000001";
			registroC405.RegistroC490.Add(registroC490);

			//Só envia este registro se o contribuinte for da BA
			if (ACBrSPEDFiscal1.Bloco_0.Registro0000.UF == "BA")
			{
				var registroC495 = new RegistroC495();

				registroC495.ALIQ_ICMS = 17.00M;
				registroC495.COD_ITEM = "000001";
				registroC495.QTD = 1.00M;
				registroC495.QTD_CANC = 0.00M;
				registroC495.UNID = "UN";
				registroC495.VL_ITEM = 100.00M;
				registroC495.VL_DESC = 0.00M;
				registroC495.VL_CANC = 0.00M;
				registroC495.VL_ACMO = 0.00M;
				registroC495.VL_BC_ICMS = 100.00M;
				registroC495.VL_ICMS = 17.00M;
				registroC495.VL_ISEN = 0.00M;
				registroC495.VL_ICMS_ST = 0.00M;
			}
		}

		private void CriaBlocoD()
		{
			btnB_D.Enabled = false;
			btnB_E.Enabled = true;

			// Alimenta o componente com informações para gerar todos os registros do Bloco D.
			var blocoD = ACBrSPEDFiscal1.Bloco_D;
			var registroD001 = blocoD.RegistroD001;

			registroD001.IND_MOV = IndicadorMovimento.ComDados;

			var registroD100 = new RegistroD100();
			registroD100.IND_OPER = TipoOperacao.EntradaAquisicao;
			registroD100.IND_EMIT = Emitente.Terceiros;
			registroD100.COD_PART = "000001";
			registroD100.COD_MOD = "57";
			registroD100.COD_SIT = SituacaoDocto.Regular;
			registroD100.SER = "1";
			registroD100.NUM_DOC = "012345";
			registroD100.CHV_CTE = "";
			registroD100.DT_DOC = blocoD.DT_FIN.AddDays(1);
			registroD100.DT_A_P = blocoD.DT_FIN.AddDays(1);
			registroD100.TP_CT_e = "1";
			registroD100.VL_DOC = 100.00M;
			registroD100.VL_DESC = 0.00M;
			registroD100.IND_FRT = TipoFrete.PorContaEmitente;
			registroD100.VL_SERV = 100.00M;
			registroD100.VL_BC_ICMS = 100.00M;
			registroD100.VL_ICMS = 17.00M;
			registroD100.VL_NT = 10.10M;
			registroD100.COD_INF = "000001";
			registroD100.COD_CTA = "111";

			registroD001.RegistroD100.Add(registroD100);

			var registroD190 = new RegistroD190();

			registroD190.CST_ICMS = "000";
			registroD190.CFOP = "1252";
			registroD190.ALIQ_ICMS = 17.00M;
			registroD190.VL_OPR = 100.00M;
			registroD190.VL_BC_ICMS = 100.00M;
			registroD190.VL_ICMS = 17.00M;
			registroD190.VL_RED_BC = 0.00M;
			registroD190.COD_OBS = "000001";
			registroD100.RegistroD190.Add(registroD190);

			if (cbConcomitante.Checked)
			{
				//ACBrSPEDFiscal1.WriteBloco_D;
				LoadToMemo();
			}
		}

		private void CriaBlocoE()
		{
			string[] ESTADOS = new string[] { "RS", "SC" };

			// Alimenta o componente com informações para gerar todos os registros do Bloco E.
			btnB_E.Enabled = false;
			btnB_G.Enabled = true;

			var blocoE = ACBrSPEDFiscal1.Bloco_E;

			var registroE001 = blocoE.RegistroE001;

			registroE001.IND_MOV = IndicadorMovimento.ComDados;

			var registroE100 = new RegistroE100();
			registroE100.DT_INI = Convert.ToDateTime("01/11/2011");
			registroE100.DT_FIN = Convert.ToDateTime("30/11/2011");

			var registroE110 = registroE100.RegistroE110;
			registroE110.VL_TOT_DEBITOS = 17.00M;
			registroE110.VL_AJ_DEBITOS = 0.00M;
			registroE110.VL_TOT_AJ_DEBITOS = 0.00M;
			registroE110.VL_ESTORNOS_CRED = 0M;
			registroE110.VL_TOT_CREDITOS = 17.00M;
			registroE110.VL_AJ_CREDITOS = 0M;
			registroE110.VL_TOT_AJ_CREDITOS = 0M;
			registroE110.VL_ESTORNOS_DEB = 0M;
			registroE110.VL_SLD_CREDOR_ANT = 0M;
			registroE110.VL_SLD_APURADO = 0.00M;
			registroE110.VL_TOT_DED = 0.00M;
			registroE110.VL_ICMS_RECOLHER = 0.00M;
			registroE110.VL_SLD_CREDOR_TRANSPORTAR = 0M;
			registroE110.DEB_ESP = 0M;


			var registroE116New = new RegistroE116();

			registroE116New.COD_OR = "000";
			registroE116New.VL_OR = 0;
			registroE116New.DT_VCTO = DateTime.Now;
			registroE116New.COD_REC = "123";
			registroE116New.NUM_PROC = "10";
			registroE116New.IND_PROC = OrigemProcesso.Sefaz;
			registroE116New.PROC = "DESCRIÇÃO DO PROCESSO";
			registroE116New.TXT_COMPL = "";
			registroE116New.MES_REF = "112011";
			registroE110.RegistroE116.Add(registroE116New);

			// Gera um registro E200 e filhos para cada estado onde o contribuinte possui inscrição estadual
			for (int i = 0; i < ESTADOS.Length; i++)
			{
				var registroE200 = new RegistroE200();

				registroE200.DT_INI = Convert.ToDateTime("01/11/2011");
				registroE200.DT_FIN = Convert.ToDateTime("30/11/2011");
				registroE200.UF = ESTADOS[i];
				registroE001.RegistroE200.Add(registroE200);

				var registroE210 = new RegistroE210();

				registroE210.IND_MOV_ST = MovimentoST.SemOperacaoST;
				registroE210.VL_SLD_CRED_ANT_ST = 0;
				registroE210.VL_DEVOL_ST = 0;
				registroE210.VL_RESSARC_ST = 0;
				registroE210.VL_OUT_CRED_ST = 0;
				registroE210.VL_AJ_CREDITOS_ST = 0;
				registroE210.VL_SLD_DEV_ANT_ST = 0.00M;
				registroE210.VL_DEDUCOES_ST = 0;
				registroE210.VL_ICMS_RECOL_ST = 0.00M;
				registroE210.VL_SLD_CRED_ST_TRANSPORTAR = 0;
				registroE210.VL_OUT_DEB_ST = 0.00M;
				registroE210.DEB_ESP_ST = 0;
				registroE200.RegistroE210.Add(registroE210);

				var registroE250 = new RegistroE250();
				registroE250.COD_OR = "000";
				registroE250.VL_OR = 0;
				registroE250.DT_VCTO = DateTime.Now;
				registroE250.COD_REC = "123";
				registroE250.NUM_PROC = "1020304050";
				registroE250.IND_PROC = OrigemProcesso.Outros;
				registroE250.PROC = "DESCRIÇÃO RESUMIDA";
				registroE250.TXT_COMPL = "";
				registroE250.MES_REF = "112011";
				registroE210.RegistroE250.Add(registroE250);

				var registroE500 = new RegistroE500();

				registroE500.IND_APUR = ApuracaoIPI.Mensal;
				registroE500.DT_INI = Convert.ToDateTime("01/11/2011");
				registroE500.DT_FIN = Convert.ToDateTime("30/11/2011");
				registroE001.RegistroE500.Add(registroE500);

				var registroE510 = new RegistroE510();
				registroE510.CFOP = "5120";
				registroE510.CST_IPI = "50";
				registroE510.VL_CONT_IPI = 0;
				registroE510.VL_BC_IPI = 0;
				registroE510.VL_IPI = 0;
				registroE500.RegistroE510.Add(registroE510);

				var registroE520 = new RegistroE520();
				registroE520.VL_SD_ANT_IPI = 0;
				registroE520.VL_DEB_IPI = 0;
				registroE520.VL_CRED_IPI = 0;
				registroE520.VL_OD_IPI = 10.00M;
				registroE520.VL_OC_IPI = 0;
				registroE520.VL_SC_IPI = 0;
				registroE520.VL_SD_IPI = 10.00M;
				registroE500.RegistroE520.Add(registroE520);

				var registroE530 = new RegistroE530();
				registroE530.IND_AJ = TipoAjuste.Debito;
				registroE530.VL_AJ = 10;
				registroE530.COD_AJ = "001";
				registroE530.IND_DOC = OrigemDocto.Outros;
				registroE530.NUM_DOC = "123";
				registroE530.DESCR_AJ = "DESCRIÇÃO DETALHADA";
				registroE520.RegistroE530.Add(registroE530);
			}

			if (cbConcomitante.Checked)
			{
				//ACBrSPEDFiscal1.WriteBloco_E;
				LoadToMemo();
			}
		}

		private void CriaBlocoG()
		{
			btnB_G.Enabled = false;
			btnB_H.Enabled = true;

			// Alimenta o componente com informações para gerar todos os registros do Bloco G.
			var blocoG = ACBrSPEDFiscal1.Bloco_G;

			var registroG001 = blocoG.RegistroG001;

			registroG001.IND_MOV = IndicadorMovimento.ComDados;

			var registroG110 = new RegistroG110();
			//registroG110.DT_INI = DateTime.Now;
			//registroG110.DT_FIN = DateTime.Now;
			registroG110.SALDO_IN_ICMS = 44.00M;
			registroG110.SOM_PARC = 4.40M;
			registroG110.VL_TRIB_EXP = 10.999M;
			registroG110.VL_TOTAL = 10.999M;
			registroG110.IND_PER_SAI = 1.00M;
			registroG110.ICMS_APROP = 4.40M;
			registroG110.SOM_ICMS_OC = 10.999M;
			registroG001.RegistroG110.Add(registroG110);

			var registroG125 = new RegistroG125();

			registroG125.COD_IND_BEM = "000001";
			registroG125.DT_MOV = Convert.ToDateTime("01/11/2011");
			registroG125.TIPO_MOV = MovimentoBens.SI;
			registroG125.VL_IMOB_ICMS_OP = 10.999M;
			registroG125.VL_IMOB_ICMS_ST = 10.999M;
			registroG125.VL_IMOB_ICMS_FRT = 10.999M;
			registroG125.VL_IMOB_ICMS_DIF = 10.999M;
			registroG125.NUM_PARC = 10;
			registroG125.VL_PARC_PASS = 4.40M;
			registroG110.RegistroG125.Add(registroG125);

			var registroG126 = new RegistroG126();

			registroG126.DT_INI = Convert.ToDateTime("01/10/2011"); ;
			registroG126.DT_FIN = Convert.ToDateTime("30/10/2011"); ;
			registroG126.NUM_PARC = 1234;
			registroG126.VL_PARC_PASS = 10.999M;
			registroG126.VL_TRIB_OC = 10.999M;
			registroG126.VL_TOTAL = 10.999M;
			registroG126.IND_PER_SAI = 1.00M;
			registroG126.VL_PARC_APROP = 10.999M;
			registroG125.RegistroG126.Add(registroG126);

			var registroG130 = new RegistroG130();
			registroG130.IND_EMIT = Emitente.EmissaoPropria;
			registroG130.COD_PART = "000001";
			registroG130.COD_MOD = "55";
			registroG130.SERIE = "1";
			registroG130.NUM_DOC = "000068849";
			registroG130.CHV_NFE_CTE = "35100260318797000100550010000688490882775007";
			registroG130.DT_DOC = DateTime.Now;
			registroG125.RegistroG130.Add(registroG130);

			var registroG140 = new RegistroG140();
			registroG140.NUM_ITEM = "9999";
			registroG140.COD_ITEM = "000001";
			registroG130.RegistroG140.Add(registroG140);

			if (cbConcomitante.Checked)
			{
				//ACBrSPEDFiscal1.WriteBloco_G;
				LoadToMemo();
			}
		}

		private void CriaBlocoH()
		{
			btnB_H.Enabled = false;
			btnB_1.Enabled = true;

			// Alimenta o componente com informações para gerar todos os registros do
			// Bloco H.
			var blocoH = ACBrSPEDFiscal1.Bloco_H;

			var registroH001 = blocoH.RegistroH001;
			registroH001.IND_MOV = IndicadorMovimento.ComDados;

			var registroH005 = new RegistroH005();

			registroH005.DT_INV = blocoH.DT_FIN; //o valor informado no campo deve ser menor ou igual ao valor no campo DT_FIN do registro 0000
			registroH005.VL_INV = 1000;
			registroH001.RegistroH005.Add(registroH005);

			// FILHO
			for (int i = 1; i <= 10; i++ )
			{
				var registroH010 = new RegistroH010();
				registroH010.COD_ITEM = string.Format("{0:00000000000000}", i);
				registroH010.UNID = "UN";
				registroH010.QTD = 1;
				registroH010.VL_UNIT = 100;
				registroH010.VL_ITEM = 100;
				registroH010.IND_PROP = PosseItem.Informante;
				registroH010.COD_PART = "";
				registroH010.TXT_COMPL = "";
				registroH010.COD_CTA = "";
				registroH005.RegistroH010.Add(registroH010);
			}

			if (cbConcomitante.Checked)
			{
				//ACBrSPEDFiscal1.WriteBloco_H;
				LoadToMemo();
			}
		}

		private void LoadToMemo()
		{
			memoTXT.Text = null;
			if (File.Exists(Path.Combine(ACBrSPEDFiscal1.Path, ACBrSPEDFiscal1.Arquivo)))
			{
				memoTXT.Text = File.ReadAllText(Path.Combine(ACBrSPEDFiscal1.Path, ACBrSPEDFiscal1.Arquivo));
			}
		}
	}
}