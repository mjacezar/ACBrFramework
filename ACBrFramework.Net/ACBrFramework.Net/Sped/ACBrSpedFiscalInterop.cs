using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.Sped
{
	internal class ACBrSpedFiscalInterop
	{
		#region InnerTypes

		#region Bloco0

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0000
		{
			[MarshalAs(UnmanagedType.I4)]
			public int COD_VER; /// Código da versão do leiaute: 100, 101, 102

			[MarshalAs(UnmanagedType.I4)]
			public int COD_FIN; /// Código da finalidade do arquivo: 0 - Remessa do arquivo original / 1 - Remessa do arquivo substituto.

			[MarshalAs(UnmanagedType.R8)]
			public double DT_INI;           /// Data inicial das informações contidas no arquivo

			[MarshalAs(UnmanagedType.R8)]
			public double DT_FIN;           /// Data final das informações contidas no arquivo

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string NOME;                 /// Nome empresarial do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;               /// Número de inscrição do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF;                 /// Número de inscrição do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;                  /// Sigla da unidade da federação:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;                  /// Inscrição Estadual do contribuinte:

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;            /// Código do município do domicílio fiscal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IM;                  /// Inscrição Municipal do contribuinte:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string SUFRAMA;             /// Número de inscrição do contribuinte:

			[MarshalAs(UnmanagedType.I4)]
			public int IND_PERFIL;     /// Perfil de apresentação do arquivo fiscal: A - Perfil A / B - Perfil B / C - Perfil C

			[MarshalAs(UnmanagedType.I4)]
			public int IND_ATIV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0005
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string FANTASIA;     /// Nome de fantasia associado:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CEP;     /// Código de Endereçamento Postal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string ENDERECO;     /// Logradouro e endereço do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM;     /// Número do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COMPL;     /// Dados complementares do endereço:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string BAIRRO;     /// Bairro em que o imóvel está situado:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FONE;     /// Número do telefone:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FAX;     /// Número do fax:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 151)]
			public string EMAIL;     /// Endereço do correio eletrônico:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0015
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_ST;   /// Sigla da unidade da federação:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_ST;   /// Inscrição Estadual:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0100
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string NOME;       /// Nome do contabilista/escritório:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF;        /// Número de inscrição no CPF:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string CRC;        /// Número de inscrição no Conselho Regional:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;        /// CNPJ do escritório de contabilidade, se houver:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CEP;         /// Código de Endereçamento Postal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string ENDERECO;        /// Logradouro e endereço do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM;        /// Número do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COMPL;        /// Dados complementares do endereço:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string BAIRRO;        /// Bairro em que o imóvel está situado:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FONE;        /// Número do telefone:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FAX;        /// Número do fax:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 151)]
			public string EMAIL;       /// Endereço do correio eletrônico:

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;                     /// Código do município, conforme tabela IBGE:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0150
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;     /// Código de identificação do participante:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string NOME;         /// Nome pessoal ou empresarial:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
			public string COD_PAIS;     /// Código do país do participante:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;         /// CNPJ do participante:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF;          /// CPF do participante na unidade da federação do destinatário:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;           /// Inscrição Estadual do participante:

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;         /// Código do município:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string SUFRAMA;      /// Número de inscrição na Suframa:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string ENDERECO;     /// Logradouro e endereço do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM;          /// Número do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COMPL;        /// Dados complementares do endereço:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string BAIRRO;       /// Bairro em que o imóvel está situado:

			[MarshalAs(UnmanagedType.I4)]
			public int Count0175;       /// BLOCO C - Lista de Registro0175 (FILHO)
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0175
		{
			[MarshalAs(UnmanagedType.R8)]
			public double DT_ALT;        /// Data de alteração do cadastro:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string NR_CAMPO;      /// Número do campo alterado (Somente campos 03 a 13):

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string CONT_ANT;      /// Conteúdo anterior do campo:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0190
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;      /// Número do campo alterado (Somente campos 03 a 13):

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string DESCR;      /// Conteúdo anterior do campo:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0200
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 201)]
			public string DESCR_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string COD_BARRA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ANT_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID_INV;

			[MarshalAs(UnmanagedType.I4)]
			public int TIPO_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string COD_NCM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string EX_IPI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_GEN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string COD_LST;

			[MarshalAs(UnmanagedType.R8)]
			public double ALIQ_ICMS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0205
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 201)]
			public string DESCR_ANT_ITEM;

			public double DT_INI;

			public double DT_FIN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ANT_ITEM;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0206
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_COMB;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0220
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID_CONV;

			public double FAT_CONV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0300
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_IND_BEM;

			public int IDENT_MERC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 201)]
			public string DESCR_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PRNC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;

			public double NR_PARC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0305
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CCUS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 201)]
			public string FUNC;

			public int VIDA_UTIL;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0400
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_NAT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 201)]
			public string DESCR_NAT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0450
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_INF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string TXT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0460
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string TXT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0500
		{
			public double DT_ALT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_NAT_CC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_CTA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
			public string NIVEL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NOME_CTA;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0600
		{
			public double DT_ALT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CCUS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string CCUS;
		}

		#endregion Bloco0

		#region Bloco1

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1010
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_EXP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_CCRF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_COMB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_USINA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_VA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_EE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_CART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_FORM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_AER;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1100
		{
			public int IND_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string NRO_DE;

			public double DT_DE;

			public int NAT_EXP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string NRO_RE;

			public double DT_RE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
			public string CHC_EMB;

			public double DT_CHC;

			public double DT_AVB;

			public int TP_CHC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string PAIS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1105
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SERIE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_NFE;

			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1110
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;

			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_NFE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NR_MEMO;

			public double QTD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1200
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string COD_AJ_APUR;

			public double SLD_CRED;

			public double CRED_APR;

			public double CRED_RECEB;

			public double CRED_UTIL;

			public double SLD_CRED_FIM;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1210
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string TIPO_UTIL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NR_DOC;

			public double VL_CRED_UTIL;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1300
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			public double DT_FECH;

			public double ESTQ_ABERT;

			public double VOL_ENTR;

			public double VOL_DISP;

			public double VOL_SAIDAS;

			public double ESTQ_ESCR;

			public double VAL_AJ_PERDA;

			public double VAL_AJ_GANHO;

			public double FECH_FISICO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1310
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUM_TANQUE;

			public double ESTQ_ABERT;

			public double VOL_ENTR;

			public double VOL_DISP;

			public double VOL_SAIDAS;

			public double ESTQ_ESCR;

			public double VAL_AJ_PERDA;

			public double VAL_AJ_GANHO;

			public double FECH_FISICO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1320
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_BICO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NR_INTERV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string MOT_INTERV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string NOM_INTERV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_INTERV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF_INTERV;

			public double VAL_FECHA;

			public double VAL_ABERT;

			public double VOL_AFERI;

			public double VOL_VENDAS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1350
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SERIE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string FABRICANTE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string MODELO;

			public int TIPO_MEDICAO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1360
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NUM_LACRE;

			public double DT_APLICACAO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1370
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUM_BICO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUM_TANQU;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1390
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_PROD;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1400
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
			public string MUN;

			public double VALOR;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1500
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_OPER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_MOD;

			public int COD_SIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			public int COD_CONS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;

			public double DT_DOC;

			public double DT_E_S;

			public double VL_DOC;

			public double VL_DESC;

			public double VL_FORN;

			public double VL_SERV_NT;

			public double VL_TERC;

			public double VL_DA;

			public double VL_BC_ICMS;

			public double VL_ICMS;

			public double VL_BC_ICMS_ST;

			public double VL_ICMS_ST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_INF;

			public double VL_PIS;

			public double VL_COFINS;

			public int TP_LIGACAO;

			public int COD_GRUPO_TENSAO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1510
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string COD_CLASS;

			public double QTD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;

			public double VL_ITEM;

			public double VL_DESC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			public double VL_BC_ICMS;

			public double ALIQ_ICMS;

			public double VL_ICMS;

			public double VL_BC_ICMS_ST;

			public double ALIQ_ST;

			public double VL_ICMS_ST;

			public int IND_REC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			public double VL_PIS;

			public double VL_COFINS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1600
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			public double TOT_CREDITO;

			public double TOT_DEBITO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1700
		{
			public int COD_DISP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string NUM_DOC_INI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string NUM_DOC_FIN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_AUT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1710
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string NUM_DOC_INI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
			public string NUM_DOC_FIN;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco1Registro1800
		{
			public double VL_CARGA;

			public double VL_PASS;

			public double VL_FAT;

			public double IND_RAT;

			public double VL_ICMS_ANT;

			public double VL_BC_ICMS;

			public double VL_ICMS_APUR;

			public double VL_BC_ICMS_APUR;

			public double VL_DIF;
		}

		#endregion Bloco1

		#endregion InnerTypes

		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrSPEDFiscal

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Create(ref IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Destroy(ref IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetUltimoErro(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetAbout(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetArquivo(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetArquivo(IntPtr spdfHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetCurMascara(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetCurMascara(IntPtr spdfHandle, string mascara);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetPath(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetPath(IntPtr spdfHandle, string path);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetDelimitador(IntPtr spdfHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetDelimitador(IntPtr spdfHandle, string delimitador);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetLinhasBuffer(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetLinhasBuffer(IntPtr spdfHandle, int linhas);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetTrimString(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetTrimString(IntPtr spdfHandle, bool trim);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetDT_INI(IntPtr spdfHandle, ref double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetDT_INI(IntPtr spdfHandle, double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_GetDT_FIN(IntPtr spdfHandle, ref double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_SetDT_FIN(IntPtr spdfHandle, double data);

		#endregion Propriedades do Componente

		#region Metodos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_IniciaGeracao(IntPtr spdfHandle);

		#region Bloco_0

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_GetDT_INI(IntPtr spdfHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_SetDT_INI(IntPtr spdfHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_GetDT_FIN(IntPtr spdfHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_SetDT_FIN(IntPtr spdfHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_GetGravado(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0000New(IntPtr spdfHandle, Bloco0Registro0000 registro0000);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0001New(IntPtr spdfHandle, Bloco0Registro0001 registro0001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0005New(IntPtr spdfHandle, Bloco0Registro0005 registro0005);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0015New(IntPtr spdfHandle, Bloco0Registro0015 registro0015);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0100New(IntPtr spdfHandle, Bloco0Registro0100 registro0100);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0150New(IntPtr spdfHandle, Bloco0Registro0150 registro0150);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0175New(IntPtr spdfHandle, Bloco0Registro0175 registro0175);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0190New(IntPtr spdfHandle, Bloco0Registro0190 registro0190);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0200New(IntPtr spdfHandle, Bloco0Registro0200 registro0200);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0205New(IntPtr spdfHandle, Bloco0Registro0205 registro0205);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0206New(IntPtr spdfHandle, Bloco0Registro0206 registro0206);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0220New(IntPtr spdfHandle, Bloco0Registro0220 registro0220);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0300New(IntPtr spdfHandle, Bloco0Registro0300 registro0300);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0305New(IntPtr spdfHandle, Bloco0Registro0305 registro0305);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0400New(IntPtr spdfHandle, Bloco0Registro0400 registro0400);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0450New(IntPtr spdfHandle, Bloco0Registro0450 registro0450);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0460New(IntPtr spdfHandle, Bloco0Registro0460 registro0460);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0500New(IntPtr spdfHandle, Bloco0Registro0500 registro0500);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0600New(IntPtr spdfHandle, Bloco0Registro0600 registro0600);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_0_Registro0990_GetQTD_LIN_0(IntPtr spdfHandle);

		#endregion Bloco_0

		#region Bloco_1

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_GetDT_INI(IntPtr spdfHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_SetDT_INI(IntPtr spdfHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_GetDT_FIN(IntPtr spdfHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_SetDT_FIN(IntPtr spdfHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_GetGravado(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1001New(IntPtr spdfHandle, Bloco1Registro1001 registro1001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1010New(IntPtr spdfHandle, Bloco1Registro1010 registro1010);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1100New(IntPtr spdfHandle, Bloco1Registro1100 registro1100);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1105New(IntPtr spdfHandle, Bloco1Registro1105 registro1105);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1110New(IntPtr spdfHandle, Bloco1Registro1110 registro1110);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1200New(IntPtr spdfHandle, Bloco1Registro1200 registro1200);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1210New(IntPtr spdfHandle, Bloco1Registro1210 registro1210);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1300New(IntPtr spdfHandle, Bloco1Registro1300 registro1300);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1310New(IntPtr spdfHandle, Bloco1Registro1310 registro1310);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1320New(IntPtr spdfHandle, Bloco1Registro1320 registro1320);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1350New(IntPtr spdfHandle, Bloco1Registro1350 registro1350);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1360New(IntPtr spdfHandle, Bloco1Registro1360 registro1360);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1370New(IntPtr spdfHandle, Bloco1Registro1370 registro1370);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1390New(IntPtr spdfHandle, Bloco1Registro1390 registro1390);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1400New(IntPtr spdfHandle, Bloco1Registro1400 registro1400);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1500New(IntPtr spdfHandle, Bloco1Registro1500 registro1500);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1510New(IntPtr spdfHandle, Bloco1Registro1510 registro1510);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1600New(IntPtr spdfHandle, Bloco1Registro1600 registro1600);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1700New(IntPtr spdfHandle, Bloco1Registro1700 registro1700);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1701New(IntPtr spdfHandle, Bloco1Registro1710 registro1710);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1800New(IntPtr spdfHandle, Bloco1Registro1800 registro1800);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1990_GetQTD_LIN_1(IntPtr spdfHandle);

		#endregion Bloco_1

		#endregion Metodos

		#endregion ACBrSPEDFiscal
	}
}