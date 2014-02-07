package jACBrFramework.sped;

/**
 * Tipo de frete.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:16:03, revisao: $Id$
 */
public enum TipoFrete {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    PorContaEmitente(0, "0 - Por conta do emitente"),
    PorContaDestinatario(1, "1 - Por conta do destinatário/remetente"),
    PorContaTerceiros(2, "2 - Por conta de terceiros"),
    SemCobrancaFrete(9, "9 - Sem frete"),
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
    TipoFrete(int pCodigo, String pDescricao) {
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