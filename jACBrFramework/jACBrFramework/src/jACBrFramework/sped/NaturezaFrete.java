package jACBrFramework.sped;

/**
 * Natureza do frete.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:55:07, revisao: $Id$
 */
public enum NaturezaFrete {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Negociavel(0, "0 - Negociavel"),
    NaoNegociavel(1, "1 - Não Negociavel");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da natureza do frete.
     */
    private String descricao;
    /**
     * Codigo da natureza do frete.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    NaturezaFrete(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da natureza do frete.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da natureza do frete.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>  
    
}