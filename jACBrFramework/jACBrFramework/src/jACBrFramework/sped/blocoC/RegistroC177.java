package jACBrFramework.sped.blocoC;

/**
 * Operacoes com produtos sujeitos a selo de controle IPI.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 16:22:36, revisao: $Id$
 */
public class RegistroC177 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do selo de controle do IPI, conforme Tabela 4.5.2.
     */
    private String COD_SELO_IPI;
    /**
     * Quantidade de selo de controle do IPI aplicada.
     */
    private double QT_SELO_IPI;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do selo de controle do IPI, conforme Tabela 4.5.2.
     * @return the COD_SELO_IPI
     */
    public String getCOD_SELO_IPI() {
        return COD_SELO_IPI;
    }

    /**
     * Codigo do selo de controle do IPI, conforme Tabela 4.5.2.
     * @param COD_SELO_IPI the COD_SELO_IPI to set
     */
    public void setCOD_SELO_IPI(String COD_SELO_IPI) {
        this.COD_SELO_IPI = COD_SELO_IPI;
    }

    /**
     * Quantidade de selo de controle do IPI aplicada.
     * @return the QT_SELO_IPI
     */
    public double getQT_SELO_IPI() {
        return QT_SELO_IPI;
    }

    /**
     * Quantidade de selo de controle do IPI aplicada.
     * @param QT_SELO_IPI the QT_SELO_IPI to set
     */
    public void setQT_SELO_IPI(double QT_SELO_IPI) {
        this.QT_SELO_IPI = QT_SELO_IPI;
    }
    // </editor-fold>    
    
}