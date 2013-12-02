package jACBrFramework.sintegra;

/**
 * Tipo de operacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 16:26:15, revisao: $Id$
 */
public enum TipoOperacao {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    VENDA_CONCESSIONARIA("Venda para concessionária", "1"),
    FATURAMENTO_DIRETO("Faturamento Direto – Convênio ICMS 51/00", "2"),
    VENDA_DIRETA("Venda direta", "3"),
    OUTRAS("Outras", "4");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de operacao.
     */
    private String descricao;
    /**
     * Codigo associado ao tipo de operacao.
     */
    private String codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoOperacao(String pDescricao, String pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de operacao.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo associado ao tipo de operacao.
     * 
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }
    // </editor-fold>    
}