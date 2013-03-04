package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class BobinaAdicionaLinhasEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String linhas;
	private String operacao;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public BobinaAdicionaLinhasEventObject(Object source, String linhas, String operacao)
	{
		super(source);
		this.linhas = linhas;
		this.operacao = operacao;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getLinhas()
	{
		return this.linhas;
	}

	public String getOperacao()
	{
		return this.operacao;
	}
//</editor-fold>
}
