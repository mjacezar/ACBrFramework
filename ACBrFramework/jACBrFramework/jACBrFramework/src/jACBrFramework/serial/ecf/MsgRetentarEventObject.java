package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class MsgRetentarEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String mensagem;
	private String situacao;
	private boolean result;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public MsgRetentarEventObject(Object source, String mensagem, String situacao, boolean result)
	{
		super(source);
		this.mensagem = mensagem;
		this.situacao = situacao;
		this.result = result;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getMensagem()
	{
		return this.mensagem;
	}

	public String getSituacao()
	{
		return this.situacao;
	}

	public boolean getResult()
	{
		return this.result;
	}

	public void setResult(boolean value)
	{
		this.result = value;
	}
//</editor-fold>
}
