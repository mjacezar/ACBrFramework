package jACBrFramework.sped;

/**
 * Tipo da arma de fogo.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:30:45, revisao: $Id$
 */
public enum TipoArmaFogo {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Permitido(0, "0 - Permitido"),
    Restrito(1, "1 - Restrito");
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo da arma de fogo.
     */
    private String descricao;
    /**
     * Codigo do tipo da arma de fogo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoArmaFogo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo da arma de fogo.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo da arma de fogo.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   
    
}