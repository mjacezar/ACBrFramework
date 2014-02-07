package jACBrFramework.sped;

/**
 * Origem do processo.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:39:13, revisao: $Id$
 */
public enum OrigemProcesso {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Sefaz(0, "0 - Sefaz"),
    JusticaFederal(1, "1 - Justiça Federal"),
    JusticaEstadual(2, "2 - Justiça Estadual"),
    SecexRFB(3, "3 - Secex/RFB"),
    Outros(9, "9 - Outros"),
    Nenhum(-1, "Preencher vazio");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da origem do processo.
     */
    private String descricao;
    /**
     * Codigo da origem do processo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    OrigemProcesso(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da origem do processo.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da origem do processo.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>        
}