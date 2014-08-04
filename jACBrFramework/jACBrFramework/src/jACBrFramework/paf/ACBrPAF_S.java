package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Registro de controle de mesas e itens.
 * @author Jose Mauro
 * @version Criado em: 04/08/2014 17:58:20, revisao: $Id$
 */
public final class ACBrPAF_S {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro S2.
     */
    private Collection<ACBrPAFRegistroS2> registrosS2 = new ArrayList<ACBrPAFRegistroS2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registrosS2.clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro S2.
     * @return the registrosS2
     */
    public Collection<ACBrPAFRegistroS2> getRegistrosS2() {
        return registrosS2;
    }
    // </editor-fold>   

}