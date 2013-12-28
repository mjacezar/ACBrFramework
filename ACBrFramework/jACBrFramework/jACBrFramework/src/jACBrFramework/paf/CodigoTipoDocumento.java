package jACBrFramework.paf;

/**
 * Codigo do tipo de documento.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 15:54:59, revisao: $Id$
 */
public enum CodigoTipoDocumento {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    CUPOM_FISCAL("Cupom Fiscal", "1"),
    COMPROVANTE_NAO_FISCAL("Comprovante Não Fiscal", "2"),
    NotaFiscal("Nota Fiscal", "3");
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de documento.
     */
    private String descricao;
    /**
     * Codigo do tipo de documento.
     */
    private String codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    CodigoTipoDocumento(String pDescricao, String pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de documento.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de documento.
     * 
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }
    // </editor-fold>    
}