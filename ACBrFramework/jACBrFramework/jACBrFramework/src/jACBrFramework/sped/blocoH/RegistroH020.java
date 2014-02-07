package jACBrFramework.sped.blocoH;

/**
 * Informacao complementar do Inventario.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:33:54, revisao: $Id$
 */
public class RegistroH020 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da Situacao Tributaria referente ao ICMS, conforme a Tabela indicada no item 4.3.1.
     */
    private String CST_ICMS;
    /**
     * Informe a base de calculo do ICMS.
     */
    private double BC_ICMS;
    /**
     * Informe o valor do ICMS a ser debitado ou creditado.
     */
    private double VL_ICMS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo da Situacao Tributaria referente ao ICMS, conforme a Tabela indicada no item 4.3.1.
     * @return the CST_ICMS
     */
    public String getCST_ICMS() {
        return CST_ICMS;
    }

    /**
     * Codigo da Situacao Tributaria referente ao ICMS, conforme a Tabela indicada no item 4.3.1.
     * @param CST_ICMS the CST_ICMS to set
     */
    public void setCST_ICMS(String CST_ICMS) {
        this.CST_ICMS = CST_ICMS;
    }

    /**
     * Informe a base de calculo do ICMS.
     * @return the BC_ICMS
     */
    public double getBC_ICMS() {
        return BC_ICMS;
    }

    /**
     * Informe a base de calculo do ICMS.
     * @param BC_ICMS the BC_ICMS to set
     */
    public void setBC_ICMS(double BC_ICMS) {
        this.BC_ICMS = BC_ICMS;
    }

    /**
     * Informe o valor do ICMS a ser debitado ou creditado.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Informe o valor do ICMS a ser debitado ou creditado.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }
    // </editor-fold>    
    
}