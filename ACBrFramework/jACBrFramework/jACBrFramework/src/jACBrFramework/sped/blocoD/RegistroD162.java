package jACBrFramework.sped.blocoD;

import java.util.Date;

/**
 * Identificacao dos documentos fiscais (codigo 08, 8B, 09, 10, 11, 26 e 27).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:45:45, revisao: $Id$
 */
public class RegistroD162 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    /**
     * Valor total do documento fiscal.
     */
    private double VL_DOC;
    /**
     * Valor das mercadorias constantes no documento fiscal.
     */
    private double VL_MERC;
    /**
     * Quantidade de volumes transportados.
     */
    private int QTD_VOL;
    /**
     * Peso bruto dos volumes transportados (em Kg).
     */
    private double PESO_BRT;
    /**
     * Peso liquido dos volumes transportados (em Kg).
     */
    private double PESO_LIQ;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
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
     * Numero do documento fiscal.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero do documento fiscal.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
    }

    /**
     * Data da emissao do documento fiscal.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao do documento fiscal.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Valor total do documento fiscal.
     * @return the VL_DOC
     */
    public double getVL_DOC() {
        return VL_DOC;
    }

    /**
     * Valor total do documento fiscal.
     * @param VL_DOC the VL_DOC to set
     */
    public void setVL_DOC(double VL_DOC) {
        this.VL_DOC = VL_DOC;
    }

    /**
     * Valor das mercadorias constantes no documento fiscal.
     * @return the VL_MERC
     */
    public double getVL_MERC() {
        return VL_MERC;
    }

    /**
     * Valor das mercadorias constantes no documento fiscal.
     * @param VL_MERC the VL_MERC to set
     */
    public void setVL_MERC(double VL_MERC) {
        this.VL_MERC = VL_MERC;
    }

    /**
     * Quantidade de volumes transportados.
     * @return the QTD_VOL
     */
    public int getQTD_VOL() {
        return QTD_VOL;
    }

    /**
     * Quantidade de volumes transportados.
     * @param QTD_VOL the QTD_VOL to set
     */
    public void setQTD_VOL(int QTD_VOL) {
        this.QTD_VOL = QTD_VOL;
    }

    /**
     * Peso bruto dos volumes transportados (em Kg).
     * @return the PESO_BRT
     */
    public double getPESO_BRT() {
        return PESO_BRT;
    }

    /**
     * Peso bruto dos volumes transportados (em Kg).
     * @param PESO_BRT the PESO_BRT to set
     */
    public void setPESO_BRT(double PESO_BRT) {
        this.PESO_BRT = PESO_BRT;
    }

    /**
     * Peso liquido dos volumes transportados (em Kg).
     * @return the PESO_LIQ
     */
    public double getPESO_LIQ() {
        return PESO_LIQ;
    }

    /**
     * Peso liquido dos volumes transportados (em Kg).
     * @param PESO_LIQ the PESO_LIQ to set
     */
    public void setPESO_LIQ(double PESO_LIQ) {
        this.PESO_LIQ = PESO_LIQ;
    }
    // </editor-fold>    
    
}