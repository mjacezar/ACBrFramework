package jACBrFramework.sped.blocoC;

/**
 * Operacoes com combustiveis (codigo 01; 55).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 14:32:36, revisao: $Id$
 */
public class RegistroC165 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante (campo 02 do Registro 0150):- transportador, se houver
     */
    private String COD_PART;
    /**
     * Placa de identificacao do veiculo.
     */
    private String VEIC_ID;
    /**
     * Codigo da autorizacao fornecido pela SEFAZ (combustiveis).
     */
    private String COD_AUT;
    /**
     * Numero do Passe Fiscal.
     */
    private String NR_PASSE;
    /**
     * Hora da saida das mercadorias .
     */
    private String HORA;
    /**
     * Temperatura em graus Celsius utilizada para quantificacao do volume de combustivel.
     */
    private String TEMPER;
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
     * Nome do motorista.
     */
    private String NOM_MOT;
    /**
     * CPF do motorista.
     */
    private String CPF;
    /**
     * Sigla da UF da placa do veiculo.
     */
    private String UF_ID;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do participante (campo 02 do Registro 0150):- transportador, se houver
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):- transportador, se houver
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Placa de identificacao do veiculo.
     * @return the VEIC_ID
     */
    public String getVEIC_ID() {
        return VEIC_ID;
    }

    /**
     * Placa de identificacao do veiculo.
     * @param VEIC_ID the VEIC_ID to set
     */
    public void setVEIC_ID(String VEIC_ID) {
        this.VEIC_ID = VEIC_ID;
    }

    /**
     * Codigo da autorizacao fornecido pela SEFAZ (combustiveis).
     * @return the COD_AUT
     */
    public String getCOD_AUT() {
        return COD_AUT;
    }

    /**
     * Codigo da autorizacao fornecido pela SEFAZ (combustiveis).
     * @param COD_AUT the COD_AUT to set
     */
    public void setCOD_AUT(String COD_AUT) {
        this.COD_AUT = COD_AUT;
    }

    /**
     * Numero do Passe Fiscal.
     * @return the NR_PASSE
     */
    public String getNR_PASSE() {
        return NR_PASSE;
    }

    /**
     * Numero do Passe Fiscal.
     * @param NR_PASSE the NR_PASSE to set
     */
    public void setNR_PASSE(String NR_PASSE) {
        this.NR_PASSE = NR_PASSE;
    }

    /**
     * Hora da saida das mercadorias .
     * @return the HORA
     */
    public String getHORA() {
        return HORA;
    }

    /**
     * Hora da saida das mercadorias .
     * @param HORA the HORA to set
     */
    public void setHORA(String HORA) {
        this.HORA = HORA;
    }

    /**
     * Temperatura em graus Celsius utilizada para quantificacao do volume de combustivel.
     * @return the TEMPER
     */
    public String getTEMPER() {
        return TEMPER;
    }

    /**
     * Temperatura em graus Celsius utilizada para quantificacao do volume de combustivel.
     * @param TEMPER the TEMPER to set
     */
    public void setTEMPER(String TEMPER) {
        this.TEMPER = TEMPER;
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
     * Nome do motorista.
     * @return the NOM_MOT
     */
    public String getNOM_MOT() {
        return NOM_MOT;
    }

    /**
     * Nome do motorista.
     * @param NOM_MOT the NOM_MOT to set
     */
    public void setNOM_MOT(String NOM_MOT) {
        this.NOM_MOT = NOM_MOT;
    }

    /**
     * CPF do motorista.
     * @return the CPF
     */
    public String getCPF() {
        return CPF;
    }

    /**
     * CPF do motorista.
     * @param CPF the CPF to set
     */
    public void setCPF(String CPF) {
        this.CPF = CPF;
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