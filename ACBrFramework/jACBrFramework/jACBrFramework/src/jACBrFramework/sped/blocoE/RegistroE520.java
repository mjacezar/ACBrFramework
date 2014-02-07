package jACBrFramework.sped.blocoE;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Apuracao do IPI.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:09:49, revisao: $Id$
 */
public class RegistroE520 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Ajustes da apuracao do IPI.
     */
    private Collection<RegistroE530> registroE530 = new ArrayList<RegistroE530>();     
    /**
     * Saldo credor do IPI transferido do periodo anterior.
     */
    private double VL_SD_ANT_IPI;
    /**
     * Valor total dos debitos por "Saidas com debito do imposto".
     */
    private double VL_DEB_IPI;
    /**
     * Valor total dos creditos por "Entradas e aquisicoes com credito do imposto".
     */
    private double VL_CRED_IPI;
    /**
     * Valor de "Outros debitos" do IPI (inclusive estornos de credito).
     */
    private double VL_OD_IPI;
    /**
     * Valor de "Outros creditos" do IPI (inclusive estornos de debitos).
     */
    private double VL_OC_IPI;
    /**
     * Valor do saldo credor do IPI a transportar para o período seguinte
     */
    private double VL_SC_IPI;
    /**
     * Valor do saldo devedor do IPI a recolher.
     */
    private double VL_SD_IPI;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Ajustes da apuracao do IPI.
     * @return the registroE530
     */
    public Collection<RegistroE530> getRegistroE530() {
        return registroE530;
    }

    /**
     * Saldo credor do IPI transferido do periodo anterior.
     * @return the VL_SD_ANT_IPI
     */
    public double getVL_SD_ANT_IPI() {
        return VL_SD_ANT_IPI;
    }

    /**
     * Saldo credor do IPI transferido do periodo anterior.
     * @param VL_SD_ANT_IPI the VL_SD_ANT_IPI to set
     */
    public void setVL_SD_ANT_IPI(double VL_SD_ANT_IPI) {
        this.VL_SD_ANT_IPI = VL_SD_ANT_IPI;
    }

    /**
     * Valor total dos debitos por "Saidas com debito do imposto".
     * @return the VL_DEB_IPI
     */
    public double getVL_DEB_IPI() {
        return VL_DEB_IPI;
    }

    /**
     * Valor total dos debitos por "Saidas com debito do imposto".
     * @param VL_DEB_IPI the VL_DEB_IPI to set
     */
    public void setVL_DEB_IPI(double VL_DEB_IPI) {
        this.VL_DEB_IPI = VL_DEB_IPI;
    }

    /**
     * Valor total dos creditos por "Entradas e aquisicoes com credito do imposto".
     * @return the VL_CRED_IPI
     */
    public double getVL_CRED_IPI() {
        return VL_CRED_IPI;
    }

    /**
     * Valor total dos creditos por "Entradas e aquisicoes com credito do imposto".
     * @param VL_CRED_IPI the VL_CRED_IPI to set
     */
    public void setVL_CRED_IPI(double VL_CRED_IPI) {
        this.VL_CRED_IPI = VL_CRED_IPI;
    }

    /**
     * Valor de "Outros debitos" do IPI (inclusive estornos de credito).
     * @return the VL_OD_IPI
     */
    public double getVL_OD_IPI() {
        return VL_OD_IPI;
    }

    /**
     * Valor de "Outros debitos" do IPI (inclusive estornos de credito).
     * @param VL_OD_IPI the VL_OD_IPI to set
     */
    public void setVL_OD_IPI(double VL_OD_IPI) {
        this.VL_OD_IPI = VL_OD_IPI;
    }

    /**
     * Valor de "Outros creditos" do IPI (inclusive estornos de debitos).
     * @return the VL_OC_IPI
     */
    public double getVL_OC_IPI() {
        return VL_OC_IPI;
    }

    /**
     * Valor de "Outros creditos" do IPI (inclusive estornos de debitos).
     * @param VL_OC_IPI the VL_OC_IPI to set
     */
    public void setVL_OC_IPI(double VL_OC_IPI) {
        this.VL_OC_IPI = VL_OC_IPI;
    }

    /**
     * Valor do saldo credor do IPI a transportar para o período seguinte
     * @return the VL_SC_IPI
     */
    public double getVL_SC_IPI() {
        return VL_SC_IPI;
    }

    /**
     * Valor do saldo credor do IPI a transportar para o período seguinte
     * @param VL_SC_IPI the VL_SC_IPI to set
     */
    public void setVL_SC_IPI(double VL_SC_IPI) {
        this.VL_SC_IPI = VL_SC_IPI;
    }

    /**
     * Valor do saldo devedor do IPI a recolher.
     * @return the VL_SD_IPI
     */
    public double getVL_SD_IPI() {
        return VL_SD_IPI;
    }

    /**
     * Valor do saldo devedor do IPI a recolher.
     * @param VL_SD_IPI the VL_SD_IPI to set
     */
    public void setVL_SD_IPI(double VL_SD_IPI) {
        this.VL_SD_IPI = VL_SD_IPI;
    }
    // </editor-fold>    
    
}