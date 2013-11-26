package jACBrFramework.serial.ecf;

/**
 * Relatorios Gerenciais. 
 * 
 * @author Jose Mauro
 * @version Criado em: 22/11/2013 10:49:53, revisao: $Id$
 */
public class RelatorioGerencial {
	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String indice;
	private String descricao;
	private int tipo;
	//</editor-fold>		
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public RelatorioGerencial(String indice, String descricao, int tipo) {
		this.indice = indice;
		this.descricao = descricao;
		this.tipo = tipo;
	}
	//</editor-fold>
	//<editor-fold defaultstate="collapsed" desc="Properties">	
	public String getIndice() {
		return indice;
	}
    public String getDescricao() {
        return descricao;
    }	
    public int getTipo() {
        return tipo;
    }    
	//</editor-fold>
}