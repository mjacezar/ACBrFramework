package jACBrFramework.sped;

/**
 * Tipo de movimento de ST.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:40:46, revisao: $Id$
 */
public enum MovimentoST {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    SemOperacaoST(0, "0 - Sem operações com ST"),
    ComOperacaoST(1, "1 - Com operações de ST");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de movimento de ST.
     */
    private String descricao;
    /**
     * Codigo do tipo de movimento de ST.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    MovimentoST(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de movimento de ST.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de movimento de ST.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}