package jACBrFramework.paf;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 09:23:02, revisao: $Id$
 */
public final class ACBrPAF_U {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro U1.
     */
    private ACBrPAFRegistroU1 registroU1 = new ACBrPAFRegistroU1();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroU1 = new ACBrPAFRegistroU1();			
    } 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro U1.
     * @return the registroU1
     */
    public ACBrPAFRegistroU1 getRegistroU1() {
        return registroU1;
    }
    // </editor-fold>    
}