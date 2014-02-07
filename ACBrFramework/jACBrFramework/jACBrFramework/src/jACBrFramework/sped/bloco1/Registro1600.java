package jACBrFramework.sped.bloco1;

/**
 * Total das operacoes com cartao de credito e/ou debito.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 09:04:35, revisao: $Id$
 */
public class Registro1600 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante (campo 02 do Registro 0150): identificacao da 
     * administradora do cartao de debito/credito.
     */
    private String COD_PART;
    /**
     * Valor total das operacoes realizadas no periodo referente a Cartao de Credito.
     */
    private double TOT_CREDITO;
    /**
     * Valor total das operacoes realizadas no periodo referente a Cartão de Debito.
     */
    private double TOT_DEBITO;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Codigo do participante (campo 02 do Registro 0150): identificacao da
     * administradora do cartao de debito/credito.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): identificacao da
     * administradora do cartao de debito/credito.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Valor total das operacoes realizadas no periodo referente a Cartao de Credito.
     * @return the TOT_CREDITO
     */
    public double getTOT_CREDITO() {
        return TOT_CREDITO;
    }

    /**
     * Valor total das operacoes realizadas no periodo referente a Cartao de Credito.
     * @param TOT_CREDITO the TOT_CREDITO to set
     */
    public void setTOT_CREDITO(double TOT_CREDITO) {
        this.TOT_CREDITO = TOT_CREDITO;
    }

    /**
     * Valor total das operacoes realizadas no periodo referente a Cartão de Debito.
     * @return the TOT_DEBITO
     */
    public double getTOT_DEBITO() {
        return TOT_DEBITO;
    }

    /**
     * Valor total das operacoes realizadas no periodo referente a Cartão de Debito.
     * @param TOT_DEBITO the TOT_DEBITO to set
     */
    public void setTOT_DEBITO(double TOT_DEBITO) {
        this.TOT_DEBITO = TOT_DEBITO;
    }
    // </editor-fold>
    
}