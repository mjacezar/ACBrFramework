package jACBrFramework.paf;

/**
 * Tipo de desenvolvimento.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 11:43:54, revisao: $Id$
 */
public enum TipoDesenvolvimento {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    COMERCIAL("Comercial", 0),
    EXCLUSIVO_PROPRIO("Exclusivo Próprio", 1),
    EXCLUSIVO_TERCEIRIZADO("Exclusivo Terceirizado", 2);
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de desenvolvimento.
     */
    private String descricao;
    /**
     * Codigo do tipo de desenvolvimento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoDesenvolvimento(String pDescricao, int pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de desenvolvimento.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de desenvolvimento.
     * 
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static TipoDesenvolvimento valueOf(int pCodigo) {
        for (TipoDesenvolvimento lTipoDesenvolvimento : values()) {
            if (lTipoDesenvolvimento.getCodigo() == pCodigo) return lTipoDesenvolvimento;
        }
        return null;
    }      
    // </editor-fold>      

}