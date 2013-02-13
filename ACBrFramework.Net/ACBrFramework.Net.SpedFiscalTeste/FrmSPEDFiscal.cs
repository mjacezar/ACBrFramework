using System;
using System.Windows.Forms;
using ACBrFramework.Sped;

namespace ACBrFramework.Net.SpedFiscalTeste
{
    public partial class FrmSPEDFiscal: Form
    {
        public FrmSPEDFiscal()
        {
            InitializeComponent();
        }

        public void ACBrSPEDFiscal1Error(string MsnError)
        {
            //@ Unsupported property or method(A): 'Add'
            //memoError.Lines  .Add(MsnError);
        }

        public void btnB_0Click(System.Object Sender, System.EventArgs _e1)
        {
            string[] strUNID = {"PC", "UN", "LT", "PC", "MT"};
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
            registro0000.IND_PERFIL =  Perfil.PerfilA;
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
            for (int0150 = 1; int0150 <= 10; int0150 ++ )
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
            for (int0190 = strUNID.GetLowerBound(0); int0190 <= strUNID.GetUpperBound(0); int0190 ++ )
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
            for (int0300 = 1; int0300 <= 10; int0300 ++ )
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

			for (int0500 = 1; int0500 <= 10; int0500 ++ )
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

            for (int0600 = 1; int0600 <= 10; int0600 ++ )
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

        public void btnB_9Click(System.Object Sender, System.EventArgs _e1)
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

		public void btnTXTClick(System.Object Sender, System.EventArgs _e1)
		{
			btnTXT.Enabled = false;
			ACBrSPEDFiscal1.LinhasBuffer = Convert.ToInt32(edBufLinhas.Text);
			ACBrSPEDFiscal1.DT_INI = Convert.ToDateTime("01/11/2011");
			ACBrSPEDFiscal1.DT_FIN = Convert.ToDateTime("30/11/2011");

			// Limpa a lista de erros.
			memoError.Text = null;

			// Informa o pata onde será salvo o arquivo TXT.
			ACBrSPEDFiscal1.Path = @"c:\NovaPasta\";
			ACBrSPEDFiscal1.Arquivo = @"sped_1.txt";

			// Método que gera o arquivo TXT.
			ACBrSPEDFiscal1.SaveFileTXT();

			// Carrega o arquivo TXT no memo.
			LoadToMemo();

			// Habilita os botões
			btnB_0.Enabled = true;
			btnTXT.Enabled = true;
			cbConcomitante.Enabled = true;
		}

        public void btnErrorClick(System.Object Sender, System.EventArgs _e1)
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

        public void btnB_1Click(System.Object Sender, System.EventArgs _e1)
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

		public void btnB_CClick(System.Object Sender, System.EventArgs _e1)
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
					var _wvar7 = new RegistroC170();

					// Inicio Adicionar os Itens:
					_wvar7.NUM_ITEM = string.Format("{0:000}", IItens);
					_wvar7.COD_ITEM = string.Format("{0:000000}", _wvar7.NUM_ITEM);
					_wvar7.DESCR_COMPL = string.Format("11{0:000000} ITEM {1}", INotas, _wvar7.COD_ITEM);
					_wvar7.QTD = 1;
					_wvar7.UNID = "UN";
					_wvar7.VL_ITEM = 0;
					_wvar7.VL_DESC = 0;
					_wvar7.IND_MOV = MovimentacaoFisica.Nao;

					registroC100.RegistroC170.Add(_wvar7);
				}
			}
		}

        public void btnB_CompletoClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void btnB_DClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void btnB_EClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void btnB_GClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void btnB_HClick(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void edtFileChange(System.Object Sender, System.EventArgs _e1)
        {
        }

        public void LoadToMemo()
        {
        }

        public void cbConcomitanteClick(System.Object Sender, System.EventArgs _e1)
        {
        }

		private void ACBrSPEDFiscal1_OnError(object sender, ErrorEventArgs e)
		{
			if (!string.IsNullOrEmpty(memoError.Text))
			{
				memoError.Text += Environment.NewLine;
			}

			memoError.Text += e.MsgErro;
		}

    }

}


