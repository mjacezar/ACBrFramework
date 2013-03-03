package jACBrFramework.serial;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrClass;
import jACBrFramework.ACBrComposedClass;
import jACBrFramework.ACBrException;
import jACBrFramework.interop.ACBrDeviceInterop;
import java.lang.String;
import java.nio.ByteBuffer;

public final class ACBrDevice extends ACBrComposedClass
{

	public ACBrDevice(ACBrClass parent) throws ACBrException
	{
		super(parent);
	}

	//<editor-fold defaultstate="collapsed" desc="Properties">
	
	public String getPorta() throws ACBrException
	{

		ByteBuffer returnBuffer = ByteBuffer.allocate(STR_BUFFER_LEN);
		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetPorta(getHandle(), returnBuffer, STR_BUFFER_LEN);
		checkResult(ret);

		return fromUTF8(returnBuffer, ret);
	}

	public void setPorta(String value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetPorta(getHandle(), toUTF8(value));
		checkResult(ret);


	}

	public int getBaud() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetBaud(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setBaud(int value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetBaud(getHandle(), value);
		checkResult(ret);


	}

	public int getDataBits() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetDataBits(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setDataBits(int value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetDataBits(getHandle(), value);
		checkResult(ret);


	}

	public int getParity() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetParity(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setParity(int value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetParity(getHandle(), value);
		checkResult(ret);


	}

	public int getStopBits() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetStopBits(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setStopBits(int value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetStopBits(getHandle(), value);
		checkResult(ret);


	}

	public int getHandShake() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetHandShake(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setHandShake(int value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetHandShake(getHandle(), value);
		checkResult(ret);


	}

	public boolean getHardFlow() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetHardFlow(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setHardFlow(boolean value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetHardFlow(getHandle(), value);
		checkResult(ret);


	}

	public boolean getSoftFlow() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetSoftFlow(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setSoftFlow(boolean value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetSoftFlow(getHandle(), value);
		checkResult(ret);


	}

	public int getTimeOut() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetTimeOut(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setTimeOut(int value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetTimeOut(getHandle(), value);
		checkResult(ret);


	}

	public int getMaxBandwidth() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetMaxBandwidth(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setMaxBandwidth(int value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetMaxBandwidth(getHandle(), value);
		checkResult(ret);


	}

	public boolean getProcessMessages() throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_GetProcessMessages(getHandle());
		checkResult(ret);

		return ret != 0;
	}

	public void setProcessMessages(boolean value) throws ACBrException
	{


		int ret = ACBrDeviceInterop.INSTANCE.DEV_SetProcessMessages(getHandle(), value);
		checkResult(ret);


	}
	//</editor-fold>
}
