package jACBrFramework.sped.blocoE;

import jACBrFramework.sped.ApuracaoIPI;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Periodo de apuracao do IPI.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:52:14, revisao: $Id$
 */
public class RegistroE500 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Consolidacao dos valores do IPI.
     */
    private Collection<RegistroE510> registroE510 = new ArrayList<RegistroE510>(); 
    /**
     * IND_APUR do IPI.
     */
    private Collection<RegistroE520> registroE520 = new ArrayList<RegistroE520>();     
    /**
     * Indicador de periodo de apuracao do IPI.
     */
    private ApuracaoIPI IND_APUR;
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
     * Consolidacao dos valores do IPI.
     * @return the registroE510
     */
    public Collection<RegistroE510> getRegistroE510() {
        return registroE510;
    }

    /**
     * IND_APUR do IPI.
     * @return the registroE520
     */
    public Collection<RegistroE520> getRegistroE520() {
        return registroE520;
    }

    /**
     * Indicador de periodo de apuracao do IPI.
     * @return the IND_APUR
     */
    public ApuracaoIPI getIND_APUR() {
        return IND_APUR;
    }

    /**
     * Indicador de periodo de apuracao do IPI.
     * @param IND_APUR the IND_APUR to set
     */
    public void setIND_APUR(ApuracaoIPI IND_APUR) {
        this.IND_APUR = IND_APUR;
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