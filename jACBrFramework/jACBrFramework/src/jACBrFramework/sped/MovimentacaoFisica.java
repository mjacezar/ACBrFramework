package jACBrFramework.sped;

/**
 * Indica movimentacao fisica (item / produto).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 16:33:23, revisao: $Id$
 */
public enum MovimentacaoFisica {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Sim(0, "0 - Sim"),
    Nao(1, "1 - Não");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da indicacao de movimentacao fisica
     */
    private String descricao;
    /**
     * Codigo da indicacao de movimentacao fisica
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    MovimentacaoFisica(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da indicacao de movimentacao fisica
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da indicacao de movimentacao fisica
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}