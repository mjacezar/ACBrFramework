package jACBrFramework.sped;

import java.util.EventObject;

/**
 * Evento de erro.
 * 
 * @author Jose Mauro
 * @version Criado em: 03/02/2014 11:20:48, revisao: $Id$
 */
public class OnErrorEventObject extends EventObject {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Mensagem de erro.
     */
    private String mensagem;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public OnErrorEventObject(Object pSource, String pMensagem) {
        super(pSource);
        this.mensagem = pMensagem;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Mensagem de erro.
     * @return the mensagem
     */
    public String getMensagem() {
        return mensagem;
    }

    /**
     * Mensagem de erro.
     * @param mensagem the mensagem to set
     */
    public void setMensagem(String mensagem) {
        this.mensagem = mensagem;
    }
    // </editor-fold>

}