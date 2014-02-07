package jACBrFramework.sped;

/**
 * Tipo de tarifa.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:34:15, revisao: $Id$
 */
public enum TipoTarifa {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Exp(0, "0 - Exp"),
    Enc(1, "1 - Enc"),
    CI(2, "2 - CI"),
    Outra(99, "9 - Outra");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do tipo de tarifa.
     */
    private String descricao;
    /**
     * Codigo do tipo de tarifa.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TipoTarifa(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do tipo de tarifa.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do tipo de tarifa.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>     
}