package jACBrFramework.ead;

import java.util.EventObject;

/**
 * Evento para recuperar a chave privada.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 10:01:23, revisao: $Id$
 */
public class EADChavePrivadaEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Chave.
     */
    private String key;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public EADChavePrivadaEventObject(Object pSource, String pKey) {
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