package jACBrFramework;

import java.util.EventObject;

public final class ChaveEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String chave;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public ChaveEventObject(Object source, String chave)
	{
		super(source);
		this.chave = chave;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getChave()
	{
		return this.chave;
	}

	public void setChave(String value)
	{
		this.chave = value;
	}
//</editor-fold>
}
