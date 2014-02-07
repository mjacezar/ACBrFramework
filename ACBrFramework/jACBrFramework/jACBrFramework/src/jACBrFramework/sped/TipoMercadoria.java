package jACBrFramework.sped;

/**
 * Tipo de Mercadoria.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:15:37, revisao: $Id$
 */
public enum TipoMercadoria {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Bem(1, "Bem"),
    Componente(2, "Componente");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de mercadoria.
     */
    private String descricao;
    /**
     * Codigo do tipo de mercadoria.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoMercadoria(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de mercadoria.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de mercadoria.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>     
}