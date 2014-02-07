package jACBrFramework.sped;

/**
 * TIpo de importacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 13:32:01, revisao: $Id$
 */
public enum DoctoImporta {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Importacao(0, "0 – Declaração de Importação"),
    SimplificadaImport(1, "1 – Declaração Simplificada de Importação");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do documento de importacao.
     */
    private String descricao;
    /**
     * Codigo do documento de importacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    DoctoImporta(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do documento de importacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do documento de importacao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>        
}