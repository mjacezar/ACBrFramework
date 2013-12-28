package jACBrFramework.ead;

/**
 * Representa as chaves obtidas na geracao das chaves EAD.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 08:49:00, revisao: $Id$
 */
public class Chaves {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Chave publica.
     */
    private String chavePublica;
    /**
     * Chave privada.
     */
    private String chavePrivada;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">
    Chaves(String pChavePublica, String pChavePrivada) {
        this.chavePublica = pChavePublica;
        this.chavePrivada = pChavePrivada;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Chave publica.
     * @return the chavePublica
     */
    public String getChavePublica() {
        return chavePublica;
    }

    /**
     * Chave privada.
     * @return the chavePrivada
     */
    public String getChavePrivada() {
        return chavePrivada;
    }
    // </editor-fold>
    
}