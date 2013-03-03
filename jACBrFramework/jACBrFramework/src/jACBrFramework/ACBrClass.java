package jACBrFramework;

public abstract class ACBrClass extends ACBrInteropBase
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	private int handle;
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	protected ACBrClass() throws ACBrException
	{
		onInitialize();
	}
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Methods">
	
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
	
	@Override
	protected abstract void checkResult(int result) throws ACBrException;
	
	//</editor-fold>
}
