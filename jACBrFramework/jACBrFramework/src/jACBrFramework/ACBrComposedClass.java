package jACBrFramework;

import com.sun.jna.Pointer;

public abstract class ACBrComposedClass extends ACBrInteropBase
{

	private int composedHandle;
	private ACBrClass parent;

	protected ACBrComposedClass(ACBrClass parent) throws ACBrException
	{
		this.parent = parent;
		this.composedHandle = 0;
	}

	protected ACBrComposedClass(ACBrClass parent, int composedHandle) throws ACBrException
	{
		this.parent = parent;
		this.composedHandle = composedHandle;
	}

	@Override
	public int getHandle()
	{
		return this.parent.getHandle();
	}

	public int getComposedHandler()
	{
		return this.composedHandle;
	}

	public ACBrClass getParent()
	{
		return this.parent;
	}

	protected void checkResult(int result) throws ACBrException
	{
		parent.checkResult(result);
	}
}
