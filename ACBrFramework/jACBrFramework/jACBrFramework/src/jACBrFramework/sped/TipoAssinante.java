package jACBrFramework.sped;

/**
 * Tipo de assinante.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 10:00:19, revisao: $Id$
 */
public enum TipoAssinante {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    ComercialIndustrial(0, "1 - Comercial/Industrial"),
    PoderPublico(1, "2 - Poder Público"),
    Residencial(2, "3 - Residencial/Pessoa física"),
    Publico(3, "4 - Público"),
    SemiPublico(4, "5 - Semi-Público"),
    Outros(5, "6 - Outros");
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