package jACBrFramework.sped.blocoC;

/**
 * Outras obrigacoes tributarias, ajustes e informacoes de valores provenientes
 * de documento fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:06:21, revisao: $Id$
 */
public class RegistroC197 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do ajustes/beneficio/incentivo, conforme tabela indicada no item 5.3.
     */
    private String COD_AJ;
    /**
     * Descricao complementar do ajuste do documento fiscal.
     */
    private String DESCR_COMPL_AJ;
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Base de calculo do ICMS ou do ICMS ST.
     */
    private double VL_BC_ICMS;
    /**
     * Aliquota do ICMS.
     */
    private double ALIQ_ICMS;
    /**
     * Valor do ICMS ou do ICMS ST.
     */
    private double VL_ICMS;
    /**
     * Outros valores.
     */
    private double VL_OUTROS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do ajustes/beneficio/incentivo, conforme tabela indicada no item 5.3.
     * @return the COD_AJ
     */
    public String getCOD_AJ() {
        return COD_AJ;
    }

    /**
     * Codigo do ajustes/beneficio/incentivo, conforme tabela indicada no item 5.3.
     * @param COD_AJ the COD_AJ to set
     */
    public void setCOD_AJ(String COD_AJ) {
        this.COD_AJ = COD_AJ;
    }

    /**
     * Descricao complementar do ajuste do documento fiscal.
     * @return the DESCR_COMPL_AJ
     */
    public String getDESCR_COMPL_AJ() {
        return DESCR_COMPL_AJ;
    }

    /**
     * Descricao complementar do ajuste do documento fiscal.
     * @param DESCR_COMPL_AJ the DESCR_COMPL_AJ to set
     */
    public void setDESCR_COMPL_AJ(String DESCR_COMPL_AJ) {
        this.DESCR_COMPL_AJ = DESCR_COMPL_AJ;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Base de calculo do ICMS ou do ICMS ST.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Base de calculo do ICMS ou do ICMS ST.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Aliquota do ICMS.
     * @return the ALIQ_ICMS
     */
    public double getALIQ_ICMS() {
        return ALIQ_ICMS;
    }

    /**
     * Aliquota do ICMS.
     * @param ALIQ_ICMS the ALIQ_ICMS to set
     */
    public void setALIQ_ICMS(double ALIQ_ICMS) {
        this.ALIQ_ICMS = ALIQ_ICMS;
    }

    /**
     * Valor do ICMS ou do ICMS ST.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS ou do ICMS ST.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Outros valores.
     * @return the VL_OUTROS
     */
    public double getVL_OUTROS() {
        return VL_OUTROS;
    }

    /**
     * Outros valores.
     * @param VL_OUTROS the VL_OUTROS to set
     */
    public void setVL_OUTROS(double VL_OUTROS) {
        this.VL_OUTROS = VL_OUTROS;
    }
    // </editor-fold>
    
}