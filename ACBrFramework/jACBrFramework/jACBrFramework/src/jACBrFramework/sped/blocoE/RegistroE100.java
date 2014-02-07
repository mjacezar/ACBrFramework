package jACBrFramework.sped.blocoE;

import java.util.Date;

/**
 * Periodo da apuracao do ICMS.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 11:10:14, revisao: $Id$
 */
public class RegistroE100 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Apuracao do ICMS - operacoes proprias.
     */
    private RegistroE110 registroE110 = new RegistroE110();
    /**
     * Data inicial a que a apuracao se refere.
     */
    private Date DT_INI;
    /**
     * Data final a que a apuracao se refere.
     */
    private Date DT_FIN;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Apuracao do ICMS - operacoes proprias.
     * @return the registroE110
     */
    public RegistroE110 getRegistroE110() {
        return registroE110;
    }

    /**
     * Data inicial a que a apuracao se refere.
     * @return the DT_INI
     */
    public Date getDT_INI() {
        return DT_INI;
    }

    /**
     * Data inicial a que a apuracao se refere.
     * @param DT_INI the DT_INI to set
     */
    public void setDT_INI(Date DT_INI) {
        this.DT_INI = DT_INI;
    }

    /**
     * Data final a que a apuracao se refere.
     * @return the DT_FIN
     */
    public Date getDT_FIN() {
        return DT_FIN;
    }

    /**
     * Data final a que a apuracao se refere.
     * @param DT_FIN the DT_FIN to set
     */
    public void setDT_FIN(Date DT_FIN) {
        this.DT_FIN = DT_FIN;
    }
    // </editor-fold>    
    
}