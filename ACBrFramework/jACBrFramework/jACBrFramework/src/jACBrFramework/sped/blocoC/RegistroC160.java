package jACBrFramework.sped.blocoC;

/**
 * Volumes transportados (codigo 01 e 04) - exceto combustiveis.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 14:28:01, revisao: $Id$
 */
public class RegistroC160 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante (campo 02 do Registro 0150): - transportador, se houver.
     */
    private String COD_PART;
    /**
     * Placa de identificacao do veiculo automotor.
     */
    private String VEIC_ID;
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
    /**
     * Sigla da UF da placa do veiculo.
     */
    private String UF_ID;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do participante (campo 02 do Registro 0150): - transportador, se houver.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - transportador, se houver.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Placa de identificacao do veiculo automotor.
     * @return the VEIC_ID
     */
    public String getVEIC_ID() {
        return VEIC_ID;
    }

    /**
     * Placa de identificacao do veiculo automotor.
     * @param VEIC_ID the VEIC_ID to set
     */
    public void setVEIC_ID(String VEIC_ID) {
        this.VEIC_ID = VEIC_ID;
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

    /**
     * Sigla da UF da placa do veiculo.
     * @return the UF_ID
     */
    public String getUF_ID() {
        return UF_ID;
    }

    /**
     * Sigla da UF da placa do veiculo.
     * @param UF_ID the UF_ID to set
     */
    public void setUF_ID(String UF_ID) {
        this.UF_ID = UF_ID;
    }
    // </editor-fold>
    
}