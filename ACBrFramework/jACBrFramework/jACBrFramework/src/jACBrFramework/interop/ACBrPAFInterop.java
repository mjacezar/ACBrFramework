/**
* ACBrFramework DefExporter
* Este arquivo foi gerado automaticamente - não altere
* This file was generated automatically - don't change it.
**/


package jACBrFramework.interop;
import jACBrFramework.InteropLib;
import com.sun.jna.*;
import com.sun.jna.ptr.*;
import java.nio.ByteBuffer;
import java.util.Arrays;
import java.util.List;


public interface ACBrPAFInterop extends InteropLib
{
	public static final ACBrPAFInterop INSTANCE = (ACBrPAFInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrPAFInterop.class);

	// Tipos de dados

	public interface PAFGetKeyRSACallback extends Callback
	{
		String invoke();
	}


	public static class RegistroB2Rec extends Structure
	{
		public char[] BOMBA = new char[4];
		public char[] BICO = new char[4];
		public double DATA;
		public double HORA;
		public char[] MOTIVO = new char[51];
		public char[] CNPJ_EMPRESA = new char[15];
		public char[] CPF_TECNICO = new char[12];
		public char[] NRO_LACRE_ANTES = new char[16];
		public char[] NRO_LACRE_APOS = new char[16];
		public double ENCERRANTE_ANTES;
		public double ENCERRANTE_APOS;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("BOMBA" , "BICO" , "DATA" , "HORA" , "MOTIVO" , "CNPJ_EMPRESA" , "CPF_TECNICO" , "NRO_LACRE_ANTES" , "NRO_LACRE_APOS" , "ENCERRANTE_ANTES" , "ENCERRANTE_APOS" , "RegistroValido");
		}


