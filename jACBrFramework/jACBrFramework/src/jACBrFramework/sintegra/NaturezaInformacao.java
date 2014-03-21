package jACBrFramework.sintegra;

/**
 * Cdigo da identificacao da natureza das operacoes informadas.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:41:17, revisao: $Id$
 */
public enum NaturezaInformacao {    
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    INTERESTADUAIS_SOMENTE_OP_SUJEITAS_REG_ST("Interestaduais somente operações sujeitas ao regime de substituição tributária", 1),
    INTERESTADUAIS_OP_COM_ST_OU_SEM_ST("Interestaduais - operações com ou sem substituição tributária", 2),
    TOTALIDADE_DAS_OPERACOES("Totalidade das operações do informantes", 3);
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da natureza da operacao.
     */
    private String descricao;
    /**
     * Codigo associado a natureza da operacao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    NaturezaInformacao(String pDescricao, int pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da natureza da operacao.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo associado a natureza da operacao.
     * 
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
    public static NaturezaInformacao valueOf(int pCodigo) {
        for (NaturezaInformacao lNaturezaInformacao : values()) {
            if (lNaturezaInformacao.getCodigo() == pCodigo) return lNaturezaInformacao;
        }
        return null;
    }       
    // </editor-fold>
}