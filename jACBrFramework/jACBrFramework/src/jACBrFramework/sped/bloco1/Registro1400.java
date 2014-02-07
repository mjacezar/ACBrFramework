package jACBrFramework.sped.bloco1;

/**
 * Informacao sobre VALORes agregados.
 *  
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 17:54:23, revisao: $Id$
 */
public class Registro1400 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Codigo do Municipio de origem.
     */
    private String MUN;
    /**
     * Valor mensal correspondente ao municipio.
     */
    private double VALOR;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Codigo do Municipio de origem.
     * @return the MUN
     */
    public String getMUN() {
        return MUN;
    }

    /**
     * Codigo do Municipio de origem.
     * @param MUN the MUN to set
     */
    public void setMUN(String MUN) {
        this.MUN = MUN;
    }

    /**
     * Valor mensal correspondente ao municipio.
     * @return the VALOR
     */
    public double getVALOR() {
        return VALOR;
    }

    /**
     * Valor mensal correspondente ao municipio.
     * @param VALOR the VALOR to set
     */
    public void setVALOR(double VALOR) {
        this.VALOR = VALOR;
    }
    // </editor-fold>    
    
}