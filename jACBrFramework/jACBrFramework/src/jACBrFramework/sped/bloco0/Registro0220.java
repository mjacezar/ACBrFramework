package jACBrFramework.sped.bloco0;

/**
 * Fatores de conversao de unidade.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 09:46:48, revisao: $Id$
 */
public class Registro0220 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Unidade comercial a ser convertida na unidade de estoque, referida no registro 0200.
     */
    private String UNID_CONV;
    /**
     * Fator de conversao: fator utilizado para converter (multiplicar) a unidade a ser 
     * convertida na unidade adotada no inventario.
     */
    private double FAT_CONV;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">       
    /**
     * Unidade comercial a ser convertida na unidade de estoque, referida no registro 0200.
     * @return the UNID_CONV
     */
    public String getUNID_CONV() {
        return UNID_CONV;
    }

    /**
     * Unidade comercial a ser convertida na unidade de estoque, referida no registro 0200.
     * @param UNID_CONV the UNID_CONV to set
     */
    public void setUNID_CONV(String UNID_CONV) {
        this.UNID_CONV = UNID_CONV;
    }

    /**
     * Fator de conversao: fator utilizado para converter (multiplicar) a unidade a ser
     * convertida na unidade adotada no inventario.
     * @return the FAT_CONV
     */
    public double getFAT_CONV() {
        return FAT_CONV;
    }

    /**
     * Fator de conversao: fator utilizado para converter (multiplicar) a unidade a ser
     * convertida na unidade adotada no inventario.
     * @param FAT_CONV the FAT_CONV to set
     */
    public void setFAT_CONV(double FAT_CONV) {
        this.FAT_CONV = FAT_CONV;
    }
    // </editor-fold>
    
}