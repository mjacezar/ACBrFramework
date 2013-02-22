package jACBrFramework;

import com.sun.jna.Pointer;

public abstract class ACBrClass extends ACBrInteropBase
{

	private int handle;

	protected ACBrClass() throws ACBrException
	{
		onInitialize();
	}

	@Override
	protected void finalize() throws Throwable
	{
		onFinalize();
		setHandle(0);
		super.finalize();
	}

	@Override
	public int getHandle()
	{
		return this.handle;
	}

	protected void setHandle(int value)
	{
		this.handle = value;
	}

	protected void onInitialize() throws ACBrException
	{
	}

	protected void onFinalize() throws ACBrException
	{
	}

	protected abstract void checkResult(int result) throws ACBrException;
}
