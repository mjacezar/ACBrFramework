package jACBrFramework.sped.blocoC;

/**
 * PIS e Cofins totalizados no dia (codigo 02 e 2D).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 18:08:03, revisao: $Id$
 */
public class RegistroC410 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Valor total do PIS.
     */
    private double VL_PIS;
    /**
     * Valor total da COFINS.
     */
    private double VL_COFINS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Valor total do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor total do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor total da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor total da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }
    // </editor-fold>
    
}