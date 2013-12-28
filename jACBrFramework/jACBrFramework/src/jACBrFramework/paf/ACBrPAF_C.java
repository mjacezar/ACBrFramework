package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:35:38, revisao: $Id$
 */
public final class ACBrPAF_C {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro C1.
     */
    private ACBrPAFRegistroC1 registroC1 = new ACBrPAFRegistroC1();
    /**
     * Registro C2.
     */
    private Collection<ACBrPAFRegistroC2> registrosC2 = new ArrayList<ACBrPAFRegistroC2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroC1 = new ACBrPAFRegistroC1();			
        getRegistrosC2().clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro C1.
     * @return the registroC1
     */
    public ACBrPAFRegistroC1 getRegistroC1() {
        return registroC1;
    }

    /**
     * Registro C2.
     * @return the registrosC2
     */
    public Collection<ACBrPAFRegistroC2> getRegistrosC2() {
        return registrosC2;
    }
    // </editor-fold>    

}