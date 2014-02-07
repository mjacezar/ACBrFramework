package jACBrFramework.sped.blocoC;

/**
 * Itens do documento consolidado notas fiscais/contas de energia eletrica
 * (codigo 06), nota fiscal/conta de fornecimento de agua canalizada (codigo 29)
 * e nota fiscal/conta de fornecimento de gas (codigo 28)
 * (empresas nao obrigadas ao convenio ICMS 115/03).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 09:29:41, revisao: $Id$
 */
public class RegistroC610 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo de classificacao do item de energia eletrica, conforme Tabela 4.4.1.
     */
    private String COD_CLASS;
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Quantidade acumulada do item.
     */
    private double QTD;
    /**
     * Unidade do item  (Campo 02 do registro 0190).
     */
    private String UNID;
    /**
     * Valor acumulado do item.
     */
    private double VL_ITEM;
    /**
     * Valor acumulado dos descontos.
     */
    private double VL_DESC;
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
     * Valor acumulado da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor acumulado do ICMS debitado.
     */
    private double VL_ICMS;
    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     */
    private double VL_BC_ICMS_ST;
    /**
     * Valor do ICMS retido por substituicao tributaria.
     */
    private double VL_ICMS_ST;
    /**
     * Valor do PIS.
     */
    private double VL_PIS;
    /**
     * Valor da COFINS.
     */
    private double VL_COFINS;
    /**
     * Codigo da conta analitica contabil debitada/creditada.
     */
    private String COD_CTA;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo de classificacao do item de energia eletrica, conforme Tabela 4.4.1.
     * @return the COD_CLASS
     */
    public String getCOD_CLASS() {
        return COD_CLASS;
    }

    /**
     * Codigo de classificacao do item de energia eletrica, conforme Tabela 4.4.1.
     * @param COD_CLASS the COD_CLASS to set
     */
    public void setCOD_CLASS(String COD_CLASS) {
        this.COD_CLASS = COD_CLASS;
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
     * Quantidade acumulada do item.
     * @return the QTD
     */
    public double getQTD() {
        return QTD;
    }

    /**
     * Quantidade acumulada do item.
     * @param QTD the QTD to set
     */
    public void setQTD(double QTD) {
        this.QTD = QTD;
    }

    /**
     * Unidade do item  (Campo 02 do registro 0190).
     * @return the UNID
     */
    public String getUNID() {
        return UNID;
    }

    /**
     * Unidade do item  (Campo 02 do registro 0190).
     * @param UNID the UNID to set
     */
    public void setUNID(String UNID) {
        this.UNID = UNID;
    }

    /**
     * Valor acumulado do item.
     * @return the VL_ITEM
     */
    public double getVL_ITEM() {
        return VL_ITEM;
    }

    /**
     * Valor acumulado do item.
     * @param VL_ITEM the VL_ITEM to set
     */
    public void setVL_ITEM(double VL_ITEM) {
        this.VL_ITEM = VL_ITEM;
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
     * Valor acumulado do ICMS debitado.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor acumulado do ICMS debitado.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     * @return the VL_BC_ICMS_ST
     */
    public double getVL_BC_ICMS_ST() {
        return VL_BC_ICMS_ST;
    }

    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     * @param VL_BC_ICMS_ST the VL_BC_ICMS_ST to set
     */
    public void setVL_BC_ICMS_ST(double VL_BC_ICMS_ST) {
        this.VL_BC_ICMS_ST = VL_BC_ICMS_ST;
    }

    /**
     * Valor do ICMS retido por substituicao tributaria.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor do ICMS retido por substituicao tributaria.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }

    /**
     * Valor do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
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