package jACBrFramework.sped;

/**
 * Tipo de exportacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 15:13:46, revisao: $Id$
 */
public enum Exportacao {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Direta(0, "0 - Exportação Direta"),
    Indireta(1, "1 - Exportação Indireta");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de exportacao.
     */
    private String descricao;
    /**
     * Codigo do tipo de exportacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    Exportacao(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de exportacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de exportacao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   

}