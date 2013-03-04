package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class EfetuaPagamentoEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String codFormaPagto;
	private double valor;
	private String observacao;
	private boolean imprimeVinculado;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public EfetuaPagamentoEventObject(Object source, String codFormaPagto, double valor, String observacao, boolean imprimeVinculado)
	{
		super(source);
		this.codFormaPagto = codFormaPagto;
		this.valor = valor;
		this.observacao = observacao;
		this.imprimeVinculado = imprimeVinculado;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getCodFormaPagto()
	{
		return this.codFormaPagto;
	}

	public double getValor()
	{
		return this.valor;
	}

	public String getObservacao()
	{
		return this.observacao;
	}

	public boolean getImprimeVinculado()
	{
		return this.imprimeVinculado;
	}
//</editor-fold>
}
