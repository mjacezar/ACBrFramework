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

public interface ACBrEADInterop extends InteropLib {

	public static final ACBrEADInterop INSTANCE = (ACBrEADInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrEADInterop.class);

	// Tipos de dados
	public interface GetChavePrivadaCallback extends com.sun.jna.Callback {
		String invoke();
	}
	public interface GetChavePublicaCallback extends com.sun.jna.Callback {
		String invoke();
	}

	// Funções
	int EAD_AssinarArquivoComEAD(int eadHandle, String Arquivo, boolean Remove, ByteBuffer EAD, int bufferLen);
	int EAD_CalcularChavePublica(int eadHandle, ByteBuffer ChavePUB, int bufferLen);
	int EAD_CalcularEAD(int eadHandle, String EString[], ByteBuffer EAD, int bufferLen);
	int EAD_CalcularEADArquivo(int eadHandle, String Arquivo, ByteBuffer EAD, int bufferLen);
	int EAD_CalcularHash(int eadHandle, String AString, int HashType, ByteBuffer Hash, int bufferLen);
	int EAD_CalcularHashArquivo(int eadHandle, String Arquivo, int HashType, ByteBuffer Hash, int bufferLen);
	int EAD_CalcularModuloeExpoente(int eadHandle, ByteBuffer Modulo, ByteBuffer Expoente, int bufferLen);
	int EAD_ConverteXMLeECFcParaOpenSSL(int eadHandle, String Arquivo, ByteBuffer Hash, int bufferLen);
	int EAD_Create(IntByReference eadHandle);
	int EAD_Destroy(int eadHandle);
	int EAD_GerarChaves(int eadHandle, ByteBuffer ChavePUB, ByteBuffer ChavePRI, int bufferLen);
	int EAD_GerarXMLeECFc(int eadHandle, String NomeSH, String PathArquivo);
	int EAD_GetAbout(int eadHandle, ByteBuffer buffer, int bufferLen);
	int EAD_GetOpenSSL_Version(int eadHandle, ByteBuffer buffer, int bufferLen);
	int EAD_GetUltimoErro(int eadHandle, ByteBuffer buffer, int bufferLen);
	int EAD_MD5FromFile(int eadHandle, String Arquivo, ByteBuffer MD5, int bufferLen);
	int EAD_MD5FromString(int eadHandle, String AString, ByteBuffer MD5, int bufferLen);
	int EAD_RemoveEADArquivo(int eadHandle, String Arquivo);
	int EAD_SetOnGetChavePrivada(int eadHandle, ACBrEADInterop.GetChavePrivadaCallback method);
	int EAD_SetOnGetChavePublica(int eadHandle, ACBrEADInterop.GetChavePublicaCallback method);
	int EAD_VerificarEAD(int eadHandle, String ead);
	int EAD_VerificarEADArquivo(int eadHandle, String Arquivo);
}
