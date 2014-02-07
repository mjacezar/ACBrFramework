package jACBrFramework.sped;

/**
 * Identificador do tipo de medicao.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 17:25:16, revisao: $Id$
 */
public enum Medicao {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Analogico(0, "Analogico"),
    Digital(1, "Digital");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de medicao.
     */
    private String descricao;
    /**
     * Codigo do tipo de medicao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    Medicao(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de medicao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de medicao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>   
    
}