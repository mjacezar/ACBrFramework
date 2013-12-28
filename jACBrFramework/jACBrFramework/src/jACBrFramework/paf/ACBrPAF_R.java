package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 08:52:20, revisao: $Id$
 */
public final class ACBrPAF_R {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro R1.
     */
    private Collection<ACBrPAFRegistroR1> registrosR1 = new ArrayList<ACBrPAFRegistroR1>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registrosR1.clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro R1.
     * @return the registrosR1
     */
    public Collection<ACBrPAFRegistroR1> getRegistrosR1() {
        return registrosR1;
    }
    // </editor-fold>    

}