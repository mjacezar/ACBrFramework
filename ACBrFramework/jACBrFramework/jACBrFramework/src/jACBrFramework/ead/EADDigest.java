package jACBrFramework.ead;

/**
 * Algoritmos de criptografia suportados pelo ACBr.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 08:21:10, revisao: $Id$
 */
public enum EADDigest {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    MD2("MD2", 0),
    MD4("MD4.", 1),
    MD5("MD5", 2),
    RMD160("RMD160", 3),
    SHA("SHA", 4),
    SHA1("SHA1", 5);
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do algoritmo de criptografia.
     */
    private String descricao;
    /**
     * Codigo do algoritmo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    EADDigest(String pDescricao, int pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do algoritmo de criptografia.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do algoritmo.
     * 
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>

}