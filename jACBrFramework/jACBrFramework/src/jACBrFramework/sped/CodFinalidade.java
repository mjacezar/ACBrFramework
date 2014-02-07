package jACBrFramework.sped;

/**
 * Codigo de finalidade do arquivo.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 08:31:02, revisao: $Id$
 */
public enum CodFinalidade {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Original(0, "Remessa do arquivo original"),
    Substituto(1, "Remessa do arquivo substituto");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da finalidade.
     */
    private String descricao;
    /**
     * Codigo da finalidade.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    CodFinalidade(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da finalidade.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da finalidade.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
    
}