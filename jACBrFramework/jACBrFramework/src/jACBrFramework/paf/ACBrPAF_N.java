package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:47:30, revisao: $Id$
 */
public final class ACBrPAF_N {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro N1.
     */
    private ACBrPAFRegistroN1 registroN1 = new ACBrPAFRegistroN1();
    /**
     * Registro N2.
     */
    private ACBrPAFRegistroN2 registroN2 = new ACBrPAFRegistroN2();    
    /**
     * Registro N3.
     */
    private Collection<ACBrPAFRegistroN3> registrosN3 = new ArrayList<ACBrPAFRegistroN3>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroN1 = new ACBrPAFRegistroN1();
        registroN2 = new ACBrPAFRegistroN2();    
        getRegistrosN3().clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro N1.
     * @return the registroN1
     */
    public ACBrPAFRegistroN1 getRegistroN1() {
        return registroN1;
    }

    /**
     * Registro N3.
     * @return the registrosN3
     */
    public Collection<ACBrPAFRegistroN3> getRegistrosN3() {
        return registrosN3;
    }

    /**
     * Registro N2.
     * @return the registroN2
     */
    public ACBrPAFRegistroN2 getRegistroN2() {
        return registroN2;
    }
    // </editor-fold>  
    
}