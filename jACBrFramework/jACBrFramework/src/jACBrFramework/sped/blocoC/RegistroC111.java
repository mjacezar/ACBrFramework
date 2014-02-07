package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.OrigemProcesso;

/**
 * Processo referenciado.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:38:44, revisao: $Id$
 */
public class RegistroC111 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Identificacao do processo ou ato concessorio.
     */
    private String NUM_PROC;
    /**
     * Indicador da origem do processo.
     */
    private OrigemProcesso IND_PROC;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Identificacao do processo ou ato concessorio.
     * @return the NUM_PROC
     */
    public String getNUM_PROC() {
        return NUM_PROC;
    }

    /**
     * Identificacao do processo ou ato concessorio.
     * @param NUM_PROC the NUM_PROC to set
     */
    public void setNUM_PROC(String NUM_PROC) {
        this.NUM_PROC = NUM_PROC;
    }

    /**
     * Indicador da origem do processo.
     * @return the IND_PROC
     */
    public OrigemProcesso getIND_PROC() {
        return IND_PROC;
    }

    /**
     * Indicador da origem do processo.
     * @param IND_PROC the IND_PROC to set
     */
    public void setIND_PROC(OrigemProcesso IND_PROC) {
        this.IND_PROC = IND_PROC;
    }
    // </editor-fold>
    
}