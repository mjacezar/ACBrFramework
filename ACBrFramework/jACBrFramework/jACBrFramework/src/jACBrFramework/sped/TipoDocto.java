package jACBrFramework.sped;

/**
 * Tipo de documento exportacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 15:10:54, revisao: $Id$
 */
public enum TipoDocto {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    DeclaracaoExportacao(0, "0 - Declaração de Exportação"),
    DeclaracaoSimplesExportacao(1, "1 - Declaração Simplificada de Exportação");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de documento.
     */
    private String descricao;
    /**
     * Codigo do tipo de documento.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoDocto(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de documento.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de documento.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}