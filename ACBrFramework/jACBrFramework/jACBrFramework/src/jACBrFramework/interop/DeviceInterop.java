package jACBrFramework.interop;

import com.sun.jna.Library;
import com.sun.jna.Native;
import com.sun.jna.NativeLibrary;
import com.sun.jna.Pointer;
import java.nio.ByteBuffer;

public interface DeviceInterop extends InteropLib
{
	public static final DeviceInterop INSTANCE = (DeviceInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, DeviceInterop.class);
	
	/**
	 * Original signature :
	 * <code>int DEV_GetBaud(const INTPTR)</code><br> <i>native declaration
	 * : line 34</i>
	 */
	int DEV_GetBaud(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetDataBits(const INTPTR)</code><br> <i>native
	 * declaration : line 35</i>
	 */
	int DEV_GetDataBits(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetHandShake(const INTPTR)</code><br> <i>native
	 * declaration : line 36</i>
	 */
	int DEV_GetHandShake(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetHardFlow(const INTPTR)</code><br> <i>native
	 * declaration : line 37</i>
	 */
	int DEV_GetHardFlow(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetMaxBandwidth(const INTPTR)</code><br> <i>native
	 * declaration : line 38</i>
	 */
	int DEV_GetMaxBandwidth(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetParity(const INTPTR)</code><br> <i>native
	 * declaration : line 39</i>
	 */
	int DEV_GetParity(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetPorta(const INTPTR, PCHAR, const int)</code><br>
	 * <i>native declaration : line 40</i>
	 */
	int DEV_GetPorta(int ecfHandle, ByteBuffer buffer, int bufferLen);

	/**
	 * Original signature :
	 * <code>int DEV_GetProcessMessages(const INTPTR)</code><br> <i>native
	 * declaration : line 41</i>
	 */
	int DEV_GetProcessMessages(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetSoftFlow(const INTPTR)</code><br> <i>native
	 * declaration : line 42</i>
	 */
	int DEV_GetSoftFlow(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetStopBits(const INTPTR)</code><br> <i>native
	 * declaration : line 43</i>
	 */
	int DEV_GetStopBits(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_GetTimeOut(const INTPTR)</code><br> <i>native
	 * declaration : line 44</i>
	 */
	int DEV_GetTimeOut(int ecfHandle);

	/**
	 * Original signature :
	 * <code>int DEV_SetBaud(const INTPTR, const int)</code><br> <i>native
	 * declaration : line 45</i>
	 */
	int DEV_SetBaud(int ecfHandle, int baud);

	/**
	 * Original signature :
	 * <code>int DEV_SetDataBits(const INTPTR, const int)</code><br>
	 * <i>native declaration : line 46</i>
	 */
	int DEV_SetDataBits(int ecfHandle, int dataBits);

	/**
	 * Original signature :
	 * <code>int DEV_SetHandShake(const INTPTR, const int)</code><br>
	 * <i>native declaration : line 47</i>
	 */
	int DEV_SetHandShake(int ecfHandle, int handShake);

	/**
	 * Original signature :
	 * <code>int DEV_SetHardFlow(const INTPTR, const BOOL)</code><br>
	 * <i>native declaration : line 48</i>
	 */
	int DEV_SetHardFlow(int ecfHandle, boolean hardFlow);

	/**
	 * Original signature :
	 * <code>int DEV_SetMaxBandwidth(const INTPTR, const int)</code><br>
	 * <i>native declaration : line 49</i>
	 */
	int DEV_SetMaxBandwidth(int ecfHandle, int maxBandwidth);

	/**
	 * Original signature :
	 * <code>int DEV_SetParity(const INTPTR, const int)</code><br> <i>native
	 * declaration : line 50</i>
	 */
	int DEV_SetParity(int ecfHandle, int parity);

	/**
	 * Original signature :
	 * <code>int DEV_SetPorta(const INTPTR, const PCHAR)</code><br>
	 * <i>native declaration : line 51</i>
	 */
	int DEV_SetPorta(int ecfHandle, ByteBuffer porta);

	/**
	 * Original signature :
	 * <code>int DEV_SetProcessMessages(const INTPTR, const BOOL)</code><br>
	 * <i>native declaration : line 52</i>
	 */
	int DEV_SetProcessMessages(int ecfHandle, boolean processMessages);

	/**
	 * Original signature :
	 * <code>int DEV_SetSoftFlow(const INTPTR, const BOOL)</code><br>
	 * <i>native declaration : line 53</i>
	 */
	int DEV_SetSoftFlow(int ecfHandle, boolean softFlow);

	/**
	 * Original signature :
	 * <code>int DEV_SetStopBits(const INTPTR, const int)</code><br>
	 * <i>native declaration : line 54</i>
	 */
	int DEV_SetStopBits(int ecfHandle, int stopBits);

	/**
	 * Original signature :
	 * <code>int DEV_SetTimeOut(const INTPTR, const int)</code><br>
	 * <i>native declaration : line 55</i>
	 */
	int DEV_SetTimeOut(int ecfHandle, int timeOut);
}
