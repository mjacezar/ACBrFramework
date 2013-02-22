package jACBrFramework;

import jACBrFramework.interop.DeviceInterop;
import java.lang.String;
import java.nio.ByteBuffer;

public final class ACBrDevice extends ACBrComposedClass
{

	ACBrDevice(ACBrClass parent) throws ACBrException
	{
		super(parent);
	}

	public int getBaud() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetBaud(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setBaud(int value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetBaud(getHandle(), value);
		checkResult(ret);
	}

	public int getDataBits() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetDataBits(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setDataBits(int value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetDataBits(getHandle(), value);
		checkResult(ret);
	}

	public int getHandShake() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetHandShake(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setHandShake(int value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetHandShake(getHandle(), value);
		checkResult(ret);
	}

	public boolean getHardFlow() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetHardFlow(getHandle());
		checkResult(ret);

		return ret == 1;
	}

	public void setHardFlow(boolean value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetHardFlow(getHandle(), value);
		checkResult(ret);
	}

	public int getMaxBandwidth() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetMaxBandwidth(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setMaxBandwidth(int value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetMaxBandwidth(getHandle(), value);
		checkResult(ret);
	}

	public int getParity() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetParity(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setParity(int value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetParity(getHandle(), value);
		checkResult(ret);
	}

	public String getPorta() throws ACBrException
	{
		int LEN = 256;
		ByteBuffer buffer = ByteBuffer.allocate(LEN);
		int ret = DeviceInterop.INSTANCE.DEV_GetPorta(getHandle(), buffer, LEN);
		checkResult(ret);

		return new String(buffer.array(), 0, ret, UTF8);
	}

	public void setPorta(String value) throws ACBrException
	{

		ByteBuffer buffer = ByteBuffer.wrap(value.getBytes(UTF8));
		int ret = DeviceInterop.INSTANCE.DEV_SetPorta(getHandle(), buffer);
		checkResult(ret);
	}

	public boolean getProcessMessages() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetProcessMessages(getHandle());
		checkResult(ret);

		return ret == 1;
	}

	public void setProcessMessages(boolean value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetProcessMessages(getHandle(), value);
		checkResult(ret);
	}

	public boolean getSoftFlow() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetSoftFlow(getHandle());
		checkResult(ret);

		return ret == 1;
	}

	public void setSoftFlow(boolean value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetSoftFlow(getHandle(), value);
		checkResult(ret);
	}

	public int getStopBits() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetStopBits(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setStopBits(int value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetStopBits(getHandle(), value);
		checkResult(ret);
	}

	public int getTimeOut() throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_GetTimeOut(getHandle());
		checkResult(ret);

		return ret;
	}

	public void setTimeOut(int value) throws ACBrException
	{
		int ret = DeviceInterop.INSTANCE.DEV_SetTimeOut(getHandle(), value);
		checkResult(ret);
	}
}
