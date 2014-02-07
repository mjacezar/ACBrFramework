package jACBrFramework.sped.bloco1;

/**
 * DCTA - Demonstrativo de credito do ICMS sobre transporte aereo.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 09:26:58, revisao: $Id$
 */
public class Registro1800 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Valor das prestacoes cargas (Tributado).
     */
    private double VL_CARGA;
    /**
     * Valor das prestacoes passageiros/cargas (Nao Tributado).
     */
    private double VL_PASS;
    /**
     * Valor total do faturamento (valor carga + valor passageiros).
     */
    private double VL_FAT;
    /**
     * Indice para rateio (2/4) - VL_CARGA/VL_FAT
     */
    private double IND_RAT;
    /**
     * Valor total dos creditos de ICMS.
     */
    private double VL_ICMS_ANT;
    /**
     * Valor da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor do ICMS apurado (5 X 6).
     */
    private double VL_ICMS_APUR;
    /**
     * Valor da base de calculo do ICMS apurada  (5 X 7).
     */
    private double VL_BC_ICMS_APUR;
    /**
     * Valor da diferenca a ser levada a estorno de credito na apuracao  (6 - 8).
     */
    private double VL_DIF;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Valor das prestacoes cargas (Tributado).
     * @return the VL_CARGA
     */
    public double getVL_CARGA() {
        return VL_CARGA;
    }

    /**
     * Valor das prestacoes cargas (Tributado).
     * @param VL_CARGA the VL_CARGA to set
     */
    public void setVL_CARGA(double VL_CARGA) {
        this.VL_CARGA = VL_CARGA;
    }

    /**
     * Valor das prestacoes passageiros/cargas (Nao Tributado).
     * @return the VL_PASS
     */
    public double getVL_PASS() {
        return VL_PASS;
    }

    /**
     * Valor das prestacoes passageiros/cargas (Nao Tributado).
     * @param VL_PASS the VL_PASS to set
     */
    public void setVL_PASS(double VL_PASS) {
        this.VL_PASS = VL_PASS;
    }

    /**
     * Valor total do faturamento (valor carga + valor passageiros).
     * @return the VL_FAT
     */
    public double getVL_FAT() {
        return VL_FAT;
    }

    /**
     * Valor total do faturamento (valor carga + valor passageiros).
     * @param VL_FAT the VL_FAT to set
     */
    public void setVL_FAT(double VL_FAT) {
        this.VL_FAT = VL_FAT;
    }

    /**
     * Indice para rateio (2/4) - VL_CARGA/VL_FAT
     * @return the IND_RAT
     */
    public double getIND_RAT() {
        return IND_RAT;
    }

    /**
     * Indice para rateio (2/4) - VL_CARGA/VL_FAT
     * @param IND_RAT the IND_RAT to set
     */
    public void setIND_RAT(double IND_RAT) {
        this.IND_RAT = IND_RAT;
    }

    /**
     * Valor total dos creditos de ICMS.
     * @return the VL_ICMS_ANT
     */
    public double getVL_ICMS_ANT() {
        return VL_ICMS_ANT;
    }

    /**
     * Valor total dos creditos de ICMS.
     * @param VL_ICMS_ANT the VL_ICMS_ANT to set
     */
    public void setVL_ICMS_ANT(double VL_ICMS_ANT) {
        this.VL_ICMS_ANT = VL_ICMS_ANT;
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
     * Valor do ICMS apurado (5 X 6).
     * @return the VL_ICMS_APUR
     */
    public double getVL_ICMS_APUR() {
        return VL_ICMS_APUR;
    }

    /**
     * Valor do ICMS apurado (5 X 6).
     * @param VL_ICMS_APUR the VL_ICMS_APUR to set
     */
    public void setVL_ICMS_APUR(double VL_ICMS_APUR) {
        this.VL_ICMS_APUR = VL_ICMS_APUR;
    }

    /**
     * Valor da base de calculo do ICMS apurada  (5 X 7).
     * @return the VL_BC_ICMS_APUR
     */
    public double getVL_BC_ICMS_APUR() {
        return VL_BC_ICMS_APUR;
    }

    /**
     * Valor da base de calculo do ICMS apurada  (5 X 7).
     * @param VL_BC_ICMS_APUR the VL_BC_ICMS_APUR to set
     */
    public void setVL_BC_ICMS_APUR(double VL_BC_ICMS_APUR) {
        this.VL_BC_ICMS_APUR = VL_BC_ICMS_APUR;
    }

    /**
     * Valor da diferenca a ser levada a estorno de credito na apuracao  (6 - 8).
     * @return the VL_DIF
     */
    public double getVL_DIF() {
        return VL_DIF;
    }

    /**
     * Valor da diferenca a ser levada a estorno de credito na apuracao  (6 - 8).
     * @param VL_DIF the VL_DIF to set
     */
    public void setVL_DIF(double VL_DIF) {
        this.VL_DIF = VL_DIF;
    }
    // </editor-fold>
    
}