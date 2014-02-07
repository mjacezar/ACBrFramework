package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Registro analitico dos bilhetes consolidados de passagem rodoviario (codigo 13),
 * de passagem aquaviario (codigo 14), de passagem e nota de bagagem (codigo 15) 
 * de de passagem ferroviario (codigo 16). 
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 15:35:03, revisao: $Id$
 */
public class RegistroD300 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documentos cancelados dos bilhetes de passagem rodoviario (codigo 13), de
     * passagem aquaviario (codigo 14), de passagem e nota de bagagem (codigo 15) e 
     * de passagem ferroviario (codigo 16). 
     */
    private Collection<RegistroD301> registroD301 = new ArrayList<RegistroD301>(); 
    /**
     * Complemento dos bilhetes (codigo 13, 14, 15 e 16).
     */
    private Collection<RegistroD310> registroD310 = new ArrayList<RegistroD310>();     
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
     * Numero do primeiro documento fiscal emitido (mesmo modelo, serie e subserie).
     */
    private String NUM_DOC_INI;
    /**
     * Numero do ultimo documento fiscal emitido (mesmo modelo, serie e subserie).
     */
    private String NUM_DOC_FIN;
    /**
     * Codigo da Situacao Tributaria, conforme a Tabela indicada no item 4.3.1.
     */
    private String CST_ICMS;
    /**
     * Codigo Fiscal de Operacao e Prestacao conforme tabela indicada no item 4.2.2.
     */
    private String CFOP;
    /**
     * Aliquota do ICMS.
     */
    private double ALIQ_ICMS;
    /**
     * Data da emissao dos documentos fiscais.
     */
    private Date DT_DOC;
    /**
     * Valor total acumulado das operacoes correspondentes a combinacao de CST_ICMS, 
     * CFOP e aliquota do ICMS, incluidas as despesas acessorias e acrescimos.
     */
    private double VL_OPR;
    /**
     * Valor total dos descontos.
     */
    private double VL_DESC;
    /**
     * Valor total da prestacao de servico.
     */
    private double VL_SERV;
    /**
     * Valor de seguro.
     */
    private double VL_SEG;
    /**
     * Valor de outras despesas.
     */
    private double VL_OUT_DESP;
    /**
     * Valor total da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor total do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor nao tributado em funcao da reducao da base de calculo do ICMS, 
     * referente a combinacao de CST_ICMS, CFOP e aliquota do ICMS.
     */
    private double VL_RED_BC;
    /**
     * Codigo da observacao do lancamento fiscal (campo 02 do Registro 0460).
     */
    private String COD_OBS;
    /**
     * Codigo da conta analitica contabil debitada/creditada.
     */
    private String COD_CTA;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Documentos cancelados dos bilhetes de passagem rodoviario (codigo 13), de
     * passagem aquaviario (codigo 14), de passagem e nota de bagagem (codigo 15) e
     * de passagem ferroviario (codigo 16).
     * @return the registroD301
     */
    public Collection<RegistroD301> getRegistroD301() {
        return registroD301;
    }

    /**
     * Complemento dos bilhetes (codigo 13, 14, 15 e 16).
     * @return the registroD310
     */
    public Collection<RegistroD310> getRegistroD310() {
        return registroD310;
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
     * Numero do primeiro documento fiscal emitido (mesmo modelo, serie e subserie).
     * @return the NUM_DOC_INI
     */
    public String getNUM_DOC_INI() {
        return NUM_DOC_INI;
    }

    /**
     * Numero do primeiro documento fiscal emitido (mesmo modelo, serie e subserie).
     * @param NUM_DOC_INI the NUM_DOC_INI to set
     */
    public void setNUM_DOC_INI(String NUM_DOC_INI) {
        this.NUM_DOC_INI = NUM_DOC_INI;
    }

    /**
     * Numero do ultimo documento fiscal emitido (mesmo modelo, serie e subserie).
     * @return the NUM_DOC_FIN
     */
    public String getNUM_DOC_FIN() {
        return NUM_DOC_FIN;
    }

    /**
     * Numero do ultimo documento fiscal emitido (mesmo modelo, serie e subserie).
     * @param NUM_DOC_FIN the NUM_DOC_FIN to set
     */
    public void setNUM_DOC_FIN(String NUM_DOC_FIN) {
        this.NUM_DOC_FIN = NUM_DOC_FIN;
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
     * Codigo Fiscal de Operacao e Prestacao conforme tabela indicada no item 4.2.2.
     * @return the CFOP
     */
    public String getCFOP() {
        return CFOP;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao conforme tabela indicada no item 4.2.2.
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
     * Valor total dos descontos.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor total dos descontos.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Valor total da prestacao de servico.
     * @return the VL_SERV
     */
    public double getVL_SERV() {
        return VL_SERV;
    }

    /**
     * Valor total da prestacao de servico.
     * @param VL_SERV the VL_SERV to set
     */
    public void setVL_SERV(double VL_SERV) {
        this.VL_SERV = VL_SERV;
    }

    /**
     * Valor de seguro.
     * @return the VL_SEG
     */
    public double getVL_SEG() {
        return VL_SEG;
    }

    /**
     * Valor de seguro.
     * @param VL_SEG the VL_SEG to set
     */
    public void setVL_SEG(double VL_SEG) {
        this.VL_SEG = VL_SEG;
    }

    /**
     * Valor de outras despesas.
     * @return the VL_OUT_DESP
     */
    public double getVL_OUT_DESP() {
        return VL_OUT_DESP;
    }

    /**
     * Valor de outras despesas.
     * @param VL_OUT_DESP the VL_OUT_DESP to set
     */
    public void setVL_OUT_DESP(double VL_OUT_DESP) {
        this.VL_OUT_DESP = VL_OUT_DESP;
    }

    /**
     * Valor total da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor total da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor total do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor total do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor nao tributado em funcao da reducao da base de calculo do ICMS,
     * referente a combinacao de CST_ICMS, CFOP e aliquota do ICMS.
     * @return the VL_RED_BC
     */
    public double getVL_RED_BC() {
        return VL_RED_BC;
    }

    /**
     * Valor nao tributado em funcao da reducao da base de calculo do ICMS,
     * referente a combinacao de CST_ICMS, CFOP e aliquota do ICMS.
     * @param VL_RED_BC the VL_RED_BC to set
     */
    public void setVL_RED_BC(double VL_RED_BC) {
        this.VL_RED_BC = VL_RED_BC;
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

    /**
     * Codigo da conta analitica contabil debitada/creditada.
     * @return the COD_CTA
     */
    public String getCOD_CTA() {
        return COD_CTA;
    }

    /**
     * Codigo da conta analitica contabil debitada/creditada.
     * @param COD_CTA the COD_CTA to set
     */
    public void setCOD_CTA(String COD_CTA) {
        this.COD_CTA = COD_CTA;
    }
    // </editor-fold>    
    
}