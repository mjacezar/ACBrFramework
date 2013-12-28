package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:29:41, revisao: $Id$
 */
public final class ACBrPAF_E {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro E1.
     */
    private ACBrPAFRegistroE1 registroE1 = new ACBrPAFRegistroE1();
    /**
     * Registro E2.
     */
    private Collection<ACBrPAFRegistroE2> registrosE2 = new ArrayList<ACBrPAFRegistroE2>();
    /**
     * Registro E3.
     */
    private ACBrPAFRegistroE3 registroE3 = new ACBrPAFRegistroE3();    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroE1 = new ACBrPAFRegistroE1();
        registroE3 = new ACBrPAFRegistroE3();    
        getRegistrosE2().clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro E1.
     * @return the registroE1
     */
    public ACBrPAFRegistroE1 getRegistroE1() {
        return registroE1;
    }

    /**
     * Registro E2.
     * @return the registrosE2
     */
    public Collection<ACBrPAFRegistroE2> getRegistrosE2() {
        return registrosE2;
    }

    /**
     * Registro E3.
     * @return the registroE3
     */
    public ACBrPAFRegistroE3 getRegistroE3() {
        return registroE3;
    }
    // </editor-fold>  
    
}