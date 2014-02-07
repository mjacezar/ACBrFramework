package jACBrFramework.sped.bloco1;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Movimentacao diaria de combustiveis por tanque.
 *
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 17:05:38, revisao: $Id$
 */
public class Registro1310 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Volume de vendas.
     */
    private Collection<Registro1320> registro1320 = new ArrayList<Registro1320>(); 
    /**
     * Tanque que armazena o combustivel.
     */
    private String NUM_TANQUE;
    /**
     * Estoque no inicio do dia, em litros.
     */
    private double ESTQ_ABERT;
    /**
     * Volume Recebido no dia (em litros).
     */
    private double VOL_ENTR;
    /**
     * Volume Disponivel (03 + 04), em litros.
     */
    private double VOL_DISP;
    /**
     * Volume Total das Saidas, em litros.
     */
    private double VOL_SAIDAS;
    /**
     * Estoque Escritural(05 - 06), litros.
     */
    private double ESTQ_ESCR;
    /**
     * Valor da Perda, em litros.
     */
    private double VAL_AJ_PERDA;
    /**
     * Valor do ganho, em litros.
     */
    private double VAL_AJ_GANHO;
    /**
     * Volume aferido no tanque, em litros. Estoque de fechamento fisico do tanque.
     */
    private double FECH_FISICO;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Volume de vendas.
     * @return the registro1320
     */
    public Collection<Registro1320> getRegistro1320() {
        return registro1320;
    }

    /**
     * Tanque que armazena o combustivel.
     * @return the NUM_TANQUE
     */
    public String getNUM_TANQUE() {
        return NUM_TANQUE;
    }

    /**
     * Tanque que armazena o combustivel.
     * @param NUM_TANQUE the NUM_TANQUE to set
     */
    public void setNUM_TANQUE(String NUM_TANQUE) {
        this.NUM_TANQUE = NUM_TANQUE;
    }

    /**
     * Estoque no inicio do dia, em litros.
     * @return the ESTQ_ABERT
     */
    public double getESTQ_ABERT() {
        return ESTQ_ABERT;
    }

    /**
     * Estoque no inicio do dia, em litros.
     * @param ESTQ_ABERT the ESTQ_ABERT to set
     */
    public void setESTQ_ABERT(double ESTQ_ABERT) {
        this.ESTQ_ABERT = ESTQ_ABERT;
    }

    /**
     * Volume Recebido no dia (em litros).
     * @return the VOL_ENTR
     */
    public double getVOL_ENTR() {
        return VOL_ENTR;
    }

    /**
     * Volume Recebido no dia (em litros).
     * @param VOL_ENTR the VOL_ENTR to set
     */
    public void setVOL_ENTR(double VOL_ENTR) {
        this.VOL_ENTR = VOL_ENTR;
    }

    /**
     * Volume Disponivel (03 + 04), em litros.
     * @return the VOL_DISP
     */
    public double getVOL_DISP() {
        return VOL_DISP;
    }

    /**
     * Volume Disponivel (03 + 04), em litros.
     * @param VOL_DISP the VOL_DISP to set
     */
    public void setVOL_DISP(double VOL_DISP) {
        this.VOL_DISP = VOL_DISP;
    }

    /**
     * Volume Total das Saidas, em litros.
     * @return the VOL_SAIDAS
     */
    public double getVOL_SAIDAS() {
        return VOL_SAIDAS;
    }

    /**
     * Volume Total das Saidas, em litros.
     * @param VOL_SAIDAS the VOL_SAIDAS to set
     */
    public void setVOL_SAIDAS(double VOL_SAIDAS) {
        this.VOL_SAIDAS = VOL_SAIDAS;
    }

    /**
     * Estoque Escritural(05 - 06), litros.
     * @return the ESTQ_ESCR
     */
    public double getESTQ_ESCR() {
        return ESTQ_ESCR;
    }

    /**
     * Estoque Escritural(05 - 06), litros.
     * @param ESTQ_ESCR the ESTQ_ESCR to set
     */
    public void setESTQ_ESCR(double ESTQ_ESCR) {
        this.ESTQ_ESCR = ESTQ_ESCR;
    }

    /**
     * Valor da Perda, em litros.
     * @return the VAL_AJ_PERDA
     */
    public double getVAL_AJ_PERDA() {
        return VAL_AJ_PERDA;
    }

    /**
     * Valor da Perda, em litros.
     * @param VAL_AJ_PERDA the VAL_AJ_PERDA to set
     */
    public void setVAL_AJ_PERDA(double VAL_AJ_PERDA) {
        this.VAL_AJ_PERDA = VAL_AJ_PERDA;
    }

    /**
     * Valor do ganho, em litros.
     * @return the VAL_AJ_GANHO
     */
    public double getVAL_AJ_GANHO() {
        return VAL_AJ_GANHO;
    }

    /**
     * Valor do ganho, em litros.
     * @param VAL_AJ_GANHO the VAL_AJ_GANHO to set
     */
    public void setVAL_AJ_GANHO(double VAL_AJ_GANHO) {
        this.VAL_AJ_GANHO = VAL_AJ_GANHO;
    }

    /**
     * Volume aferido no tanque, em litros. Estoque de fechamento fisico do tanque.
     * @return the FECH_FISICO
     */
    public double getFECH_FISICO() {
        return FECH_FISICO;
    }

    /**
     * Volume aferido no tanque, em litros. Estoque de fechamento fisico do tanque.
     * @param FECH_FISICO the FECH_FISICO to set
     */
    public void setFECH_FISICO(double FECH_FISICO) {
        this.FECH_FISICO = FECH_FISICO;
    }
    // </editor-fold>
    
}