package jACBrFramework.sped.blocoD;

/**
 * Registro de informacoes de outras UFs, relativamente aos servicos "nao-medidos"
 * de televisao por asssinatura via satelite. 
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 10:37:56, revisao: $Id$
 */
public class RegistroD697 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Sigla da unidade da federacao.
     */
    private String UF;
    /**
     * Valor da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor do ICMS.
     */
    private double VL_ICMS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Sigla da unidade da federacao.
     * @return the UF
     */
    public String getUF() {
        return UF;
    }

    /**
     * Sigla da unidade da federacao.
     * @param UF the UF to set
     */
    public void setUF(String UF) {
        this.UF = UF;
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
     * Valor do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }
    // </editor-fold>    
    
}