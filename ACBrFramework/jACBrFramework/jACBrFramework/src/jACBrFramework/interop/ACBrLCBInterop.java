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

public interface ACBrLCBInterop extends InteropLib {

	public static final ACBrLCBInterop INSTANCE = (ACBrLCBInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrLCBInterop.class);

	// Tipos de dados
	public interface LeCodigoCallback extends com.sun.jna.Callback {
		void invoke();
	}

	// Funções
	int LCB_Ativar(int lcbHandle);
	int LCB_Create(IntByReference lcbHandle);
	int LCB_Desativar(int lcbHandle);
	int LCB_Destroy(int lcbHandle);
	int LCB_GetAtivo(int lcbHandle);
	int LCB_GetPorta(int lcbHandle, ByteBuffer buffer, int bufferLen);
	int LCB_GetUltimaLeitura(int lcbHandle, ByteBuffer buffer, int bufferLen);
	int LCB_GetUltimoCodigo(int lcbHandle, ByteBuffer buffer, int bufferLen);
	int LCB_GetUltimoErro(int lcbHandle, ByteBuffer buffer, int bufferLen);
	int LCB_LerString(int lcbHandle, ByteBuffer buffer, int bufferLen);
	int LCB_SetOnLeCodigo(int lcbHandle, ACBrLCBInterop.LeCodigoCallback method);
	int LCB_SetPorta(int lcbHandle, String porta);
}
