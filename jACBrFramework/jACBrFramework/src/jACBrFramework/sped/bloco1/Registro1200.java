package jACBrFramework.sped.bloco1;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Controle de creditos fiscais - ICMS
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 16:41:30, revisao: $Id$
 */
public class Registro1200 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Utilizacao de creditos fiscais - ICMS.
     */
    private Collection<Registro1210> registro1210 = new ArrayList<Registro1210>();    
    /**
     * Codigo de ajuste, conforme informado na Tabela indicada no item 5.1.1..
     */
    private String COD_AJ_APUR;
    /**
     * Saldo de creditos fiscais de periodos anteriores.
     */
    private double SLD_CRED;
    /**
     * Total de credito apropriado no mes.
     */
    private double CRED_APR;
    /**
     * Total de creditos recebidos por transferencia.
     */
    private double CRED_RECEB;
    /**
     * Total de creditos utilizados no periodo.
     */
    private double CRED_UTIL;
    /**
     * Saldo de credito fiscal acumulado a transportar para o periodo seguinte.
     */
    private double SLD_CRED_FIM;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Utilizacao de creditos fiscais - ICMS.
     * @return the registro1210
     */
    public Collection<Registro1210> getRegistro1210() {
        return registro1210;
    }

    /**
     * Codigo de ajuste, conforme informado na Tabela indicada no item 5.1.1..
     * @return the COD_AJ_APUR
     */
    public String getCOD_AJ_APUR() {
        return COD_AJ_APUR;
    }

    /**
     * Codigo de ajuste, conforme informado na Tabela indicada no item 5.1.1..
     * @param COD_AJ_APUR the COD_AJ_APUR to set
     */
    public void setCOD_AJ_APUR(String COD_AJ_APUR) {
        this.COD_AJ_APUR = COD_AJ_APUR;
    }

    /**
     * Saldo de creditos fiscais de periodos anteriores.
     * @return the SLD_CRED
     */
    public double getSLD_CRED() {
        return SLD_CRED;
    }

    /**
     * Saldo de creditos fiscais de periodos anteriores.
     * @param SLD_CRED the SLD_CRED to set
     */
    public void setSLD_CRED(double SLD_CRED) {
        this.SLD_CRED = SLD_CRED;
    }

    /**
     * Total de credito apropriado no mes.
     * @return the CRED_APR
     */
    public double getCRED_APR() {
        return CRED_APR;
    }

    /**
     * Total de credito apropriado no mes.
     * @param CRED_APR the CRED_APR to set
     */
    public void setCRED_APR(double CRED_APR) {
        this.CRED_APR = CRED_APR;
    }

    /**
     * Total de creditos recebidos por transferencia.
     * @return the CRED_RECEB
     */
    public double getCRED_RECEB() {
        return CRED_RECEB;
    }

    /**
     * Total de creditos recebidos por transferencia.
     * @param CRED_RECEB the CRED_RECEB to set
     */
    public void setCRED_RECEB(double CRED_RECEB) {
        this.CRED_RECEB = CRED_RECEB;
    }

    /**
     * Total de creditos utilizados no periodo.
     * @return the CRED_UTIL
     */
    public double getCRED_UTIL() {
        return CRED_UTIL;
    }

    /**
     * Total de creditos utilizados no periodo.
     * @param CRED_UTIL the CRED_UTIL to set
     */
    public void setCRED_UTIL(double CRED_UTIL) {
        this.CRED_UTIL = CRED_UTIL;
    }

    /**
     * Saldo de credito fiscal acumulado a transportar para o periodo seguinte.
     * @return the SLD_CRED_FIM
     */
    public double getSLD_CRED_FIM() {
        return SLD_CRED_FIM;
    }

    /**
     * Saldo de credito fiscal acumulado a transportar para o periodo seguinte.
     * @param SLD_CRED_FIM the SLD_CRED_FIM to set
     */
    public void setSLD_CRED_FIM(double SLD_CRED_FIM) {
        this.SLD_CRED_FIM = SLD_CRED_FIM;
    }
    // </editor-fold>
    
}