package jACBrFramework.aac;

import java.util.EventObject;

/**
 * Evento de verificacao de recomposicao de numero de serie.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 16:46:16, revisao: $Id$
 */
public class AACVerificarRecomporNumSerieEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero de Serie.
     */
    private String numSerie;
    /**
     * Valor GT.
     */
    private double valorGT;
    /**
     * Contador de reinicio de operacao.
     */
    private int cro;
    /**
     * Codigo nacional de identificacao.
     */
    private int cni;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AACVerificarRecomporNumSerieEventObject(Object pSource, String pNumSerie,
            double pValorGT, int pCro, int pCni) {
        super(pSource);
        this.numSerie = pNumSerie;
        this.valorGT = pValorGT;
        this.cro = pCro;
        this.cni = pCni;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Numero de Serie.
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
     * Contador de reinicio de operacao.
     * @return the cro
     */
    public int getCro() {
        return cro;
    }

    /**
     * Codigo nacional de identificacao.
     * @return the cni
     */
    public int getCni() {
        return cni;
    }

    /**
     * Contador de reinicio de operacao.
     * @param cro the cro to set
     */
    public void setCro(int cro) {
        this.cro = cro;
    }

    /**
     * Codigo nacional de identificacao.
     * @param cni the cni to set
     */
    public void setCni(int cni) {
        this.cni = cni;
    }
    // </editor-fold>

}