package jACBrFramework.sped.blocoC;

import java.util.Date;

/**
 * Vencimento da fatura (codigo 01).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 13:40:52, revisao: $Id$
 */
public class RegistroC141 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero da parcela a receber/pagar.
     */
    private String NUM_PARC;
    /**
     * Data de vencimento da parcela.
     */
    private Date DT_VCTO;
    /**
     * Valor da parcela a receber/pagar.
     */
    private double VL_PARC;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Numero da parcela a receber/pagar.
     * @return the NUM_PARC
     */
    public String getNUM_PARC() {
        return NUM_PARC;
    }

    /**
     * Numero da parcela a receber/pagar.
     * @param NUM_PARC the NUM_PARC to set
     */
    public void setNUM_PARC(String NUM_PARC) {
        this.NUM_PARC = NUM_PARC;
    }

    /**
     * Data de vencimento da parcela.
     * @return the DT_VCTO
     */
    public Date getDT_VCTO() {
        return DT_VCTO;
    }

    /**
     * Data de vencimento da parcela.
     * @param DT_VCTO the DT_VCTO to set
     */
    public void setDT_VCTO(Date DT_VCTO) {
        this.DT_VCTO = DT_VCTO;
    }

    /**
     * Valor da parcela a receber/pagar.
     * @return the VL_PARC
     */
    public double getVL_PARC() {
        return VL_PARC;
    }

    /**
     * Valor da parcela a receber/pagar.
     * @param VL_PARC the VL_PARC to set
     */
    public void setVL_PARC(double VL_PARC) {
        this.VL_PARC = VL_PARC;
    }
    // </editor-fold>
    
}