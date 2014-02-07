package jACBrFramework.sped.blocoE;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Periodo da apuracao do ICMS - Substituicao Tributaria.
 *  
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:21:35, revisao: $Id$
 */
public class RegistroE200 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Apuracao do ICMS - Substituicao Tributaria.
     */
    private Collection<RegistroE210> registroE210 = new ArrayList<RegistroE210>();     
    /**
     * Sigla da unidade da federacao a que se refere a apuracao do ICMS ST.
     */
    private String UF;
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
     * Apuracao do ICMS - Substituicao Tributaria.
     * @return the registroE210
     */
    public Collection<RegistroE210> getRegistroE210() {
        return registroE210;
    }

    /**
     * Sigla da unidade da federacao a que se refere a apuracao do ICMS ST.
     * @return the UF
     */
    public String getUF() {
        return UF;
    }

    /**
     * Sigla da unidade da federacao a que se refere a apuracao do ICMS ST.
     * @param UF the UF to set
     */
    public void setUF(String UF) {
        this.UF = UF;
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