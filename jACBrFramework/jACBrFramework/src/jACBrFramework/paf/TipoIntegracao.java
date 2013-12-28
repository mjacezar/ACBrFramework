package jACBrFramework.paf;

/**
 * Tipo de integracao.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 11:34:01, revisao: $Id$
 */
public enum TipoIntegracao {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    RETAGUARDA("Retaguarda", 0),
    PED("Processamento Eletrônico de Dados", 1),
    AMBOS("Ambos", 2),
    NAO_INTEGRA("Não Integra", 3);
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de integracao.
     */
    private String descricao;
    /**
     * Codigo do tipo de integracao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoIntegracao(String pDescricao, int pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de integracao.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de integracao.
     * 
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>        
}