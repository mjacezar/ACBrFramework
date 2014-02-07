package jACBrFramework.sped.bloco9;

/**
 * Registros do arquivo.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:17:40, revisao: $Id$
 */
public class Registro9900 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Registro que sera totalizado no próximo campo.
     */
    private String REG_BLC;
    /**
     * Total de registros do tipo informado no campo anterior.
     */
    private int QTD_REG_BLC;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters"> 
    /**
     * Registro que sera totalizado no próximo campo.
     * @return the REG_BLC
     */
    public String getREG_BLC() {
        return REG_BLC;
    }

    /**
     * Registro que sera totalizado no próximo campo.
     * @param REG_BLC the REG_BLC to set
     */
    public void setREG_BLC(String REG_BLC) {
        this.REG_BLC = REG_BLC;
    }

    /**
     * Total de registros do tipo informado no campo anterior.
     * @return the QTD_REG_BLC
     */
    public int getQTD_REG_BLC() {
        return QTD_REG_BLC;
    }

    /**
     * Total de registros do tipo informado no campo anterior.
     * @param QTD_REG_BLC the QTD_REG_BLC to set
     */
    public void setQTD_REG_BLC(int QTD_REG_BLC) {
        this.QTD_REG_BLC = QTD_REG_BLC;
    }
    // </editor-fold>    
    
}