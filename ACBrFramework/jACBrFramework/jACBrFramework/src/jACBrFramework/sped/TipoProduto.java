package jACBrFramework.sped;

/**
 * Tipo de produto.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:25:06, revisao: $Id$
 */
public enum TipoProduto {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Similar(0, "0 - Similar"),
    Generico(1, "1 - Genérico"),
    Marca(2, "2 - Ético ou de Marca");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de produto.
     */
    private String descricao;
    /**
     * Codigo do tipo de produto.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoProduto(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de produto.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de produto.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}