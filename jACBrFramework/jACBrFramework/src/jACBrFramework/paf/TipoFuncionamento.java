package jACBrFramework.paf;

/**
 * Tipo de Funcionamento.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 11:19:46, revisao: $Id$
 */
public enum TipoFuncionamento {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    STANDALONE("StandAlone", 0),
    EM_REDE("Em Rede", 1),
    PARAMETRIZAVEL("Parametrizável", 2);
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de funcionamento.
     */
    private String descricao;
    /**
     * Codigo do tipo de funcionamento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoFuncionamento(String pDescricao, int pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de funcionamento.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de funcionamento.
     * 
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      

}