package jACBrFramework.sped;

/**
 * Indicador do periodo de apuracao.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 16:31:59, revisao: $Id$
 */
public enum ApuracaoIPI {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Mensal(0, "0 - Mensal"),
    Decendial(1, "1 - Decendial");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do periodo de apuracao.
     */
    private String descricao;
    /**
     * Codigo do periodo de apuracao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    ApuracaoIPI(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do periodo de apuracao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do periodo de apuracao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
        
}