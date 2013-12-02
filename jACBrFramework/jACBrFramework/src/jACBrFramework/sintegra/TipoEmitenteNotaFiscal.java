package jACBrFramework.sintegra;

/**
 * Tipo associado ao emitente da nota fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 15:16:57, revisao: $Id$
 */
public enum TipoEmitenteNotaFiscal {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    PROPRIO("Próprio", "P"),
    TERCEIROS("Terceiros", "T");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao associada ao emitente.
     */
    private String descricao;
    /**
     * Tipo associado ao emitente.
     */
    private String tipo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoEmitenteNotaFiscal(String pDescricao, String pTipo) {
        descricao = pDescricao;
        tipo = pTipo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao associada ao emitente.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Tipo associado ao emitente.
     * 
     * @return the tipo
     */
    public String getTipo() {
        return tipo;
    }
    // </editor-fold>
}