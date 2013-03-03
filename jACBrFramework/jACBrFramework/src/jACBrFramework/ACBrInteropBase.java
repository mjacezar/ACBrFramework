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
	
	//<editor-fold defaultstate="collapsed" desc="Constructors">
	static {
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
	
	protected String[] toUTF8(String[] value)
	{
		String[] array = new String[value.length];
		for(int i=0; i<array.length; i++)
		{
			array[i] = new String(value[i].getBytes(UTF8));
		}
		
		return array;
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
	//</editor-fold>
	
	//</editor-fold>
}
