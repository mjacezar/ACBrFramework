package jACBrFramework.sped.blocoD;

/**
 * Registro analitico dos documentos (codigos 07, 08, 8B, 09, 10, 11, 26, 27 e 57).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 15:08:52, revisao: $Id$
 */
public class RegistroD190 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da Situacao Tributaria, conforme a tabela indicada no item 4.3.1.
     */
    private String CST_ICMS;
    /**
     * Codigo Fiscal de Operacao e Prestacao, conforme a tabela indicada no item 4.2.2.
     */
    private String CFOP;
    /**
     * Aliquota do ICMS.
     */
    private double ALIQ_ICMS;
    /**
     * Valor da operacao correspondente a combinacao de CST_ICMS, CFOP, e aliquota do ICMS.
     */
    private double VL_OPR;
    /**
     * Parcela correspondente ao "Valor da base de calculo do ICMS" referente a 
     * combinacao CST_ICMS, CFOP, e aliquota do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Parcela correspondente ao "Valor do ICMS" referente a combinacao CST_ICMS,  
     * CFOP e aliquota do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor nao tributado em funcao da reducao da base de calculo do ICMS, 
     * referente a combinação de CST_ICMS, CFOP e aliquota do ICMS.
     */
    private double VL_RED_BC;
    /**
     * Codigo da observacao do lacamento fiscal (campo 02 do Registro 0460).
     */
    private String COD_OBS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo da Situacao Tributaria, conforme a tabela indicada no item 4.3.1.
     * @return the CST_ICMS
     */
    public String getCST_ICMS() {
        return CST_ICMS;
    }

    /**
     * Codigo da Situacao Tributaria, conforme a tabela indicada no item 4.3.1.
     * @param CST_ICMS the CST_ICMS to set
     */
    public void setCST_ICMS(String CST_ICMS) {
        this.CST_ICMS = CST_ICMS;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao, conforme a tabela indicada no item 4.2.2.
     * @return the CFOP
     */
    public String getCFOP() {
        return CFOP;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao, conforme a tabela indicada no item 4.2.2.
     * @param CFOP the CFOP to set
     */
    public void setCFOP(String CFOP) {
        this.CFOP = CFOP;
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
     * Valor da operacao correspondente a combinacao de CST_ICMS, CFOP, e aliquota do ICMS.
     * @return the VL_OPR
     */
    public double getVL_OPR() {
        return VL_OPR;
    }

    /**
     * Valor da operacao correspondente a combinacao de CST_ICMS, CFOP, e aliquota do ICMS.
     * @param VL_OPR the VL_OPR to set
     */
    public void setVL_OPR(double VL_OPR) {
        this.VL_OPR = VL_OPR;
    }

    /**
     * Parcela correspondente ao "Valor da base de calculo do ICMS" referente a
     * combinacao CST_ICMS, CFOP, e aliquota do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Parcela correspondente ao "Valor da base de calculo do ICMS" referente a
     * combinacao CST_ICMS, CFOP, e aliquota do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Parcela correspondente ao "Valor do ICMS" referente a combinacao CST_ICMS,
     * CFOP e aliquota do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Parcela correspondente ao "Valor do ICMS" referente a combinacao CST_ICMS,
     * CFOP e aliquota do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor nao tributado em funcao da reducao da base de calculo do ICMS,
     * referente a combinação de CST_ICMS, CFOP e aliquota do ICMS.
     * @return the VL_RED_BC
     */
    public double getVL_RED_BC() {
        return VL_RED_BC;
    }

    /**
     * Valor nao tributado em funcao da reducao da base de calculo do ICMS,
     * referente a combinação de CST_ICMS, CFOP e aliquota do ICMS.
     * @param VL_RED_BC the VL_RED_BC to set
     */
    public void setVL_RED_BC(double VL_RED_BC) {
        this.VL_RED_BC = VL_RED_BC;
    }

    /**
     * Codigo da observacao do lacamento fiscal (campo 02 do Registro 0460).
     * @return the COD_OBS
     */
    public String getCOD_OBS() {
        return COD_OBS;
    }

    /**
     * Codigo da observacao do lacamento fiscal (campo 02 do Registro 0460).
     * @param COD_OBS the COD_OBS to set
     */
    public void setCOD_OBS(String COD_OBS) {
        this.COD_OBS = COD_OBS;
    }
    // </editor-fold>    
    
}