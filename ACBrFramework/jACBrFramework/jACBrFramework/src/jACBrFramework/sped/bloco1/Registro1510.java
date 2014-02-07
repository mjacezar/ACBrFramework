package jACBrFramework.sped.bloco1;

import jACBrFramework.sped.TipoReceita;

/**
 * Itens do documento nota fiscal/conta energia eletrica (Codigo 06)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 08:19:23, revisao: $Id$
 */
public class Registro1510 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero sequencial do item no documento fiscal.
     */
    private String NUM_ITEM;
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Codigo de classificacao do item de energia eletrica, conforme a Tabela 4.4.1.
     */
    private String COD_CLASS;
    /**
     * Quantidade do item.
     */
    private double QTD;
    /**
     * Unidade do item (Campo 02 do registro 0190).
     */
    private String UNID;
    /**
     * Valor do item.
     */
    private double VL_ITEM;
    /**
     * Valor total do desconto.
     */
    private double VL_DESC;
    /**
     * Codigo da Situacao Tributaria, conforme a Tabela indicada no item 4.3.1.
     */
    private String CST_ICMS;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String CFOP;
    /**
     * Valor da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Aliquota do ICMS.
     */
    private double ALIQ_ICMS;
    /**
     * Valor do ICMS creditado/debitado.
     */
    private double VL_ICMS;
    /**
     * Valor da base de calculo referente a substituicao tributaria.
     */
    private double VL_BC_ICMS_ST;
    /**
     * Aliquota do ICMS da substituicao tributaria na UNID da federacao de destino.
     */
    private double ALIQ_ST;
    /**
     * Valor do ICMS referente a substituicao tributaria.
     */
    private double VL_ICMS_ST;
    /**
     * Indicador do tipo de receita.
     */
    private TipoReceita IND_REC;
    /**
     * Codigo do participante receptor da receita, terceiro da operacao (campo 02 do Registro 0150).
     */
    private String COD_PART;
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
     * Numero sequencial do item no documento fiscal.
     * @return the NUM_ITEM
     */
    public String getNUM_ITEM() {
        return NUM_ITEM;
    }

    /**
     * Numero sequencial do item no documento fiscal.
     * @param NUM_ITEM the NUM_ITEM to set
     */
    public void setNUM_ITEM(String NUM_ITEM) {
        this.NUM_ITEM = NUM_ITEM;
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
     * Codigo de classificacao do item de energia eletrica, conforme a Tabela 4.4.1.
     * @return the COD_CLASS
     */
    public String getCOD_CLASS() {
        return COD_CLASS;
    }

    /**
     * Codigo de classificacao do item de energia eletrica, conforme a Tabela 4.4.1.
     * @param COD_CLASS the COD_CLASS to set
     */
    public void setCOD_CLASS(String COD_CLASS) {
        this.COD_CLASS = COD_CLASS;
    }

    /**
     * Quantidade do item.
     * @return the QTD
     */
    public double getQTD() {
        return QTD;
    }

    /**
     * Quantidade do item.
     * @param QTD the QTD to set
     */
    public void setQTD(double QTD) {
        this.QTD = QTD;
    }

    /**
     * Unidade do item (Campo 02 do registro 0190).
     * @return the UNID
     */
    public String getUNID() {
        return UNID;
    }

    /**
     * Unidade do item (Campo 02 do registro 0190).
     * @param UNID the UNID to set
     */
    public void setUNID(String UNID) {
        this.UNID = UNID;
    }

    /**
     * Valor do item.
     * @return the VL_ITEM
     */
    public double getVL_ITEM() {
        return VL_ITEM;
    }

    /**
     * Valor do item.
     * @param VL_ITEM the VL_ITEM to set
     */
    public void setVL_ITEM(double VL_ITEM) {
        this.VL_ITEM = VL_ITEM;
    }

    /**
     * Valor total do desconto.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor total do desconto.
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
     * Valor da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor da base de calculo do ICMS.
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
     * Valor do ICMS creditado/debitado.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS creditado/debitado.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor da base de calculo referente a substituicao tributaria.
     * @return the VL_BC_ICMS_ST
     */
    public double getVL_BC_ICMS_ST() {
        return VL_BC_ICMS_ST;
    }

    /**
     * Valor da base de calculo referente a substituicao tributaria.
     * @param VL_BC_ICMS_ST the VL_BC_ICMS_ST to set
     */
    public void setVL_BC_ICMS_ST(double VL_BC_ICMS_ST) {
        this.VL_BC_ICMS_ST = VL_BC_ICMS_ST;
    }

    /**
     * Aliquota do ICMS da substituicao tributaria na UNID da federacao de destino.
     * @return the ALIQ_ST
     */
    public double getALIQ_ST() {
        return ALIQ_ST;
    }

    /**
     * Aliquota do ICMS da substituicao tributaria na UNID da federacao de destino.
     * @param ALIQ_ST the ALIQ_ST to set
     */
    public void setALIQ_ST(double ALIQ_ST) {
        this.ALIQ_ST = ALIQ_ST;
    }

    /**
     * Valor do ICMS referente a substituicao tributaria.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor do ICMS referente a substituicao tributaria.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }

    /**
     * Indicador do tipo de receita.
     * @return the IND_REC
     */
    public TipoReceita getIND_REC() {
        return IND_REC;
    }

    /**
     * Indicador do tipo de receita.
     * @param IND_REC the IND_REC to set
     */
    public void setIND_REC(TipoReceita IND_REC) {
        this.IND_REC = IND_REC;
    }

    /**
     * Codigo do participante receptor da receita, terceiro da operacao (campo 02 do Registro 0150).
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante receptor da receita, terceiro da operacao (campo 02 do Registro 0150).
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
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