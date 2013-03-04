package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class ChangeEstadoEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private int estadoAnterior;
	private int estadoAtual;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public ChangeEstadoEventObject(Object source, int estadoAnterior, int estadoAtual)
	{
		super(source);
		this.estadoAnterior = estadoAnterior;
		this.estadoAtual = estadoAtual;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public int getEstadoAnterior()
	{
		return this.estadoAnterior;
	}

	public int getEstadoAtual()
	{
		return this.estadoAtual;
	}
//</editor-fold>
}
