package jACBrFramework;

import java.lang.String;
import java.util.Date;

public abstract class ACBrClass extends ACBrInteropBase
{

	/**
	 * Handle para o componente nativo criado pelo ACBrFramework Este campo
	 * é utilizado apenas pela interface JNI.
	 */
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

	private void setHandle(int value)
	{
		this.handle = value;
	}

	protected void onInitialize() throws ACBrException
	{
	}

	protected void onFinalize() throws ACBrException
	{
	}
}
