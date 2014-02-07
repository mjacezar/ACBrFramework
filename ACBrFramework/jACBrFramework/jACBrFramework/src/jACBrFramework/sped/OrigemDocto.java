package jACBrFramework.sped;

/**
 * Origem do documento vinculado ao ajuste.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:18:48, revisao: $Id$
 */
public enum OrigemDocto {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    PorcessoJudicial(0, "0 - Processo Judicial"),
    ProcessoAdminist(1, "1 - Processo Administrativo"),
    PerDcomp(2, "2 - PER/DCOMP"),
    Outros(9, "9 – Outros");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da origem do documento de ajuste.
.     */
    private String descricao;
    /**
     * Codigo da origem do documento de ajuste.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    OrigemDocto(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da origem do documento de ajuste.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da origem do documento de ajuste.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>      
}