package jACBrFramework.sped.blocoG;

import jACBrFramework.sped.IndicadorMovimento;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Abertura do bloco G.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:53:39, revisao: $Id$
 */
public class RegistroG001 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * ICMS - Ativo Permanente - CIAP.
     */
    private Collection<RegistroG110> registroG110 = new ArrayList<RegistroG110>();     
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV;       
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * ICMS - Ativo Permanente - CIAP.
     * @return the registroG110
     */
    public Collection<RegistroG110> getRegistroG110() {
        return registroG110;
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