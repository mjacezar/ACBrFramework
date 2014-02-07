package jACBrFramework.sped.bloco1;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Movimentacao diaria de combustiveis.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 16:55:32, revisao: $Id$
 */
public class Registro1300 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Movimentacao diaria de combustiveis por tanque.
     */
    private Collection<Registro1310> registro1310 = new ArrayList<Registro1310>(); 
    /**
     * Codigo do Produto, constante do registro 0200.
     */
    private String COD_ITEM;
    /**
     * Data do fechamento da movimentacao.
     */
    private Date DT_FECH;
    /**
     * Estoque no inicio do dia, em litros.
     */
    private double ESTQ_ABERT;
    /**
     * Volume Recebido no dia (em litros).
     */
    private double VOL_ENTR;
    /**
     * Volume Disponivel (04 + 05), em litros.
     */
    private double VOL_DISP;
    /**
     * Volume Total das Saidas, em litros.
     */
    private double VOL_SAIDAS;
    /**
     * Estoque Escritural (06 - 07), litros.
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
     * Estoque de Fechamento, em litros.
     */
    private double FECH_FISICO;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Movimentacao diaria de combustiveis por tanque.
     * @return the registro1310
     */
    public Collection<Registro1310> getRegistro1310() {
        return registro1310;
    }

    /**
     * Codigo do Produto, constante do registro 0200.
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do Produto, constante do registro 0200.
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Data do fechamento da movimentacao.
     * @return the DT_FECH
     */
    public Date getDT_FECH() {
        return DT_FECH;
    }

    /**
     * Data do fechamento da movimentacao.
     * @param DT_FECH the DT_FECH to set
     */
    public void setDT_FECH(Date DT_FECH) {
        this.DT_FECH = DT_FECH;
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
     * Volume Disponivel (04 + 05), em litros.
     * @return the VOL_DISP
     */
    public double getVOL_DISP() {
        return VOL_DISP;
    }

    /**
     * Volume Disponivel (04 + 05), em litros.
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
     * Estoque Escritural (06 - 07), litros.
     * @return the ESTQ_ESCR
     */
    public double getESTQ_ESCR() {
        return ESTQ_ESCR;
    }

    /**
     * Estoque Escritural (06 - 07), litros.
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
     * Estoque de Fechamento, em litros.
     * @return the FECH_FISICO
     */
    public double getFECH_FISICO() {
        return FECH_FISICO;
    }

    /**
     * Estoque de Fechamento, em litros.
     * @param FECH_FISICO the FECH_FISICO to set
     */
    public void setFECH_FISICO(double FECH_FISICO) {
        this.FECH_FISICO = FECH_FISICO;
    }
    // </editor-fold>
    
}