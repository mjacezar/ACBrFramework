package jACBrFramework.sped.blocoC;

/**
 * Armazenamento de combustiveis (codigo 01, 55)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 14:42:49, revisao: $Id$
 */
public class RegistroC171 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tanque onde foi armazenado o combustivel.
     */
    private String NUM_TANQUE;
    /**
     * Quantidade ou volume armazenado.
     */
    private double QTDE;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Tanque onde foi armazenado o combustivel.
     * @return the NUM_TANQUE
     */
    public String getNUM_TANQUE() {
        return NUM_TANQUE;
    }

    /**
     * Tanque onde foi armazenado o combustivel.
     * @param NUM_TANQUE the NUM_TANQUE to set
     */
    public void setNUM_TANQUE(String NUM_TANQUE) {
        this.NUM_TANQUE = NUM_TANQUE;
    }

    /**
     * Quantidade ou volume armazenado.
     * @return the QTDE
     */
    public double getQTDE() {
        return QTDE;
    }

    /**
     * Quantidade ou volume armazenado.
     * @param QTDE the QTDE to set
     */
    public void setQTDE(double QTDE) {
        this.QTDE = QTDE;
    }
    // </editor-fold>
    
}