package jACBrFramework.sped.bloco0;

import java.util.Date;

/**
 * Centro de custos.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:58:34, revisao: $Id$
 */
public class Registro0600 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Data da inclusao/alteracao.
     */
    private Date DT_ALT;
    /**
     * Codigo do centro de custos. 
     */
    private String COD_CCUS;
    /**
     * Nome do centro de custos. 
     */
    private String CCUS;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Data da inclusao/alteracao.
     * @return the DT_ALT
     */
    public Date getDT_ALT() {
        return DT_ALT;
    }

    /**
     * Data da inclusao/alteracao.
     * @param DT_ALT the DT_ALT to set
     */
    public void setDT_ALT(Date DT_ALT) {
        this.DT_ALT = DT_ALT;
    }

    /**
     * Codigo do centro de custos.
     * @return the COD_CCUS
     */
    public String getCOD_CCUS() {
        return COD_CCUS;
    }

    /**
     * Codigo do centro de custos.
     * @param COD_CCUS the COD_CCUS to set
     */
    public void setCOD_CCUS(String COD_CCUS) {
        this.COD_CCUS = COD_CCUS;
    }

    /**
     * Nome do centro de custos.
     * @return the CCUS
     */
    public String getCCUS() {
        return CCUS;
    }

    /**
     * Nome do centro de custos.
     * @param CCUS the CCUS to set
     */
    public void setCCUS(String CCUS) {
        this.CCUS = CCUS;
    }
    // </editor-fold>

}