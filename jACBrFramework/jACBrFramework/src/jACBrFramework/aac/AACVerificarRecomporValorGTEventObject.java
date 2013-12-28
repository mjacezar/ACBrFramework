package jACBrFramework.aac;

import java.util.EventObject;

/**
 * Evento acionado ao recompor valor GT.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 16:51:46, revisao: $Id$
 */
public class AACVerificarRecomporValorGTEventObject extends EventObject {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero de serie.
     */
    private String numSerie;
    /**
     * Valor GT.
     */
    private double valorGT;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AACVerificarRecomporValorGTEventObject(Object pSource, String pNumSerie, double pValorGT) {
        super(pSource);
        this.numSerie = pNumSerie;
        this.valorGT = pValorGT;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Numero de serie.
     * @return the numSerie
     */
    public String getNumSerie() {
        return numSerie;
    }

    /**
     * Valor GT.
     * @return the valorGT
     */
    public double getValorGT() {
        return valorGT;
    }

    /**
     * Valor GT.
     * @param valorGT the valorGT to set
     */
    public void setValorGT(double valorGT) {
        this.valorGT = valorGT;
    }
    // </editor-fold>    
}