package jACBrFramework.sped.blocoD;

/**
 * Registro analitico do movimento diario (codigos 13, 14, 15, 16 e 2E).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 16:49:54, revisao: $Id$
 */
public class RegistroD390 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da Situacao Tributaria, conforme a Tabela indicada no item 4.3.1. 
     */
    private String CST_ICMS;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String CFOP;
    /**
     * Aliquota do ICMS.
     */
    private double ALIQ_ICMS;
    /**
     * Valor da operacao correspondente a combinacao de CST_ICMS, CFOP, e 
     * aliquota do ICMS, incluidas as despesas acessorias e acrescimos.
     */
    private double VL_OPR;
    /**
     * Valor da base de calculo do ISSQN.
     */
    private double VL_BC_ISSQN;
    /**
     * Aliquota do ISSQN.
     */
    private double ALIQ_ISSQN;
    /**
     * Valor do ISSQN.
     */
    private double VL_ISSQN;
    /**
     * Base de calculo do ICMS acumulada relativa a aliquota informada.
     */
    private double VL_BC_ICMS;
    /**
     * Valor do ICMS acumulado relativo a aliquota informada.
     */
    private double VL_ICMS;
    /**
     * Codigo da observacao do lancamento fiscal (campo 02 do Registro 0460).
     */
    private String COD_OBS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo da Situacao Tributaria, conforme a Tabela indicada no item 4.3.1.
     * @return the CST_ICMS
     */
    public String getCST_ICMS() {
        return CST_ICMS;
    }

    /**
     * Codigo da Situacao Tributaria, conforme a Tabela indicada no item 4.3.1.
     * @param CST_ICMS the CST_ICMS to set
     */
    public void setCST_ICMS(String CST_ICMS) {
        this.CST_ICMS = CST_ICMS;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
     * @return the CFOP
     */
    public String getCFOP() {
        return CFOP;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
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
     * Valor da operacao correspondente a combinacao de CST_ICMS, CFOP, e
     * aliquota do ICMS, incluidas as despesas acessorias e acrescimos.
     * @return the VL_OPR
     */
    public double getVL_OPR() {
        return VL_OPR;
    }

    /**
     * Valor da operacao correspondente a combinacao de CST_ICMS, CFOP, e
     * aliquota do ICMS, incluidas as despesas acessorias e acrescimos.
     * @param VL_OPR the VL_OPR to set
     */
    public void setVL_OPR(double VL_OPR) {
        this.VL_OPR = VL_OPR;
    }

    /**
     * Valor da base de calculo do ISSQN.
     * @return the VL_BC_ISSQN
     */
    public double getVL_BC_ISSQN() {
        return VL_BC_ISSQN;
    }

    /**
     * Valor da base de calculo do ISSQN.
     * @param VL_BC_ISSQN the VL_BC_ISSQN to set
     */
    public void setVL_BC_ISSQN(double VL_BC_ISSQN) {
        this.VL_BC_ISSQN = VL_BC_ISSQN;
    }

    /**
     * Aliquota do ISSQN.
     * @return the ALIQ_ISSQN
     */
    public double getALIQ_ISSQN() {
        return ALIQ_ISSQN;
    }

    /**
     * Aliquota do ISSQN.
     * @param ALIQ_ISSQN the ALIQ_ISSQN to set
     */
    public void setALIQ_ISSQN(double ALIQ_ISSQN) {
        this.ALIQ_ISSQN = ALIQ_ISSQN;
    }

    /**
     * Valor do ISSQN.
     * @return the VL_ISSQN
     */
    public double getVL_ISSQN() {
        return VL_ISSQN;
    }

    /**
     * Valor do ISSQN.
     * @param VL_ISSQN the VL_ISSQN to set
     */
    public void setVL_ISSQN(double VL_ISSQN) {
        this.VL_ISSQN = VL_ISSQN;
    }

    /**
     * Base de calculo do ICMS acumulada relativa a aliquota informada.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Base de calculo do ICMS acumulada relativa a aliquota informada.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor do ICMS acumulado relativo a aliquota informada.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS acumulado relativo a aliquota informada.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Codigo da observacao do lancamento fiscal (campo 02 do Registro 0460).
     * @return the COD_OBS
     */
    public String getCOD_OBS() {
        return COD_OBS;
    }

    /**
     * Codigo da observacao do lancamento fiscal (campo 02 do Registro 0460).
     * @param COD_OBS the COD_OBS to set
     */
    public void setCOD_OBS(String COD_OBS) {
        this.COD_OBS = COD_OBS;
    }
    // </editor-fold>    
    
}