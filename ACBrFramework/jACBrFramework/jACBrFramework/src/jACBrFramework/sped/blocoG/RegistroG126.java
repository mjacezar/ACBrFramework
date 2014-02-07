package jACBrFramework.sped.blocoG;

import java.util.Date;

/**
 * Outros creditos CIAP.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:00:50, revisao: $Id$
 */
public class RegistroG126 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Data inicial do periodo de apuracao.
     */
    private Date DT_INI;
    /**
     * Data final do periodo de apuracao.
     */
    private Date DT_FIN;
    /**
     * Numero da parcela do ICMS.
     */
    private int NUM_PARC;
    /**
     * Valor da parcela de ICMS passivel de apropriacao - antes da aplicacao da 
     * participacao percentual do valor das saidas tributadas/exportacao sobre 
     * as saidas totais.
     */
    private double VL_PARC_PASS;
    /**
     * Valor do somatorio das saidas tributadas e saidas para exportacao no 
     * periodo indicado neste registro.
     */
    private double VL_TRIB_OC;
    /**
     * Valor total de saidas no periodo indicado neste registro.
     */
    private double VL_TOTAL;
    /**
     * Indice de participacao do valor do somatorio das saidas tributadas e 
     * saidas para exportacao no valor total de saidas (Campo 06 dividido pelo campo 07).
     */
    private double IND_PER_SAI;
    /**
     * Valor de outros creditos de ICMS a ser apropriado como na apuracao (campo 05 vezes o campo 08). 
     */
    private double VL_PARC_APROP;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Data inicial do periodo de apuracao.
     * @return the DT_INI
     */
    public Date getDT_INI() {
        return DT_INI;
    }

    /**
     * Data inicial do periodo de apuracao.
     * @param DT_INI the DT_INI to set
     */
    public void setDT_INI(Date DT_INI) {
        this.DT_INI = DT_INI;
    }

    /**
     * Data final do periodo de apuracao.
     * @return the DT_FIN
     */
    public Date getDT_FIN() {
        return DT_FIN;
    }

    /**
     * Data final do periodo de apuracao.
     * @param DT_FIN the DT_FIN to set
     */
    public void setDT_FIN(Date DT_FIN) {
        this.DT_FIN = DT_FIN;
    }

    /**
     * Numero da parcela do ICMS.
     * @return the NUM_PARC
     */
    public int getNUM_PARC() {
        return NUM_PARC;
    }

    /**
     * Numero da parcela do ICMS.
     * @param NUM_PARC the NUM_PARC to set
     */
    public void setNUM_PARC(int NUM_PARC) {
        this.NUM_PARC = NUM_PARC;
    }

    /**
     * Valor da parcela de ICMS passivel de apropriacao - antes da aplicacao da
     * participacao percentual do valor das saidas tributadas/exportacao sobre
     * as saidas totais.
     * @return the VL_PARC_PASS
     */
    public double getVL_PARC_PASS() {
        return VL_PARC_PASS;
    }

    /**
     * Valor da parcela de ICMS passivel de apropriacao - antes da aplicacao da
     * participacao percentual do valor das saidas tributadas/exportacao sobre
     * as saidas totais.
     * @param VL_PARC_PASS the VL_PARC_PASS to set
     */
    public void setVL_PARC_PASS(double VL_PARC_PASS) {
        this.VL_PARC_PASS = VL_PARC_PASS;
    }

    /**
     * Valor do somatorio das saidas tributadas e saidas para exportacao no
     * periodo indicado neste registro.
     * @return the VL_TRIB_OC
     */
    public double getVL_TRIB_OC() {
        return VL_TRIB_OC;
    }

    /**
     * Valor do somatorio das saidas tributadas e saidas para exportacao no
     * periodo indicado neste registro.
     * @param VL_TRIB_OC the VL_TRIB_OC to set
     */
    public void setVL_TRIB_OC(double VL_TRIB_OC) {
        this.VL_TRIB_OC = VL_TRIB_OC;
    }

    /**
     * Valor total de saidas no periodo indicado neste registro.
     * @return the VL_TOTAL
     */
    public double getVL_TOTAL() {
        return VL_TOTAL;
    }

    /**
     * Valor total de saidas no periodo indicado neste registro.
     * @param VL_TOTAL the VL_TOTAL to set
     */
    public void setVL_TOTAL(double VL_TOTAL) {
        this.VL_TOTAL = VL_TOTAL;
    }

    /**
     * Indice de participacao do valor do somatorio das saidas tributadas e
     * saidas para exportacao no valor total de saidas (Campo 06 dividido pelo campo 07).
     * @return the IND_PER_SAI
     */
    public double getIND_PER_SAI() {
        return IND_PER_SAI;
    }

    /**
     * Indice de participacao do valor do somatorio das saidas tributadas e
     * saidas para exportacao no valor total de saidas (Campo 06 dividido pelo campo 07).
     * @param IND_PER_SAI the IND_PER_SAI to set
     */
    public void setIND_PER_SAI(double IND_PER_SAI) {
        this.IND_PER_SAI = IND_PER_SAI;
    }

    /**
     * Valor de outros creditos de ICMS a ser apropriado como na apuracao (campo 05 vezes o campo 08).
     * @return the VL_PARC_APROP
     */
    public double getVL_PARC_APROP() {
        return VL_PARC_APROP;
    }

    /**
     * Valor de outros creditos de ICMS a ser apropriado como na apuracao (campo 05 vezes o campo 08).
     * @param VL_PARC_APROP the VL_PARC_APROP to set
     */
    public void setVL_PARC_APROP(double VL_PARC_APROP) {
        this.VL_PARC_APROP = VL_PARC_APROP;
    }
    // </editor-fold>    
    
}