package jACBrFramework.sped.blocoC;

/**
 * ISSQN, IRRF e Previdencia Social.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 13:37:03, revisao: $Id$
 */
public class RegistroC130 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Valor dos servicos sob nao-incidencia ou nao-tributados pelo ICMS.
     */
    private double VL_SERV_NT;
    /**
     * Valor da base de calculo do ISSQN.
     */
    private double VL_BC_ISSQN;
    /**
     * Valor do ISSQN.
     */
    private double VL_ISSQN;
    /**
     * Valor da base de calculo do Imposto de Renda Retido na Fonte.
     */
    private double VL_BC_IRRF;
    /**
     * Valor do Imposto de Renda - Retido na Fonte.
     */
    private double VL_IRRF;
    /**
     * Valor da base de calculo de retencao da Previdencia Social.
     */
    private double VL_BC_PREV;
    /**
     * Valor destacado para retencao da Previdencia Social.
     */
    private double VL_PREV;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Valor dos servicos sob nao-incidencia ou nao-tributados pelo ICMS.
     * @return the VL_SERV_NT
     */
    public double getVL_SERV_NT() {
        return VL_SERV_NT;
    }

    /**
     * Valor dos servicos sob nao-incidencia ou nao-tributados pelo ICMS.
     * @param VL_SERV_NT the VL_SERV_NT to set
     */
    public void setVL_SERV_NT(double VL_SERV_NT) {
        this.VL_SERV_NT = VL_SERV_NT;
    }

    /**
     * Valor da base de calculo do ISSQN.
     * @return the VL_BC_ISSQN
     */
    public double getVL_BC_ISSQN() {
        return VL_BC_ISSQN;
    }

    /**
     * Valor da base de calculo do ISSQN.
     * @param VL_BC_ISSQN the VL_BC_ISSQN to set
     */
    public void setVL_BC_ISSQN(double VL_BC_ISSQN) {
        this.VL_BC_ISSQN = VL_BC_ISSQN;
    }

    /**
     * Valor do ISSQN.
     * @return the VL_ISSQN
     */
    public double getVL_ISSQN() {
        return VL_ISSQN;
    }

    /**
     * Valor do ISSQN.
     * @param VL_ISSQN the VL_ISSQN to set
     */
    public void setVL_ISSQN(double VL_ISSQN) {
        this.VL_ISSQN = VL_ISSQN;
    }

    /**
     * Valor da base de calculo do Imposto de Renda Retido na Fonte.
     * @return the VL_BC_IRRF
     */
    public double getVL_BC_IRRF() {
        return VL_BC_IRRF;
    }

    /**
     * Valor da base de calculo do Imposto de Renda Retido na Fonte.
     * @param VL_BC_IRRF the VL_BC_IRRF to set
     */
    public void setVL_BC_IRRF(double VL_BC_IRRF) {
        this.VL_BC_IRRF = VL_BC_IRRF;
    }

    /**
     * Valor do Imposto de Renda - Retido na Fonte.
     * @return the VL_IRRF
     */
    public double getVL_IRRF() {
        return VL_IRRF;
    }

    /**
     * Valor do Imposto de Renda - Retido na Fonte.
     * @param VL_IRRF the VL_IRRF to set
     */
    public void setVL_IRRF(double VL_IRRF) {
        this.VL_IRRF = VL_IRRF;
    }

    /**
     * Valor da base de calculo de retencao da Previdencia Social.
     * @return the VL_BC_PREV
     */
    public double getVL_BC_PREV() {
        return VL_BC_PREV;
    }

    /**
     * Valor da base de calculo de retencao da Previdencia Social.
     * @param VL_BC_PREV the VL_BC_PREV to set
     */
    public void setVL_BC_PREV(double VL_BC_PREV) {
        this.VL_BC_PREV = VL_BC_PREV;
    }

    /**
     * Valor destacado para retencao da Previdencia Social.
     * @return the VL_PREV
     */
    public double getVL_PREV() {
        return VL_PREV;
    }

    /**
     * Valor destacado para retencao da Previdencia Social.
     * @param VL_PREV the VL_PREV to set
     */
    public void setVL_PREV(double VL_PREV) {
        this.VL_PREV = VL_PREV;
    }
    // </editor-fold>
    
}