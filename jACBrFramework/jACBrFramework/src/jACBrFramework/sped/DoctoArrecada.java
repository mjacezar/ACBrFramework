package jACBrFramework.sped;

/**
 * Documento de arrecadacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:47:40, revisao: $Id$
 */
public enum DoctoArrecada {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    EstadualArrecadacao(0, "0 - Documento Estadual de Arrecadação"),
    GNRE(1, "1 - GNRE");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do documento de arrecadacao.
     */
    private String descricao;
    /**
     * Codigo do documento de arrecadacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    DoctoArrecada(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do documento de arrecadacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do documento de arrecadacao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
        
}