package jACBrFramework.aac;

import java.util.Date;

/**
 * Identificacao das ECFs.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 14:26:26, revisao: $Id$
 */
public class AACECF {

    // <editor-fold defaultstate="collapsed" desc="Attributes">        
    /**
     * Valor do GT.
     */
    private double valorGT;
    /**
     * Numero de serie da ECF.
     */
    private String numeroSerie;
    /**
     * Contador de Reinicio de Operacao.
     */
    private int cro;
    /**
     * Codigo nacional de identificacao da ECF.
     */
    private int cni;
    /**
     * Data e hora atualizado. 
     */
    private Date dtHrAtualizado;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Valor do GT.
     * @return the valorGT
     */
    public double getValorGT() {
        return valorGT;
    }

    /**
     * Valor do GT.
     * @param valorGT the valorGT to set
     */
    public void setValorGT(double valorGT) {
        this.valorGT = valorGT;
    }

    /**
     * Numero de serie da ECF.
     * @return the numeroSerie
     */
    public String getNumeroSerie() {
        return numeroSerie;
    }

    /**
     * Numero de serie da ECF.
     * @param numeroSerie the numeroSerie to set
     */
    public void setNumeroSerie(String numeroSerie) {
        this.numeroSerie = numeroSerie;
    }

    /**
     * Contador de Reinicio de Operacao.
     * @return the cro
     */
    public int getCro() {
        return cro;
    }

    /**
     * Contador de Reinicio de Operacao.
     * @param cro the cro to set
     */
    public void setCro(int cro) {
        this.cro = cro;
    }

    /**
     * Codigo nacional de identificacao da ECF.
     * @return the cni
     */
    public int getCni() {
        return cni;
    }

    /**
     * Codigo nacional de identificacao da ECF.
     * @param cni the cni to set
     */
    public void setCni(int cni) {
        this.cni = cni;
    }

    /**
     * Data e hora atualizado.
     * @return the dtHrAtualizado
     */
    public Date getDtHrAtualizado() {
        return dtHrAtualizado;
    }

    /**
     * Data e hora atualizado.
     * @param dtHrAtualizado the dtHrAtualizado to set
     */
    void setDtHrAtualizado(Date dtHrAtualizado) {
        this.dtHrAtualizado = dtHrAtualizado;
    }
    // </editor-fold>    

}