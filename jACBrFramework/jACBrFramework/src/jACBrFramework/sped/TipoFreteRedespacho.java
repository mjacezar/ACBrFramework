package jACBrFramework.sped;

/**
 * Tipo do frete de operacao de redespacho.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:39:03, revisao: $Id$
 */
public enum TipoFreteRedespacho {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    SemRedespacho(0, "0 – Sem redespacho"),
    PorContaEmitente(1, "1 - Por conta do emitente"),
    PorContaDestinatario(2, "2 - Por conta do destinatário"),
    Outros(9, "9 – Outros"),
    Nenhum(-1, "Preencher vazio");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de frete.
     */
    private String descricao;
    /**
     * Codigo do tipo de frete.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoFreteRedespacho(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de frete.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de frete.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>       
}