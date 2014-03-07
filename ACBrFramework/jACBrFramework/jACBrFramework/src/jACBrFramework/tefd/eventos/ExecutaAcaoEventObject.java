package jACBrFramework.tefd.eventos;

import java.util.EventObject;

/**
 * Evento acionado ao executar a acao.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:22:14, revisao: $Id$
 */
public class ExecutaAcaoEventObject extends EventObject {    
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 5741765199715932239L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tratado.
     */
    private int tratado;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ExecutaAcaoEventObject(Object pSource, int pTratado) {
        super(pSource);
        this.tratado = pTratado;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Tratado.
     * @return the tratado
     */
    public int getTratado() {
        return tratado;
    }

    /**
     * Tratado.
     * @param tratado the tratado to set
     */
    public void setTratado(int tratado) {
        this.tratado = tratado;
    }
    // </editor-fold>    

}