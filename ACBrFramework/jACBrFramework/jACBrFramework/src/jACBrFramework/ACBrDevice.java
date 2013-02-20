package jACBrFramework;

import java.lang.String;
import java.util.Date;

public final class ACBrDevice extends ACBrComposedClass
{

	ACBrDevice(ACBrClass parent) throws ACBrException
	{
		super(parent);
	}

	public native int getBaud() throws ACBrException;

	public native void setBaud(int value) throws ACBrException;

	public native int getDataBits() throws ACBrException;

	public native void setDataBits(int value) throws ACBrException;

	public native int getHandShake() throws ACBrException;

	public native void setHandShake(int value) throws ACBrException;

	public native boolean getHardFlow() throws ACBrException;

	public native void setHardFlow(boolean value) throws ACBrException;

	public native int getMaxBandwidth() throws ACBrException;

	public native void setMaxBandwidth(int value) throws ACBrException;

	public native int getParity() throws ACBrException;

	public native void setParity(int value) throws ACBrException;

	public native String getPorta() throws ACBrException;

	public native void setPorta(String value) throws ACBrException;

	public native boolean getProcessMessages() throws ACBrException;

	public native void setProcessMessages(boolean value) throws ACBrException;

	public native boolean getSoftFlow() throws ACBrException;

	public native void setSoftFlow(boolean value) throws ACBrException;

	public native int getStopBits() throws ACBrException;

	public native void setStopBits(int value) throws ACBrException;

	public native int getTimeOut() throws ACBrException;

	public native void setTimeOut(int value) throws ACBrException;
}
