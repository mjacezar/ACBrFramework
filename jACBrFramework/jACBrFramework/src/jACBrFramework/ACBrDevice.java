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
		return getInt(new GetIntEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetBaud(handle);
			}
		});
	}

	public void setBaud(int value) throws ACBrException
	{
		setInt(value, new SetIntEntryPoint() {

			@Override
			public int invoke(int handle, int value)
			{
				return DeviceInterop.INSTANCE.DEV_SetBaud(handle, value);
			}
		});

	}

	public int getDataBits() throws ACBrException
	{
		return getInt(new GetIntEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetDataBits(handle);
			}
		});
	}

	public void setDataBits(int value) throws ACBrException
	{
		setInt(value, new SetIntEntryPoint() {

			@Override
			public int invoke(int handle, int value)
			{
				return DeviceInterop.INSTANCE.DEV_SetDataBits(handle, value);
			}
		});
	}

	public int getHandShake() throws ACBrException
	{
		return getInt(new GetIntEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetHandShake(handle);
			}
		});
	}

	public void setHandShake(int value) throws ACBrException
	{
		setInt(value, new SetIntEntryPoint() {

			@Override
			public int invoke(int handle, int value)
			{
				return DeviceInterop.INSTANCE.DEV_SetHandShake(handle, value);
			}
		});
	}

	public boolean getHardFlow() throws ACBrException
	{
		return getBoolean(new GetBooleanEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetHardFlow(handle);
			}
		});
	}

	public void setHardFlow(boolean value) throws ACBrException
	{
		setBoolean(value, new SetBooleanEntryPoint() {

			@Override
			public int invoke(int handle, boolean value)
			{
				return DeviceInterop.INSTANCE.DEV_SetHardFlow(handle, value);
			}
		});
	}

	public int getMaxBandwidth() throws ACBrException
	{
		return getInt(new GetIntEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetMaxBandwidth(handle);
			}
		});
	}

	public void setMaxBandwidth(int value) throws ACBrException
	{
		setInt(value, new SetIntEntryPoint() {

			@Override
			public int invoke(int handle, int value)
			{
				return DeviceInterop.INSTANCE.DEV_SetMaxBandwidth(handle, value);
			}
		});		
	}

	public int getParity() throws ACBrException
	{
		return getInt(new GetIntEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetParity(handle);
			}
		});		
	}

	public void setParity(int value) throws ACBrException
	{
		setInt(value, new SetIntEntryPoint() {

			@Override
			public int invoke(int handle, int value)
			{
				return DeviceInterop.INSTANCE.DEV_SetParity(handle, value);
			}
		});			
	}

	public String getPorta() throws ACBrException
	{
		return getString(new GetStringEntryPoint() {

			@Override
			public int invoke(int handle, ByteBuffer buffer, int bufferLen)
			{
				return DeviceInterop.INSTANCE.DEV_GetPorta(handle, buffer, bufferLen);
			}
		});		
	}

	public void setPorta(String value) throws ACBrException
	{
		setString(value, new SetStringEntryPoint() {

			@Override
			public int invoke(int handle, ByteBuffer buffer)
			{
				return DeviceInterop.INSTANCE.DEV_SetPorta(handle, buffer);
			}
		});
	}

	public boolean getProcessMessages() throws ACBrException
	{
		return getBoolean(new GetBooleanEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetProcessMessages(handle);
			}
		});		
	}

	public void setProcessMessages(boolean value) throws ACBrException
	{
		setBoolean(value, new SetBooleanEntryPoint() {

			@Override
			public int invoke(int handle, boolean value)
			{
				return DeviceInterop.INSTANCE.DEV_SetProcessMessages(handle, value);
			}
		});		

	}

	public boolean getSoftFlow() throws ACBrException
	{
		return getBoolean(new GetBooleanEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetSoftFlow(handle);
			}
		});		
	}

	public void setSoftFlow(boolean value) throws ACBrException
	{
		setBoolean(value, new SetBooleanEntryPoint() {

			@Override
			public int invoke(int handle, boolean value)
			{
				return DeviceInterop.INSTANCE.DEV_SetSoftFlow(handle, value);
			}
		});		
	}

	public int getStopBits() throws ACBrException
	{
		return getInt(new GetIntEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetStopBits(handle);
			}
		});			
	}

	public void setStopBits(int value) throws ACBrException
	{
		setInt(value, new SetIntEntryPoint() {

			@Override
			public int invoke(int handle, int value)
			{
				return DeviceInterop.INSTANCE.DEV_SetStopBits(handle, value);
			}
		});					
	}

	public int getTimeOut() throws ACBrException
	{
		return getInt(new GetIntEntryPoint() {

			@Override
			public int invoke(int handle)
			{
				return DeviceInterop.INSTANCE.DEV_GetTimeOut(handle);
			}
		});		
	}

	public void setTimeOut(int value) throws ACBrException
	{
		setInt(value, new SetIntEntryPoint() {

			@Override
			public int invoke(int handle, int value)
			{
				return DeviceInterop.INSTANCE.DEV_SetTimeOut(handle, value);
			}
		});			
	}
}
