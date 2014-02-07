package jACBrFramework.sped;

/** 
 * Tipo de pagamento.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:12:53, revisao: $Id$
 */
public enum TipoPagamento {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Vista(0, "0 - À Vista"),
    Prazo(1, "1 - A Prazo"),
    Outros(2, "2 - Outros"),
    SemPagamento(9, "9 - Sem pagamento"),
    Nenhum(-1, "Preencher vazio");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de pagamento.
     */
    private String descricao;
    /**
     * Codigo do tipo de pagamento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoPagamento(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de pagamento.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de pagamento.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
}