package jACBrFramework.serial.ecf;

public class FormaPagamento
{

	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	private String indice;
	private String descricao;
	private boolean permiteVinculado;
	private double total;

	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	FormaPagamento(String indice, String descricao, boolean permiteVinculado, double total)
	{
		this.indice = indice;
		this.descricao = descricao;
		this.permiteVinculado = permiteVinculado;
		this.total = total;
	}
	
	//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getIndice()
	{
		return indice;
	}

	public String getDescricao()
	{
		return descricao;
	}

	public boolean getPermiteVinculado()
	{
		return permiteVinculado;
	}

	public double getTotal()
	{
		return total;
	}
	//</editor-fold>
}
