package jACBrFramework.sped;

/**
 * Tipo da navegacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:15:43, revisao: $Id$
 */
public enum TipoNavegacao {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Interior(0, "0 – Interior"),
    Cabotagem(1, "1 – Cabotagem");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de navegacao.
     */
    private String descricao;
    /**
     * Codigo do tipo de navegacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoNavegacao(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de navegacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de navegacao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}