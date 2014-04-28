package jACBrFramework.sped.bloco9;

import jACBrFramework.sped.IndicadorMovimento;

/**
 * Abertura do bloco 9.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:15:45, revisao: $Id$
 */
public class Registro9001 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">     
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV = IndicadorMovimento.ComDados;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters"> 
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