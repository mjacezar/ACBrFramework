package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class SangriaSuprimentoEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private double valor;
	private String obs;
	private String descricaoCNF;
	private String descricaoFPG;

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public SangriaSuprimentoEventObject(Object source, double valor, String obs, String descricaoCNF, String descricaoFPG)
	{
		super(source);
		this.valor = valor;
		this.obs = obs;
		this.descricaoCNF = descricaoCNF;
		this.descricaoFPG = descricaoFPG;
	}

//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	public double getValor()
	{
		return this.valor;
	}

	public String getObs()
	{
		return this.obs;
	}

	public String getDescricaoCNF()
	{
		return this.descricaoCNF;
	}

	public String getDescricaoFPG()
	{
		return this.descricaoFPG;
	}
//</editor-fold>
}
