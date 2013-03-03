package jACBrFramework;

import com.sun.jna.ptr.DoubleByReference;
import java.nio.ByteBuffer;
import java.nio.charset.Charset;
import java.util.Date;

public abstract class ACBrInteropBase
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	protected final int STR_BUFFER_LEN = 256;
	
	protected final static Charset UTF8;

	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="InnerTypes">
	
	protected interface GetStringEntryPoint
	{
		int invoke(int handle, ByteBuffer buffer, int bufferLen);
	}
	
	protected interface SetStringEntryPoint
	{
		int invoke(int handle, String value);
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
	
	protected interface GetStringArrayEntryPoint
	{
		int invoke(int handle, ByteBuffer buffer, int bufferLen, int index);
	}
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructors">
	
	static 
	{
		UTF8 = Charset.forName("UTF-8");
	}
	
	protected ACBrInteropBase()
	{
	}
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Methods">
	
	//<editor-fold defaultstate="collapsed" desc="Abstract Methods">
	
	public abstract int getHandle();
	
	protected abstract void checkResult(int result) throws ACBrException;
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="InteropHelper Methods">
	
	protected String toUTF8(String value)
	{
		return new String(value.getBytes(UTF8));
	}
	
	protected String fromUTF8(String value)
	{
		return new String(value.getBytes(), UTF8);
	}
	
	protected String fromUTF8(ByteBuffer buffer, int len)
	{
		return new String(buffer.array(), 0, len, UTF8);
	}
	
	protected String fromUTF8(byte[] value)
	{
		return new String(value, UTF8).trim();
	}
	
	protected String getString(GetStringEntryPoint entryPoint) throws ACBrException
	{
		return getString(entryPoint, STR_BUFFER_LEN);
	}
	
	protected String getString(GetStringEntryPoint entryPoint, int len) throws ACBrException
	{
		ByteBuffer buffer = ByteBuffer.allocate(len);
		int ret = entryPoint.invoke(getHandle(), buffer, len);
		checkResult(ret);
		
		return fromUTF8(buffer, ret);
	}
	
	protected void setString(String value, SetStringEntryPoint entryPoint) throws ACBrException
	{
		int ret = entryPoint.invoke(getHandle(), toUTF8(value));
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
		
		return OleDate.fromOADate(value.getValue());
	}
	
	protected void setDate(Date value, SetDoubleEntryPoint entryPoint) throws ACBrException
	{
		int ret = entryPoint.invoke(getHandle(), OleDate.toOADate(value));
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
	
	protected String[] getStringArray(GetStringArrayEntryPoint entryPoint, GetIntEntryPoint countEntryPoint) throws ACBrException
	{
		return getStringArray(entryPoint, countEntryPoint, STR_BUFFER_LEN);
	}
	
	protected String[] getStringArray(GetStringArrayEntryPoint entryPoint, GetIntEntryPoint countEntryPoint, int len) throws ACBrException
	{
		int count = countEntryPoint.invoke(getHandle());
		checkResult(count);
		
		String[] items = new String[count];
		for(int i=0; i<count; i++)
		{
			ByteBuffer buffer = ByteBuffer.allocate(len);
			int ret = entryPoint.invoke(getHandle(), buffer, len, i);
			checkResult(ret);
			
			items[i] = new String(buffer.array(), 0, ret, UTF8);
		}
		
		return items;
	}
	
	protected void setStringArray() throws ACBrException
	{
		
	}
	
	//</editor-fold>
	
	//</editor-fold>
}
