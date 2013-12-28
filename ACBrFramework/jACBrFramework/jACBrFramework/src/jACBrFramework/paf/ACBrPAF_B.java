package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:20:41, revisao: $Id$
 */
public final class ACBrPAF_B {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro B1.
     */
    private ACBrPAFRegistroB1 registroB1 = new ACBrPAFRegistroB1();
    /**
     * Registro B2.
     */
    private Collection<ACBrPAFRegistroB2> registrosB2 = new ArrayList<ACBrPAFRegistroB2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroB1 = new ACBrPAFRegistroB1();			
        getRegistrosB2().clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro B1.
     * @return the registroB1
     */
    public ACBrPAFRegistroB1 getRegistroB1() {
        return registroB1;
    }

    /**
     * Registro B2.
     * @return the registrosB2
     */
    public Collection<ACBrPAFRegistroB2> getRegistrosB2() {
        return registrosB2;
    }
    // </editor-fold>

}