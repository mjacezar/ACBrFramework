package jACBrFramework;

public abstract class ACBrComposedClass extends ACBrInteropBase
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	private int composedHandle;
	private ACBrClass parent;
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
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

	//</editor-fold>	
	
	//<editor-fold defaultstate="collapsed" desc="Methods">
	
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
	
	//</editor-fold>
}
