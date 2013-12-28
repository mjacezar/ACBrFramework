package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:56:15, revisao: $Id$
 */
public final class ACBrPAF_P {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro P1.
     */
    private ACBrPAFRegistroP1 registroP1 = new ACBrPAFRegistroP1();
    /**
     * Registro P2.
     */
    private Collection<ACBrPAFRegistroP2> registrosP2 = new ArrayList<ACBrPAFRegistroP2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroP1 = new ACBrPAFRegistroP1();			
        registrosP2.clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro P1.
     * @return the registroP1
     */
    public ACBrPAFRegistroP1 getRegistroP1() {
        return registroP1;
    }

    /**
     * Registro P2.
     * @return the registrosP2
     */
    public Collection<ACBrPAFRegistroP2> getRegistrosP2() {
        return registrosP2;
    }
    // </editor-fold>    
}