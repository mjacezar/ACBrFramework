package jACBrFramework.aac;

import java.util.EventObject;

/**
 * Evento acionado antes de abrir/gravar o arquivo.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 16:28:56, revisao: $Id$
 */
public class AACAntesArquivoEventObject extends EventObject {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Continua.
     */
    private boolean continua;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AACAntesArquivoEventObject(Object pSource, boolean pContinua) {
        super(pSource);
        this.continua = pContinua;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Continua.
     * @return the continua
     */
    public boolean isContinua() {
        return continua;
    }

    /**
     * Continua.
     * @param continua the continua to set
     */
    public void setContinua(boolean continua) {
        this.continua = continua;
    }
    // </editor-fold>    
    
}