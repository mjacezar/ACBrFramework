package jACBrFramework.sintegra;

/**
 * Versao do validador do sintegra.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/11/2013 10:37:54, revisao: $Id$
 */
public enum VersaoValidador {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    V523(0),
    V524(1);
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Identificador da versao.
     */
    private int id;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    VersaoValidador(int pId) {
        id = pId;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Identificador da versao.
     * 
     * @return the id
     */
    public int getId() {
        return id;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static VersaoValidador valueOf(int pCodigo) {
        for (VersaoValidador lVersaoValidador : values()) {
            if (lVersaoValidador.getId() == pCodigo) return lVersaoValidador;
        }
        return null;
    }      
    // </editor-fold>
}