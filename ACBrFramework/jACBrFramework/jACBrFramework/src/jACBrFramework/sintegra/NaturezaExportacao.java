package jACBrFramework.sintegra;

/**
 * Natureza da exportacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 18:16:25, revisao: $Id$
 */
public enum NaturezaExportacao {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    DIRETA("Exportação direta", "1"),
    INDIRETA("Exportação indireta", "2"),
    DIRETA_SIMPLICADO("Exportação Direta- Regime Simplificado", "3"),
    INDIRETA_SIMPLICADO(" Exportação Indireta- Regime Simplificado", "4");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da natureza da exportacao.
     */
    private String descricao;
    /**
     * Codigo associado a natureza da exportacao.
     */
    private String codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    NaturezaExportacao(String pDescricao, String pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da natureza da exportacao.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo associado a natureza da exportacao.
     * 
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }
    // </editor-fold>    
}