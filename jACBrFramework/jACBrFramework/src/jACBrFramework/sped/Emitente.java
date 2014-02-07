package jACBrFramework.sped;

/**
 * Tipo de emitente do documento fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:59:48, revisao: $Id$
 */
public enum Emitente {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    EmissaoPropria(0, "0 - Emissão própria"),
    Terceiros(1, "1 - Terceiro");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de emitente.
     */
    private String descricao;
    /**
     * Codigo do tipo de emitente.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    Emitente(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de emitente.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de emitente.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   
}