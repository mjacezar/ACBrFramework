package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class RelatorioGerencialEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private int indice;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public RelatorioGerencialEventObject(Object source, int indice)
	{
		super(source);
		this.indice = indice;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public int getIndice()
	{
		return this.indice;
	}
//</editor-fold>
}
