package jACBrFramework.sped.blocoE;

/**
 * Consolidacao dos valores do IPI.
 *  
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:52:23, revisao: $Id$
 */
public class RegistroE510 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo Fiscal de Operacao e Prestacao do agrupamento de itens.
     */
    private String CFOP;
    /**
     * Codigo da Situacao Tributaria referente ao IPI, conforme a Tabela indicada no item 4.3.2.
     */
    private String CST_IPI;
    /**
     * Parcela correspondente ao "Valor Contábil" referente ao CFOP e ao Codigo de Tributacao do IPI.
     */
    private double VL_CONT_IPI;
    /**
     * Parcela correspondente ao "Valor da base de calculo do IPI" referente ao 
     * CFOP e ao Codigo de Tributacao do IPI, para operacoes tributadas.
     */
    private double VL_BC_IPI;
    /**
     * Parcela correspondente ao "Valor do IPI" referente ao CFOP e ao Codigo de 
     * Tributacao do IPI, para operacoes tributadas.
     */
    private double VL_IPI;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo Fiscal de Operacao e Prestacao do agrupamento de itens.
     * @return the CFOP
     */
    public String getCFOP() {
        return CFOP;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao do agrupamento de itens.
     * @param CFOP the CFOP to set
     */
    public void setCFOP(String CFOP) {
        this.CFOP = CFOP;
    }

    /**
     * Codigo da Situacao Tributaria referente ao IPI, conforme a Tabela indicada no item 4.3.2.
     * @return the CST_IPI
     */
    public String getCST_IPI() {
        return CST_IPI;
    }

    /**
     * Codigo da Situacao Tributaria referente ao IPI, conforme a Tabela indicada no item 4.3.2.
     * @param CST_IPI the CST_IPI to set
     */
    public void setCST_IPI(String CST_IPI) {
        this.CST_IPI = CST_IPI;
    }

    /**
     * Parcela correspondente ao "Valor Contábil" referente ao CFOP e ao Codigo de Tributacao do IPI.
     * @return the VL_CONT_IPI
     */
    public double getVL_CONT_IPI() {
        return VL_CONT_IPI;
    }

    /**
     * Parcela correspondente ao "Valor Contábil" referente ao CFOP e ao Codigo de Tributacao do IPI.
     * @param VL_CONT_IPI the VL_CONT_IPI to set
     */
    public void setVL_CONT_IPI(double VL_CONT_IPI) {
        this.VL_CONT_IPI = VL_CONT_IPI;
    }

    /**
     * Parcela correspondente ao "Valor da base de calculo do IPI" referente ao
     * CFOP e ao Codigo de Tributacao do IPI, para operacoes tributadas.
     * @return the VL_BC_IPI
     */
    public double getVL_BC_IPI() {
        return VL_BC_IPI;
    }

    /**
     * Parcela correspondente ao "Valor da base de calculo do IPI" referente ao
     * CFOP e ao Codigo de Tributacao do IPI, para operacoes tributadas.
     * @param VL_BC_IPI the VL_BC_IPI to set
     */
    public void setVL_BC_IPI(double VL_BC_IPI) {
        this.VL_BC_IPI = VL_BC_IPI;
    }

    /**
     * Parcela correspondente ao "Valor do IPI" referente ao CFOP e ao Codigo de
     * Tributacao do IPI, para operacoes tributadas.
     * @return the VL_IPI
     */
    public double getVL_IPI() {
        return VL_IPI;
    }

    /**
     * Parcela correspondente ao "Valor do IPI" referente ao CFOP e ao Codigo de
     * Tributacao do IPI, para operacoes tributadas.
     * @param VL_IPI the VL_IPI to set
     */
    public void setVL_IPI(double VL_IPI) {
        this.VL_IPI = VL_IPI;
    }
    // </editor-fold>    
    
}