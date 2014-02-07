package jACBrFramework.sped;

/**
 * Tipo de assinante.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 10:00:19, revisao: $Id$
 */
public enum TipoAssinante {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    ComercialIndustrial(1, "1 - Comercial/Industrial"),
    PoderPublico(2, "2 - Poder Público"),
    Residencial(3, "3 - Residencial/Pessoa física"),
    Publico(4, "4 - Público"),
    SemiPublico(5, "5 - Semi-Público"),
    Outros(6, "6 - Outros");
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo do assinante.
     */
    private String descricao;
    /**
     * Codigo do tipo do assinante.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoAssinante(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo do assinante.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo do assinante.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       

}