		public static class ByReference extends RegistroB2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroB2Rec implements Structure.ByValue{ }
	}

	public static class RegistroC2Rec extends Structure
	{
		public char[] ID_ABASTECIMENTO = new char[16];
		public char[] TANQUE = new char[4];
		public char[] BOMBA = new char[4];
		public char[] BICO = new char[4];
		public char[] COMBUSTIVEL = new char[21];
		public double DATA_ABASTECIMENTO;
		public double HORA_ABASTECIMENTO;
		public double ENCERRANTE_INICIAL;
		public double ENCERRANTE_FINAL;
		public char[] STATUS_ABASTECIMENTO = new char[11];
		public char[] NRO_SERIE_ECF = new char[15];
		public double DATA;
		public double HORA;
		public int COO;
		public int NRO_NOTA_FISCAL;
		public double VOLUME;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("ID_ABASTECIMENTO" , "TANQUE" , "BOMBA" , "BICO" , "COMBUSTIVEL" , "DATA_ABASTECIMENTO" , "HORA_ABASTECIMENTO" , "ENCERRANTE_INICIAL" , "ENCERRANTE_FINAL" , "STATUS_ABASTECIMENTO" , "NRO_SERIE_ECF" , "DATA" , "HORA" , "COO" , "NRO_NOTA_FISCAL" , "VOLUME" , "RegistroValido");
		}


		public static class ByReference extends RegistroC2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroC2Rec implements Structure.ByValue{ }
	}

	public static class RegistroD2Rec extends Structure
	{
		public int QTD_D3;
		public char[] NUM_FAB = new char[21];
		public char[] MF_ADICIONAL = new char[2];
		public char[] TIPO_ECF = new char[8];
		public char[] MARCA_ECF = new char[21];
		public char[] MODELO_ECF = new char[21];
		public char[] COO = new char[7];
		public char[] NUM_DAV = new char[14];
		public double DT_DAV;
		public char[] TIT_DAV = new char[31];
		public double VLT_DAV;
		public char[] COO_DFV = new char[7];
		public char[] NUMERO_ECF = new char[4];
		public char[] NOME_CLIENTE = new char[41];
		public char[] CPF_CNPJ = new char[15];
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("QTD_D3" , "NUM_FAB" , "MF_ADICIONAL" , "TIPO_ECF" , "MARCA_ECF" , "MODELO_ECF" , "COO" , "NUM_DAV" , "DT_DAV" , "TIT_DAV" , "VLT_DAV" , "COO_DFV" , "NUMERO_ECF" , "NOME_CLIENTE" , "CPF_CNPJ" , "RegistroValido");
		}


		public static class ByReference extends RegistroD2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroD2Rec implements Structure.ByValue{ }
	}

	public static class RegistroD3Rec extends Structure
	{
		public double DT_INCLUSAO;
		public int NUM_ITEM;
		public char[] COD_ITEM = new char[15];
		public char[] DESC_ITEM = new char[101];
		public double QTDE_ITEM;
		public char[] UNI_ITEM = new char[4];
		public double VL_UNIT;
		public double VL_DESCTO;
		public double VL_ACRES;
		public double VL_TOTAL;
		public int DEC_VL_UNIT;
		public int DEC_QTDE_ITEM;
		public char[] SIT_TRIB = new char[2];
		public double ALIQ;
		public char[] IND_CANC = new char[2];
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("DT_INCLUSAO" , "NUM_ITEM" , "COD_ITEM" , "DESC_ITEM" , "QTDE_ITEM" , "UNI_ITEM" , "VL_UNIT" , "VL_DESCTO" , "VL_ACRES" , "VL_TOTAL" , "DEC_VL_UNIT" , "DEC_QTDE_ITEM" , "SIT_TRIB" , "ALIQ" , "IND_CANC" , "RegistroValido");
		}


		public static class ByReference extends RegistroD3Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroD3Rec implements Structure.ByValue{ }
	}

	public static class RegistroE2Rec extends Structure
	{
		public char[] COD_MERC = new char[15];
		public char[] DESC_MERC = new char[51];
		public char[] UN_MED = new char[7];
		public double QTDE_EST;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("COD_MERC" , "DESC_MERC" , "UN_MED" , "QTDE_EST" , "RegistroValido");
		}


		public static class ByReference extends RegistroE2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroE2Rec implements Structure.ByValue{ }
	}

	public static class RegistroH2Rec extends Structure
	{
		public char[] CNPJ_CRED_CARTAO = new char[15];
		public int COO;
		public int CCF;
		public double VLR_TROCO;
		public double DT_TROCO;
		public char[] CPF = new char[15];
		public char[] Titulo = new char[8];
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CNPJ_CRED_CARTAO" , "COO" , "CCF" , "VLR_TROCO" , "DT_TROCO" , "CPF" , "Titulo" , "RegistroValido");
		}


		public static class ByReference extends RegistroH2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroH2Rec implements Structure.ByValue{ }
	}

	public static class RegistroHD1Rec extends Structure
	{
		public char[] RAZAOSOCIAL = new char[51];
		public char[] UF = new char[3];
		public char[] CNPJ = new char[15];
		public char[] IE = new char[15];
		public char[] IM = new char[15];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("RAZAOSOCIAL" , "UF" , "CNPJ" , "IE" , "IM");
		}


		public static class ByReference extends RegistroHD1Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroHD1Rec implements Structure.ByValue{ }
	}

	public static class RegistroHD2Rec extends Structure
	{
		public char[] RAZAOSOCIAL = new char[51];
		public char[] UF = new char[3];
		public char[] CNPJ = new char[15];
		public char[] IE = new char[15];
		public char[] IM = new char[15];
		public char[] NUM_FAB = new char[21];
		public char[] MF_ADICIONAL = new char[2];
		public char[] TIPO_ECF = new char[8];
		public char[] MARCA_ECF = new char[21];
		public char[] MODELO_ECF = new char[21];
		public double DT_EST;
		public boolean RegistroValido;
		public boolean InclusaoExclusao;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("RAZAOSOCIAL" , "UF" , "CNPJ" , "IE" , "IM" , "NUM_FAB" , "MF_ADICIONAL" , "TIPO_ECF" , "MARCA_ECF" , "MODELO_ECF" , "DT_EST" , "RegistroValido" , "InclusaoExclusao");
		}


		public static class ByReference extends RegistroHD2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroHD2Rec implements Structure.ByValue{ }
	}

	public static class RegistroInsumosRec extends Structure
	{
		public char[] Descricao = new char[101];
		public char[] Codigo = new char[15];
		public double Aliquota;
		public char[] Unidade = new char[4];
		public double Quantidade;
		public char[] Ean = new char[14];
		public char[] CST = new char[4];
		public double VlrUnitario;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Descricao" , "Codigo" , "Aliquota" , "Unidade" , "Quantidade" , "Ean" , "CST" , "VlrUnitario");
		}


		public static class ByReference extends RegistroInsumosRec implements Structure.ByReference{ }
		public static class ByValue extends RegistroInsumosRec implements Structure.ByValue{ }
	}

	public static class RegistroMercadoriasRec extends Structure
	{
		public char[] Descricao = new char[101];
		public char[] Codigo = new char[15];
		public double Aliquota;
		public char[] Unidade = new char[4];
		public double Quantidade;
		public char[] Ean = new char[14];
		public char[] CST = new char[4];
		public double VlrUnitario;
		public int QTD_Insumos;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Descricao" , "Codigo" , "Aliquota" , "Unidade" , "Quantidade" , "Ean" , "CST" , "VlrUnitario" , "QTD_Insumos");
		}


		public static class ByReference extends RegistroMercadoriasRec implements Structure.ByReference{ }
		public static class ByValue extends RegistroMercadoriasRec implements Structure.ByValue{ }
	}

	public static class RegistroN2Rec extends Structure
	{
		public char[] LAUDO = new char[11];
		public char[] NOME = new char[51];
		public char[] VERSAO = new char[11];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("LAUDO" , "NOME" , "VERSAO");
		}


		public static class ByReference extends RegistroN2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroN2Rec implements Structure.ByValue{ }
	}

	public static class RegistroN3Rec extends Structure
	{
		public char[] NOME_ARQUIVO = new char[51];
		public char[] MD5 = new char[33];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("NOME_ARQUIVO" , "MD5");
		}


		public static class ByReference extends RegistroN3Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroN3Rec implements Structure.ByValue{ }
	}

	public static class RegistroP2Rec extends Structure
	{
		public char[] COD_MERC_SERV = new char[15];
		public char[] DESC_MERC_SERV = new char[51];
		public char[] UN_MED = new char[7];
		public char[] IAT = new char[2];
		public char[] IPPT = new char[2];
		public char[] ST = new char[2];
		public double ALIQ;
		public double VL_UNIT;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("COD_MERC_SERV" , "DESC_MERC_SERV" , "UN_MED" , "IAT" , "IPPT" , "ST" , "ALIQ" , "VL_UNIT" , "RegistroValido");
		}


		public static class ByReference extends RegistroP2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroP2Rec implements Structure.ByValue{ }
	}

	public static class RegistroR1Rec extends Structure
	{
		public char[] NUM_FAB = new char[21];
		public char[] MF_ADICIONAL = new char[2];
		public char[] TIPO_ECF = new char[8];
		public char[] MARCA_ECF = new char[21];
		public char[] MODELO_ECF = new char[21];
		public char[] VERSAO_SB = new char[11];
		public double DT_INST_SB;
		public double HR_INST_SB;
		public int NUM_SEQ_ECF;
		public char[] CNPJ = new char[15];
		public char[] IE = new char[15];
		public char[] CNPJ_SH = new char[15];
		public char[] IE_SH = new char[15];
		public char[] IM_SH = new char[15];
		public char[] NOME_SH = new char[41];
		public char[] NOME_PAF = new char[41];
		public char[] VER_PAF = new char[11];
		public char[] COD_MD5 = new char[33];
		public double DT_INI;
		public double DT_FIN;
		public char[] ER_PAF_ECF = new char[5];
		public boolean InclusaoExclusao;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("NUM_FAB" , "MF_ADICIONAL" , "TIPO_ECF" , "MARCA_ECF" , "MODELO_ECF" , "VERSAO_SB" , "DT_INST_SB" , "HR_INST_SB" , "NUM_SEQ_ECF" , "CNPJ" , "IE" , "CNPJ_SH" , "IE_SH" , "IM_SH" , "NOME_SH" , "NOME_PAF" , "VER_PAF" , "COD_MD5" , "DT_INI" , "DT_FIN" , "ER_PAF_ECF" , "InclusaoExclusao" , "RegistroValido");
		}


		public static class ByReference extends RegistroR1Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroR1Rec implements Structure.ByValue{ }
	}

	public static class RegistroR2Rec extends Structure
	{
		public int QTD_R3;
		public int NUM_USU;
		public int CRZ;
		public int COO;
		public int CRO;
		public double DT_MOV;
		public double DT_EMI;
		public double HR_EMI;
		public double VL_VBD;
		public char[] PAR_ECF = new char[2];
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("QTD_R3" , "NUM_USU" , "CRZ" , "COO" , "CRO" , "DT_MOV" , "DT_EMI" , "HR_EMI" , "VL_VBD" , "PAR_ECF" , "RegistroValido");
		}


		public static class ByReference extends RegistroR2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroR2Rec implements Structure.ByValue{ }
	}

	public static class RegistroR3Rec extends Structure
	{
		public char[] TOT_PARCIAL = new char[8];
		public double VL_ACUM;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("TOT_PARCIAL" , "VL_ACUM" , "RegistroValido");
		}


		public static class ByReference extends RegistroR3Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroR3Rec implements Structure.ByValue{ }
	}

	public static class RegistroR4Rec extends Structure
	{
		public int QTD_R5;
		public int QTD_R7;
		public int NUM_USU;
		public int NUM_CONT;
		public int COO;
		public double DT_INI;
		public double SUB_DOCTO;
		public double SUB_DESCTO;
		public char[] TP_DESCTO = new char[2];
		public double SUB_ACRES;
		public char[] TP_ACRES = new char[2];
		public double VL_TOT;
		public char[] CANC = new char[2];
		public double VL_CA;
		public char[] ORDEM_DA = new char[2];
		public char[] NOME_CLI = new char[41];
		public char[] CNPJ_CPF = new char[15];
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("QTD_R5" , "QTD_R7" , "NUM_USU" , "NUM_CONT" , "COO" , "DT_INI" , "SUB_DOCTO" , "SUB_DESCTO" , "TP_DESCTO" , "SUB_ACRES" , "TP_ACRES" , "VL_TOT" , "CANC" , "VL_CA" , "ORDEM_DA" , "NOME_CLI" , "CNPJ_CPF" , "RegistroValido");
		}


		public static class ByReference extends RegistroR4Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroR4Rec implements Structure.ByValue{ }
	}

	public static class RegistroR5Rec extends Structure
	{
		public int NUM_CONT;
		public int NUM_ITEM;
		public char[] COD_ITEM = new char[15];
		public char[] DESC_ITEM = new char[101];
		public double QTDE_ITEM;
		public char[] UN_MED = new char[4];
		public double VL_UNIT;
		public double DESCTO_ITEM;
		public double ACRES_ITEM;
		public double VL_TOT_ITEM;
		public char[] COD_TOT_PARC = new char[8];
		public char[] IND_CANC = new char[2];
		public double QTDE_CANC;
		public double VL_CANC;
		public double VL_CANC_ACRES;
		public char[] IAT = new char[2];
		public char[] IPPT = new char[2];
		public int QTDE_DECIMAL;
		public int VL_DECIMAL;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("NUM_CONT" , "NUM_ITEM" , "COD_ITEM" , "DESC_ITEM" , "QTDE_ITEM" , "UN_MED" , "VL_UNIT" , "DESCTO_ITEM" , "ACRES_ITEM" , "VL_TOT_ITEM" , "COD_TOT_PARC" , "IND_CANC" , "QTDE_CANC" , "VL_CANC" , "VL_CANC_ACRES" , "IAT" , "IPPT" , "QTDE_DECIMAL" , "VL_DECIMAL" , "RegistroValido");
		}


		public static class ByReference extends RegistroR5Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroR5Rec implements Structure.ByValue{ }
	}

	public static class RegistroR6Rec extends Structure
	{
		public int QTD_R7;
		public int NUM_USU;
		public int COO;
		public int GNF;
		public int GRG;
		public int CDC;
		public char[] DENOM = new char[3];
		public double DT_FIN;
		public double HR_FIN;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("QTD_R7" , "NUM_USU" , "COO" , "GNF" , "GRG" , "CDC" , "DENOM" , "DT_FIN" , "HR_FIN" , "RegistroValido");
		}


		public static class ByReference extends RegistroR6Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroR6Rec implements Structure.ByValue{ }
	}

	public static class RegistroR7Rec extends Structure
	{
		public int CCF;
		public int GNF;
		public char[] MP = new char[16];
		public double VL_PAGTO;
		public char[] IND_EST = new char[2];
		public double VL_EST;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("CCF" , "GNF" , "MP" , "VL_PAGTO" , "IND_EST" , "VL_EST" , "RegistroValido");
		}


		public static class ByReference extends RegistroR7Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroR7Rec implements Structure.ByValue{ }
	}

	public static class RegistroT2Rec extends Structure
	{
		public double DT_MOV;
		public char[] TP_DOCTO = new char[11];
		public char[] SERIE = new char[3];
		public int NUM_BILH_I;
		public int NUM_BILH_F;
		public char[] NUM_ECF = new char[21];
		public int CRZ;
		public char[] CFOP = new char[5];
		public double VL_CONT;
		public double VL_BASECALC;
		public double ALIQ;
		public double VL_IMPOSTO;
		public double VL_ISENTAS;
		public double VL_OUTRAS;
		public boolean RegistroValido;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("DT_MOV" , "TP_DOCTO" , "SERIE" , "NUM_BILH_I" , "NUM_BILH_F" , "NUM_ECF" , "CRZ" , "CFOP" , "VL_CONT" , "VL_BASECALC" , "ALIQ" , "VL_IMPOSTO" , "VL_ISENTAS" , "VL_OUTRAS" , "RegistroValido");
		}


		public static class ByReference extends RegistroT2Rec implements Structure.ByReference{ }
		public static class ByValue extends RegistroT2Rec implements Structure.ByValue{ }
	}


	// Funções

	int PAF_AssinarArquivoComEAD(int eadHandle, String Arquivo);
	int PAF_Create(IntByReference pafHandle);
	int PAF_Destroy(int pafHandle);
	int PAF_GetAssinarArquivo(int pafHandle);
	int PAF_GetCurMascara(int pafHandle, ByteBuffer buffer, int bufferLen);
	int PAF_GetDelimitador(int pafHandle, ByteBuffer buffer, int bufferLen);
	int PAF_GetPath(int pafHandle, ByteBuffer buffer, int bufferLen);
	int PAF_GetTrimString(int pafHandle);
	int PAF_GetUltimoErro(int pafHandle, ByteBuffer buffer, int bufferLen);
	int PAF_SaveFileTXT_B(int pafHandle, ACBrPAFInterop.RegistroHD1Rec RegistroB1, ACBrPAFInterop.RegistroB2Rec RegistroB2[], int CountB2, String Arquivo);
	int PAF_SaveFileTXT_C(int pafHandle, ACBrPAFInterop.RegistroHD1Rec RegistroC1, ACBrPAFInterop.RegistroC2Rec RegistroC2[], int CountC2, String Arquivo);
	int PAF_SaveFileTXT_D(int pafHandle, ACBrPAFInterop.RegistroHD1Rec RegistroD1, ACBrPAFInterop.RegistroD2Rec RegistroD2[], int CountD2, ACBrPAFInterop.RegistroD3Rec RegistroD3[], String Arquivo);
	int PAF_SaveFileTXT_E(int pafHandle, ACBrPAFInterop.RegistroHD2Rec RegistroE1, ACBrPAFInterop.RegistroE2Rec RegistroE2[], int CountE2, String Arquivo);
	int PAF_SaveFileTXT_H(int pafHandle, ACBrPAFInterop.RegistroHD2Rec RegistroH1, ACBrPAFInterop.RegistroH2Rec RegistroH2[], int CountH2, String Arquivo);
	int PAF_SaveFileTXT_N(int pafHandle, ACBrPAFInterop.RegistroHD1Rec RegistroN1, ACBrPAFInterop.RegistroN2Rec RegistroN2, ACBrPAFInterop.RegistroN3Rec RegistroN3[], int CountN3, String Arquivo);
	int PAF_SaveFileTXT_P(int pafHandle, ACBrPAFInterop.RegistroHD1Rec RegistroP1, ACBrPAFInterop.RegistroP2Rec RegistroP2[], int CountP2, String Arquivo);
	int PAF_SaveFileTXT_R(int pafHandle, ACBrPAFInterop.RegistroR1Rec RegistroR1, ACBrPAFInterop.RegistroR2Rec RegistroR2[], int CountR2, ACBrPAFInterop.RegistroR3Rec RegistroR3[], ACBrPAFInterop.RegistroR4Rec RegistroR4[], int CountR4, ACBrPAFInterop.RegistroR5Rec RegistroP5[], ACBrPAFInterop.RegistroR6Rec RegistroR6[], int CountR6, ACBrPAFInterop.RegistroR7Rec RegistroR7[], String Arquivo);
	int PAF_SaveFileTXT_T(int pafHandle, ACBrPAFInterop.RegistroHD1Rec RegistroT1, ACBrPAFInterop.RegistroT2Rec RegistroT2[], int CountT2, String Arquivo);
	int PAF_SaveFileTXT_TITP(int pafHandle, ACBrPAFInterop.RegistroMercadoriasRec RegistroMercadorias[], int Count, ACBrPAFInterop.RegistroInsumosRec RegistroInsumos[], String Arquivo, String titulo, double data);
	int PAF_SetAAC(int pafHandle, int aacHandle);
	int PAF_SetAssinarArquivo(int pafHandle, boolean Assinar);
	int PAF_SetCurMascara(int pafHandle, String CurMascara);
	int PAF_SetDelimitador(int pafHandle, String Delimitador);
	int PAF_SetEAD(int pafHandle, int eadHandle);
	int PAF_SetOnPAFGetKeyRSA(int eadHandle, ACBrPAFInterop.PAFGetKeyRSACallback method);
	int PAF_SetPath(int pafHandle, String porta);
	int PAF_SetTrimString(int pafHandle, boolean TrimString);
}
