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

		#region Bloco9

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco9Registro9001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco9Registro9900
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string REG_BLC;

			[MarshalAs(UnmanagedType.I4)]
			public int QTD_REG_BLC;
		}

		#endregion Bloco9

		#region BlocoC

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC100
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_OPER;

			[MarshalAs(UnmanagedType.I4)]
			public int IND_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_SIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_NFE;

			public double DT_DOC;

			public double DT_E_S;

			public double VL_DOC;

			[MarshalAs(UnmanagedType.I4)]
			public int IND_PGTO;

			public double VL_DESC;

			public double VL_ABAT_NT;

			public double VL_MERC;

			[MarshalAs(UnmanagedType.I4)]
			public int IND_FRT;

			public double VL_FRT;

			public double VL_SEG;

			public double VL_OUT_DA;

			public double VL_BC_ICMS;

			public double VL_ICMS;

			public double VL_BC_ICMS_ST;

			public double VL_ICMS_ST;

			public double VL_IPI;

			public double VL_PIS;

			public double VL_COFINS;

			public double VL_PIS_ST;

			public double VL_COFINS_ST;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC105
		{
			public int OPER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC110
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_INF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string TXT_COMPL;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC111
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string NUM_PROC;

			public int IND_PROC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC112
		{
			public int COD_DA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_DA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_AUT;

			public double VL_DA;

			public double DT_VCTO;

			public double DT_PGTO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC113
		{
			public int IND_OPER;

			public int IND_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;

			public double DT_DOC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC114
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string ECF_FAB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string ECF_CX;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_DOC;

			public double DT_DOC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC115
		{
			public int IND_CARGA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_COL;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_COL;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF_COL;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_COL;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_ENTG;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string IE_ENTG;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF_ENTG;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ENTG;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC116
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NR_SAT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_CFE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_CFE;

			public double DT_DOC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC120
		{
			public int COD_DOC_IMP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM_DOC__IMP;

			public double PIS_IMP;

			public double COFINS_IMP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NUM_ACDRAW;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC130
		{
			public double VL_SERV_NT;
		
			public double VL_BC_ISSQN;
			
			public double VL_ISSQN;
			
			public double VL_BC_IRRF;
			
			public double VL_IRRF;
			
			public double VL_BC_PREV;
			
			public double VL_PREV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC140
		{
			public int IND_EMIT;
			
			public int IND_TIT;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string DESC_TIT;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_TIT;
			
			public int QTD_PARC;
		
			public double VL_TIT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC141
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string NUM_PARC;

			public double DT_VCTO;

			public double VL_PARC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC160
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string VEIC_ID;
			
			public int QTD_VOL;
			
			public double PESO_BRT;
			
			public double PESO_LIQ;
		
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_ID;
		}


		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC165
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string VEIC_ID;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_AUT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NR_PASSE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string HORA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string TEMPER;
		
			public int QTD_VOL;
			
			public double PESO_BRT;
			
			public double PESO_LIQ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NOM_MOT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_ID;

		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC170
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string DESCR_COMPL;

			public double QTD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;

			public double VL_ITEM;

			public double VL_DESC;

			public int IND_MOV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string COD_NAT;

			public double VL_BC_ICMS;

			public double ALIQ_ICMS;

			public double VL_ICMS;

			public double VL_BC_ICMS_ST;

			public double ALIQ_ST;

			public double VL_ICMS_ST;

			public int IND_APUR;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string CST_IPI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string COD_ENQ;

			public double VL_BC_IPI;

			public double ALIQ_IPI;

			public double VL_IPI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string CST_PIS;

			public double VL_BC_PIS;

			public double ALIQ_PIS_PERC;

			public double QUANT_BC_PIS;

			public double ALIQ_PIS_R;

			public double VL_PIS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string CST_COFINS;

			public double VL_BC_COFINS;

			public double ALIQ_COFINS_PERC;

			public double QUANT_BC_COFINS;

			public double ALIQ_COFINS_R;

			public double VL_COFINS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC171
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUM_TANQUE;

			public double QTDE;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC172
		{
			public double VL_BC_ISSQN;

			public double ALIQ_ISSQN;

			public double VL_ISSQN;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC173
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string LOTE_MED;
		
			public double QTD_ITEM;
			
			public double DT_FAB;
			
			public double DT_VAL;
			
			public int IND_MED;
			
			public int TP_PROD;
			
			public double VL_TAB_MAX;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC174
		{
			public int IND_ARM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_ARM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string DESCR_COMPL;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC175
		{
			public int IND_VEIC_OPER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
			public string CHASSI_VEIC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC176
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD_ULT_E;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC_ULT_E;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SER_ULT_E;

			public double DT_ULT_E;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART_ULT_E;
		
			public double QUANT_ULT_E;
			
			public double VL_UNIT_ULT_E;
			
			public double VL_UNIT_BC_ST;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC177
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_SELO_IPI;

			public double QT_SELO_IPI;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC178
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
			public string CL_ENQ;

			public double VL_UNID;

			public double QUANT_PAD;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC179
		{
			public double BC_ST_ORIG_DEST;
		
			public double ICMS_ST_REP;
			
			public double ICMS_ST_COMPL;
			
			public double BC_RET;
			
			public double ICMS_RET;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC190
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_BC_ICMS_ST;
			
			public double VL_ICMS_ST;
			
			public double VL_RED_BC;
			
			public double VL_IPI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC195
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string TXT_COMPL;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC197
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string COD_AJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string DESCR_COMPL_AJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string COD_ITEM;

			public double VL_BC_ICMS;

			public double ALIQ_ICMS;

			public double VL_ICMS;

			public double VL_OUTROS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC300
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_DOC_INI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_DOC_FIN;
			
			public double DT_DOC;
			
			public double VL_DOC;
			
			public double VL_PIS;
			
			public double VL_COFINS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC310
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_DOC_CANC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC320
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_RED_BC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC321
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			public double QTD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;
			
			public double VL_ITEM;
			
			public double VL_DESC;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_PIS;
			
			public double VL_COFINS;
		}


		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC350
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB_SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_DOC;

			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CPF;

			public double VL_MERC;
			
			public double VL_DOC;
			
			public double VL_DESC;
			
			public double VL_PIS;
			
			public double VL_COFINS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC370
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			public double QTD;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string UNID;
			
			public double VL_ITEM;
			
			public double VL_DESC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC390
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_RED_BC;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC400
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string ECF_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string ECF_FAB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string ECF_CX;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC405
		{
			public double DT_DOC;
			
			public int CRO;
			
			public int CRZ;
			
			public int NUM_COO_FIN;
			
			public double GT_FIN;
			
			public double VL_BRT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC410
		{
			public double VL_PIS;

			public double VL_COFINS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC420
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_TOT_PAR;
			
			public double VLR_ACUM_TOT;
			
			public int NR_TOT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string DESCR_NR_TOT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC425
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;
			
			public double QTD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;
			
			public double VL_ITEM;
			
			public double VL_PIS;
		
			public double VL_COFINS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC460
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_MOD;
		
			public int COD_SIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string NUM_DOC;
			
			public double DT_DOC;
			
			public double VL_DOC;
			
			public double VL_PIS;
			
			public double VL_COFINS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPF_CNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NOM_ADQ;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC470
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;
		
			public double QTD;
			
			public double QTD_CANC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;
			
			public double VL_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_PIS;
			
			public double VL_COFINS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC490
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC495
		{
			public double ALIQ_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;
			
			public double QTD;
			
			public double QTD_CANC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;
			
			public double VL_ITEM;
			
			public double VL_DESC;
			
			public double VL_CANC;
			
			public double VL_ACMO;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_ISEN;
			
			public double VL_NT;
			
			public double VL_ICMS_ST;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC500
		{
			public int IND_OPER;
			
			public int IND_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;
			
			public int COD_SIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_CONS;
			
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
		public struct BlocoCRegistroC510
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
		public struct BlocoCRegistroC590
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_BC_ICMS_ST;
			
			public double VL_ICMS_ST;
			
			public double VL_RED_BC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC600
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_CONS;

			public double QTD_CONS;
			
			public double QTD_CANC;
			
			public double DT_DOC;
			
			public double VL_DOC;
			
			public double VL_DESC;
			
			public double CONS;
			
			public double VL_FORN;
			
			public double VL_SERV_NT;
			
			public double VL_TERC;
			
			public double VL_DA;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_BC_ICMS_ST;
			
			public double VL_ICMS_ST;
			
			public double VL_PIS;
			
			public double VL_COFINS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC601
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC_CANC;

		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC610
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string COD_CLASS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;
			
			public double QTD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID;
			
			public double VL_ITEM;
			
			public double VL_DESC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_BC_ICMS_ST;
			
			public double VL_ICMS_ST;
			
			public double VL_PIS;
			
			public double VL_COFINS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC690
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_RED_BC;
			
			public double VL_BC_ICMS_ST;
			
			public double VL_ICMS_ST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC700
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;
			
			public int NRO_ORD_INI;
			
			public int NRO_ORD_FIN;
			
			public double DT_DOC_INI;
			
			public double DT_DOC_FIN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string NOM_MEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
			public string CHV_COD_DIG;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC790
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public double CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_BC_ICMS_ST;
			
			public double VL_ICMS_ST;
			
			public double VL_RED_BC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC791
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			public double VL_BC_ICMS_ST;

			public double VL_ICMS_ST;
		}


		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC800
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;
			
			public int COD_SIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_CFE;
			
			public double DT_DOC;
			
			public double VL_CFE;
			
			public double VL_PIS;
			
			public double VL_COFINS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CPF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NR_SAT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_CFE;
			
			public double VL_DESC;
			
			public double VL_MERC;
			
			public double VL_OUT_DA;
			
			public double VL_ICMS;
			
			public double VL_PIS_ST;
			
			public double VL_COFINS_ST;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC850
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC860
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NR_SAT;
			
			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string DOC_INI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string DOC_FIN;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC890
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			public double ALIQ_ICMS;

			public double VL_OPR;

			public double VL_BC_ICMS;

			public double VL_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		#endregion BlocoC

		#region BlocoD

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD100
		{
			public int IND_OPER;
			
			public int IND_EMIT;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;
			
			public int COD_SIT;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_CTE;
			
			public double DT_DOC;
			
			public double DT_A_P;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string TP_CT_e;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_CTE_REF;
			
			public double VL_DOC;
			
			public double VL_DESC;
			
			public int IND_FRT;
			
			public double VL_SERV;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_NT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_INF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;
		}


		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD110
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			public int NUN_ITEM;
			
			public double VL_SERV;
			
			public double VL_OUT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD120
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORIG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_DEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string VEIC_ID;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_ID;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD130
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART_CONSG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART_RED;
			
			public int IND_FRT_RED;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORIG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_DEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string VEIC_ID;
			
			public double VL_LIQ_FRT;
			
			public double VL_SEC_CAT;
			
			public double VL_DESP;
			
			public double VL_PEDG;
			
			public double VL_OUT;
			
			public double VL_FRT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_ID;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD140
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART_CONSG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORIG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_DEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_VEIC;

			public int VEIC_ID;
			
			public int IND_NAV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string VIAGEM;
			
			public double VL_FRT_LIQ;
			
			public double VL_DESP_PORT;
			
			public double VL_DESP_CAR_DESC;
			
			public double VL_OUT;
			
			public double VL_FRT_BRT;
			
			public double VL_FRT_MM;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD150
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORIG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_DEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string VEIC_ID;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string VIAGEM;
			
			public int IND_TFA;
			
			public double VL_PESO_TX;
			
			public double VL_TX_TERR;
			
			public double VL_TX_RED;
			
			public double VL_OUT;
			
			public double VL_TX_ADV;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD160
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string DESPACHO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CPF_REM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_REM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CPF_DEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_DEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_DEST;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD161
		{
			public int IND_CARGA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_COL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_COL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_COL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_ENTG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_ENTG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ENTG;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD162
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;
			
			public double DT_DOC;
			
			public double VL_DOC;
			
			public double VL_MERC;
			
			public double QTD_VOL;
			
			public double PESO_BRT;
			
			public double PESO_LIQ;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD170
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART_CONSG;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_PART_RED;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORIG;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_DEST;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string OTM;
			
			public int IND_NAT_FRT;
			
			public double VL_LIQ_FRT;
			
			public double VL_GRIS;
			
			public double VL_PDG;
			
			public double VL_OUT;
			
			public double VL_FRT;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string VEIC_ID;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_ID;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD180
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_SEQ;
			
			public int IND_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_EMIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORIG;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CPF_TOM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF_TOM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_TOM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_DEST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
			public string NUM_DOC;
			
			public double DT_DOC;
			
			public double VL_DOC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD190
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;
			
			public double ALIQ_ICMS;
			
			public double VL_OPR;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_RED_BC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD195
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
			public string TXT_COMPL;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD197
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string COD_AJ;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string DESCR_COMPL_AJ;
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;
			
			public double VL_BC_ICMS;
			
			public double ALIQ_ICMS;
			
			public double VL_ICMS;
			
			public double VL_OUTROS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD300
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string SUB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_DOC_INI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string NUM_DOC_FIN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			public double ALIQ_ICMS;
			
			public double DT_DOC;
			
			public double VL_OPR;
			
			public double VL_DESC;
			
			public double VL_SERV;
			
			public double VL_SEG;
			
			public double VL_OUT_DESP;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
			
			public double VL_RED_BC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COD_OBS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_CTA;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD301
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NUM_DOC_CANC;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD310
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_MUN_ORIG;
		
			public double VL_SERV;
			
			public double VL_BC_ICMS;
			
			public double VL_ICMS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD350
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string ECF_MOD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string ECF_FAB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string ECF_CX;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD355
		{
			public double DT_DOC;
			
			public int CRO;
			
			public int CRZ;
			
			public int NUM_COO_FIN;
			
			public double GT_FIN;
			
			public double VL_BRT;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD360
		{
			public double VL_PIS;
		
			public double VL_COFINS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoDRegistroD365
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_TOT_PAR;
		
			public double VLR_ACUM_TOT;
			
			public double NR_TOT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string DESCR_NR_TOT;
		}



		#endregion BlocoD

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
		public static extern int SPDF_Bloco_1_Registro1710New(IntPtr spdfHandle, Bloco1Registro1710 registro1710);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1800New(IntPtr spdfHandle, Bloco1Registro1800 registro1800);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_1_Registro1990_GetQTD_LIN_1(IntPtr spdfHandle);

		#endregion Bloco_1

		#region Bloco_9

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_GetDT_INI(IntPtr spdfHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_SetDT_INI(IntPtr spdfHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_GetDT_FIN(IntPtr spdfHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_SetDT_FIN(IntPtr spdfHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_GetGravado(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_Registro9001New(IntPtr spdfHandle, Bloco9Registro9001 registro9001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_Registro9900New(IntPtr spdfHandle, Bloco9Registro9900 registro9900);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_Registro9990_GetQTD_LIN_9(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_9_Registro9999_GetQTD_LIN(IntPtr spdfHandle);

		#endregion Bloco_9

		#region BlocoC

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_GetDT_INI(IntPtr spdfHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_SetDT_INI(IntPtr spdfHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_GetDT_FIN(IntPtr spdfHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_SetDT_FIN(IntPtr spdfHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_GetGravado(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC001New(IntPtr spdfHandle, BlocoCRegistroC001 registroC001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC100New(IntPtr spdfHandle, BlocoCRegistroC100 registroC100);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC110New(IntPtr spdfHandle, BlocoCRegistroC110 registroC110);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC105New(IntPtr spdfHandle, BlocoCRegistroC105 registroC105);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC111New(IntPtr spdfHandle, BlocoCRegistroC111 registroC111);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC112New(IntPtr spdfHandle, BlocoCRegistroC112 registroC112);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC113New(IntPtr spdfHandle, BlocoCRegistroC113 registroC113);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC114New(IntPtr spdfHandle, BlocoCRegistroC114 registroC114);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC115New(IntPtr spdfHandle, BlocoCRegistroC115 registroC115);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC116New(IntPtr spdfHandle, BlocoCRegistroC116 registroC116);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC120New(IntPtr spdfHandle, BlocoCRegistroC120 registroC120);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC130New(IntPtr spdfHandle, BlocoCRegistroC130 registroC130);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC140New(IntPtr spdfHandle, BlocoCRegistroC140 registroC140);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC141New(IntPtr spdfHandle, BlocoCRegistroC141 registroC141);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC160New(IntPtr spdfHandle, BlocoCRegistroC160 registroC160);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC165New(IntPtr spdfHandle, BlocoCRegistroC165 registroC165);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC170New(IntPtr spdfHandle, BlocoCRegistroC170 registroC170);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC171New(IntPtr spdfHandle, BlocoCRegistroC171 registroC171);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC172New(IntPtr spdfHandle, BlocoCRegistroC172 registroC172);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC173New(IntPtr spdfHandle, BlocoCRegistroC173 registroC173);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC174New(IntPtr spdfHandle, BlocoCRegistroC174 registroC174);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC175New(IntPtr spdfHandle, BlocoCRegistroC175 registroC175);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC176New(IntPtr spdfHandle, BlocoCRegistroC176 registroC176);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC177New(IntPtr spdfHandle, BlocoCRegistroC177 registroC177);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC178New(IntPtr spdfHandle, BlocoCRegistroC178 registroC178);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC179New(IntPtr spdfHandle, BlocoCRegistroC179 registroC179);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC190New(IntPtr spdfHandle, BlocoCRegistroC190 registroC190);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC195New(IntPtr spdfHandle, BlocoCRegistroC195 registroC195);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC197New(IntPtr spdfHandle, BlocoCRegistroC197 registroC197);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC300New(IntPtr spdfHandle, BlocoCRegistroC300 registroC300);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC310New(IntPtr spdfHandle, BlocoCRegistroC310 registroC310);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC320New(IntPtr spdfHandle, BlocoCRegistroC320 registroC320);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC321New(IntPtr spdfHandle, BlocoCRegistroC321 registroC321);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC350New(IntPtr spdfHandle, BlocoCRegistroC350 registroC350);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC370New(IntPtr spdfHandle, BlocoCRegistroC370 registroC370);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC390New(IntPtr spdfHandle, BlocoCRegistroC390 registroC390);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC400New(IntPtr spdfHandle, BlocoCRegistroC400 registroC400);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC405New(IntPtr spdfHandle, BlocoCRegistroC405 registroC405);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC410New(IntPtr spdfHandle, BlocoCRegistroC410 registroC410);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC420New(IntPtr spdfHandle, BlocoCRegistroC420 registroC420);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC425New(IntPtr spdfHandle, BlocoCRegistroC425 registroC425);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC460New(IntPtr spdfHandle, BlocoCRegistroC460 registroC460);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC470New(IntPtr spdfHandle, BlocoCRegistroC470 registroC470);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC490New(IntPtr spdfHandle, BlocoCRegistroC490 registroC490);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC495New(IntPtr spdfHandle, BlocoCRegistroC495 registroC495);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC500New(IntPtr spdfHandle, BlocoCRegistroC500 registroC500);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC510New(IntPtr spdfHandle, BlocoCRegistroC510 registroC510);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC590New(IntPtr spdfHandle, BlocoCRegistroC590 registroC590);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC600New(IntPtr spdfHandle, BlocoCRegistroC600 registroC600);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC601New(IntPtr spdfHandle, BlocoCRegistroC601 registroC601);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC610New(IntPtr spdfHandle, BlocoCRegistroC610 registroC610);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC690New(IntPtr spdfHandle, BlocoCRegistroC690 registroC690);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC700New(IntPtr spdfHandle, BlocoCRegistroC700 registroC700);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC790New(IntPtr spdfHandle, BlocoCRegistroC790 registroC790);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC791New(IntPtr spdfHandle, BlocoCRegistroC791 registroC791);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC800New(IntPtr spdfHandle, BlocoCRegistroC800 registroC800);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC850New(IntPtr spdfHandle, BlocoCRegistroC850 registroC850);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC860New(IntPtr spdfHandle, BlocoCRegistroC860 registroC860);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC890New(IntPtr spdfHandle, BlocoCRegistroC890 registroC890);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_C_RegistroC990_GetQTD_LIN_C(IntPtr spdfHandle);

		#endregion BlocoC

		#region Bloco_D

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_GetDT_INI(IntPtr spdfHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_SetDT_INI(IntPtr spdfHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_GetDT_FIN(IntPtr spdfHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_SetDT_FIN(IntPtr spdfHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_GetGravado(IntPtr spdfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD001New(IntPtr spdfHandle, BlocoDRegistroD001 registroD001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD100New(IntPtr spdfHandle, BlocoDRegistroD100 registroD100);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD110New(IntPtr spdfHandle, BlocoDRegistroD110 registroD110);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD120New(IntPtr spdfHandle, BlocoDRegistroD120 registroD120);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD130New(IntPtr spdfHandle, BlocoDRegistroD130 registroD130);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD140New(IntPtr spdfHandle, BlocoDRegistroD140 registroD140);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD150New(IntPtr spdfHandle, BlocoDRegistroD150 registroD150);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD160New(IntPtr spdfHandle, BlocoDRegistroD160 registroD160);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD161New(IntPtr spdfHandle, BlocoDRegistroD161 registroD161);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD162New(IntPtr spdfHandle, BlocoDRegistroD162 registroD162);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD170New(IntPtr spdfHandle, BlocoDRegistroD170 registroD170);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD180New(IntPtr spdfHandle, BlocoDRegistroD180 registroD180);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD190New(IntPtr spdfHandle, BlocoDRegistroD190 registroD190);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD195New(IntPtr spdfHandle, BlocoDRegistroD195 registroD195);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD197New(IntPtr spdfHandle, BlocoDRegistroD197 registroD197);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD300New(IntPtr spdfHandle, BlocoDRegistroD300 registroD300);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD301New(IntPtr spdfHandle, BlocoDRegistroD301 registroD301);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD310New(IntPtr spdfHandle, BlocoDRegistroD310 registroD310);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD350New(IntPtr spdfHandle, BlocoDRegistroD350 registroD350);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD355New(IntPtr spdfHandle, BlocoDRegistroD355 registroD355);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD360New(IntPtr spdfHandle, BlocoDRegistroD360 registroD360);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD365New(IntPtr spdfHandle, BlocoDRegistroD365 registroD365);


		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SPDF_Bloco_D_RegistroD990_GetQTD_LIN_D(IntPtr spdfHandle);

		#endregion Bloco_9

		#endregion Metodos

		#endregion ACBrSPEDFiscal
	}
}