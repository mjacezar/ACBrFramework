package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class VendeItemEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String codigo;
	private String descricao;
	private String aliquotaICMS;
	private double qtd;
	private double valorUnitario;
	private double valorDescontoAcrescimo;
	private String unidade;
	private String tipoDescontoAcrescimo;
	private String descontoAcrescimo;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public VendeItemEventObject(Object source, String codigo, String descricao, String aliquotaICMS, double qtd, double valorUnitario, double valorDescontoAcrescimo, String unidade, String tipoDescontoAcrescimo, String descontoAcrescimo)
	{
		super(source);
		this.codigo = codigo;
		this.descricao = descricao;
		this.aliquotaICMS = aliquotaICMS;
		this.qtd = qtd;
		this.valorUnitario = valorUnitario;
		this.valorDescontoAcrescimo = valorDescontoAcrescimo;
		this.unidade = unidade;
		this.tipoDescontoAcrescimo = tipoDescontoAcrescimo;
		this.descontoAcrescimo = descontoAcrescimo;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getCodigo()
	{
		return this.codigo;
	}

	public String getDescricao()
	{
		return this.descricao;
	}

	public String getAliquotaICMS()
	{
		return this.aliquotaICMS;
	}

	public double getQtd()
	{
		return this.qtd;
	}

	public double getValorUnitario()
	{
		return this.valorUnitario;
	}

	public double getValorDescontoAcrescimo()
	{
		return this.valorDescontoAcrescimo;
	}

	public String getUnidade()
	{
		return this.unidade;
	}

	public String getTipoDescontoAcrescimo()
	{
		return this.tipoDescontoAcrescimo;
	}

	public String getDescontoAcrescimo()
	{
		return this.descontoAcrescimo;
	}
//</editor-fold>
}
