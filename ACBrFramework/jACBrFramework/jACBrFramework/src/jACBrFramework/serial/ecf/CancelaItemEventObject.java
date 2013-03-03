package jACBrFramework.serial.ecf;

import java.util.EventObject;

public class CancelaItemEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	private int numItem;
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	public CancelaItemEventObject(Object source, int numItem)
	{
		super(source);
		this.numItem = numItem;
	}
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Properties">
	
	public int getNumItem()
	{
		return this.numItem;
	}
	
	//</editor-fold>	
}
