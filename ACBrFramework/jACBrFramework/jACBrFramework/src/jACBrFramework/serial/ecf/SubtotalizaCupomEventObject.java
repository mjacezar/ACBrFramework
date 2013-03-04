package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class SubtotalizaCupomEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private double descontoAcrescimo;
	private String mensagemRodape;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public SubtotalizaCupomEventObject(Object source, double descontoAcrescimo, String mensagemRodape)
	{
		super(source);
		this.descontoAcrescimo = descontoAcrescimo;
		this.mensagemRodape = mensagemRodape;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public double getDescontoAcrescimo()
	{
		return this.descontoAcrescimo;
	}

	public String getMensagemRodape()
	{
		return this.mensagemRodape;
	}
//</editor-fold>
}
