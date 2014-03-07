package jACBrFramework.tefd;

/**
 * Operacao campo Sitef.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 13:21:54, revisao: $Id$
 */
public enum TefCliSiTefOperacaoCampo {
    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    String(0, "0 - String"),
    Double(1, "1 - Double"),
    CMC7(2, "2 - CMC7"),
    BarCode(3, "3 - BarCode");		    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da operacao.
     */
    private String descricao;
    /**
     * Codigo da operacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    TefCliSiTefOperacaoCampo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da operacao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da operacao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static TefCliSiTefOperacaoCampo valueOf(int pCodigo) {
        for (TefCliSiTefOperacaoCampo lTefCliSiTefOperacaoCampo : values()) {
            if (lTefCliSiTefOperacaoCampo.getCodigo() == pCodigo) return lTefCliSiTefOperacaoCampo;
        }
        return null;
    }
    // </editor-fold>       

}