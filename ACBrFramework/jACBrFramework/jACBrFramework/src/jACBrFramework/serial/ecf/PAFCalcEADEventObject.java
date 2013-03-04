package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class PAFCalcEADEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String arquivo;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public PAFCalcEADEventObject(Object source, String arquivo)
	{
		super(source);
		this.arquivo = arquivo;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getArquivo()
	{
		return this.arquivo;
	}
//</editor-fold>
}
