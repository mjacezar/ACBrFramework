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

public interface ACBrSpedFiscalInterop extends InteropLib {

	public static final ACBrSpedFiscalInterop INSTANCE = (ACBrSpedFiscalInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrSpedFiscalInterop.class);

	// Tipos de dados
	public static class Bloco0Registro0000 extends Structure implements Structure.ByValue {
		public int COD_VER;
		public int COD_FIN;
		public double DT_INI;
		public double DT_FIN;
		public byte[] NOME = new byte[101];
		public byte[] CNPJ = new byte[15];
		public byte[] CPF = new byte[12];
		public byte[] UF = new byte[3];
		public byte[] IE = new byte[15];
		public int COD_MUN;
		public byte[] IM = new byte[15];
		public byte[] SUFRAMA = new byte[10];
		public int IND_PERFIL;
		public int IND_ATIV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_VER" , "COD_FIN" , "DT_INI" , "DT_FIN" , "NOME" , "CNPJ" , "CPF" , "UF" , "IE" , "COD_MUN" , "IM" , "SUFRAMA" , "IND_PERFIL" , "IND_ATIV");
		}

		public static class ByReference extends Bloco0Registro0000 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0000 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends Bloco0Registro0001 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0001 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0005 extends Structure implements Structure.ByValue {
		public byte[] FANTASIA = new byte[61];
		public byte[] CEP = new byte[9];
		public byte[] ENDERECO = new byte[61];
		public byte[] NUM = new byte[11];
		public byte[] COMPL = new byte[61];
		public byte[] BAIRRO = new byte[61];
		public byte[] FONE = new byte[11];
		public byte[] FAX = new byte[11];
		public byte[] EMAIL = new byte[151];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("FANTASIA" , "CEP" , "ENDERECO" , "NUM" , "COMPL" , "BAIRRO" , "FONE" , "FAX" , "EMAIL");
		}

		public static class ByReference extends Bloco0Registro0005 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0005 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0015 extends Structure implements Structure.ByValue {
		public byte[] UF_ST = new byte[3];
		public byte[] IE_ST = new byte[15];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("UF_ST" , "IE_ST");
		}

		public static class ByReference extends Bloco0Registro0015 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0015 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0100 extends Structure implements Structure.ByValue {
		public byte[] NOME = new byte[101];
		public byte[] CPF = new byte[12];
		public byte[] CRC = new byte[16];
		public byte[] CNPJ = new byte[15];
		public byte[] CEP = new byte[9];
		public byte[] ENDERECO = new byte[61];
		public byte[] NUM = new byte[11];
		public byte[] COMPL = new byte[61];
		public byte[] BAIRRO = new byte[61];
		public byte[] FONE = new byte[11];
		public byte[] FAX = new byte[11];
		public byte[] EMAIL = new byte[151];
		public int COD_MUN;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NOME" , "CPF" , "CRC" , "CNPJ" , "CEP" , "ENDERECO" , "NUM" , "COMPL" , "BAIRRO" , "FONE" , "FAX" , "EMAIL" , "COD_MUN");
		}

