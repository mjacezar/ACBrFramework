package jACBrFramework;

import com.sun.jna.Pointer;
import java.nio.charset.Charset;

public abstract class ACBrInteropBase
{

	protected final static Charset UTF8;

	static {
		UTF8 = Charset.forName("UTF-8");
	}

	protected ACBrInteropBase()
	{
	}

	public abstract int getHandle();
}
