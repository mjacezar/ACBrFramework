package jACBrFramework.sped.blocoC;

/**
 * Registro de informacoes de ICMS ST por UF (cod 06).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 10:23:57, revisao: $Id$
 */
public class RegistroC791 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Sigla da unidade da federacao a que se refere a retencao ST.
     */
    private String UF;
    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     */
    private double VL_BC_ICMS_ST;
    /**
     * Valor do ICMS retido por substituicao tributaria.
     */
    private double VL_ICMS_ST;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Sigla da unidade da federacao a que se refere a retencao ST.
     * @return the UF
     */
    public String getUF() {
        return UF;
    }

    /**
     * Sigla da unidade da federacao a que se refere a retencao ST.
     * @param UF the UF to set
     */
    public void setUF(String UF) {
        this.UF = UF;
    }

    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     * @return the VL_BC_ICMS_ST
     */
    public double getVL_BC_ICMS_ST() {
        return VL_BC_ICMS_ST;
    }

    /**
     * Valor da base de calculo do ICMS substituicao tributaria.
     * @param VL_BC_ICMS_ST the VL_BC_ICMS_ST to set
     */
    public void setVL_BC_ICMS_ST(double VL_BC_ICMS_ST) {
        this.VL_BC_ICMS_ST = VL_BC_ICMS_ST;
    }

    /**
     * Valor do ICMS retido por substituicao tributaria.
     * @return the VL_ICMS_ST
     */
    public double getVL_ICMS_ST() {
        return VL_ICMS_ST;
    }

    /**
     * Valor do ICMS retido por substituicao tributaria.
     * @param VL_ICMS_ST the VL_ICMS_ST to set
     */
    public void setVL_ICMS_ST(double VL_ICMS_ST) {
        this.VL_ICMS_ST = VL_ICMS_ST;
    }
    // </editor-fold>
    
}