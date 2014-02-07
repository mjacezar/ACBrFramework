package jACBrFramework.sped.blocoG;

import java.util.ArrayList;
import java.util.Collection;

/**
 * ICMS - Ativo Permanente - CIAP.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:53:49, revisao: $Id$
 */
public class RegistroG110 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Movimentacao de bem ou componente do ativo imobilizado.
     */
    private Collection<RegistroG125> registroG125 = new ArrayList<RegistroG125>();     
    /**
     * Modelo de CIAP adotado: "C" ou "D". Ate a versao 102.
     */
    private String MODO_CIAP; 
    /**
     * Saldo inicial de ICMS do CIAP, composto por ICMS de bens que entraram 
     * anteriormente ao periodo de apuracao (somatorio dos campos 05 a 08 dos registros G125).
     */
    private double SALDO_IN_ICMS;
    /**
     * Saldo final de ICMS do CIAP, utilizado como base de calculo do ICMS 
     * apropriado no periodo de apuracao (Modelo C). Ate a versao 102.
     */
    private double SALDO_FN_ICMS; 
    /**
     * Somatorio das parcelas de ICMS passivel de apropriacao de cada bem (campo 10 do G125).
     */
    private double SOM_PARC;
    /**
     * Valor do somatorio das saidas tributadas e saidas para exportacao.
     */
    private double VL_TRIB_EXP;
    /**
     * Valor total de saidas.
     */
    private double VL_TOTAL;
    /**
     * Indice de participacao do valor do somatorio das saidas tributadas e 
     * saidas para exportacao no valor total de saidas (Campo 06 dividido pelo campo 07).
     */
    private double IND_PER_SAI;
    /**
     * Valor de ICMS a ser apropriado na apuracao do ICMS, correspondente a 
     * multiplicacao do campo 05 pelo campo 08. 
     */
    private double ICMS_APROP;
    /**
     * Valor de outros creditos a ser apropriado na apuracao do ICMS, 
     * correspondente ao somatorio do campo 09 dos registros G126.
     */
    private double SOM_ICMS_OC;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Movimentacao de bem ou componente do ativo imobilizado.
     * @return the registroG125
     */
    public Collection<RegistroG125> getRegistroG125() {
        return registroG125;
    }

    /**
     * Modelo de CIAP adotado: "C" ou "D". Ate a versao 102.
     * @return the MODO_CIAP
     */
    public String getMODO_CIAP() {
        return MODO_CIAP;
    }

    /**
     * Modelo de CIAP adotado: "C" ou "D". Ate a versao 102.
     * @param MODO_CIAP the MODO_CIAP to set
     */
    public void setMODO_CIAP(String MODO_CIAP) {
        this.MODO_CIAP = MODO_CIAP;
    }

    /**
     * Saldo inicial de ICMS do CIAP, composto por ICMS de bens que entraram
     * anteriormente ao periodo de apuracao (somatorio dos campos 05 a 08 dos registros G125).
     * @return the SALDO_IN_ICMS
     */
    public double getSALDO_IN_ICMS() {
        return SALDO_IN_ICMS;
    }

    /**
     * Saldo inicial de ICMS do CIAP, composto por ICMS de bens que entraram
     * anteriormente ao periodo de apuracao (somatorio dos campos 05 a 08 dos registros G125).
     * @param SALDO_IN_ICMS the SALDO_IN_ICMS to set
     */
    public void setSALDO_IN_ICMS(double SALDO_IN_ICMS) {
        this.SALDO_IN_ICMS = SALDO_IN_ICMS;
    }

    /**
     * Saldo final de ICMS do CIAP, utilizado como base de calculo do ICMS
     * apropriado no periodo de apuracao (Modelo C). Ate a versao 102.
     * @return the SALDO_FN_ICMS
     */
    public double getSALDO_FN_ICMS() {
        return SALDO_FN_ICMS;
    }

    /**
     * Saldo final de ICMS do CIAP, utilizado como base de calculo do ICMS
     * apropriado no periodo de apuracao (Modelo C). Ate a versao 102.
     * @param SALDO_FN_ICMS the SALDO_FN_ICMS to set
     */
    public void setSALDO_FN_ICMS(double SALDO_FN_ICMS) {
        this.SALDO_FN_ICMS = SALDO_FN_ICMS;
    }

    /**
     * Somatorio das parcelas de ICMS passivel de apropriacao de cada bem (campo 10 do G125).
     * @return the SOM_PARC
     */
    public double getSOM_PARC() {
        return SOM_PARC;
    }

    /**
     * Somatorio das parcelas de ICMS passivel de apropriacao de cada bem (campo 10 do G125).
     * @param SOM_PARC the SOM_PARC to set
     */
    public void setSOM_PARC(double SOM_PARC) {
        this.SOM_PARC = SOM_PARC;
    }

    /**
     * Valor do somatorio das saidas tributadas e saidas para exportacao.
     * @return the VL_TRIB_EXP
     */
    public double getVL_TRIB_EXP() {
        return VL_TRIB_EXP;
    }

    /**
     * Valor do somatorio das saidas tributadas e saidas para exportacao.
     * @param VL_TRIB_EXP the VL_TRIB_EXP to set
     */
    public void setVL_TRIB_EXP(double VL_TRIB_EXP) {
        this.VL_TRIB_EXP = VL_TRIB_EXP;
    }

    /**
     * Valor total de saidas.
     * @return the VL_TOTAL
     */
    public double getVL_TOTAL() {
        return VL_TOTAL;
    }

    /**
     * Valor total de saidas.
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
     * Valor de ICMS a ser apropriado na apuracao do ICMS, correspondente a
     * multiplicacao do campo 05 pelo campo 08.
     * @return the ICMS_APROP
     */
    public double getICMS_APROP() {
        return ICMS_APROP;
    }

    /**
     * Valor de ICMS a ser apropriado na apuracao do ICMS, correspondente a
     * multiplicacao do campo 05 pelo campo 08.
     * @param ICMS_APROP the ICMS_APROP to set
     */
    public void setICMS_APROP(double ICMS_APROP) {
        this.ICMS_APROP = ICMS_APROP;
    }

    /**
     * Valor de outros creditos a ser apropriado na apuracao do ICMS,
     * correspondente ao somatorio do campo 09 dos registros G126.
     * @return the SOM_ICMS_OC
     */
    public double getSOM_ICMS_OC() {
        return SOM_ICMS_OC;
    }

    /**
     * Valor de outros creditos a ser apropriado na apuracao do ICMS,
     * correspondente ao somatorio do campo 09 dos registros G126.
     * @param SOM_ICMS_OC the SOM_ICMS_OC to set
     */
    public void setSOM_ICMS_OC(double SOM_ICMS_OC) {
        this.SOM_ICMS_OC = SOM_ICMS_OC;
    }
    // </editor-fold>    
    
}