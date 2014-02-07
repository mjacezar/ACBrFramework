package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Documentos informados (codigos 13, 14, 15 e 16).
 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 17:03:07, revisao: $Id$
 */
public class RegistroD410 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documentos cancelados dos documentos informados (codigos 13, 14, 15 e 16).
     */
    private Collection<RegistroD411> registroD411 = new ArrayList<RegistroD411>();     
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB;
    /**
     * Numero do documento fiscal inicial (mesmo modelo, serie e subserie).
     */
    private String NUM_DOC_INI;
    /**
     * Numero do documento fiscal final(mesmo modelo, serie e subserie)
     */
    private String NUM_DOC_FIN;
    /**
     * Data da emissao dos documentos fiscais.
     */
    private Date DT_DOC;
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
     * Valor total acumulado das operacoes correspondentes a combinacao de CST_ICMS, 
     * CFOP e aliquota do ICMS, incluidas as despesas acessorias e acrescimos.
     */
    private double VL_OPR;
    /**
     * Valor acumulado dos descontos.
     */
    private double VL_DESC;
    /**
     * Valor acumulado da prestacao de servico.
     */
    private double VL_SERV;
    /**
     * Valor acumulado da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor acumulado do ICMS.
     */
    private double VL_ICMS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Documentos cancelados dos documentos informados (codigos 13, 14, 15 e 16).
     * @return the registroD411
     */
    public Collection<RegistroD411> getRegistroD411() {
        return registroD411;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Serie do documento fiscal.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Subserie do documento fiscal.
     * @return the SUB
     */
    public String getSUB() {
        return SUB;
    }

    /**
     * Subserie do documento fiscal.
     * @param SUB the SUB to set
     */
    public void setSUB(String SUB) {
        this.SUB = SUB;
    }

    /**
     * Numero do documento fiscal inicial (mesmo modelo, serie e subserie).
     * @return the NUM_DOC_INI
     */
    public String getNUM_DOC_INI() {
        return NUM_DOC_INI;
    }

    /**
     * Numero do documento fiscal inicial (mesmo modelo, serie e subserie).
     * @param NUM_DOC_INI the NUM_DOC_INI to set
     */
    public void setNUM_DOC_INI(String NUM_DOC_INI) {
        this.NUM_DOC_INI = NUM_DOC_INI;
    }

    /**
     * Numero do documento fiscal final(mesmo modelo, serie e subserie)
     * @return the NUM_DOC_FIN
     */
    public String getNUM_DOC_FIN() {
        return NUM_DOC_FIN;
    }

    /**
     * Numero do documento fiscal final(mesmo modelo, serie e subserie)
     * @param NUM_DOC_FIN the NUM_DOC_FIN to set
     */
    public void setNUM_DOC_FIN(String NUM_DOC_FIN) {
        this.NUM_DOC_FIN = NUM_DOC_FIN;
    }

    /**
     * Data da emissao dos documentos fiscais.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao dos documentos fiscais.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

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
     * Valor total acumulado das operacoes correspondentes a combinacao de CST_ICMS,
     * CFOP e aliquota do ICMS, incluidas as despesas acessorias e acrescimos.
     * @return the VL_OPR
     */
    public double getVL_OPR() {
        return VL_OPR;
    }

    /**
     * Valor total acumulado das operacoes correspondentes a combinacao de CST_ICMS,
     * CFOP e aliquota do ICMS, incluidas as despesas acessorias e acrescimos.
     * @param VL_OPR the VL_OPR to set
     */
    public void setVL_OPR(double VL_OPR) {
        this.VL_OPR = VL_OPR;
    }

    /**
     * Valor acumulado dos descontos.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor acumulado dos descontos.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Valor acumulado da prestacao de servico.
     * @return the VL_SERV
     */
    public double getVL_SERV() {
        return VL_SERV;
    }

    /**
     * Valor acumulado da prestacao de servico.
     * @param VL_SERV the VL_SERV to set
     */
    public void setVL_SERV(double VL_SERV) {
        this.VL_SERV = VL_SERV;
    }

    /**
     * Valor acumulado da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor acumulado da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor acumulado do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor acumulado do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }
    // </editor-fold>    
    
}