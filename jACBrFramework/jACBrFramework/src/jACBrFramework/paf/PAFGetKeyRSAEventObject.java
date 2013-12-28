package jACBrFramework.paf;

import java.util.EventObject;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 21:13:09, revisao: $Id$
 */
public class PAFGetKeyRSAEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Chave.
     */
    private String key;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public PAFGetKeyRSAEventObject(Object pSource, String pKey) {
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