package jACBrFramework.sped.blocoC;

/**
 * Itens do documento fiscal emitido por ECF (codigo 02 e 2D).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 18:17:27, revisao: $Id$
 */
public class RegistroC470 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Quantidade do item.
     */
    private double QTD;
    /**
     * Quantidade cancelada, no caso de cancelamento parcial de item.
     */
    private double QTD_CANC;
    /**
     * Unidade do item (Campo 02 do registro 0190).
     */
    private String UNID;
    /**
     * Valor do item.
     */
    private double VL_ITEM;
    /**
     * Codigo da Situacao Tributaria, conforme a Tabela indicada no item 4.3.1.
     */
    private String CST_ICMS;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String CFOP;
    /**
     * Aliquota do ICMS - Carga tributaria efetiva em percentual.
     */
    private double ALIQ_ICMS;
    /**
     * Valor do PIS.
     */
    private double VL_PIS;
    /**
     * Valor da COFINS.
     */
    private double VL_COFINS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
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
     * Quantidade cancelada, no caso de cancelamento parcial de item.
     * @return the QTD_CANC
     */
    public double getQTD_CANC() {
        return QTD_CANC;
    }

    /**
     * Quantidade cancelada, no caso de cancelamento parcial de item.
     * @param QTD_CANC the QTD_CANC to set
     */
    public void setQTD_CANC(double QTD_CANC) {
        this.QTD_CANC = QTD_CANC;
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
     * Aliquota do ICMS - Carga tributaria efetiva em percentual.
     * @return the ALIQ_ICMS
     */
    public double getALIQ_ICMS() {
        return ALIQ_ICMS;
    }

    /**
     * Aliquota do ICMS - Carga tributaria efetiva em percentual.
     * @param ALIQ_ICMS the ALIQ_ICMS to set
     */
    public void setALIQ_ICMS(double ALIQ_ICMS) {
        this.ALIQ_ICMS = ALIQ_ICMS;
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
    // </editor-fold>
    
}