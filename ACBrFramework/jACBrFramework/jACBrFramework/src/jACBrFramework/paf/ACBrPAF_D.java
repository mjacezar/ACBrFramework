package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:20:02, revisao: $Id$
 */
public final class ACBrPAF_D {

    // <editor-fold defaultstate="collapsed" desc="Enums">
    /**
     * Tipo de registro que sofrera contagem.
     */
    private enum TipoRegistro { D3, D4 }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tipo de registro que sofrera contagem.
     */
    /**
     * Registro D1.
     */
    private ACBrPAFRegistroD1 registroD1 = new ACBrPAFRegistroD1();
    /**
     * Registro D2.
     */
    private Collection<ACBrPAFRegistroD2> registrosD2 = new ArrayList<ACBrPAFRegistroD2>();
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        registroD1 = new ACBrPAFRegistroD1();			
        getRegistrosD2().clear();
    } 
    
    /**
     * Totaliza o numero de registros D3.
     * @return 
     */
    public int countD3() {
        return countElements(TipoRegistro.D3);
    }

    /**
     * Totaliza o numero de registros D4.
     * @return 
     */
    public int countD4() {
        return countElements(TipoRegistro.D4);
    }
    
    /**
     * Contabiliza os registros para formacao recebido.
     * 
     * @param pTipo tipo do registro a ser contabilizado.
     * @return numero de registros.
     */
    private int countElements(TipoRegistro pTipo) {
        int lCount = 0;
        
        for (ACBrPAFRegistroD2 lRegistroD2 : getRegistrosD2()) {
            switch (pTipo) {
                case D3: lCount += lRegistroD2.getRegistrosD3().size(); break;
                case D4: lCount += lRegistroD2.getRegistrosD4().size(); break;
            }
        }
        return lCount;
    }    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro D1.
     * @return the registroD1
     */
    public ACBrPAFRegistroD1 getRegistroD1() {
        return registroD1;
    }

    /**
     * Registro D2.
     * @return the registrosD2
     */
    public Collection<ACBrPAFRegistroD2> getRegistrosD2() {
        return registrosD2;
    }
    // </editor-fold>     
}