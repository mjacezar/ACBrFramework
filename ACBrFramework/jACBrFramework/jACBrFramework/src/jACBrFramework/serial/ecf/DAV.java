package jACBrFramework.serial.ecf;

import java.util.Date;

/**
 * Representa a entidade DAV.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/12/2013 14:03:53, revisao: $Id$
 */
public class DAV {
	//<editor-fold defaultstate="collapsed" desc="Fields">
    /**
     * Numero DAV.
     */
	private String numero;
    /**
     * Titulo da DAV.
     */
	private String titulo;
    /**
     * COO do cupom fiscal.
     */
	private int cooCupom;
    /**
     * COO do num dav.
     */
    private int cooDAV;
    /**
     * Valor do DAV.
     */
    private double valor;
    /**
     * Data de emissao do DAV.
     */
    private Date dtEmissao;
	//</editor-fold>		
	//<editor-fold defaultstate="collapsed" desc="Properties">	
    /**
     * Numero DAV.
     * @return the numero
     */
    public String getNumero() {
        return numero;
    }

    /**
     * Numero DAV.
     * @param numero the numero to set
     */
    public void setNumero(String numero) {
        this.numero = numero;
    }

    /**
     * Titulo da DAV.
     * @return the titulo
     */
    public String getTitulo() {
        return titulo;
    }

    /**
     * Titulo da DAV.
     * @param titulo the titulo to set
     */
    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    /**
     * COO do cupom fiscal.
     * @return the cooCupom
     */
    public int getCooCupom() {
        return cooCupom;
    }

    /**
     * COO do cupom fiscal.
     * @param cooCupom the cooCupom to set
     */
    public void setCooCupom(int cooCupom) {
        this.cooCupom = cooCupom;
    }

    /**
     * COO do num dav.
     * @return the cooDAV
     */
    public int getCooDAV() {
        return cooDAV;
    }

    /**
     * COO do num dav.
     * @param cooDAV the cooDAV to set
     */
    public void setCooDAV(int cooDAV) {
        this.cooDAV = cooDAV;
    }

    /**
     * Valor do DAV.
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor do DAV.
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Data de emissao do DAV.
     * @return the dtEmissao
     */
    public Date getDtEmissao() {
        return dtEmissao;
    }

    /**
     * Data de emissao do DAV.
     * @param dtEmissao the dtEmissao to set
     */
    public void setDtEmissao(Date dtEmissao) {
        this.dtEmissao = dtEmissao;
    }
	//</editor-fold>
    
}