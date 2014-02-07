package jACBrFramework.sped.bloco1;

import java.util.Date;

/**
 * Lacres da bomba.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 17:18:51, revisao: $Id$
 */
public class Registro1360 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero do Lacre associado na Bomba.
     */
    private String NUM_LACRE;
    /**
     * Data de aplicacao do Lacre.
     */
    private Date DT_APLICACAO;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Numero do Lacre associado na Bomba.
     * @return the NUM_LACRE
     */
    public String getNUM_LACRE() {
        return NUM_LACRE;
    }

    /**
     * Numero do Lacre associado na Bomba.
     * @param NUM_LACRE the NUM_LACRE to set
     */
    public void setNUM_LACRE(String NUM_LACRE) {
        this.NUM_LACRE = NUM_LACRE;
    }

    /**
     * Data de aplicacao do Lacre.
     * @return the DT_APLICACAO
     */
    public Date getDT_APLICACAO() {
        return DT_APLICACAO;
    }

    /**
     * Data de aplicacao do Lacre.
     * @param DT_APLICACAO the DT_APLICACAO to set
     */
    public void setDT_APLICACAO(Date DT_APLICACAO) {
        this.DT_APLICACAO = DT_APLICACAO;
    }
    // </editor-fold>
    
}