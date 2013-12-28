package jACBrFramework.ead;

import java.util.EventObject;

/**
 * Evento para recuperar a chave public.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 10:03:16, revisao: $Id$
 */
public class EADChavePublicaEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Chave.
     */
    private String key;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public EADChavePublicaEventObject(Object pSource, String pKey) {
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