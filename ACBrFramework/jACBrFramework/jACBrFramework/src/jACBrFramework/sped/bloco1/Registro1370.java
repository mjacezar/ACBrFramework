package jACBrFramework.sped.bloco1;

/**
 * Bicos da bomba.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 17:21:25, revisao: $Id$
 */
public class Registro1370 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero sequencial do bico ligado a bomba.
     */
    private String NUM_BICO;
    /**
     * Codigo do Produto, constante do registro 0200.
     */
    private String COD_ITEM;
    /**
     * Tanque que armazena o combustivel.
     */
    private String NUM_TANQUE;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Numero sequencial do bico ligado a bomba.
     * @return the NUM_BICO
     */
    public String getNUM_BICO() {
        return NUM_BICO;
    }

    /**
     * Numero sequencial do bico ligado a bomba.
     * @param NUM_BICO the NUM_BICO to set
     */
    public void setNUM_BICO(String NUM_BICO) {
        this.NUM_BICO = NUM_BICO;
    }

    /**
     * Codigo do Produto, constante do registro 0200.
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do Produto, constante do registro 0200.
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Tanque que armazena o combustivel.
     * @return the NUM_TANQUE
     */
    public String getNUM_TANQUE() {
        return NUM_TANQUE;
    }

    /**
     * Tanque que armazena o combustivel.
     * @param NUM_TANQUE the NUM_TANQUE to set
     */
    public void setNUM_TANQUE(String NUM_TANQUE) {
        this.NUM_TANQUE = NUM_TANQUE;
    }
    // </editor-fold>
    
}