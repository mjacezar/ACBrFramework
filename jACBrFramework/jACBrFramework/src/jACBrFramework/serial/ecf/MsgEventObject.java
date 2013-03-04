package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class MsgEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String mensagem;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public MsgEventObject(Object source, String mensagem)
	{
		super(source);
		this.mensagem = mensagem;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getMensagem()
	{
		return this.mensagem;
	}
//</editor-fold>
}
