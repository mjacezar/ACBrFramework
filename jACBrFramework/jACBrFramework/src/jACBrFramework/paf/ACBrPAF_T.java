package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 09:06:56, revisao: $Id$
 */
public final class ACBrPAF_T {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro T1.
     */
    private ACBrPAFRegistroT1 registroT1 = new ACBrPAFRegistroT1();
    /**
     * Registro T2.
     */
    private Collection<ACBrPAFRegistroT2> registrosT2 = new ArrayList<ACBrPAFRegistroT2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroT1 = new ACBrPAFRegistroT1();			
        registrosT2.clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro T1.
     * @return the registroT1
     */
    public ACBrPAFRegistroT1 getRegistroT1() {
        return registroT1;
    }

    /**
     * Registro T2.
     * @return the registrosT2
     */
    public Collection<ACBrPAFRegistroT2> getRegistrosT2() {
        return registrosT2;
    }
    // </editor-fold>        

}