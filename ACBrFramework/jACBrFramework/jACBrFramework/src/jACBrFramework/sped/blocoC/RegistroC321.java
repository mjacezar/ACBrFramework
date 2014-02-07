package jACBrFramework.sped.blocoC;

/**
 * Itens de resumo diario dos documentos (codigo 02)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:37:19, revisao: $Id$
 */
public class RegistroC321 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Quantidade acumulada do item.
     */
    private double QTD;
    /**
     * Unidade do item (Campo 02 do registro 0190).
     */
    private String UNID;
    /**
     * Valor acumulado do item.
     */
    private double VL_ITEM;
    /**
     * Valor do desconto acumulado.
     */
    private double VL_DESC;
    /**
     * Valor acumulado da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor acumulado do ICMS debitado.
     */
    private double VL_ICMS;
    /**
     * Valor acumulado do PIS.
     */
    private double VL_PIS;
    /**
     * Valor acumulado da COFINS.
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
     * Valor do desconto acumulado.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor do desconto acumulado.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
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
     * Valor acumulado do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor acumulado do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor acumulado da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor acumulado da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }
    // </editor-fold>
    
}