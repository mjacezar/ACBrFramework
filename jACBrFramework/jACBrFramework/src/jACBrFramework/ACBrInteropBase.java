package jACBrFramework;

import com.sun.jna.ptr.DoubleByReference;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;
import java.util.Date;

public abstract class ACBrInteropBase
{
	protected interface GetStringEntryPoint
	{
		int invoke(int handle, ByteBuffer buffer, int bufferLen);
	}

	protected interface SetStringEntryPoint
	{
		int invoke(int handle, ByteBuffer buffer);
	}
	
	protected interface GetBooleanEntryPoint
	{
		int invoke(int handle);
	}

	protected interface SetBooleanEntryPoint
	{
		int invoke(int handle, boolean value);
	}

	protected interface GetIntEntryPoint
	{
		int invoke(int handle);
	}

	protected interface SetIntEntryPoint
	{
		int invoke(int handle, int value);
	}	
	
	protected interface GetDoubleEntryPoint
	{
		int invoke(int handle, DoubleByReference value);
	}
	
	protected interface SetDoubleEntryPoint
	{
		int invoke(int handle, double value);
	}	
		
	
	
	protected final static Charset UTF8;

	static {
		UTF8 = Charset.forName("UTF-8");
	}

	protected ACBrInteropBase()
	{
	}

	public abstract int getHandle();
	
	protected abstract void checkResult(int result) throws ACBrException;
	
	protected String getString(GetStringEntryPoint entryPoint) throws ACBrException
	{
		final int LEN = 256;
		return getString(entryPoint, LEN);
	}
	
	protected String getString(GetStringEntryPoint entryPoint, int len) throws ACBrException
	{
		ByteBuffer buffer = ByteBuffer.allocate(len);
		int ret = entryPoint.invoke(getHandle(), buffer, len);
		checkResult(ret);

		return new String(buffer.array(), 0, ret, UTF8);
	}
	
	protected void setString(String value, SetStringEntryPoint entryPoint) throws ACBrException
	{	
		ByteBuffer buffer = ByteBuffer.wrap(value.getBytes(UTF8));
		int ret = entryPoint.invoke(getHandle(), buffer);
		checkResult(ret);		
	}
	
	protected boolean getBoolean(GetBooleanEntryPoint entryPoint) throws ACBrException
	{
		int ret = entryPoint.invoke(getHandle());
		checkResult(ret);

		return ret != 0;
	}
	
	protected void setBoolean(Boolean value, SetBooleanEntryPoint entryPoint) throws ACBrException
	{	
		int ret = entryPoint.invoke(getHandle(), value);
		checkResult(ret);		
	}

	protected double getDouble(GetDoubleEntryPoint entryPoint) throws ACBrException
	{
		DoubleByReference value = new DoubleByReference();
		int ret = entryPoint.invoke(getHandle(), value);
		checkResult(ret);

		return value.getValue();
	}
	
	protected void setDouble(Double value, SetDoubleEntryPoint entryPoint) throws ACBrException
	{	
		int ret = entryPoint.invoke(getHandle(), value);
		checkResult(ret);		
	}

	protected Date getDate(GetDoubleEntryPoint entryPoint) throws ACBrException
	{
		DoubleByReference value = new DoubleByReference();
		int ret = entryPoint.invoke(getHandle(), value);
		checkResult(ret);

		OleDate oleDate = new OleDate(value.getValue());
		return oleDate.toDate();
	}
	
	protected void setDate(Date value, SetDoubleEntryPoint entryPoint) throws ACBrException
	{	
		OleDate oleDate = new OleDate(value);
		int ret = entryPoint.invoke(getHandle(), oleDate.toDouble());
		checkResult(ret);		
	}
	
	protected int getInt(GetIntEntryPoint entryPoint) throws ACBrException
	{
		int ret = entryPoint.invoke(getHandle());
		checkResult(ret);

		return ret;
	}
	
	protected void setInt(int value, SetIntEntryPoint entryPoint) throws ACBrException
	{	
		int ret = entryPoint.invoke(getHandle(), value);
		checkResult(ret);		
	}	
	

	
}
