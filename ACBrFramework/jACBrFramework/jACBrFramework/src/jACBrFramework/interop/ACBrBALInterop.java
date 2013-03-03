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


public interface ACBrBALInterop extends InteropLib
{
	public static final ACBrBALInterop INSTANCE = (ACBrBALInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrBALInterop.class);

	// Tipos de dados

	public interface LePesoCallback extends Callback
	{
		void invoke(double value);
	}



	// Funções

	int BAL_Ativar(int balHandle);
	int BAL_Create(IntByReference balHandle);
	int BAL_Desativar(int balHandle);
	int BAL_Destroy(int balHandle);
	int BAL_GetAtivo(int balHandle);
	int BAL_GetModelo(int balHandle);
	int BAL_GetModeloStr(int balHandle, ByteBuffer buffer, int bufferLen);
	int BAL_GetMonitoraBalanca(int balHandle);
	int BAL_GetPorta(int balHandle, ByteBuffer buffer, int bufferLen);
	int BAL_GetUltimaResposta(int balHandle, ByteBuffer buffer, int bufferLen);
	int BAL_GetUltimoErro(int balHandle, ByteBuffer buffer, int bufferLen);
	int BAL_GetUltimoPesoLido(int balHandle, DoubleByReference peso);
	int BAL_LePeso(int balHandle, int timeout, DoubleByReference peso);
	int BAL_SetModelo(int balHandle, int modelo);
	int BAL_SetMonitoraBalanca(int balHandle, boolean monitora);
	int BAL_SetOnLePeso(int balHandle, ACBrBALInterop.LePesoCallback method);
	int BAL_SetPorta(int balHandle, String porta);
}
