package jACBrFramework.sped;

/**
 * Indicador do movimento.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 11:07:06, revisao: $Id$
 */
public enum IndicadorMovimento {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    ComDados(0, "0 - Bloco com dados informados"),
    SemDados(1, "1 - Bloco sem dados informados");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do indicador de movimento.
     */
    private String descricao;
    /**
     * Codigo do indicador de movimento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    IndicadorMovimento(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do indicador de movimento.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do indicador de movimento.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold> 
    
}