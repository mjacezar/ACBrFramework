package jACBrFramework.tefd;

/**
 * Tipo de Relatorio.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 16:12:55, revisao: $Id$
 */
public enum TipoRelatorio {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Gerencial(0, "0 - Gerencial"),
    Vinculado(1, "1 - Vinculado");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de relatorio.
     */
    private String descricao;
    /**
     * Codigo do tipo de relatorio.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoRelatorio(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de relatorio.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de relatorio.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static TipoRelatorio valueOf(int pCodigo) {
        for (TipoRelatorio lTipoRelatorio : values()) {
            if (lTipoRelatorio.getCodigo() == pCodigo) return lTipoRelatorio;
        }
        return null;
    }       
    // </editor-fold>    

}