package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class ErrorEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private boolean tratado;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public ErrorEventObject(Object source, boolean tratado)
	{
		super(source);
		this.tratado = tratado;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public boolean getTratado()
	{
		return this.tratado;
	}

	public void setTratado(boolean value)
	{
		this.tratado = value;
	}
//</editor-fold>
}
