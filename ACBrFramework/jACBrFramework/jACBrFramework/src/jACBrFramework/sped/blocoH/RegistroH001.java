package jACBrFramework.sped.blocoH;

import jACBrFramework.sped.IndicadorMovimento;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Abertura do bloco H.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:32:51, revisao: $Id$
 */
public class RegistroH001 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Inventario.
     */
    private Collection<RegistroH005> registroH005 = new ArrayList<RegistroH005>();     
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV;     
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Inventario.
     * @return the registroH005
     */
    public Collection<RegistroH005> getRegistroH005() {
        return registroH005;
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