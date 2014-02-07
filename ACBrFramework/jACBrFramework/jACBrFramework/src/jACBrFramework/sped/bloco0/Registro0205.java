package jACBrFramework.sped.bloco0;

import java.util.Date;

/**
 * Alteracao do item.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 09:29:15, revisao: $Id$
 */
public class Registro0205 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">     
    /**
     * Descricao anterior do item.
     */
    private String DESCR_ANT_ITEM;
    /**
     * Data inicial de utilizacao da descricao do item.
     */
    private Date DT_INI;
    /**
     * Data final de utilizacao da descricao do item.
     */
    private Date DT_FIN;
    /**
     * Codigo anterior do item com relacao a ultima informacao apresentada.
     */
    private String COD_ANT_ITEM;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">       
    /**
     * Descricao anterior do item.
     * @return the DESCR_ANT_ITEM
     */
    public String getDESCR_ANT_ITEM() {
        return DESCR_ANT_ITEM;
    }

    /**
     * Descricao anterior do item.
     * @param DESCR_ANT_ITEM the DESCR_ANT_ITEM to set
     */
    public void setDESCR_ANT_ITEM(String DESCR_ANT_ITEM) {
        this.DESCR_ANT_ITEM = DESCR_ANT_ITEM;
    }

    /**
     * Data inicial de utilizacao da descricao do item.
     * @return the DT_INI
     */
    public Date getDT_INI() {
        return DT_INI;
    }

    /**
     * Data inicial de utilizacao da descricao do item.
     * @param DT_INI the DT_INI to set
     */
    public void setDT_INI(Date DT_INI) {
        this.DT_INI = DT_INI;
    }

    /**
     * Data final de utilizacao da descricao do item.
     * @return the DT_FIN
     */
    public Date getDT_FIN() {
        return DT_FIN;
    }

    /**
     * Data final de utilizacao da descricao do item.
     * @param DT_FIN the DT_FIN to set
     */
    public void setDT_FIN(Date DT_FIN) {
        this.DT_FIN = DT_FIN;
    }

    /**
     * Codigo anterior do item com relacao a ultima informacao apresentada.
     * @return the COD_ANT_ITEM
     */
    public String getCOD_ANT_ITEM() {
        return COD_ANT_ITEM;
    }

    /**
     * Codigo anterior do item com relacao a ultima informacao apresentada.
     * @param COD_ANT_ITEM the COD_ANT_ITEM to set
     */
    public void setCOD_ANT_ITEM(String COD_ANT_ITEM) {
        this.COD_ANT_ITEM = COD_ANT_ITEM;
    }
    // </editor-fold>
        
}