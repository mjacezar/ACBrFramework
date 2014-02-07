package jACBrFramework.sped.blocoE;

/**
 * Informacoes adicionais da apuracao - valores declaratorios.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:00:09, revisao: $Id$
 */
public class RegistroE115 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da informacao adicional conforme tabela a ser definida pelas SEFAZ, 
     * conforme tabela definida no item 5.2.
     */
    private String COD_INF_ADIC;
    /**
     * Valor referente a informação adicional.
     */
    private double VL_INF_ADIC;
    /**
     * Descricao complementar do ajuste.
     */
    private String DESCR_COMPL_AJ;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo da informacao adicional conforme tabela a ser definida pelas SEFAZ,
     * conforme tabela definida no item 5.2.
     * @return the COD_INF_ADIC
     */
    public String getCOD_INF_ADIC() {
        return COD_INF_ADIC;
    }

    /**
     * Codigo da informacao adicional conforme tabela a ser definida pelas SEFAZ,
     * conforme tabela definida no item 5.2.
     * @param COD_INF_ADIC the COD_INF_ADIC to set
     */
    public void setCOD_INF_ADIC(String COD_INF_ADIC) {
        this.COD_INF_ADIC = COD_INF_ADIC;
    }

    /**
     * Valor referente a informação adicional.
     * @return the VL_INF_ADIC
     */
    public double getVL_INF_ADIC() {
        return VL_INF_ADIC;
    }

    /**
     * Valor referente a informação adicional.
     * @param VL_INF_ADIC the VL_INF_ADIC to set
     */
    public void setVL_INF_ADIC(double VL_INF_ADIC) {
        this.VL_INF_ADIC = VL_INF_ADIC;
    }

    /**
     * Descricao complementar do ajuste.
     * @return the DESCR_COMPL_AJ
     */
    public String getDESCR_COMPL_AJ() {
        return DESCR_COMPL_AJ;
    }

    /**
     * Descricao complementar do ajuste.
     * @param DESCR_COMPL_AJ the DESCR_COMPL_AJ to set
     */
    public void setDESCR_COMPL_AJ(String DESCR_COMPL_AJ) {
        this.DESCR_COMPL_AJ = DESCR_COMPL_AJ;
    }
    // </editor-fold>    
    
}