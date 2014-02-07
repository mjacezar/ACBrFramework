package jACBrFramework.sped;

/**
 * Tipo de transporte.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 11:13:58, revisao: $Id$
 */
public enum TipoTransporte {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Rodoviario(0, "0 – Rodoviário"),
    Ferroviario(1, "1 – Ferroviário"),
    RodoFerroviario(2, "2 – Rodo-Ferroviário"),
    Aquaviario(3, "3 – Aquaviário"),
    Dutoviario(4, "4 – Dutoviário"),
    Aereo(5, "5 – Aéreo"),
    Outros(9, "9 – Outros");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de receita.
     */
    private String descricao;
    /**
     * Codigo do tipo de receita.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoTransporte(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de receita.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de receita.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>     
}