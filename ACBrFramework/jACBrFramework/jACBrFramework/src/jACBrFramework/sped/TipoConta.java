package jACBrFramework.sped;

/**
 * Indicador do tipo de conta.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:52:17, revisao: $Id$
 */
public enum TipoConta {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Sintetica("S", "Sintética (grupo de contas)"),
    Analitica("A", "Analítica (conta)");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de conta.
     */
    private String descricao;
    /**
     * Codigo do tipo de conta.
     */
    private String codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoConta(String pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de conta.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de conta.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }
    // </editor-fold>  

}