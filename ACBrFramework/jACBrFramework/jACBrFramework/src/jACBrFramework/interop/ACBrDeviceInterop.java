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

public interface ACBrDeviceInterop extends InteropLib {

	public static final ACBrDeviceInterop INSTANCE = (ACBrDeviceInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrDeviceInterop.class);

	// Tipos de dados

	// Funções
	int DEV_GetBaud(int ecfHandle);
	int DEV_GetDataBits(int ecfHandle);
	int DEV_GetHandShake(int ecfHandle);
	int DEV_GetHardFlow(int ecfHandle);
	int DEV_GetMaxBandwidth(int ecfHandle);
	int DEV_GetParity(int ecfHandle);
	int DEV_GetPorta(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int DEV_GetProcessMessages(int ecfHandle);
	int DEV_GetSoftFlow(int ecfHandle);
	int DEV_GetStopBits(int ecfHandle);
	int DEV_GetTimeOut(int ecfHandle);
	int DEV_SetBaud(int ecfHandle, int baud);
	int DEV_SetDataBits(int ecfHandle, int dataBits);
	int DEV_SetHandShake(int ecfHandle, int handShake);
	int DEV_SetHardFlow(int ecfHandle, boolean hardFlow);
	int DEV_SetMaxBandwidth(int ecfHandle, int maxBandwidth);
	int DEV_SetParity(int ecfHandle, int parity);
	int DEV_SetPorta(int ecfHandle, String porta);
	int DEV_SetProcessMessages(int ecfHandle, boolean processMessages);
	int DEV_SetSoftFlow(int ecfHandle, boolean softFlow);
	int DEV_SetStopBits(int ecfHandle, int stopBits);
	int DEV_SetTimeOut(int ecfHandle, int timeOut);
}
