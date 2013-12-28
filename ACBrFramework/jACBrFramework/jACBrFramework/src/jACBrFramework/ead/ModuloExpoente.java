package jACBrFramework.ead;

/**
 * Controle de expoente e modelo do EAD.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 08:57:35, revisao: $Id$
 */
public class ModuloExpoente {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Expoente.
     */
    private String expoente;
    /**
     * Modulo
     */
    private String modulo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">
    ModuloExpoente(String pExpoente, String pModulo) {
        this.expoente = pExpoente;
        this.modulo = pModulo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Expoente.
     * @return the expoente
     */
    public String getExpoente() {
        return expoente;
    }

    /**
     * Modulo
     * @return the modulo
     */
    public String getModulo() {
        return modulo;
    }
    // </editor-fold>    
    
}