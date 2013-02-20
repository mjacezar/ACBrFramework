package jACBrFramework;

import java.lang.String;
import java.util.Date;

public abstract class ACBrComposedClass extends ACBrInteropBase
{

	/**
	 * Handle para o componente nativo criado pelo ACBrFramework Este campo
	 * é utilizado apenas pela interface JNI.
	 */
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

	public ACBrClass getParent()
	{
		return this.parent;
	}
}
