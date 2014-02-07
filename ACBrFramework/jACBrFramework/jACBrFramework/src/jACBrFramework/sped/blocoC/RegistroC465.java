package jACBrFramework.sped.blocoC;

/**
 * Complemento do cupom fiscal eletronico emitido por ECF - ECF-e-ECF (codigo 60).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 18:23:41, revisao: $Id$
 */
public class RegistroC465 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Chave do Cupom Fiscal Eletronico.
     */
    private String CHV_CFE;
    /**
     * Numero do Contador de Cupom Fiscal.
     */
    private int NUM_CCF;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Chave do Cupom Fiscal Eletronico.
     * @return the CHV_CFE
     */
    public String getCHV_CFE() {
        return CHV_CFE;
    }

    /**
     * Chave do Cupom Fiscal Eletronico.
     * @param CHV_CFE the CHV_CFE to set
     */
    public void setCHV_CFE(String CHV_CFE) {
        this.CHV_CFE = CHV_CFE;
    }

    /**
     * Numero do Contador de Cupom Fiscal.
     * @return the NUM_CCF
     */
    public int getNUM_CCF() {
        return NUM_CCF;
    }

    /**
     * Numero do Contador de Cupom Fiscal.
     * @param NUM_CCF the NUM_CCF to set
     */
    public void setNUM_CCF(int NUM_CCF) {
        this.NUM_CCF = NUM_CCF;
    }
    // </editor-fold>
    
}