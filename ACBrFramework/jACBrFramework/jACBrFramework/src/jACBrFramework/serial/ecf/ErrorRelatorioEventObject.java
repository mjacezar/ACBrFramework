package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class ErrorRelatorioEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">

	private boolean tratado;
	private int indice;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public ErrorRelatorioEventObject(Object source, boolean tratado, int indice)
	{
		super(source);
		this.tratado = tratado;
		this.indice = indice;
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

	public int getIndice()
	{
		return this.indice;
	}
//</editor-fold>
}
