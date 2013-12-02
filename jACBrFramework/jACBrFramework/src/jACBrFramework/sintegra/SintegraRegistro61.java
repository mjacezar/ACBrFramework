package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Documentos fiscais não emitidos por equipamento emissor de cupom fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:37:18, revisao: $Id$
 */
public class SintegraRegistro61 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">              
    /**
     * Data de emissao do(s) documento(s) fiscal(is).
     */
    private Date emissao;
    /**
     * Valor total do(s) documento(s) fiscal(is)/movimento diario (com 2 decimais).
     */
    private double valor;
    /**
     * Valor do montante do imposto/ total diario (com 2 decimais).
     */
    private double valorIcms;
    /**
     * Valor que nao confira debito ou credito de ICMS/total diario (com 2 decimais).
     */
    private double outras;
    /**
     * Base de calculo do(s) documento(s) fiscal(is)/total diario (com 2 decimais).
     */
    private double baseCalculo;
    /**
     * Valor amparado por isencao ou nao-incidencia/total diario (com 2 decimais).
     */
    private double isentas;
    /**
     * Numero do primeiro documento fiscal emitido no dia do mesmo modelo, serie e subserie.
     */
    private int numOrdemInicial;
    /**
     * Numero do ultimo documento fiscal emitido no dia do mesmo modelo, serie e subserie.
     */
    private int numOrdemFinal;
    /**
     * Modelo do(s) documento(s) fiscal(is).
     */
    private String modelo;
    /**
     * Subserie do(s) documento(s) fiscal(is).
     */
    private String subSerie;
    /**
     * Serie do(s) documento(s) fiscal(is).
     */
    private String serie;
    /**
     * Aliquota do ICMS ( com 2 decimais).
     */
    private double aliquota;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Data de emissao do(s) documento(s) fiscal(is).
     * @return the emissao
     */
    public Date getEmissao() {
        return emissao;
    }

    /**
     * Data de emissao do(s) documento(s) fiscal(is).
     * @param emissao the emissao to set
     */
    public void setEmissao(Date emissao) {
        this.emissao = emissao;
    }

    /**
     * Valor total do(s) documento(s) fiscal(is)/movimento diario (com 2 decimais).
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor total do(s) documento(s) fiscal(is)/movimento diario (com 2 decimais).
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Valor do montante do imposto/ total diario (com 2 decimais).
     * @return the valorIcms
     */
    public double getValorIcms() {
        return valorIcms;
    }

    /**
     * Valor do montante do imposto/ total diario (com 2 decimais).
     * @param valorIcms the valorIcms to set
     */
    public void setValorIcms(double valorIcms) {
        this.valorIcms = valorIcms;
    }

    /**
     * Valor que nao confira debito ou credito de ICMS/total diario (com 2 decimais).
     * @return the outras
     */
    public double getOutras() {
        return outras;
    }

    /**
     * Valor que nao confira debito ou credito de ICMS/total diario (com 2 decimais).
     * @param outras the outras to set
     */
    public void setOutras(double outras) {
        this.outras = outras;
    }

    /**
     * Base de calculo do(s) documento(s) fiscal(is)/total diario (com 2 decimais).
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Base de calculo do(s) documento(s) fiscal(is)/total diario (com 2 decimais).
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }

    /**
     * Valor amparado por isencao ou nao-incidencia/total diario (com 2 decimais).
     * @return the isentas
     */
    public double getIsentas() {
        return isentas;
    }

    /**
     * Valor amparado por isencao ou nao-incidencia/total diario (com 2 decimais).
     * @param isentas the isentas to set
     */
    public void setIsentas(double isentas) {
        this.isentas = isentas;
    }

    /**
     * Numero do primeiro documento fiscal emitido no dia do mesmo modelo, serie e subserie.
     * @return the numOrdemInicial
     */
    public int getNumOrdemInicial() {
        return numOrdemInicial;
    }

    /**
     * Numero do primeiro documento fiscal emitido no dia do mesmo modelo, serie e subserie.
     * @param numOrdemInicial the numOrdemInicial to set
     */
    public void setNumOrdemInicial(int numOrdemInicial) {
        this.numOrdemInicial = numOrdemInicial;
    }

    /**
     * Numero do ultimo documento fiscal emitido no dia do mesmo modelo, serie e subserie.
     * @return the numOrdemFinal
     */
    public int getNumOrdemFinal() {
        return numOrdemFinal;
    }

    /**
     * Numero do ultimo documento fiscal emitido no dia do mesmo modelo, serie e subserie.
     * @param numOrdemFinal the numOrdemFinal to set
     */
    public void setNumOrdemFinal(int numOrdemFinal) {
        this.numOrdemFinal = numOrdemFinal;
    }

    /**
     * Modelo do(s) documento(s) fiscal(is).
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Modelo do(s) documento(s) fiscal(is).
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    /**
     * Subserie do(s) documento(s) fiscal(is).
     * @return the subSerie
     */
    public String getSubSerie() {
        return subSerie;
    }

    /**
     * Subserie do(s) documento(s) fiscal(is).
     * @param subSerie the subSerie to set
     */
    public void setSubSerie(String subSerie) {
        this.subSerie = subSerie;
    }

    /**
     * Serie do(s) documento(s) fiscal(is).
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie do(s) documento(s) fiscal(is).
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }

    /**
     * Aliquota do ICMS ( com 2 decimais).
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota do ICMS ( com 2 decimais).
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }    
    // </editor-fold>       
    
}