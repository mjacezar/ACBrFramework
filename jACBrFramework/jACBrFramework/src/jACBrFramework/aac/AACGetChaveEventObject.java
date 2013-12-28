package jACBrFramework.aac;

import java.util.EventObject;

/**
 * Evento para obtencao da chave de criptografia.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 16:44:22, revisao: $Id$
 */
public class AACGetChaveEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Chave.
     */
    private String key;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AACGetChaveEventObject(Object pSource, String pKey) {
        super(pSource);
        this.key = pKey;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * @return the key
     */
    public String getKey() {
        return key;
    }

    /**
     * @param key the key to set
     */
    public void setKey(String key) {
        this.key = key;
    }
    // </editor-fold>

}