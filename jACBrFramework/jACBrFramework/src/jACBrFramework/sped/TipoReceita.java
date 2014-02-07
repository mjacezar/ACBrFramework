package jACBrFramework.sped;

/**
 * Indicador do tipo de receita.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 08:24:24, revisao: $Id$
 */
public enum TipoReceita {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Propria(0, "0 - Receita própria"),
    Componente(1, "1 - Receita de terceiros");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de receita.
     */
    private String descricao;
    /**
     * Codigo do tipo de receita.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoReceita(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de receita.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de receita.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
}