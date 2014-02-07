package jACBrFramework.sped.blocoG;

/**
 * Identificacao do Item do Documento Fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:54:25, revisao: $Id$
 */
public class RegistroG140 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero sequencial do item no documento fiscal.
     */
    private String NUM_ITEM;
    /**
     * Codigo correspondente do bem no documento fiscal.
     */
    private String COD_ITEM;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Numero sequencial do item no documento fiscal.
     * @return the NUM_ITEM
     */
    public String getNUM_ITEM() {
        return NUM_ITEM;
    }

    /**
     * Numero sequencial do item no documento fiscal.
     * @param NUM_ITEM the NUM_ITEM to set
     */
    public void setNUM_ITEM(String NUM_ITEM) {
        this.NUM_ITEM = NUM_ITEM;
    }

    /**
     * Codigo correspondente do bem no documento fiscal.
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo correspondente do bem no documento fiscal.
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }
    // </editor-fold>    
    
}