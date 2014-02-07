package jACBrFramework.sped;

/**
 * Tipo de Atividade.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 08:37:47, revisao: $Id$
 */
public enum TipoAtividade {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Industrial(0, "Industrial ou equiparado a industrial"),
    Outros(1, "Outros");
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de atividade.
     */
    private String descricao;
    /**
     * Codigo do tipo de atividade.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoAtividade(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de atividade.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de atividade.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   

}