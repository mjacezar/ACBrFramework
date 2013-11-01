using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.PAF
{
	public static class ACBrPAFInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrPAF

		#region Interop Types

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string PAFGetKeyRSACallback();

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroHD1Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string RAZAOSOCIAL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IM;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroHD2Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string RAZAOSOCIAL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string UF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NUM_FAB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string MF_ADICIONAL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string TIPO_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string MARCA_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string MODELO_ECF;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_EST;

			[MarshalAs(UnmanagedType.U1)]
			public bool InclusaoExclusao;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroB2Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string BOMBA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string BICO;

			[MarshalAs(UnmanagedType.R8)]
			public double DATA;

			[MarshalAs(UnmanagedType.R8)]
			public double HORA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string MOTIVO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_EMPRESA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
			public string CPF_TECNICO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string NRO_LACRE_ANTES;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string NRO_LACRE_APOS;

			[MarshalAs(UnmanagedType.R8)]
			public double ENCERRANTE_ANTES;

			[MarshalAs(UnmanagedType.R8)]
			public double ENCERRANTE_APOS;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroC2Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string ID_ABASTECIMENTO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string TANQUE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string BOMBA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string BICO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string COMBUSTIVEL;

			[MarshalAs(UnmanagedType.R8)]
			public double DATA_ABASTECIMENTO;

			[MarshalAs(UnmanagedType.R8)]
			public double HORA_ABASTECIMENTO;

			[MarshalAs(UnmanagedType.R8)]
			public double ENCERRANTE_INICIAL;

			[MarshalAs(UnmanagedType.R8)]
			public double ENCERRANTE_FINAL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string STATUS_ABASTECIMENTO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string NRO_SERIE_ECF;

			[MarshalAs(UnmanagedType.R8)]
			public double DATA;

			[MarshalAs(UnmanagedType.R8)]
			public double HORA;

			[MarshalAs(UnmanagedType.I4)]
			public int COO;

			[MarshalAs(UnmanagedType.I4)]
			public int NRO_NOTA_FISCAL;

			[MarshalAs(UnmanagedType.R8)]
			public double VOLUME;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroD2Rec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int QTD_D3;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NUM_FAB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string MF_ADICIONAL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string TIPO_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string MARCA_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string MODELO_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string NUM_DAV;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_DAV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
			public string TIT_DAV;

			[MarshalAs(UnmanagedType.R8)]
			public double VLT_DAV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string COO_DFV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string NUMERO_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
			public string NOME_CLIENTE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPF_CNPJ;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroD3Rec
		{
			[MarshalAs(UnmanagedType.R8)]
			public double DT_INCLUSAO;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string DESC_ITEM;

			[MarshalAs(UnmanagedType.R8)]
			public double QTDE_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string UNI_ITEM;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_UNIT;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_DESCTO;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACRES;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_TOTAL;

			[MarshalAs(UnmanagedType.I4)]
			public int DEC_VL_UNIT;

			[MarshalAs(UnmanagedType.I4)]
			public int DEC_QTDE_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string SIT_TRIB;

			[MarshalAs(UnmanagedType.R8)]
			public double ALIQ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_CANC;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroE2Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string COD_MERC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string DESC_MERC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UN_MED;

			[MarshalAs(UnmanagedType.R8)]
			public double QTDE_EST;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroH2Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CRED_CARTAO;

			[MarshalAs(UnmanagedType.I4)]
			public int COO;

			[MarshalAs(UnmanagedType.I4)]
			public int CCF;

			[MarshalAs(UnmanagedType.R8)]
			public double VLR_TROCO;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_TROCO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CPF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string Titulo;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroN2Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string LAUDO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string NOME;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string VERSAO;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroN3Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string NOME_ARQUIVO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
			public string MD5;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroP2Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string COD_MERC_SERV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
			public string DESC_MERC_SERV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
			public string UN_MED;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IAT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IPPT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string ST;

			[MarshalAs(UnmanagedType.R8)]
			public double ALIQ;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_UNIT;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroR1Rec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int QTD_R2;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NUM_FAB;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string MF_ADICIONAL;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string TIPO_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string MARCA_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string MODELO_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string VERSAO_SB;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_INST_SB;

			[MarshalAs(UnmanagedType.R8)]
			public double HR_INST_SB;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_SEQ_ECF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_SH;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IE_SH;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string IM_SH;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
			public string NOME_SH;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
			public string NOME_PAF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string VER_PAF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
			public string COD_MD5;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_INI;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_FIN;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string ER_PAF_ECF;

			[MarshalAs(UnmanagedType.U1)]
			public bool InclusaoExclusao;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroR2Rec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int QTD_R3;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_USU;

			[MarshalAs(UnmanagedType.I4)]
			public int CRZ;

			[MarshalAs(UnmanagedType.I4)]
			public int COO;

			[MarshalAs(UnmanagedType.I4)]
			public int CRO;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_MOV;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_EMI;

			[MarshalAs(UnmanagedType.R8)]
			public double HR_EMI;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_VBD;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string PAR_ECF;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroR3Rec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string TOT_PARCIAL;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ACUM;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroR4Rec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int QTD_R5;

			[MarshalAs(UnmanagedType.I4)]
			public int QTD_R7;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_USU;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_CONT;

			[MarshalAs(UnmanagedType.I4)]
			public int COO;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_INI;

			[MarshalAs(UnmanagedType.R8)]
			public double SUB_DOCTO;

			[MarshalAs(UnmanagedType.R8)]
			public double SUB_DESCTO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string TP_DESCTO;

			[MarshalAs(UnmanagedType.R8)]
			public double SUB_ACRES;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string TP_ACRES;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_TOT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string CANC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string ORDEM_DA;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
			public string NOME_CLI;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string CNPJ_CPF;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroR5Rec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int NUM_CONT;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string COD_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string DESC_ITEM;

			[MarshalAs(UnmanagedType.R8)]
			public double QTDE_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string UN_MED;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_UNIT;

			[MarshalAs(UnmanagedType.R8)]
			public double DESCTO_ITEM;

			[MarshalAs(UnmanagedType.R8)]
			public double ACRES_ITEM;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_TOT_ITEM;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string COD_TOT_PARC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_CANC;

			[MarshalAs(UnmanagedType.R8)]
			public double QTDE_CANC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CANC_ACRES;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IAT;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IPPT;

			[MarshalAs(UnmanagedType.I4)]
			public int QTDE_DECIMAL;

			[MarshalAs(UnmanagedType.I4)]
			public int VL_DECIMAL;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;			
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroR6Rec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int QTD_R7;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_USU;

			[MarshalAs(UnmanagedType.I4)]
			public int COO;

			[MarshalAs(UnmanagedType.I4)]
			public int GNF;

			[MarshalAs(UnmanagedType.I4)]
			public int GRG;

			[MarshalAs(UnmanagedType.I4)]
			public int CDC;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string DENOM;

			[MarshalAs(UnmanagedType.R8)]
			public double DT_FIN;

			[MarshalAs(UnmanagedType.R8)]
			public double HR_FIN;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroR7Rec
		{
			[MarshalAs(UnmanagedType.I4)]
			public int CCF;

			[MarshalAs(UnmanagedType.I4)]
			public int GNF;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string MP;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_PAGTO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
			public string IND_EST;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_EST;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroT2Rec
		{
			[MarshalAs(UnmanagedType.R8)]
			public double DT_MOV;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
			public string TP_DOCTO;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
			public string SERIE;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_BILH_I;

			[MarshalAs(UnmanagedType.I4)]
			public int NUM_BILH_F;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
			public string NUM_ECF;

			[MarshalAs(UnmanagedType.I4)]
			public int CRZ;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
			public string CFOP;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_CONT;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_BASECALC;

			[MarshalAs(UnmanagedType.R8)]
			public double ALIQ;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_IMPOSTO;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_ISENTAS;

			[MarshalAs(UnmanagedType.R8)]
			public double VL_OUTRAS;

			[MarshalAs(UnmanagedType.U1)]
			public bool RegistroValido;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroMercadoriasRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string Descricao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

			[MarshalAs(UnmanagedType.R8)]
			public double Aliquota;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Unidade;

			[MarshalAs(UnmanagedType.R8)]
			public double Quantidade;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string Ean;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST;

			[MarshalAs(UnmanagedType.R8)]
			public double VlrUnitario;

			[MarshalAs(UnmanagedType.I4)]
			public int QTD_Insumos;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RegistroInsumosRec
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
			public string Descricao;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
			public string Codigo;

			[MarshalAs(UnmanagedType.R8)]
			public double Aliquota;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string Unidade;

			[MarshalAs(UnmanagedType.R8)]
			public double Quantidade;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string Ean;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
			public string CST;

			[MarshalAs(UnmanagedType.R8)]
			public double VlrUnitario;
		}

		#endregion Interop Types

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_Create(ref IntPtr pafHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_Destroy(IntPtr pafHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_GetUltimoErro(IntPtr pafHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Propriedades do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_GetPath(IntPtr pafHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetPath(IntPtr pafHandle, string porta);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_GetDelimitador(IntPtr pafHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetDelimitador(IntPtr pafHandle, string Delimitador);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_GetCurMascara(IntPtr pafHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetCurMascara(IntPtr pafHandle, string CurMascara);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_GetTrimString(IntPtr pafHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetTrimString(IntPtr pafHandle, bool TrimString);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_GetAssinarArquivo(IntPtr pafHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetAssinarArquivo(IntPtr pafHandle, bool Assinar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetAAC(IntPtr pafHandle, IntPtr aacHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetEAD(IntPtr pafHandle, IntPtr eadHandle);

		#endregion Propriedades do Componente

		#region Methods

		#region SaveFile

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_B(IntPtr pafHandle, RegistroHD1Rec RegistroB1, RegistroB2Rec[] RegistroB2, int CountB2, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_C(IntPtr pafHandle, RegistroHD1Rec RegistroC1, RegistroC2Rec[] RegistroC2, int CountC2, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_D(IntPtr pafHandle, RegistroHD1Rec RegistroD1, RegistroD2Rec[] RegistroD2, int CountD2, RegistroD3Rec[] RegistroD3, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_E(IntPtr pafHandle, RegistroHD2Rec RegistroE1, RegistroE2Rec[] RegistroE2, int CountE2, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_H(IntPtr pafHandle, RegistroHD2Rec RegistroH1, RegistroH2Rec[] RegistroH2, int CountH2, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_N(IntPtr pafHandle, RegistroHD1Rec RegistroN1, RegistroN2Rec RegistroN2, RegistroN3Rec[] RegistroN3, int CountN3, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_P(IntPtr pafHandle, RegistroHD1Rec RegistroP1, RegistroP2Rec[] RegistroP2, int CountP2, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_R(IntPtr pafHandle, RegistroR1Rec[] RegistroR1, int CountR1, RegistroR2Rec[] RegistroR2, int CountR2, RegistroR3Rec[] RegistroR3, int CountR3, RegistroR4Rec[] RegistroR4, int CountR4, RegistroR5Rec[] RegistroR5, int CountR5, RegistroR6Rec[] RegistroR6, int CountR6, RegistroR7Rec[] RegistroR7, int CountR7, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_T(IntPtr pafHandle, RegistroHD1Rec RegistroT1, RegistroT2Rec[] RegistroT2, int CountT2, string Arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SaveFileTXT_TITP(IntPtr pafHandle, RegistroMercadoriasRec[] RegistroMercadorias, int Count, RegistroInsumosRec[] RegistroInsumos, string Arquivo, string titulo, double data);

		#endregion SaveFile

		#region Metodos ACBrPAF

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_AssinarArquivoComEAD(IntPtr eadHandle, String Arquivo);

		#endregion Metodos ACBrPAF

		#region Eventos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int PAF_SetOnPAFGetKeyRSA(IntPtr eadHandle, PAFGetKeyRSACallback method);

		#endregion Eventos

		#endregion Methods

		#endregion ACBrPAF
	}
}