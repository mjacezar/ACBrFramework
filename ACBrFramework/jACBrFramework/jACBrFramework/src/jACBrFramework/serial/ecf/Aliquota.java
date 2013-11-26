package jACBrFramework.serial.ecf;

public class Aliquota
{
	//<editor-fold defaultstate="collapsed" desc="Fields">

	private String indice;
	private double aliquota;
	private char tipo;
	private double total;
	private boolean sequencia;

	//</editor-fold>
		
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	public Aliquota(String indice, double aliquota, char tipo, double total, boolean sequencia)
	{
		this.indice = indice;
		this.aliquota = aliquota;
		this.tipo = tipo;
		this.total = total;
		this.sequencia = sequencia;
	}
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	
	public String getIndice()
	{
		return indice;
	}

	public double getAliquota()
	{
		return aliquota;
	}

	public char getTipo()
	{
		return tipo;
	}

	public double getTotal()
	{
		return total;
	}

	public boolean getSequencia()
	{
		return sequencia;
	}
	
	//</editor-fold>
}
