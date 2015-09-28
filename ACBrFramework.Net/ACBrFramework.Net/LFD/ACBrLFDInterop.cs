using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.LFD
{
	public static class ACBrLFDInterop
	{
		#region InnerTypes

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void StringCallback(string Mensagem);

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
			public int COD_CONTEUDO;     /// Perfil de apresentação do arquivo fiscal: A - Perfil A / B - Perfil B / C - Perfil C

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string FANTASIA;      /// Nome de fantasia associado ao nome empresarial
											
			[MarshalAs(UnmanagedType.I4)]
			public int NIRE;			/// Número de Identificação do Registro de Empresas da Junta Comercial
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0005
		{	
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string NOMERESP;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_ASS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPFRESP;     /// Nome de fantasia associado:

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

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CEP_CP;    

			[MarshalAs(UnmanagedType.I4)]
			public int CP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FONE;     /// Número do telefone:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FAX;     /// Número do fax:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 151)]
			public string EMAIL;     /// Endereço do correio eletrônico:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0025
		{
			[MarshalAs(UnmanagedType.I4)]
			public int CODBF_ICMS;

			[MarshalAs(UnmanagedType.I4)]
			public int CODBF_ISS;   
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

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CEP_CP;         /// Código de Endereçamento Postal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CP;         /// Caixa postal

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string ENDERECO;        /// Logradouro e endereço do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string NUM;        /// Número do imóvel:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COMPL;        /// Dados complementares do endereço:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string BAIRRO;        /// Bairro em que o imóvel está situado:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string UF;        /// UF

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FONE;        /// Número do telefone:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FAX;        /// Número do fax:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 151)]
			public string EMAIL;       /// Endereço do correio eletrônico:

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;                     /// Código do município, conforme tabela IBGE:
													/// 
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string COD_ASS;                     ///  Código de qualificação do assinante:
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
			public string IE_ST;           /// Inscrição Estadual do participante emitente contribuinte-substituto na unidade da Federação do destinatário substituído
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;           /// Inscrição Estadual do participante:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IM;           /// Inscrição Municipal

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

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string UF;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0175
		{
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

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public string CEP_CP;         /// Código de Endereçamento Postal:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
			public int CP;         /// Caixa postal
			
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FONE;        /// Número do telefone:

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string FAX;        /// Número do fax:
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0200
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 201)]
			public string DESCR_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_GEN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string COD_LST;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0205
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 201)]
			public string DESCR_ANT_ITEM;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_INI;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_FIN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ANT_ITEM;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Bloco0Registro0210
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM_COMP;

			[MarshalAs(UnmanagedType.R8)]
			public double QTD_COMP;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UNID_COMP;

			[MarshalAs(UnmanagedType.R8)]
			public double PERDA_COMP;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_INI_COMP;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_FIN_COMP;

			[MarshalAs(UnmanagedType.I4)]
			public int IND_ALT;
		}

		#endregion Bloco0

		#region BlocoA

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoARegistroA001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoARegistroA350
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF_CONS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CONS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_SIT;

			[MarshalAs(UnmanagedType.I4)]
			public int ECF_CX;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string ECF_FAB;

			[MarshalAs(UnmanagedType.I4)]
			public int CRO;

			[MarshalAs(UnmanagedType.I4)]
			public int CRZ;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_DOC;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string COP;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DOC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISN_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_NT_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_RET_ISS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoARegistroA360
		{
			[MarshalAs(UnmanagedType.I4)]
			public int NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string UNID;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_UNIT;

			[MarshalAs(UnmanagedType.R8)]
			public double QTD;

			[MarshalAs(UnmanagedType.I4)]
			public int QTDCANC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string CTISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ISS_I;

			[MarshalAs(UnmanagedType.R8)]
			public double ALIQ_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISS_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISN_ISS_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_NT_ISS_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_RT_ISS_I;
		}

		#endregion BlocoA

		#region BlocoC

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC001
		{
			[MarshalAs(UnmanagedType.I4)]
			public int IND_MOV;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_MUN;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC020
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

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string SER;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 45)]
			public string CHV_NFE;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_EMIS;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string COD_NAT;

			[MarshalAs(UnmanagedType.I4)]
			public int IND_PGTO;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DOC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_MERC;

			[MarshalAs(UnmanagedType.I4)]
			public int IND_FRT;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_FRT;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_SEG;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_OUT_DA;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ST;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS_ST;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_AT;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_IPI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string COD_INF_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC550
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF_CONS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CONS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_SIT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string SER;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string SUB;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_DOC;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COP;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DOC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_MERC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_INF_OBS;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC555
		{
			[MarshalAs(UnmanagedType.I4)]
			public int NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string UNID;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_UNIT;

			[MarshalAs(UnmanagedType.R8)]
			public double QTD;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ICMS_I;

			[MarshalAs(UnmanagedType.R8)]
			public double ALIQ_ICMS;
			
			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS_I;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC600
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF_CONS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CONS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string COD_MOD;

			[MarshalAs(UnmanagedType.I4)]
			public int COD_SIT;

			[MarshalAs(UnmanagedType.I4)]
			public int ECF_CX;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string ECF_FAB;

			[MarshalAs(UnmanagedType.I4)]
			public int CRO;

			[MarshalAs(UnmanagedType.I4)]
			public int CRZ;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_DOC;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_DOC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string COP;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DOC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISN;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_NT;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ST;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS_ST;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BlocoCRegistroC605
		{
			[MarshalAs(UnmanagedType.I4)]
			public int NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string UNID;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_UNIT;

			[MarshalAs(UnmanagedType.R8)]
			public double QTD;

			[MarshalAs(UnmanagedType.R8)]
			public double QTD_CANC_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ITEM;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESC_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACMO_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISS;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BC_ICMS_I;

			[MarshalAs(UnmanagedType.R8)]
			public double ALIQ_ICMS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISN_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_NT_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ST_I;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ICMS_ST_I;
		}

		#endregion BlocoC


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



		#endregion InnerTypes

		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrLFD

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Create(ref IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Destroy(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetUltimoErro(IntPtr lfdHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetAbout(IntPtr lfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetArquivo(IntPtr lfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetArquivo(IntPtr lfdHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetCurMascara(IntPtr lfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetCurMascara(IntPtr lfdHandle, string mascara);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetPath(IntPtr lfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetPath(IntPtr lfdHandle, string path);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetDelimitador(IntPtr lfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetDelimitador(IntPtr lfdHandle, string delimitador);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetLinhasBuffer(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetLinhasBuffer(IntPtr lfdHandle, int linhas);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetTrimString(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetTrimString(IntPtr lfdHandle, bool trim);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetDT_INI(IntPtr lfdHandle, ref double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetDT_INI(IntPtr lfdHandle, double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_GetDT_FIN(IntPtr lfdHandle, ref double data);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetDT_FIN(IntPtr lfdHandle, double data);

		#endregion Propriedades do Componente

		#region Metodos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SaveFileTXT(IntPtr lfdHandle);

		#region Bloco0

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_GetDT_INI(IntPtr lfdHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_SetDT_INI(IntPtr lfdHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_GetDT_FIN(IntPtr lfdHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_SetDT_FIN(IntPtr lfdHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_GetGravado(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0000New(IntPtr lfdHandle, Bloco0Registro0000 registro0000);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0001New(IntPtr lfdHandle, Bloco0Registro0001 registro0001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0005New(IntPtr lfdHandle, Bloco0Registro0005 registro0005);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0025New(IntPtr lfdHandle, Bloco0Registro0025 registro0025);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0100New(IntPtr lfdHandle, Bloco0Registro0100 registro0100);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0150New(IntPtr lfdHandle, Bloco0Registro0150 registro0150);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0175New(IntPtr lfdHandle, Bloco0Registro0175 registro0175);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0200New(IntPtr lfdHandle, Bloco0Registro0200 registro0200);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0205New(IntPtr lfdHandle, Bloco0Registro0205 registro0205);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0210New(IntPtr lfdHandle, Bloco0Registro0210 registro0210);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_0_Registro0990_GetQTD_LIN_0(IntPtr lfdHandle);

		#endregion Bloco0

		#region BlocoA

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_GetDT_INI(IntPtr lfdHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_SetDT_INI(IntPtr lfdHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_GetDT_FIN(IntPtr lfdHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_SetDT_FIN(IntPtr lfdHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_GetGravado(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_RegistroA001New(IntPtr lfdHandle, BlocoARegistroA001 registroA001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_RegistroA350New(IntPtr lfdHandle, BlocoARegistroA350 registroA350);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_RegistroA360New(IntPtr lfdHandle, BlocoARegistroA360 registroA360);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_A_RegistroA990_GetQTD_LIN_A(IntPtr lfdHandle);

		#endregion BlocoA

		#region BlocoC

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_GetDT_INI(IntPtr lfdHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_SetDT_INI(IntPtr lfdHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_GetDT_FIN(IntPtr lfdHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_SetDT_FIN(IntPtr lfdHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_GetGravado(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_RegistroC001New(IntPtr lfdHandle, BlocoCRegistroC001 registroC001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_RegistroC020New(IntPtr lfdHandle, BlocoCRegistroC020 registroC020);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_RegistroC550New(IntPtr lfdHandle, BlocoCRegistroC550 registroC550);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_RegistroC555New(IntPtr lfdHandle, BlocoCRegistroC555 registroC555);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_RegistroC600New(IntPtr lfdHandle, BlocoCRegistroC600 registroC600);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_RegistroC605New(IntPtr lfdHandle, BlocoCRegistroC605 registroC605);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_C_RegistroC990_GetQTD_LIN_C(IntPtr lfdHandle);

		#endregion BlocoC

		#region Bloco9

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_GetDT_INI(IntPtr lfdHandle, ref double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_SetDT_INI(IntPtr lfdHandle, double dtIni);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_GetDT_FIN(IntPtr lfdHandle, ref double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_SetDT_FIN(IntPtr lfdHandle, double dtFin);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_GetGravado(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_Registro9001New(IntPtr lfdHandle, Bloco9Registro9001 registro9001);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_Registro9900New(IntPtr lfdHandle, Bloco9Registro9900 registro9900);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_Registro9990_GetQTD_LIN_9(IntPtr lfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_Bloco_9_Registro9999_GetQTD_LIN(IntPtr lfdHandle);

		#endregion Bloco9

		#region EventHandlers

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int LFD_SetOnError(IntPtr lfdHandle, StringCallback method);

		#endregion EventHandlers

		#endregion Metodos

		#endregion ACBrLFD
	}
}