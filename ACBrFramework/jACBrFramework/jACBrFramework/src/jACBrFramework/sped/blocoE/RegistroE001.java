package jACBrFramework.sped.blocoE;

import jACBrFramework.sped.IndicadorMovimento;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Abertura do bloco E.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 11:09:59, revisao: $Id$
 */
public class RegistroE001 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Periodo da apuracao do ICMS.
     */
    private Collection<RegistroE100> registroE100 = new ArrayList<RegistroE100>(); 
    /**
     * Periodo da apuracao do ICMS - Substituicao Tributaria.
     */
    private Collection<RegistroE200> registroE200 = new ArrayList<RegistroE200>(); 
    /**
     * Periodo de apuracao do IPI.
     */
    private Collection<RegistroE500> registroE500 = new ArrayList<RegistroE500>();     
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Periodo da apuracao do ICMS.
     * @return the registroE100
     */
    public Collection<RegistroE100> getRegistroE100() {
        return registroE100;
    }

    /**
     * Periodo da apuracao do ICMS - Substituicao Tributaria.
     * @return the registroE200
     */
    public Collection<RegistroE200> getRegistroE200() {
        return registroE200;
    }

    /**
     * Periodo de apuracao do IPI.
     * @return the registroE500
     */
    public Collection<RegistroE500> getRegistroE500() {
        return registroE500;
    }

    /**
     * Indicador de movimento.
     * @return the IND_MOV
     */
    public IndicadorMovimento getIND_MOV() {
        return IND_MOV;
    }

    /**
     * Indicador de movimento.
     * @param IND_MOV the IND_MOV to set
     */
    public void setIND_MOV(IndicadorMovimento IND_MOV) {
        this.IND_MOV = IND_MOV;
    }
    // </editor-fold>    
    
}