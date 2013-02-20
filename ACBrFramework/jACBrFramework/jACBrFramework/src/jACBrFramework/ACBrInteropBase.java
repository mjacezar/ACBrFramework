package jACBrFramework;

import java.lang.String;
import java.util.Date;

public abstract class ACBrInteropBase
{

	static 
	{
		//Carrega a biblioteca de chamadas nativas JNI
		System.loadLibrary("ACBrFramework32");
		System.loadLibrary("ACBrFramework_JNI");
	}

	protected ACBrInteropBase()
	{
	}

	public abstract int getHandle();
}
