package jACBrFramework.sintegra;

/**
 * Identificacao da estrutura do arquivo magnetico.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:46:53, revisao: $Id$
 */
public enum Convenio {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    ICMS_57_95_CONV_31_99("Estrutura conforme Convênio ICMS 57/95, na versão estabelecida pelo Convênio ICMS 31/99 e com as alterações promovidas até o Convênio ICMS 30/02.", 1),
    ICMS_57_95_CONV_69_02("Estrutura conforme Convênio ICMS 57/95, na versão estabelecida pelo Convênio ICMS 69/02 e com as alterações promovidas pelo Convênio ICMS 142/02.", 2),    
    ICMS_57_95_CONV_76_03("Estrutura conforme Convênio ICMS 57/95, com as alterações promovidas pelo Convênio ICMS 76/03.", 3);
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do convenio.
     */
    private String descricao;
    /**
     * Codigo associado ao convenio.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    Convenio(String pDescricao, int pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do convenio.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo associado ao convenio.
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
    public static Convenio valueOf(int pCodigo) {
        for (Convenio lConvenio : values()) {
            if (lConvenio.getCodigo() == pCodigo) return lConvenio;
        }
        return null;
    }    
    // </editor-fold>
}