		public static class ByReference extends Bloco0Registro0100 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0100 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0150 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public byte[] NOME = new byte[101];
		public byte[] COD_PAIS = new byte[6];
		public byte[] CNPJ = new byte[15];
		public byte[] CPF = new byte[12];
		public byte[] IE = new byte[15];
		public int COD_MUN;
		public byte[] SUFRAMA = new byte[10];
		public byte[] ENDERECO = new byte[61];
		public byte[] NUM = new byte[11];
		public byte[] COMPL = new byte[61];
		public byte[] BAIRRO = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "NOME" , "COD_PAIS" , "CNPJ" , "CPF" , "IE" , "COD_MUN" , "SUFRAMA" , "ENDERECO" , "NUM" , "COMPL" , "BAIRRO");
		}

		public static class ByReference extends Bloco0Registro0150 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0150 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0175 extends Structure implements Structure.ByValue {
		public double DT_ALT;
		public byte[] NR_CAMPO = new byte[3];
		public byte[] CONT_ANT = new byte[101];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_ALT" , "NR_CAMPO" , "CONT_ANT");
		}

		public static class ByReference extends Bloco0Registro0175 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0175 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0190 extends Structure implements Structure.ByValue {
		public byte[] UNID = new byte[7];
		public byte[] DESCR = new byte[101];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("UNID" , "DESCR");
		}

		public static class ByReference extends Bloco0Registro0190 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0190 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0200 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public byte[] DESCR_ITEM = new byte[201];
		public byte[] COD_BARRA = new byte[15];
		public byte[] COD_ANT_ITEM = new byte[61];
		public byte[] UNID_INV = new byte[7];
		public int TIPO_ITEM;
		public byte[] COD_NCM = new byte[9];
		public byte[] EX_IPI = new byte[4];
		public byte[] COD_GEN = new byte[3];
		public byte[] COD_LST = new byte[5];
		public double ALIQ_ICMS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "DESCR_ITEM" , "COD_BARRA" , "COD_ANT_ITEM" , "UNID_INV" , "TIPO_ITEM" , "COD_NCM" , "EX_IPI" , "COD_GEN" , "COD_LST" , "ALIQ_ICMS");
		}

		public static class ByReference extends Bloco0Registro0200 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0200 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0205 extends Structure implements Structure.ByValue {
		public byte[] DESCR_ANT_ITEM = new byte[201];
		public double DT_INI;
		public double DT_FIN;
		public byte[] COD_ANT_ITEM = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DESCR_ANT_ITEM" , "DT_INI" , "DT_FIN" , "COD_ANT_ITEM");
		}

		public static class ByReference extends Bloco0Registro0205 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0205 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0206 extends Structure implements Structure.ByValue {
		public byte[] COD_COMB = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_COMB");
		}

		public static class ByReference extends Bloco0Registro0206 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0206 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0220 extends Structure implements Structure.ByValue {
		public byte[] UNID_CONV = new byte[7];
		public double FAT_CONV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("UNID_CONV" , "FAT_CONV");
		}

		public static class ByReference extends Bloco0Registro0220 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0220 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0300 extends Structure implements Structure.ByValue {
		public byte[] COD_IND_BEM = new byte[61];
		public int IDENT_MERC;
		public byte[] DESCR_ITEM = new byte[201];
		public byte[] COD_PRNC = new byte[61];
		public byte[] COD_CTA = new byte[61];
		public double NR_PARC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_IND_BEM" , "IDENT_MERC" , "DESCR_ITEM" , "COD_PRNC" , "COD_CTA" , "NR_PARC");
		}

		public static class ByReference extends Bloco0Registro0300 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0300 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0305 extends Structure implements Structure.ByValue {
		public byte[] COD_CCUS = new byte[61];
		public byte[] FUNC = new byte[201];
		public int VIDA_UTIL;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_CCUS" , "FUNC" , "VIDA_UTIL");
		}

		public static class ByReference extends Bloco0Registro0305 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0305 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0400 extends Structure implements Structure.ByValue {
		public byte[] COD_NAT = new byte[61];
		public byte[] DESCR_NAT = new byte[201];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_NAT" , "DESCR_NAT");
		}

		public static class ByReference extends Bloco0Registro0400 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0400 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0450 extends Structure implements Structure.ByValue {
		public byte[] COD_INF = new byte[7];
		public byte[] TXT = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_INF" , "TXT");
		}

		public static class ByReference extends Bloco0Registro0450 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0450 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0460 extends Structure implements Structure.ByValue {
		public byte[] COD_OBS = new byte[7];
		public byte[] TXT = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_OBS" , "TXT");
		}

		public static class ByReference extends Bloco0Registro0460 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0460 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0500 extends Structure implements Structure.ByValue {
		public double DT_ALT;
		public byte[] COD_NAT_CC = new byte[3];
		public byte[] IND_CTA = new byte[2];
		public byte[] NIVEL = new byte[6];
		public byte[] COD_CTA = new byte[61];
		public byte[] NOME_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_ALT" , "COD_NAT_CC" , "IND_CTA" , "NIVEL" , "COD_CTA" , "NOME_CTA");
		}

		public static class ByReference extends Bloco0Registro0500 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0500 implements Structure.ByValue { }
	}

	public static class Bloco0Registro0600 extends Structure implements Structure.ByValue {
		public double DT_ALT;
		public byte[] COD_CCUS = new byte[61];
		public byte[] CCUS = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_ALT" , "COD_CCUS" , "CCUS");
		}

		public static class ByReference extends Bloco0Registro0600 implements Structure.ByReference { }
		public static class ByValue extends Bloco0Registro0600 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends Bloco1Registro1001 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1001 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1010 extends Structure implements Structure.ByValue {
		public byte[] IND_EXP = new byte[2];
		public byte[] IND_CCRF = new byte[2];
		public byte[] IND_COMB = new byte[2];
		public byte[] IND_USINA = new byte[2];
		public byte[] IND_VA = new byte[2];
		public byte[] IND_EE = new byte[2];
		public byte[] IND_CART = new byte[2];
		public byte[] IND_FORM = new byte[2];
		public byte[] IND_AER = new byte[2];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_EXP" , "IND_CCRF" , "IND_COMB" , "IND_USINA" , "IND_VA" , "IND_EE" , "IND_CART" , "IND_FORM" , "IND_AER");
		}

		public static class ByReference extends Bloco1Registro1010 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1010 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1100 extends Structure implements Structure.ByValue {
		public int IND_DOC;
		public byte[] NRO_DE = new byte[12];
		public double DT_DE;
		public int NAT_EXP;
		public byte[] NRO_RE = new byte[13];
		public double DT_RE;
		public byte[] CHC_EMB = new byte[19];
		public double DT_CHC;
		public double DT_AVB;
		public int TP_CHC;
		public byte[] PAIS = new byte[4];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_DOC" , "NRO_DE" , "DT_DE" , "NAT_EXP" , "NRO_RE" , "DT_RE" , "CHC_EMB" , "DT_CHC" , "DT_AVB" , "TP_CHC" , "PAIS");
		}

		public static class ByReference extends Bloco1Registro1100 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1100 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1105 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] SERIE = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public byte[] CHV_NFE = new byte[45];
		public double DT_DOC;
		public byte[] COD_ITEM = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "SERIE" , "NUM_DOC" , "CHV_NFE" , "DT_DOC" , "COD_ITEM");
		}

		public static class ByReference extends Bloco1Registro1105 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1105 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1110 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] NUM_DOC = new byte[10];
		public double DT_DOC;
		public byte[] CHV_NFE = new byte[45];
		public byte[] NR_MEMO = new byte[61];
		public double QTD;
		public byte[] UNID = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "COD_MOD" , "SER" , "NUM_DOC" , "DT_DOC" , "CHV_NFE" , "NR_MEMO" , "QTD" , "UNID");
		}

		public static class ByReference extends Bloco1Registro1110 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1110 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1200 extends Structure implements Structure.ByValue {
		public byte[] COD_AJ_APUR = new byte[9];
		public double SLD_CRED;
		public double CRED_APR;
		public double CRED_RECEB;
		public double CRED_UTIL;
		public double SLD_CRED_FIM;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_AJ_APUR" , "SLD_CRED" , "CRED_APR" , "CRED_RECEB" , "CRED_UTIL" , "SLD_CRED_FIM");
		}

		public static class ByReference extends Bloco1Registro1200 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1200 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1210 extends Structure implements Structure.ByValue {
		public byte[] TIPO_UTIL = new byte[5];
		public byte[] NR_DOC = new byte[61];
		public double VL_CRED_UTIL;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("TIPO_UTIL" , "NR_DOC" , "VL_CRED_UTIL");
		}

		public static class ByReference extends Bloco1Registro1210 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1210 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1300 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public double DT_FECH;
		public double ESTQ_ABERT;
		public double VOL_ENTR;
		public double VOL_DISP;
		public double VOL_SAIDAS;
		public double ESTQ_ESCR;
		public double VAL_AJ_PERDA;
		public double VAL_AJ_GANHO;
		public double FECH_FISICO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "DT_FECH" , "ESTQ_ABERT" , "VOL_ENTR" , "VOL_DISP" , "VOL_SAIDAS" , "ESTQ_ESCR" , "VAL_AJ_PERDA" , "VAL_AJ_GANHO" , "FECH_FISICO");
		}

		public static class ByReference extends Bloco1Registro1300 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1300 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1310 extends Structure implements Structure.ByValue {
		public byte[] NUM_TANQUE = new byte[4];
		public double ESTQ_ABERT;
		public double VOL_ENTR;
		public double VOL_DISP;
		public double VOL_SAIDAS;
		public double ESTQ_ESCR;
		public double VAL_AJ_PERDA;
		public double VAL_AJ_GANHO;
		public double FECH_FISICO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_TANQUE" , "ESTQ_ABERT" , "VOL_ENTR" , "VOL_DISP" , "VOL_SAIDAS" , "ESTQ_ESCR" , "VAL_AJ_PERDA" , "VAL_AJ_GANHO" , "FECH_FISICO");
		}

		public static class ByReference extends Bloco1Registro1310 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1310 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1320 extends Structure implements Structure.ByValue {
		public byte[] NUM_BICO = new byte[61];
		public byte[] NR_INTERV = new byte[61];
		public byte[] MOT_INTERV = new byte[51];
		public byte[] NOM_INTERV = new byte[31];
		public byte[] CNPJ_INTERV = new byte[15];
		public byte[] CPF_INTERV = new byte[12];
		public double VAL_FECHA;
		public double VAL_ABERT;
		public double VOL_AFERI;
		public double VOL_VENDAS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_BICO" , "NR_INTERV" , "MOT_INTERV" , "NOM_INTERV" , "CNPJ_INTERV" , "CPF_INTERV" , "VAL_FECHA" , "VAL_ABERT" , "VOL_AFERI" , "VOL_VENDAS");
		}

		public static class ByReference extends Bloco1Registro1320 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1320 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1350 extends Structure implements Structure.ByValue {
		public byte[] SERIE = new byte[5];
		public byte[] FABRICANTE = new byte[61];
		public byte[] MODELO = new byte[61];
		public int TIPO_MEDICAO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("SERIE" , "FABRICANTE" , "MODELO" , "TIPO_MEDICAO");
		}

		public static class ByReference extends Bloco1Registro1350 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1350 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1360 extends Structure implements Structure.ByValue {
		public byte[] NUM_LACRE = new byte[21];
		public double DT_APLICACAO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_LACRE" , "DT_APLICACAO");
		}

		public static class ByReference extends Bloco1Registro1360 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1360 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1370 extends Structure implements Structure.ByValue {
		public byte[] NUM_BICO = new byte[4];
		public byte[] COD_ITEM = new byte[61];
		public byte[] NUM_TANQU = new byte[4];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_BICO" , "COD_ITEM" , "NUM_TANQU");
		}

		public static class ByReference extends Bloco1Registro1370 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1370 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1390 extends Structure implements Structure.ByValue {
		public byte[] COD_PROD = new byte[3];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PROD");
		}

		public static class ByReference extends Bloco1Registro1390 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1390 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1400 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public byte[] MUN = new byte[6];
		public double VALOR;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "MUN" , "VALOR");
		}

		public static class ByReference extends Bloco1Registro1400 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1400 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1500 extends Structure implements Structure.ByValue {
		public byte[] IND_OPER = new byte[2];
		public byte[] IND_EMIT = new byte[2];
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[61];
		public int COD_SIT;
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public int COD_CONS;
		public byte[] NUM_DOC = new byte[10];
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
		public byte[] COD_INF = new byte[7];
		public double VL_PIS;
		public double VL_COFINS;
		public int TP_LIGACAO;
		public int COD_GRUPO_TENSAO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_OPER" , "IND_EMIT" , "COD_PART" , "COD_MOD" , "COD_SIT" , "SER" , "SUB" , "COD_CONS" , "NUM_DOC" , "DT_DOC" , "DT_E_S" , "VL_DOC" , "VL_DESC" , "VL_FORN" , "VL_SERV_NT" , "VL_TERC" , "VL_DA" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "COD_INF" , "VL_PIS" , "VL_COFINS" , "TP_LIGACAO" , "COD_GRUPO_TENSAO");
		}

		public static class ByReference extends Bloco1Registro1500 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1500 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1510 extends Structure implements Structure.ByValue {
		public byte[] NUM_ITEM = new byte[4];
		public byte[] COD_ITEM = new byte[61];
		public byte[] COD_CLASS = new byte[5];
		public double QTD;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public double VL_DESC;
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double VL_BC_ICMS;
		public double ALIQ_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_ST;
		public double ALIQ_ST;
		public double VL_ICMS_ST;
		public int IND_REC;
		public byte[] COD_PART = new byte[61];
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_ITEM" , "COD_ITEM" , "COD_CLASS" , "QTD" , "UNID" , "VL_ITEM" , "VL_DESC" , "CST_ICMS" , "CFOP" , "VL_BC_ICMS" , "ALIQ_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "ALIQ_ST" , "VL_ICMS_ST" , "IND_REC" , "COD_PART" , "VL_PIS" , "VL_COFINS" , "COD_CTA");
		}

		public static class ByReference extends Bloco1Registro1510 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1510 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1600 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public double TOT_CREDITO;
		public double TOT_DEBITO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "TOT_CREDITO" , "TOT_DEBITO");
		}

		public static class ByReference extends Bloco1Registro1600 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1600 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1700 extends Structure implements Structure.ByValue {
		public int COD_DISP;
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC_INI = new byte[13];
		public byte[] NUM_DOC_FIN = new byte[13];
		public byte[] NUM_AUT = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_DISP" , "COD_MOD" , "SER" , "SUB" , "NUM_DOC_INI" , "NUM_DOC_FIN" , "NUM_AUT");
		}

		public static class ByReference extends Bloco1Registro1700 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1700 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1710 extends Structure implements Structure.ByValue {
		public byte[] NUM_DOC_INI = new byte[13];
		public byte[] NUM_DOC_FIN = new byte[13];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_DOC_INI" , "NUM_DOC_FIN");
		}

		public static class ByReference extends Bloco1Registro1710 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1710 implements Structure.ByValue { }
	}

	public static class Bloco1Registro1800 extends Structure implements Structure.ByValue {
		public double VL_CARGA;
		public double VL_PASS;
		public double VL_FAT;
		public double IND_RAT;
		public double VL_ICMS_ANT;
		public double VL_BC_ICMS;
		public double VL_ICMS_APUR;
		public double VL_BC_ICMS_APUR;
		public double VL_DIF;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("VL_CARGA" , "VL_PASS" , "VL_FAT" , "IND_RAT" , "VL_ICMS_ANT" , "VL_BC_ICMS" , "VL_ICMS_APUR" , "VL_BC_ICMS_APUR" , "VL_DIF");
		}

		public static class ByReference extends Bloco1Registro1800 implements Structure.ByReference { }
		public static class ByValue extends Bloco1Registro1800 implements Structure.ByValue { }
	}

	public static class Bloco9Registro9001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends Bloco9Registro9001 implements Structure.ByReference { }
		public static class ByValue extends Bloco9Registro9001 implements Structure.ByValue { }
	}

	public static class Bloco9Registro9900 extends Structure implements Structure.ByValue {
		public byte[] REG_BLC = new byte[5];
		public int QTD_REG_BLC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("REG_BLC" , "QTD_REG_BLC");
		}

		public static class ByReference extends Bloco9Registro9900 implements Structure.ByReference { }
		public static class ByValue extends Bloco9Registro9900 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends BlocoCRegistroC001 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC001 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC100 extends Structure implements Structure.ByValue {
		public int IND_OPER;
		public int IND_EMIT;
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public int COD_SIT;
		public byte[] SER = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public byte[] CHV_NFE = new byte[45];
		public double DT_DOC;
		public double DT_E_S;
		public double VL_DOC;
		public int IND_PGTO;
		public double VL_DESC;
		public double VL_ABAT_NT;
		public double VL_MERC;
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

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_OPER" , "IND_EMIT" , "COD_PART" , "COD_MOD" , "COD_SIT" , "SER" , "NUM_DOC" , "CHV_NFE" , "DT_DOC" , "DT_E_S" , "VL_DOC" , "IND_PGTO" , "VL_DESC" , "VL_ABAT_NT" , "VL_MERC" , "IND_FRT" , "VL_FRT" , "VL_SEG" , "VL_OUT_DA" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "VL_IPI" , "VL_PIS" , "VL_COFINS" , "VL_PIS_ST" , "VL_COFINS_ST");
		}

		public static class ByReference extends BlocoCRegistroC100 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC100 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC105 extends Structure implements Structure.ByValue {
		public int OPER;
		public byte[] UF = new byte[3];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("OPER" , "UF");
		}

		public static class ByReference extends BlocoCRegistroC105 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC105 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC110 extends Structure implements Structure.ByValue {
		public byte[] COD_INF = new byte[7];
		public byte[] TXT_COMPL = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_INF" , "TXT_COMPL");
		}

		public static class ByReference extends BlocoCRegistroC110 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC110 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC111 extends Structure implements Structure.ByValue {
		public byte[] NUM_PROC = new byte[16];
		public int IND_PROC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_PROC" , "IND_PROC");
		}

		public static class ByReference extends BlocoCRegistroC111 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC111 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC112 extends Structure implements Structure.ByValue {
		public int COD_DA;
		public byte[] UF = new byte[3];
		public byte[] NUM_DA = new byte[61];
		public byte[] COD_AUT = new byte[61];
		public double VL_DA;
		public double DT_VCTO;
		public double DT_PGTO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_DA" , "UF" , "NUM_DA" , "COD_AUT" , "VL_DA" , "DT_VCTO" , "DT_PGTO");
		}

		public static class ByReference extends BlocoCRegistroC112 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC112 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC113 extends Structure implements Structure.ByValue {
		public int IND_OPER;
		public int IND_EMIT;
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public double DT_DOC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_OPER" , "IND_EMIT" , "COD_PART" , "COD_MOD" , "SER" , "SUB" , "NUM_DOC" , "DT_DOC");
		}

		public static class ByReference extends BlocoCRegistroC113 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC113 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC114 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] ECF_FAB = new byte[21];
		public byte[] ECF_CX = new byte[4];
		public byte[] NUM_DOC = new byte[7];
		public double DT_DOC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "ECF_FAB" , "ECF_CX" , "NUM_DOC" , "DT_DOC");
		}

		public static class ByReference extends BlocoCRegistroC114 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC114 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC115 extends Structure implements Structure.ByValue {
		public int IND_CARGA;
		public byte[] CNPJ_COL = new byte[15];
		public byte[] IE_COL = new byte[15];
		public byte[] CPF_COL = new byte[12];
		public byte[] COD_MUN_COL = new byte[8];
		public byte[] CNPJ_ENTG = new byte[15];
		public byte[] IE_ENTG = new byte[14];
		public byte[] CPF_ENTG = new byte[12];
		public byte[] COD_MUN_ENTG = new byte[8];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_CARGA" , "CNPJ_COL" , "IE_COL" , "CPF_COL" , "COD_MUN_COL" , "CNPJ_ENTG" , "IE_ENTG" , "CPF_ENTG" , "COD_MUN_ENTG");
		}

		public static class ByReference extends BlocoCRegistroC115 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC115 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC116 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] NR_SAT = new byte[10];
		public byte[] CHV_CFE = new byte[45];
		public byte[] NUM_CFE = new byte[7];
		public double DT_DOC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "NR_SAT" , "CHV_CFE" , "NUM_CFE" , "DT_DOC");
		}

		public static class ByReference extends BlocoCRegistroC116 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC116 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC120 extends Structure implements Structure.ByValue {
		public int COD_DOC_IMP;
		public byte[] NUM_DOC__IMP = new byte[11];
		public double PIS_IMP;
		public double COFINS_IMP;
		public byte[] NUM_ACDRAW = new byte[21];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_DOC_IMP" , "NUM_DOC__IMP" , "PIS_IMP" , "COFINS_IMP" , "NUM_ACDRAW");
		}

		public static class ByReference extends BlocoCRegistroC120 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC120 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC130 extends Structure implements Structure.ByValue {
		public double VL_SERV_NT;
		public double VL_BC_ISSQN;
		public double VL_ISSQN;
		public double VL_BC_IRRF;
		public double VL_IRRF;
		public double VL_BC_PREV;
		public double VL_PREV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("VL_SERV_NT" , "VL_BC_ISSQN" , "VL_ISSQN" , "VL_BC_IRRF" , "VL_IRRF" , "VL_BC_PREV" , "VL_PREV");
		}

		public static class ByReference extends BlocoCRegistroC130 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC130 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC140 extends Structure implements Structure.ByValue {
		public int IND_EMIT;
		public int IND_TIT;
		public byte[] DESC_TIT = new byte[255];
		public byte[] NUM_TIT = new byte[61];
		public int QTD_PARC;
		public double VL_TIT;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_EMIT" , "IND_TIT" , "DESC_TIT" , "NUM_TIT" , "QTD_PARC" , "VL_TIT");
		}

		public static class ByReference extends BlocoCRegistroC140 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC140 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC141 extends Structure implements Structure.ByValue {
		public byte[] NUM_PARC = new byte[3];
		public double DT_VCTO;
		public double VL_PARC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_PARC" , "DT_VCTO" , "VL_PARC");
		}

		public static class ByReference extends BlocoCRegistroC141 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC141 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC160 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public byte[] VEIC_ID = new byte[8];
		public int QTD_VOL;
		public double PESO_BRT;
		public double PESO_LIQ;
		public byte[] UF_ID = new byte[3];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "VEIC_ID" , "QTD_VOL" , "PESO_BRT" , "PESO_LIQ" , "UF_ID");
		}

		public static class ByReference extends BlocoCRegistroC160 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC160 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC165 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public byte[] VEIC_ID = new byte[8];
		public byte[] COD_AUT = new byte[61];
		public byte[] NR_PASSE = new byte[61];
		public byte[] HORA = new byte[7];
		public byte[] TEMPER = new byte[61];
		public int QTD_VOL;
		public double PESO_BRT;
		public double PESO_LIQ;
		public byte[] NOM_MOT = new byte[61];
		public byte[] CPF = new byte[12];
		public byte[] UF_ID = new byte[3];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "VEIC_ID" , "COD_AUT" , "NR_PASSE" , "HORA" , "TEMPER" , "QTD_VOL" , "PESO_BRT" , "PESO_LIQ" , "NOM_MOT" , "CPF" , "UF_ID");
		}

		public static class ByReference extends BlocoCRegistroC165 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC165 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC170 extends Structure implements Structure.ByValue {
		public byte[] NUM_ITEM = new byte[4];
		public byte[] COD_ITEM = new byte[61];
		public byte[] DESCR_COMPL = new byte[255];
		public double QTD;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public double VL_DESC;
		public int IND_MOV;
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public byte[] COD_NAT = new byte[11];
		public double VL_BC_ICMS;
		public double ALIQ_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_ST;
		public double ALIQ_ST;
		public double VL_ICMS_ST;
		public int IND_APUR;
		public byte[] CST_IPI = new byte[3];
		public byte[] COD_ENQ = new byte[4];
		public double VL_BC_IPI;
		public double ALIQ_IPI;
		public double VL_IPI;
		public byte[] CST_PIS = new byte[3];
		public double VL_BC_PIS;
		public double ALIQ_PIS_PERC;
		public double QUANT_BC_PIS;
		public double ALIQ_PIS_R;
		public double VL_PIS;
		public byte[] CST_COFINS = new byte[3];
		public double VL_BC_COFINS;
		public double ALIQ_COFINS_PERC;
		public double QUANT_BC_COFINS;
		public double ALIQ_COFINS_R;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_ITEM" , "COD_ITEM" , "DESCR_COMPL" , "QTD" , "UNID" , "VL_ITEM" , "VL_DESC" , "IND_MOV" , "CST_ICMS" , "CFOP" , "COD_NAT" , "VL_BC_ICMS" , "ALIQ_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "ALIQ_ST" , "VL_ICMS_ST" , "IND_APUR" , "CST_IPI" , "COD_ENQ" , "VL_BC_IPI" , "ALIQ_IPI" , "VL_IPI" , "CST_PIS" , "VL_BC_PIS" , "ALIQ_PIS_PERC" , "QUANT_BC_PIS" , "ALIQ_PIS_R" , "VL_PIS" , "CST_COFINS" , "VL_BC_COFINS" , "ALIQ_COFINS_PERC" , "QUANT_BC_COFINS" , "ALIQ_COFINS_R" , "VL_COFINS" , "COD_CTA");
		}

		public static class ByReference extends BlocoCRegistroC170 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC170 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC171 extends Structure implements Structure.ByValue {
		public byte[] NUM_TANQUE = new byte[4];
		public double QTDE;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_TANQUE" , "QTDE");
		}

		public static class ByReference extends BlocoCRegistroC171 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC171 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC172 extends Structure implements Structure.ByValue {
		public double VL_BC_ISSQN;
		public double ALIQ_ISSQN;
		public double VL_ISSQN;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("VL_BC_ISSQN" , "ALIQ_ISSQN" , "VL_ISSQN");
		}

		public static class ByReference extends BlocoCRegistroC172 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC172 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC173 extends Structure implements Structure.ByValue {
		public byte[] LOTE_MED = new byte[61];
		public double QTD_ITEM;
		public double DT_FAB;
		public double DT_VAL;
		public int IND_MED;
		public int TP_PROD;
		public double VL_TAB_MAX;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("LOTE_MED" , "QTD_ITEM" , "DT_FAB" , "DT_VAL" , "IND_MED" , "TP_PROD" , "VL_TAB_MAX");
		}

		public static class ByReference extends BlocoCRegistroC173 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC173 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC174 extends Structure implements Structure.ByValue {
		public int IND_ARM;
		public byte[] NUM_ARM = new byte[61];
		public byte[] DESCR_COMPL = new byte[255];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_ARM" , "NUM_ARM" , "DESCR_COMPL");
		}

		public static class ByReference extends BlocoCRegistroC174 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC174 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC175 extends Structure implements Structure.ByValue {
		public int IND_VEIC_OPER;
		public byte[] CNPJ = new byte[15];
		public byte[] UF = new byte[3];
		public byte[] CHASSI_VEIC = new byte[18];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_VEIC_OPER" , "CNPJ" , "UF" , "CHASSI_VEIC");
		}

		public static class ByReference extends BlocoCRegistroC175 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC175 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC176 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD_ULT_E = new byte[3];
		public byte[] NUM_DOC_ULT_E = new byte[10];
		public byte[] SER_ULT_E = new byte[4];
		public double DT_ULT_E;
		public byte[] COD_PART_ULT_E = new byte[61];
		public double QUANT_ULT_E;
		public double VL_UNIT_ULT_E;
		public double VL_UNIT_BC_ST;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD_ULT_E" , "NUM_DOC_ULT_E" , "SER_ULT_E" , "DT_ULT_E" , "COD_PART_ULT_E" , "QUANT_ULT_E" , "VL_UNIT_ULT_E" , "VL_UNIT_BC_ST");
		}

		public static class ByReference extends BlocoCRegistroC176 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC176 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC177 extends Structure implements Structure.ByValue {
		public byte[] COD_SELO_IPI = new byte[7];
		public double QT_SELO_IPI;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_SELO_IPI" , "QT_SELO_IPI");
		}

		public static class ByReference extends BlocoCRegistroC177 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC177 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC178 extends Structure implements Structure.ByValue {
		public byte[] CL_ENQ = new byte[6];
		public double VL_UNID;
		public double QUANT_PAD;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CL_ENQ" , "VL_UNID" , "QUANT_PAD");
		}

		public static class ByReference extends BlocoCRegistroC178 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC178 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC179 extends Structure implements Structure.ByValue {
		public double BC_ST_ORIG_DEST;
		public double ICMS_ST_REP;
		public double ICMS_ST_COMPL;
		public double BC_RET;
		public double ICMS_RET;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("BC_ST_ORIG_DEST" , "ICMS_ST_REP" , "ICMS_ST_COMPL" , "BC_RET" , "ICMS_RET");
		}

		public static class ByReference extends BlocoCRegistroC179 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC179 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC190 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_ST;
		public double VL_ICMS_ST;
		public double VL_RED_BC;
		public double VL_IPI;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "VL_RED_BC" , "VL_IPI" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC190 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC190 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC195 extends Structure implements Structure.ByValue {
		public byte[] COD_OBS = new byte[7];
		public byte[] TXT_COMPL = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_OBS" , "TXT_COMPL");
		}

		public static class ByReference extends BlocoCRegistroC195 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC195 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC197 extends Structure implements Structure.ByValue {
		public byte[] COD_AJ = new byte[11];
		public byte[] DESCR_COMPL_AJ = new byte[61];
		public byte[] COD_ITEM = new byte[255];
		public double VL_BC_ICMS;
		public double ALIQ_ICMS;
		public double VL_ICMS;
		public double VL_OUTROS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_AJ" , "DESCR_COMPL_AJ" , "COD_ITEM" , "VL_BC_ICMS" , "ALIQ_ICMS" , "VL_ICMS" , "VL_OUTROS");
		}

		public static class ByReference extends BlocoCRegistroC197 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC197 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC300 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC_INI = new byte[7];
		public byte[] NUM_DOC_FIN = new byte[7];
		public double DT_DOC;
		public double VL_DOC;
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "SER" , "SUB" , "NUM_DOC_INI" , "NUM_DOC_FIN" , "DT_DOC" , "VL_DOC" , "VL_PIS" , "VL_COFINS" , "COD_CTA");
		}

		public static class ByReference extends BlocoCRegistroC300 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC300 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC310 extends Structure implements Structure.ByValue {
		public byte[] NUM_DOC_CANC = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_DOC_CANC");
		}

		public static class ByReference extends BlocoCRegistroC310 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC310 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC320 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_RED_BC;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_RED_BC" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC320 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC320 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC321 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public double QTD;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public double VL_DESC;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_PIS;
		public double VL_COFINS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "QTD" , "UNID" , "VL_ITEM" , "VL_DESC" , "VL_BC_ICMS" , "VL_ICMS" , "VL_PIS" , "VL_COFINS");
		}

		public static class ByReference extends BlocoCRegistroC321 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC321 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC350 extends Structure implements Structure.ByValue {
		public byte[] SER = new byte[4];
		public byte[] SUB_SER = new byte[4];
		public byte[] NUM_DOC = new byte[7];
		public double DT_DOC;
		public byte[] CNPJ_CPF = new byte[15];
		public double VL_MERC;
		public double VL_DOC;
		public double VL_DESC;
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("SER" , "SUB_SER" , "NUM_DOC" , "DT_DOC" , "CNPJ_CPF" , "VL_MERC" , "VL_DOC" , "VL_DESC" , "VL_PIS" , "VL_COFINS" , "COD_CTA");
		}

		public static class ByReference extends BlocoCRegistroC350 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC350 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC370 extends Structure implements Structure.ByValue {
		public byte[] NUM_ITEM = new byte[4];
		public byte[] COD_ITEM = new byte[61];
		public double QTD;
		public byte[] UNID = new byte[4];
		public double VL_ITEM;
		public double VL_DESC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_ITEM" , "COD_ITEM" , "QTD" , "UNID" , "VL_ITEM" , "VL_DESC");
		}

		public static class ByReference extends BlocoCRegistroC370 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC370 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC390 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_RED_BC;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_RED_BC" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC390 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC390 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC400 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] ECF_MOD = new byte[21];
		public byte[] ECF_FAB = new byte[21];
		public byte[] ECF_CX = new byte[4];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "ECF_MOD" , "ECF_FAB" , "ECF_CX");
		}

		public static class ByReference extends BlocoCRegistroC400 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC400 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC405 extends Structure implements Structure.ByValue {
		public double DT_DOC;
		public int CRO;
		public int CRZ;
		public int NUM_COO_FIN;
		public double GT_FIN;
		public double VL_BRT;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_DOC" , "CRO" , "CRZ" , "NUM_COO_FIN" , "GT_FIN" , "VL_BRT");
		}

		public static class ByReference extends BlocoCRegistroC405 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC405 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC410 extends Structure implements Structure.ByValue {
		public double VL_PIS;
		public double VL_COFINS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("VL_PIS" , "VL_COFINS");
		}

		public static class ByReference extends BlocoCRegistroC410 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC410 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC420 extends Structure implements Structure.ByValue {
		public byte[] COD_TOT_PAR = new byte[8];
		public double VLR_ACUM_TOT;
		public int NR_TOT;
		public byte[] DESCR_NR_TOT = new byte[255];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_TOT_PAR" , "VLR_ACUM_TOT" , "NR_TOT" , "DESCR_NR_TOT");
		}

		public static class ByReference extends BlocoCRegistroC420 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC420 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC425 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public double QTD;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public double VL_PIS;
		public double VL_COFINS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "QTD" , "UNID" , "VL_ITEM" , "VL_PIS" , "VL_COFINS");
		}

		public static class ByReference extends BlocoCRegistroC425 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC425 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC460 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[7];
		public int COD_SIT;
		public byte[] NUM_DOC = new byte[15];
		public double DT_DOC;
		public double VL_DOC;
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] CPF_CNPJ = new byte[15];
		public byte[] NOM_ADQ = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "COD_SIT" , "NUM_DOC" , "DT_DOC" , "VL_DOC" , "VL_PIS" , "VL_COFINS" , "CPF_CNPJ" , "NOM_ADQ");
		}

		public static class ByReference extends BlocoCRegistroC460 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC460 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC470 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public double QTD;
		public double QTD_CANC;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_PIS;
		public double VL_COFINS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "QTD" , "QTD_CANC" , "UNID" , "VL_ITEM" , "CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_PIS" , "VL_COFINS");
		}

		public static class ByReference extends BlocoCRegistroC470 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC470 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC490 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC490 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC490 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC495 extends Structure implements Structure.ByValue {
		public double ALIQ_ICMS;
		public byte[] COD_ITEM = new byte[61];
		public double QTD;
		public double QTD_CANC;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public double VL_DESC;
		public double VL_CANC;
		public double VL_ACMO;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_ISEN;
		public double VL_NT;
		public double VL_ICMS_ST;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("ALIQ_ICMS" , "COD_ITEM" , "QTD" , "QTD_CANC" , "UNID" , "VL_ITEM" , "VL_DESC" , "VL_CANC" , "VL_ACMO" , "VL_BC_ICMS" , "VL_ICMS" , "VL_ISEN" , "VL_NT" , "VL_ICMS_ST");
		}

		public static class ByReference extends BlocoCRegistroC495 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC495 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC500 extends Structure implements Structure.ByValue {
		public int IND_OPER;
		public int IND_EMIT;
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public int COD_SIT;
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] COD_CONS = new byte[3];
		public byte[] NUM_DOC = new byte[10];
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
		public byte[] COD_INF = new byte[7];
		public double VL_PIS;
		public double VL_COFINS;
		public int TP_LIGACAO;
		public int COD_GRUPO_TENSAO;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_OPER" , "IND_EMIT" , "COD_PART" , "COD_MOD" , "COD_SIT" , "SER" , "SUB" , "COD_CONS" , "NUM_DOC" , "DT_DOC" , "DT_E_S" , "VL_DOC" , "VL_DESC" , "VL_FORN" , "VL_SERV_NT" , "VL_TERC" , "VL_DA" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "COD_INF" , "VL_PIS" , "VL_COFINS" , "TP_LIGACAO" , "COD_GRUPO_TENSAO");
		}

		public static class ByReference extends BlocoCRegistroC500 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC500 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC510 extends Structure implements Structure.ByValue {
		public byte[] NUM_ITEM = new byte[4];
		public byte[] COD_ITEM = new byte[61];
		public byte[] COD_CLASS = new byte[5];
		public double QTD;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public double VL_DESC;
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double VL_BC_ICMS;
		public double ALIQ_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_ST;
		public double ALIQ_ST;
		public double VL_ICMS_ST;
		public int IND_REC;
		public byte[] COD_PART = new byte[61];
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_ITEM" , "COD_ITEM" , "COD_CLASS" , "QTD" , "UNID" , "VL_ITEM" , "VL_DESC" , "CST_ICMS" , "CFOP" , "VL_BC_ICMS" , "ALIQ_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "ALIQ_ST" , "VL_ICMS_ST" , "IND_REC" , "COD_PART" , "VL_PIS" , "VL_COFINS" , "COD_CTA");
		}

		public static class ByReference extends BlocoCRegistroC510 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC510 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC590 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_ST;
		public double VL_ICMS_ST;
		public double VL_RED_BC;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "VL_RED_BC" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC590 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC590 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC600 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] COD_MUN = new byte[8];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] COD_CONS = new byte[3];
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

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "COD_MUN" , "SER" , "SUB" , "COD_CONS" , "QTD_CONS" , "QTD_CANC" , "DT_DOC" , "VL_DOC" , "VL_DESC" , "CONS" , "VL_FORN" , "VL_SERV_NT" , "VL_TERC" , "VL_DA" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "VL_PIS" , "VL_COFINS");
		}

		public static class ByReference extends BlocoCRegistroC600 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC600 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC601 extends Structure implements Structure.ByValue {
		public byte[] NUM_DOC_CANC = new byte[10];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_DOC_CANC");
		}

		public static class ByReference extends BlocoCRegistroC601 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC601 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC610 extends Structure implements Structure.ByValue {
		public byte[] COD_CLASS = new byte[5];
		public byte[] COD_ITEM = new byte[61];
		public double QTD;
		public byte[] UNID = new byte[7];
		public double VL_ITEM;
		public double VL_DESC;
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_ST;
		public double VL_ICMS_ST;
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_CLASS" , "COD_ITEM" , "QTD" , "UNID" , "VL_ITEM" , "VL_DESC" , "CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "VL_PIS" , "VL_COFINS" , "COD_CTA");
		}

		public static class ByReference extends BlocoCRegistroC610 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC610 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC690 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_RED_BC;
		public double VL_BC_ICMS_ST;
		public double VL_ICMS_ST;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_RED_BC" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC690 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC690 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC700 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public int NRO_ORD_INI;
		public int NRO_ORD_FIN;
		public double DT_DOC_INI;
		public double DT_DOC_FIN;
		public byte[] NOM_MEST = new byte[16];
		public byte[] CHV_COD_DIG = new byte[33];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "SER" , "NRO_ORD_INI" , "NRO_ORD_FIN" , "DT_DOC_INI" , "DT_DOC_FIN" , "NOM_MEST" , "CHV_COD_DIG");
		}

		public static class ByReference extends BlocoCRegistroC700 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC700 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC790 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_ST;
		public double VL_ICMS_ST;
		public double VL_RED_BC;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_ST" , "VL_ICMS_ST" , "VL_RED_BC" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC790 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC790 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC791 extends Structure implements Structure.ByValue {
		public byte[] UF = new byte[3];
		public double VL_BC_ICMS_ST;
		public double VL_ICMS_ST;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("UF" , "VL_BC_ICMS_ST" , "VL_ICMS_ST");
		}

		public static class ByReference extends BlocoCRegistroC791 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC791 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC800 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public int COD_SIT;
		public byte[] NUM_CFE = new byte[7];
		public double DT_DOC;
		public double VL_CFE;
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] CNPJ_CPF = new byte[15];
		public byte[] NR_SAT = new byte[10];
		public byte[] CHV_CFE = new byte[45];
		public double VL_DESC;
		public double VL_MERC;
		public double VL_OUT_DA;
		public double VL_ICMS;
		public double VL_PIS_ST;
		public double VL_COFINS_ST;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "COD_SIT" , "NUM_CFE" , "DT_DOC" , "VL_CFE" , "VL_PIS" , "VL_COFINS" , "CNPJ_CPF" , "NR_SAT" , "CHV_CFE" , "VL_DESC" , "VL_MERC" , "VL_OUT_DA" , "VL_ICMS" , "VL_PIS_ST" , "VL_COFINS_ST");
		}

		public static class ByReference extends BlocoCRegistroC800 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC800 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC850 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC850 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC850 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC860 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] NR_SAT = new byte[10];
		public double DT_DOC;
		public byte[] DOC_INI = new byte[7];
		public byte[] DOC_FIN = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "NR_SAT" , "DT_DOC" , "DOC_INI" , "DOC_FIN");
		}

		public static class ByReference extends BlocoCRegistroC860 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC860 implements Structure.ByValue { }
	}

	public static class BlocoCRegistroC890 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "COD_OBS");
		}

		public static class ByReference extends BlocoCRegistroC890 implements Structure.ByReference { }
		public static class ByValue extends BlocoCRegistroC890 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends BlocoDRegistroD001 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD001 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD100 extends Structure implements Structure.ByValue {
		public int IND_OPER;
		public int IND_EMIT;
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public int COD_SIT;
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public byte[] CHV_CTE = new byte[45];
		public double DT_DOC;
		public double DT_A_P;
		public byte[] TP_CT_e = new byte[2];
		public byte[] CHV_CTE_REF = new byte[45];
		public double VL_DOC;
		public double VL_DESC;
		public int IND_FRT;
		public double VL_SERV;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_NT;
		public byte[] COD_INF = new byte[7];
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_OPER" , "IND_EMIT" , "COD_PART" , "COD_MOD" , "COD_SIT" , "SER" , "SUB" , "NUM_DOC" , "CHV_CTE" , "DT_DOC" , "DT_A_P" , "TP_CT_e" , "CHV_CTE_REF" , "VL_DOC" , "VL_DESC" , "IND_FRT" , "VL_SERV" , "VL_BC_ICMS" , "VL_ICMS" , "VL_NT" , "COD_INF" , "COD_CTA");
		}

		public static class ByReference extends BlocoDRegistroD100 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD100 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD110 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public int NUN_ITEM;
		public double VL_SERV;
		public double VL_OUT;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "NUN_ITEM" , "VL_SERV" , "VL_OUT");
		}

		public static class ByReference extends BlocoDRegistroD110 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD110 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD120 extends Structure implements Structure.ByValue {
		public byte[] COD_MUN_ORIG = new byte[8];
		public byte[] COD_MUN_DEST = new byte[8];
		public byte[] VEIC_ID = new byte[8];
		public byte[] UF_ID = new byte[3];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MUN_ORIG" , "COD_MUN_DEST" , "VEIC_ID" , "UF_ID");
		}

		public static class ByReference extends BlocoDRegistroD120 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD120 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD130 extends Structure implements Structure.ByValue {
		public byte[] COD_PART_CONSG = new byte[61];
		public byte[] COD_PART_RED = new byte[61];
		public int IND_FRT_RED;
		public byte[] COD_MUN_ORIG = new byte[8];
		public byte[] COD_MUN_DEST = new byte[8];
		public byte[] VEIC_ID = new byte[8];
		public double VL_LIQ_FRT;
		public double VL_SEC_CAT;
		public double VL_DESP;
		public double VL_PEDG;
		public double VL_OUT;
		public double VL_FRT;
		public byte[] UF_ID = new byte[3];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART_CONSG" , "COD_PART_RED" , "IND_FRT_RED" , "COD_MUN_ORIG" , "COD_MUN_DEST" , "VEIC_ID" , "VL_LIQ_FRT" , "VL_SEC_CAT" , "VL_DESP" , "VL_PEDG" , "VL_OUT" , "VL_FRT" , "UF_ID");
		}

		public static class ByReference extends BlocoDRegistroD130 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD130 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD140 extends Structure implements Structure.ByValue {
		public byte[] COD_PART_CONSG = new byte[61];
		public byte[] COD_MUN_ORIG = new byte[8];
		public byte[] COD_MUN_DEST = new byte[8];
		public byte[] IND_VEIC = new byte[2];
		public int VEIC_ID;
		public int IND_NAV;
		public byte[] VIAGEM = new byte[61];
		public double VL_FRT_LIQ;
		public double VL_DESP_PORT;
		public double VL_DESP_CAR_DESC;
		public double VL_OUT;
		public double VL_FRT_BRT;
		public double VL_FRT_MM;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART_CONSG" , "COD_MUN_ORIG" , "COD_MUN_DEST" , "IND_VEIC" , "VEIC_ID" , "IND_NAV" , "VIAGEM" , "VL_FRT_LIQ" , "VL_DESP_PORT" , "VL_DESP_CAR_DESC" , "VL_OUT" , "VL_FRT_BRT" , "VL_FRT_MM");
		}

		public static class ByReference extends BlocoDRegistroD140 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD140 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD150 extends Structure implements Structure.ByValue {
		public byte[] COD_MUN_ORIG = new byte[8];
		public byte[] COD_MUN_DEST = new byte[8];
		public byte[] VEIC_ID = new byte[61];
		public byte[] VIAGEM = new byte[61];
		public int IND_TFA;
		public double VL_PESO_TX;
		public double VL_TX_TERR;
		public double VL_TX_RED;
		public double VL_OUT;
		public double VL_TX_ADV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MUN_ORIG" , "COD_MUN_DEST" , "VEIC_ID" , "VIAGEM" , "IND_TFA" , "VL_PESO_TX" , "VL_TX_TERR" , "VL_TX_RED" , "VL_OUT" , "VL_TX_ADV");
		}

		public static class ByReference extends BlocoDRegistroD150 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD150 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD160 extends Structure implements Structure.ByValue {
		public byte[] DESPACHO = new byte[61];
		public byte[] CNPJ_CPF_REM = new byte[15];
		public byte[] IE_REM = new byte[15];
		public byte[] COD_MUN_ORI = new byte[8];
		public byte[] CNPJ_CPF_DEST = new byte[15];
		public byte[] IE_DEST = new byte[15];
		public byte[] COD_MUN_DEST = new byte[8];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DESPACHO" , "CNPJ_CPF_REM" , "IE_REM" , "COD_MUN_ORI" , "CNPJ_CPF_DEST" , "IE_DEST" , "COD_MUN_DEST");
		}

		public static class ByReference extends BlocoDRegistroD160 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD160 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD161 extends Structure implements Structure.ByValue {
		public int IND_CARGA;
		public byte[] CNPJ_COL = new byte[15];
		public byte[] IE_COL = new byte[15];
		public byte[] COD_MUN_COL = new byte[8];
		public byte[] CNPJ_ENTG = new byte[15];
		public byte[] IE_ENTG = new byte[15];
		public byte[] COD_MUN_ENTG = new byte[8];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_CARGA" , "CNPJ_COL" , "IE_COL" , "COD_MUN_COL" , "CNPJ_ENTG" , "IE_ENTG" , "COD_MUN_ENTG");
		}

		public static class ByReference extends BlocoDRegistroD161 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD161 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD162 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] NUM_DOC = new byte[10];
		public double DT_DOC;
		public double VL_DOC;
		public double VL_MERC;
		public double QTD_VOL;
		public double PESO_BRT;
		public double PESO_LIQ;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "SER" , "NUM_DOC" , "DT_DOC" , "VL_DOC" , "VL_MERC" , "QTD_VOL" , "PESO_BRT" , "PESO_LIQ");
		}

		public static class ByReference extends BlocoDRegistroD162 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD162 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD170 extends Structure implements Structure.ByValue {
		public byte[] COD_PART_CONSG = new byte[61];
		public byte[] COD_PART_RED = new byte[61];
		public byte[] COD_MUN_ORIG = new byte[8];
		public byte[] COD_MUN_DEST = new byte[8];
		public byte[] OTM = new byte[61];
		public int IND_NAT_FRT;
		public double VL_LIQ_FRT;
		public double VL_GRIS;
		public double VL_PDG;
		public double VL_OUT;
		public double VL_FRT;
		public byte[] VEIC_ID = new byte[8];
		public byte[] UF_ID = new byte[3];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART_CONSG" , "COD_PART_RED" , "COD_MUN_ORIG" , "COD_MUN_DEST" , "OTM" , "IND_NAT_FRT" , "VL_LIQ_FRT" , "VL_GRIS" , "VL_PDG" , "VL_OUT" , "VL_FRT" , "VEIC_ID" , "UF_ID");
		}

		public static class ByReference extends BlocoDRegistroD170 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD170 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD180 extends Structure implements Structure.ByValue {
		public byte[] NUM_SEQ = new byte[61];
		public int IND_EMIT;
		public byte[] CNPJ_EMIT = new byte[15];
		public byte[] UF_EMIT = new byte[3];
		public byte[] IE_EMIT = new byte[15];
		public byte[] COD_MUN_ORIG = new byte[8];
		public byte[] CNPJ_CPF_TOM = new byte[15];
		public byte[] UF_TOM = new byte[3];
		public byte[] IE_TOM = new byte[15];
		public byte[] COD_MUN_DEST = new byte[8];
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public double DT_DOC;
		public double VL_DOC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_SEQ" , "IND_EMIT" , "CNPJ_EMIT" , "UF_EMIT" , "IE_EMIT" , "COD_MUN_ORIG" , "CNPJ_CPF_TOM" , "UF_TOM" , "IE_TOM" , "COD_MUN_DEST" , "COD_MOD" , "SER" , "SUB" , "NUM_DOC" , "DT_DOC" , "VL_DOC");
		}

		public static class ByReference extends BlocoDRegistroD180 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD180 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD190 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_RED_BC;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_RED_BC" , "COD_OBS");
		}

		public static class ByReference extends BlocoDRegistroD190 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD190 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD195 extends Structure implements Structure.ByValue {
		public byte[] COD_OBS = new byte[7];
		public byte[] TXT_COMPL = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_OBS" , "TXT_COMPL");
		}

		public static class ByReference extends BlocoDRegistroD195 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD195 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD197 extends Structure implements Structure.ByValue {
		public byte[] COD_AJ = new byte[11];
		public byte[] DESCR_COMPL_AJ = new byte[255];
		public byte[] COD_ITEM = new byte[61];
		public double VL_BC_ICMS;
		public double ALIQ_ICMS;
		public double VL_ICMS;
		public double VL_OUTROS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_AJ" , "DESCR_COMPL_AJ" , "COD_ITEM" , "VL_BC_ICMS" , "ALIQ_ICMS" , "VL_ICMS" , "VL_OUTROS");
		}

		public static class ByReference extends BlocoDRegistroD197 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD197 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD300 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC_INI = new byte[7];
		public byte[] NUM_DOC_FIN = new byte[7];
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
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
		public byte[] COD_OBS = new byte[7];
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "SER" , "SUB" , "NUM_DOC_INI" , "NUM_DOC_FIN" , "CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "DT_DOC" , "VL_OPR" , "VL_DESC" , "VL_SERV" , "VL_SEG" , "VL_OUT_DESP" , "VL_BC_ICMS" , "VL_ICMS" , "VL_RED_BC" , "COD_OBS" , "COD_CTA");
		}

		public static class ByReference extends BlocoDRegistroD300 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD300 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD301 extends Structure implements Structure.ByValue {
		public byte[] NUM_DOC_CANC = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_DOC_CANC");
		}

		public static class ByReference extends BlocoDRegistroD301 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD301 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD310 extends Structure implements Structure.ByValue {
		public byte[] COD_MUN_ORIG = new byte[8];
		public double VL_SERV;
		public double VL_BC_ICMS;
		public double VL_ICMS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MUN_ORIG" , "VL_SERV" , "VL_BC_ICMS" , "VL_ICMS");
		}

		public static class ByReference extends BlocoDRegistroD310 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD310 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD350 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] ECF_MOD = new byte[21];
		public byte[] ECF_FAB = new byte[21];
		public byte[] ECF_CX = new byte[4];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "ECF_MOD" , "ECF_FAB" , "ECF_CX");
		}

		public static class ByReference extends BlocoDRegistroD350 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD350 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD355 extends Structure implements Structure.ByValue {
		public double DT_DOC;
		public int CRO;
		public int CRZ;
		public int NUM_COO_FIN;
		public double GT_FIN;
		public double VL_BRT;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_DOC" , "CRO" , "CRZ" , "NUM_COO_FIN" , "GT_FIN" , "VL_BRT");
		}

		public static class ByReference extends BlocoDRegistroD355 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD355 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD360 extends Structure implements Structure.ByValue {
		public double VL_PIS;
		public double VL_COFINS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("VL_PIS" , "VL_COFINS");
		}

		public static class ByReference extends BlocoDRegistroD360 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD360 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD365 extends Structure implements Structure.ByValue {
		public byte[] COD_TOT_PAR = new byte[8];
		public double VLR_ACUM_TOT;
		public double NR_TOT;
		public byte[] DESCR_NR_TOT = new byte[255];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_TOT_PAR" , "VLR_ACUM_TOT" , "NR_TOT" , "DESCR_NR_TOT");
		}

		public static class ByReference extends BlocoDRegistroD365 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD365 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD370 extends Structure implements Structure.ByValue {
		public byte[] COD_MUN_ORIG = new byte[8];
		public double VL_SERV;
		public double QTD_BILH;
		public double VL_BC_ICMS;
		public double VL_ICMS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MUN_ORIG" , "VL_SERV" , "QTD_BILH" , "VL_BC_ICMS" , "VL_ICMS");
		}

		public static class ByReference extends BlocoDRegistroD370 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD370 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD390 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ISSQN;
		public double ALIQ_ISSQN;
		public double VL_ISSQN;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ISSQN" , "ALIQ_ISSQN" , "VL_ISSQN" , "VL_BC_ICMS" , "VL_ICMS" , "COD_OBS");
		}

		public static class ByReference extends BlocoDRegistroD390 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD390 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD400 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public int COD_SIT;
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC = new byte[7];
		public double DT_DOC;
		public double VL_DOC;
		public double VL_DESC;
		public double VL_SERV;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "COD_MOD" , "COD_SIT" , "SER" , "SUB" , "NUM_DOC" , "DT_DOC" , "VL_DOC" , "VL_DESC" , "VL_SERV" , "VL_BC_ICMS" , "VL_ICMS" , "VL_PIS" , "VL_COFINS" , "COD_CTA");
		}

		public static class ByReference extends BlocoDRegistroD400 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD400 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD410 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC_INI = new byte[7];
		public byte[] NUM_DOC_FIN = new byte[7];
		public double DT_DOC;
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_DESC;
		public double VL_SERV;
		public double VL_BC_ICMS;
		public double VL_ICMS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "SER" , "SUB" , "NUM_DOC_INI" , "NUM_DOC_FIN" , "DT_DOC" , "CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_DESC" , "VL_SERV" , "VL_BC_ICMS" , "VL_ICMS");
		}

		public static class ByReference extends BlocoDRegistroD410 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD410 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD411 extends Structure implements Structure.ByValue {
		public byte[] NUM_DOC_CANC = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_DOC_CANC");
		}

		public static class ByReference extends BlocoDRegistroD411 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD411 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD420 extends Structure implements Structure.ByValue {
		public byte[] COD_MUN_ORIG = new byte[8];
		public double VL_SERV;
		public double VL_BC_ICMS;
		public double VL_ICMS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MUN_ORIG" , "VL_SERV" , "VL_BC_ICMS" , "VL_ICMS");
		}

		public static class ByReference extends BlocoDRegistroD420 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD420 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD500 extends Structure implements Structure.ByValue {
		public int IND_OPER;
		public int IND_EMIT;
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public int COD_SIT;
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public double DT_DOC;
		public double DT_A_P;
		public double VL_DOC;
		public double VL_DESC;
		public double VL_SERV;
		public double VL_SERV_NT;
		public double VL_TERC;
		public double VL_DA;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public byte[] COD_INF = new byte[7];
		public double VL_PIS;
		public double VL_COFINS;
		public byte[] COD_CTA = new byte[61];
		public int TP_ASSINANTE;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_OPER" , "IND_EMIT" , "COD_PART" , "COD_MOD" , "COD_SIT" , "SER" , "SUB" , "NUM_DOC" , "DT_DOC" , "DT_A_P" , "VL_DOC" , "VL_DESC" , "VL_SERV" , "VL_SERV_NT" , "VL_TERC" , "VL_DA" , "VL_BC_ICMS" , "VL_ICMS" , "COD_INF" , "VL_PIS" , "VL_COFINS" , "COD_CTA" , "TP_ASSINANTE");
		}

		public static class ByReference extends BlocoDRegistroD500 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD500 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD510 extends Structure implements Structure.ByValue {
		public int IND_REC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_REC");
		}

		public static class ByReference extends BlocoDRegistroD510 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD510 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD530 extends Structure implements Structure.ByValue {
		public int IND_SERV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_SERV");
		}

		public static class ByReference extends BlocoDRegistroD530 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD530 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD590 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_UF;
		public double VL_ICMS_UF;
		public double VL_RED_BC;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_UF" , "VL_ICMS_UF" , "VL_RED_BC" , "COD_OBS");
		}

		public static class ByReference extends BlocoDRegistroD590 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD590 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD600 extends Structure implements Structure.ByValue {

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList();
		}

		public static class ByReference extends BlocoDRegistroD600 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD600 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD610 extends Structure implements Structure.ByValue {

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList();
		}

		public static class ByReference extends BlocoDRegistroD610 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD610 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD690 extends Structure implements Structure.ByValue {

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList();
		}

		public static class ByReference extends BlocoDRegistroD690 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD690 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD695 extends Structure implements Structure.ByValue {
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public int NRO_ORD_INI;
		public int NRO_ORD_FIN;
		public double DT_DOC_INI;
		public double DT_DOC_FIN;
		public byte[] NOM_MEST = new byte[16];
		public byte[] CHV_COD_DIG = new byte[33];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_MOD" , "SER" , "NRO_ORD_INI" , "NRO_ORD_FIN" , "DT_DOC_INI" , "DT_DOC_FIN" , "NOM_MEST" , "CHV_COD_DIG");
		}

		public static class ByReference extends BlocoDRegistroD695 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD695 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD696 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public byte[] CFOP = new byte[5];
		public double ALIQ_ICMS;
		public double VL_OPR;
		public double VL_BC_ICMS;
		public double VL_ICMS;
		public double VL_BC_ICMS_UF;
		public double VL_ICMS_UF;
		public double VL_RED_BC;
		public byte[] COD_OBS = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "CFOP" , "ALIQ_ICMS" , "VL_OPR" , "VL_BC_ICMS" , "VL_ICMS" , "VL_BC_ICMS_UF" , "VL_ICMS_UF" , "VL_RED_BC" , "COD_OBS");
		}

		public static class ByReference extends BlocoDRegistroD696 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD696 implements Structure.ByValue { }
	}

	public static class BlocoDRegistroD697 extends Structure implements Structure.ByValue {
		public byte[] UF = new byte[3];
		public double VL_BC_ICMS;
		public double VL_ICMS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("UF" , "VL_BC_ICMS" , "VL_ICMS");
		}

		public static class ByReference extends BlocoDRegistroD697 implements Structure.ByReference { }
		public static class ByValue extends BlocoDRegistroD697 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends BlocoERegistroE001 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE001 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE100 extends Structure implements Structure.ByValue {
		public double DT_INI;
		public double DT_FIN;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_INI" , "DT_FIN");
		}

		public static class ByReference extends BlocoERegistroE100 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE100 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE110 extends Structure implements Structure.ByValue {
		public double VL_TOT_DEBITOS;
		public double VL_AJ_DEBITOS;
		public double VL_TOT_AJ_DEBITOS;
		public double VL_ESTORNOS_CRED;
		public double VL_TOT_CREDITOS;
		public double VL_AJ_CREDITOS;
		public double VL_TOT_AJ_CREDITOS;
		public double VL_ESTORNOS_DEB;
		public double VL_SLD_CREDOR_ANT;
		public double VL_SLD_APURADO;
		public double VL_TOT_DED;
		public double VL_ICMS_RECOLHER;
		public double VL_SLD_CREDOR_TRANSPORTAR;
		public double DEB_ESP;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("VL_TOT_DEBITOS" , "VL_AJ_DEBITOS" , "VL_TOT_AJ_DEBITOS" , "VL_ESTORNOS_CRED" , "VL_TOT_CREDITOS" , "VL_AJ_CREDITOS" , "VL_TOT_AJ_CREDITOS" , "VL_ESTORNOS_DEB" , "VL_SLD_CREDOR_ANT" , "VL_SLD_APURADO" , "VL_TOT_DED" , "VL_ICMS_RECOLHER" , "VL_SLD_CREDOR_TRANSPORTAR" , "DEB_ESP");
		}

		public static class ByReference extends BlocoERegistroE110 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE110 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE111 extends Structure implements Structure.ByValue {
		public byte[] COD_AJ_APUR = new byte[9];
		public byte[] DESCR_COMPL_AJ = new byte[255];
		public double VL_AJ_APUR;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_AJ_APUR" , "DESCR_COMPL_AJ" , "VL_AJ_APUR");
		}

		public static class ByReference extends BlocoERegistroE111 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE111 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE112 extends Structure implements Structure.ByValue {
		public byte[] NUM_DA = new byte[61];
		public byte[] NUM_PROC = new byte[16];
		public int IND_PROC;
		public byte[] PROC = new byte[1024];
		public byte[] TXT_COMPL = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_DA" , "NUM_PROC" , "IND_PROC" , "PROC" , "TXT_COMPL");
		}

		public static class ByReference extends BlocoERegistroE112 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE112 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE113 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public double DT_DOC;
		public byte[] CHV_NFE = new byte[45];
		public byte[] COD_ITEM = new byte[61];
		public double VL_AJ_ITEM;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "COD_MOD" , "SER" , "SUB" , "NUM_DOC" , "DT_DOC" , "CHV_NFE" , "COD_ITEM" , "VL_AJ_ITEM");
		}

		public static class ByReference extends BlocoERegistroE113 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE113 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE115 extends Structure implements Structure.ByValue {
		public byte[] COD_INF_ADIC = new byte[9];
		public double VL_INF_ADIC;
		public byte[] DESCR_COMPL_AJ = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_INF_ADIC" , "VL_INF_ADIC" , "DESCR_COMPL_AJ");
		}

		public static class ByReference extends BlocoERegistroE115 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE115 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE116 extends Structure implements Structure.ByValue {
		public byte[] COD_OR = new byte[4];
		public double VL_OR;
		public double DT_VCTO;
		public byte[] COD_REC = new byte[61];
		public byte[] NUM_PROC = new byte[16];
		public int IND_PROC;
		public byte[] PROC = new byte[1024];
		public byte[] TXT_COMPL = new byte[1024];
		public byte[] MES_REF = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_OR" , "VL_OR" , "DT_VCTO" , "COD_REC" , "NUM_PROC" , "IND_PROC" , "PROC" , "TXT_COMPL" , "MES_REF");
		}

		public static class ByReference extends BlocoERegistroE116 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE116 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE200 extends Structure implements Structure.ByValue {
		public byte[] UF = new byte[3];
		public double DT_INI;
		public double DT_FIN;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("UF" , "DT_INI" , "DT_FIN");
		}

		public static class ByReference extends BlocoERegistroE200 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE200 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE210 extends Structure implements Structure.ByValue {
		public int IND_MOV_ST;
		public double VL_SLD_CRED_ANT_ST;
		public double VL_DEVOL_ST;
		public double VL_RESSARC_ST;
		public double VL_OUT_CRED_ST;
		public double VL_AJ_CREDITOS_ST;
		public double VL_RETENCAO_ST;
		public double VL_OUT_DEB_ST;
		public double VL_AJ_DEBITOS_ST;
		public double VL_SLD_DEV_ANT_ST;
		public double VL_DEDUCOES_ST;
		public double VL_ICMS_RECOL_ST;
		public double VL_SLD_CRED_ST_TRANSPORTAR;
		public double DEB_ESP_ST;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV_ST" , "VL_SLD_CRED_ANT_ST" , "VL_DEVOL_ST" , "VL_RESSARC_ST" , "VL_OUT_CRED_ST" , "VL_AJ_CREDITOS_ST" , "VL_RETENCAO_ST" , "VL_OUT_DEB_ST" , "VL_AJ_DEBITOS_ST" , "VL_SLD_DEV_ANT_ST" , "VL_DEDUCOES_ST" , "VL_ICMS_RECOL_ST" , "VL_SLD_CRED_ST_TRANSPORTAR" , "DEB_ESP_ST");
		}

		public static class ByReference extends BlocoERegistroE210 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE210 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE220 extends Structure implements Structure.ByValue {
		public byte[] COD_AJ_APUR = new byte[9];
		public byte[] DESCR_COMPL_AJ = new byte[1024];
		public double VL_AJ_APUR;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_AJ_APUR" , "DESCR_COMPL_AJ" , "VL_AJ_APUR");
		}

		public static class ByReference extends BlocoERegistroE220 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE220 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE230 extends Structure implements Structure.ByValue {
		public byte[] NUM_DA = new byte[61];
		public byte[] NUM_PROC = new byte[16];
		public int IND_PROC;
		public byte[] PROC = new byte[1024];
		public byte[] TXT_COMPL = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_DA" , "NUM_PROC" , "IND_PROC" , "PROC" , "TXT_COMPL");
		}

		public static class ByReference extends BlocoERegistroE230 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE230 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE240 extends Structure implements Structure.ByValue {
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public byte[] SER = new byte[5];
		public byte[] SUB = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public double DT_DOC;
		public byte[] CHV_NFE = new byte[45];
		public byte[] COD_ITEM = new byte[61];
		public double VL_AJ_ITEM;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_PART" , "COD_MOD" , "SER" , "SUB" , "NUM_DOC" , "DT_DOC" , "CHV_NFE" , "COD_ITEM" , "VL_AJ_ITEM");
		}

		public static class ByReference extends BlocoERegistroE240 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE240 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE250 extends Structure implements Structure.ByValue {
		public byte[] COD_OR = new byte[4];
		public double VL_OR;
		public double DT_VCTO;
		public byte[] COD_REC = new byte[61];
		public byte[] NUM_PROC = new byte[16];
		public int IND_PROC;
		public byte[] PROC = new byte[1024];
		public byte[] TXT_COMPL = new byte[1024];
		public byte[] MES_REF = new byte[7];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_OR" , "VL_OR" , "DT_VCTO" , "COD_REC" , "NUM_PROC" , "IND_PROC" , "PROC" , "TXT_COMPL" , "MES_REF");
		}

		public static class ByReference extends BlocoERegistroE250 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE250 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE500 extends Structure implements Structure.ByValue {
		public int IND_APUR;
		public double DT_INI;
		public double DT_FIN;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_APUR" , "DT_INI" , "DT_FIN");
		}

		public static class ByReference extends BlocoERegistroE500 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE500 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE510 extends Structure implements Structure.ByValue {
		public byte[] CFOP = new byte[5];
		public byte[] CST_IPI = new byte[3];
		public double VL_CONT_IPI;
		public double VL_BC_IPI;
		public double VL_IPI;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CFOP" , "CST_IPI" , "VL_CONT_IPI" , "VL_BC_IPI" , "VL_IPI");
		}

		public static class ByReference extends BlocoERegistroE510 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE510 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE520 extends Structure implements Structure.ByValue {
		public double VL_SD_ANT_IPI;
		public double VL_DEB_IPI;
		public double VL_CRED_IPI;
		public double VL_OD_IPI;
		public double VL_OC_IPI;
		public double VL_SC_IPI;
		public double VL_SD_IPI;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("VL_SD_ANT_IPI" , "VL_DEB_IPI" , "VL_CRED_IPI" , "VL_OD_IPI" , "VL_OC_IPI" , "VL_SC_IPI" , "VL_SD_IPI");
		}

		public static class ByReference extends BlocoERegistroE520 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE520 implements Structure.ByValue { }
	}

	public static class BlocoERegistroE530 extends Structure implements Structure.ByValue {
		public int IND_AJ;
		public double VL_AJ;
		public byte[] COD_AJ = new byte[4];
		public int IND_DOC;
		public byte[] NUM_DOC = new byte[61];
		public byte[] DESCR_AJ = new byte[1024];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_AJ" , "VL_AJ" , "COD_AJ" , "IND_DOC" , "NUM_DOC" , "DESCR_AJ");
		}

		public static class ByReference extends BlocoERegistroE530 implements Structure.ByReference { }
		public static class ByValue extends BlocoERegistroE530 implements Structure.ByValue { }
	}

	public static class BlocoGRegistroG001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends BlocoGRegistroG001 implements Structure.ByReference { }
		public static class ByValue extends BlocoGRegistroG001 implements Structure.ByValue { }
	}

	public static class BlocoGRegistroG110 extends Structure implements Structure.ByValue {
		public byte[] MODO_CIAP = new byte[61];
		public double SALDO_IN_ICMS;
		public double SALDO_FN_ICMS;
		public double SOM_PARC;
		public double VL_TRIB_EXP;
		public double VL_TOTAL;
		public double IND_PER_SAI;
		public double ICMS_APROP;
		public double SOM_ICMS_OC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("MODO_CIAP" , "SALDO_IN_ICMS" , "SALDO_FN_ICMS" , "SOM_PARC" , "VL_TRIB_EXP" , "VL_TOTAL" , "IND_PER_SAI" , "ICMS_APROP" , "SOM_ICMS_OC");
		}

		public static class ByReference extends BlocoGRegistroG110 implements Structure.ByReference { }
		public static class ByValue extends BlocoGRegistroG110 implements Structure.ByValue { }
	}

	public static class BlocoGRegistroG125 extends Structure implements Structure.ByValue {
		public byte[] COD_IND_BEM = new byte[61];
		public double DT_MOV;
		public int TIPO_MOV;
		public double VL_IMOB_ICMS_OP;
		public double VL_IMOB_ICMS_ST;
		public double VL_IMOB_ICMS_FRT;
		public double VL_IMOB_ICMS_DIF;
		public int NUM_PARC;
		public double VL_PARC_PASS;
		public double VL_PARC_APROP;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_IND_BEM" , "DT_MOV" , "TIPO_MOV" , "VL_IMOB_ICMS_OP" , "VL_IMOB_ICMS_ST" , "VL_IMOB_ICMS_FRT" , "VL_IMOB_ICMS_DIF" , "NUM_PARC" , "VL_PARC_PASS" , "VL_PARC_APROP");
		}

		public static class ByReference extends BlocoGRegistroG125 implements Structure.ByReference { }
		public static class ByValue extends BlocoGRegistroG125 implements Structure.ByValue { }
	}

	public static class BlocoGRegistroG126 extends Structure implements Structure.ByValue {
		public double DT_INI;
		public double DT_FIN;
		public int NUM_PARC;
		public double VL_PARC_PASS;
		public double VL_TRIB_OC;
		public double VL_TOTAL;
		public double IND_PER_SAI;
		public double VL_PARC_APROP;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_INI" , "DT_FIN" , "NUM_PARC" , "VL_PARC_PASS" , "VL_TRIB_OC" , "VL_TOTAL" , "IND_PER_SAI" , "VL_PARC_APROP");
		}

		public static class ByReference extends BlocoGRegistroG126 implements Structure.ByReference { }
		public static class ByValue extends BlocoGRegistroG126 implements Structure.ByValue { }
	}

	public static class BlocoGRegistroG130 extends Structure implements Structure.ByValue {
		public int IND_EMIT;
		public byte[] COD_PART = new byte[61];
		public byte[] COD_MOD = new byte[3];
		public byte[] SERIE = new byte[4];
		public byte[] NUM_DOC = new byte[10];
		public byte[] CHV_NFE_CTE = new byte[45];
		public double DT_DOC;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_EMIT" , "COD_PART" , "COD_MOD" , "SERIE" , "NUM_DOC" , "CHV_NFE_CTE" , "DT_DOC");
		}

		public static class ByReference extends BlocoGRegistroG130 implements Structure.ByReference { }
		public static class ByValue extends BlocoGRegistroG130 implements Structure.ByValue { }
	}

	public static class BlocoGRegistroG140 extends Structure implements Structure.ByValue {
		public byte[] NUM_ITEM = new byte[4];
		public byte[] COD_ITEM = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NUM_ITEM" , "COD_ITEM");
		}

		public static class ByReference extends BlocoGRegistroG140 implements Structure.ByReference { }
		public static class ByValue extends BlocoGRegistroG140 implements Structure.ByValue { }
	}

	public static class BlocoHRegistroH001 extends Structure implements Structure.ByValue {
		public int IND_MOV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("IND_MOV");
		}

		public static class ByReference extends BlocoHRegistroH001 implements Structure.ByReference { }
		public static class ByValue extends BlocoHRegistroH001 implements Structure.ByValue { }
	}

	public static class BlocoHRegistroH005 extends Structure implements Structure.ByValue {
		public double DT_INV;
		public double VL_INV;
		public int MOT_INV;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("DT_INV" , "VL_INV" , "MOT_INV");
		}

		public static class ByReference extends BlocoHRegistroH005 implements Structure.ByReference { }
		public static class ByValue extends BlocoHRegistroH005 implements Structure.ByValue { }
	}

	public static class BlocoHRegistroH010 extends Structure implements Structure.ByValue {
		public byte[] COD_ITEM = new byte[61];
		public byte[] UNID = new byte[7];
		public double QTD;
		public double VL_UNIT;
		public double VL_ITEM;
		public int IND_PROP;
		public byte[] COD_PART = new byte[61];
		public byte[] TXT_COMPL = new byte[1024];
		public byte[] COD_CTA = new byte[61];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("COD_ITEM" , "UNID" , "QTD" , "VL_UNIT" , "VL_ITEM" , "IND_PROP" , "COD_PART" , "TXT_COMPL" , "COD_CTA");
		}

		public static class ByReference extends BlocoHRegistroH010 implements Structure.ByReference { }
		public static class ByValue extends BlocoHRegistroH010 implements Structure.ByValue { }
	}

	public static class BlocoHRegistroH020 extends Structure implements Structure.ByValue {
		public byte[] CST_ICMS = new byte[4];
		public double BC_ICMS;
		public double VL_ICMS;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("CST_ICMS" , "BC_ICMS" , "VL_ICMS");
		}

		public static class ByReference extends BlocoHRegistroH020 implements Structure.ByReference { }
		public static class ByValue extends BlocoHRegistroH020 implements Structure.ByValue { }
	}

	public interface StringCallback extends com.sun.jna.Callback {
		void invoke(String Mensagem);
	}

	// Funções
	int SPDF_Bloco_0_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_0_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_0_GetGravado(int spdfHandle);
	int SPDF_Bloco_0_Registro0000New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0000 registro0000);
	int SPDF_Bloco_0_Registro0001New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0001 registro0001);
	int SPDF_Bloco_0_Registro0005New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0005 registro0005);
	int SPDF_Bloco_0_Registro0015New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0015 registro0015);
	int SPDF_Bloco_0_Registro0100New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0100 registro0100);
	int SPDF_Bloco_0_Registro0150New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0150 registro0150);
	int SPDF_Bloco_0_Registro0175New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0175 registro0175);
	int SPDF_Bloco_0_Registro0190New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0190 registro0190);
	int SPDF_Bloco_0_Registro0200New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0200 registro0200);
	int SPDF_Bloco_0_Registro0205New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0205 registro0205);
	int SPDF_Bloco_0_Registro0206New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0206 registro0206);
	int SPDF_Bloco_0_Registro0220New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0220 registro0220);
	int SPDF_Bloco_0_Registro0300New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0300 registro0300);
	int SPDF_Bloco_0_Registro0305New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0305 registro0305);
	int SPDF_Bloco_0_Registro0400New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0400 registro0400);
	int SPDF_Bloco_0_Registro0450New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0450 registro0450);
	int SPDF_Bloco_0_Registro0460New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0460 registro0460);
	int SPDF_Bloco_0_Registro0500New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0500 registro0500);
	int SPDF_Bloco_0_Registro0600New(int spdfHandle, ACBrSpedFiscalInterop.Bloco0Registro0600 registro0600);
	int SPDF_Bloco_0_Registro0990_GetQTD_LIN_0(int spdfHandle);
	int SPDF_Bloco_0_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_0_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Bloco_1_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_1_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_1_GetGravado(int spdfHandle);
	int SPDF_Bloco_1_Registro1001New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1001 registro1001);
	int SPDF_Bloco_1_Registro1010New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1010 registro1010);
	int SPDF_Bloco_1_Registro1100New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1100 registro1100);
	int SPDF_Bloco_1_Registro1105New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1105 registro1105);
	int SPDF_Bloco_1_Registro1110New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1110 registro1110);
	int SPDF_Bloco_1_Registro1200New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1200 registro1200);
	int SPDF_Bloco_1_Registro1210New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1210 registro1210);
	int SPDF_Bloco_1_Registro1300New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1300 registro1300);
	int SPDF_Bloco_1_Registro1310New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1310 registro1310);
	int SPDF_Bloco_1_Registro1320New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1320 registro1320);
	int SPDF_Bloco_1_Registro1350New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1350 registro1350);
	int SPDF_Bloco_1_Registro1360New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1360 registro1360);
	int SPDF_Bloco_1_Registro1370New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1370 registro1370);
	int SPDF_Bloco_1_Registro1390New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1390 registro1390);
	int SPDF_Bloco_1_Registro1400New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1400 registro1400);
	int SPDF_Bloco_1_Registro1500New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1500 registro1500);
	int SPDF_Bloco_1_Registro1510New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1510 registro1510);
	int SPDF_Bloco_1_Registro1600New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1600 registro1600);
	int SPDF_Bloco_1_Registro1700New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1700 registro1700);
	int SPDF_Bloco_1_Registro1710New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1710 registro1710);
	int SPDF_Bloco_1_Registro1800New(int spdfHandle, ACBrSpedFiscalInterop.Bloco1Registro1800 registro1800);
	int SPDF_Bloco_1_Registro1990_GetQTD_LIN_1(int spdfHandle);
	int SPDF_Bloco_1_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_1_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Bloco_9_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_9_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_9_GetGravado(int spdfHandle);
	int SPDF_Bloco_9_Registro9001New(int spdfHandle, ACBrSpedFiscalInterop.Bloco9Registro9001 registro9001);
	int SPDF_Bloco_9_Registro9900New(int spdfHandle, ACBrSpedFiscalInterop.Bloco9Registro9900 registro9900);
	int SPDF_Bloco_9_Registro9990_GetQTD_LIN_9(int spdfHandle);
	int SPDF_Bloco_9_Registro9999_GetQTD_LIN(int spdfHandle);
	int SPDF_Bloco_9_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_9_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Bloco_C_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_C_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_C_GetGravado(int spdfHandle);
	int SPDF_Bloco_C_RegistroC001New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC001 registroC001);
	int SPDF_Bloco_C_RegistroC100New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC100 registroC100);
	int SPDF_Bloco_C_RegistroC105New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC105 registroC105);
	int SPDF_Bloco_C_RegistroC110New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC110 registroC110);
	int SPDF_Bloco_C_RegistroC111New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC111 registroC111);
	int SPDF_Bloco_C_RegistroC112New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC112 registroC112);
	int SPDF_Bloco_C_RegistroC113New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC113 registroC113);
	int SPDF_Bloco_C_RegistroC114New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC114 registroC114);
	int SPDF_Bloco_C_RegistroC115New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC115 registroC115);
	int SPDF_Bloco_C_RegistroC116New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC116 registroC116);
	int SPDF_Bloco_C_RegistroC120New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC120 registroC120);
	int SPDF_Bloco_C_RegistroC130New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC130 registroC130);
	int SPDF_Bloco_C_RegistroC140New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC140 registroC140);
	int SPDF_Bloco_C_RegistroC141New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC141 registroC141);
	int SPDF_Bloco_C_RegistroC160New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC160 registroC160);
	int SPDF_Bloco_C_RegistroC165New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC165 registroC165);
	int SPDF_Bloco_C_RegistroC170New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC170 registroC170);
	int SPDF_Bloco_C_RegistroC171New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC171 registroC171);
	int SPDF_Bloco_C_RegistroC172New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC172 registroC172);
	int SPDF_Bloco_C_RegistroC173New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC173 registroC173);
	int SPDF_Bloco_C_RegistroC174New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC174 registroC174);
	int SPDF_Bloco_C_RegistroC175New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC175 registroC175);
	int SPDF_Bloco_C_RegistroC176New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC176 registroC176);
	int SPDF_Bloco_C_RegistroC177New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC177 registroC177);
	int SPDF_Bloco_C_RegistroC178New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC178 registroC178);
	int SPDF_Bloco_C_RegistroC179New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC179 registroC179);
	int SPDF_Bloco_C_RegistroC190New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC190 registroC190);
	int SPDF_Bloco_C_RegistroC195New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC195 registroC195);
	int SPDF_Bloco_C_RegistroC197New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC197 registroC197);
	int SPDF_Bloco_C_RegistroC300New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC300 registroC300);
	int SPDF_Bloco_C_RegistroC310New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC310 registroC310);
	int SPDF_Bloco_C_RegistroC320New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC320 registroC320);
	int SPDF_Bloco_C_RegistroC321New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC321 registroC321);
	int SPDF_Bloco_C_RegistroC350New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC350 registroC350);
	int SPDF_Bloco_C_RegistroC370New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC370 registroC370);
	int SPDF_Bloco_C_RegistroC390New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC390 registroC390);
	int SPDF_Bloco_C_RegistroC400New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC400 registroC400);
	int SPDF_Bloco_C_RegistroC405New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC405 registroC405);
	int SPDF_Bloco_C_RegistroC410New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC410 registroC410);
	int SPDF_Bloco_C_RegistroC420New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC420 registroC420);
	int SPDF_Bloco_C_RegistroC425New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC425 registroC425);
	int SPDF_Bloco_C_RegistroC460New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC460 registroC460);
	int SPDF_Bloco_C_RegistroC470New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC470 registroC470);
	int SPDF_Bloco_C_RegistroC490New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC490 registroC490);
	int SPDF_Bloco_C_RegistroC495New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC495 registroC495);
	int SPDF_Bloco_C_RegistroC500New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC500 registroC500);
	int SPDF_Bloco_C_RegistroC510New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC510 registroC510);
	int SPDF_Bloco_C_RegistroC590New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC590 registroC590);
	int SPDF_Bloco_C_RegistroC600New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC600 registroC600);
	int SPDF_Bloco_C_RegistroC601New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC601 registroC601);
	int SPDF_Bloco_C_RegistroC610New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC610 registroC610);
	int SPDF_Bloco_C_RegistroC690New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC690 registroC690);
	int SPDF_Bloco_C_RegistroC700New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC700 registroC700);
	int SPDF_Bloco_C_RegistroC790New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC790 registroC790);
	int SPDF_Bloco_C_RegistroC791New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC791 registroC791);
	int SPDF_Bloco_C_RegistroC800New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC800 registroC800);
	int SPDF_Bloco_C_RegistroC850New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC850 registroC850);
	int SPDF_Bloco_C_RegistroC860New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC860 registroC860);
	int SPDF_Bloco_C_RegistroC890New(int spdfHandle, ACBrSpedFiscalInterop.BlocoCRegistroC890 registroC890);
	int SPDF_Bloco_C_RegistroC990_GetQTD_LIN_C(int spdfHandle);
	int SPDF_Bloco_C_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_C_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Bloco_D_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_D_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_D_GetGravado(int spdfHandle);
	int SPDF_Bloco_D_RegistroD001New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD001 registroD001);
	int SPDF_Bloco_D_RegistroD100New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD100 registroD100);
	int SPDF_Bloco_D_RegistroD110New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD110 registroD110);
	int SPDF_Bloco_D_RegistroD120New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD120 registroD120);
	int SPDF_Bloco_D_RegistroD130New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD130 registroD130);
	int SPDF_Bloco_D_RegistroD140New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD140 registroD140);
	int SPDF_Bloco_D_RegistroD150New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD150 registroD150);
	int SPDF_Bloco_D_RegistroD160New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD160 registroD160);
	int SPDF_Bloco_D_RegistroD161New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD161 registroD161);
	int SPDF_Bloco_D_RegistroD162New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD162 registroD162);
	int SPDF_Bloco_D_RegistroD170New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD170 registroD170);
	int SPDF_Bloco_D_RegistroD180New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD180 registroD180);
	int SPDF_Bloco_D_RegistroD190New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD190 registroD190);
	int SPDF_Bloco_D_RegistroD195New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD195 registroD195);
	int SPDF_Bloco_D_RegistroD197New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD197 registroD197);
	int SPDF_Bloco_D_RegistroD300New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD300 registroD300);
	int SPDF_Bloco_D_RegistroD301New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD301 registroD301);
	int SPDF_Bloco_D_RegistroD310New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD310 registroD310);
	int SPDF_Bloco_D_RegistroD350New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD350 registroD350);
	int SPDF_Bloco_D_RegistroD355New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD355 registroD355);
	int SPDF_Bloco_D_RegistroD360New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD360 registroD360);
	int SPDF_Bloco_D_RegistroD365New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD365 registroD365);
	int SPDF_Bloco_D_RegistroD370New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD370 registroD370);
	int SPDF_Bloco_D_RegistroD390New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD390 registroD390);
	int SPDF_Bloco_D_RegistroD400New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD400 registroD400);
	int SPDF_Bloco_D_RegistroD410New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD410 registroD410);
	int SPDF_Bloco_D_RegistroD411New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD411 registroD411);
	int SPDF_Bloco_D_RegistroD420New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD420 registroD420);
	int SPDF_Bloco_D_RegistroD500New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD500 registroD500);
	int SPDF_Bloco_D_RegistroD510New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD510 registroD510);
	int SPDF_Bloco_D_RegistroD530New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD530 registroD530);
	int SPDF_Bloco_D_RegistroD590New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD590 registroD590);
	int SPDF_Bloco_D_RegistroD600New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD600 registroD600);
	int SPDF_Bloco_D_RegistroD610New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD610 registroD610);
	int SPDF_Bloco_D_RegistroD690New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD690 registroD690);
	int SPDF_Bloco_D_RegistroD695New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD695 registroD695);
	int SPDF_Bloco_D_RegistroD696New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD696 registroD696);
	int SPDF_Bloco_D_RegistroD697New(int spdfHandle, ACBrSpedFiscalInterop.BlocoDRegistroD697 registroD697);
	int SPDF_Bloco_D_RegistroD990_GetQTD_LIN_D(int spdfHandle);
	int SPDF_Bloco_D_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_D_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Bloco_E_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_E_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_E_GetGravado(int spdfHandle);
	int SPDF_Bloco_E_RegistroE001New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE001 registroE001);
	int SPDF_Bloco_E_RegistroE100New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE100 registroE100);
	int SPDF_Bloco_E_RegistroE110New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE110 registroE110);
	int SPDF_Bloco_E_RegistroE111New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE111 registroE111);
	int SPDF_Bloco_E_RegistroE112New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE112 registroE112);
	int SPDF_Bloco_E_RegistroE113New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE113 registroE113);
	int SPDF_Bloco_E_RegistroE115New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE115 registroE115);
	int SPDF_Bloco_E_RegistroE116New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE116 registroE116);
	int SPDF_Bloco_E_RegistroE200New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE200 registroE200);
	int SPDF_Bloco_E_RegistroE210New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE210 registroE210);
	int SPDF_Bloco_E_RegistroE220New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE220 registroE220);
	int SPDF_Bloco_E_RegistroE230New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE230 registroE230);
	int SPDF_Bloco_E_RegistroE240New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE240 registroE240);
	int SPDF_Bloco_E_RegistroE250New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE250 registroE250);
	int SPDF_Bloco_E_RegistroE500New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE500 registroE500);
	int SPDF_Bloco_E_RegistroE510New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE510 registroE510);
	int SPDF_Bloco_E_RegistroE520New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE520 registroE520);
	int SPDF_Bloco_E_RegistroE530New(int spdfHandle, ACBrSpedFiscalInterop.BlocoERegistroE530 registroE530);
	int SPDF_Bloco_E_RegistroE990_GetQTD_LIN_E(int spdfHandle);
	int SPDF_Bloco_E_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_E_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Bloco_G_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_G_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_G_GetGravado(int spdfHandle);
	int SPDF_Bloco_G_RegistroG001New(int spdfHandle, ACBrSpedFiscalInterop.BlocoGRegistroG001 registroG001);
	int SPDF_Bloco_G_RegistroG110New(int spdfHandle, ACBrSpedFiscalInterop.BlocoGRegistroG110 registroG110);
	int SPDF_Bloco_G_RegistroG125New(int spdfHandle, ACBrSpedFiscalInterop.BlocoGRegistroG125 registroG125);
	int SPDF_Bloco_G_RegistroG126New(int spdfHandle, ACBrSpedFiscalInterop.BlocoGRegistroG126 registroG126);
	int SPDF_Bloco_G_RegistroG130New(int spdfHandle, ACBrSpedFiscalInterop.BlocoGRegistroG130 registroG130);
	int SPDF_Bloco_G_RegistroG140New(int spdfHandle, ACBrSpedFiscalInterop.BlocoGRegistroG140 registroG140);
	int SPDF_Bloco_G_RegistroG990_GetQTD_LIN_G(int spdfHandle);
	int SPDF_Bloco_G_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_G_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Bloco_H_GetDT_FIN(int spdfHandle, DoubleByReference dtFin);
	int SPDF_Bloco_H_GetDT_INI(int spdfHandle, DoubleByReference dtIni);
	int SPDF_Bloco_H_GetGravado(int spdfHandle);
	int SPDF_Bloco_H_RegistroH001New(int spdfHandle, ACBrSpedFiscalInterop.BlocoHRegistroH001 registroH001);
	int SPDF_Bloco_H_RegistroH005New(int spdfHandle, ACBrSpedFiscalInterop.BlocoHRegistroH005 registroH005);
	int SPDF_Bloco_H_RegistroH010New(int spdfHandle, ACBrSpedFiscalInterop.BlocoHRegistroH010 registroH010);
	int SPDF_Bloco_H_RegistroH020New(int spdfHandle, ACBrSpedFiscalInterop.BlocoHRegistroH020 registroH020);
	int SPDF_Bloco_H_RegistroH990_GetQTD_LIN_H(int spdfHandle);
	int SPDF_Bloco_H_SetDT_FIN(int spdfHandle, double dtFin);
	int SPDF_Bloco_H_SetDT_INI(int spdfHandle, double dtIni);
	int SPDF_Create(IntByReference spdfHandle);
	int SPDF_Destroy(int spdfHandle);
	int SPDF_GetAbout(int spdfHandle, ByteBuffer buffer, int bufferLen);
	int SPDF_GetArquivo(int spdfHandle, ByteBuffer buffer, int bufferLen);
	int SPDF_GetCurMascara(int spdfHandle, ByteBuffer buffer, int bufferLen);
	int SPDF_GetDelimitador(int spdfHandle, ByteBuffer buffer, int bufferLen);
	int SPDF_GetDT_FIN(int spdfHandle, DoubleByReference data);
	int SPDF_GetDT_INI(int spdfHandle, DoubleByReference data);
	int SPDF_GetLinhasBuffer(int spdfHandle);
	int SPDF_GetPath(int spdfHandle, ByteBuffer buffer, int bufferLen);
	int SPDF_GetTrimString(int spdfHandle);
	int SPDF_GetUltimoErro(int spdfHandle, ByteBuffer buffer, int bufferLen);
	int SPDF_SaveFileTXT(int spdfHandle);
	int SPDF_SetArquivo(int spdfHandle, String arquivo);
	int SPDF_SetCurMascara(int spdfHandle, String mascara);
	int SPDF_SetDelimitador(int spdfHandle, String delimitador);
	int SPDF_SetDT_FIN(int spdfHandle, double data);
	int SPDF_SetDT_INI(int spdfHandle, double data);
	int SPDF_SetLinhasBuffer(int spdfHandle, int linhas);
	int SPDF_SetOnError(int spdfHandle, ACBrSpedFiscalInterop.StringCallback method);
	int SPDF_SetPath(int spdfHandle, String path);
	int SPDF_SetTrimString(int spdfHandle, boolean trim);
}
