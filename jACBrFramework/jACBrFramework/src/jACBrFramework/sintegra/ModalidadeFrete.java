package jACBrFramework.sintegra;

/**
 * Modalidade de cobranca do frete.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 17:38:11, revisao: $Id$
 */
public enum ModalidadeFrete {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    OUTROS("Outros", "0"),
    CIF("CIF", "1"),
    FOB("FOB", "2");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da modalidade do frete.
     */
    private String descricao;
    /**
     * Codigo da modalidade do frete.
     */
    private String codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    ModalidadeFrete(String pDescricao, String pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da modalidade do frete.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da modalidade do frete.
     * 
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }
    // </editor-fold>

}