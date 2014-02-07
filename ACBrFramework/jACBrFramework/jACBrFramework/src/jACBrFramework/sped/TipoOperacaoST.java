package jACBrFramework.sped;

/**
 * Tipo de operacao de substitucao tributaria.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:34:16, revisao: $Id$
 */
public enum TipoOperacaoST {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    CombustiveisLubrificantes(0, "0 - Combustíveis e Lubrificantes"),
    LeasingVeiculos(1, "1 - leasing de veículos ou faturamento direto");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de operacao.
     */
    private String descricao;
    /**
     * Codigo do tipo de operacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoOperacaoST(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de operacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de operacao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}