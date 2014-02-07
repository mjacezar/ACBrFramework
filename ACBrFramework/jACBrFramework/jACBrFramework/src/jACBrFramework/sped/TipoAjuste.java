package jACBrFramework.sped;

/**
 * Tipo de ajuste.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:16:10, revisao: $Id$
 */
public enum TipoAjuste {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Debito(0, "0 - Ajuste a débito"),
    Credito(1, "1 - Ajuste a crédito");
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de assinante.
     */
    private String descricao;
    /**
     * Codigo do tipo de assinante.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoAjuste(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de assinante.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de assinante.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>         
}