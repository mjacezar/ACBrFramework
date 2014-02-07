package jACBrFramework.sped.blocoC;

/**
 * Resumo mensal de itens do Ecf por estabelecimento (codigo 02, 2D).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 08:30:18, revisao: $Id$
 */
public class RegistroC495 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Aliquota do ICMS.
     */
    private double ALIQ_ICMS;
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Quantidade acumulada do item.
     */
    private double QTD;
    /**
     * Quantidade cancelada acumulada, no caso de cancelamento parcial de item. 
     */
    private double QTD_CANC;
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
     * Valor acumulado dos cancelamentos.
     */
    private double VL_CANC;
    /**
     * Valor acumulado dos acrescimos.
     */
    private double VL_ACMO;
    /**
     * Valor acumulado da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor acumulado do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor das saidas isentas do ICMS.
     */
    private double VL_ISEN;
    /**
     * Valor das saidas sob nao-incidencia ou nao-tributadas pelo ICMS.
     */
    private double VL_NT;
    /**
     * Valor das saidas de mercadorias adquiridas com substituicao tributaria do ICMS.
     */
    private double VL_ICMS_ST;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
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
     * Quantidade cancelada acumulada, no caso de cancelamento parcial de item.
     * @return the QTD_CANC
     */
    public double getQTD_CANC() {
        return QTD_CANC;
    }

    /**
     * Quantidade cancelada acumulada, no caso de cancelamento parcial de item.
     * @param QTD_CANC the QTD_CANC to set
     */
    public void setQTD_CANC(double QTD_CANC) {
        this.QTD_CANC = QTD_CANC;
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
     * Valor acumulado dos cancelamentos.
     * @return the VL_CANC
     */
    public double getVL_CANC() {
        return VL_CANC;
    }

    /**
     * Valor acumulado dos cancelamentos.
     * @param VL_CANC the VL_CANC to set
     */
    public void setVL_CANC(double VL_CANC) {
        this.VL_CANC = VL_CANC;
    }

    /**
     * Valor acumulado dos acrescimos.
     * @return the VL_ACMO
     */
    public double getVL_ACMO() {
        return VL_ACMO;
    }

    /**
     * Valor acumulado dos acrescimos.
     * @param VL_ACMO the VL_ACMO to set
     */
    public void setVL_ACMO(double VL_ACMO) {
        this.VL_ACMO = VL_ACMO;
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

    /**
     * Valor das saidas isentas do ICMS.
     * @return the VL_ISEN
     */
    public double getVL_ISEN() {
        return VL_ISEN;
    }

    /**
     * Valor das saidas isentas do ICMS.
     * @param VL_ISEN the VL_ISEN to set
     */
    public void setVL_ISEN(double VL_ISEN) {
        this.VL_ISEN = VL_ISEN;
    }

    /**
     * Valor das saidas sob nao-incidencia ou nao-tributadas pelo ICMS.
     * @return the VL_NT
     */
    public double getVL_NT() {
        return VL_NT;
    }

    /**
     * Valor das saidas sob nao-incidencia ou nao-tributadas pelo ICMS.
     * @param VL_NT the VL_NT to set
     */
    public void setVL_NT(double VL_NT) {
        this.VL_NT = VL_NT;
    }

    /**
     * Valor das saidas de mercadorias adquiridas com substituicao tributaria do ICMS.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor das saidas de mercadorias adquiridas com substituicao tributaria do ICMS.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }
    // </editor-fold>
    
}