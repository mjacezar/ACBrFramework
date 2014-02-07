package jACBrFramework.sped.blocoC;

/**
 * Itens do documento (codigo 02).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:53:01, revisao: $Id$
 */
public class RegistroC370 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero sequencial do item no documento fiscal.
     */
    private String NUM_ITEM;
    /**
     * Codigo do Item (campo 02 do registro 0200).
     */
    private String COD_ITEM;
    /**
     * Quantidade do item.
     */
    private double QTD;
    /**
     * Unidade do item (campo 02 do registro 0190).
     */
    private String UNID;
    /**
     * Valor total do item.
     */
    private double VL_ITEM;
    /**
     * Valor total do desconto no item.
     */
    private double VL_DESC;    
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
     * Codigo do Item (campo 02 do registro 0200).
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do Item (campo 02 do registro 0200).
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
     * Unidade do item (campo 02 do registro 0190).
     * @return the UNID
     */
    public String getUNID() {
        return UNID;
    }

    /**
     * Unidade do item (campo 02 do registro 0190).
     * @param UNID the UNID to set
     */
    public void setUNID(String UNID) {
        this.UNID = UNID;
    }

    /**
     * Valor total do item.
     * @return the VL_ITEM
     */
    public double getVL_ITEM() {
        return VL_ITEM;
    }

    /**
     * Valor total do item.
     * @param VL_ITEM the VL_ITEM to set
     */
    public void setVL_ITEM(double VL_ITEM) {
        this.VL_ITEM = VL_ITEM;
    }

    /**
     * Valor total do desconto no item.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor total do desconto no item.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }
    // </editor-fold>
    
}