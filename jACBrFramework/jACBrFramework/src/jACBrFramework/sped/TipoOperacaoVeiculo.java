package jACBrFramework.sped;

/**
 * Tipo de operacao com veiculo.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:35:33, revisao: $Id$
 */
public enum TipoOperacaoVeiculo {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    VendaPConcess(0, "0 - Venda para concessionária"),
    FaturaDireta(1, "1 - Faturamento direto"),
    VendaDireta(2, "2 - Venda direta"),
    VendaDConcess(3, "3 - Venda da concessionária"),
    VendaOutros(9, "9 - Outros");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de operacao com veiculo.
     */
    private String descricao;
    /**
     * Codigo do tipo de operacao com veiculo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoOperacaoVeiculo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de operacao com veiculo.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de operacao com veiculo.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}