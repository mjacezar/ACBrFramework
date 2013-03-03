package jACBrFramework.serial.ecf;

import java.util.EventObject;

public class BobinaEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	private String linhas;
	private String operacao;
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	public BobinaEventObject(Object source, String linhas, String operacao)
	{
		super(source);
		this.linhas = linhas;
		this.operacao = operacao;
	}
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	public String getLinhas()
	{
		return linhas;
	}
	
	public String Operacao()
	{
		return operacao;
	}
	
	//</editor-fold>
}
