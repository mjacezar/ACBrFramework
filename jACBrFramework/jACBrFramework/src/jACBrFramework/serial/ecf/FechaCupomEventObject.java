package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class FechaCupomEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">

	private String observacao;
	private int indiceBMP;

//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public FechaCupomEventObject(Object source, String observacao, int indiceBMP)
	{
		super(source);
		this.observacao = observacao;
		this.indiceBMP = indiceBMP;
	}

//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getObservacao()
	{
		return this.observacao;
	}

	public int getIndiceBMP()
	{
		return this.indiceBMP;
	}
//</editor-fold>
}
