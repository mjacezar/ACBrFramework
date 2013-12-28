package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:39:05, revisao: $Id$
 */
public final class ACBrPAF_H {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro H1.
     */
    private ACBrPAFRegistroH1 registroH1 = new ACBrPAFRegistroH1();
    /**
     * Registro H2.
     */
    private Collection<ACBrPAFRegistroH2> registrosH2 = new ArrayList<ACBrPAFRegistroH2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroH1 = new ACBrPAFRegistroH1();			
        registrosH2.clear();
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro H1.
     * @return the registroH1
     */
    public ACBrPAFRegistroH1 getRegistroH1() {
        return registroH1;
    }

    /**
     * Registro H2.
     * @return the registrosH2
     */
    public Collection<ACBrPAFRegistroH2> getRegistrosH2() {
        return registrosH2;
    }
    // </editor-fold>

}