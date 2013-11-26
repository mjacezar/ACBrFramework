using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ACBrFramework.PAF;

namespace ACBrFramework.Net.PAFTeste
{
    public partial class Form1: Form
    {
        #region Fields

        private const string NUM_FAB = "NUMFAB78901234567890";
        private const string MF_ADICIONAL = "";
        private const string TIPO_ECF = "ECF-IF";
        private const string MARCA_ECF = "ACBr";
        private const string MODELO_ECF = "PAF";

        #endregion Fields

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            InicializarPaf();
        }

        #endregion Constructor

        #region Methods

        private void InicializarPaf()
        {
            acbrPAF.Path = Path.GetDirectoryName(Application.ExecutablePath);
        }

        #region Registros ECF
        private void GerarRegistrosECF()
        {
            try
            {
                PAF_Preenche_A();
                PAF_Preenche_B();
                PAF_Preenche_C();
                PAF_Preenche_D();
                PAF_Preenche_E();
                PAF_Preenche_H();
                PAF_Preenche_P();
                PAF_Preenche_R();
                PAF_Preenche_U();

                if(acbrPAF.SaveFileTXT_RegistrosECF(@"\Registros_PAF.txt"))
                    WriteResp("Arquivo 'Registros_PAF.txt' gerado com sucesso");
                else
                    WriteResp("Arquivo 'Registros_PAF.txt' não foi gerado");
            }
            catch(Exception exception)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = exception.Message;
            }
        }

        #region PAF_Preenche_A
        private void PAF_Preenche_A()
        {
            for(int i = 0; i < 10; i++)
            {
                acbrPAF.PAF_A.RegistroA2.Add(new ACBrPAFRegistroA2
                {
                    CodigoTipoDocumento = CodigoTipoDocumento.CupomFiscal,
                    Data = DateTime.Today,
                    MeioPagamento = "Dinheiro",
                    RegistroValido = true,
                    Valor = (decimal)GerarDados('D', 3)
                });
            }
        }
        #endregion

        #region PAF_Preenche_B
        private void PAF_Preenche_B()
        {
            #region B1
            acbrPAF.PAF_B.RegistroB1.RazaoSocial = txtRazaoSocial.Text;
            acbrPAF.PAF_B.RegistroB1.CNPJ = txtCNPJ.Text;
            acbrPAF.PAF_B.RegistroB1.UF = txtUF.Text;
            acbrPAF.PAF_B.RegistroB1.IE = txtIE.Text;
            acbrPAF.PAF_B.RegistroB1.IM = txtIM.Text;
            #endregion

            #region B2

            for(int i = 0; i < 10; i++)
            {
                acbrPAF.PAF_B.RegistroB2.Add(new ACBrPAFRegistroB2
                                                                 {
                                                                     BOMBA = "Bomba",
                                                                     BICO = "Bico",
                                                                     DATA = DateTime.Today,
                                                                     HORA = DateTime.Now,
                                                                     MOTIVO = "http://desenvolvedores.net",
                                                                     CNPJ_EMPRESA = "12345678901234",
                                                                     CPF_TECNICO = "12345678901",
                                                                     NRO_LACRE_ANTES = "101010",
                                                                     NRO_LACRE_APOS = "90909",
                                                                     ENCERRANTE_ANTES = 10,
                                                                     ENCERRANTE_APOS = 10,
                                                                     RegistroValido = true
                                                                 });
            }
            #endregion
        }
        #endregion

        #region PAF_Preenche_C
        private void PAF_Preenche_C()
        {
            List<ACBrPAFRegistroC2> RegistroC2 = new List<ACBrPAFRegistroC2>();

            acbrPAF.PAF_C.RegistroC1.RazaoSocial = txtRazaoSocial.Text;
            acbrPAF.PAF_C.RegistroC1.UF = txtUF.Text;
            acbrPAF.PAF_C.RegistroC1.CNPJ = txtCNPJ.Text;
            acbrPAF.PAF_C.RegistroC1.IE = txtIE.Text;
            acbrPAF.PAF_C.RegistroC1.IM = txtIM.Text;

            for(int i = 0; i < 10; i++)
            {
                ACBrPAFRegistroC2 ItemC2 = new ACBrPAFRegistroC2();
                ItemC2.ID_ABASTECIMENTO = "";
                ItemC2.TANQUE = "001";
                ItemC2.BOMBA = "001";
                ItemC2.BICO = "001";
                ItemC2.COMBUSTIVEL = (string)GerarDados('S', 14);
                ItemC2.DATA_ABASTECIMENTO = DateTime.Now;
                ItemC2.HORA_ABASTECIMENTO = DateTime.Now;
                ItemC2.ENCERRANTE_INICIAL = (decimal)GerarDados('D', 5);
                ItemC2.ENCERRANTE_FINAL = (decimal)GerarDados('D', 5);
                ItemC2.STATUS_ABASTECIMENTO = "EMITIDO CF";
                ItemC2.NRO_SERIE_ECF = (string)GerarDados('S', 14);
                ItemC2.DATA = DateTime.Now;
                ItemC2.HORA = DateTime.Now;
                ItemC2.COO = (int)GerarDados('I', 3);
                ItemC2.NRO_NOTA_FISCAL = (int)GerarDados('I', 4);
                ItemC2.VOLUME = (int)GerarDados('I', 2);
                ItemC2.RegistroValido = true;
                acbrPAF.PAF_C.RegistroC2.Add(ItemC2);
                ItemC2 = null;
            }
        }
        #endregion

        #region PAF_Preenche_D
        private void PAF_Preenche_D()
        {
            List<ACBrPAFRegistroD2> RegistroD2 = new List<ACBrPAFRegistroD2>();

            acbrPAF.PAF_D.RegistroD1.RazaoSocial = txtRazaoSocial.Text;
            acbrPAF.PAF_D.RegistroD1.UF = txtUF.Text;
            acbrPAF.PAF_D.RegistroD1.CNPJ = txtCNPJ.Text;
            acbrPAF.PAF_D.RegistroD1.IE = txtIE.Text;
            acbrPAF.PAF_D.RegistroD1.IM = txtIM.Text;

            for(int i = 0; i < 10; i++)
            {
                ACBrPAFRegistroD2 ItemD2 = new ACBrPAFRegistroD2();
                ItemD2.NUM_FAB = NUM_FAB;
                ItemD2.MF_ADICIONAL = MF_ADICIONAL;
                ItemD2.TIPO_ECF = TIPO_ECF;
                ItemD2.MARCA_ECF = MARCA_ECF;
                ItemD2.MODELO_ECF = MODELO_ECF;
                ItemD2.COO = GerarDados('I', 6).ToString();
                ItemD2.NUM_DAV = GerarDados('I', 13).ToString();
                ItemD2.DT_DAV = DateTime.Now;
                ItemD2.TIT_DAV = "Pedido";
                ItemD2.VLT_DAV = (decimal)GerarDados('D', 8);
                ItemD2.COO_DFV = "0";
                ItemD2.NUMERO_ECF = "1";
                ItemD2.NOME_CLIENTE = "http://desenvolvedores.net";
                ItemD2.CPF_CNPJ = GerarDados('I', 14).ToString();

                for(int d = 0; d < 5; d++)
                {
                    ACBrPAFRegistroD3 ItemD3 = new ACBrPAFRegistroD3();
                    ItemD3.DT_INCLUSAO = DateTime.Now;
                    ItemD3.NUM_ITEM = d;
                    ItemD3.COD_ITEM = GerarDados('I', 8).ToString();
                    ItemD3.DESC_ITEM = "http://desenvolvedores.net";
                    ItemD3.QTDE_ITEM = (decimal)GerarDados('D', 8);
                    ItemD3.UNI_ITEM = "UN";
                    ItemD3.VL_UNIT = (decimal)GerarDados('D', 8);
                    ItemD3.VL_DESCTO = (decimal)GerarDados('D', 8);
                    ItemD3.VL_ACRES = (decimal)GerarDados('D', 8);
                    ItemD3.VL_TOTAL = (decimal)GerarDados('D', 8);
                    ItemD3.DEC_VL_UNIT = 2;
                    ItemD3.DEC_QTDE_ITEM = 2;
                    ItemD3.SIT_TRIB = "T";
                    ItemD3.ALIQ = (decimal)GerarDados('D', 8); ;
                    ItemD3.IND_CANC = "M";
                    ItemD3.RegistroValido = true;
                    ItemD2.RegistroD3.Add(ItemD3);
                    ItemD3 = null;
                }

                ItemD2.RegistroValido = true;
                acbrPAF.PAF_D.RegistroD2.Add(ItemD2);
                ItemD2 = null;
            }
        }
        #endregion

        #region PAF_Preenche_E
        private void PAF_Preenche_E()
        {
            #region E1
            acbrPAF.PAF_E.RegistroE1.RazaoSocial = txtRazaoSocial.Text;
            acbrPAF.PAF_E.RegistroE1.CNPJ = txtCNPJ.Text;
            acbrPAF.PAF_E.RegistroE1.UF = txtUF.Text;
            acbrPAF.PAF_E.RegistroE1.IE = txtIE.Text;
            acbrPAF.PAF_E.RegistroE1.IM = txtIM.Text;

            acbrPAF.PAF_E.RegistroE1.TIPO_ECF = "tipo";
            acbrPAF.PAF_E.RegistroE1.MARCA_ECF = "MARCA_ECF";
            acbrPAF.PAF_E.RegistroE1.MODELO_ECF = "MODELO_ECF";
            acbrPAF.PAF_E.RegistroE1.NUM_FAB = "NUM_FAB";
            acbrPAF.PAF_E.RegistroE1.MF_ADICIONAL = "MF_ADICIONAL";
            acbrPAF.PAF_E.RegistroE1.DT_EST = DateTime.Today;
            acbrPAF.PAF_E.RegistroE1.RegistroValido = true;
            acbrPAF.PAF_E.RegistroE1.InclusaoExclusao = true;
            #endregion

            #region E2
            for(int i = 0; i < 10; i++)
            {
                acbrPAF.PAF_E.RegistroE2.Add(new ACBrPAFRegistroE2
                {
                    COD_MERC = GerarDados('S', 10).ToString(),
                    DESC_MERC = "Descrição",
                    UN_MED = "UN",
                    QTDE_EST = 15,
                    RegistroValido = true
                });
            }
            #endregion

            #region E3
            acbrPAF.PAF_E.RegistroE3.DataEstoque = DateTime.Today;
            acbrPAF.PAF_E.RegistroE3.HoraEstoque = (decimal)DateTime.Now.ToOADate();
            acbrPAF.PAF_E.RegistroE3.MarcaECF = "MarcaECF";
            acbrPAF.PAF_E.RegistroE3.MFAdicional = "MFAdicional";
            acbrPAF.PAF_E.RegistroE3.ModeloECF = "ModeloECF";
            acbrPAF.PAF_E.RegistroE3.NumeroFabricacao = "NumeroFabricacao";
            acbrPAF.PAF_E.RegistroE3.RegistroValido = true;
            acbrPAF.PAF_E.RegistroE3.TipoECF = "TipoECF";
            #endregion
        }
        #endregion

        #region PAF_Preenche_H
        private void PAF_Preenche_H()
        {
            #region H1
            acbrPAF.PAF_H.RegistroH1.RazaoSocial = txtRazaoSocial.Text;
            acbrPAF.PAF_H.RegistroH1.CNPJ = txtCNPJ.Text;
            acbrPAF.PAF_H.RegistroH1.UF = txtUF.Text;
            acbrPAF.PAF_H.RegistroH1.IE = txtIE.Text;
            acbrPAF.PAF_H.RegistroH1.IM = txtIM.Text;

            acbrPAF.PAF_H.RegistroH1.TIPO_ECF = "TIPO_ECF";
            acbrPAF.PAF_H.RegistroH1.MARCA_ECF = "MARCA_ECF";
            acbrPAF.PAF_H.RegistroH1.MODELO_ECF = "MODELO_ECF";
            acbrPAF.PAF_H.RegistroH1.NUM_FAB = "NUM_FAB";
            acbrPAF.PAF_H.RegistroH1.MF_ADICIONAL = "MF_ADICIONAL";
            acbrPAF.PAF_H.RegistroH1.DT_EST = DateTime.Today;
            acbrPAF.PAF_H.RegistroH1.RegistroValido = true;
            acbrPAF.PAF_H.RegistroH1.InclusaoExclusao = false;
            #endregion

            #region H2
            for(int i = 0; i < 10; i++)
            {
                acbrPAF.PAF_H.RegistroH2.Add(new ACBrPAFRegistroH2
                {
                    CNPJ_CRED_CARTAO = "12345678901234",
                    COO = 1212,
                    CCF = 12121,
                    VLR_TROCO = 1212,
                    DT_TROCO = DateTime.Today,
                    CPF = "12345678901",
                    Titulo = "Titulo",
                    RegistroValido = false
                });
            }
            #endregion
        }
        #endregion

        #region PAF_Preenche_P
        private void PAF_Preenche_P()
        {
            acbrPAF.PAF_P.RegistroP1.RazaoSocial = txtRazaoSocial.Text;
            acbrPAF.PAF_P.RegistroP1.UF = txtUF.Text;
            acbrPAF.PAF_P.RegistroP1.CNPJ = txtCNPJ.Text;
            acbrPAF.PAF_P.RegistroP1.IE = txtIE.Text;
            acbrPAF.PAF_P.RegistroP1.IM = txtIM.Text;

            for(int i = 0; i < 10; i++)
            {
                ACBrPAFRegistroP2 ItemP2 = new ACBrPAFRegistroP2();
                ItemP2.COD_MERC_SERV = (string)GerarDados('S', 6);
                ItemP2.DESC_MERC_SERV = (string)GerarDados('S', 6);
                ItemP2.UN_MED = (string)GerarDados('S', 2);
                ItemP2.IAT = (string)GerarDados('S', 6);
                ItemP2.IPPT = (string)GerarDados('S', 6);
                ItemP2.ST = (string)GerarDados('S', 6);
                ItemP2.ALIQ = (decimal)GerarDados('D', 6);
                ItemP2.VL_UNIT = (decimal)GerarDados('D', 6);
                ItemP2.RegistroValido = true;
                acbrPAF.PAF_P.RegistroP2.Add(ItemP2);
                ItemP2 = null;
            }
        }
        #endregion

        #region PAF_Preenche_R
        private void PAF_Preenche_R()
        {

            for(int i = 0; i < 10; i++)
            {
                ACBrPAFRegistroR1 R1 = new ACBrPAFRegistroR1();

                R1.NUM_FAB = "NUM_FAB";
                R1.MF_ADICIONAL = "MF_ADICIONAL";
                R1.TIPO_ECF = "TIPO_ECF";
                R1.MARCA_ECF = "MARCA_ECF";
                R1.MODELO_ECF = "MODELO_ECF";
                R1.VERSAO_SB = "VERSAO_SB";
                R1.DT_INST_SB = DateTime.Today;
                R1.HR_INST_SB = DateTime.Now;
                R1.NUM_SEQ_ECF = i;
                R1.CNPJ = "12345678901234";
                R1.IE = "54654987";
                R1.CNPJ_SH = "12345678912345";
                R1.IE_SH = "654654654";
                R1.IM_SH = "65465687";
                R1.NOME_SH = "No nnoNo nOnon";
                R1.NOME_PAF = "Non nonoanoa";
                R1.VER_PAF = "1.0";
                R1.COD_MD5 = "jhg67565ahgfs65465agfs6a54sagfs564ashf";
                R1.DT_INI = DateTime.Today.AddDays(-10);
                R1.DT_FIN = DateTime.Today;
                R1.ER_PAF_ECF = "lklkj";
                R1.InclusaoExclusao = false;
                R1.RegistroValido = true;

                //R2 e R3
                for(int j = 0; j < 10; j++)
                {

                    ACBrPAFRegistroR2 R2 = new ACBrPAFRegistroR2();

                    R2.NUM_USU = 12121;
                    R2.CRZ = 12121;
                    R2.COO = 12121;
                    R2.CRO = 12121;
                    R2.DT_MOV = DateTime.Today;
                    R2.DT_EMI = DateTime.Today;
                    R2.HR_EMI = DateTime.Now;
                    R2.VL_VBD = 12;
                    R2.PAR_ECF = "asa";
                    R2.RegistroValido = true;

                    for(int k = 0; k < 10; k++)
                    {
                        R2.RegistroR3.Add(new ACBrPAFRegistroR3
                        {
                            TOT_PARCIAL = "Chucrute",
                            VL_ACUM = .71M * k,
                            RegistroValido = true
                        });
                    }

                    R1.RegistroR2.Add(R2);
                }

                //R4, R5 e R7				
                for(int x = 0; x < 10; x++)
                {
                    ACBrPAFRegistroR4 R4 = new ACBrPAFRegistroR4();

                    R4.NUM_USU = 12212;
                    R4.NUM_CONT = 1212;
                    R4.COO = 1212;
                    R4.DT_INI = DateTime.Today;
                    R4.SUB_DOCTO = 21212;
                    R4.SUB_DESCTO = 1212;
                    R4.TP_DESCTO = "S";
                    R4.SUB_ACRES = 12121;
                    R4.TP_ACRES = "D";
                    R4.VL_TOT = 12121;
                    R4.CANC = "C";
                    R4.VL_CA = 23323;
                    R4.ORDEM_DA = "asa";
                    R4.NOME_CLI = "No Non ononO n";
                    R4.CNPJ_CPF = "45645698741";
                    R4.RegistroValido = true;

                    for(int g = 0; g < 10; g++)
                    {

                        R4.RegistroR5.Add(new ACBrPAFRegistroR5
                        {
                            NUM_CONT = 121,
                            NUM_ITEM = 1212,
                            COD_ITEM = "21212",
                            DESC_ITEM = "43434",
                            QTDE_ITEM = 121,
                            UN_MED = "UN",
                            VL_UNIT = 121,
                            DESCTO_ITEM = 343,
                            ACRES_ITEM = 3432,
                            VL_TOT_ITEM = 321,
                            COD_TOT_PARC = "S",
                            IND_CANC = "D",
                            QTDE_CANC = 1212,
                            VL_CANC = 12,
                            VL_CANC_ACRES = 32,
                            IAT = "A",
                            IPPT = "T",
                            QTDE_DECIMAL = 1212,
                            VL_DECIMAL = 434,
                            RegistroValido = false
                        });
                    }

                    for(int h = 0; h < 10; h++)
                    {
                        R4.RegistroR7.Add(new ACBrPAFRegistroR7
                        {
                            CCF = 1212,
                            GNF = 1212,
                            MP = "S",
                            VL_PAGTO = 121,
                            IND_EST = "T",
                            VL_EST = 36,
                            RegistroValido = false
                        });
                    }

                    R1.RegistroR4.Add(R4);
                }

                //R6 e R7
                for(int l = 0; l < 10; l++)
                {
                    ACBrPAFRegistroR6 R6 = new ACBrPAFRegistroR6();
                    R6.NUM_USU = 121;
                    R6.COO = 546;
                    R6.GNF = 8;
                    R6.GRG = 36;
                    R6.CDC = 59;
                    R6.DENOM = "çasdflkçflsdk";
                    R6.DT_FIN = DateTime.Today;
                    R6.HR_FIN = DateTime.Now;
                    R6.RegistroValido = R6.RegistroValido;

                    for(int n = 0; n < 10; n++)
                    {
                        R6.RegistroR7.Add(new ACBrPAFRegistroR7
                        {
                            CCF = 1234,
                            GNF = 564,
                            MP = "lksdjhf",
                            VL_PAGTO = 12121,
                            IND_EST = "S",
                            VL_EST = 45,
                            RegistroValido = true
                        });
                    }

                    R1.RegistroR6.Add(R6);
                }

                acbrPAF.PAF_R.RegistroR1.Add(R1);
            }
        }
        #endregion

        #region PAF_Preenche_U
        private void PAF_Preenche_U()
        {
            acbrPAF.PAF_U.RegistroU1.RazaoSocial = txtRazaoSocial.Text;
            acbrPAF.PAF_U.RegistroU1.CNPJ = txtCNPJ.Text;
            acbrPAF.PAF_U.RegistroU1.UF = txtUF.Text;
            acbrPAF.PAF_U.RegistroU1.IE = txtIE.Text;
            acbrPAF.PAF_U.RegistroU1.IM = txtIM.Text;
        }
        #endregion

        #endregion

        private void GerarArquivoC()
        {
            try
            {
                acbrPAF.PAF_C.RegistroC1.RazaoSocial = txtRazaoSocial.Text;
                acbrPAF.PAF_C.RegistroC1.UF = txtUF.Text;
                acbrPAF.PAF_C.RegistroC1.CNPJ = txtCNPJ.Text;
                acbrPAF.PAF_C.RegistroC1.IE = txtIE.Text;
                acbrPAF.PAF_C.RegistroC1.IM = txtIM.Text;

                for(int i = 0; i < 10; i++)
                {
                    ACBrPAFRegistroC2 ItemC2 = new ACBrPAFRegistroC2();
                    ItemC2.ID_ABASTECIMENTO = "";
                    ItemC2.TANQUE = "001";
                    ItemC2.BOMBA = "001";
                    ItemC2.BICO = "001";
                    ItemC2.COMBUSTIVEL = (string)GerarDados('S', 14);
                    ItemC2.DATA_ABASTECIMENTO = DateTime.Now;
                    ItemC2.HORA_ABASTECIMENTO = DateTime.Now;
                    ItemC2.ENCERRANTE_INICIAL = (int)GerarDados('I', 5);
                    ItemC2.ENCERRANTE_FINAL = (int)GerarDados('I', 5);
                    ItemC2.STATUS_ABASTECIMENTO = "EMITIDO CF";
                    ItemC2.NRO_SERIE_ECF = (string)GerarDados('S', 14);
                    ItemC2.DATA = DateTime.Now;
                    ItemC2.HORA = DateTime.Now;
                    ItemC2.COO = (int)GerarDados('I', 3);
                    ItemC2.NRO_NOTA_FISCAL = (int)GerarDados('I', 4);
                    ItemC2.VOLUME = (int)GerarDados('I', 2);
                    ItemC2.RegistroValido = true;
                    acbrPAF.PAF_C.RegistroC2.Add(ItemC2);
                    ItemC2 = null;
                }

                if(acbrPAF.SaveFileTXT_C(@"\PAF_C.txt"))
                    WriteResp("Arquivo PAF_C gerado com sucesso");
                else
                    WriteResp("Arquivo PAF_C não foi gerado");
            }
            catch(Exception exception)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = exception.Message;
            }
        }

        private void GerarArquivoD()
        {
            try
            {
                acbrPAF.PAF_D.RegistroD1.RazaoSocial = txtRazaoSocial.Text;
                acbrPAF.PAF_D.RegistroD1.UF = txtUF.Text;
                acbrPAF.PAF_D.RegistroD1.CNPJ = txtCNPJ.Text;
                acbrPAF.PAF_D.RegistroD1.IE = txtIE.Text;
                acbrPAF.PAF_D.RegistroD1.IM = txtIM.Text;

                for(int i = 0; i < 10; i++)
                {
                    ACBrPAFRegistroD2 ItemD2 = new ACBrPAFRegistroD2();
                    ItemD2.NUM_FAB = NUM_FAB;
                    ItemD2.MF_ADICIONAL = MF_ADICIONAL;
                    ItemD2.TIPO_ECF = TIPO_ECF;
                    ItemD2.MARCA_ECF = MARCA_ECF;
                    ItemD2.MODELO_ECF = MODELO_ECF;
                    ItemD2.COO = GerarDados('I', 6).ToString();
                    ItemD2.NUM_DAV = GerarDados('I', 13).ToString();
                    ItemD2.DT_DAV = DateTime.Now;
                    ItemD2.TIT_DAV = "Pedido";
                    ItemD2.VLT_DAV = (decimal)GerarDados('D', 8);
                    ItemD2.COO_DFV = "0";
                    ItemD2.NUMERO_ECF = "1";
                    ItemD2.NOME_CLIENTE = "Rafael Dias";
                    ItemD2.CPF_CNPJ = GerarDados('I', 14).ToString();

                    for(int d = 0; d < 5; d++)
                    {
                        ACBrPAFRegistroD3 ItemD3 = new ACBrPAFRegistroD3();
                        ItemD3.DT_INCLUSAO = DateTime.Now;
                        ItemD3.NUM_ITEM = d;
                        ItemD3.COD_ITEM = GerarDados('I', 8).ToString();
                        ItemD3.DESC_ITEM = "descricao do item";
                        ItemD3.QTDE_ITEM = (decimal)GerarDados('D', 8);
                        ItemD3.UNI_ITEM = "UN";
                        ItemD3.VL_UNIT = (decimal)GerarDados('D', 8);
                        ItemD3.VL_DESCTO = (decimal)GerarDados('D', 8);
                        ItemD3.VL_ACRES = (decimal)GerarDados('D', 8);
                        ItemD3.VL_TOTAL = (decimal)GerarDados('D', 8);
                        ItemD3.DEC_VL_UNIT = 2;
                        ItemD3.DEC_QTDE_ITEM = 2;
                        ItemD3.SIT_TRIB = "T";
                        ItemD3.ALIQ = (decimal)GerarDados('D', 8); ;
                        ItemD3.IND_CANC = "M";
                        ItemD3.RegistroValido = true;
                        ItemD2.RegistroD3.Add(ItemD3);
                        ItemD3 = null;
                    }

                    ItemD2.RegistroValido = true;
                    acbrPAF.PAF_D.RegistroD2.Add(ItemD2);
                    ItemD2 = null;
                }

                if(acbrPAF.SaveFileTXT_D(@"\PAF_D.txt"))
                    WriteResp("Arquivo PAF_D gerado com sucesso");
                else
                    WriteResp("Arquivo PAF_D não foi gerado");
            }
            catch(Exception exception)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = exception.Message;
            }
        }

        private void GerarArquivoN()
        {
            try
            {
                acbrPAF.PAF_N.RegistroN1.RazaoSocial = txtRazaoSocial.Text;
                acbrPAF.PAF_N.RegistroN1.UF = txtUF.Text;
                acbrPAF.PAF_N.RegistroN1.CNPJ = txtCNPJ.Text;
                acbrPAF.PAF_N.RegistroN1.IE = txtIE.Text;
                acbrPAF.PAF_N.RegistroN1.IM = txtIM.Text;

                acbrPAF.PAF_N.RegistroN2.LAUDO = (string)GerarDados('S', 6); ;
                acbrPAF.PAF_N.RegistroN2.NOME = (string)GerarDados('S', 6); ;
                acbrPAF.PAF_N.RegistroN2.VERSAO = (string)GerarDados('S', 6);

                List<ACBrPAFRegistroN3> N3 = new List<ACBrPAFRegistroN3>();
                ACBrPAFRegistroN3 item1 = new ACBrPAFRegistroN3()
                {
                    NOME_ARQUIVO = (string)GerarDados('S', 6),
                    MD5 = (string)GerarDados('S', 36)
                };

                ACBrPAFRegistroN3 item2 = new ACBrPAFRegistroN3()
                {
                    NOME_ARQUIVO = "balcao.exe",
                    MD5 = (string)GerarDados('S', 36)
                };


                N3.Add(item1);
                N3.Add(item2);

                acbrPAF.PAF_N.RegistroN3.Clear();
                acbrPAF.PAF_N.RegistroN3.AddRange(N3.ToArray());

                if(acbrPAF.SaveFileTXT_N(@"\PAF_N.txt"))
                    WriteResp("Arquivo PAF_N gerado com sucesso");
                else
                    WriteResp("Arquivo PAF_N não foi gerado");
            }
            catch(Exception exception)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = exception.Message;
            }
        }

        private void GerarArquivoP()
        {
            try
            {
                acbrPAF.PAF_P.RegistroP1.RazaoSocial = txtRazaoSocial.Text;
                acbrPAF.PAF_P.RegistroP1.UF = txtUF.Text;
                acbrPAF.PAF_P.RegistroP1.CNPJ = txtCNPJ.Text;
                acbrPAF.PAF_P.RegistroP1.IE = txtIE.Text;
                acbrPAF.PAF_P.RegistroP1.IM = txtIM.Text;

                for(int i = 0; i < 10; i++)
                {
                    ACBrPAFRegistroP2 ItemP2 = new ACBrPAFRegistroP2();
                    ItemP2.COD_MERC_SERV = (string)GerarDados('S', 6);
                    ItemP2.DESC_MERC_SERV = (string)GerarDados('S', 6);
                    ItemP2.UN_MED = (string)GerarDados('S', 2);
                    ItemP2.IAT = (string)GerarDados('S', 6);
                    ItemP2.IPPT = (string)GerarDados('S', 6);
                    ItemP2.ST = (string)GerarDados('S', 6);
                    ItemP2.ALIQ = (decimal)GerarDados('D', 6);
                    ItemP2.VL_UNIT = (decimal)GerarDados('D', 6);
                    ItemP2.RegistroValido = true;
                    acbrPAF.PAF_P.RegistroP2.Add(ItemP2);
                    ItemP2 = null;
                }

                if(acbrPAF.SaveFileTXT_P(@"\PAF_P.txt"))
                    WriteResp("Arquivo PAF_P gerado com sucesso");
                else
                    WriteResp("Arquivo PAF_P não foi gerado");
            }
            catch(Exception exception)
            {
                messageToolStripStatusLabel.Text = "Exception";
                descriptionToolStripStatusLabel.Text = exception.Message;
            }
        }

        private object GerarDados(char tipo, int size)
        {
            Random random = new Random();
            StringBuilder str = new StringBuilder(size);
            char ch;
            int nb;
            for(int ind = 0; ind < size; ind++)
            {
                switch(tipo)
                {
                    case 'S':
                        ch = Convert.ToChar(Convert.ToInt32(Math.Floor(size * random.NextDouble() + 65)));
                        str.Append(ch);
                        break;

                    case 'I':
                        nb = Convert.ToInt32(decimal.Round(Convert.ToDecimal(Math.Floor(size * random.NextDouble() + 65)), 1));
                        str.Append(nb.ToString());
                        break;

                    case 'D':
                        nb = Convert.ToInt32(decimal.Round(Convert.ToDecimal(Math.Floor(size * random.NextDouble() + 65)), 1));
                        str.Append(nb.ToString());
                        break;
                }
            }

            str.Remove(0, str.Length - size);

            if(tipo == 'I')
                try
                {
                    return Convert.ToInt32(str.ToString().ToUpper());
                }
                catch(OverflowException)
                {
                    Int64 r = Convert.ToInt64(str.ToString().ToUpper());
                    return Convert.ToInt32((int)r / size);
                }
            if(tipo == 'D')
                return Convert.ToDecimal(str.ToString().ToUpper());
            else
                return str.ToString().ToUpper();
        }

        private void WriteResp(string resp)
        {
            if(string.IsNullOrEmpty(resp)) return;

            foreach(string line in resp.Split('\n'))
            {
                respListBox.Items.Add(line);
            }
            respListBox.Items.Add("+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
            respListBox.Items.Add("");
            respListBox.SelectedIndex = respListBox.Items.Count - 1;
        }

        #endregion Methods

        #region Event Handlers

        private void btnTipoC_Click(object sender, EventArgs e)
        {
            GerarArquivoC();
        }

        private void btnTipoD_Click(object sender, EventArgs e)
        {
            GerarArquivoD();
        }

        private void btnTipoN_Click(object sender, EventArgs e)
        {
            GerarArquivoN();
        }

        private void btnTipoP_Click(object sender, EventArgs e)
        {
            GerarArquivoP();
        }

        private void btnRegistroECF_Click(object sender, EventArgs e)
        {
            GerarRegistrosECF();
        }

        private void acbrPAF_OnPAFGetKeyRSA(object sender, ChaveEventArgs e)
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

        #endregion Event Handlers        
    }
}