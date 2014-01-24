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

public interface ACBrAACInterop extends InteropLib {

	public static final ACBrAACInterop INSTANCE = (ACBrAACInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrAACInterop.class);

	// Tipos de dados
	public interface AntesArquivoCallback extends com.sun.jna.Callback {
		boolean invoke();
	}
	public interface CryptCallback extends com.sun.jna.Callback {
		String invoke(String value);
	}
	public interface NoArgumentsCallback extends com.sun.jna.Callback {
		void invoke();
	}
	public interface OnGetChaveCallback extends com.sun.jna.Callback {
		String invoke();
	}
	public static class TECFArquivo extends Structure {
		public byte[] NOME_ARQUIVO = new byte[51];
		public byte[] MD5 = new byte[33];

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("NOME_ARQUIVO" , "MD5");
		}

		public static class ByReference extends TECFArquivo implements Structure.ByReference { }
		public static class ByValue extends TECFArquivo implements Structure.ByValue { }
	}
    
	public static class TECFAutorizado extends Structure {
		public double ValorGT;
		public byte[] NumeroSerie = new byte[30];
		public int CRO;
		public int CNI;
		public double DtHrAtualizado;

		@Override
		protected List<String> getFieldOrder() {
			return Arrays.asList("ValorGT" , "NumeroSerie" , "CRO" , "CNI" , "DtHrAtualizado");
		}

		public static class ByReference extends TECFAutorizado implements Structure.ByReference { }
		public static class ByValue extends TECFAutorizado implements Structure.ByValue { }
	}

	public interface VerificarRecomporNumSerieCallback extends com.sun.jna.Callback {
		void invoke(String NumSerie,double ValorGT,IntByReference CRO,IntByReference CNI);
	}
	public interface VerificarRecomporValorGTCallback extends com.sun.jna.Callback {
		void invoke(String NumSerie,DoubleByReference ValorGT);
	}

	// Funções
	int AAC_AbrirArquivo(int aacHandle);
	int AAC_AchaECF(int aacHandle, String numSerie, ACBrAACInterop.TECFAutorizado ECF);
	int AAC_AchaIndiceECF(int aacHandle, String numSerie, IntByReference indice);
	int AAC_AtualizarMD5(int aacHandle, String md5);
	int AAC_AtualizarValorGT(int aacHandle, String numSerie, double grandeTotal);
	int AAC_Create(IntByReference aacHandle);
	int AAC_Destroy(int aacHandle);
	int AAC_GetArqLOG(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_GetCriarBAK(int aacHandle);
	int AAC_GetEfetuarFlush(int aacHandle);
	int AAC_GetGravarConfigApp(int aacHandle);
	int AAC_GetGravarDadosPAF(int aacHandle);
	int AAC_GetGravarDadosSH(int aacHandle);
	int AAC_GetGravarTodosECFs(int aacHandle);
	int AAC_GetNomeArquivoAux(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_GetParams(int aacHandle, ByteBuffer buffer, int bufferLen, int index);
	int AAC_GetParamsCount(int aacHandle);
	int AAC_GetUltimoErro(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_ArquivoListaAutenticados_GetMD5(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_ArquivoListaAutenticados_GetNome(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_ArquivoListaAutenticados_SetMD5(int aacHandle, String buffer);
	int AAC_IdentPaf_ArquivoListaAutenticados_SetNome(int aacHandle, String buffer);
	int AAC_IdentPaf_ECFsAutorizados_Clear(int aacHandle);
	int AAC_IdentPaf_ECFsAutorizados_Count(int aacHandle);
	int AAC_IdentPaf_ECFsAutorizados_Get(int aacHandle, ACBrAACInterop.TECFAutorizado retAutorizado, int index);
	int AAC_IdentPaf_ECFsAutorizados_New(int aacHandle, ACBrAACInterop.TECFAutorizado.ByValue ecfAutorizado);
	int AAC_IdentPaf_Empresa_GetCep(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetCidade(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetCNPJ(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetContato(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetEmail(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetEndereco(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetIE(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetIM(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetRazaoSocial(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetTelefone(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_GetUf(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Empresa_SetCep(int aacHandle, String cep);
	int AAC_IdentPaf_Empresa_SetCidade(int aacHandle, String cidade);
	int AAC_IdentPaf_Empresa_SetCNPJ(int aacHandle, String cnpj);
	int AAC_IdentPaf_Empresa_SetContato(int aacHandle, String contato);
	int AAC_IdentPaf_Empresa_SetEmail(int aacHandle, String email);
	int AAC_IdentPaf_Empresa_SetEndereco(int aacHandle, String endereco);
	int AAC_IdentPaf_Empresa_SetIE(int aacHandle, String ie);
	int AAC_IdentPaf_Empresa_SetIM(int aacHandle, String im);
	int AAC_IdentPaf_Empresa_SetRazaoSocial(int aacHandle, String razaoSocial);
	int AAC_IdentPaf_Empresa_SetTelefone(int aacHandle, String telefone);
	int AAC_IdentPaf_Empresa_SetUf(int aacHandle, String uf);
	int AAC_IdentPaf_GetNumeroLaudo(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_GetVersaoER(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_OutrosArquivos_Clear(int aacHandle);
	int AAC_IdentPaf_OutrosArquivos_Count(int aacHandle);
	int AAC_IdentPaf_OutrosArquivos_Get(int aacHandle, ACBrAACInterop.TECFArquivo ecfArquivo, int index);
	int AAC_IdentPaf_OutrosArquivos_New(int aacHandle, ACBrAACInterop.TECFArquivo ecfArquivo);
	int AAC_IdentPaf_Paf_GetAcumulaVolumeDiario(int aacHandle);
	int AAC_IdentPaf_Paf_GetArmazenaEncerranteIniFinal(int aacHandle);
	int AAC_IdentPaf_Paf_GetBancoDados(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Paf_GetBarSimilarBalanca(int aacHandle);
	int AAC_IdentPaf_Paf_GetBarSimilarECFComum(int aacHandle);
	int AAC_IdentPaf_Paf_GetBarSimilarECFRestaurante(int aacHandle);
	int AAC_IdentPaf_Paf_GetCadastroPlacaBomba(int aacHandle);
	int AAC_IdentPaf_Paf_GetCriaAbastDivergEncerrante(int aacHandle);
	int AAC_IdentPaf_Paf_GetCupomMania(int aacHandle);
	int AAC_IdentPaf_Paf_GetDAVConfAnexoII(int aacHandle);
	int AAC_IdentPaf_Paf_GetDAVDiscrFormula(int aacHandle);
	int AAC_IdentPaf_Paf_GetEmiteContrEncerrAposREDZLEIX(int aacHandle);
	int AAC_IdentPaf_Paf_GetEmitePED(int aacHandle);
	int AAC_IdentPaf_Paf_GetImpedeVendaVlrZero(int aacHandle);
	int AAC_IdentPaf_Paf_GetIndiceTecnicoProd(int aacHandle);
	int AAC_IdentPaf_Paf_GetIntegracaoPafECF(int aacHandle);
	int AAC_IdentPaf_Paf_GetIntegradoComBombas(int aacHandle);
	int AAC_IdentPaf_Paf_GetLinguagem(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Paf_GetMinasLegal(int aacHandle);
	int AAC_IdentPaf_Paf_GetNome(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Paf_GetNotaLegalDF(int aacHandle);
	int AAC_IdentPaf_Paf_GetParaibaLegal(int aacHandle);
	int AAC_IdentPaf_Paf_GetRealizaDAVECF(int aacHandle);
	int AAC_IdentPaf_Paf_GetRealizaDAVNaoFiscal(int aacHandle);
	int AAC_IdentPaf_Paf_GetRealizaDAVOS(int aacHandle);
	int AAC_IdentPaf_Paf_GetRealizaLancamentoMesa(int aacHandle);
	int AAC_IdentPaf_Paf_GetRealizaPreVenda(int aacHandle);
	int AAC_IdentPaf_Paf_GetRecompoeGT(int aacHandle);
	int AAC_IdentPaf_Paf_GetRecompoeNumSerie(int aacHandle);
	int AAC_IdentPaf_Paf_GetSistemaOperacional(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Paf_GetTipoDesenvolvimento(int aacHandle);
	int AAC_IdentPaf_Paf_GetTipoFuncionamento(int aacHandle);
	int AAC_IdentPaf_Paf_GetTotalizaValoresLista(int aacHandle);
	int AAC_IdentPaf_Paf_GetTransfDAV(int aacHandle);
	int AAC_IdentPaf_Paf_GetTransfPreVenda(int aacHandle);
	int AAC_IdentPaf_Paf_GetTransportePassageiro(int aacHandle);
	int AAC_IdentPaf_Paf_GetTrocoEmCartao(int aacHandle);
	int AAC_IdentPaf_Paf_GetUsaImpressoraNaoFiscal(int aacHandle);
	int AAC_IdentPaf_Paf_GetVersao(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Paf_PrincipalExe_GetMD5(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Paf_PrincipalExe_GetNome(int aacHandle, ByteBuffer buffer, int bufferLen);
	int AAC_IdentPaf_Paf_PrincipalExe_SetMD5(int aacHandle, String md5Exe);
	int AAC_IdentPaf_Paf_PrincipalExe_SetNome(int aacHandle, String exePrincipal);
	int AAC_IdentPaf_Paf_SetAcumulaVolumeDiario(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetArmazenaEncerranteIniFinal(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetBancoDados(int aacHandle, String banco);
	int AAC_IdentPaf_Paf_SetBarSimilarBalanca(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetBarSimilarECFComum(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetBarSimilarECFRestaurante(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetCadastroPlacaBomba(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetCriaAbastDivergEncerrante(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetCupomMania(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetDAVConfAnexoII(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetDAVDiscrFormula(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetEmiteContrEncerrAposREDZLEIX(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetEmitePED(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetImpedeVendaVlrZero(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetIndiceTecnicoProd(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetIntegracaoPafECF(int aacHandle, int tipo);
	int AAC_IdentPaf_Paf_SetIntegradoComBombas(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetLinguagem(int aacHandle, String linguagem);
	int AAC_IdentPaf_Paf_SetMinasLegal(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetNome(int aacHandle, String nome);
	int AAC_IdentPaf_Paf_SetNotaLegalDF(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetParaibaLegal(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetRealizaDAVECF(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetRealizaDAVNaoFiscal(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetRealizaDAVOS(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetRealizaLancamentoMesa(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetRealizaPreVenda(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetRecompoeGT(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetRecompoeNumSerie(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetSistemaOperacional(int aacHandle, String sistema);
	int AAC_IdentPaf_Paf_SetTipoDesenvolvimento(int aacHandle, int tipo);
	int AAC_IdentPaf_Paf_SetTipoFuncionamento(int aacHandle, int tipo);
	int AAC_IdentPaf_Paf_SetTotalizaValoresLista(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetTransfDAV(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetTransfPreVenda(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetTransportePassageiro(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetTrocoEmCartao(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetUsaImpressoraNaoFiscal(int aacHandle, boolean check);
	int AAC_IdentPaf_Paf_SetVersao(int aacHandle, String versao);
	int AAC_IdentPaf_SetNumeroLaudo(int aacHandle, String razaoSocial);
	int AAC_IdentPaf_SetVersaoER(int aacHandle, String razaoSocial);
	int AAC_SalvarArquivo(int aacHandle);
	int AAC_SetAntesGravarArquivo(int aacHandle, ACBrAACInterop.AntesArquivoCallback method);
	int AAC_SetArqLOG(int aacHandle, String arqLog);
	int AAC_SetCriarBAK(int aacHandle, boolean value);
	int AAC_SetEfetuarFlush(int aacHandle, boolean value);
	int AAC_SetGravarConfigApp(int aacHandle, boolean value);
	int AAC_SetGravarDadosPAF(int aacHandle, boolean value);
	int AAC_SetGravarDadosSH(int aacHandle, boolean value);
	int AAC_SetGravarTodosECFs(int aacHandle, boolean value);
	int AAC_SetNomeArquivoAux(int aacHandle, String caminho);
	int AAC_SetOnAntesAbrirArquivo(int aacHandle, ACBrAACInterop.AntesArquivoCallback method);
	int AAC_SetOnCrypt(int aacHandle, ACBrAACInterop.CryptCallback method);
	int AAC_SetOnDeCrypt(int aacHandle, ACBrAACInterop.CryptCallback method);
	int AAC_SetOnDepoisAbrirArquivo(int aacHandle, ACBrAACInterop.NoArgumentsCallback method);
	int AAC_SetOnDepoisGravarArquivo(int aacHandle, ACBrAACInterop.NoArgumentsCallback method);
	int AAC_SetOnGetChave(int aacHandle, ACBrAACInterop.OnGetChaveCallback method);
	int AAC_SetParams(int aacHandle, String parametros[], int count);
	int AAC_SetVerificarRecomporNumSerie(int aacHandle, ACBrAACInterop.VerificarRecomporNumSerieCallback method);
	int AAC_SetVerificarRecomporValorGT(int aacHandle, ACBrAACInterop.VerificarRecomporValorGTCallback method);
	int AAC_VerificaReCarregarArquivo(int aacHandle);
	int AAC_VerificarGTECF(int aacHandle, String numSerie, DoubleByReference grandeTotal);
}
