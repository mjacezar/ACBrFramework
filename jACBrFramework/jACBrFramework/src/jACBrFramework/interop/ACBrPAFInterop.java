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

public interface ACBrPAFInterop extends InteropLib {

	public static final ACBrPAFInterop INSTANCE = (ACBrPAFInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrPAFInterop.class);

	// Tipos de dados
	public interface PAFGetKeyRSACallback extends com.sun.jna.Callback {
		String invoke();
	}
	public static class RegistroA2Rec extends Structure {
		public double Data;
		public byte[] MeioDePagamento = new byte[26];
		public byte[] CodigoTipoDocumento = new byte[2];
		public double Valor;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("Data" , "MeioDePagamento" , "CodigoTipoDocumento" , "Valor" , "RegistroValido");
		}

		public static class ByReference extends RegistroA2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroA2Rec implements Structure.ByValue { }
	}

	public static class RegistroB2Rec extends Structure {
		public byte[] BOMBA = new byte[4];
		public byte[] BICO = new byte[4];
		public double DATA;
		public double HORA;
		public byte[] MOTIVO = new byte[51];
		public byte[] CNPJ_EMPRESA = new byte[15];
		public byte[] CPF_TECNICO = new byte[12];
		public byte[] NRO_LACRE_ANTES = new byte[16];
		public byte[] NRO_LACRE_APOS = new byte[16];
		public double ENCERRANTE_ANTES;
		public double ENCERRANTE_APOS;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("BOMBA" , "BICO" , "DATA" , "HORA" , "MOTIVO" , "CNPJ_EMPRESA" , "CPF_TECNICO" , "NRO_LACRE_ANTES" , "NRO_LACRE_APOS" , "ENCERRANTE_ANTES" , "ENCERRANTE_APOS" , "RegistroValido");
		}

		public static class ByReference extends RegistroB2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroB2Rec implements Structure.ByValue { }
	}

	public static class RegistroC2Rec extends Structure {
		public byte[] ID_ABASTECIMENTO = new byte[16];
		public byte[] TANQUE = new byte[4];
		public byte[] BOMBA = new byte[4];
		public byte[] BICO = new byte[4];
		public byte[] COMBUSTIVEL = new byte[21];
		public double DATA_ABASTECIMENTO;
		public double HORA_ABASTECIMENTO;
		public double ENCERRANTE_INICIAL;
		public double ENCERRANTE_FINAL;
		public byte[] STATUS_ABASTECIMENTO = new byte[11];
		public byte[] NRO_SERIE_ECF = new byte[15];
		public double DATA;
		public double HORA;
		public int COO;
		public int NRO_NOTA_FISCAL;
		public double VOLUME;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("ID_ABASTECIMENTO" , "TANQUE" , "BOMBA" , "BICO" , "COMBUSTIVEL" , "DATA_ABASTECIMENTO" , "HORA_ABASTECIMENTO" , "ENCERRANTE_INICIAL" , "ENCERRANTE_FINAL" , "STATUS_ABASTECIMENTO" , "NRO_SERIE_ECF" , "DATA" , "HORA" , "COO" , "NRO_NOTA_FISCAL" , "VOLUME" , "RegistroValido");
		}

		public static class ByReference extends RegistroC2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroC2Rec implements Structure.ByValue { }
	}

	public static class RegistroD2Rec extends Structure {
		public int QTD_D3;
		public int QTD_D4;
		public byte[] NUM_FAB = new byte[21];
		public byte[] MF_ADICIONAL = new byte[2];
		public byte[] TIPO_ECF = new byte[8];
		public byte[] MARCA_ECF = new byte[21];
		public byte[] MODELO_ECF = new byte[21];
		public byte[] COO = new byte[7];
		public byte[] NUM_DAV = new byte[14];
		public double DT_DAV;
		public byte[] TIT_DAV = new byte[31];
		public double VLT_DAV;
		public byte[] COO_DFV = new byte[7];
		public byte[] NUMERO_ECF = new byte[4];
		public byte[] NOME_CLIENTE = new byte[41];
		public byte[] CPF_CNPJ = new byte[15];
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("QTD_D3" , "QTD_D4" , "NUM_FAB" , "MF_ADICIONAL" , "TIPO_ECF" , "MARCA_ECF" , "MODELO_ECF" , "COO" , "NUM_DAV" , "DT_DAV" , "TIT_DAV" , "VLT_DAV" , "COO_DFV" , "NUMERO_ECF" , "NOME_CLIENTE" , "CPF_CNPJ" , "RegistroValido");
		}

		public static class ByReference extends RegistroD2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroD2Rec implements Structure.ByValue { }
	}

	public static class RegistroD3Rec extends Structure {
		public double DT_INCLUSAO;
		public int NUM_ITEM;
		public byte[] COD_ITEM = new byte[15];
		public byte[] DESC_ITEM = new byte[101];
		public double QTDE_ITEM;
		public byte[] UNI_ITEM = new byte[4];
		public double VL_UNIT;
		public double VL_DESCTO;
		public double VL_ACRES;
		public double VL_TOTAL;
		public int DEC_VL_UNIT;
		public int DEC_QTDE_ITEM;
		public byte[] SIT_TRIB = new byte[2];
		public double ALIQ;
		public byte[] IND_CANC = new byte[2];
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_INCLUSAO" , "NUM_ITEM" , "COD_ITEM" , "DESC_ITEM" , "QTDE_ITEM" , "UNI_ITEM" , "VL_UNIT" , "VL_DESCTO" , "VL_ACRES" , "VL_TOTAL" , "DEC_VL_UNIT" , "DEC_QTDE_ITEM" , "SIT_TRIB" , "ALIQ" , "IND_CANC" , "RegistroValido");
		}

		public static class ByReference extends RegistroD3Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroD3Rec implements Structure.ByValue { }
	}

	public static class RegistroD4Rec extends Structure {
		public byte[] NumeroDAV = new byte[14];
		public double DataAlteracao;
		public double HoraAlteracao;
		public byte[] CodigoProdutoServico = new byte[15];
		public byte[] Descricao = new byte[101];
		public double Quantidade;
		public byte[] Unidade = new byte[4];
		public double ValorUnitario;
		public double DescontoSobreItem;
		public double AcrescimoSobreItem;
		public double ValorTotalLiquido;
		public byte[] SituacaoTributaria = new byte[2];
		public double Aliquota;
		public byte[] IndicadorCancelamento = new byte[2];
		public int CasasDecimaisQtd;
		public int CasasDecimaisVlUn;
		public byte[] TipoAlteracao = new byte[2];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NumeroDAV" , "DataAlteracao" , "HoraAlteracao" , "CodigoProdutoServico" , "Descricao" , "Quantidade" , "Unidade" , "ValorUnitario" , "DescontoSobreItem" , "AcrescimoSobreItem" , "ValorTotalLiquido" , "SituacaoTributaria" , "Aliquota" , "IndicadorCancelamento" , "CasasDecimaisQtd" , "CasasDecimaisVlUn" , "TipoAlteracao");
		}

		public static class ByReference extends RegistroD4Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroD4Rec implements Structure.ByValue { }
	}

	public static class RegistroE2Rec extends Structure {
		public byte[] COD_MERC = new byte[15];
		public byte[] DESC_MERC = new byte[51];
		public byte[] UN_MED = new byte[7];
		public double QTDE_EST;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MERC" , "DESC_MERC" , "UN_MED" , "QTDE_EST" , "RegistroValido");
		}

		public static class ByReference extends RegistroE2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroE2Rec implements Structure.ByValue { }
	}

	public static class RegistroE3Rec extends Structure implements Structure.ByValue {
		public byte[] NumeroFabricacao = new byte[21];
		public byte[] MFAdicional = new byte[2];
		public byte[] TipoECF = new byte[8];
		public byte[] MarcaECF = new byte[21];
		public byte[] ModeloECF = new byte[21];
		public double DataEstoque;
		public double HoraEstoque;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NumeroFabricacao" , "MFAdicional" , "TipoECF" , "MarcaECF" , "ModeloECF" , "DataEstoque" , "HoraEstoque" , "RegistroValido");
		}

		public static class ByReference extends RegistroE3Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroE3Rec implements Structure.ByValue { }
	}

	public static class RegistroH2Rec extends Structure {
		public byte[] CNPJ_CRED_CARTAO = new byte[15];
		public int COO;
		public int CCF;
		public double VLR_TROCO;
		public double DT_TROCO;
		public byte[] CPF = new byte[15];
		public byte[] Titulo = new byte[8];
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CNPJ_CRED_CARTAO" , "COO" , "CCF" , "VLR_TROCO" , "DT_TROCO" , "CPF" , "Titulo" , "RegistroValido");
		}

		public static class ByReference extends RegistroH2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroH2Rec implements Structure.ByValue { }
	}

	public static class RegistroHD1Rec extends Structure implements Structure.ByValue {
		public byte[] RAZAOSOCIAL = new byte[51];
		public byte[] UF = new byte[3];
		public byte[] CNPJ = new byte[15];
		public byte[] IE = new byte[15];
		public byte[] IM = new byte[15];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("RAZAOSOCIAL" , "UF" , "CNPJ" , "IE" , "IM");
		}

		public static class ByReference extends RegistroHD1Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroHD1Rec implements Structure.ByValue { }
	}

	public static class RegistroHD2Rec extends Structure implements Structure.ByValue {
		public byte[] RAZAOSOCIAL = new byte[51];
		public byte[] UF = new byte[3];
		public byte[] CNPJ = new byte[15];
		public byte[] IE = new byte[15];
		public byte[] IM = new byte[15];
		public byte[] NUM_FAB = new byte[21];
		public byte[] MF_ADICIONAL = new byte[2];
		public byte[] TIPO_ECF = new byte[8];
		public byte[] MARCA_ECF = new byte[21];
		public byte[] MODELO_ECF = new byte[21];
		public double DT_EST;
		public boolean InclusaoExclusao;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("RAZAOSOCIAL" , "UF" , "CNPJ" , "IE" , "IM" , "NUM_FAB" , "MF_ADICIONAL" , "TIPO_ECF" , "MARCA_ECF" , "MODELO_ECF" , "DT_EST" , "InclusaoExclusao" , "RegistroValido");
		}

		public static class ByReference extends RegistroHD2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroHD2Rec implements Structure.ByValue { }
	}

	public static class RegistroInsumosRec extends Structure {
		public byte[] Descricao = new byte[101];
		public byte[] Codigo = new byte[15];
		public double Aliquota;
		public byte[] Unidade = new byte[4];
		public double Quantidade;
		public byte[] Ean = new byte[14];
		public byte[] CST = new byte[4];
		public double VlrUnitario;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("Descricao" , "Codigo" , "Aliquota" , "Unidade" , "Quantidade" , "Ean" , "CST" , "VlrUnitario");
		}

		public static class ByReference extends RegistroInsumosRec implements Structure.ByReference { }
		public static class ByValue extends RegistroInsumosRec implements Structure.ByValue { }
	}

	public static class RegistroMercadoriasRec extends Structure {
		public byte[] Descricao = new byte[101];
		public byte[] Codigo = new byte[15];
		public double Aliquota;
		public byte[] Unidade = new byte[4];
		public double Quantidade;
		public byte[] Ean = new byte[14];
		public byte[] CST = new byte[4];
		public double VlrUnitario;
		public int QTD_Insumos;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("Descricao" , "Codigo" , "Aliquota" , "Unidade" , "Quantidade" , "Ean" , "CST" , "VlrUnitario" , "QTD_Insumos");
		}

		public static class ByReference extends RegistroMercadoriasRec implements Structure.ByReference { }
		public static class ByValue extends RegistroMercadoriasRec implements Structure.ByValue { }
	}

	public static class RegistroN2Rec extends Structure implements Structure.ByValue { 
		public byte[] LAUDO = new byte[11];
		public byte[] NOME = new byte[51];
		public byte[] VERSAO = new byte[11];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("LAUDO" , "NOME" , "VERSAO");
		}

		public static class ByReference extends RegistroN2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroN2Rec implements Structure.ByValue { }
	}

	public static class RegistroN3Rec extends Structure {
		public byte[] NOME_ARQUIVO = new byte[51];
		public byte[] MD5 = new byte[33];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NOME_ARQUIVO" , "MD5");
		}

		public static class ByReference extends RegistroN3Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroN3Rec implements Structure.ByValue { }
	}

	public static class RegistroP2Rec extends Structure {
		public byte[] COD_MERC_SERV = new byte[15];
		public byte[] DESC_MERC_SERV = new byte[51];
		public byte[] UN_MED = new byte[7];
		public byte[] IAT = new byte[2];
		public byte[] IPPT = new byte[2];
		public byte[] ST = new byte[2];
		public double ALIQ;
		public double VL_UNIT;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MERC_SERV" , "DESC_MERC_SERV" , "UN_MED" , "IAT" , "IPPT" , "ST" , "ALIQ" , "VL_UNIT" , "RegistroValido");
		}

		public static class ByReference extends RegistroP2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroP2Rec implements Structure.ByValue { }
	}

	public static class RegistroR1Rec extends Structure {
		public int QTD_R2;
		public int QTD_R4;
		public int QTD_R6;
		public byte[] NUM_FAB = new byte[21];
		public byte[] MF_ADICIONAL = new byte[2];
		public byte[] TIPO_ECF = new byte[8];
		public byte[] MARCA_ECF = new byte[21];
		public byte[] MODELO_ECF = new byte[21];
		public byte[] VERSAO_SB = new byte[11];
		public double DT_INST_SB;
		public double HR_INST_SB;
		public int NUM_SEQ_ECF;
		public byte[] CNPJ = new byte[15];
		public byte[] IE = new byte[15];
		public byte[] CNPJ_SH = new byte[15];
		public byte[] IE_SH = new byte[15];
		public byte[] IM_SH = new byte[15];
		public byte[] NOME_SH = new byte[41];
		public byte[] NOME_PAF = new byte[41];
		public byte[] VER_PAF = new byte[11];
		public byte[] COD_MD5 = new byte[33];
		public double DT_INI;
		public double DT_FIN;
		public byte[] ER_PAF_ECF = new byte[5];
		public boolean InclusaoExclusao;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("QTD_R2" , "QTD_R4" , "QTD_R6" , "NUM_FAB" , "MF_ADICIONAL" , "TIPO_ECF" , "MARCA_ECF" , "MODELO_ECF" , "VERSAO_SB" , "DT_INST_SB" , "HR_INST_SB" , "NUM_SEQ_ECF" , "CNPJ" , "IE" , "CNPJ_SH" , "IE_SH" , "IM_SH" , "NOME_SH" , "NOME_PAF" , "VER_PAF" , "COD_MD5" , "DT_INI" , "DT_FIN" , "ER_PAF_ECF" , "InclusaoExclusao" , "RegistroValido");
		}

		public static class ByReference extends RegistroR1Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroR1Rec implements Structure.ByValue { }
	}

	public static class RegistroR2Rec extends Structure {
		public int QTD_R3;
		public int NUM_USU;
		public int CRZ;
		public int COO;
		public int CRO;
		public double DT_MOV;
		public double DT_EMI;
		public double HR_EMI;
		public double VL_VBD;
		public byte[] PAR_ECF = new byte[2];
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("QTD_R3" , "NUM_USU" , "CRZ" , "COO" , "CRO" , "DT_MOV" , "DT_EMI" , "HR_EMI" , "VL_VBD" , "PAR_ECF" , "RegistroValido");
		}

		public static class ByReference extends RegistroR2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroR2Rec implements Structure.ByValue { }
	}

	public static class RegistroR3Rec extends Structure {
		public byte[] TOT_PARCIAL = new byte[8];
		public double VL_ACUM;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("TOT_PARCIAL" , "VL_ACUM" , "RegistroValido");
		}

		public static class ByReference extends RegistroR3Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroR3Rec implements Structure.ByValue { }
	}

	public static class RegistroR4Rec extends Structure {
		public int QTD_R5;
		public int QTD_R7;
		public int NUM_USU;
		public int NUM_CONT;
		public int COO;
		public double DT_INI;
		public double SUB_DOCTO;
		public double SUB_DESCTO;
		public byte[] TP_DESCTO = new byte[2];
		public double SUB_ACRES;
		public byte[] TP_ACRES = new byte[2];
		public double VL_TOT;
		public byte[] CANC = new byte[2];
		public double VL_CA;
		public byte[] ORDEM_DA = new byte[2];
		public byte[] NOME_CLI = new byte[41];
		public byte[] CNPJ_CPF = new byte[15];
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("QTD_R5" , "QTD_R7" , "NUM_USU" , "NUM_CONT" , "COO" , "DT_INI" , "SUB_DOCTO" , "SUB_DESCTO" , "TP_DESCTO" , "SUB_ACRES" , "TP_ACRES" , "VL_TOT" , "CANC" , "VL_CA" , "ORDEM_DA" , "NOME_CLI" , "CNPJ_CPF" , "RegistroValido");
		}

		public static class ByReference extends RegistroR4Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroR4Rec implements Structure.ByValue { }
	}

	public static class RegistroR5Rec extends Structure {
		public int NUM_CONT;
		public int NUM_ITEM;
		public byte[] COD_ITEM = new byte[15];
		public byte[] DESC_ITEM = new byte[101];
		public double QTDE_ITEM;
		public byte[] UN_MED = new byte[4];
		public double VL_UNIT;
		public double DESCTO_ITEM;
		public double ACRES_ITEM;
		public double VL_TOT_ITEM;
		public byte[] COD_TOT_PARC = new byte[8];
		public byte[] IND_CANC = new byte[2];
		public double QTDE_CANC;
		public double VL_CANC;
		public double VL_CANC_ACRES;
		public byte[] IAT = new byte[2];
		public byte[] IPPT = new byte[2];
		public int QTDE_DECIMAL;
		public int VL_DECIMAL;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_CONT" , "NUM_ITEM" , "COD_ITEM" , "DESC_ITEM" , "QTDE_ITEM" , "UN_MED" , "VL_UNIT" , "DESCTO_ITEM" , "ACRES_ITEM" , "VL_TOT_ITEM" , "COD_TOT_PARC" , "IND_CANC" , "QTDE_CANC" , "VL_CANC" , "VL_CANC_ACRES" , "IAT" , "IPPT" , "QTDE_DECIMAL" , "VL_DECIMAL" , "RegistroValido");
		}

		public static class ByReference extends RegistroR5Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroR5Rec implements Structure.ByValue { }
	}

	public static class RegistroR6Rec extends Structure {
		public int QTD_R7;
		public int NUM_USU;
		public int COO;
		public int GNF;
		public int GRG;
		public int CDC;
		public byte[] DENOM = new byte[3];
		public double DT_FIN;
		public double HR_FIN;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("QTD_R7" , "NUM_USU" , "COO" , "GNF" , "GRG" , "CDC" , "DENOM" , "DT_FIN" , "HR_FIN" , "RegistroValido");
		}

		public static class ByReference extends RegistroR6Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroR6Rec implements Structure.ByValue { }
	}

	public static class RegistroR7Rec extends Structure {
		public int CCF;
		public int GNF;
		public byte[] MP = new byte[16];
		public double VL_PAGTO;
		public byte[] IND_EST = new byte[2];
		public double VL_EST;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CCF" , "GNF" , "MP" , "VL_PAGTO" , "IND_EST" , "VL_EST" , "RegistroValido");
		}

		public static class ByReference extends RegistroR7Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroR7Rec implements Structure.ByValue { }
	}

	public static class RegistroT2Rec extends Structure {
		public double DT_MOV;
		public byte[] TP_DOCTO = new byte[11];
		public byte[] SERIE = new byte[3];
		public int NUM_BILH_I;
		public int NUM_BILH_F;
		public byte[] NUM_ECF = new byte[21];
		public int CRZ;
		public byte[] CFOP = new byte[5];
		public double VL_CONT;
		public double VL_BASECALC;
		public double ALIQ;
		public double VL_IMPOSTO;
		public double VL_ISENTAS;
		public double VL_OUTRAS;
		public boolean RegistroValido;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_MOV" , "TP_DOCTO" , "SERIE" , "NUM_BILH_I" , "NUM_BILH_F" , "NUM_ECF" , "CRZ" , "CFOP" , "VL_CONT" , "VL_BASECALC" , "ALIQ" , "VL_IMPOSTO" , "VL_ISENTAS" , "VL_OUTRAS" , "RegistroValido");
		}

		public static class ByReference extends RegistroT2Rec implements Structure.ByReference { }
		public static class ByValue extends RegistroT2Rec implements Structure.ByValue { }
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
	int PAF_Preenche_A(int pafHandle, ACBrPAFInterop.RegistroA2Rec registrosA2Rec[], int countA2);
	int PAF_Preenche_B(int pafHandle, ACBrPAFInterop.RegistroHD1Rec registrosHD1Rec, ACBrPAFInterop.RegistroB2Rec registrosB2Rec[], int countB2);
	int PAF_Preenche_C(int pafHandle, ACBrPAFInterop.RegistroHD1Rec registrosC1Rec, ACBrPAFInterop.RegistroC2Rec registrosC2Rec[], int countC2);
	int PAF_Preenche_D(int pafHandle, ACBrPAFInterop.RegistroHD1Rec registroD1Rec, ACBrPAFInterop.RegistroD2Rec registrosD2Rec[], int countD2, ACBrPAFInterop.RegistroD3Rec registrosD3Rec[], ACBrPAFInterop.RegistroD4Rec registrosD4Rec[], int countD4);
	int PAF_Preenche_E(int pafHandle, ACBrPAFInterop.RegistroHD2Rec registroE1Rec, ACBrPAFInterop.RegistroE2Rec RegistroE2Rec[], ACBrPAFInterop.RegistroE3Rec RegistroE3Rec, int countE2);
	int PAF_Preenche_H(int pafHandle, ACBrPAFInterop.RegistroHD2Rec RegistroH1Rec, ACBrPAFInterop.RegistroH2Rec RegistroH2Rec[], int CountH2);
	int PAF_Preenche_N(int pafHandle, ACBrPAFInterop.RegistroHD1Rec registroN1Rec, ACBrPAFInterop.RegistroN2Rec registrosN2Rec, ACBrPAFInterop.RegistroN3Rec registrosN3Rec[], int countN3);
	int PAF_Preenche_P(int pafHandle, ACBrPAFInterop.RegistroHD1Rec registroP1Rec, ACBrPAFInterop.RegistroP2Rec registrosP2Rec[], int countP2);
	int PAF_Preenche_R(int pafHandle, int CountR1, ACBrPAFInterop.RegistroR1Rec registrosR1Rec[], ACBrPAFInterop.RegistroR2Rec registrosR2Rec[], ACBrPAFInterop.RegistroR3Rec registrosR3Rec[], ACBrPAFInterop.RegistroR4Rec registrosR4Rec[], ACBrPAFInterop.RegistroR5Rec registrosR5Rec[], ACBrPAFInterop.RegistroR6Rec registrosR6Rec[], ACBrPAFInterop.RegistroR7Rec registrosR7Rec[]);
	int PAF_Preenche_T(int pafHandle, ACBrPAFInterop.RegistroHD1Rec registroT1Rec, ACBrPAFInterop.RegistroT2Rec registrosT2Rec[], int countT2);
	int PAF_Preenche_TITP(int pafHandle, ACBrPAFInterop.RegistroMercadoriasRec RegistroMercadorias[], int Count, ACBrPAFInterop.RegistroInsumosRec RegistroInsumos[], String titulo, double data);
	int PAF_Preenche_U(int pafHandle, ACBrPAFInterop.RegistroHD1Rec registroU1Rec);
	int PAF_SaveFileTXT_B(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_C(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_D(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_E(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_H(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_N(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_P(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_R(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_RegistrosPAF(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_T(int pafHandle, String Arquivo);
	int PAF_SaveFileTXT_TITP(int pafHandle, String Arquivo);
	int PAF_SetAAC(int pafHandle, int aacHandle);
	int PAF_SetAssinarArquivo(int pafHandle, boolean Assinar);
	int PAF_SetCurMascara(int pafHandle, String CurMascara);
	int PAF_SetDelimitador(int pafHandle, String Delimitador);
	int PAF_SetEAD(int pafHandle, int eadHandle);
	int PAF_SetOnPAFGetKeyRSA(int eadHandle, ACBrPAFInterop.PAFGetKeyRSACallback method);
	int PAF_SetPath(int pafHandle, String porta);
	int PAF_SetTrimString(int pafHandle, boolean TrimString);
}
