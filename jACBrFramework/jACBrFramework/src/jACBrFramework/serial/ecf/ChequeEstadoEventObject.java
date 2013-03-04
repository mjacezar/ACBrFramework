package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class ChequeEstadoEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private int estadoAtual;
	private boolean continuar;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public ChequeEstadoEventObject(Object source, int estadoAtual, boolean continuar)
	{
		super(source);
		this.estadoAtual = estadoAtual;
		this.continuar = continuar;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public int getEstadoAtual()
	{
		return this.estadoAtual;
	}

	public boolean getContinuar()
	{
		return this.continuar;
	}

	public void setContinuar(boolean value)
	{
		this.continuar = value;
	}
//</editor-fold>
}
