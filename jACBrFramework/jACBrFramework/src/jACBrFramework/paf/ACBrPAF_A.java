package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 14:41:09, revisao: $Id$
 */
public final class ACBrPAF_A {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro A1.
     */
    private ACBrPAFRegistroA1 registroA1 = new ACBrPAFRegistroA1();
    /**
     * Registro A2.
     */
    private Collection<ACBrPAFRegistroA2> registrosA2 = new ArrayList<ACBrPAFRegistroA2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroA1 = new ACBrPAFRegistroA1();			
        registrosA2.clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro A1.
     * @return the registroA1
     */
    public ACBrPAFRegistroA1 getRegistroA1() {
        return registroA1;
    }

    /**
     * Registro A2.
     * @return the registrosA2
     */
    public Collection<ACBrPAFRegistroA2> getRegistrosA2() {
        return registrosA2;
    }
    // </editor-fold>
    
}