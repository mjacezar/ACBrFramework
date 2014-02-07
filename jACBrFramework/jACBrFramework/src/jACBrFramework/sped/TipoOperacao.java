package jACBrFramework.sped;

/**
 * Tipo de operacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:58:26, revisao: $Id$
 */
public enum TipoOperacao {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    EntradaAquisicao(0, "0 - Entrada"),
    SaidaPrestacao(1, "1 - Saída");
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
    TipoOperacao(int pCodigo, String pDescricao) {
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